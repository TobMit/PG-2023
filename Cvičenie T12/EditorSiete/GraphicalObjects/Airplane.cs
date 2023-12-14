using AntialiasingApp.GraphicsClasses;
using EditorSiete.Interfaces;
using EditorSiete.Tools;
using Matrix = UNIZA.FRI.MatrixVectorMath.Matrix;

namespace EditorSiete.GraphicalObjects
{
    public sealed class Airplane : IDrawable2DObject
    {
        private Matrix[] vertexBufferOrig;
        private Matrix[] vertexBuffer;
        private EdgeIndices[] indexBuffer;

        public Airplane()
        {
            vertexBufferOrig = new Matrix[]
                {
                new Matrix(new float[,] { { -1, 8 , 1} }, transpose: true),		// V1
				new Matrix(new float[,] { {  1, 8 , 1} }, transpose: true),		// V2
				new Matrix(new float[,] { {  2, 1 , 1} }, transpose: true),		// V3
				new Matrix(new float[,] { {  4, 1 , 1} }, transpose: true),		// V4
				new Matrix(new float[,] { {  5, 1 , 1} }, transpose: true),		// V5
				new Matrix(new float[,] { {  5, -1, 1} }, transpose: true),		// V6
				new Matrix(new float[,] { {  4, -1, 1} }, transpose: true),		// V7
				new Matrix(new float[,] { {  2, -1, 1} }, transpose: true),		// V8
				new Matrix(new float[,] { {  1, -8, 1} }, transpose: true),		// V9
				new Matrix(new float[,] { { -1, -8, 1} }, transpose: true),		// V10
				new Matrix(new float[,] { { -2, -1, 1} }, transpose: true),		// V11
				new Matrix(new float[,] { { -5, -1, 1} }, transpose: true),		// V12
				new Matrix(new float[,] { { -5, -3, 1} }, transpose: true),		// V13
				new Matrix(new float[,] { { -6, -3, 1} }, transpose: true),		// V14
				new Matrix(new float[,] { { -6, 3 , 1} }, transpose: true),		// V15
				new Matrix(new float[,] { { -5, 3 , 1} }, transpose: true),		// V16
				new Matrix(new float[,] { { -5, 1 , 1} }, transpose: true),		// V17
				new Matrix(new float[,] { { -2, 1 , 1} }, transpose: true)      // V18
				};

            indexBuffer = new EdgeIndices[]
            {
                new EdgeIndices(0,1),	//U1
				new EdgeIndices(1,2),	//U2
				new EdgeIndices(2,3),	//U3
				new EdgeIndices(3,4),	//U4
				new EdgeIndices(4,5),	//U5
				new EdgeIndices(5,6),	//U6
				new EdgeIndices(3,6),	//U7
				new EdgeIndices(6,7),	//U8
				new EdgeIndices(7,8),	//U9
				new EdgeIndices(8,9),	//U10
				new EdgeIndices(9,10),	//U11
				new EdgeIndices(10,11),	//U12
				new EdgeIndices(11,12),	//U13
				new EdgeIndices(12,13),	//U14
				new EdgeIndices(13,14),	//U15
				new EdgeIndices(14,15),	//U16
				new EdgeIndices(15,16),	//U17
				new EdgeIndices(16,17),	//U18
				new EdgeIndices(17,0),	//U19
			};
        }

        /// <summary>
        /// Transform
        /// </summary>
        public void Transform(Matrix transformationMatrix)
        {
            if (transformationMatrix == null)
                throw new ApplicationException("Matrix is null");

            vertexBuffer = new Matrix[vertexBufferOrig.Length];

            for (int i = 0; i < vertexBufferOrig.Length; i++)
                vertexBuffer[i] = transformationMatrix * vertexBufferOrig[i];
        }

        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="g">Graphics object</param>
        public void Draw(Graphics g)
        {
            var first = true;

            // draw topology
            foreach (var abscissa in indexBuffer)
            {
                var lineStart = CoordTransformations.GetUV(vertexBuffer[abscissa.PointStartID]);
                var lineEnd = CoordTransformations.GetUV(vertexBuffer[abscissa.PointEndID]);

                if (first)
                {
                    first = false;
                    g.DrawLine(Pens.Red, lineStart, lineEnd);
                }
                else
                    g.DrawLine(Pens.Black, lineStart, lineEnd);
            }

            // draw vertices
            foreach (var vertex in vertexBuffer)
			{
                Point2D point2D = new(new PointF(vertex[0, 0], vertex[1, 0]))
                {
                    Color = Color.OrangeRed
                };

                point2D.Draw(g);
            }
        }
	}
}
