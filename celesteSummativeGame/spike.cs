using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace celesteSummativeGame
{
    internal class spike
    {
        public int x, y, width, height;

        public spike(int _x, int _y, int _width, int _height) // creating a build for the spikes
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
        }

        public bool Collision(Player p)
        {
            Rectangle spikeRec = new Rectangle(x, y, width, height);
            Rectangle playerRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (spikeRec.IntersectsWith(playerRec)) //checking if the player has interacted with the spike
            {

                return true;
            }
            return false;





        }
    }



}

