using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvičenie_T2.Interfaces.Objects2D
{
    public class NetworkNode : IDrawable2DObjects
    {
        private Point position;
        public Point Position { 
            get 
            { 
                return position;
            } 
            set 
            {
                position = value;
            } 
        }

        public NetworkNode() 
        {
        
        }

        public bool IsHitByMouser(Point mousePoint)
        {
            Rectangle rectangle = new(mousePoint.X-10, mousePoint.Y-10, 20,20);
            return rectangle.Contains(mousePoint);
        }

        public void Draw(Graphics g)
        {
            Rectangle r = new Rectangle(position.X-10, position.Y-10, 20, 20);
            g.FillEllipse (Brushes.GreenYellow, r);
            g.DrawEllipse(Pens.Red, r);
        }
    }
}
