/*
 * Kevin Zhong
 * Dec 31 2019
 * Creating the child class for my cannon game
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FinalCannonGame
{
    class LargeCannonBall : Projectile
    {
        // create a constant for the large cannon ball
        private const int LARGE_CANNON_BALL_SIZE = 50;

        /// <summary>
        /// Constructor for making large cannon balls.
        /// </summary>
        /// <param name="radian"></param>
        /// <param name="v0"></param>
        public LargeCannonBall(double radian, int v0)
        {
            // set the raidan for the large cannonballs 
            this.radian = radian;
            // set the initial velocity for the normal size cannonball
            this.v0 = v0;

            //set the image of the cannonball
            image = Properties.Resources.cannonball;
            // set the image box for the cannon ball
            imageBox = new RectangleF(X_CANNON_BALL_SPAWN, Y_CANNON_BALL_SPAWN, LARGE_CANNON_BALL_SIZE, LARGE_CANNON_BALL_SIZE);
        }
    }
}
