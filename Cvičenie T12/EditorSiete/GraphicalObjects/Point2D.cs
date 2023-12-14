using EditorSiete.Interfaces;
using EditorSiete.Tools;

namespace AntialiasingApp.GraphicsClasses
{
    public sealed class Point2D : IDrawable2DObject
    {
        private bool antialiased;

        public bool Antialiased
        {
            get { return antialiased; }
            set { antialiased = value; }
        }

        private Color color = Color.Red;

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        private PointF position;

        public PointF Position
        {
            get { return position; }
            set { position = value; }
        }

        /// <summary>
        /// Cosntructor 1
        /// </summary>
        /// <param name="position"></param>
        /// <param name="antialiased"></param>
        public Point2D(PointF position, bool antialiased = false)
        {
            this.position = position;
            this.antialiased = antialiased;
        }

        /// <summary>
        /// Draw method
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            if (true)
            {
                using (SolidBrush b = new SolidBrush(color))
                {
                    PointF locationF = CoordTransformations.FromXYtoUVF(position);

                    float xRightOverhang = locationF.X % 1;
                    float xLeftOverhang = 1.0f - xRightOverhang;
                    float yBottomOverhang = locationF.Y % 1;
                    float yTopOverhang = 1.0f - yBottomOverhang;

                    int x = (int)locationF.X;
                    int y = (int)locationF.Y;

                    // Antialiased pixel takes up 3 x 3 grid, with the middle pixel fully opaque. Other pixels are made partially transparent.
                    // Upper row
                    GetBrushByAlpha(b, xLeftOverhang * yTopOverhang);
                    g.FillRectangle(b, x - 1, y - 1, 1, 1);

                    GetBrushByAlpha(b, yTopOverhang);
                    g.FillRectangle(b, x, y - 1, 1, 1);

                    GetBrushByAlpha(b, xRightOverhang * yTopOverhang);
                    g.FillRectangle(b, x + 1, y - 1, 1, 1);

                    // Middle row
                    GetBrushByAlpha(b, xLeftOverhang);
                    g.FillRectangle(b, x - 1, y, 1, 1);

                    GetBrushByAlpha(b, 1.0f);
                    g.FillRectangle(b, x, y, 1, 1);

                    GetBrushByAlpha(b, xRightOverhang);
                    g.FillRectangle(b, x + 1, y, 1, 1);

                    // Lower row
                    GetBrushByAlpha(b, xLeftOverhang * yBottomOverhang);
                    g.FillRectangle(b, x - 1, y + 1, 1, 1);

                    GetBrushByAlpha(b, yBottomOverhang);
                    g.FillRectangle(b, x, y + 1, 1, 1);

                    GetBrushByAlpha(b, xRightOverhang * yBottomOverhang);
                    g.FillRectangle(b, x + 1, y + 1, 1, 1);
                }
            }
            else
            {
                Point p = CoordTransformations.FromXYtoUV(position);

                using (var b = new SolidBrush(Color))
                {
                    g.FillRectangle(b, new Rectangle(new Point(p.X - 1, p.Y - 1), new Size(2, 2)));
                }
            }
        }

        /// <summary>
        /// GetBrushByAlpha
        /// </summary>
        /// <param name="b"></param>
        /// <param name="alpha"></param>
        /// <param name="baseColor"></param>
        private void GetBrushByAlpha(SolidBrush b, float alpha)
        {
            int colorAlpha = (int)(alpha * 255);

            if (colorAlpha > 255)
                colorAlpha = 255;
            else if (colorAlpha < 0)
                colorAlpha = 0;

            b.Color = Color.FromArgb(colorAlpha, color);
        }
    }
}
