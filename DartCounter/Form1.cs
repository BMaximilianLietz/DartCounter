using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DartCounter
{
    public partial class Form1 : Form
    {
        FlowLayoutPanel scoreCounter = new FlowLayoutPanel();
        Label testlabel = new Label();
        Label descriptionLabel = new Label();
        TextBox enterScore = new TextBox();
        Button submit = new Button();

        public Form1()
        {
            InitializeComponent();
        }

        private void singlePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.scoreCounter.Location = new System.Drawing.Point((int) (this.Width*0.1), 
                (int)(this.Height * 0.1));
            this.scoreCounter.Size = new System.Drawing.Size((int)(this.Width * 0.4),
                (int)(this.Height * 0.4));
            this.scoreCounter.Name = "scoreCounter";

            // 
            // score description label
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Text = "Last Throw";
            this.descriptionLabel.Location = new System.Drawing.Point(
                (int)(this.Width * 0.1), (int)(this.Height * 0.6));
            this.descriptionLabel.Size = new System.Drawing.Size(65, 15);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.TabIndex = 0;

            // 
            // enterScore Textbox
            // 
            this.enterScore.Location = new System.Drawing.Point(
                (int)(this.Width * 0.1)+100, (int)(this.Height * 0.6));
            this.enterScore.Name = "enterScore";
            this.enterScore.Size = new System.Drawing.Size(100, 22);
            this.enterScore.TabIndex = 1;

            // 
            // submit button
            // 

            this.submit.Location = new System.Drawing.Point(
                (int)(this.Width * 0.1), (int)(this.Height * 0.7));
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 23);
            this.submit.TabIndex = 2;
            this.submit.Text = "submit";
            this.submit.UseVisualStyleBackColor = true;

            this.testlabel.AutoSize = true;
            this.testlabel.Text = "You will find your score below";
            this.testlabel.Location = new System.Drawing.Point(0, 0);
            this.testlabel.Size = new System.Drawing.Size(65, 15);
            this.testlabel.Name = "testlabel";
            this.testlabel.TabIndex = 0;


            this.Controls.Add(scoreCounter);
            this.scoreCounter.Controls.Add(testlabel);
            this.Controls.Add(descriptionLabel);
            this.Controls.Add(enterScore);
            this.Controls.Add(submit);

            // 
            // panel1
            // 
            /*
            panel1.Controls.Add(this.label1);
            panel1.Location = new System.Drawing.Point(73, 72);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(206, 277);
            panel1.TabIndex = 1;
            */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 
            // label1
            // 
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
