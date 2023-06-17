﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace celesteSummativeGame
{
    internal class Wall
    {
        public int x, y, width, height;


        public Wall(int _x, int _y, int _width, int _height)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
        }


        public bool Collision(Player p)
        {
            Rectangle wallRec = new Rectangle(x, y, width, height);
            Rectangle playerRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (wallRec.IntersectsWith(playerRec))
            {
                int newX = x + width;
                int newY = y + height;

                Rectangle topRec = new Rectangle(x, y, width, 20);
                Rectangle leftRec = new Rectangle(x, y, 1, height);
                Rectangle rightRec = new Rectangle(newX, y, 1, height);
                Rectangle bottomRec = new Rectangle(x, newY, width, 1);

                if (topRec.IntersectsWith(playerRec))
                {
                    p.y = y - p.height;
                    GameScreen.isInAir = false;

                }
                else if (leftRec.IntersectsWith(playerRec))
                {
                    p.x = x - p.width;
                    GameScreen.isInAir = true;
                    //   GameScreen.boostCounter = 1;

                }
                else if (rightRec.IntersectsWith(playerRec))
                {
                    p.x = newX;
                    GameScreen.isInAir = true;
                }
                else if (bottomRec.IntersectsWith(playerRec))
                {
                    p.y = newY;
                  GameScreen.isInAir = true;
                }

               return true;
            }
            return false;





        }
    }
}
