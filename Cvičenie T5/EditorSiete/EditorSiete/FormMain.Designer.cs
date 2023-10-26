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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadBackgroundImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTools = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonEdges = new System.Windows.Forms.RadioButton();
            this.radioButtonNodes = new System.Windows.Forms.RadioButton();
            this.panelPropertyGrid = new System.Windows.Forms.Panel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.checkBoxBackgroundVisible = new System.Windows.Forms.CheckBox();
            this.doubleBufferedPanelDrawing = new EditorSiete.Tools.DoubleBufferedPanel();
            this.menuStrip1.SuspendLayout();
            this.panelTools.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelPropertyGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.projectToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1190, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newProjectToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadBackgroundImageToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // loadBackgroundImageToolStripMenuItem
            // 
            this.loadBackgroundImageToolStripMenuItem.Name = "loadBackgroundImageToolStripMenuItem";
            this.loadBackgroundImageToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.loadBackgroundImageToolStripMenuItem.Text = "Load background image";
            // 
            // panelTools
            // 
            this.panelTools.Controls.Add(this.groupBox1);
            this.panelTools.Controls.Add(this.panelPropertyGrid);
            this.panelTools.Controls.Add(this.checkBoxBackgroundVisible);
            this.panelTools.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTools.Location = new System.Drawing.Point(0, 24);
            this.panelTools.Name = "panelTools";
            this.panelTools.Size = new System.Drawing.Size(206, 661);
            this.panelTools.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonEdges);
            this.groupBox1.Controls.Add(this.radioButtonNodes);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 80);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Editor state";
            // 
            // radioButtonEdges
            // 
            this.radioButtonEdges.AutoSize = true;
            this.radioButtonEdges.Location = new System.Drawing.Point(9, 51);
            this.radioButtonEdges.Name = "radioButtonEdges";
            this.radioButtonEdges.Size = new System.Drawing.Size(79, 19);
            this.radioButtonEdges.TabIndex = 1;
            this.radioButtonEdges.TabStop = true;
            this.radioButtonEdges.Text = "Edit edges";
            this.radioButtonEdges.UseVisualStyleBackColor = true;
            this.radioButtonEdges.CheckedChanged += new System.EventHandler(this.radioButtonEdges_CheckedChanged);
            // 
            // radioButtonNodes
            // 
            this.radioButtonNodes.AutoSize = true;
            this.radioButtonNodes.Checked = true;
            this.radioButtonNodes.Location = new System.Drawing.Point(9, 26);
            this.radioButtonNodes.Name = "radioButtonNodes";
            this.radioButtonNodes.Size = new System.Drawing.Size(80, 19);
            this.radioButtonNodes.TabIndex = 0;
            this.radioButtonNodes.TabStop = true;
            this.radioButtonNodes.Text = "Edit nodes";
            this.radioButtonNodes.UseVisualStyleBackColor = true;
            this.radioButtonNodes.CheckedChanged += new System.EventHandler(this.radioButtonNodes_CheckedChanged);
            // 
            // panelPropertyGrid
            // 
            this.panelPropertyGrid.Controls.Add(this.propertyGrid1);
            this.panelPropertyGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPropertyGrid.Location = new System.Drawing.Point(0, 335);
            this.panelPropertyGrid.Name = "panelPropertyGrid";
            this.panelPropertyGrid.Size = new System.Drawing.Size(206, 326);
            this.panelPropertyGrid.TabIndex = 1;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(206, 326);
            this.propertyGrid1.TabIndex = 0;
            // 
            // checkBoxBackgroundVisible
            // 
            this.checkBoxBackgroundVisible.AutoSize = true;
            this.checkBoxBackgroundVisible.Checked = true;
            this.checkBoxBackgroundVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBackgroundVisible.Location = new System.Drawing.Point(21, 14);
            this.checkBoxBackgroundVisible.Name = "checkBoxBackgroundVisible";
            this.checkBoxBackgroundVisible.Size = new System.Drawing.Size(127, 19);
            this.checkBoxBackgroundVisible.TabIndex = 0;
            this.checkBoxBackgroundVisible.Text = "Visible background";
            this.checkBoxBackgroundVisible.UseVisualStyleBackColor = true;
            // 
            // doubleBufferedPanelDrawing
            // 
            this.doubleBufferedPanelDrawing.BackColor = System.Drawing.Color.White;
            this.doubleBufferedPanelDrawing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doubleBufferedPanelDrawing.Location = new System.Drawing.Point(206, 24);
            this.doubleBufferedPanelDrawing.Name = "doubleBufferedPanelDrawing";
            this.doubleBufferedPanelDrawing.Size = new System.Drawing.Size(984, 661);
            this.doubleBufferedPanelDrawing.TabIndex = 2;
            this.doubleBufferedPanelDrawing.Paint += new System.Windows.Forms.PaintEventHandler(this.doubleBufferedPanelDrawing_Paint);
            this.doubleBufferedPanelDrawing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.doubleBufferedPanelDrawing_MouseDown);
            this.doubleBufferedPanelDrawing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.doubleBufferedPanelDrawing_MouseMove);
            this.doubleBufferedPanelDrawing.MouseUp += new System.Windows.Forms.MouseEventHandler(this.doubleBufferedPanelDrawing_MouseUp);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 685);
            this.Controls.Add(this.doubleBufferedPanelDrawing);
            this.Controls.Add(this.panelTools);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Editor siete";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelTools.ResumeLayout(false);
            this.panelTools.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelPropertyGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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