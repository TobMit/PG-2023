using EditorSiete.GraphicalObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
