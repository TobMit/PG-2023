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

            // vykreslenie vsetkych uzlov siete
            foreach (NetworkNode node in ProjectData.ProjectData.Nodes)
                node.Draw(e.Graphics);
        }

        private void doubleBufferedPanelDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // zistime či sme klikli na nejaký point
                NetworkNode? node = ProjectData.ProjectData.isNodeHitByMouse(e.Location);
                if (node != null)
                {
                    ProjectData.ProjectData.SelectNode(node);
                    propertyGrid1.SelectedObject = node;
                    ProjectData.ProjectData.editorState = EditorState.StartDragging;
                }
                else
                {
                    NetworkNode tmp = new(e.Location);
                    ProjectData.ProjectData.Nodes.Add(tmp);
                    ProjectData.ProjectData.SelectNode(node);
                    propertyGrid1.SelectedObject = tmp;
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
            NetworkNode? node = ProjectData.ProjectData.selectedNode;
            if (ProjectData.ProjectData.selectedNode != null && ProjectData.ProjectData.editorState == EditorState.StartDragging)
            {
                node.Position = e.Location;
            }
            doubleBufferedPanelDrawing.Invalidate();
            propertyGrid1.Refresh();
        }

        private void doubleBufferedPanelDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            ProjectData.ProjectData.editorState = ProjectData.EditorState.None;
        }
    }
}