namespace EditorSiete.Tools
{
    public class DoubleBufferedPanel: Panel
    {
        public DoubleBufferedPanel() 
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | //Do not erase the background, reduce flicker
                 ControlStyles.OptimizedDoubleBuffer | //Double buffering
                 ControlStyles.UserPaint, //Use a custom redraw event to reduce flicker
                 true);
        }
    }
}
