namespace EditorSiete.GraphicalObjects
{
    public sealed class EdgeIndices
    {
        public int PointStartID { get; set; }
        public int PointEndID { get; set; }

        public EdgeIndices(int pointStartID, int pointEndID)
        {
            PointStartID = pointStartID;
            PointEndID = pointEndID;
        }
    }
}