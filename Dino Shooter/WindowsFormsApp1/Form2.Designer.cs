
namespace WindowsFormsApp1
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.usernametxt = new System.Windows.Forms.TextBox();
            this.formtitletxt = new System.Windows.Forms.Label();
            this.usernamelbl = new System.Windows.Forms.Label();
            this.punteggioGiocatorelbl = new System.Windows.Forms.Label();
            this.accedi_registrati_btn = new System.Windows.Forms.Button();
            this.logoutbtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mostraSchermataDiGiocobtn = new System.Windows.Forms.Button();
            this.mostraClassificabtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // usernametxt
            // 
            this.usernametxt.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.usernametxt.BackColor = System.Drawing.SystemColors.Window;
            this.usernametxt.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernametxt.Location = new System.Drawing.Point(314, 233);
            this.usernametxt.Name = "usernametxt";
            this.usernametxt.Size = new System.Drawing.Size(190, 37);
            this.usernametxt.TabIndex = 0;
            this.usernametxt.TextChanged += new System.EventHandler(this.usernametxt_TextChanged);
            // 
            // formtitletxt
            // 
            this.formtitletxt.AutoSize = true;
            this.formtitletxt.BackColor = System.Drawing.Color.Black;
            this.formtitletxt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.formtitletxt.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formtitletxt.ForeColor = System.Drawing.Color.White;
            this.formtitletxt.Location = new System.Drawing.Point(277, 24);
            this.formtitletxt.Name = "formtitletxt";
            this.formtitletxt.Size = new System.Drawing.Size(283, 70);
            this.formtitletxt.TabIndex = 1;
            this.formtitletxt.Text = "dino shooter\r\nregistrazione punteggio";
            this.formtitletxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // usernamelbl
            // 
            this.usernamelbl.AutoSize = true;
            this.usernamelbl.BackColor = System.Drawing.Color.Black;
            this.usernamelbl.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernamelbl.ForeColor = System.Drawing.Color.White;
            this.usernamelbl.Location = new System.Drawing.Point(363, 168);
            this.usernamelbl.Name = "usernamelbl";
            this.usernamelbl.Size = new System.Drawing.Size(100, 26);
            this.usernamelbl.TabIndex = 2;
            this.usernamelbl.Text = "username";
            this.usernamelbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // punteggioGiocatorelbl
            // 
            this.punteggioGiocatorelbl.AutoSize = true;
            this.punteggioGiocatorelbl.BackColor = System.Drawing.Color.Black;
            this.punteggioGiocatorelbl.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.punteggioGiocatorelbl.ForeColor = System.Drawing.Color.White;
            this.punteggioGiocatorelbl.Location = new System.Drawing.Point(312, 115);
            this.punteggioGiocatorelbl.Name = "punteggioGiocatorelbl";
            this.punteggioGiocatorelbl.Size = new System.Drawing.Size(192, 26);
            this.punteggioGiocatorelbl.TabIndex = 3;
            this.punteggioGiocatorelbl.Text = "punteggio giocatore:";
            // 
            // accedi_registrati_btn
            // 
            this.accedi_registrati_btn.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accedi_registrati_btn.Location = new System.Drawing.Point(336, 286);
            this.accedi_registrati_btn.Name = "accedi_registrati_btn";
            this.accedi_registrati_btn.Size = new System.Drawing.Size(140, 45);
            this.accedi_registrati_btn.TabIndex = 4;
            this.accedi_registrati_btn.Text = "accedi/registrati";
            this.accedi_registrati_btn.UseVisualStyleBackColor = true;
            this.accedi_registrati_btn.Click += new System.EventHandler(this.accedi_registrati_btn_Click);
            // 
            // logoutbtn
            // 
            this.logoutbtn.BackColor = System.Drawing.Color.Maroon;
            this.logoutbtn.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutbtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.logoutbtn.Location = new System.Drawing.Point(345, 349);
            this.logoutbtn.Name = "logoutbtn";
            this.logoutbtn.Size = new System.Drawing.Size(140, 45);
            this.logoutbtn.TabIndex = 5;
            this.logoutbtn.Text = "logout";
            this.logoutbtn.UseVisualStyleBackColor = false;
            this.logoutbtn.Click += new System.EventHandler(this.logoutbtn_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mostraSchermataDiGiocobtn
            // 
            this.mostraSchermataDiGiocobtn.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mostraSchermataDiGiocobtn.Location = new System.Drawing.Point(83, 145);
            this.mostraSchermataDiGiocobtn.Name = "mostraSchermataDiGiocobtn";
            this.mostraSchermataDiGiocobtn.Size = new System.Drawing.Size(140, 45);
            this.mostraSchermataDiGiocobtn.TabIndex = 6;
            this.mostraSchermataDiGiocobtn.Text = "torna al gioco";
            this.mostraSchermataDiGiocobtn.UseVisualStyleBackColor = true;
            this.mostraSchermataDiGiocobtn.Click += new System.EventHandler(this.mostraSchermataDiGiocobtn_Click);
            // 
            // mostraClassificabtn
            // 
            this.mostraClassificabtn.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mostraClassificabtn.Location = new System.Drawing.Point(83, 266);
            this.mostraClassificabtn.Name = "mostraClassificabtn";
            this.mostraClassificabtn.Size = new System.Drawing.Size(140, 45);
            this.mostraClassificabtn.TabIndex = 7;
            this.mostraClassificabtn.Text = "classifica";
            this.mostraClassificabtn.UseVisualStyleBackColor = true;
            this.mostraClassificabtn.Click += new System.EventHandler(this.mostraClassificabtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 8;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.mostraClassificabtn);
            this.Controls.Add(this.mostraSchermataDiGiocobtn);
            this.Controls.Add(this.logoutbtn);
            this.Controls.Add(this.accedi_registrati_btn);
            this.Controls.Add(this.punteggioGiocatorelbl);
            this.Controls.Add(this.usernamelbl);
            this.Controls.Add(this.formtitletxt);
            this.Controls.Add(this.usernametxt);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernametxt;
        private System.Windows.Forms.Label formtitletxt;
        private System.Windows.Forms.Label usernamelbl;
        private System.Windows.Forms.Label punteggioGiocatorelbl;
        private System.Windows.Forms.Button accedi_registrati_btn;
        private System.Windows.Forms.Button logoutbtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button mostraSchermataDiGiocobtn;
        private System.Windows.Forms.Button mostraClassificabtn;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}