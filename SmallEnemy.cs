/*
 * Jason Kwan
 * 2019-12-13
 * Class for small enemies which is a subclass of enemy units
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalCannonGame
{
    class SmallEnemy : EnemyUnit
    {
        // store speed, hp, spawn point on the y-axis, and the length of the small unit
        private const int FAST_SPEED = 7;
        private const int SMALL_HP = 100;
        private const int HIGH_POINT = 200;
        private const int SMALL_UNIT_LENGTH = 50;

        // constructor for small enemies
        public SmallEnemy()
        {
            // assign appropriate speed, health, beginning y-values, sizes, types, max unit health, enemy type, and image
            // for a small enemy
            unitHealth = SMALL_HP;
            maxUnitHealth = SMALL_HP;
            startingYPoint = HIGH_POINT;
            unitSize = SMALL_UNIT_LENGTH;
        }

        // constructor for recreating an already existing enemy
        // loads in previous health of that enemy unit
        public SmallEnemy(int enemyUnitHealth)
        {
            // assign appropriate speed, health, beginning y-values, sizes, types, max unit health, enemy type, and image
            // for a small enemy
            unitHealth = enemyUnitHealth;
            maxUnitHealth = SMALL_HP;
            startingYPoint = HIGH_POINT;
            unitSize = SMALL_UNIT_LENGTH;
        }

        // override method to move enemy boxes so it changes depending on the units speed
        public override void MoveEnemyBoxes()
        {
            // move every enemy and enemy health box at a fast speed
            enemyUnitBox.X -= FAST_SPEED;
            enemyUnitHealthBox.X -= FAST_SPEED;
        }

        // override method to draw the enemy with the correct enemy image
        protected override void DrawEnemyBoxes(PaintEventArgs e)
        {
            // create simple animation by changing what images show depending on the picture box's x coordinate
            // the folowing remainder calculations are set up so the animations occur in the correct order
            if (enemyUnitBox.X % 4 == 0)
            {
                e.Graphics.DrawImage(Properties.Resources.BobOmb1, enemyUnitBox);
            }
            else if (enemyUnitBox.X % 4 == 1)
            {
                e.Graphics.DrawImage(Properties.Resources.BobOmb2, enemyUnitBox);
            }
            else if (enemyUnitBox.X % 4 == 2)
            {
                e.Graphics.DrawImage(Properties.Resources.BobOmb3, enemyUnitBox);
            }
            else if (enemyUnitBox.X % 4 == 3)
            {
                e.Graphics.DrawImage(Properties.Resources.BobOmb2, enemyUnitBox);
            }
        }
    }
}
