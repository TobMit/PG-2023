using System.Reflection;
using FriBird._2DObjects;
using FriBird.Tool;

namespace FriBird
{
    public partial class Form1 : Form
    {
        private BackGround backGround;
        private Bird bird;

        private List<Prekazky> prekazyList;
        private Random random;

        public Form1()
        {
            InitializeComponent();
            backGround = new BackGround();
            bird = new();
            prekazyList = new(2);
            random = new();

            GenerujPrekazky();

            timer1.Start();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);

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
            bird.Draw(g);
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

            bird.GravitaciaPosun();
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                bird.Jump();
            }
        }
    }
}