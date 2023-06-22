using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace celesteSummativeGame
{
    internal class Player
    {
        public  int x, y;
        public  double xSpeed = 8;
        public  double ySpeed = 8;
        public int width = 60;
        public int height = 60;
        bool isInAir;


       
        public Player(int _x, int _y, double _xSpeed, double _ySpeed)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed; 
        }

        public void Move(string direction) //checking which direction the player is moving, then moving the player properly
        {
            if (direction == "up")
            {
            // not needed, as jump was created
            }
            if (direction == "down")
            {
             // not needed, as jump was created
            }
            if (direction == "left")
            { 
                x -= (int)xSpeed;
            }
            if (direction == "right")
            {
                x += (int)xSpeed;
            }
            if (direction == "jump")
            {
                ySpeed = -30; // giving the charter a direction 
              // y += ySpeed;
            }

            if (direction == "airBoost") // multi directional boosting, all eight directions
            {
                if (GameScreen.upArrowDown)
                {
                    ySpeed = 0;
                    ySpeed -= 35;
                }
                else if (GameScreen.upArrowDown && GameScreen.leftArrowDown)
                {
                    ySpeed = 0;
                    ySpeed -= 35;
                    xSpeed -= 35;
                }
                else if (GameScreen.upArrowDown && GameScreen.rightArrowDown)
                {
                    ySpeed = 0;
                    ySpeed -= 35;
                    xSpeed += 35;
                }
                else if (GameScreen.downArrowDown)
                {
                    ySpeed = 0;
                    ySpeed += 35;
                }
                else if (GameScreen.downArrowDown && GameScreen.leftArrowDown)
                {
                    ySpeed = 0;
                    ySpeed += 35;
                    xSpeed -= 35;
                }
                else if (GameScreen.downArrowDown && GameScreen.rightArrowDown)
                {
                    ySpeed = 0;
                    ySpeed += 35;
                    xSpeed += 35;
                }
                //else if (GameScreen.leftArrowDown)
                //{
                //    xSpeed = 0;
                //    xSpeed += 15;
                //}
                //else if (GameScreen.rightArrowDown)
                //{
                //    xSpeed = 0;
                //    xSpeed += 15;
                //}

            }

        }     
    }
}
