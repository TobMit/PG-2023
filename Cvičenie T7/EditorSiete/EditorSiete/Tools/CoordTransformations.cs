using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorSiete.Tools
{
    public class CoordTransformations
    {
        public static int Umax;
        public static int Umin;
        public static int Vmax;
        public static int Vmin;

        public static float Xmin;
        public static float Xmax;
        public static float Ymin;
        public static float Ymax;

        public static PointF FromUVtoXY(Point p)
        {
            return new PointF((p.X - Umin) / (float)(Umax - Umin) * (Xmax - Xmin) + Xmin,
                (p.Y - Vmin) / (float)(Vmax - Vmin) * (Ymax - Ymin) + Ymin);
        }

        public static Point FromXYtoUV(Point p)
        {
            return new Point((int)((p.X - Xmin) / (Xmax - Xmin) * (Umax - Umin) + Umin),
                             (int)((p.Y - Ymin) / (Ymax - Ymin) * (Vmax - Vmin) + Vmin));
        }
    }
}
