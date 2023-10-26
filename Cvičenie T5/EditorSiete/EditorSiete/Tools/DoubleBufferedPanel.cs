namespace EditorSiete.Tools
{
    public class DoubleBufferedPanel: Panel
    {
        public DoubleBufferedPanel() 
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }
    }
}
