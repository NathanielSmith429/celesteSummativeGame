using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace celesteSummativeGame
{
    public partial class highscoreScreen : UserControl
    {
       public static List<HighScore> scores = new List<HighScore>();       

        String Player;
        public highscoreScreen()
        {
          InitializeComponent();

            // highscoreReader();

            //create a code to display the times in a label

            // scores.Sort(score);
            outputLabel.Text = "";
            scoreLabel.Text = "";

            foreach (HighScore hs in scores)
            {
                // next step is to sort by time, would change to only show top 5
                outputLabel.Text = outputLabel.Text + "\n" + hs.name;
                scoreLabel.Text = scoreLabel.Text + "\n" + hs.score;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new TitleScreen());
        }
    }
}
