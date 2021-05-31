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
        char carattereDivisore = ':';
        int nRighe;
        static int nRigaPlayer;
        public static string[,] username_punteggi;
        bool letturaFileEseguita;
        string username = "";
        static bool statoAccesso=false;
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
                for (int j = 0; j < 3; j++)
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
                    if (username == username_punteggi[i, 0])
                    {
                        controllo = true;
                        MessageBox.Show("benvenuto " + username);
                        nRigaPlayer = i;
                        statoAccesso = true;
                    }
                }
                if (controllo == false)
                {
                    nRighe++;

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
    }
}
