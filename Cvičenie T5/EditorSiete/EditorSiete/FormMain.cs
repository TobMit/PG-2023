using EditorSiete.GraphicalObjects;
using EditorSiete.Project;
using EditorSiete.Tools;

namespace EditorSiete
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void doubleBufferedPanelDrawing_Paint(object sender, PaintEventArgs e)
        {
            // graficky kontext
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // vykreslenie mapoveho podkladu
            if (ProjectData.BackgroundVisible && ProjectData.Bitmap != null)
                g.DrawImage(ProjectData.Bitmap, 0, 0);

            // vykreslenie vsetkych hran siete
            foreach (NetworkEdge edge in ProjectData.GetNetworkEdges())
                edge.Draw(e.Graphics);

            // vykreslenie vsetkych uzlov siete
            foreach (NetworkNode node in ProjectData.GetNetworkNodes())
                node.Draw(e.Graphics);

            if (ProjectData.Mode == EditorMode.EditingEdge &&
                ProjectData.State == EditorState.AddingEdge &&
                ProjectData.ActiveNode != null)
            {
                float[] dashValues = { 5, 2, 5, 2 };
                using Pen blackPen = new(Color.Gray, 2.0f);
                blackPen.DashPattern = dashValues;
                g.DrawLine(blackPen, ProjectData.ActiveNode.Position, ProjectData.CurrentMousePosition);
            }

            if( ProjectData.State == EditorState.SelectorTrakcing)
            {
                SelectionBox.Draw(g);
            }
        }

        private void doubleBufferedPanelDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            ProjectData.CurrentMousePosition = e.Location;

            if (e.Button == MouseButtons.Left)
            {
                if (ProjectData.Mode == EditorMode.EditingNode)
                {
                    NetworkNode? node = ProjectData.IsNodeHitByMouse(e.Location);

                    // zistime ci sme klikli na nejaky uzol
                    if (node != null)
                    {
                        ProjectData.SelectNode(node);
                        propertyGrid1.SelectedObject = node;
                        ProjectData.State = EditorState.Dragging;
                    }
                    else if (ProjectData.isCtrlPressed )
                    {
                        NetworkNode newNode = new(e.Location);

                        ProjectData.GetNetworkNodes().Add(newNode);
                        ProjectData.SelectNode(newNode);
                        newNode.Selected = true;
                        propertyGrid1.SelectedObject = newNode;
                    }
                    else
                    {
                        SelectionBox.Start = e.Location;
                        ProjectData.State = EditorState.SelectorTrakcing;
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
            if(ProjectData.State == EditorState.SelectorTrakcing && SelectionBox.IsActive)
            {
                using Region r = SelectionBox.Track(e.Location);
                doubleBufferedPanelDrawing.Invalidate(r);
                return;
            }

            else if (ProjectData.Mode == EditorMode.EditingNode)
            {

                NetworkNode? node = ProjectData.SelectedNode;

                if (node != null && ProjectData.State == EditorState.Dragging)
                {
                    node.Position = e.Location;

                }
            }
            else if (ProjectData.Mode == EditorMode.EditingEdge && ProjectData.ActiveNode != null)
            {

            }
            

            doubleBufferedPanelDrawing.Invalidate();
        }
        private void doubleBufferedPanelDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            if (ProjectData.Mode == EditorMode.EditingEdge && ProjectData.ActiveNode != null)
            {
                NetworkNode? node = ProjectData.IsNodeHitByMouse(e.Location);

                if (node != null)
                    ProjectData.GetNetworkEdges().Add(new(ProjectData.ActiveNode, node));
            }

            ProjectData.State = EditorState.None;
            SelectionBox.IsActive = false;

            propertyGrid1.Refresh();
            doubleBufferedPanelDrawing.Invalidate();
        }

        private void checkBoxBackgroundVisible_CheckedChanged(object sender, EventArgs e)
        {
            ProjectData.BackgroundVisible = checkBoxBackgroundVisible.Checked;

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

            ProjectData.BitmapPath = openFileDialog.FileName;
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

            ProjectData.LoadNetworkData();

            doubleBufferedPanelDrawing.Invalidate();
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                ProjectData.isCtrlPressed = true;
            }
        }

        private void FormMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                ProjectData.isCtrlPressed = false;
            }
        }
    }
}