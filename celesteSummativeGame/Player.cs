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
        public  int xSpeed = 8;
        public  int ySpeed = 8;
        public int width = 75;
        public int height = 75;
        bool isInAir;


       
        public Player(int _x, int _y, int _xSpeed, int _ySpeed)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed; 
        }

        public void Move(string direction)
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
                x -= xSpeed;
            }
            if (direction == "right")
            {
                x += xSpeed;
            }
            if (direction == "jump")
            {
                ySpeed = -25; // giving the charter a direction 
              // y += ySpeed;
            }

            if (direction == "airBoost") // multi directional boosting, all eight directions
            {
                if (GameScreen.upArrowDown)
                {
                    ySpeed = 0;
                    ySpeed -= 20;
                }
                else if (GameScreen.upArrowDown && GameScreen.leftArrowDown)
                {
                    ySpeed = 0;
                    ySpeed -= 20;
                    xSpeed -= 40;
                }
                else if (GameScreen.upArrowDown && GameScreen.rightArrowDown)
                {
                    ySpeed = 0;
                    ySpeed -= 20;
                    xSpeed += 40;
                }
                else if (GameScreen.downArrowDown)
                {
                    ySpeed = 0;
                    ySpeed += 20;
                }
                else if (GameScreen.downArrowDown && GameScreen.leftArrowDown)
                {
                    ySpeed = 0;
                    ySpeed += 20;
                    xSpeed -= 40;
                }
                else if (GameScreen.downArrowDown && GameScreen.rightArrowDown)
                {
                    ySpeed = 0;
                    ySpeed += 20;
                    xSpeed += 40;
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
