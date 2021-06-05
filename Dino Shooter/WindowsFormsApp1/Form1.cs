using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static Form1 form1 = new Form1();
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

        private void MainTimerEvent(object sender, EventArgs e)// timer che gestisce il gioco
        {
            if (playerHealth > 1)
            {
                HealthBar.Value = playerHealth;
            }
            else
            {
                gameOver = true;// se la salute è minore di 1 il gioco si ferma
                player.Image = Properties.Resources.dead;
                GameTimer.Stop();
                playtxt.Visible = true;mostraForm2.Visible = true;
                if (Form2.statoAccesso == true)
                {
                    if (score > Form2.punteggio)
                    {
                        Form2.punteggio= score;
                        Form2.username_punteggi[Form2.nRigaPlayer, 1]=Convert.ToString(score);
                        sort();
                        save();
                    }
                }
            }

            txtAmmo.Text = "Ammo" + ammo;
            txtScore.Text = "Kills" + score;

            if (goLeft == true && player.Left > 0)//velocità player
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
                if (x is PictureBox && (string)x.Tag == "ammo")//comando per raccogliere munizioni
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo += 10; // aumenta il caricatore di 10 munizioni
                    }
                }

                if (x is PictureBox && (string)x.Tag == "dino")
                {
                    if(player.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerHealth -= 1;//attacco dei dinosauri
                    }

                    if (x.Left > player.Left)//movimento dinosauri
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
                        if (x.Bounds.IntersectsWith(j.Bounds))//uccisione dinosauri
                        {
                            score++;

                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x);
                            dinoList.Remove(((PictureBox)x));
                            MakeDinos();// crea un nuovo dinosauro quando ne viene eliminato 1
                        }
                    }
                }

            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)//funzioni pressione tasti
        {

            if( gameOver == true)
            {
                return;
            }

            if (e.KeyCode == Keys.Left)//movimento player
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

        private void KeyIsUp(object sender, KeyEventArgs e)//funzione rilascio tasti
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

                if (ammo < 1)//se le munizioni finiscono viene generato un caricatore nella mappa
                {
                   DropAmmo();//funzione spawn caricatore
                }
            }
        }
        private void txtAmmo_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            playtxt.Left = this.ClientSize.Width / 2 - playtxt.Width / 2;
            mostraForm2.Left = this.ClientSize.Width / 2 - mostraForm2.Width / 2;
            GameTimer.Stop();
            playtxt.Visible = true;
            mostraForm2.Visible = true;
        }

        private void playtxt_Click(object sender, EventArgs e)
        {
            RestartGame();
            playtxt.Visible = false;
            mostraForm2.Visible = false;
        }

        private void mostraForm2_Click(object sender, EventArgs e)
        {
            form2.Show();
            this.Hide();
        }

        private void ShootBullet(string direction)//funzione per sparare
          {
            Bullet shootBullet = new Bullet();//crea il proiettile
            shootBullet.direction = direction;//muove il proiettile in base alla posizione
            shootBullet.bulletLeft = player.Left + (player.Width / 2);
            shootBullet.bulletTop = player.Top + (player.Height / 2);
            shootBullet.makeBullet(this);

        }

        private void MakeDinos()//funzione per generare dinosauri
        {
            PictureBox dino = new PictureBox();//immagine dinosauro
            dino.BackColor = Color.Transparent;//toglie lo sfondo
            dino.Image = Properties.Resources.dino_1_down;//sceglie immagine
            dino.Tag = "dino";

            dino.Left = newRand.Next(0, 900);//genera un punto randomico dove spawnare il dinosauro
            dino.Top = newRand.Next(0, 800);//genera un punto randomico dove spawnare il dinosauro
            dino.SizeMode = PictureBoxSizeMode.AutoSize;
            dinoList.Add(dino);
            this.Controls.Add(dino);
            player.BringToFront();//porta davanti il player
        }

        private void DropAmmo()// funzione per generare un caricatore in un punto randomico della mappa 
        {
            PictureBox ammoPic = new PictureBox();
            ammoPic.Image = Properties.Resources.ammo_Image; // dare l'immagine ammo to the picture box
            ammoPic.SizeMode = PictureBoxSizeMode.AutoSize; 
            ammoPic.Left = newRand.Next(10, this.ClientSize.Width - ammoPic.Width); // poszione random
            ammoPic.Top = newRand.Next(50, this.ClientSize.Height - ammoPic.Height); // poszione random
            ammoPic.Tag = "ammo"; 
            this.Controls.Add(ammoPic); // mettere immagine ammo sullo

            ammoPic.BringToFront(); // mettere davanti
            player.BringToFront(); // mettere il player davanti

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void RestartGame()// funzione per riiniziare la partita
        {
            player.Image = Properties.Resources.shooter_assault_up;//sceglie l'immagine

            foreach (PictureBox i in dinoList)
            {
                this.Controls.Remove(i);//rimuove tutti i dinosauri rimasti
            }

            dinoList.Clear();

            for (int i = 0; i < 3; i++)
            {
                MakeDinos();
            }

            goUp = false;//impedisce al giocatore di muoversi
            goDown = false;//impedisce al giocatore di muoversi
            goLeft = false;//impedisce al giocatore di muoversi
            goRight = false;//impedisce al giocatore di muoversi
            gameOver = false;

            playerHealth = 100;//ripristina la salute
            score = 0;//azzera il numero di uccisioni
            ammo = 10;//ripristina le munizioni

            GameTimer.Start();//fa riiniziare la partita
        }
        private void sort()
        {
            for (int i = 0; i < Form2.nRighe - 1; i++)
            {
                // Trova il minimo nel subarray da ordinare
                int indice_min = i;
                int primoElementoComparazione;
                int secondoElementoComparazione;
                for (int j = i + 1; j < Form2.nRighe; j++)
                {
                    primoElementoComparazione = Convert.ToInt32(Form2.username_punteggi[j, 1]);
                    secondoElementoComparazione = Convert.ToInt32(Form2.username_punteggi[indice_min, 1]);
                    // Confronto per trovare un nuovo minimo
                    if (primoElementoComparazione < secondoElementoComparazione)
                    {
                        indice_min = j; // Salvo l'indice del nuovo minimo
                    }
                }
                // Scambia il minimo trovato con il primo elemento
                swap(indice_min, i);
            }
        }
        private void swap(int a, int b)
        {
            string tempPunteggio = Form2.username_punteggi[a, 1];
            Form2.username_punteggi[a, 1] = Form2.username_punteggi[b, 1];
            Form2.username_punteggi[b, 1] = tempPunteggio;
            string tempUsername = Form2.username_punteggi[a, 0];
            Form2.username_punteggi[a, 0] = Form2.username_punteggi[b, 0];
            Form2.username_punteggi[b, 0] = tempUsername;
        }
        private void save()
        {
            string salvataggio = "";//viene dichiarata la stringa per il salvataggio su file
            string[,] arrayDiSalvataggio = new string[Form2.nRighe, 2];//viene dichiarato l'array di tipo string per la memorizzazione ordinata di ID e punteggi con i caratteri divisori
            for (int i = 0; i < Form2.nRighe; i++)                     //tramite i seguenti cicli for 
            {
                for (int j = 0; j < 2; j++)
                {
                    if (i == (Form2.nRighe - 1) && j == 2)//se si tratta dell'ultimo elemento del file non viene aggiunto il carattere divisore
                    {
                        arrayDiSalvataggio[i, j] = Form2.username_punteggi[i, j];
                    }
                    else//in caso contrario si
                    {
                        arrayDiSalvataggio[i, j] = Form2.username_punteggi[i, j] + Form2.carattereDivisore;
                    }
                }
            }
            int variabileDiControllo = 0;
            for (int i = 0; i < Form2.nRighe; i++)//ciclo for per il salvataggio nella stringa di salvataggio
            {
                if (variabileDiControllo == 0)//il primo valore che deve essere salvato su file è il numero delle righe delfile 
                {
                    salvataggio = Convert.ToString(Form2.nRighe) + Form2.carattereDivisore;
                    variabileDiControllo = 1;
                }
                for (int j = 0; j < 2; j++)//vengono salvati gli ID e punteggi corrispondenti
                {
                    salvataggio = salvataggio + arrayDiSalvataggio[i, j];
                }
                //salvataggio = salvataggio + "\n";//dopo il salvataggio di un ID e punteggio il programma va a capo per salvare il successivo
            }
            File.WriteAllText(@"", salvataggio);//viene salvato il tutto su file
            salvataggio = "";//viene svuotata la variabile stringa
        }
    }
}
