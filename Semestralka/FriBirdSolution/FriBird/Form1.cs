using System.Reflection;
using FriBird._2DObjects;
using FriBird.Tool;

namespace FriBird
{
    public partial class Form1 : Form
    {
        private BackGround backGround;

        private List<Prekazky> prekazyList;
        private Random random;

        public Form1()
        {
            InitializeComponent();
            backGround = new BackGround();
            prekazyList = new(2);
            random = new();

            GenerujPrekazky();

            timer1.Start();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            backGround.DrawSky(g);

            foreach (var prekazky in prekazyList)
            {
                prekazky.Draw(g);
            }

            backGround.DrawGround(g);
        }

        private void GenerujPrekazky()
        {
            prekazyList.Clear();
            var spodnaHranaHornejPrekazky = random.Next(3, 250);
            prekazyList.Add(new(false, spodnaHranaHornejPrekazky));
            prekazyList.Add(new(true, spodnaHranaHornejPrekazky));
        }
        

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Tick();
            panel1.Invalidate();
        }


        private void Tick()
        {
            foreach (var prekazky in prekazyList)
            {
                prekazky.Move();
            }

            if (prekazyList[0].PoziciaX + Constants.SIRKA_PREKAZKY < 0)
            {
                GenerujPrekazky();
            }
        }
    }
}