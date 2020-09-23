/*
 * Kevin Zhong
 * Cannon game
 * Nov 27 2019
 */
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace FinalCannonGame
{
    class Projectile
    {
        // a double variable created for radian
        protected double radian;

        // damage that each projectile will do
        public const int DAMAGE = 50;

        // start postion of cannon ball
        protected const int X_CANNON_BALL_SPAWN = 70;
        protected const int Y_CANNON_BALL_SPAWN = 310;

        // double variables for displacenment of cannon balls
        protected double xDisplacementDouble, yDisplacementDouble;

        // integer variables for displacement of cannon balls
        protected int xDisplacementInt, yDisplacementInt;

        // variable to save time
        protected double time;

        // intial velocity in horizontal and vertical
        protected double v0X, v0Y;

        // initial velocity in general
        protected int v0;

        // acceleration in y-axis due to the earth gravity
        protected const double GRAVITY = 0.25;

        // create a variable for the image
        protected Image image;

        // rectangle for cannonball
        protected RectangleF imageBox;

        // gets the imagebox
        public RectangleF GetImageBox
        {
            get
            {
                // return imagebox
                return imageBox;
            }
        }

        // gets the image 
        public Image GetImage
        {
            get
            {
                // return image
                return image;
            }
        }

        // calculate the horizontal and vertical displacenment
        public void MoveCannonBall()
        {
            // add the time to 0.1s
            time = time + 0.5;
            // initial velocity in x axis is cosine * radian
            v0X = v0 * Math.Cos(radian);
            // initial velocity in y-axis is sine * radian
            v0Y = v0 * Math.Sin(radian);
            // record the horizntal displacement
            xDisplacementDouble = v0X;
            // record the vertical displacement
            yDisplacementDouble = v0Y;
            // calculate for the displacement for y axis
            yDisplacementDouble = (v0Y * time + 0.5 * GRAVITY * Math.Pow(time, 2) + Y_CANNON_BALL_SPAWN);
            // calculate the displacement for x axis
            xDisplacementDouble = (v0X * time + 0.5 * GRAVITY * Math.Pow(time, 2) + X_CANNON_BALL_SPAWN);
            // convert horizontal displacement integer into double
            xDisplacementInt = (int)xDisplacementDouble;
            // covert  vertical displacement integer into double   
            yDisplacementInt = (int)yDisplacementDouble;
            // record the displacemnt for the cannonball in x axis
            imageBox.X = xDisplacementInt;
            // record the displacement for the cannon ball in y axis
            imageBox.Y = yDisplacementInt;
        }
        // draw the cannon ball
        public void Draw(PaintEventArgs e)
        {
            // draw the cannon ball
            e.Graphics.DrawImage(image, imageBox);
        }

        // check top boundary make sure the cannonball doesn't go out of the border
        private bool CheckTopBoundary()
        {
            // check if the image goes past the top of the screen
            if (imageBox.X < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // check bottom boundary make sure the cannonball doesn't go too out of the border
        private bool CheckBottomBoundary()
        {
            // check if the image goes a little past the bottom of the screen
            // this is required to make sure the right boundary works properly
            if (imageBox.X > 1200)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // check right boundary make sure the cannonball doesn't go too far out of the border
        private bool CheckRightBoundary()
        {
            // check if the image goes past the right side of the screen
            if (imageBox.X > 1600)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // check left boundary make sure the cannonball doesn't go too far out of the border
        private bool CheckLeftBoundary()
        {
            // check if the cannonball goes past the left border of the screen
            if (imageBox.X < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // check all the boundaries
        public bool CheckBoundary()
        {
            // check if the cannonball reaches any of the boundaries
            if (CheckLeftBoundary() == true || CheckRightBoundary() == true || CheckTopBoundary() == true || CheckBottomBoundary() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
