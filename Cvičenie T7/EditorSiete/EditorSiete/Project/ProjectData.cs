using EditorSiete.GraphicalObjects;
using System.Runtime.Serialization;
using System.Xml;

namespace EditorSiete.Project
{
    public enum EditorState
    {
        None,
        Dragging, 
        AddingEdge,
        SelectorTracking
    }

    public enum EditorMode
    {
        EditingNode, 
        EditingEdge
    }

    public static class ProjectData
    {
        public static NetworkNode? SelectedNode;
        public static NetworkNode? ActiveNode;
        public static Point CurrentMousePosition;
        public static bool BackgroundVisible = true;
        public static string BitmapPath = string.Empty;
        public static string ProjectPath = string.Empty;
        public static Bitmap? Bitmap;
        public static NetworkData NetworkData;
        public static bool CTRLKeyPressed; 
 
        public static EditorState State = EditorState.None;
        public static EditorMode Mode = EditorMode.EditingNode;

        static ProjectData()
        {
            NetworkData = new();
            ResetProjectData();
        }

        public static void ResetProjectData()
        {
            NetworkData = new();
            SelectedNode = null;
            ActiveNode = null;
            BackgroundVisible = true;
            BitmapPath = string.Empty;
            Bitmap?.Dispose();

            State = EditorState.None;
            Mode = EditorMode.EditingNode;
        }

        public static bool LoadBitmap()
        {
            if (string.IsNullOrWhiteSpace(BitmapPath))
                return false;

            try
            {
                Bitmap?.Dispose();

                Bitmap = new Bitmap(BitmapPath);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Loading bitmap", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }
        public static NetworkNode? IsNodeHitByMouse(Point mousePosition)
        {
            foreach (NetworkNode node in NetworkData.Nodes)
            {
                if (node.IsHitByMouse(mousePosition))
                {
                    return node;
                }
            }

            return null;
        }

        public static NetworkEdge? IsEdgeHitByMouse(Point mousePosition)
        {
            foreach (NetworkEdge edge in NetworkData.Edges)
                if (edge.IsHitByMouse(mousePosition))
                    return edge;

            return null;
        }

        public static void DeleteNode(NetworkNode? node)
        {
            if (node != null)
                NetworkData.Nodes.Remove(node);
        }

        public static void DeleteEdge(NetworkEdge? edge)
        {
            if (edge != null)
                NetworkData.Edges.Remove(edge);
        }

        public static void SelectNode(NetworkNode? node)
        {
            NetworkData.Nodes.ForEach(x => x.Selected = false);
            SelectedNode = null; 

            if (node != null)
            {
                node.Selected = true;
                SelectedNode = node;
            }
        }

        public static void SelectNode(Rectangle rectangle)
        {
            NetworkData.Nodes.ForEach(x => x.Selected = false);
            SelectedNode = null;

            if (rectangle.IsEmpty)
            {
                return;
            }

            foreach (var node in NetworkData.Nodes)
            {
                if (rectangle.Contains(node.Position))
                {
                    node.Selected = true;
                    SelectedNode = node;
                }
            }
            
        }

        public static List<NetworkNode> GetNetworkNodes()
        {
            return NetworkData.Nodes;
        }

        public static List<NetworkEdge> GetNetworkEdges()
        {
            return NetworkData.Edges;
        }

        public static void LoadNetworkData()
        {
            if (string.IsNullOrWhiteSpace(ProjectPath))
                return;

            ResetProjectData();

            FileStream fs = new(ProjectPath, FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer? serializer = new(typeof(NetworkData));

            if (serializer == null)
                return;

            NetworkData? data = serializer.ReadObject(reader, true) as NetworkData;

            if (data == null)
                return; 

            foreach (var node in data.Nodes) 
            {
                ProjectData.GetNetworkNodes().Add(node);
            }

            foreach (var edge in data.Edges)
            {
                NetworkNode? startNode = ProjectData.GetNetworkNodes().Find(n => n.ID == edge.StartNodeId);
                NetworkNode? endNode = ProjectData.GetNetworkNodes().Find(n => n.ID == edge.EndNodeId);
                
                if (startNode == null || endNode == null)
                    continue;

                ProjectData.GetNetworkEdges().Add(new NetworkEdge(startNode, endNode));
            }

            reader.Close();
            fs.Close();
        }

        public static void SaveNetworkData() 
        {
            if (string.IsNullOrWhiteSpace(ProjectPath))
                return;

            // Creates an instance of the XmlSerializer class;
            // specifies the type of object to serialize.
            var serializer = new DataContractSerializer(NetworkData.GetType());
            FileStream writer = new FileStream(ProjectPath, FileMode.Create);

            serializer.WriteObject(writer, NetworkData);

            writer.Close();
        }
    }
}
