using System.Reflection;
using FriBird._2DObjects;
using FriBird.Tool;

namespace FriBird
{
    public partial class Form1 : Form
    {
        private BackGround backGround;
        private Bird bird;
        private CiselnyDisplay scoreDisplay;

        private List<Prekazky> prekazyList;
        private Random random;


        private GameStat stat;
        private int score;

        public Form1()
        {
            InitializeComponent();
            backGround = new BackGround();
            bird = new();
            prekazyList = new(2);
            random = new();
            scoreDisplay = new();
            scoreDisplay.Pozicia = new(150, 425);

            GenerujPrekazky();

            timer1.Start();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);

            stat = GameStat.Start;
            score = 0;

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
            scoreDisplay.Draw(g);

        }

        private void GenerujPrekazky()
        {
            var spodnaHranaHornejPrekazky = random.Next(3, 240);
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
            bool colidet = false;
            if (stat == GameStat.Run)
            {
                foreach (var prekazky in prekazyList)
                {
                    prekazky.Move();
                    colidet |= prekazky.IsColiding(bird);
                }

                colidet |= bird.PoziciaY < 0; // kolizia s hornou hranou
                colidet |= bird.PoziciaY + Constants.SIZE_OF_BIRD > 350; // kolizia s dolnou hranou

                bird.GravitaciaPosun();

                if (colidet)
                {
                    stat = GameStat.Lose;
                    bird.Run = false;
                }
            }

            if (prekazyList.Count > 2) // aby sa porovnávalo podla správnej prekazky èiže ak sú nové prekážky pred birdom ale staré sú ešte na ploche
            {
                if (prekazyList[3].PoziciaX + Constants.SIRKA_PREKAZKY < 80)
                {
                    GenerujPrekazky();
                }
            }
            else
            {
                if (prekazyList[0].PoziciaX + Constants.SIRKA_PREKAZKY < 80)
                {
                    GenerujPrekazky();
                }
            }

            if (prekazyList[0].PoziciaX + Constants.SIRKA_PREKAZKY < 0)
            {
                prekazyList.RemoveAt(0);
                prekazyList.RemoveAt(0);
            }

            if (prekazyList[0].PoziciaX + Constants.SIRKA_PREKAZKY < 151 && prekazyList[0].PoziciaX + Constants.SIRKA_PREKAZKY >= 150)
            {
                score++;
                scoreDisplay.ZobrazovaneCislo = score;
            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (stat == GameStat.Start)
                {
                    bird.Run = true;
                    stat = GameStat.Run;
                    bird.Jump();
                }
                else if (stat == GameStat.Run)
                {
                    bird.Jump();
                }
                else
                {

                    bird = new();
                    prekazyList.Clear();
                    GenerujPrekazky();
                    stat = GameStat.Start;
                    scoreDisplay.ZobrazovaneCislo = 0;
                    score = 0;
                }

            }
            else if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }
    }
}