using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace celesteSummativeGame
{
    public partial class GameScreen : UserControl
    {
        List<Wall> walls = new List<Wall>();    

        SolidBrush greenBrush = new SolidBrush(Color.Green); //creating brushes to paint with
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush redBrush = new SolidBrush(Color.Red);


        public static Boolean leftArrowDown, rightArrowDown, upArrowDown, downArrowDown, xKeyDown, cKeyDown; // getting key presses for movements

        Player madeline; //Creating a charecter 

      public static bool isInAir; // bool to see if the charceter is in the air

        int gravity; // gravity to force the player down to the ground

      public static int boostCounter = 0;

        Wall floor, plat1,leftWall, rightWall, topWall;
     


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

            madeline.y += madeline.ySpeed; //players y postion is added to by tshe y speed

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

            foreach (Wall w in walls)
            {
                if (!w.Collision(madeline))
                {
                    isInAir = true;
                    gravity = 1; // setting the force of gravity
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
                    madeline.xSpeed = 8;
                    break;
                }
            }

            Refresh();        
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.FillRectangle(greenBrush, madeline.x, madeline.y, madeline.width, madeline.height);
           
            if(boostCounter > 0)
            {
                e.Graphics.FillRectangle(blueBrush, madeline.x, madeline.y, madeline.width, madeline.height);
            }

            foreach (Wall w in walls)
            {
             e.Graphics.FillRectangle(redBrush, w.x, w.y, w.width, w.height);   
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
            madeline = new Player(25,1200, 12, 1);
            GameEngine.Enabled = true;
            plat1 = new Wall(500, 1200, 300, 300);
            floor = new Wall(0, 1350, 400, 50);
            leftWall= new Wall(0, 0, 150, 1050);// temp floor
            rightWall = new Wall(1300, 0, 100, 1400);
            walls.Add(plat1);
            walls.Add(floor);
            walls.Add(leftWall);
            walls.Add(floor);
            walls.Add(rightWall);

        }

    }
}
