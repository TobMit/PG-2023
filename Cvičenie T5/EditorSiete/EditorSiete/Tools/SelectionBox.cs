using EditorSiete.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorSiete.Tools
{
    public static class SelectionBox
    {
        private static Point _startPoint;
        private static Rectangle _beforeRectangle;
        private static Rectangle _nowRectangle;

        private static Region _a;
        private static SolidBrush _fillbrush;
        private static bool _isAcive;

        public static bool IsActive
        {
            get => _isAcive;
            set
            {
                _isAcive = value;
            }
        }

        private static Point start;

        public static Point Start
        {
            get { return start; }
            set { start = value; }
        }


        static SelectionBox()
        {
            _a = new Region();
            _fillbrush = new(Color.FromArgb(120, 0, 116, 231));
        }

        private static Rectangle GetRectangle(Point endPoint)
        {
            Rectangle outRectangle = new(_startPoint.X, _startPoint.Y,
                endPoint.X - _startPoint.X,
                endPoint.Y - _startPoint.Y);
            if (outRectangle.Width < 0)
            {
                outRectangle = new(endPoint.X, outRectangle.Y, -outRectangle.Width, outRectangle.Height);
            }

            if (outRectangle.Height < 0)
            {
                outRectangle = new(outRectangle.X, endPoint.Y, outRectangle.Width, -outRectangle.Height);
            }
            return outRectangle;

        }

        public static void Draw(Graphics g)
        {
            g.FillRectangle(_fillbrush, _nowRectangle);
        }

        public static Region Track(Point mousePoint)
        {
            _beforeRectangle = GetRectangle(mousePoint);
            _a = new Region(_nowRectangle);
            _a.Xor(_beforeRectangle);
            _nowRectangle = _beforeRectangle;

            return _a;
        }

    }
}
