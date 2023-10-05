namespace Cvičenie_T2
{
    partial class Okno
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
            closeToolStripMenuItem1 = new ToolStripMenuItem();
            projectToolStripMenuItem = new ToolStripMenuItem();
            loadMapToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            doubleBufferedPanelDrowing = new Tools.DoubleBufferedPanel();
            chekcstate = new CheckBox();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, projectToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(3, 1, 0, 1);
            menuStrip1.Size = new Size(769, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newProjectToolStripMenuItem, openToolStripMenuItem, closeToolStripMenuItem, closeToolStripMenuItem1 });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 22);
            fileToolStripMenuItem.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            newProjectToolStripMenuItem.Size = new Size(138, 22);
            newProjectToolStripMenuItem.Text = "New project";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(138, 22);
            openToolStripMenuItem.Text = "Open";
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(138, 22);
            closeToolStripMenuItem.Text = "Close";
            // 
            // closeToolStripMenuItem1
            // 
            closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
            closeToolStripMenuItem1.Size = new Size(138, 22);
            closeToolStripMenuItem1.Text = "Exit";
            closeToolStripMenuItem1.Click += closeToolStripMenuItem1_Click;
            // 
            // projectToolStripMenuItem
            // 
            projectToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadMapToolStripMenuItem });
            projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            projectToolStripMenuItem.Size = new Size(56, 22);
            projectToolStripMenuItem.Text = "Project";
            // 
            // loadMapToolStripMenuItem
            // 
            loadMapToolStripMenuItem.Name = "loadMapToolStripMenuItem";
            loadMapToolStripMenuItem.Size = new Size(127, 22);
            loadMapToolStripMenuItem.Text = "Load map";
            // 
            // panel1
            // 
            panel1.Controls.Add(chekcstate);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 442);
            panel1.TabIndex = 1;
            // 
            // doubleBufferedPanelDrowing
            // 
            doubleBufferedPanelDrowing.BackColor = Color.White;
            doubleBufferedPanelDrowing.Dock = DockStyle.Fill;
            doubleBufferedPanelDrowing.Location = new Point(200, 24);
            doubleBufferedPanelDrowing.Name = "doubleBufferedPanelDrowing";
            doubleBufferedPanelDrowing.Size = new Size(569, 442);
            doubleBufferedPanelDrowing.TabIndex = 2;
            doubleBufferedPanelDrowing.Paint += doubleBufferedPanelDrowing_Paint;
            doubleBufferedPanelDrowing.MouseDown += doubleBufferedPanelDrowing_MouseDown;
            // 
            // chekcstate
            // 
            chekcstate.AutoSize = true;
            chekcstate.Checked = true;
            chekcstate.CheckState = CheckState.Checked;
            chekcstate.Location = new Point(12, 3);
            chekcstate.Name = "chekcstate";
            chekcstate.Size = new Size(126, 19);
            chekcstate.TabIndex = 0;
            chekcstate.Text = "Background visible";
            chekcstate.UseVisualStyleBackColor = true;
            chekcstate.CheckStateChanged += chekcstate_CheckStateChanged;
            // 
            // Okno
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(769, 466);
            Controls.Add(doubleBufferedPanelDrowing);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2, 1, 2, 1);
            Name = "Okno";
            Text = "Form1";
            Load += Okno_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newProjectToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem projectToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem1;
        private ToolStripMenuItem loadMapToolStripMenuItem;
        private Panel panel1;
        private Tools.DoubleBufferedPanel doubleBufferedPanelDrowing;
        private CheckBox chekcstate;
    }
}