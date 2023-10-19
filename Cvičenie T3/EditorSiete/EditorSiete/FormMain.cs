using EditorSiete.GraphicalObjects;
using EditorSiete.ProjectData;
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

            // vykreslenie mapoveho podkladu
            if (ProjectData.ProjectData.BacgroundVisible && ProjectData.ProjectData.Bitmap != null)
                g.DrawImage(ProjectData.ProjectData.Bitmap, 0, 0);

            // vykreslenie vešetkých hrán siete
            foreach (NetworkEdge node in ProjectData.ProjectData.Edges)
                node.Draw(e.Graphics);

            // vykreslenie vsetkych uzlov siete
            foreach (NetworkNode node in ProjectData.ProjectData.Nodes)
                node.Draw(e.Graphics);

            if (ProjectData.ProjectData.Mode == EditorMode.EditingEdge
                && ProjectData.ProjectData.editorState == EditorState.AddingEdge
                && ProjectData.ProjectData.activeNode != null)
            {
                float[] dashValues = { 5, 2, 5, 2 };
                using Pen blackPen = new Pen(Color.Black, 5);
                blackPen.DashPattern = dashValues;
                e.Graphics.DrawLine(blackPen, ProjectData.ProjectData.activeNode.Position, ProjectData.ProjectData.CurrentMousePosition);
            }
        }

        private void doubleBufferedPanelDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (ProjectData.ProjectData.Mode == EditorMode.EditingNode)
                {
                    // zistime či sme klikli na nejaký point
                    NetworkNode? node = ProjectData.ProjectData.isNodeHitByMouse(e.Location);
                    if (node != null)
                    {
                        ProjectData.ProjectData.SelectNode(node);
                        propertyGrid1.SelectedObject = node;
                        ProjectData.ProjectData.editorState = EditorState.Dragging;
                    }
                    else
                    {
                        NetworkNode tmp = new(e.Location);
                        ProjectData.ProjectData.Nodes.Add(tmp);
                        ProjectData.ProjectData.SelectNode(node);
                        propertyGrid1.SelectedObject = tmp;
                    }
                } else if (ProjectData.ProjectData.Mode == EditorMode.EditingEdge)
                {
                    NetworkNode? node = ProjectData.ProjectData.isNodeHitByMouse(e.Location);
                    if (node != null)
                    {
                        ProjectData.ProjectData.activeNode = node;
                        ProjectData.ProjectData.editorState = EditorState.AddingEdge;
                    }
                }

            }
            else if (e.Button == MouseButtons.Right)
            {
                ProjectData.ProjectData.DeleteNode(ProjectData.ProjectData.isNodeHitByMouse(e.Location));
            }

            doubleBufferedPanelDrawing.Invalidate();
        }

        private void checkBoxBackgroundVisible_CheckedChanged(object sender, EventArgs e)
        {
            ProjectData.ProjectData.BacgroundVisible = checkBoxBackgroundVisible.Checked;

            doubleBufferedPanelDrawing.Invalidate();
        }

        private void loadeImmageToolStripMenuItem_Click(object sender, EventArgs e)
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

            ProjectData.ProjectData.BitmapPath = openFileDialog.FileName;
            ProjectData.ProjectData.LoadBitmap();
            doubleBufferedPanelDrawing.Invalidate();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            doubleBufferedPanelDrawing.Invalidate();
        }

        private void doubleBufferedPanelDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            ProjectData.ProjectData.CurrentMousePosition = e.Location;

            if (ProjectData.ProjectData.Mode == EditorMode.EditingNode)
            {
                NetworkNode? node = ProjectData.ProjectData.selectedNode;
                if (ProjectData.ProjectData.selectedNode != null && ProjectData.ProjectData.editorState == EditorState.Dragging)
                {
                    node.Position = e.Location;
                    propertyGrid1.Refresh();
                }
            }
            if (ProjectData.ProjectData.Mode == EditorMode.EditingEdge && ProjectData.ProjectData.activeNode != null)
            {
                
            }

            doubleBufferedPanelDrawing.Invalidate();
            
        }

        private void doubleBufferedPanelDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            if (ProjectData.ProjectData.Mode == EditorMode.EditingEdge && ProjectData.ProjectData.activeNode != null)
            {
                NetworkNode? node = ProjectData.ProjectData.isNodeHitByMouse(e.Location);
                if (node != null)
                {
                    ProjectData.ProjectData.Edges.Add(new NetworkEdge(ProjectData.ProjectData.activeNode, node));
                }
            }

                ProjectData.ProjectData.editorState = ProjectData.EditorState.None;
        }

        private void nodes_CheckedChanged(object sender, EventArgs e)
        {
            ProjectData.ProjectData.Mode = EditorMode.EditingNode;
            ProjectData.ProjectData.SelectNode(null);
        }

        private void edges_CheckedChanged(object sender, EventArgs e)
        {
            ProjectData.ProjectData.Mode = EditorMode.EditingEdge;
            ProjectData.ProjectData.SelectNode(null);
        }
    }
}