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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            highscoreOnStart();
            ChangeScreen(this, new TitleScreen());   
        }

        public static void ChangeScreen(object sender, UserControl next)
        {
            Form f; // will either be the sender or parent of sender

            if (sender is Form)
            {
                f = (Form)sender;
            }
            else
            {
                UserControl current = (UserControl)sender;
                f = current.FindForm();
                f.Controls.Remove(current); // THIS LINE HAS ERROR
            }

            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,
                (f.ClientSize.Height - next.Height) / 2);

            f.Controls.Add(next);
            next.Focus();
        }

        // when programed closed, add all new highscores achived to the text file
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) //Highscores are currently getting added to the text file, overwritting pervious scores?

        {
            List<string> finalList = new List<string>();

            // Add all info from each HighScore object to temp list
            foreach (HighScore hs in highscoreScreen.scores)
            {
                finalList.Add(hs.name);
                finalList.Add(Convert.ToString(hs.score));
            }

            File.WriteAllLines("HighscoreList.txt", finalList);
        }

        public void highscoreOnStart()
        {
            // text file stores, highscores over multipal opens and closes/ at the moment doesnt display
            List<string> scoreList = File.ReadAllLines("HighscoreList.txt").ToList();

            for (int i = 0; i < scoreList.Count; i += 2)
            {
                string name = scoreList[i];
                int score = Convert.ToInt32(scoreList[i + 1]);

                HighScore hs = new HighScore(name, score);
                highscoreScreen.scores.Add(hs);
            }
        }
    }
}
