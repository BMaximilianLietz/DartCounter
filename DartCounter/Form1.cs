using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Recognition;

namespace DartCounter
{
    public partial class Form1 : Form
    {
        FlowLayoutPanel scoreCounter = new FlowLayoutPanel();
        Panel topPanel = new Panel();
        Label testlabel = new Label();
        Label descriptionLabel = new Label();
        Label scoreLabel = new Label();
        TextBox enterScore = new TextBox();
        Button submit = new Button();
        Button btn2 = new Button();

        Boolean gameOverFlag = false;


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
            this.scoreCounter.FlowDirection = FlowDirection.TopDown;
            this.scoreCounter.WrapContents = true;
            this.scoreCounter.AutoScroll = true;
            this.scoreCounter.VerticalScroll.Visible = true;

            // 
            // topPanel
            // 
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            //this.topPanel.Size = new System.Drawing.Size(206, 277);
            this.topPanel.AutoSize = true;
            this.topPanel.TabIndex = 1;

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
            this.enterScore.TextChanged += EnterScore_TextChanged;

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
            this.submit.Click += submit_Click;

            // 
            // test label
            // 
            this.testlabel.AutoSize = true;
            this.testlabel.Text = "Points left";
            this.testlabel.Location = new System.Drawing.Point(0, 0);
            this.testlabel.Size = new System.Drawing.Size(60, 15);
            this.testlabel.Name = "testlabel";
            this.testlabel.TabIndex = 0;

            // 
            // score label
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Text = "301";
            this.scoreLabel.Location = new System.Drawing.Point(65, 0);
            this.scoreLabel.Size = new System.Drawing.Size(65, 15);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.TabIndex = 0;


            this.Controls.Add(scoreCounter);
            this.topPanel.Controls.Add(testlabel);
            this.topPanel.Controls.Add(scoreLabel);
            this.scoreCounter.Controls.Add(topPanel);
            this.Controls.Add(descriptionLabel);
            this.Controls.Add(enterScore);
            this.Controls.Add(submit);
            this.ActiveControl = enterScore;
        }

        private void EnterScore_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int buffer = Convert.ToInt16(enterScore.Text);
                if (buffer.ToString().Length == 1)
                {
                    newEntry((buffer).ToString());
                }
                else if (buffer.ToString().Length == 2)
                {
                    int firsletter = Convert.ToInt16(buffer.ToString()[0].ToString());
                    newEntry((buffer-firsletter).ToString());
                    MessageBox.Show(firsletter.ToString());
                } else if (buffer.ToString().Length == 3)
                {
                    int firsletter = Convert.ToInt32(buffer.ToString()[0]);
                    int secondletter = Convert.ToInt32(buffer.ToString()[1]);
                    newEntry((buffer - firsletter - secondletter).ToString());
                } else
                {
                    MessageBox.Show("don't cheat mate");
                }

            } catch
            {

            }
            newEntry(enterScore.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create a new SpeechRecognitionEngine instance
            SpeechRecognizer sr = new SpeechRecognizer();
            sr.LoadGrammar(createGrammar());
            sr.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sr_SpeechRecognized);

        }

        void sr_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            MessageBox.Show(e.Result.Text);
            //enterScore.Text = e.Result.Text;
            /*
            int buffer2 = Convert.ToInt16(e.Result.Text);
            newEntry(buffer2.ToString());
            if (e.Result.Text.Equals("New Game Single Player")) {
                singlePlayerToolStripMenuItem_Click(singlePlayerToolStripMenuItem, e);
            }
            try
            {
                MessageBox.Show("something was tried");
                int buffer = Convert.ToInt16(e.Result.Text);
                newEntry(buffer.ToString());
            } catch
            {

            }
            */
        }


        private void submit_Click(object sender, EventArgs e)
        {
            newEntry(enterScore.Text); 
        }

        private Grammar createGrammar()
        {
            Choices phrases = new Choices();
            phrases.Add(new string[] { "New Game Single Player" });

            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(phrases);

            // Create the Grammar instance.
            Grammar g = new Grammar(gb);
            return g;
        }

        private SpeechRecognitionEngine LoadDictationGrammars()
        {
            // Create a default dictation grammar.
            DictationGrammar defaultDictationGrammar = new DictationGrammar();
            defaultDictationGrammar.Name = "default dictation";
            defaultDictationGrammar.Enabled = true;

            // Create the spelling dictation grammar.
            DictationGrammar spellingDictationGrammar =
              new DictationGrammar("grammar:dictation#spelling");
            spellingDictationGrammar.Name = "spelling dictation";
            spellingDictationGrammar.Enabled = true;

            // Create the question dictation grammar.
            DictationGrammar customDictationGrammar =
              new DictationGrammar("grammar:dictation");
            customDictationGrammar.Name = "question dictation";
            customDictationGrammar.Enabled = true;

            // Create a SpeechRecognitionEngine object and add the grammars to it.
            SpeechRecognitionEngine recoEngine = new SpeechRecognitionEngine();
            recoEngine.LoadGrammar(defaultDictationGrammar);
            recoEngine.LoadGrammar(spellingDictationGrammar);
            recoEngine.LoadGrammar(customDictationGrammar);

            // Add a context to customDictationGrammar.
            customDictationGrammar.SetDictationContext("How do you", null);

            return recoEngine;
        }

        private string scoreSubtract(string currentscorestring, string thrownscorestring)
        {
            int currentscore = Convert.ToInt16(currentscorestring);
            int thrownscore = Convert.ToInt16(thrownscorestring);
            currentscore -= thrownscore;
            if (currentscore < 0 )
            {
                if (gameOverFlag == true)
                {
                    MessageBox.Show("Game's already over mate");
                    return (0).ToString();
                } else
                {
                    MessageBox.Show("Well that didn't work out");
                    return (currentscore + thrownscore).ToString();
                }
                
            } else if (currentscore == 0)
            {
                MessageBox.Show("Win");
                gameOverFlag = true;
            }

            return currentscore.ToString();
        }

        private void newEntry(string throwValue)
        {
            try
            {
                Label bufferLabel = new Label();
                bufferLabel.Text = throwValue;
                bufferLabel.AutoSize = true;
                bufferLabel.Size = new System.Drawing.Size(65, 15);
                this.scoreCounter.Controls.Add(bufferLabel);

                scoreLabel.Text = scoreSubtract(scoreLabel.Text,
                    enterScore.Text);
            }
            catch
            {
                Debug.WriteLine("there was an error");
            }
        }

        private void initNumbers()
        {
            

            //(new string[] { "New Game Single Player" });
        }
    }
}
