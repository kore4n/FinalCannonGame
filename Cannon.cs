/*
 * Kevin Zhong
 * Create a cannon game
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
    class Cannon
    {
        // a list for cannonball a player owns
        private List<Projectile> cannonBalls = new List<Projectile>();

        // the base health for the cannon
        private int health = 300;

        // store the enemy
        private EnemyPlayer enemyPlayerBot;

        // initial velocity in general
        private int v0;
        // constant created for initial velocity upgrade
        private const int INITIAL_VELOCITY_UPGRADE_THIRD = 30;
        // constant created for initial velocity upgrade
        private const int INITIAL_VELOCITY_UPGRADE_SECOND = 20;
        // constant for initial velocity
        private const int INITIAL_VELOCITY_FIRST = 10;

        // get the health of the cannon/castle left
        public int GetHealth
        {
            get
            {
                return health;
            }
        }
        // gets the list of cannon balls
        public List<Projectile> GetProjectileList
        {
            get
            {
                // return the list of cannonballs
                return cannonBalls; 
            }
        }

        // accessor and mutator for Cannon Health, return the Cannon's health and/or change it
        public int CannonHealthProperty
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }

        // set the player to have access to the number of player deaths
        public EnemyPlayer SetEnemyPlayer
        {
            set
            {
                enemyPlayerBot = value;
            }
        }

        // it is the cannon's responsibility to check if the player has won or lost
        // check if the player's health is equal to or less than 0
        public bool GameOver()
        {
            // if the health reachhes 0 game ends
            if (health <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // subprogram to draw the image of the cannon ball
        public void Draw(PaintEventArgs e)
        {
            // loop through all th cannon ball
            for (int i = 0; i < cannonBalls.Count; i++)
            {
                e.Graphics.DrawImage(cannonBalls[i].GetImage, cannonBalls[i].GetImageBox);
                // draw them out on the interface
                cannonBalls[i].Draw(e);
            }
        }

        /// <summary>
        /// constructor for spawning the cannon
        /// </summary>
        public Cannon()
        {
            // set initial velocity equals to 10
            v0 = INITIAL_VELOCITY_FIRST;
        }

        // makes different sized cannonballs
        public void CreateCannonBall(string cannonBallType, double radian)
        {
            // create a new cannonball
            Projectile cannonBall;
            // check if the cannon ball to be created is supposed to be large
            if (cannonBallType == "Large")
            {
                // create a large cannonball
                cannonBall = new LargeCannonBall(radian, v0);
            }
            // check if the cannon ball to be created is supposed to be normal sized
            else
            {
                // create a normal sized cannonball
                cannonBall = new NormalCannonBall(radian, v0);
            }
            // add the cannon ball to the cannon's list of cannonballs
            cannonBalls.Add(cannonBall);
        }

        // shoot the cannon to move the cannonballs
        private void Shoot()
        {
            // loop through the list of cannonballs
            for (int i = 0; i < cannonBalls.Count; i++)
            {
                // tell each cannonball to shoot
                cannonBalls[i].MoveCannonBall();
            }
        }

        // upgrade the cannonball's features depending on the amount of kills
        // the user gets
        private void SpeedUpgrades()
        {
            // check if the cannon gets 30 kills
            if (enemyPlayerBot.UnitsDefeatedProperty >= 30)
            {
                // increase the initial velocity to 30
                v0 = INITIAL_VELOCITY_UPGRADE_THIRD;
            }
            // check if the cannon kills 20 enemies
            else if (enemyPlayerBot.UnitsDefeatedProperty >= 20)
            {
                // increase the initial velocity to 10
                v0 = INITIAL_VELOCITY_UPGRADE_SECOND ;
            }
        }

        // check if the user has enough upgrades to make a huge cannonball
        public bool BigCannonBall()
        {
            // check if the number of kills is greater than 30
            if (enemyPlayerBot.UnitsDefeatedProperty >= 30)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // check if the cannonball must be removed from the game
        // and remove it if required
        private void CheckCannonBall()
        {
            // loop through every cannonball
            for (int i = 0; i < cannonBalls.Count(); i++)
            {
                // check if the cannonball reaches any border
                if (cannonBalls[i].CheckBoundary() == true)
                {
                    // remove the cannon ball from the list
                    cannonBalls.RemoveAt(i);
                }
            }
        }

        // make the cannon ready to fire and let the cannonballs move
        // encapsulate info
        public void RunCannon()
        {
            SpeedUpgrades();
            GameOver();
            Shoot();
            CheckCannonBall();
        }
    }
}