using AntialiasingApp.GraphicsClasses;
using EditorSiete.Interfaces;
using EditorSiete.Tools;
using System.Drawing.Drawing2D;
using Matrix = UNIZA.FRI.MatrixVectorMath.Matrix;

namespace EditorSiete.GraphicalObjects
{
    public class BezierCubicCurve : CurveBase, IDrawable2DObject
    {
        private Matrix baseMatrix = new (
            new float[,]
            {
                { -1, 3, -3, 1},
                {  3, -6, 3, 0},
                { -3, 3, 0, 0 },
                { 1, 0, 0, 0 }
            }
            );

        public void Draw(Graphics g)
        {
            if (controlPoints.Count < 4)
                return;

            RecalculateCurve();

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
            using (Pen pen = new Pen(Color.DarkGray))
            {
                using (AdjustableArrowCap customCap = new AdjustableArrowCap(7, 7, false))
                {
                    // Set cap properties
                    customCap.BaseCap = LineCap.Square;
                    customCap.WidthScale = 2;
                    pen.DashPattern = dashValues;
                    pen.CustomEndCap = customCap;
                    g.DrawLine(pen, CoordTransformations.GetUVF(controlPoints[0]), CoordTransformations.GetUVF(controlPoints[1]));
                    g.DrawLine(pen, CoordTransformations.GetUVF(controlPoints[3]), CoordTransformations.GetUVF(controlPoints[2]));
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
                // Draw last control point
                controlPoint = CoordTransformations.GetUV(controlPoints[3]);
                point = new Point(controlPoint.X - 5, controlPoint.Y - 5);
                rect = new Rectangle(point, new Size(10, 10));
                g.FillRectangle(ControlPointIsSelected(1) ? Brushes.LimeGreen : Brushes.OrangeRed, rect);
                g.DrawRectangle(Pens.Black, rect);
                g.DrawString("V end", font, Brushes.Black, new Point(rect.X + 10, rect.Y + 10));
                // Draw intermediate control points
                for (int i = 1; i < controlPoints.Count - 1; i++)
                {
                    controlPoint = CoordTransformations.GetUV(controlPoints[i]);
                    point = new Point(controlPoint.X, controlPoint.Y);
                    rect = new Rectangle(point.X - 5, point.Y - 5, 10, 10);
                    g.FillEllipse(ControlPointIsSelected(i) ? Brushes.LimeGreen : Brushes.DarkOrange, rect);
                    g.DrawEllipse(Pens.Black, rect);
                    g.DrawString("C" + i.ToString(), font, Brushes.Black, new Point(rect.X + 10, rect.Y + 10));
                }
            }
        }

        public override Matrix GetPointAndAngleOnCurve(float time, out float angle)
        {
            throw new NotImplementedException();
        }

        protected override void RecalculateCurve()
        {
            if(controlPoints == null || controlPoints.Count != 4)
                return;

            Matrix P0 = controlPoints[0];
            Matrix P1 = controlPoints[1];
            Matrix P2 = controlPoints[2];
            Matrix P3 = controlPoints[3];
            
            Matrix cParametersXvector = new Matrix(new float[,] {
                { P0[0,0],
                  P1[0,0],
                  P2[0,0],
                  P3[0,0],
                } }, transpose: true);

            Matrix cParametersYvector = new Matrix(new float[,] {
                { P0[1,0],
                  P1[1,0],
                  P2[1,0],
                  P3[1,0],
                } }, transpose: true);

            curvePoints = new();

            float dT = 1.0f / (float)curvePrecision;
            float t = 0.0f;

            for (int i = 0; i < curvePrecision; i++) 
            {
                var tMatrix = new Matrix(new float[,] { { t * t * t, t * t, t, 1 } });
                var ttMatrix = tMatrix * baseMatrix;

                Matrix xCoord = ttMatrix * cParametersXvector;
                Matrix yCoord = ttMatrix * cParametersYvector;

                curvePoints.Add(new Matrix(new float[,] { { xCoord[0, 0], yCoord[0, 0], 1 } }, transpose: true));

                t += dT; 
            }
        }
    }
}
