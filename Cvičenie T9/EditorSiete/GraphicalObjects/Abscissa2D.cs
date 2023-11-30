using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EditorSiete.Interfaces;
using EditorSiete.Tools;

namespace EditorSiete.GraphicalObjects
{
    public class Abscissa2D
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

        public void Draw(Graphics g)
        {

            PointF startP = pointStart;
            PointF endP = pointEnd;
            //Point startP = new ((int)PointStart.X, (int)PointStart.Y);
            //Point endP = new((int)PointEnd.X, (int)PointEnd.Y);
            //float dX = endP.X - startP.X;
            //float dY = endP.Y - startP.Y;

            //float dXAbs = Math.Abs(dX);
            //float dYabs = Math.Abs(dY);

            //float steps = Math.Max(dXAbs, dYabs);

            //float steps2 = Math.Min(dXAbs, dYabs) / (float)steps;

            float dX = endP.X - startP.X;
            float dY = endP.Y - startP.Y;

            float steps = Math.Abs(dX) > Math.Abs(dY) ? Math.Abs(dX) : Math.Abs(dY);


            float startX = startP.X;
            float startY = startP.Y;


            float incrementX = dX / steps;
            float incrementY = dY / steps;

            for (int i = 0; i < steps; i++)
            {
                Point2D point = new Point2D(new PointF(startX, startY), true, Color.Red);
                point.Draw(g);

                startX += incrementX;
                startY += incrementY;


                //if (dXAbs > dYabs)
                //{
                //    int calX = startX + (int)Math.Round((float)dX / steps);
                //    int calY = startY + (int)Math.Round(steps2);

                //    Rectangle rec = new Rectangle(calX, calY, 30, 30);
                //    g.FillRectangle(Brushes.Red, rec);
                //    startX = calX;
                //    startY = calY;
                //}
                //else
                //{
                //    int calX = startX + (int)Math.Round(steps2);
                //    int calY = startY + (int)Math.Round((float)dY / steps);
                //    Rectangle rec = new Rectangle(calX, calY, 30, 30);
                //    g.FillRectangle(Brushes.Red, rec);

                //    startX = calX;
                //    startY = calY;
                //}

            }
        }
    }
}
