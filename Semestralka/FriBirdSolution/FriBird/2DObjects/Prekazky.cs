using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriBird.Interface;
using FriBird.Tool;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Rectangle = System.Drawing.Rectangle;

namespace FriBird._2DObjects
{
    public class Prekazky :IDrawable2DObjects
    {
        public int PoziciaY { get; set; }
        public int PoziciaX { get; set; }
        private bool hornaPrekazka;
        public Prekazky(bool pHornaPrekazka, int spodnaHranaHornejPrekazky)
        {
            PoziciaY = 0;
            PoziciaX = 300;
            hornaPrekazka = pHornaPrekazka;
            if (hornaPrekazka)
            {
                PoziciaY -= Constants.DLZKA_PREKAZKY - spodnaHranaHornejPrekazky;
            }
            else
            {
                PoziciaY += (spodnaHranaHornejPrekazky + Constants.VYSKA_MEDZI_PREKAZKAMI);
            }
        }
        public void Draw(Graphics g)
        {
            // draw rectangle
            g.FillRectangle(Brushes.Yellow, PoziciaX, PoziciaY, Constants.SIRKA_PREKAZKY, Constants.DLZKA_PREKAZKY);
        }

        public void Move()
        {
            this.PoziciaX -= Constants.POHYB_PREKAZKY;
        }

        public bool IsColiding(Bird bird)
        {
            Rectangle rec = new(PoziciaX, PoziciaY, Constants.SIRKA_PREKAZKY, Constants.DLZKA_PREKAZKY);
            Rectangle recBird = new(bird.PoziciaX, bird.PoziciaY, Constants.SIZE_OF_BIRD, Constants.SIZE_OF_BIRD);
            return rec.IntersectsWith(recBird);
        }
    }
}
