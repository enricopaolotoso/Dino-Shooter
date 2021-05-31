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
        string riempimentoFile = "0::";
        public static char carattereDivisore = ':';
        public static int nRighe=0;
        public static int punteggio = 0;
        public static int nRigaPlayer;
        public static string[,] username_punteggi;
        bool letturaFileEseguita;
        string stringSalvataggio = "";
        string username = "";
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
            statoUsernametxt();
            bool controllo=false;
            if (variabileStatoUsernamebtn == true)
            {
                for (int i = 0; i < nRighe; i++)
                {
                    if (username == username_punteggi[i, 0]||username=="\n"+username_punteggi[i,0])
                    {
                        controllo = true;
                        MessageBox.Show("benvenuto " + username);
                        nRigaPlayer = i;
                        statoAccesso = true;
                        punteggio =Convert.ToInt32(username_punteggi[i, 1]);
                        punteggioGiocatorelbl.Text= "punteggio giocatore: " + username_punteggi[i, 1];
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
                    gestioneFile();
                    punteggioGiocatorelbl.Text = "punteggio giocatore: " + username_punteggi[nRigaPlayer, 1];
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
            this.Hide();
            Form1.form1.Show();
        }
    }
}
