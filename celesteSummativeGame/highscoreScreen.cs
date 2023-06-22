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
        }

        public void highscoreReader()
        {
      // moved to form1

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new TitleScreen());
        }
    }
}
