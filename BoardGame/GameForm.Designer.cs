
namespace BoardGame
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.GameToolstrip = new System.Windows.Forms.ToolStrip();
            this.Menu = new System.Windows.Forms.ToolStripDropDownButton();
            this.StartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripTypeDropdown = new System.Windows.Forms.ToolStripDropDownButton();
            this.chessStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reversiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GameToolstrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameToolstrip
            // 
            this.GameToolstrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GameToolstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu,
            this.ToolStripTypeDropdown});
            this.GameToolstrip.Location = new System.Drawing.Point(0, 0);
            this.GameToolstrip.Name = "GameToolstrip";
            this.GameToolstrip.Size = new System.Drawing.Size(784, 25);
            this.GameToolstrip.TabIndex = 0;
            this.GameToolstrip.Text = "GameToolstrip";
            // 
            // Menu
            // 
            this.Menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.LoadToolStripMenuItem,
            this.ReplayToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.Menu.Image = ((System.Drawing.Image)(resources.GetObject("Menu.Image")));
            this.Menu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(51, 22);
            this.Menu.Text = "Menu";
            // 
            // StartToolStripMenuItem
            // 
            this.StartToolStripMenuItem.Name = "StartToolStripMenuItem";
            this.StartToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.StartToolStripMenuItem.Text = "&Start";
            this.StartToolStripMenuItem.Click += new System.EventHandler(this.StartToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.SaveToolStripMenuItem.Text = "Save";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // LoadToolStripMenuItem
            // 
            this.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem";
            this.LoadToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.LoadToolStripMenuItem.Text = "Load";
            this.LoadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // ReplayToolStripMenuItem
            // 
            this.ReplayToolStripMenuItem.Name = "ReplayToolStripMenuItem";
            this.ReplayToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.ReplayToolStripMenuItem.Text = "Replay";
            this.ReplayToolStripMenuItem.Click += new System.EventHandler(this.ReplayToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // ToolStripTypeDropdown
            // 
            this.ToolStripTypeDropdown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripTypeDropdown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chessStripMenuItem1,
            this.reversiToolStripMenuItem});
            this.ToolStripTypeDropdown.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripTypeDropdown.Image")));
            this.ToolStripTypeDropdown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripTypeDropdown.Name = "ToolStripTypeDropdown";
            this.ToolStripTypeDropdown.Size = new System.Drawing.Size(78, 22);
            this.ToolStripTypeDropdown.Tag = "ToolStripTypeDropdown";
            this.ToolStripTypeDropdown.Text = "Game Type";
            // 
            // chessStripMenuItem1
            // 
            this.chessStripMenuItem1.Name = "chessStripMenuItem1";
            this.chessStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.chessStripMenuItem1.Text = "Chess";
            this.chessStripMenuItem1.Click += new System.EventHandler(this.ChessStripMenuItem1_Click);
            // 
            // reversiToolStripMenuItem
            // 
            this.reversiToolStripMenuItem.Name = "reversiToolStripMenuItem";
            this.reversiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reversiToolStripMenuItem.Text = "Reversi";
            this.reversiToolStripMenuItem.Click += new System.EventHandler(this.ReversiToolStripMenuItem_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.GameToolstrip);
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Form";
            this.GameToolstrip.ResumeLayout(false);
            this.GameToolstrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip GameToolstrip;
        private System.Windows.Forms.ToolStripMenuItem chessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reversiToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ChessToolStripMenuItem2;
        private System.Windows.Forms.ToolStripDropDownButton Menu;
        private System.Windows.Forms.ToolStripMenuItem StartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReplayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reversiToolStripMenuItem2;
        private System.Windows.Forms.ToolStripDropDownButton ToolStripTypeDropdown;
        private System.Windows.Forms.ToolStripMenuItem chessStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reversiToolStripMenuItem;
    }
}

