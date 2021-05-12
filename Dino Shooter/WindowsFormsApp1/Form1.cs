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
        PictureBox ammoPic = new PictureBox(); // create a new instance of the picture box

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

            if (player.Bounds.IntersectsWith(ammoPic.Bounds))
            {
                ammo = 10;
            }



        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
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

        private void MainTimerEvents(object sender, EventArgs e)
        {

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

            if (e.KeyCode == Keys.Space && ammo > 0)
            {
                ammo--;
                ShootBullet(facing);
            }

            if (ammo < 1)
            {
                DropAmmo() ;                
            }

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
            dino.Tag = "dino";
            dino.Image = Properties.Resources.dino_1_down;
            dino.Left = newRand.Next(0, 900);
            dino.Top = newRand.Next(0, 800);
            dino.SizeMode = PictureBoxSizeMode.AutoSize;
            dinoList.Add(dino);
            this.Controls.Add(dino);
            player.BringToFront();
        }

        private void DropAmmo()
        {

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

        }
    }
}
