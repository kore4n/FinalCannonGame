/*
 * Jason Kwan
 * 2019-11-13
 * Class to store the enemy player, list of enemy units, and
 * subprograms to create different types of enemies
 */

using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace FinalCannonGame
{
    class EnemyPlayer
    {
        // create different thresholds or amounts of enemies that have been defeated
        private const int EASY_REQUIRED_KILLCOUNT = 10;
        private const int HARD_REQUIRED_KILLCOUNT = 50;
        private const int VERY_HARD_REQUIRED_KILLCOUNT = 100;

        // store the spawnrate percentage chances for enemies every time the timer runs
        // can't be more than 100
        private const int EASY_SPAWNRATE_PERCENTAGE = 3;
        private const int HARD_SPAWNRATE_PERCENTAGE = 10;
        private const int VERY_HARD_SPAWNRATE_PERCENTAGE = 15;

        // create a list of enemy units for the enemy player
        private List<EnemyUnit> enemyUnits = new List<EnemyUnit>();

        // store the cannon
        private Cannon c1;

        // this is the amount of enemies that the enemy player has remaining
        // when this amount reaches 0, the player wins
        private int amountOfEnemiesRemaining = 100;

        // track the number of units that are beaten
        // does NOT include enemies that have gotten to the tower
        // that the player was unable to kill
        private int unitsDefeated;

        // store small, medium, and large types of enemies
        // large constant is never used as else state is used instead
        private const int SMALL_ENEMY = 0;
        private const int MEDIUM_ENEMY = 1;
        private const int MAX_ENEMY_TYPES_PLUS_ONE = 3;

        // get the number of units defeated
        public int UnitsDefeatedProperty
        {
            get
            {
                return unitsDefeated;
            }
            set
            {
                unitsDefeated = value;
            }
        }

        // get the cannon
        public Cannon SetCannon
        {
            set
            {
                c1 = value;
            }
        }

        // get the amount of enemies remaining
        public int GetEnemiesRemaining
        {
            get
            {
                return amountOfEnemiesRemaining;
            }
        }

        // Create an enemy of a specific type.
        private void CreateEnemy(string unitType)
        {
            // create a new enemy unit
            EnemyUnit enemyUnit;
            // check the unit type
            if (unitType == EnemyUnit.LARGE_ENEMY)
            {
                // create a large enemy unit
                enemyUnit = new LargeEnemy();
            }
            else if (unitType == EnemyUnit.MEDIUM_ENEMY)
            {
                // create a medium enemy
                enemyUnit = new MediumEnemy();
            }
            else
            {
                // create a small enemy
                enemyUnit = new SmallEnemy();
            }
            // setup the unit boxes in the default location
            enemyUnit.SpawnEnemy(unitType);
            // add it to the list
            enemyUnits.Add(enemyUnit);
            // calculate the amount of enemies remaining
            amountOfEnemiesRemaining -= 1;
        }

        // Create an enemy given recorded information
        private void CreateSpecificEnemy(string unitType, int enemyUnitHealth, int enemyUnitBoxX, int enemyUnitHealthBoxY)
        {
            // create a new enemy unit
            EnemyUnit enemyUnit;
            // check the unit type
            if (unitType == EnemyUnit.LARGE_ENEMY)
            {
                // create a large enemy unit
                enemyUnit = new LargeEnemy();
            }
            else if (unitType == EnemyUnit.MEDIUM_ENEMY)
            {
                // create a medium enemy
                enemyUnit = new MediumEnemy();
            }
            else
            {
                // create a small enemy
                enemyUnit = new SmallEnemy();
            }
            // load the enemy boxes into specific locations
            enemyUnit.LoadEnemy(unitType, enemyUnitHealth, enemyUnitBoxX, enemyUnitHealthBoxY);
            // add it to the list
            enemyUnits.Add(enemyUnit);
            // calculate the amount of enemies remaining
            amountOfEnemiesRemaining -= 1;
        }
        
        // check if the enemy intersects with a cannon/the tower
        private void EnemyIntersect()
        {
            // loop through every enemy box
            for (int i = 0; i < enemyUnits.Count; i++)
            {
                // loop through every cannonball
                for (int k = 0; k < c1.GetProjectileList.Count(); k++)
                {
                    // check if the enemy touches with a cannonball
                    if (enemyUnits[i].EnemyUnitBoxProperty.IntersectsWith(c1.GetProjectileList[k].GetImageBox))
                    {
                        // check if the enemy is able to be pushed back
                        if (KnockBack() == true)
                        {
                            // replace the enemy box with another box with the same dimensions that is 20 pixels to the right
                            // (there was no other way to move the rectangleF back)
                            enemyUnits[i].EnemyUnitBoxProperty = new RectangleF (enemyUnits[i].EnemyUnitBoxProperty.X + 20, enemyUnits[i].EnemyUnitBoxProperty.Y, enemyUnits[i].EnemyUnitBoxProperty.Width, enemyUnits[i].EnemyUnitBoxProperty.Height);
                        }
                        // subtract enemy health by the damage of a cannon's projectile
                        enemyUnits[i].UnitHealthProperty -= Projectile.DAMAGE;
                        // remove the cannonball from the list
                        c1.GetProjectileList.RemoveAt(k);
                    }
                }

                // check if the enemy touches the tower
                if (enemyUnits[i].EnemyUnitBoxProperty.X <= 0 - enemyUnits[i].GetUnitSize)
                {
                    // subtract the value of the enemy unit's remaining health from the health of the cannon
                    c1.CannonHealthProperty -= enemyUnits[i].UnitHealthProperty;
                    // remove the enemy unit that touches the cannonball
                    enemyUnits.RemoveAt(i);
                }
            }
        }

        // check if the cannon should be able to push back the enemy
        private bool KnockBack()
        {
            // check if the enemy player has had enough of its units killed for the user to get the "knockback" upgrade
            if (unitsDefeated >= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // remove the enemy that dies when their health gets too low
        private void BuryTheDead()
        {
            // loop through all enemies
            for (int i = 0; i < enemyUnits.Count; i++)
            {
                // check if the enemy health is equal to or less than 0
                if (enemyUnits[i].CheckEnemyDeath() == true)
                {
                    // remove the enemy unit that touches the cannonball
                    enemyUnits.RemoveAt(i);
                    // add 1 to the enemy player's # enemies killed
                    unitsDefeated += 1;
                }
            }
        }

        // it is the enemy player's responsibility to check if they have lost
        // check if the enemy player has run out of enemies to send
        // if this is the case, the user wins
        public bool PlayerWin()
        {
            // check if the number of enemies remaining is less than or equal to 0
            // and if the amount of enemies left on the screen is 0
            if (amountOfEnemiesRemaining == 0 && enemyUnits.Count() == 0)
            {
                // if true, return true so the player wins
                return true;
            }
            else
            {
                // if false, return true so the player wins
                return false;
            }
        }

        // move the enemy
        private void MoveEveryEnemy()
        {
            // loop through list
            for (int i = 0; i < enemyUnits.Count; i++)
            {
                // move the enemy to the left
                enemyUnits[i].MoveEnemyBoxes();
            }
        }

        // draw all required rectangles
        public void Draw(PaintEventArgs e)
        {
            // loop through all enemy units
            for (int i = 0; i < enemyUnits.Count; i++)
            {
                // draw enemy units and their health bars
                enemyUnits[i].DrawAll(e);
            }
        }

        // generate an enemy type
        private void GenerateEnemyType()
        {
            // random number generator for randomizing rates for units spawn times
            Random random = new Random();

            // generate a random number between 0 and 2
            int unitType = random.Next(0, MAX_ENEMY_TYPES_PLUS_ONE);

            // randomize the rate between units spawning
            // make a random number between 0 and 100
            int randomNumber = random.Next(0, 100);

            // check if the amount of enemies remaining is greater than 0
            // the amount of enemies left will not be subtracted from if there are no enemies left to spawn
            if (amountOfEnemiesRemaining > 0)
            {
                // check if the number of defeated bots is less than 10
                if (unitsDefeated < EASY_REQUIRED_KILLCOUNT)
                {
                    // units spawn 3% of the time
                    if (randomNumber < EASY_SPAWNRATE_PERCENTAGE)
                    {
                        // if unit type is zero, spawn a small enemy
                        if (unitType == SMALL_ENEMY)
                        {
                            CreateEnemy(EnemyUnit.SMALL_ENEMY);
                        }
                        // if unit type is 1, spawn a medium enemy
                        else if (unitType == MEDIUM_ENEMY)
                        {
                            CreateEnemy(EnemyUnit.MEDIUM_ENEMY);
                        }
                        // otherwise spawn a large enemy
                        else
                        {
                            CreateEnemy(EnemyUnit.LARGE_ENEMY);
                        }
                    }
                }
                // units spawn 20% of the time
                else if (unitsDefeated < HARD_REQUIRED_KILLCOUNT)
                {
                    // increase the rate that the enemies spawn at
                    if (randomNumber < HARD_SPAWNRATE_PERCENTAGE)
                    {
                        // if unit type is zero, spawn a small enemy
                        if (unitType == SMALL_ENEMY)
                        {
                            CreateEnemy(EnemyUnit.SMALL_ENEMY);
                        }
                        // if unit type is 1, spawn a medium enemy
                        else if (unitType == MEDIUM_ENEMY)
                        {
                            CreateEnemy(EnemyUnit.MEDIUM_ENEMY);
                        }
                        // otherwise spawn a large enemy
                        else
                        {
                            CreateEnemy(EnemyUnit.LARGE_ENEMY);
                        }
                    }
                }
                // units spawn 100% of the time
                else
                {
                    // increase the rate that the enemies spawn at
                    if (randomNumber < VERY_HARD_SPAWNRATE_PERCENTAGE)
                    {
                        // if unit type is zero, spawn a small enemy
                        if (unitType == SMALL_ENEMY)
                        {
                            CreateEnemy(EnemyUnit.SMALL_ENEMY);
                        }
                        // if unit type is 1, spawn a medium enemy
                        else if (unitType == MEDIUM_ENEMY)
                        {
                            CreateEnemy(EnemyUnit.MEDIUM_ENEMY);
                        }
                        // otherwise spawn a large enemy
                        else
                        {
                            CreateEnemy(EnemyUnit.LARGE_ENEMY);
                        }
                    }
                }
            }
        }

        // makes sure everything relating to enemies is active
        public void ActiveEnemy()
        {
            // make an enemy type
            GenerateEnemyType();
            // check if units/tower should be hurt
            EnemyIntersect();
            // remove units that are dead
            BuryTheDead();
            // move all enemies to the left
            MoveEveryEnemy();
        }

        // load in the enemy's info
        private void LoadEnemyInfo()
        {
            // prevent the user from using the wrong file
            try
            {
                // create a new object that has the enemy's info
                using (StreamReader file = new StreamReader("enemyinfo.txt"))
                {
                    // check if there is any info ahead
                    while (file.Peek() != -1)
                    {
                        string fileLine = file.ReadLine();
                        // check the enemy unit type
                        if (fileLine == EnemyUnit.SMALL_ENEMY)
                        {
                            // make a small enemy
                            CreateSpecificEnemy(EnemyUnit.SMALL_ENEMY, int.Parse(file.ReadLine()), int.Parse(file.ReadLine()), int.Parse(file.ReadLine()));
                        }
                        else if (fileLine == EnemyUnit.MEDIUM_ENEMY)
                        {
                            // make a medium enemy
                            CreateSpecificEnemy(EnemyUnit.MEDIUM_ENEMY, int.Parse(file.ReadLine()), int.Parse(file.ReadLine()), int.Parse(file.ReadLine()));
                        }
                        else if (fileLine == EnemyUnit.LARGE_ENEMY)
                        {
                            // make a large enemy
                            CreateSpecificEnemy(EnemyUnit.LARGE_ENEMY, int.Parse(file.ReadLine()), int.Parse(file.ReadLine()), int.Parse(file.ReadLine()));
                        }
                    }
                }
            }
            // display a message if the correct file is not found
            catch
            {
                // show an error message
                MessageBox.Show("Enemy info could not be loaded.");
            }
        }

        // save the enemy's info
        private void SaveEnemyInfo()
        {
            // prevent the user from using the wrong file
            try
            {
                // create a new object that has the enemy's info
                using (StreamWriter file = new StreamWriter("enemyinfo.txt"))
                {
                    // loop through all enemy units
                    for (int i = 0; i < enemyUnits.Count(); i++)
                    {
                        // write out the enemy's info in the following format
                        // unit type (holds speed, max health, size, and y point which are constant for each type)
                        // unit health
                        // unit x point
                        // unit health box x location
                        // unit health box y location
                        file.WriteLine(enemyUnits[i].GetUnitType);
                        file.WriteLine(enemyUnits[i].UnitHealthProperty);
                        file.WriteLine(enemyUnits[i].EnemyUnitBoxProperty.X);
                        file.WriteLine(enemyUnits[i].GetEnemyUnitHealthBox.Y);
                    }
                }
            }
            // display a message if the correct file is not found
            catch
            {
                // show an error message
                MessageBox.Show("Enemy info could not be saved");
            }
        }

        // load the enemy's number of deaths
        private void LoadDeaths()
        {
            // prevent the user from using the wrong file
            try
            {
                // create a new object that stores the number of enemy deaths
                using (StreamReader file = new StreamReader("deaths.txt"))
                {
                    // read the number of units that have been defeated
                    unitsDefeated = int.Parse(file.ReadLine());
                }
            }
            // display a message if the correct file is not found
            catch
            {
                // show an error message
                MessageBox.Show("No save file could be loaded");
            }
        }

        // save the amount of enemies that have died
        private void SaveDeaths()
        {
            // prevent the user from using the wrong file
            try
            {
                // create a new object that stores the number of enemy deaths
                using (StreamWriter file = new StreamWriter("deaths.txt"))
                {
                    // read the number of units that have been defeated
                    file.WriteLine(unitsDefeated);
                }
            }
            // display a message if the correct file is not found
            catch
            {
                // show an error message
                MessageBox.Show("Number of enemy deaths could not be saved");
            }
        }

        // delete save
        public void DeleteSave()
        {
            // try to delete save
            try
            {
                // overwrite
                using (StreamWriter file = new StreamWriter("deaths.txt"))
                {
                    // file is overwritten, so 0 units have died
                    file.WriteLine("0");
                }
                // overwrite and leave blank
                using (StreamWriter file = new StreamWriter("enemyinfo.txt"))
                {
                    // leave blank   
                }
            }
            // display a message if this is not possible
            catch
            {
                // show an error message
                MessageBox.Show("Enemy save file could not be deleted");
            }
        }

        // loads all enemy info
        public void LoadAll()
        {
            LoadDeaths();
            LoadEnemyInfo();
        }

        // saves all enemy info
        public void SaveAll()
        {
            SaveDeaths();
            SaveEnemyInfo();
        }
    }
}
