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
            loadBackgroundImageToolStripMenuItem = new ToolStripMenuItem();
            panelTools = new Panel();
            groupBox1 = new GroupBox();
            radioButtonEdges = new RadioButton();
            radioButtonNodes = new RadioButton();
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, projectToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1190, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newProjectToolStripMenuItem, openToolStripMenuItem, closeToolStripMenuItem, saveToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            newProjectToolStripMenuItem.Size = new Size(103, 22);
            newProjectToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(103, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(103, 22);
            closeToolStripMenuItem.Text = "Close";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(103, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(103, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // projectToolStripMenuItem
            // 
            projectToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadBackgroundImageToolStripMenuItem });
            projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            projectToolStripMenuItem.Size = new Size(56, 20);
            projectToolStripMenuItem.Text = "Project";
            // 
            // loadBackgroundImageToolStripMenuItem
            // 
            loadBackgroundImageToolStripMenuItem.Name = "loadBackgroundImageToolStripMenuItem";
            loadBackgroundImageToolStripMenuItem.Size = new Size(203, 22);
            loadBackgroundImageToolStripMenuItem.Text = "Load background image";
            // 
            // panelTools
            // 
            panelTools.Controls.Add(groupBox1);
            panelTools.Controls.Add(panelPropertyGrid);
            panelTools.Controls.Add(checkBoxBackgroundVisible);
            panelTools.Dock = DockStyle.Left;
            panelTools.Location = new Point(0, 24);
            panelTools.Name = "panelTools";
            panelTools.Size = new Size(206, 661);
            panelTools.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButtonEdges);
            groupBox1.Controls.Add(radioButtonNodes);
            groupBox1.Location = new Point(12, 39);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(182, 78);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Editor state";
            // 
            // radioButtonEdges
            // 
            radioButtonEdges.AutoSize = true;
            radioButtonEdges.Location = new Point(9, 51);
            radioButtonEdges.Name = "radioButtonEdges";
            radioButtonEdges.Size = new Size(79, 19);
            radioButtonEdges.TabIndex = 1;
            radioButtonEdges.TabStop = true;
            radioButtonEdges.Text = "Edit edges";
            radioButtonEdges.UseVisualStyleBackColor = true;
            radioButtonEdges.CheckedChanged += radioButtonEdges_CheckedChanged;
            // 
            // radioButtonNodes
            // 
            radioButtonNodes.AutoSize = true;
            radioButtonNodes.Checked = true;
            radioButtonNodes.Location = new Point(9, 26);
            radioButtonNodes.Name = "radioButtonNodes";
            radioButtonNodes.Size = new Size(80, 19);
            radioButtonNodes.TabIndex = 0;
            radioButtonNodes.TabStop = true;
            radioButtonNodes.Text = "Edit nodes";
            radioButtonNodes.UseVisualStyleBackColor = true;
            radioButtonNodes.CheckedChanged += radioButtonNodes_CheckedChanged;
            // 
            // panelPropertyGrid
            // 
            panelPropertyGrid.Controls.Add(propertyGrid1);
            panelPropertyGrid.Dock = DockStyle.Bottom;
            panelPropertyGrid.Location = new Point(0, 335);
            panelPropertyGrid.Name = "panelPropertyGrid";
            panelPropertyGrid.Size = new Size(206, 326);
            panelPropertyGrid.TabIndex = 1;
            // 
            // propertyGrid1
            // 
            propertyGrid1.Dock = DockStyle.Fill;
            propertyGrid1.Location = new Point(0, 0);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(206, 326);
            propertyGrid1.TabIndex = 0;
            // 
            // checkBoxBackgroundVisible
            // 
            checkBoxBackgroundVisible.AutoSize = true;
            checkBoxBackgroundVisible.Checked = true;
            checkBoxBackgroundVisible.CheckState = CheckState.Checked;
            checkBoxBackgroundVisible.Location = new Point(21, 14);
            checkBoxBackgroundVisible.Name = "checkBoxBackgroundVisible";
            checkBoxBackgroundVisible.Size = new Size(127, 19);
            checkBoxBackgroundVisible.TabIndex = 0;
            checkBoxBackgroundVisible.Text = "Visible background";
            checkBoxBackgroundVisible.UseVisualStyleBackColor = true;
            // 
            // doubleBufferedPanelDrawing
            // 
            doubleBufferedPanelDrawing.BackColor = Color.White;
            doubleBufferedPanelDrawing.Dock = DockStyle.Fill;
            doubleBufferedPanelDrawing.Location = new Point(206, 24);
            doubleBufferedPanelDrawing.Name = "doubleBufferedPanelDrawing";
            doubleBufferedPanelDrawing.Size = new Size(984, 661);
            doubleBufferedPanelDrawing.TabIndex = 2;
            doubleBufferedPanelDrawing.Paint += doubleBufferedPanelDrawing_Paint;
            doubleBufferedPanelDrawing.MouseDown += doubleBufferedPanelDrawing_MouseDown;
            doubleBufferedPanelDrawing.MouseMove += doubleBufferedPanelDrawing_MouseMove;
            doubleBufferedPanelDrawing.MouseUp += doubleBufferedPanelDrawing_MouseUp;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1190, 685);
            Controls.Add(doubleBufferedPanelDrawing);
            Controls.Add(panelTools);
            Controls.Add(menuStrip1);
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Name = "FormMain";
            Text = "Editor siete";
            KeyDown += FormMain_KeyDown;
            KeyUp += FormMain_KeyUp;
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
        private ToolStripMenuItem loadBackgroundImageToolStripMenuItem;
        private Panel panelPropertyGrid;
        private PropertyGrid propertyGrid1;
        private GroupBox groupBox1;
        private RadioButton radioButtonEdges;
        private RadioButton radioButtonNodes;
    }
}