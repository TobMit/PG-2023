using Cvičenie_T2.Interfaces.Objects2D;
using System.Xml.Linq;

namespace Cvičenie_T2
{
    public partial class Okno : Form
    {
        private List<NetworkNode> networkNodes = new();
        private Bitmap bitmap;
        private bool visible;

        public Okno()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            bitmap = new("\\\\Mac\\Home\\Documents\\Programovanie\\PG-2023\\Cvičenie T2\\Cvičenie T2\\Cvičenie T2\\Images\\Podklad.png");
            visible = true;
        }

        private void Okno_Load(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void doubleBufferedPanelDrowing_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (visible)
            {
                graphics.DrawImage(bitmap, 0, 0);
            }
            // vykreslenie uzlov siete
            foreach (NetworkNode node in networkNodes)
            {
                node.Draw(graphics);
            }

        }

        private void doubleBufferedPanelDrowing_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                networkNodes.Add(new NetworkNode
                {
                    Position = e.Location
                });
            }
            else if (e.Button == MouseButtons.Right) 
            {
                NetworkNode nodeToRemove = null;
                foreach (NetworkNode node in networkNodes)
                {
                    if (node.IsHitByMouser(e.Location))
                    {
                        nodeToRemove = node;
                        break;
                    }
                }
                if (nodeToRemove != null)
                    networkNodes.Remove(nodeToRemove);
            }
            
            
            doubleBufferedPanelDrowing.Invalidate();
        }

        private void chekcstate_CheckStateChanged(object sender, EventArgs e)
        {
            visible = !visible;
            doubleBufferedPanelDrowing.Invalidate();
        }
    }
}