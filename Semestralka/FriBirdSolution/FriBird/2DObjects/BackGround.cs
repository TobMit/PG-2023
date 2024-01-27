using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriBird.Interface;
using FriBird.Tool;

namespace FriBird._2DObjects
{
    public class BackGround : IDrawable2DObjects
    {
        public BackGround()
        {
            // nothing here fow now
        }
        public void Draw(Graphics g)
        {
            Bitmap bitmapFri = new(Constants.BASE_IMAGE_DIR + "\\Pozadie-1-3.png");
            g.DrawImage(bitmapFri, 0, -200, 300, 600);
            Bitmap bitmapGrass = new(Constants.BASE_IMAGE_DIR + "\\Pozadie-2-pauza.png");
            g.DrawImage(bitmapGrass, 0, 600 - 256, 300, 256);
        }

        public void DrawGround(Graphics g)
        {
            Bitmap bitmapGrass = new(Constants.BASE_IMAGE_DIR + "\\Pozadie-2-pauza.png");
            g.DrawImage(bitmapGrass, 0, 600 - 256, 300, 256);
        }
        public void DrawSky(Graphics g)
        {
            Bitmap bitmapFri = new(Constants.BASE_IMAGE_DIR + "\\Pozadie-1-3.png");
            g.DrawImage(bitmapFri, 0, -200, 300, 600);
        }
    }
}
