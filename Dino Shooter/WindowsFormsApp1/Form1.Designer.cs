namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtAmmo = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.Label();
            this.HealthBar = new System.Windows.Forms.ProgressBar();
            this.txtHealth = new System.Windows.Forms.Label();
            this.player = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAmmo
            // 
            this.txtAmmo.AutoSize = true;
            this.txtAmmo.BackColor = System.Drawing.Color.Transparent;
            this.txtAmmo.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmmo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtAmmo.Location = new System.Drawing.Point(13, 13);
            this.txtAmmo.Name = "txtAmmo";
            this.txtAmmo.Size = new System.Drawing.Size(96, 29);
            this.txtAmmo.TabIndex = 0;
            this.txtAmmo.Text = "Ammo. 0";
            this.txtAmmo.Click += new System.EventHandler(this.txtAmmo_Click);
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.BackColor = System.Drawing.Color.Transparent;
            this.txtScore.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtScore.Location = new System.Drawing.Point(349, 13);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(77, 29);
            this.txtScore.TabIndex = 1;
            this.txtScore.Text = "Kills: 0";
            this.txtScore.Click += new System.EventHandler(this.label2_Click);
            // 
            // HealthBar
            // 
            this.HealthBar.Location = new System.Drawing.Point(692, 19);
            this.HealthBar.Name = "HealthBar";
            this.HealthBar.Size = new System.Drawing.Size(137, 23);
            this.HealthBar.TabIndex = 2;
            this.HealthBar.Value = 100;
            this.HealthBar.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // txtHealth
            // 
            this.txtHealth.AutoSize = true;
            this.txtHealth.BackColor = System.Drawing.Color.Transparent;
            this.txtHealth.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHealth.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtHealth.Location = new System.Drawing.Point(615, 13);
            this.txtHealth.Name = "txtHealth";
            this.txtHealth.Size = new System.Drawing.Size(81, 29);
            this.txtHealth.TabIndex = 3;
            this.txtHealth.Text = "Health:";
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.player.Image = ((System.Drawing.Image)(resources.GetObject("player.Image")));
            this.player.Location = new System.Drawing.Point(372, 416);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(100, 101);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 4;
            this.player.TabStop = false;
            this.player.Click += new System.EventHandler(this.player_Click);
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Tick += new System.EventHandler(this.MainTimerEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(851, 529);
            this.Controls.Add(this.player);
            this.Controls.Add(this.txtHealth);
            this.Controls.Add(this.HealthBar);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.txtAmmo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtAmmo;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.ProgressBar HealthBar;
        private System.Windows.Forms.Label txtHealth;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer GameTimer;
    }
}

