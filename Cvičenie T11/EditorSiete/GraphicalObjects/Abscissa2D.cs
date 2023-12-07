using AntialiasingApp.GraphicsClasses;
using EditorSiete.Interfaces;
using EditorSiete.Tools;
using System.Diagnostics.Eventing.Reader;

namespace EditorSiete.GraphicalObjects
{
    public enum AbscissaDrawingMethod
    {
        Bresenham,
        DDA
    }

    public class Abscissa2D : IDrawable2DObject
    {
        private PointF pointStart;

        public PointF PointStart
        {
            get { return pointStart; }
            set { pointStart = value; }
        }

        private PointF pointEnd;

        public PointF PointEnd
        {
            get { return pointEnd; }
            set { pointEnd = value; }
        }

        private AbscissaDrawingMethod drawingMethod = AbscissaDrawingMethod.Bresenham;

        public AbscissaDrawingMethod DrawingMethod
        {
            get { return drawingMethod; }
            set { drawingMethod = value; }
        }


        public Abscissa2D(PointF startPoint, PointF endPoint)
        {
            pointStart = startPoint;
            pointEnd = endPoint;
        }

        public void DrawDDA(Graphics g)
        {
            pointStart = CoordTransformations.FromXYtoUV(pointStart);
            pointEnd = CoordTransformations.FromXYtoUV(pointEnd);

            float dX = pointEnd.X - pointStart.X;
            float dY = pointEnd.Y - pointStart.Y;

            float steps = Math.Abs(dX) > Math.Abs(dY) ? Math.Abs(dX) : Math.Abs(dY);

            float incrementX = dX / steps;
            float incrementY = dY / steps;

            float x = pointStart.X;
            float y = pointStart.Y;

            for (int i = 0; i <= steps; i++)
            {
                var point = new Point2D(new PointF(x, y));
                Rectangle rectangle = new((int)x, (int)y, 1, 1);
                g.FillRectangle(Brushes.Black, rectangle);
                x += incrementX;
                y += incrementY;
            }

        }

        public void DrawBresenham(Graphics g)
        {
            Point pStart = CoordTransformations.FromXYtoUV(pointStart);
            Point pEnd = CoordTransformations.FromXYtoUV(pointEnd);

            int X0 = pStart.X;
            int Y0 = pStart.Y;
            int X1 = pEnd.X;
            int Y1 = pEnd.Y;

            int dX = X1 - X0;
            int dY = Y1 - Y0;

            int D = 2 * dY - dX;
            int Y = Y0;

            for (int X = X0; X <= X1; X++)
            {
                Rectangle rectangle = new(X, Y, 1, 1);
                g.FillRectangle(Brushes.Black, rectangle);

                if (D > 0)
                {
                    Y++;
                    D -= 2 * dX;
                }

                D += 2 * dY;
            }

        }

        public void Draw(Graphics g)
        {
            if (DrawingMethod == AbscissaDrawingMethod.Bresenham)
                DrawBresenham(g);
            else if (DrawingMethod == AbscissaDrawingMethod.DDA)
                DrawDDA(g);
        }
    }
}
