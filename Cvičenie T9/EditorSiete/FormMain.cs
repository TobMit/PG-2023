using EditorSiete.GraphicalObjects;
using EditorSiete.Project;
using EditorSiete.Tools;
using System.Diagnostics;
using System.Windows.Forms;

namespace EditorSiete
{
    public partial class FormMain : Form
    {
        private List<Point2D> points;
        private Stopwatch stopwatch;

        public FormMain()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint |   // Do not erase the background, reduce flicker
            ControlStyles.OptimizedDoubleBuffer |           // Double buffering
            ControlStyles.UserPaint,                        // Use a custom redraw event to reduce flicker
            true);

            StartPosition = FormStartPosition.CenterScreen;


            // vytvorenie zoznamu bodov nahodne vygenerovanych

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            timerAnimation.Start();

            CoordTransformations.Umin = 0;
            CoordTransformations.Vmax = 0;
            CoordTransformations.Umax = doubleBufferedPanelDrawing.Width;
            CoordTransformations.Vmin = doubleBufferedPanelDrawing.Height;

            CoordTransformations.Xmin = -492.0f;
            CoordTransformations.Xmax = 492.0f;
            CoordTransformations.Ymin = -330.0f;
            CoordTransformations.Ymax = 330.0f;

            points = new List<Point2D>();
            Random random = new Random();


            for (int i = 0; i < 100; i++)
            {
                points.Add(
                    new Point2D
                    (
                        new PointF
                            (
                                (float)(random.NextDouble() * 984.0 - 492.0),
                                (float)(random.NextDouble() * 661.0 - 330.0)
                            ), true, Color.Black
                    )
                );
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void doubleBufferedPanelDrawing_Paint(object sender, PaintEventArgs e)
        {
            // graficky kontext
            Graphics g = e.Graphics;
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            foreach (Point2D point in points)
            {


                point.Draw(g);
            }

            Abscissa2D ciara = new Abscissa2D();
            ciara.PointStart = new PointF(0, 0);
            ciara.PointEnd = new PointF(100, -200);
            ciara.Draw(g);

            //// vykreslenie mapoveho podkladu
            //if (ProjectData.NetworkData.BackgroundVisible && ProjectData.Bitmap != null)
            //    g.DrawImage(ProjectData.Bitmap, 0, 0);

            //// vykreslenie vsetkych hran siete
            //foreach (NetworkEdge edge in ProjectData.GetNetworkEdges())
            //    edge.Draw(e.Graphics);

            //// vykreslenie vsetkych uzlov siete
            //foreach (NetworkNode node in ProjectData.GetNetworkNodes())
            //    node.Draw(e.Graphics);

            //if (ProjectData.Mode == EditorMode.EditingEdge &&
            //    ProjectData.State == EditorState.AddingEdge &&
            //    ProjectData.ActiveNode != null)
            //{
            //    float[] dashValues = { 5, 2, 5, 2 };
            //    using Pen blackPen = new(Color.Gray, 2.0f);
            //    blackPen.DashPattern = dashValues;
            //    g.DrawLine(blackPen, ProjectData.ActiveNode.Position, ProjectData.CurrentMousePosition);
            //}

            //if (ProjectData.State == EditorState.SelectorTracking)
            //{
            //    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            //    SelectionBox.Draw(g);
            //}
        }

        private void doubleBufferedPanelDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            ProjectData.CurrentMousePosition = e.Location;
            ProjectData.StartMousePosition = e.Location;

            if (e.Button == MouseButtons.Left)
            {
                if (ProjectData.Mode == EditorMode.EditingNode)
                {
                    NetworkNode? node = ProjectData.IsNodeHitByMouse(e.Location);

                    // zistime ci sme klikli na nejaky uzol
                    if (node != null)
                    {
                        if (!ProjectData.SelectedNodes.Contains(node))
                            ProjectData.SelectNode(node);

                        propertyGrid1.SelectedObject = node;
                        ProjectData.State = EditorState.Dragging;
                    }
                    else if (ProjectData.CTRLKeyPressed)
                    {
                        NetworkNode newNode = new(e.Location);

                        ProjectData.GetNetworkNodes().Add(newNode);
                        ProjectData.SelectNode(newNode);
                        newNode.Selected = true;
                        propertyGrid1.SelectedObject = newNode;
                    }
                    else
                    {
                        SelectionBox.InitSelectionBox(e.Location);
                        ProjectData.State = EditorState.SelectorTracking;
                    }
                }
                else if (ProjectData.Mode == EditorMode.EditingEdge)
                {
                    NetworkNode? node = ProjectData.IsNodeHitByMouse(e.Location);

                    if (node != null)
                    {
                        ProjectData.ActiveNode = node;
                        ProjectData.State = EditorState.AddingEdge;
                    }
                    else
                    {
                        NetworkEdge? edge = ProjectData.IsEdgeHitByMouse(e.Location);

                        if (edge != null)
                            propertyGrid1.SelectedObject = edge;
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (ProjectData.Mode == EditorMode.EditingNode)
                {
                    ProjectData.DeleteNode(ProjectData.IsNodeHitByMouse(e.Location));
                }
                else if (ProjectData.Mode == EditorMode.EditingEdge)
                {
                    ProjectData.DeleteEdge(ProjectData.IsEdgeHitByMouse(e.Location));
                }
            }

            doubleBufferedPanelDrawing.Invalidate();
        }

        private void doubleBufferedPanelDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            ProjectData.CurrentMousePosition = e.Location;

            if (ProjectData.State == EditorState.SelectorTracking && SelectionBox.IsTrackerActive)
            {
                using Region r = SelectionBox.Track(e.Location);
                doubleBufferedPanelDrawing.Invalidate(r);
                return;
            }

            if (ProjectData.Mode == EditorMode.EditingNode)
            {

                var selectedNodes = ProjectData.SelectedNodes;

                if (selectedNodes.Count > 0 && ProjectData.State == EditorState.Dragging)
                {
                    var displacement = new Point(ProjectData.CurrentMousePosition.X - ProjectData.StartMousePosition.X,
                                        ProjectData.CurrentMousePosition.Y - ProjectData.StartMousePosition.Y);

                    foreach (var node in selectedNodes)
                    {
                        node.Position = new Point(node.Position.X + displacement.X, node.Position.Y + displacement.Y);
                    }

                    ProjectData.StartMousePosition = ProjectData.CurrentMousePosition;
                }
            }
            else if (ProjectData.Mode == EditorMode.EditingEdge && ProjectData.ActiveNode != null)
            {

            }

            doubleBufferedPanelDrawing.Invalidate();
        }
        private void doubleBufferedPanelDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            if (ProjectData.State == EditorState.SelectorTracking)
            {
                ProjectData.SelectNode(SelectionBox.TrackedRectangle);
            }
            else if (ProjectData.Mode == EditorMode.EditingEdge && ProjectData.ActiveNode != null)
            {
                NetworkNode? node = ProjectData.IsNodeHitByMouse(e.Location);

                if (node != null)
                    ProjectData.GetNetworkEdges().Add(new(ProjectData.ActiveNode, node));
            }

            ProjectData.State = EditorState.None;
            SelectionBox.DisableTracker();

            propertyGrid1.Refresh();
            doubleBufferedPanelDrawing.Invalidate();
        }

        private void checkBoxBackgroundVisible_CheckedChanged(object sender, EventArgs e)
        {
            ProjectData.NetworkData.BackgroundVisible = checkBoxBackgroundVisible.Checked;

            doubleBufferedPanelDrawing.Invalidate();
        }

        private void loadBackgroundImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "Browse PNG Files";
            openFileDialog.DefaultExt = "png";
            openFileDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.ShowDialog();

            ProjectData.NetworkData.BitmapPath = openFileDialog.FileName;
            ProjectData.LoadBitmap();

            doubleBufferedPanelDrawing.Invalidate();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            doubleBufferedPanelDrawing.Invalidate();
        }

        private void radioButtonNodes_CheckedChanged(object sender, EventArgs e)
        {
            ProjectData.Mode = EditorMode.EditingNode;
            ProjectData.SelectNode(null);
        }

        private void radioButtonEdges_CheckedChanged(object sender, EventArgs e)
        {
            ProjectData.Mode = EditorMode.EditingEdge;
            ProjectData.SelectNode(null);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new();
            saveFileDialog.InitialDirectory = @"Documents";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "Browse XML Files";
            saveFileDialog.DefaultExt = "xml";
            saveFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.ShowDialog();

            ProjectData.ProjectPath = saveFileDialog.FileName;

            ProjectData.SaveNetworkData();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"Documents";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "Browse XML Files";
            openFileDialog.DefaultExt = "xml";
            openFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.ShowDialog();

            ProjectData.ProjectPath = openFileDialog.FileName;

            ProjectData.LoadNetworkData();
            ProjectData.LoadBitmap();

            doubleBufferedPanelDrawing.Invalidate();
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                ProjectData.CTRLKeyPressed = true;
            }
        }

        private void FormMain_KeyUp(object sender, KeyEventArgs e)
        {
            ProjectData.CTRLKeyPressed = false;
        }

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            double alpha = 0.0001;

            foreach (Point2D point in points)
            {
                float x = (float)(point.Position.X * Math.Cos(alpha) - point.Position.Y * Math.Sin(alpha));
                float y = (float)(point.Position.X * Math.Sin(alpha) + point.Position.Y * Math.Cos(alpha));

                point.Position = new PointF(x, y);
            }

            doubleBufferedPanelDrawing.Invalidate();
        }
    }
}