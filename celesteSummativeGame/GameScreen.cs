using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace celesteSummativeGame
{
    public partial class GameScreen : UserControl
    {
        List<Wall> walls = new List<Wall>();
        List<spike> spikes = new List<spike>();

        SolidBrush greenBrush = new SolidBrush(Color.LightGreen); //creating brushes to paint with
        SolidBrush blueBrush = new SolidBrush(Color.LightBlue);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush greyBrush = new SolidBrush(Color.DarkGray);
        SolidBrush darkBlueBrush = new SolidBrush(Color.DarkBlue);
        SolidBrush pinkBrush = new SolidBrush(Color.Pink);


        public static Boolean leftArrowDown, rightArrowDown, upArrowDown, downArrowDown, xKeyDown, cKeyDown; // getting key presses for movements

        Player madeline; //Creating a charecter 

        public static bool isInAir; // bool to see if the charceter is in the air

        double gravity; // gravity to force the player down to the ground

        public static int boostCounter = 0;

        public static int deathCounter;

        Wall bottomWall,leftWall, rightWall, topWall, plat1, plat2, plat3, plat4, plat5, plat6;

        spike spike1, spike2;

        Rectangle winZone = new Rectangle(1200, 0, 300, 50);

       public static Stopwatch myWatch = new Stopwatch();

        public GameScreen()
        {  
            InitializeComponent();
            InitalizeGame();
        }

        private void GameEngine_Tick(object sender, EventArgs e)
        {
            Rectangle madelineRect = new Rectangle(madeline.x, madeline.y, madeline.width, madeline.height);
            
            if (upArrowDown && isInAir) //these are used to read what key is pressed
            {
                madeline.Move("up");
            }
            if (downArrowDown)
            {
                madeline.Move("down");
            }
            if (leftArrowDown && madeline.x > 0)
            {
                madeline.Move("left");
            }
            if (rightArrowDown && madeline.x < this.Width - madeline.width)
            {
                madeline.Move("right");
            }
            if (cKeyDown && !isInAir)
            {
                madeline.Move("jump");
            }
            if (xKeyDown)
            {
                if (isInAir && boostCounter < 1)
                {
                    boostCounter++;
                    madeline.Move("airBoost");
                }
                else
                {
                    madeline.Move("groundBoost");
                }
            }

            madeline.y += (int)madeline.ySpeed; //players y postion is added to by tshe y speed

            madelineRect = new Rectangle(madeline.x, madeline.y, madeline.width, madeline.height);

            //Old code
            #region

            // if (!madelineRect.IntersectsWith(floor)) // fix the floor
            // {
            //     isInAir = true;
            //     gravity = 1; // setting the force of gravity
            //     madeline.ySpeed += gravity; // ySpeed is be taking down by the force of gravity 
            // }
            //// if (madelineRect.IntersectsWith(floor))
            //else
            // {
            //     gravity = 0; // setting gravity to nothing
            //     isInAir = false;
            //     boostCounter = 0;
            //     madeline.y = floor.Y - 49;
            //     madeline.ySpeed = 0;
            //     madeline.xSpeed = 8;
            // }

            #endregion //Old Code

            // Creating code to have the player interact with the level walls

            foreach (Wall w in walls)
            {
                if (!w.Collision(madeline))
                {
                    isInAir = true;
                    gravity = 0.2; // setting the force of gravity
                    madeline.ySpeed += gravity; // ySpeed is be taking down by the force of gravity 

                   // break;
                }
                else
                {
                    if(isInAir == false)
                    {
                       boostCounter = 0;
                    }
                    gravity = 0; // setting gravity to nothing
                   // isInAir = false;
                   // boostCounter = 0;
                   // madeline.y = w.y - madeline.height;
                    madeline.ySpeed = 0;
                    madeline.xSpeed = 12;
                    break;
                }
            }

            //Reseting player to start when hitting a spike
            foreach (spike s in spikes)
            {
                if (s.Collision(madeline))
                {
                  //  deathCounter++;
                    madeline.x = 25;
                    madeline.y = 1200;
                    break;
                }
            }
            madelineRect = new Rectangle(madeline.x, madeline.y, madeline.width, madeline.height); //updating rectangle


            // Creating the end region
            if(winZone.IntersectsWith(madelineRect))
            {
                myWatch.Stop();
                GameEngine.Stop();
                Form1.ChangeScreen(this, new EndScreen());
            }
                Refresh();        
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(greenBrush, winZone); //drawing the win zone

             e.Graphics.FillRectangle(pinkBrush, madeline.x, madeline.y, madeline.width, madeline.height);
            //  e.Graphics.DrawImageUnscaled(Properties.Resources.spritePicture2, madeline.x, madeline.y, madeline.width, madeline.height);

            if (boostCounter > 0)
            {
                e.Graphics.FillRectangle(blueBrush, madeline.x, madeline.y, madeline.width, madeline.height);
            }

            foreach (Wall w in walls)
            {
                e.Graphics.FillRectangle(darkBlueBrush , w.x, w.y, w.width, w.height);
              //  e.Graphics.DrawImage(Properties.Resources.iceCave,w.x, w.y, w.height,w.width);

            }
            
            foreach (spike s in spikes)
            {
                e.Graphics.FillRectangle(greyBrush, s.x, s.y, s.width, s.height);
                 //e.Graphics.DrawImage(Properties.Resources.spikePng,s.x, s.y, s.height,s.width);

            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;

                case Keys.Right:
                    rightArrowDown = true;
                    break;

                case Keys.Up:
                    upArrowDown = true;
                    break;

                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.C:
                    cKeyDown = true;
                    break;
                case Keys.X:
                    xKeyDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;

                case Keys.Right:
                    rightArrowDown = false;
                    break;

                case Keys.Up:
                    upArrowDown = false;
                    break;

                case Keys.Down:
                    downArrowDown = false;
                    break;

                case Keys.C:
                    cKeyDown = false;
                    break;

                case Keys.X:
                    xKeyDown = false;
                    break;
            }

        }
        public void InitalizeGame()
        {
            myWatch.Reset();

            madeline = new Player(25,1200, 15, 1);
            GameEngine.Enabled = true;

            // Creating the platforms 
            #region
            bottomWall = new Wall(0, 1350, 1400, 50);
            leftWall= new Wall(0, 0, 100, 900);// temp floor
            rightWall = new Wall(1350, 0, 100, 1400);
            topWall = new Wall(0, 0, 1200, 50);

            plat1 = new Wall(0, 1250, 300, 100);
            plat2 = new Wall(300, 1150, 100, 200);
            plat3 = new Wall(650, 1100, 150, 250);
            plat4 = new Wall(1210, 900, 190, 40);
            plat5 = new Wall(550, 650, 190, 40);
            plat6 = new Wall(1150, 350, 500, 80);

            walls.Add(bottomWall);
            walls.Add(leftWall);
            walls.Add(rightWall);
            walls.Add(topWall);

            walls.Add(plat1);
            walls.Add(plat2);
            walls.Add(plat3);
            walls.Add(plat4);
            walls.Add(plat5);
            walls.Add(plat6);

            #endregion

            // Creating the spikes

            spike1 = new spike(400,1300, 250, 50);

            spike2 = new spike(800, 1300, 550, 50);

            spikes.Add(spike1);
            spikes.Add(spike2);

            myWatch.Start(); //starting a stop watch



        }

    }
}
