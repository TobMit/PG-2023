using EditorSiete.GraphicalObjects;
using System.Runtime.Serialization;
using System.Xml;

namespace EditorSiete.Project
{
    public enum EditorState
    {
        None,
        Dragging, 
        AddingEdge
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

            FileStream fs = new FileStream(ProjectPath, FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer serializer = new DataContractSerializer(typeof(NetworkData));

            var data = (NetworkData)serializer.ReadObject(reader, true);

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
