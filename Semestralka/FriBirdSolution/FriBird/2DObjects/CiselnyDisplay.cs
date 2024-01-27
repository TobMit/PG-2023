using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriBird.Interface;

namespace FriBird._2DObjects
{
    public class CiselnyDisplay : IDrawable2DObjects
    {
        private Cisla jednotky;
        private Cisla desiadky;
        private Cisla stovky;

        public int ZobrazovaneCislo { get; set; }
        public Point Pozicia { get; set; }

        public CiselnyDisplay()
        {
            jednotky = new();
            desiadky = new();
            stovky = new();

            ZobrazovaneCislo = 0;
            Pozicia = new Point(0, 0);
        }

        public void Draw(Graphics g)
        {
            // if number is 1 digit show only jednotky else show jednotky and desiatky and if number is 3 digits show all
            if (ZobrazovaneCislo < 10)
            {
                jednotky.ZobrazovaneCislo = ZobrazovaneCislo;
                jednotky.Pozicia = new(Pozicia.X - 15, Pozicia.Y);
                jednotky.Draw(g);
            }
            else if (ZobrazovaneCislo < 100)
            {
                desiadky.ZobrazovaneCislo = ZobrazovaneCislo / 10;
                desiadky.Pozicia = new(Pozicia.X - 30, Pozicia.Y);
                desiadky.Draw(g);

                jednotky.ZobrazovaneCislo = ZobrazovaneCislo % 10;
                jednotky.Pozicia = Pozicia;
                jednotky.Draw(g);
            }
            else
            {
                stovky.ZobrazovaneCislo = ZobrazovaneCislo / 100;
                stovky.Pozicia = new(Pozicia.X - 45, Pozicia.Y);
                stovky.Draw(g);

                desiadky.ZobrazovaneCislo = (ZobrazovaneCislo % 100) / 10;
                desiadky.Pozicia = new Point(Pozicia.X - 15, Pozicia.Y);
                desiadky.Draw(g);

                jednotky.ZobrazovaneCislo = ZobrazovaneCislo % 10;
                jednotky.Pozicia = new Point(Pozicia.X + 15, Pozicia.Y);
                jednotky.Draw(g);
            }

            g.FillRectangle(Brushes.Blue, Pozicia.X, Pozicia.Y, 5, 5);
        }
    }
}
