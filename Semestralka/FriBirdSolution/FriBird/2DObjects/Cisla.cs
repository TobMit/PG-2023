using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using FriBird.Interface;
using FriBird.Tool;

namespace FriBird._2DObjects
{
    public class Cisla : IDrawable2DObjects
    {
        private Bitmap[] cisla;

        public int ZobrazovaneCislo { get; set; }
        public Point Pozicia { get; set; }

        public Cisla()
        {
            ZobrazovaneCislo = 0;
            Pozicia = new Point(0, 0);
            cisla = new Bitmap[10];
            for (int i = 0; i < cisla.Length; i++)
            {
                var addresa = $"{Constants.BASE_IMAGE_DIR}/Numbers/{i}.png";
                cisla[i] = new Bitmap(addresa);
            }
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(cisla[ZobrazovaneCislo], Pozicia.X, Pozicia.Y, 30 ,47);
        }
    }
}
