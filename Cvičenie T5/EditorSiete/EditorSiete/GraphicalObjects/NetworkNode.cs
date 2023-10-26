using EditorSiete.Interfaces;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace EditorSiete.GraphicalObjects
{
    [DataContract(Name = "NetworkNode")]
    public class NetworkNode : IDrawable2DObject
    {
        [DataMember()]
        private Point size;
        [DataMember()]
        private Point position;
        private Rectangle boundingRectangle;
        private bool selected = false;

        [Browsable(false)]
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        public string Name { get; set; }

        public Point Position 
        {
            get => position;

            set
            {
                position = value;
                boundingRectangle = new(position.X - (int)(size.X /2.0), position.Y - (int)(size.Y / 2.0), size.X, size.Y);
            }
        }

        public Point Size 
        { 
            get => size; 
            
            set
            {
                size = value;
                boundingRectangle = new (position.X - (int) (size.X /2.0), position.Y - (int) (size.Y / 2.0), size.X, size.Y);
            }
        }

        public NetworkNode()
        {
            Name = string.Empty;
        }

        public NetworkNode(Point position)
        {
            Name = "Node";
            size = new(20, 20);
            Position = position;
        }

        public bool IsHitByMouse(Point position)
        {
            return boundingRectangle.Contains(position);
        }

        public void Draw(Graphics g)
        {
            using Pen p = new(Color.LightGreen, 2.0f);
            g.FillEllipse(Brushes.Orange, boundingRectangle);
            g.DrawEllipse(p, boundingRectangle);
            if (!string.IsNullOrEmpty(Name))
            {
                using FontFamily fontFamily = new("Times New Roman");
                using Font font = new(fontFamily, 12);
                g.DrawString(Name, font, Brushes.Green, new PointF(position.X + (int)(size.X / 2.0), position.Y));
            }
            if (selected)
            {
                g.DrawRectangle(Pens.Gray, boundingRectangle);
            }
        }
    }
}
