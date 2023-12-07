using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntialiasingApp.GraphicsClasses;
using Editor2D.Drawing2DMath;
using EditorSiete.Interfaces;
using EditorSiete.Tools;
using Matrix = UNIZA.FRI.MatrixVectorMath.Matrix;

namespace EditorSiete.GraphicalObjects
{
    public class BesierCubicCurve : CurveBase, IDrawable2DObject
    {
        public void Add(Matrix tmpMatrix)
        {
            controlPoints.Add(tmpMatrix);
        }
        
        private Matrix baseMatrix = new(new float[,]
        {
            { -1, 3, -3, 1},
            { 3, -6, 3, 0},
            { -3, 3, 0, 0},
            { 1, 0, 0, 0}
        });


        protected override void RecalculateCurve()
        {
            if (controlPoints == null || controlPoints.Count != 4)
                return;
            Matrix P0 = controlPoints[0];
            Matrix P1 = controlPoints[1];
            Matrix P2 = controlPoints[2];
            Matrix P3 = controlPoints[3];
            Matrix cParametersXvector = new Matrix(new float[,] {
            {   P0[0,0],
                P1[0,0],
                P2[0,0],
                P3[0,0],
            } }, transpose: true);
            Matrix cParametersYvector = new Matrix(new float[,] {
            {   P0[1,0],
                P1[1,0],
                P2[1,0],
                P3[1,0],
            } }, transpose: true);

            curvePoints = new();

            float dT = 1.0f / (float)curvePrecision;
            float t = 0.0f;
            for (int i = 0; i < curvePrecision; i++)
            {
                var tMatrix = new Matrix(new float[,] { { t*t*t, t*t, t, 1 } }, true);
                var ttMtrix = baseMatrix * baseMatrix;

                Matrix xCord = ttMtrix * cParametersXvector;
                Matrix yCord = ttMtrix * cParametersYvector;

                curvePoints.Add(new Matrix(new float[,]{ { xCord[0,0], yCord[0,0] } }, true));
                t += dT;
            }
        }

        public override Matrix GetPointAndAngleOnCurve(float time, out float angle)
        {
            throw new NotImplementedException();
        }

        public void Draw(Graphics g)
        {
            RecalculateCurve();
            if (curvePoints == null || controlPoints == null || controlPoints.Count < 4)
                return;
            // Draw lines between control points for better visibility
            for (int i = 0; i < curvePoints.Count - 1; i++)
            {
                PointF point1 = CoordTransformations.GetUVF(curvePoints[i]);
                PointF point2 = CoordTransformations.GetUVF(curvePoints[i + 1]);
                g.DrawLine(Pens.Pink, point1, point2);

                Point2D point2D = new Point2D(point1);
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
                    g.DrawLine(pen, CoordTransformations.GetUVF(controlPoints[0]), CoordTransformations.GetUVF(controlPoints[2]));
                    g.DrawLine(pen, CoordTransformations.GetUVF(controlPoints[3]), CoordTransformations.GetUVF(controlPoints[1]));
                }
            }
        }
    }
}
