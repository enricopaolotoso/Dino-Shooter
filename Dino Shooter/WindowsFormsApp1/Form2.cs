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
    public partial class Form2 : Form
    {
        bool variabileStatoDataGrid = false;
        string riempimentoFile = "0::";
        public static char carattereDivisore = ':';
        public static int nRighe=0;
        public static int punteggio = 0;
        public static int nRigaPlayer;
        public static string[,] username_punteggi;
        bool letturaFileEseguita;
        public static string name;
        string stringSalvataggio = "";
        string username;
        public static bool statoAccesso=false;
        bool variabileStatoUsernamebtn = false;
        
        public Form2()
        {
            InitializeComponent();
        }
        private void gestioneFile()
        {
            try
            {
                riempimentoFile = File.ReadAllText(@"C:\Users\Asus\Desktop\fileDinoShooter");
                caricamentoFile();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("file non trovato. ne verrà creato uno in automatico");
                File.WriteAllText(@"C:\Users\Asus\Desktop\fileDinoShooter", riempimentoFile);
                caricamentoFile();
            }
            catch (IOException)
            {
                MessageBox.Show("si è verificato un errore");
                Environment.Exit(0);
            }
        }
        private void caricamentoFile()
        {
            string[] elementiFile = riempimentoFile.Split(carattereDivisore);
            nRighe = Convert.ToInt32(elementiFile[0]);
            username_punteggi = new string[nRighe, 2];
            int n1 = 1; //Si inizializza la variabile necessaria per l'estrazione del contenuto dell'array monodimensionale elementi.
            for (int i = 0; i < nRighe; i++) //Inserisce nell'array multidimensionale elementiFileOrdinati il contenuto dell'array monodimensionale elementiFileDaOrdinare, 
            {
                for (int j = 0; j < 2; j++)
                {
                    username_punteggi[i, j] = elementiFile[n1];
                    n1++;
                }
            }
            letturaFileEseguita = true;
        }

        private void accedi_registrati_btn_Click(object sender, EventArgs e)
        {
            if (statoAccesso == false)
            {
                statoUsernametxt();
                bool controllo = false;
                if (variabileStatoUsernamebtn == true)
                {
                    for (int i = 0; i < nRighe; i++)
                    {
                        if (username == username_punteggi[i, 0] || "\n" + username == username_punteggi[i, 0])
                        {
                            controllo = true;
                            MessageBox.Show("benvenuto " + username);
                            nRigaPlayer = i;
                            username = username_punteggi[i, 0];
                            statoAccesso = true;
                            punteggio = Convert.ToInt32(username_punteggi[i, 1]);
                        }
                    }
                    if (controllo == false)
                    {
                        nRighe++;
                        string[,] arrayDiSalvataggio = new string[nRighe, 2];//array utilizzato per il salvataggio su File
                        for (int i = 0; i < nRighe; i++)//ciclo che inserisce i valori nell'array di salvataggio
                        {
                            if (i == 0)//se i=0, quindi si sta lavorando della prima riga dell'array, salva il nuovo ID con punteggio=0
                            {
                                arrayDiSalvataggio[i, 0] = username + ":";
                                arrayDiSalvataggio[i, 1] = punteggio + ":" + "\n";
                            }
                            else if (i >= 1)//dopodichè inserirà quelli già presenti nel file
                            {
                                for (int j = 0; j < 2; j++)//ciclo che permette di variare colonna
                                {
                                    if (i == (nRighe - 1) && j == 2)//se si tratta dell'ultimo elemento del file non viene aggiunto il carattere divisore
                                    {
                                        arrayDiSalvataggio[i, j] = username_punteggi[i - 1, j];
                                    }
                                    else//in caso contrario si
                                    {
                                        arrayDiSalvataggio[i, j] = username_punteggi[i - 1, j] + ":";
                                    }
                                }
                            }
                        }
                        int variabileDiControllo = 0;
                        for (int i = 0; i < nRighe; i++)//ciclo che inserisce i valori dell'array di salvataggio nella stringa utilizzata per la scrittura su file
                        {
                            if (variabileDiControllo == 0)//inserisce come primo valore il numero di righe del file
                            {
                                stringSalvataggio = Convert.ToString(nRighe) + ":";
                                variabileDiControllo = 1;
                            }
                            for (int j = 0; j < 2; j++)//dopodichè inserisce gli ID e punteggi
                            {
                                stringSalvataggio = stringSalvataggio + arrayDiSalvataggio[i, j];
                            }
                            //salvataggioID = salvataggioID + "\n";//dopo ogni ID e punteggio va a capo per salvare il successivo
                        }
                        File.WriteAllText(@"C:\Users\Asus\Desktop\fileDinoShooter", stringSalvataggio);//esegue la scrittura su file
                        stringSalvataggio = "";//svuota la stringa salvataggioID
                        nRigaPlayer = 0;//rigagiocatore assume il valore 0 poichè l'ID dell'utente appena rigistrato si trova nalla prima riga dell'array
                        statoAccesso = true;//l'utente è loggato
                        punteggio = 0;
                        username = username_punteggi[0, 0];
                        gestioneFile();
                        MessageBox.Show("benvenuto " + username);
                    }
                }
            }

        }
        private void statoUsernametxt()
        {
            if (username == "") 
            {
                //accedi_registrati_btn.BackColor = Color.DarkGray;
                //logoutbtn.BackColor = Color.Maroon;
                MessageBox.Show("non hai inserito uno username");
                usernametxt.Focus();     
                variabileStatoUsernamebtn=false;
            }
            else
            {
                variabileStatoUsernamebtn = true;
            }
        }
        private void usernametxt_TextChanged(object sender, EventArgs e)
        {
            username = usernametxt.Text;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            gestioneFile();
            dataGridView1.Visible = false;
            formtitletxt.Left = this.ClientSize.Width / 2 - formtitletxt.Width / 2;
            usernamelbl.Left = this.ClientSize.Width / 2 - usernamelbl.Width / 2;
            usernametxt.Left = this.ClientSize.Width / 2 - usernametxt.Width / 2;
            logoutbtn.Left = this.ClientSize.Width / 2 - logoutbtn.Width / 2;
            accedi_registrati_btn.Left = this.ClientSize.Width / 2 - accedi_registrati_btn.Width / 2;
            punteggioGiocatorelbl.Left = this.ClientSize.Width / 2 - punteggioGiocatorelbl.Width / 2;
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            if (statoAccesso==true)
            {
                nRigaPlayer = nRighe + 1;
                punteggio = 0;
                username = "";
                usernametxt.Clear();
                statoAccesso = false;
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Form1.form1.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (statoAccesso==true)
            {
                usernametxt.ReadOnly = true;
                usernametxt.BackColor = Color.DarkGray;
                name = username_punteggi[nRigaPlayer, 0];
                usernamelbl.Text = "username:" + name;
                logoutbtn.BackColor = Color.Red;
                accedi_registrati_btn.BackColor = Color.DarkGray;
            }
            else if (statoAccesso == false)
            {
                name = "";
                usernametxt.BackColor = Color.White;
                usernamelbl.Text = "username";
                logoutbtn.BackColor = Color.Maroon;
                accedi_registrati_btn.BackColor = Color.White;
            }
            punteggioGiocatorelbl.Text = "punteggio giocatore: " + punteggio;
            usernamelbl.Left = this.ClientSize.Width / 2 - usernamelbl.Width / 2;
            punteggioGiocatorelbl.Left = this.ClientSize.Width / 2 - punteggioGiocatorelbl.Width / 2;
        }

        private void mostraClassificabtn_Click(object sender, EventArgs e)
        {
            if (variabileStatoDataGrid == false) 
            {
                variabileStatoDataGrid = true;
                dataGridView1.Visible = true;
                dataGridView1.ColumnCount = 0;
                dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].HeaderText = "posizione";
                dataGridView1.Columns[1].HeaderText = "nome";
                dataGridView1.Columns[2].HeaderText = "punteggio";
                if (username_punteggi.Length >= 3)
                {
                    dataGridView1.Rows.Add("1", username_punteggi[nRighe - 1, 0], username_punteggi[nRighe - 1, 1]);
                    dataGridView1.Rows.Add("2", username_punteggi[nRighe - 2, 0], username_punteggi[nRighe - 2, 1]);
                    dataGridView1.Rows.Add("3", username_punteggi[nRighe - 3, 0], username_punteggi[nRighe - 3, 1]);
                }
                else if (username_punteggi.Length == 2)
                {
                    dataGridView1.Rows.Add("1", username_punteggi[nRighe - 1, 0], username_punteggi[nRighe - 1, 1]);
                    dataGridView1.Rows.Add("2", username_punteggi[nRighe - 2, 0], username_punteggi[nRighe - 2, 1]);
                }
                else if (username_punteggi.Length == 1)
                {
                    dataGridView1.Rows.Add("1", username_punteggi[nRighe - 1, 0], username_punteggi[nRighe - 1, 1]);
                }
            }
            else if (variabileStatoDataGrid == true)
            {
                dataGridView1.Visible = false;
                variabileStatoDataGrid = false;
            }

        }

        private void mostraSchermataDiGiocobtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1.form1.Show();
        }
    }
}
