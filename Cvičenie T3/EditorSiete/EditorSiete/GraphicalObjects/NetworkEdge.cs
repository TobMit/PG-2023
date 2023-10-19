using EditorSiete.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorSiete.GraphicalObjects
{
    public class NetworkEdge : IDrawable2DObject
    {
        private NetworkNode startNode;
        private NetworkNode endNode;

        public NetworkEdge(NetworkNode stNode, NetworkNode eNode)
        {
            startNode = stNode;
            endNode = eNode;
            
        }
        public void Draw(Graphics g)
        {
            Point pStart = startNode.Position;
            Point pEnd = endNode.Position;

            using Pen p = new(Color.Red, 2.0f);

            g.DrawLine(p, pStart, pEnd);
        }
    }
}
