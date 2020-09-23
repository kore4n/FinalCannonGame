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
    class NormalCannonBall : Projectile
    {
        // create a constant for the cannon ball size
        private const int CANNON_BALL_SIZE = 20;

        /// <summary>
        /// a constructor for normal size cannonballs
        /// </summary>
        /// <param name="radian"></param>
        /// <param name="v0"></param>
        public NormalCannonBall(double radian, int v0)
        {
            // set the radian for the normal cannonballs
            this.radian = radian;
            // set the initial velocity for the normal size cannonball
            this.v0 = v0;
            // set the image of the cannonball
            image = Properties.Resources.cannonball;
            // set the image box for the cannon ball
            imageBox = new RectangleF(X_CANNON_BALL_SPAWN, Y_CANNON_BALL_SPAWN, CANNON_BALL_SIZE, CANNON_BALL_SIZE);
        }
    }
}
