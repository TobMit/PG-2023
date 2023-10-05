using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvičenie_T2.Tools
{
    public class DoubleBufferedPanel: Panel
    {

        public DoubleBufferedPanel()
        {
            // aby nepreblikávala obrazovka tak sa vykresulje do druhého buffera
            //
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }
    }
}
