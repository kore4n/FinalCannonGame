namespace FinalCannonGame
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.tmrGame = new System.Windows.Forms.Timer(this.components);
            this.lblUserInstructions = new System.Windows.Forms.Label();
            this.picCannon = new System.Windows.Forms.PictureBox();
            this.picCastle = new System.Windows.Forms.PictureBox();
            this.lblEnemiesRemaining = new System.Windows.Forms.Label();
            this.lblKills = new System.Windows.Forms.Label();
            this.lblHealth = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCannon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCastle)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrGame
            // 
            this.tmrGame.Interval = 10;
            this.tmrGame.Tick += new System.EventHandler(this.tmrGame_Tick);
            // 
            // lblUserInstructions
            // 
            this.lblUserInstructions.BackColor = System.Drawing.Color.Transparent;
            this.lblUserInstructions.Font = new System.Drawing.Font("Cambria", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserInstructions.Location = new System.Drawing.Point(211, 155);
            this.lblUserInstructions.Name = "lblUserInstructions";
            this.lblUserInstructions.Size = new System.Drawing.Size(807, 376);
            this.lblUserInstructions.TabIndex = 1;
            this.lblUserInstructions.Text = resources.GetString("lblUserInstructions.Text");
            // 
            // picCannon
            // 
            this.picCannon.BackColor = System.Drawing.Color.Transparent;
            this.picCannon.Image = global::FinalCannonGame.Properties.Resources.cannon;
            this.picCannon.Location = new System.Drawing.Point(-16, 316);
            this.picCannon.Name = "picCannon";
            this.picCannon.Size = new System.Drawing.Size(114, 98);
            this.picCannon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCannon.TabIndex = 2;
            this.picCannon.TabStop = false;
            // 
            // picCastle
            // 
            this.picCastle.BackColor = System.Drawing.Color.Transparent;
            this.picCastle.Image = global::FinalCannonGame.Properties.Resources.Castle;
            this.picCastle.Location = new System.Drawing.Point(-115, 459);
            this.picCastle.Name = "picCastle";
            this.picCastle.Size = new System.Drawing.Size(282, 308);
            this.picCastle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCastle.TabIndex = 3;
            this.picCastle.TabStop = false;
            // 
            // lblEnemiesRemaining
            // 
            this.lblEnemiesRemaining.AutoSize = true;
            this.lblEnemiesRemaining.BackColor = System.Drawing.Color.Transparent;
            this.lblEnemiesRemaining.Font = new System.Drawing.Font("Cambria", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnemiesRemaining.Location = new System.Drawing.Point(432, 34);
            this.lblEnemiesRemaining.Name = "lblEnemiesRemaining";
            this.lblEnemiesRemaining.Size = new System.Drawing.Size(443, 57);
            this.lblEnemiesRemaining.TabIndex = 4;
            this.lblEnemiesRemaining.Text = "Enemies Remaining:";
            this.lblEnemiesRemaining.Visible = false;
            // 
            // lblKills
            // 
            this.lblKills.AutoSize = true;
            this.lblKills.BackColor = System.Drawing.Color.Transparent;
            this.lblKills.Font = new System.Drawing.Font("Cambria", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKills.Location = new System.Drawing.Point(432, 110);
            this.lblKills.Name = "lblKills";
            this.lblKills.Size = new System.Drawing.Size(128, 57);
            this.lblKills.TabIndex = 5;
            this.lblKills.Text = "Kills:";
            this.lblKills.Visible = false;
            // 
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.BackColor = System.Drawing.Color.Transparent;
            this.lblHealth.Font = new System.Drawing.Font("Cambria", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHealth.Location = new System.Drawing.Point(173, 695);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(328, 57);
            this.lblHealth.TabIndex = 6;
            this.lblHealth.Text = "HP Remaining:";
            this.lblHealth.Visible = false;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Font = new System.Drawing.Font("Cambria", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(432, 260);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 57);
            this.lblResult.TabIndex = 7;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FinalCannonGame.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblHealth);
            this.Controls.Add(this.lblKills);
            this.Controls.Add(this.lblEnemiesRemaining);
            this.Controls.Add(this.picCannon);
            this.Controls.Add(this.picCastle);
            this.Controls.Add(this.lblUserInstructions);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.picCannon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCastle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrGame;
        private System.Windows.Forms.Label lblUserInstructions;
        private System.Windows.Forms.PictureBox picCannon;
        private System.Windows.Forms.PictureBox picCastle;
        private System.Windows.Forms.Label lblEnemiesRemaining;
        private System.Windows.Forms.Label lblKills;
        private System.Windows.Forms.Label lblHealth;
        private System.Windows.Forms.Label lblResult;
    }
}

