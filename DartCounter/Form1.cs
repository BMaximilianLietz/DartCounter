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
using System.Speech.Synthesis;

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

        Boolean isHundred = false;
        Boolean gameOverFlag = false;
        Boolean newGameFlag = false;
        Boolean singleplayerFlag = false;
        Boolean multiplayerFlag = false;
        Boolean savedGameFlag = false;

        private static Dictionary<string, int> numberTable = new Dictionary<string, int>
                {{"zero",0},{"one",1},{"two",2},{"three",3},{"four",4},
                {"five",5},{"six",6},{"seven",7},{"eight",8},{"nine",9},
                {"ten",10},{"eleven",11},{"twelve",12},{"thirteen",13},
                {"fourteen",14},{"fifteen",15},{"sixteen",16},
                {"seventeen",17},{"eighteen",18},{"nineteen",19},

                { "twenty",20}, {"twenty one", 21}, {"twenty two", 22}, {"twenty three", 23},
                { "twenty four", 24}, {"twenty five", 25}, {"twenty six", 26}, {"twenty seven", 27},
                { "twenty eight", 28}, {"twenty nine", 29},

                { "thirty",30}, {"thirty one", 31}, {"thirty two", 32}, {"thirty three", 33},
                { "thirty four", 34}, {"thirty five", 35}, {"thirty six", 36}, {"thirty seven", 37},
                { "thirty eight", 38}, {"thirty nine", 39},

                { "forty",40}, {"forty one", 41}, {"forty two", 42}, {"forty three", 43},
                { "forty four", 44}, {"forty five", 45}, {"forty six", 46}, {"forty seven", 47},
                { "forty eight", 48}, {"forty nine", 49},

                { "fifty",50}, {"fifty one", 51}, {"fifty two", 52}, {"fifty three", 53},
                { "fifty four", 54}, {"fifty five", 55}, {"fifty six", 56}, {"fifty seven", 57},
                { "fifty eight", 58}, {"fifty nine", 59},

                { "sixty",60}, {"sixty one", 61}, {"sixty two", 62}, {"sixty three", 63},
                { "sixty four", 64}, {"sixty five", 65}, {"sixty six", 66}, {"sixty seven", 67},
                { "sixty eight", 68}, {"sixty nine", 69},

                { "seventy",70}, {"seventy one", 71}, {"seventy two", 72}, {"seventy three", 73},
                { "seventy four", 74}, {"seventy five", 75}, {"seventy six", 76}, {"seventy seven", 77},
                { "seventy eight", 78}, {"seventy nine", 79},

                { "eighty",80}, {"eighty one", 81}, {"eighty two", 82}, {"eighty three", 83},
                { "eighty four", 84}, {"eighty five", 85}, {"eighty six", 86}, {"eighty seven", 87},
                { "eighty eight", 88}, {"eighty nine", 89},

                { "ninety",90}, {"ninety one", 91}, {"ninety two", 92}, {"ninety three", 93},
                { "ninety four", 99}, {"ninety five", 95}, {"ninety six", 96}, {"ninety seven", 97},
                { "ninety eight", 98}, {"ninety nine", 99},

                { "hundred",100} };

        public Form1()
        {
            InitializeComponent();
        }

        private void singlePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // getting score to get (501 or 301)
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            int score = (int) menuItem.Tag;

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
            this.scoreLabel.Text = score.ToString();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create a new SpeechRecognitionEngine instance
            SpeechRecognizer sr = new SpeechRecognizer();
            sr.LoadGrammar(createGrammar());
            sr.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sr_SpeechRecognized);

        }

        void sr_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text.Equals("New Game"))
            {
                newGameToolStripMenuItem.DropDown.Show();
                newGameFlag = true;
            }
            if (e.Result.Text.Equals("Single Player") )
            {
                singlePlayerToolStripMenuItem.DropDown.Show();
                singleplayerFlag = true;
                newGameFlag = false;
            }
            if (e.Result.Text.Equals("301") && singleplayerFlag)
            {
                newGameToolStripMenuItem.HideDropDown();
                singleplayerFlag = false;
                singlePlayerToolStripMenuItem_Click(toolStripMenuItem2, e);
            }
            if (e.Result.Text.Equals("501") && singleplayerFlag)
            {
                newGameToolStripMenuItem.HideDropDown();
                singleplayerFlag = false;
                singlePlayerToolStripMenuItem_Click(toolStripMenuItem2, e);
            }
            if (e.Result.Text.Equals("hundred"))
            {
                isHundred = true;
                return;
            }
            if (e.Result.Text.Equals("Clear Game"))
            {
                this.Controls.Clear();
                InitializeComponent();
            }
            if (e.Result.Text.Equals("Is Richard Gay"))
            {
                // Initialize a new instance of the SpeechSynthesizer.
                SpeechSynthesizer synth = new SpeechSynthesizer();

                // Select a voice that matches a specific gender.  
                synth.SelectVoiceByHints(VoiceGender.Female);
                synth.SpeakAsync("He is the gayest gay");

            }
            if (numberTable.ContainsKey(e.Result.Text) && !gameOverFlag){
                if (e.Result.Text.Equals("hundred"))
                {
                    isHundred = true;
                    return;
                }

                if (!isHundred)
                {
                    newEntry(numberTable[e.Result.Text].ToString());
                } else
                {
                    if (e.Result.Text.Equals("hundred") && isHundred)
                    {
                        MessageBox.Show("WTF are you doing");
                    } else
                    {
                        isHundred = false;
                        newEntry((numberTable[e.Result.Text] + 100).ToString());
                    }
                }
            } 
        }


        private void submit_Click(object sender, EventArgs e)
        {
            newEntry(enterScore.Text); 
        }

        private Grammar createGrammar()
        {
            Choices phrases = new Choices();
            phrases.Add(new string[] { "New Game", "Single Player", "301", "501", "Is Richard Gay",
            "Clear Game"});
            foreach (string element in initNumbers())
            {
                phrases.Add(element);
            }

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
            //try
            //{
                Label bufferLabel = new Label();
                bufferLabel.Text = throwValue;
                bufferLabel.AutoSize = true;
                bufferLabel.Size = new System.Drawing.Size(65, 15);
                this.scoreCounter.Controls.Add(bufferLabel);

                scoreLabel.Text = scoreSubtract(scoreLabel.Text,
                    throwValue);
            //}
            /*catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Debug.WriteLine("there was an error");
            }
            */
        }

        
        private List<string> initNumbers()
        {
            List<string> buffer = new List<string>();
            foreach (KeyValuePair<string, int> element in numberTable)
            {
                buffer.Add(element.Key);
            }
            return buffer;
        }
    }
}
