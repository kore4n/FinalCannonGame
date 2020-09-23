/*
 * Jason Kwan
 * 2019-11-13
 * Class of enemy units and their information including their
 * speed, health, max health, sizes, types, etc...
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
    abstract class EnemyUnit
    {
        // create enemy unit health, max health, starting point regarding the y-axis,
        // size of the unit, damage taken in an instance, and the type of enemy
        protected int unitHealth;
        protected int maxUnitHealth;
        protected int startingYPoint;
        protected int unitSize;
        protected string unitType;

        // create the rectangleF for the enemy unit
        protected RectangleF enemyUnitBox;
        // create the rectangleF for the enemy unit's health bar
        protected RectangleF enemyUnitHealthBox;

        // store the spawning x-value of enemies
        public const int X_SPAWN_LOCATION = 1200;

        // distance between enemy health bar and enemy it belongs to
        public const int Y_DIFFERENCE = 100;

        // store small, medium, and large types of enemies
        public const string SMALL_ENEMY = "Small Enemy";
        public const string MEDIUM_ENEMY = "Medium Enemy";
        public const string LARGE_ENEMY = "Large Enemy";

        // accessor and mutator for unitHealth, return the unit's health and/or change it
        public int UnitHealthProperty
        {
            get
            {
                return unitHealth;
            }
            set
            {
                unitHealth = value;
            }
        }

        // get the unitsize
        public int GetUnitSize
        {
            get
            {
                return unitSize;
            }
        }

        // get the enemy unit's unitbox
        public RectangleF GetEnemyUnitBox
        {
            get
            {
                return enemyUnitBox;
            }
        }

        // accessor for unit's type
        public string GetUnitType
        {
            get
            {
                return unitType;
            }
        }

        // check if the enemy is dead
        public bool CheckEnemyDeath()
        {
            // check if the enemy's health is less than or equal to 0
            if (unitHealth <= 0)
            {
                // return true if enemy should be dead
                return true;
            }
            // otherwise if the enemy is alive, return false
            else
            {
                return false;
            }
        }

        // draw enemy boxes
        protected abstract void DrawEnemyBoxes(PaintEventArgs e);

        // draw enemy health boxes
        private void DrawEnemyHealthBoxes(PaintEventArgs e)
        {
            // only draw the enemy health boxes if the enemy has less than max health
            if (unitHealth < maxUnitHealth)
            {
                // change the colour of the health bar depending on the health remaining
                if (unitHealth <= maxUnitHealth / 2)
                {
                    // change box dimensions
                    enemyUnitHealthBox = new RectangleF(enemyUnitHealthBox.X, startingYPoint - Y_DIFFERENCE, unitHealth, unitSize / 3);
                    // make the pen red
                    SolidBrush pen = new SolidBrush(Color.Red);
                    // fill the enemy's health bar with the custom colour
                    e.Graphics.FillRectangle(pen, enemyUnitHealthBox);
                }
                // if the health remaining isnt less than or equal to half
                // the max health, run the following code
                else
                {
                    // change box dimensions
                    enemyUnitHealthBox = new RectangleF(enemyUnitHealthBox.X, startingYPoint - Y_DIFFERENCE, unitHealth, unitSize / 3);
                    // make the pen green
                    SolidBrush pen = new SolidBrush(Color.Green);
                    // fill the enemy's health bar with the custom colour
                    e.Graphics.FillRectangle(pen, enemyUnitHealthBox);
                }
            }
        }

        // draw everything
        public void DrawAll(PaintEventArgs e)
        {
            DrawEnemyBoxes(e);
            DrawEnemyHealthBoxes(e);
        }

        // accessor and mutator for and returns the enemy's unit box
        public RectangleF EnemyUnitBoxProperty
        {
            get
            {
                return enemyUnitBox;
            }
            set
            {
                enemyUnitBox = value;
            }
        }

        // accessor for and returns the enemy's health's unit box
        public RectangleF GetEnemyUnitHealthBox
        {
            get
            {
                return enemyUnitHealthBox;
            }
        }

        // create an enemy unit's boxes and give them their locations
        public void SpawnEnemy(string unitType)
        {
            // set the unit type
            this.unitType = unitType;
            // create dimensions of the enemy unit box
            enemyUnitBox = new RectangleF(X_SPAWN_LOCATION, startingYPoint, unitSize, unitSize);
            // create dimensions of the enemy unit's health box
            enemyUnitHealthBox = new RectangleF(X_SPAWN_LOCATION, startingYPoint - Y_DIFFERENCE, unitSize, unitSize / 3); // divide the health bar height by 3
        }

        // give the enemy unit specific values
        public void LoadEnemy(string unitType, int enemyUnitHealth, int enemyUnitBoxX, int enemyUnitHealthBoxY)
        {
            // set the unit type
            this.unitType = unitType;
            // create dimensions of the enemy unit's box
            enemyUnitBox = new RectangleF(enemyUnitBoxX, startingYPoint, unitSize, unitSize);
            // create dimensions of the enemy unit's health box
            enemyUnitHealthBox = new RectangleF(enemyUnitBoxX, enemyUnitHealthBoxY, unitSize, unitSize / 3); // divide the health bar height by 3
        }

        // move enemy boxes to the left
        public abstract void MoveEnemyBoxes();
    }
}
