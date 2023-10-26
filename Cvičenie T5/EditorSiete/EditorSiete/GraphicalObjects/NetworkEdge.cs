using EditorSiete.Interfaces;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

namespace EditorSiete.GraphicalObjects
{
    [DataContract(Name = "NetworkEdge")]
    public class NetworkEdge : IDrawable2DObject
    {
        [DataMember()]
        private NetworkNode? startNode;
        [DataMember()]
        private NetworkNode? endNode;
        
        public NetworkEdge()
        {
        }

        public NetworkEdge(NetworkNode stNode, NetworkNode eNode) 
        {
            startNode = stNode;
            endNode = eNode;    
        }

        public void Draw(Graphics g)
        {
            if (startNode == null || endNode == null)
                return;

            Point pStart = startNode.Position;
            Point pEnd = endNode.Position;

            using Pen p = new(Color.Red, 2.0f);

            g.DrawLine(p, pStart, pEnd);
        }

        public bool IsHitByMouse(Point position)
        {
            if (startNode == null || endNode == null)
                return false;

            using GraphicsPath boundingPath = new GraphicsPath();
            boundingPath.AddLine(startNode.Position, endNode.Position);

            using Pen p = new(Color.Empty, 8.0f);

            return boundingPath.IsOutlineVisible(position, p);
        }
    }

}
