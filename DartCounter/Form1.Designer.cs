using System.Windows.Forms;

namespace DartCounter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private async void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singlePlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoPlayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savedGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speechOutput = new System.Windows.Forms.TextBox();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.savedGamesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1046, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.singlePlayerToolStripMenuItem,
            this.twoPlayersToolStripMenuItem});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.newGameToolStripMenuItem.Text = "New Game";
            // 
            // singlePlayerToolStripMenuItem
            // 
            this.singlePlayerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.singlePlayerToolStripMenuItem.Name = "singlePlayerToolStripMenuItem";
            this.singlePlayerToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.singlePlayerToolStripMenuItem.Text = "Single Player";
            this.singlePlayerToolStripMenuItem.Click += new System.EventHandler(this.singlePlayerToolStripMenuItem_Click);
            // 
            // twoPlayersToolStripMenuItem
            // 
            this.twoPlayersToolStripMenuItem.Name = "twoPlayersToolStripMenuItem";
            this.twoPlayersToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.twoPlayersToolStripMenuItem.Text = "Two Players";
            // 
            // savedGamesToolStripMenuItem
            // 
            this.savedGamesToolStripMenuItem.Name = "savedGamesToolStripMenuItem";
            this.savedGamesToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.savedGamesToolStripMenuItem.Text = "Saved Games";
            // 
            // speechOutput
            // 
            this.speechOutput.Location = new System.Drawing.Point(699, 78);
            this.speechOutput.Name = "speechOutput";
            this.speechOutput.Size = new System.Drawing.Size(281, 22);
            this.speechOutput.TabIndex = 1;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(216, 26);
            this.toolStripMenuItem2.Text = "301";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(216, 26);
            this.toolStripMenuItem3.Text = "501";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 519);
            this.Controls.Add(this.speechOutput);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Hello";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem savedGamesToolStripMenuItem;
        private ToolStripMenuItem singlePlayerToolStripMenuItem;
        private ToolStripMenuItem twoPlayersToolStripMenuItem;
        private TextBox speechOutput;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
    }
}

