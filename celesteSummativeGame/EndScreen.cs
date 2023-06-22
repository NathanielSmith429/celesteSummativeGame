using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace celesteSummativeGame
{
    public partial class EndScreen : UserControl
    {
        string name;
        string time;

        int counter = 0;

        HighScore newScore;
        TimeSpan elapsed = GameScreen.myWatch.Elapsed;
        public EndScreen()
        {
            InitializeComponent();


            outputLabel.Text = "Your time: " + elapsed.ToString(@"m\:ss\:ff"); //displaying user time
        }

        // create an object of name & score, add that to a list, when you exit program save the list

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (nameBox.Text == "")
            {
                errorLabel.Text = "Please Input Name";
            }
            else
            {
                highscore();
                Form1.ChangeScreen(this, new TitleScreen());
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            if (nameBox.Text == "")
            {
                errorLabel.Text = "Please Input Name";
            }
            else
            {
                highscore();
                Application.Exit();
            }
        }

        public void highscore()
        {
            //creating an object of the player score/time
            newScore = new HighScore(nameBox.Text, (int)GameScreen.myWatch.ElapsedMilliseconds);
            highscoreScreen.scores.Add(newScore);

        }
    }
}
