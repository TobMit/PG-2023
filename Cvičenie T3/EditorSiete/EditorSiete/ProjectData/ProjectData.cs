using EditorSiete.GraphicalObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EditorSiete.ProjectData
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
        public static bool BacgroundVisible = true;
        public static string BitmapPath;
        public static Bitmap Bitmap;
        public static List<NetworkNode> Nodes = new();
        public static List<NetworkEdge> Edges = new();
        public static EditorState editorState { get; set; }
        public static NetworkNode? selectedNode;
        public static NetworkNode? activeNode;
        public static EditorMode Mode = EditorMode.EditingNode;
        public static Point CurrentMousePosition;

        public static bool LoadBitmap()
        {
            if(string.IsNullOrWhiteSpace(BitmapPath))
            {
                return false;
            }

            // ak je bitmapa načítaná
            try
            {
                Bitmap?.Dispose();

                Bitmap = new Bitmap(BitmapPath);
                return true;


            } catch (Exception e)
            {
                MessageBox.Show(e.Message, "Loading Bitmap", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static NetworkNode? isNodeHitByMouse(Point mousePosition)
        {
            foreach (NetworkNode node in Nodes)
                if (node.IsHitByMouse(mousePosition))
                {
                    return node;
                }
            return null;
        }

        public static void DeleteNode(NetworkNode? node)
        {
            if (node != null)
            {
                Nodes.Remove(node);
            }
        }

        public static void SelectNode(NetworkNode? node)
        {
            Nodes.ForEach( x => x.Selected = false);
            selectedNode = null;
            if (node != null)
            {
                node.Selected = true;
                selectedNode = node;
            }
        }

        public static void SaveData() 
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "SaveNodes";
            saveFileDialog1.Filter = "XML Files|*.xml";
            saveFileDialog1.ShowDialog();
            List<NetworkNode> networkNodes = new(Nodes);
            XmlSerializer serializer = new XmlSerializer(typeof(List<NetworkNode>)) ;

            TextWriter writer = new StreamWriter(saveFileDialog1.OpenFile());
            serializer.Serialize(writer, networkNodes);
            writer.Close();
        }

        public static void OpenData()
        {
            OpenFileDialog openData = new OpenFileDialog();
            openData.Title = "OpenNodes";
            openData.ShowDialog();

            XmlSerializer serializer = new XmlSerializer(typeof(List<NetworkNode>));
            using var reader = XmlReader.Create(openData.OpenFile());
            Nodes.AddRange((List<NetworkNode>)serializer.Deserialize(reader));

        }
    }
}
