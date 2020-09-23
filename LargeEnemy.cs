/*
 * Jason Kwan
 * 2019-12-13
 * Class for large enemies which is a subclass of enemy units
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalCannonGame
{
    class LargeEnemy : EnemyUnit
    {
        // store speed, hp, spawn point on the y-axis, and the length of the small unit
        private const int SLOW_SPEED = 3;
        private const int LARGE_HP = 200;
        private const int LOW_POINT = 550;
        private const int BIG_UNIT_LENGTH = 200;

        // constructor for large enemies
        public LargeEnemy()
        {
            // assign appropriate speed, health, beginning y-values, sizes, types, max unit health, enemy type, and image
            // for a large enemy
            unitHealth = LARGE_HP;
            maxUnitHealth = LARGE_HP;
            startingYPoint = LOW_POINT;
            unitSize = BIG_UNIT_LENGTH;
        }

        // constructor for recreating an already existing large enemy
        // loads in previous health of that enemy unit
        public LargeEnemy(int enemyUnitHealth)
        {
            // assign specific speed, health, beginning y-values, sizes, types, max unit health, enemy type, and image
            unitHealth = enemyUnitHealth;
            maxUnitHealth = LARGE_HP;
            startingYPoint = LOW_POINT;
            unitSize = BIG_UNIT_LENGTH;
        }

        // override method to move enemy boxes so it changes depending on the units speed
        public override void MoveEnemyBoxes()
        {
            // move every enemy and enemy health box at a slow speed
            enemyUnitBox.X -= SLOW_SPEED;
            enemyUnitHealthBox.X -= SLOW_SPEED;
        }

        // override method to draw the enemy with the correct enemy images
        protected override void DrawEnemyBoxes(PaintEventArgs e)
        {
            // create simple animation by changing what images show depending on the picture box's x coordinate
            // the folowing remainder calculations are set up so the animations occur in the correct order
            if (enemyUnitBox.X % 4 == 0)
            {
                e.Graphics.DrawImage(Properties.Resources.Koopas1, enemyUnitBox);
            }
            else if (enemyUnitBox.X % 4 == 1)
            {
                e.Graphics.DrawImage(Properties.Resources.Koopas2, enemyUnitBox);
            }
            else if (enemyUnitBox.X % 4 == 2)
            {
                e.Graphics.DrawImage(Properties.Resources.Koopas3, enemyUnitBox);
            }
            else if (enemyUnitBox.X % 4 == 3)
            {
                e.Graphics.DrawImage(Properties.Resources.Koopas2, enemyUnitBox);
            }
        }
    }
}
