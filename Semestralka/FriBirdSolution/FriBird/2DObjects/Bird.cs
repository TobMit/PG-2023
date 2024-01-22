using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriBird.Interface;
using FriBird.Tool;

namespace FriBird._2DObjects
{
    public class Bird : IDrawable2DObjects
    {
        public int PoziciaX { get; set; }
        public int PoziciaY { get; set; }

        private Bitmap image;
        float degree = 0;

        public Bird()
        {
            PoziciaY = 205-25; // lavý horny bod obrázka
            PoziciaX = 150-25; // lavý horný bod obrázka

            image = new Bitmap(Constants.BASE_IMAGE_DIR + "\\Birds\\FriBird\\2-1.png");
        }

        public void Draw(Graphics g)
        {
            // rotate image by 2 degree every time this method is called
            if (degree >= 359 - Constants.ROTATION_SPEED)
            {
                degree = 0;
            }

            


            float centerX = image.Width / 2f;
            float centerY = image.Height / 2f;

            // Set the rotation point at the center of the image
            g.TranslateTransform(PoziciaX + centerX, PoziciaY + centerY);

            // Rotate the image
            g.RotateTransform(degree);

            // Draw the rotated image
            g.DrawImage(image, -centerX, -centerY, 51, 51);

            // Reset the transformation matrix for future drawings
            g.ResetTransform();

            //g.FillRectangle(Brushes.Red, PoziciaX, PoziciaY, 5,5);


            degree += Constants.ROTATION_SPEED;
        }

        public void Move(int posun)
        {
            PoziciaY += posun;
        }
    }
}
