using System.Reflection;
using FriBird._2DObjects;

namespace FriBird
{
    public partial class Form1 : Form
    {
        private BackGround backGround;

        public Form1()
        {
            InitializeComponent();
            backGround = new BackGround();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            backGround.Draw(g);
            
        }
    }
}