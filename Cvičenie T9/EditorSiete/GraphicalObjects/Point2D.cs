using EditorSiete.Interfaces;
using EditorSiete.Tools;
using Microsoft.VisualBasic;

namespace EditorSiete.GraphicalObjects
{
    public class Point2D : IDrawable2DObject
    {
        public PointF Position { get; set; }
        public bool Antialiased { get; set; } 
        public Color Color { get; set; }

        public Point2D(PointF position, bool antialiased, Color color)
        {
            Position = position;
            Antialiased = antialiased;
            Color = color;
        }

        public void Draw(Graphics g)
        {
            if (Antialiased)
            {
                var position = Position;
                if (!position.IsEmpty)
                {
                    Point drawAt = CoordTransformations.FromXYtoUV(position);
                    var newPos = CoordTransformations.FromXYtoUVf(position);
                    double x = newPos.X % 1;
                    double y = newPos.Y % 1;

                    if (x == 0 && y == 0)
                    {
                        return;
                    }

                    int alfa1 = Color.A;
                    if (alfa1 < 0)
                    {
                        alfa1 = 0;
                    } else if (alfa1 > 255)
                    {
                        alfa1 = 255;
                    }
                    int alfa2 = (int)(Color.A * x);
                    if (alfa2 < 0)
                    {
                        alfa2 = 0;
                    }
                    else if (alfa2 > 255)
                    {
                        alfa2 = 255;
                    }
                    int alfa3 = (int)(Color.A * y);
                    if (alfa3 < 0)
                    {
                        alfa3 = 0;
                    }
                    else if (alfa3 > 255)
                    {
                        alfa3 = 255;
                    }
                    int alfa4 = (int)(Color.A * (x * y));
                    if (alfa4 < 0)
                    {
                        alfa4 = 0;
                    }
                    else if (alfa4 > 255)
                    {
                        alfa4 = 255;
                    }
                    int alfa5 = (int)(Color.A * (1 - x));
                    if (alfa5 < 0)
                    {
                        alfa5 = 0;
                    }
                    else if (alfa5 > 255)
                    {
                        alfa5 = 255;
                    }
                    int alfa6 = (int)(Color.A * ((1 - x) * y));
                    if (alfa6 < 0)
                    {
                        alfa6 = 0;
                    }
                    else if (alfa6 > 255)
                    {
                        alfa6 = 255;
                    }
                    int alfa7 = (int)(Color.A * (1 - y));
                    if (alfa7 < 0)
                    {
                        alfa7 = 0;
                    }
                    else if (alfa7 > 255)
                    {
                        alfa7 = 255;
                    }
                    int alfa8 = (int)(Color.A * (x * (1 - y)));
                    if (alfa8 < 0)
                    {
                        alfa8 = 0;
                    }
                    else if (alfa8 > 255)
                    {
                        alfa8 = 255;
                    }
                    int alfa9 = (int)(Color.A * ((1 - x) * (1 - y)));
                    if (alfa9 < 0)
                    {
                        alfa9 = 0;
                    }
                    else if (alfa9 > 255)
                    {
                        alfa9 = 255;
                    }



                    SolidBrush brush = new SolidBrush(Color.FromArgb(Color.A, (int)Color.R, Color.G, Color.B));

                    g.FillRectangle(new SolidBrush(Color.FromArgb(alfa1, (int)Color.R, Color.G, Color.B)), drawAt.X,
                        drawAt.Y, 1, 1);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(alfa2, (int)Color.R, Color.G, Color.B)), drawAt.X + 1,
                        drawAt.Y, 1, 1);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(alfa3, (int)Color.R, Color.G, Color.B)), drawAt.X,
                        drawAt.Y + 1, 1, 1);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(alfa4, (int)Color.R, Color.G, Color.B)), drawAt.X + 1,
                        drawAt.Y + 1, 1, 1);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(alfa5, (int)Color.R, Color.G, Color.B)), drawAt.X - 1,
                        drawAt.Y, 1, 1);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(alfa6, (int)Color.R, Color.G, Color.B)), drawAt.X - 1,
                        drawAt.Y + 1, 1, 1);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(alfa7, (int)Color.R, Color.G, Color.B)), drawAt.X,
                        drawAt.Y - 1, 1, 1);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(alfa8, (int)Color.R, Color.G, Color.B)), drawAt.X + 1,
                        drawAt.Y - 1, 1, 1);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(alfa9, (int)Color.R, Color.G, Color.B)), drawAt.X - 1,
                        drawAt.Y - 1, 1, 1);
                }
            }
            else
            {
                Point drawAt = CoordTransformations.FromXYtoUV(Position);

                SolidBrush brush = new SolidBrush(Color);

                g.FillRectangle(brush, drawAt.X, drawAt.Y, 1, 1);
                g.FillRectangle(brush, drawAt.X + 1, drawAt.Y, 1, 1);
                g.FillRectangle(brush, drawAt.X, drawAt.Y + 1, 1, 1);
                g.FillRectangle(brush, drawAt.X + 1, drawAt.Y + 1, 1, 1);
                // how to f you no
            }
        }
    }
}
