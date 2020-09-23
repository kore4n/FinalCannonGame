/*
 * Jason Kwan, Kevin Zhong
 * 2019-11-13
 * To make a real time cannon shooting game to kill enemy invaders attacking a castle to survive until the end
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalCannonGame
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();

            // let the enemy player bot to have access to the cannon
            enemyPlayerBot.SetCannon = c1;
            // let the cannon have access to the enemy player]
            c1.SetEnemyPlayer = enemyPlayerBot;
            // load all enemy info and their deaths
            enemyPlayerBot.LoadAll();
        }

        // make the starting cannon
        private Cannon c1 = new Cannon();
        // create a new enemy player
        private EnemyPlayer enemyPlayerBot = new EnemyPlayer();

        // draw enemy boxes
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // draw the rectangleFs that belong to the enemy player
            enemyPlayerBot.Draw(e);

            // draw the cannon and its projectiles
            c1.Draw(e);
        }

        // detect key presses
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // run the code if the E key is pressed
            // make sure nobody has lost yet is on so the game can't be unpaused after somebody lost
            if (e.KeyCode == Keys.E && c1.GameOver() == false && enemyPlayerBot.PlayerWin() == false)
            {
                // check if the timer is running
                if (tmrGame.Enabled == true)
                {
                    // show the user instructions
                    lblUserInstructions.Show();
                    // hide all other labels
                    lblHealth.Hide();
                    lblKills.Hide();
                    lblEnemiesRemaining.Hide();
                    // disable the timer
                    tmrGame.Enabled = false;
                }
                // timer is false
                else
                {
                    // hide the user instructions
                    lblUserInstructions.Hide();
                    // show all other labels
                    lblHealth.Show();
                    lblKills.Show();
                    lblEnemiesRemaining.Show();
                    // enable the timer
                    tmrGame.Enabled = true;
                }
            }
            // check if the Q key was pressed
            else if (e.KeyCode == Keys.Q)
            {
                // save the enemy's info
                enemyPlayerBot.SaveAll();
            }
            // check if the delete key was pressed
            else if (e.KeyCode == Keys.Delete)
            {
                // delete the save
                enemyPlayerBot.DeleteSave();
            }
            // check if the escape key was pressed
            else if (e.KeyCode == Keys.Escape)
            {
                // restart the game
                Application.Restart();
            }
        }

        
        // timer to control enemies
        private void tmrGame_Tick(object sender, EventArgs e)
        {
            // run the game
            PlayGame();
            // refreshes the screen continuously and updates it with the moving and changing parts
            Refresh();
        }

        // mouse down event for shooting
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // shoot a normal cannon ball with a left click
            if (e.Button == MouseButtons.Left)
            {
                // get the x coordinate of the mouse cursor
                int mouseX = e.X;
                // get the y coordinate of the mouse cursor
                int mouseY = e.Y;
                // calculate the radian 
                double radian = Math.Atan((mouseY - picCannon.Location.Y) / (double)(mouseX - picCannon.Location.X));
                // check if the player has enough kills to shoot a large cannonball
                if (c1.BigCannonBall() == true)
                {
                    // make a large cannon ball
                    c1.CreateCannonBall("Large", radian);
                }
                else
                {
                    // make a normal sized cannon ball
                    c1.CreateCannonBall("Normal", radian);
                }
            }
        }

        // update the label to show the proper amount of enemies remaining
        private void UpdateEnemyRemainingLabel()
        {
            // show the amount of enemies remaining
            lblEnemiesRemaining.Text = "Enemies Remaining: " + enemyPlayerBot.GetEnemiesRemaining + "";
        }

        // update the label to show the amount of kills the player has
        private void UpdateEnemyKillsLabel()
        {
            // show the number of enemies killed
            lblKills.Text = "Kills: " + enemyPlayerBot.UnitsDefeatedProperty + "";
        }

        // update the label to show the player's health remaining 
        private void UpdatePlayerHealth()
        {
            // show the remaining health of the player
            lblHealth.Text = "Player HP Remaining: " + c1.GetHealth + "";
        }

        // update every label for the user interface
        private void UpdateAllLabels()
        {
            // update the number of enemies remaining
            UpdateEnemyRemainingLabel();
            // update the amount of kills the enemy has
            UpdateEnemyKillsLabel();
            // update the player's health
            UpdatePlayerHealth();
        }

        // check who the winner of the game is
        private void CheckWinner()
        {
            // check if the user won
            if (enemyPlayerBot.PlayerWin() == true || c1.GameOver() == true)
            {
                // disable the timer
                tmrGame.Enabled = false;
                // tell the user their outcome
                if (enemyPlayerBot.PlayerWin() == true)
                {
                    lblResult.Text = "You Won! Congrats!";
                }
                // if the user didn't win, then they lost
                else
                {
                    lblResult.Text = "You lost! Try again!";
                }
            }
        }

        // play the entire game
        private void PlayGame()
        {
            // check who the winner is
            CheckWinner();
            // make the enemy active
            enemyPlayerBot.ActiveEnemy();
            // run the cannon
            c1.RunCannon();
            // update all user interface labels
            UpdateAllLabels();
        }
    }
}
