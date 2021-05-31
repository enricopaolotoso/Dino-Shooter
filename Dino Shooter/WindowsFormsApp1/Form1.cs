using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Form2 form2 = new Form2();
        bool goLeft, goRight, goUp, goDown, gameOver;
        string facing = "up";
        int playerHealth = 100;
        int speed = 20;
        int ammo = 10;
        int dinoSpeed = 5;
        Random newRand = new Random();
        int score;
        List<PictureBox> dinoList = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            if (playerHealth > 1)
            {
                HealthBar.Value = playerHealth;
            }
            else
            {
                gameOver = true;
                player.Image = Properties.Resources.dead;
                GameTimer.Stop();
                playtxt.Visible = true;
            }

            txtAmmo.Text = "Ammo" + ammo;
            txtScore.Text = "Kills" + score;

            if (goLeft == true && player.Left > 0)
            {
                player.Left -= speed;
            }
            if(goRight == true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += speed;
            }
            if (goUp == true && player.Top > 40)
            {
                player.Top -= speed;
            }
            if (goDown == true && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += speed;
            }
           
            foreach(Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo += 10;
                    }
                }

                if (x is PictureBox && (string)x.Tag == "dino")
                {
                    if(player.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerHealth -= 1;
                    }

                    if (x.Left > player.Left)
                    {
                        x.Left -= dinoSpeed;
                        ((PictureBox)x).Image = Properties.Resources.dino_1;
                    }
                    if (x.Left < player.Left)
                    {
                        x.Left += dinoSpeed;
                        ((PictureBox)x).Image = Properties.Resources.dino_1_right;
                    }
                    if (x.Top > player.Top)
                    {
                        x.Top -= dinoSpeed;
                        ((PictureBox)x).Image = Properties.Resources.dino_1_down;
                    }
                    if (x.Top < player.Top)
                    {
                        x.Top += dinoSpeed;
                        ((PictureBox)x).Image = Properties.Resources.dino_1_up;
                    }


                }

                foreach (Control j in this.Controls)
                {
                    if (j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "dino")
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            score++;

                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x);
                            dinoList.Remove(((PictureBox)x));
                            MakeDinos();
                        }
                    }
                }

            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {

            if( gameOver == true)
            {
                return;
            }

            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
                facing = "left";
                player.Image = Properties.Resources.shooter_assault_left;          
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                facing = "right";
                player.Image = Properties.Resources.shooter_assalut_right;                
            }

            if(e.KeyCode == Keys.Up)
            {
                goUp = true;
                facing = "up";
                player.Image = Properties.Resources.shooter_assault_up;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                facing = "down";
                player.Image = Properties.Resources.shooter_assault_down;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }

            if (e.KeyCode == Keys.Space && ammo > 0 && gameOver == false)
            {
                ammo--;
                ShootBullet(facing);

                if (ammo < 1)
                {
                   DropAmmo();
                }
            }

            //if(e.KeyCode == Keys.Enter && gameOver == true)
            //{
            //    RestartGame();
            //}
        }


        private void txtAmmo_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GameTimer.Stop();
            playtxt.Visible = true;
        }

        private void playtxt_Click(object sender, EventArgs e)
        {
            RestartGame();
            playtxt.Visible = false;
        }

        private void mostraForm2_Click(object sender, EventArgs e)
        {
            form2.Show();
            this.Hide();
        }

        private void ShootBullet(string direction)
          {
            Bullet shootBullet = new Bullet();
            shootBullet.direction = direction;
            shootBullet.bulletLeft = player.Left + (player.Width / 2);
            shootBullet.bulletTop = player.Top + (player.Height / 2);
            shootBullet.makeBullet(this);

        }

        private void MakeDinos()
        {

            PictureBox dino = new PictureBox();
            dino.BackColor = Color.Transparent;
            dino.Image = Properties.Resources.dino_1_down;
            dino.Tag = "dino";

            dino.Left = newRand.Next(0, 900);
            dino.Top = newRand.Next(0, 800);
            dino.SizeMode = PictureBoxSizeMode.AutoSize;
            dinoList.Add(dino);
            this.Controls.Add(dino);
            player.BringToFront();
        }

        private void DropAmmo()
        {
            PictureBox ammoPic = new PictureBox();
            ammoPic.Image = Properties.Resources.ammo_Image; // assignment the ammo image to the picture box
            ammoPic.SizeMode = PictureBoxSizeMode.AutoSize; // set the size to auto size
            ammoPic.Left = newRand.Next(10, this.ClientSize.Width - ammoPic.Width); // set the location to a random left
            ammoPic.Top = newRand.Next(50, this.ClientSize.Height - ammoPic.Height); // set the location to a random top
            ammoPic.Tag = "ammo"; // set the tag to ammo
            this.Controls.Add(ammoPic); // add the ammo picture box to the screen

            ammoPic.BringToFront(); // bring it to front
            player.BringToFront(); // bring the player to front

        }

        private void RestartGame()
        {
            player.Image = Properties.Resources.shooter_assault_up;

            foreach (PictureBox i in dinoList)
            {
                this.Controls.Remove(i);
            }

            dinoList.Clear();

            for (int i = 0; i < 3; i++)
            {
                MakeDinos();
            }

            goUp = false;
            goDown = false;
            goLeft = false;
            goRight = false;
            gameOver = false;

            playerHealth = 100;
            score = 0;
            ammo = 10;

            GameTimer.Start();
        }
    }
}
