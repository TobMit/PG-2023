using UNIZA.FRI.MatrixVectorMath;

namespace EditorSiete.Tools
{
    public static class CoordTransformations
    {
        public static int Umax;
        public static int Vmax;
        public static int Umin;
        public static int Vmin;

        public static float Xmin;
        public static float Ymin;
        public static float Xmax;
        public static float Ymax;

        public static PointF FromUVtoXY(Point p)
        {
            return new PointF((p.X - Umin) / (float)(Umax - Umin) * (Xmax - Xmin) + Xmin,
                              (p.Y - Vmin) / (float)(Vmax - Vmin) * (Ymax - Ymin) + Ymin);
        }

        public static Point FromXYtoUV(PointF p)
        {
            return new Point((int)((p.X - Xmin) / (Xmax - Xmin) * (Umax - Umin) + Umin), 
                             (int)((p.Y - Ymin) / (Ymax - Ymin) * (Vmax - Vmin) + Vmin));
        }

        public static PointF FromXYtoUVF(PointF p)
        {
            return new PointF((p.X - Xmin) / (Xmax - Xmin) * (Umax - Umin) + Umin,
                             (p.Y - Ymin) / (Ymax - Ymin) * (Vmax - Vmin) + Vmin);
        }

        public static Matrix FromUVtoXYMatrix(Point p)
        {
            return new Matrix(new float[,] { { p.X / (float)Umax * Xmax }, { Ymax - (p.Y / (float)Vmax * Ymax) }, { 1 } });
        }

        /// <summary>
        /// GetUVF
        /// </summary>
        public static PointF GetUVF(Matrix v)
        {
            if ((v == null) || (v.Rows != 3 || v.Columns != 1))
                throw new ApplicationException($"Wrong vertex data input!");
            return new PointF((v[0, 0] - Xmin) / (Xmax -Xmin) * (Umax - Umin) + Umin,
                              (v[1, 0] - Ymin) / (Ymax - Ymin) * (Vmax - Vmin) + Vmin);
        }
        public static Point GetUV(Matrix v)
        {
            PointF p = GetUVF(v);
            return new Point((int)Math.Round(p.X), (int)Math.Round(p.Y));
        }
    }
}
