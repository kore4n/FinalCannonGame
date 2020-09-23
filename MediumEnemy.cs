/*
 * Jason Kwan
 * 2019-12-13
 * Class for medium enemies which is a subclass of enemy units
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalCannonGame
{
    class MediumEnemy : EnemyUnit
    {
        // store speed, hp, spawn point on the y-axis, and the length of the small unit
        private const int MEDIUM_SPEED = 5;
        private const int MEDIUM_HP = 150;
        private const int MEDIUM_POINT = 400;
        private const int MEDIUM_UNIT_LENGTH = 100;

        // constructor for medium enemies
        public MediumEnemy()
        {
            // assign appropriate speed, health, beginning y-values, sizes, types, max unit health, enemy type, and image
            // for a medium enemy
            unitHealth = MEDIUM_HP;
            maxUnitHealth = MEDIUM_HP;
            startingYPoint = MEDIUM_POINT;
            unitSize = MEDIUM_UNIT_LENGTH;
        }

        // constructor for recreating an already existing medium enemy
        // loads in previous health of that enemy unit
        public MediumEnemy(int enemyUnitHealth)
        {
            // assign appropriate speed, health, beginning y-values, sizes, types, max unit health, enemy type, and image
            // for a medium enemy
            unitHealth = enemyUnitHealth;
            maxUnitHealth = MEDIUM_HP;
            startingYPoint = MEDIUM_POINT;
            unitSize = MEDIUM_UNIT_LENGTH;
        }

        // override method to move enemy boxes so it changes depending on the units speed
        public override void MoveEnemyBoxes()
        {
            // move every enemy and enemy health box at a medium speed
            enemyUnitBox.X -= MEDIUM_SPEED;
            enemyUnitHealthBox.X -= MEDIUM_SPEED;
        }

        // override method to draw the enemy with the correct enemy image
        protected override void DrawEnemyBoxes(PaintEventArgs e)
        {
            // create simple animation by changing what images show depending on the picture box's x coordinate
            // the folowing remainder calculations are set up so the animations occur in the correct order
            if (enemyUnitBox.X % 4 == 0)
            {
                e.Graphics.DrawImage(Properties.Resources.Kamek1, enemyUnitBox);
            }
            else if (enemyUnitBox.X % 4 == 3)
            {
                e.Graphics.DrawImage(Properties.Resources.Kamek2, enemyUnitBox);
            }
            else if (enemyUnitBox.X % 4 == 2)
            {
                e.Graphics.DrawImage(Properties.Resources.Kamek3, enemyUnitBox);
            }
            else if (enemyUnitBox.X % 4 == 1)
            {
                e.Graphics.DrawImage(Properties.Resources.Kamek2, enemyUnitBox);
            }
        }
    }
}
