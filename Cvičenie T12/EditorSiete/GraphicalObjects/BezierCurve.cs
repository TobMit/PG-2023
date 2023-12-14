using AntialiasingApp.GraphicsClasses;
using EditorSiete.Interfaces;
using EditorSiete.Tools;
using Matrix = UNIZA.FRI.MatrixVectorMath.Matrix;

namespace EditorSiete.GraphicalObjects
{
    public sealed class BezierCurve : CurveBase, IDrawable2DObject
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public BezierCurve() { }

        private float CalculateDistanceBetweenPoints(Matrix point1, Matrix point2)
        {
            float deltaX = Math.Abs(point1[0, 0] - point2[0, 0]);
            float deltaY = Math.Abs(point1[1, 0] - point2[1, 0]);

            return (float)Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
        }

        /// <summary>
        /// Prepocitanie krivky podla potreby
        /// </summary>
        protected override void RecalculateCurve()
        {
            // get curve points
            curvePoints = DeCasteljau.GetCurvePoints(controlPoints, curvePrecision);

            if (curvePoints == null)
                return;

            // calculate curve length
            segmentLengths = new List<float>();

            for (int i = 0; i < curvePoints.Count - 1; i++)
                segmentLengths.Add(CalculateDistanceBetweenPoints(curvePoints[i], curvePoints[i + 1]));

            length = segmentLengths.Sum();
        }

        /// <summary>
        /// GetPointAndAngleOnCurve
        /// </summary>
		public override Matrix GetPointAndAngleOnCurve(float time, out float angle)
        {
            return DeCasteljau.GetDeCasteljauPoint(controlPoints, time, out angle);
        }

        /// <summary>
        /// Draw
        /// </summary>
        public void Draw(Graphics g)
        {
            if (curvePoints == null || controlPoints == null || controlPoints.Count < 4)
                return;

            // Draw lines between control points for better visibility
            for (int i = 0; i < curvePoints.Count - 1; i++)
            {
                PointF point1 = CoordTransformations.GetUVF(curvePoints[i]);
                PointF point2 = CoordTransformations.GetUVF(curvePoints[i + 1]);
                g.DrawLine(Pens.Pink, point1, point2);

                Point2D point2D = new(new PointF(curvePoints[i][0, 0], curvePoints[i][1, 0]));
                point2D.Draw(g);
            }

            // Draw lines between control points for better visibility
            float[] dashValues = { 10, 6 };

            using (Pen pen = new Pen(Color.LightGray))
            {
                for (int i = 0; i < controlPoints.Count - 1; i++)
                {
                    PointF point1 = CoordTransformations.GetUVF(controlPoints[i]);
                    PointF point2 = CoordTransformations.GetUVF(controlPoints[i + 1]);

                    pen.DashPattern = dashValues;
                    g.DrawLine(pen, point1, point2);
                }
            }

            // Draw control point anchors
            using (var font = new Font("Arial", 10))
            {
                // Draw first control point
                Point controlPoint = CoordTransformations.GetUV(controlPoints[0]);
                Point point = new Point(controlPoint.X - 5, controlPoint.Y - 5);
                Rectangle rect = new Rectangle(point, new Size(10, 10));
                g.FillRectangle(ControlPointIsSelected(0) ? Brushes.LimeGreen : Brushes.OrangeRed, rect);
                g.DrawRectangle(Pens.Black, rect);
                g.DrawString("V start", font, Brushes.Black, new Point(rect.X + 10, rect.Y + 10));

                // Draw intermediate control points
                for (int i = 1; i < controlPoints.Count - 1; i++)
                {
                    controlPoint = CoordTransformations.GetUV(controlPoints[i]);
                    point = new Point(controlPoint.X - 5, controlPoint.Y - 5);
                    rect = new Rectangle(point, new Size(10, 10));
                    g.FillRectangle(ControlPointIsSelected(i) ? Brushes.LimeGreen : Brushes.DarkOrange, rect);
                    g.DrawRectangle(Pens.Black, rect);
                    g.DrawString("C" + i.ToString(), font, Brushes.Black, new Point(rect.X + 10, rect.Y + 10));
                }

                // Draw last control point
                controlPoint = CoordTransformations.GetUV(controlPoints[controlPoints.Count - 1]);
                point = new Point(controlPoint.X - 5, controlPoint.Y - 5);
                rect = new Rectangle(point, new Size(10, 10));
                g.FillRectangle(ControlPointIsSelected(controlPoints.Count - 1) ? Brushes.LimeGreen : Brushes.OrangeRed, rect);
                g.DrawRectangle(Pens.Black, rect);
                g.DrawString("V end", font, Brushes.Black, new Point(rect.X + 10, rect.Y + 10));
            }
        }
    }
}
