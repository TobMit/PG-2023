namespace EditorSiete
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newProjectToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            projectToolStripMenuItem = new ToolStripMenuItem();
            loadeImmageToolStripMenuItem = new ToolStripMenuItem();
            panelTools = new Panel();
            groupBox1 = new GroupBox();
            edges = new RadioButton();
            nodes = new RadioButton();
            panelPropertyGrid = new Panel();
            propertyGrid1 = new PropertyGrid();
            checkBoxBackgroundVisible = new CheckBox();
            doubleBufferedPanelDrawing = new Tools.DoubleBufferedPanel();
            menuStrip1.SuspendLayout();
            panelTools.SuspendLayout();
            groupBox1.SuspendLayout();
            panelPropertyGrid.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, projectToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(11, 4, 0, 4);
            menuStrip1.Size = new Size(2210, 46);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newProjectToolStripMenuItem, openToolStripMenuItem, closeToolStripMenuItem, saveToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(71, 38);
            fileToolStripMenuItem.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            newProjectToolStripMenuItem.Size = new Size(359, 44);
            newProjectToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(359, 44);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(359, 44);
            closeToolStripMenuItem.Text = "Close";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(359, 44);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(359, 44);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // projectToolStripMenuItem
            // 
            projectToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadeImmageToolStripMenuItem });
            projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            projectToolStripMenuItem.Size = new Size(107, 38);
            projectToolStripMenuItem.Text = "Project";
            // 
            // loadeImmageToolStripMenuItem
            // 
            loadeImmageToolStripMenuItem.Name = "loadeImmageToolStripMenuItem";
            loadeImmageToolStripMenuItem.Size = new Size(305, 44);
            loadeImmageToolStripMenuItem.Text = "Loade Immage";
            loadeImmageToolStripMenuItem.Click += loadeImmageToolStripMenuItem_Click;
            // 
            // panelTools
            // 
            panelTools.Controls.Add(groupBox1);
            panelTools.Controls.Add(panelPropertyGrid);
            panelTools.Controls.Add(checkBoxBackgroundVisible);
            panelTools.Dock = DockStyle.Left;
            panelTools.Location = new Point(0, 46);
            panelTools.Margin = new Padding(6);
            panelTools.Name = "panelTools";
            panelTools.Size = new Size(371, 1415);
            panelTools.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(edges);
            groupBox1.Controls.Add(nodes);
            groupBox1.Location = new Point(12, 75);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(338, 194);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "EditorState";
            // 
            // edges
            // 
            edges.AutoSize = true;
            edges.Location = new Point(9, 87);
            edges.Name = "edges";
            edges.Size = new Size(155, 36);
            edges.TabIndex = 1;
            edges.Text = "Edit Edges";
            edges.UseVisualStyleBackColor = true;
            edges.CheckedChanged += edges_CheckedChanged;
            // 
            // nodes
            // 
            nodes.AutoSize = true;
            nodes.Checked = true;
            nodes.Location = new Point(13, 39);
            nodes.Name = "nodes";
            nodes.Size = new Size(151, 36);
            nodes.TabIndex = 0;
            nodes.TabStop = true;
            nodes.Text = "Edit Node";
            nodes.UseVisualStyleBackColor = true;
            nodes.CheckedChanged += nodes_CheckedChanged;
            // 
            // panelPropertyGrid
            // 
            panelPropertyGrid.Controls.Add(propertyGrid1);
            panelPropertyGrid.Dock = DockStyle.Bottom;
            panelPropertyGrid.Location = new Point(0, 603);
            panelPropertyGrid.Name = "panelPropertyGrid";
            panelPropertyGrid.Size = new Size(371, 812);
            panelPropertyGrid.TabIndex = 1;
            // 
            // propertyGrid1
            // 
            propertyGrid1.Dock = DockStyle.Fill;
            propertyGrid1.Location = new Point(0, 0);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(371, 812);
            propertyGrid1.TabIndex = 0;
            propertyGrid1.PropertyValueChanged += propertyGrid1_PropertyValueChanged;
            // 
            // checkBoxBackgroundVisible
            // 
            checkBoxBackgroundVisible.AutoSize = true;
            checkBoxBackgroundVisible.Location = new Point(22, 30);
            checkBoxBackgroundVisible.Margin = new Padding(6);
            checkBoxBackgroundVisible.Name = "checkBoxBackgroundVisible";
            checkBoxBackgroundVisible.Size = new Size(250, 36);
            checkBoxBackgroundVisible.TabIndex = 0;
            checkBoxBackgroundVisible.Text = "Visible background";
            checkBoxBackgroundVisible.UseVisualStyleBackColor = true;
            checkBoxBackgroundVisible.CheckedChanged += checkBoxBackgroundVisible_CheckedChanged;
            // 
            // doubleBufferedPanelDrawing
            // 
            doubleBufferedPanelDrawing.BackColor = Color.White;
            doubleBufferedPanelDrawing.Dock = DockStyle.Fill;
            doubleBufferedPanelDrawing.Location = new Point(371, 46);
            doubleBufferedPanelDrawing.Margin = new Padding(6);
            doubleBufferedPanelDrawing.Name = "doubleBufferedPanelDrawing";
            doubleBufferedPanelDrawing.Size = new Size(1839, 1415);
            doubleBufferedPanelDrawing.TabIndex = 2;
            doubleBufferedPanelDrawing.Paint += doubleBufferedPanelDrawing_Paint;
            doubleBufferedPanelDrawing.MouseDown += doubleBufferedPanelDrawing_MouseDown;
            doubleBufferedPanelDrawing.MouseMove += doubleBufferedPanelDrawing_MouseMove;
            doubleBufferedPanelDrawing.MouseUp += doubleBufferedPanelDrawing_MouseUp;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2210, 1461);
            Controls.Add(doubleBufferedPanelDrawing);
            Controls.Add(panelTools);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(6);
            Name = "FormMain";
            Text = "Editor siete";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelTools.ResumeLayout(false);
            panelTools.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panelPropertyGrid.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newProjectToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem projectToolStripMenuItem;
        private Panel panelTools;
        private Tools.DoubleBufferedPanel doubleBufferedPanelDrawing;
        private CheckBox checkBoxBackgroundVisible;
        private ToolStripMenuItem loadeImmageToolStripMenuItem;
        private Panel panelPropertyGrid;
        private PropertyGrid propertyGrid1;
        private GroupBox groupBox1;
        private RadioButton edges;
        private RadioButton nodes;
    }
}