namespace WindowsFormsApplication5
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBoxMinimize = new System.Windows.Forms.PictureBox();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.labelLogo = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.textBoxSifre = new System.Windows.Forms.TextBox();
            this.textBoxKullaniciAdi = new System.Windows.Forms.TextBox();
            this.labelSifre = new System.Windows.Forms.Label();
            this.labelKullaniciAdi = new System.Windows.Forms.Label();
            this.bttnGirisYap2 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelMesaj = new System.Windows.Forms.Label();
            this.panelGirisYap = new System.Windows.Forms.Panel();
            this.bttnKayitOl = new System.Windows.Forms.Button();
            this.panelKayitOl = new System.Windows.Forms.Panel();
            this.buttonGirisYap = new System.Windows.Forms.Button();
            this.buttonKayitOl2 = new System.Windows.Forms.Button();
            this.labelMesaj2 = new System.Windows.Forms.Label();
            this.textBoxSifre2 = new System.Windows.Forms.TextBox();
            this.labelSifre2 = new System.Windows.Forms.Label();
            this.textBoxKullaniciAdi2 = new System.Windows.Forms.TextBox();
            this.labelKullaniciAdi2 = new System.Windows.Forms.Label();
            this.tablo1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelBolum = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelGirisYap.SuspendLayout();
            this.panelKayitOl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablo1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Black;
            this.panelTop.Controls.Add(this.labelBolum);
            this.panelTop.Controls.Add(this.pictureBoxMinimize);
            this.panelTop.Controls.Add(this.pictureBoxClose);
            this.panelTop.Controls.Add(this.labelLogo);
            this.panelTop.Controls.Add(this.pictureBoxLogo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(756, 72);
            this.panelTop.TabIndex = 0;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // pictureBoxMinimize
            // 
            this.pictureBoxMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxMinimize.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMinimize.Image")));
            this.pictureBoxMinimize.Location = new System.Drawing.Point(657, 0);
            this.pictureBoxMinimize.Name = "pictureBoxMinimize";
            this.pictureBoxMinimize.Size = new System.Drawing.Size(45, 69);
            this.pictureBoxMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMinimize.TabIndex = 7;
            this.pictureBoxMinimize.TabStop = false;
            this.pictureBoxMinimize.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.Image")));
            this.pictureBoxClose.Location = new System.Drawing.Point(708, 3);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(45, 66);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxClose.TabIndex = 6;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // labelLogo
            // 
            this.labelLogo.AutoSize = true;
            this.labelLogo.BackColor = System.Drawing.Color.Transparent;
            this.labelLogo.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelLogo.ForeColor = System.Drawing.Color.White;
            this.labelLogo.Location = new System.Drawing.Point(84, 26);
            this.labelLogo.Name = "labelLogo";
            this.labelLogo.Size = new System.Drawing.Size(259, 24);
            this.labelLogo.TabIndex = 5;
            this.labelLogo.Text = "Hazır Giyim Otomasyonu";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(75, 66);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 4;
            this.pictureBoxLogo.TabStop = false;
            // 
            // textBoxSifre
            // 
            this.textBoxSifre.BackColor = System.Drawing.SystemColors.Highlight;
            this.textBoxSifre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSifre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBoxSifre.Font = new System.Drawing.Font("Candara", 14.25F);
            this.textBoxSifre.Location = new System.Drawing.Point(193, 71);
            this.textBoxSifre.Name = "textBoxSifre";
            this.textBoxSifre.Size = new System.Drawing.Size(100, 24);
            this.textBoxSifre.TabIndex = 13;
            this.textBoxSifre.Text = "textbox";
            this.textBoxSifre.UseSystemPasswordChar = true;
            this.textBoxSifre.Click += new System.EventHandler(this.textBox2_Click);
            // 
            // textBoxKullaniciAdi
            // 
            this.textBoxKullaniciAdi.BackColor = System.Drawing.SystemColors.Highlight;
            this.textBoxKullaniciAdi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxKullaniciAdi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBoxKullaniciAdi.Font = new System.Drawing.Font("Candara", 14.25F);
            this.textBoxKullaniciAdi.Location = new System.Drawing.Point(193, 41);
            this.textBoxKullaniciAdi.Name = "textBoxKullaniciAdi";
            this.textBoxKullaniciAdi.Size = new System.Drawing.Size(100, 24);
            this.textBoxKullaniciAdi.TabIndex = 12;
            this.textBoxKullaniciAdi.Text = "textbox";
            this.textBoxKullaniciAdi.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // labelSifre
            // 
            this.labelSifre.AutoSize = true;
            this.labelSifre.BackColor = System.Drawing.Color.Transparent;
            this.labelSifre.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSifre.ForeColor = System.Drawing.Color.White;
            this.labelSifre.Location = new System.Drawing.Point(113, 72);
            this.labelSifre.Name = "labelSifre";
            this.labelSifre.Size = new System.Drawing.Size(47, 23);
            this.labelSifre.TabIndex = 11;
            this.labelSifre.Text = "Şifre";
            // 
            // labelKullaniciAdi
            // 
            this.labelKullaniciAdi.AutoSize = true;
            this.labelKullaniciAdi.BackColor = System.Drawing.Color.Transparent;
            this.labelKullaniciAdi.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelKullaniciAdi.ForeColor = System.Drawing.Color.White;
            this.labelKullaniciAdi.Location = new System.Drawing.Point(55, 42);
            this.labelKullaniciAdi.Name = "labelKullaniciAdi";
            this.labelKullaniciAdi.Size = new System.Drawing.Size(105, 23);
            this.labelKullaniciAdi.TabIndex = 10;
            this.labelKullaniciAdi.Text = "Kullanıcı Adı";
            // 
            // bttnGirisYap2
            // 
            this.bttnGirisYap2.BackColor = System.Drawing.Color.White;
            this.bttnGirisYap2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttnGirisYap2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnGirisYap2.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bttnGirisYap2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.bttnGirisYap2.Location = new System.Drawing.Point(374, 3);
            this.bttnGirisYap2.Name = "bttnGirisYap2";
            this.bttnGirisYap2.Size = new System.Drawing.Size(150, 54);
            this.bttnGirisYap2.TabIndex = 14;
            this.bttnGirisYap2.Text = "Giriş Yap";
            this.bttnGirisYap2.UseVisualStyleBackColor = false;
            this.bttnGirisYap2.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(678, 228);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelMesaj
            // 
            this.labelMesaj.AutoSize = true;
            this.labelMesaj.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelMesaj.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMesaj.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelMesaj.Location = new System.Drawing.Point(23, 149);
            this.labelMesaj.Name = "labelMesaj";
            this.labelMesaj.Size = new System.Drawing.Size(115, 22);
            this.labelMesaj.TabIndex = 17;
            this.labelMesaj.Text = "hata mesajı";
            // 
            // panelGirisYap
            // 
            this.panelGirisYap.Controls.Add(this.bttnKayitOl);
            this.panelGirisYap.Controls.Add(this.bttnGirisYap2);
            this.panelGirisYap.Controls.Add(this.labelMesaj);
            this.panelGirisYap.Controls.Add(this.textBoxSifre);
            this.panelGirisYap.Controls.Add(this.labelSifre);
            this.panelGirisYap.Controls.Add(this.textBoxKullaniciAdi);
            this.panelGirisYap.Controls.Add(this.labelKullaniciAdi);
            this.panelGirisYap.Location = new System.Drawing.Point(118, 80);
            this.panelGirisYap.Name = "panelGirisYap";
            this.panelGirisYap.Size = new System.Drawing.Size(527, 189);
            this.panelGirisYap.TabIndex = 19;
            // 
            // bttnKayitOl
            // 
            this.bttnKayitOl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttnKayitOl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnKayitOl.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bttnKayitOl.ForeColor = System.Drawing.Color.White;
            this.bttnKayitOl.Location = new System.Drawing.Point(374, 63);
            this.bttnKayitOl.Name = "bttnKayitOl";
            this.bttnKayitOl.Size = new System.Drawing.Size(150, 54);
            this.bttnKayitOl.TabIndex = 20;
            this.bttnKayitOl.Text = "Kayıt Ol";
            this.bttnKayitOl.UseVisualStyleBackColor = true;
            this.bttnKayitOl.Click += new System.EventHandler(this.button4_Click);
            // 
            // panelKayitOl
            // 
            this.panelKayitOl.Controls.Add(this.buttonGirisYap);
            this.panelKayitOl.Controls.Add(this.buttonKayitOl2);
            this.panelKayitOl.Controls.Add(this.labelMesaj2);
            this.panelKayitOl.Controls.Add(this.textBoxSifre2);
            this.panelKayitOl.Controls.Add(this.labelSifre2);
            this.panelKayitOl.Controls.Add(this.textBoxKullaniciAdi2);
            this.panelKayitOl.Controls.Add(this.labelKullaniciAdi2);
            this.panelKayitOl.Location = new System.Drawing.Point(118, 80);
            this.panelKayitOl.Name = "panelKayitOl";
            this.panelKayitOl.Size = new System.Drawing.Size(527, 189);
            this.panelKayitOl.TabIndex = 19;
            // 
            // buttonGirisYap
            // 
            this.buttonGirisYap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGirisYap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGirisYap.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonGirisYap.ForeColor = System.Drawing.Color.White;
            this.buttonGirisYap.Location = new System.Drawing.Point(374, 4);
            this.buttonGirisYap.Name = "buttonGirisYap";
            this.buttonGirisYap.Size = new System.Drawing.Size(150, 54);
            this.buttonGirisYap.TabIndex = 21;
            this.buttonGirisYap.Text = "Giriş Yap";
            this.buttonGirisYap.UseVisualStyleBackColor = true;
            this.buttonGirisYap.Click += new System.EventHandler(this.button5_Click);
            // 
            // buttonKayitOl2
            // 
            this.buttonKayitOl2.BackColor = System.Drawing.Color.White;
            this.buttonKayitOl2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonKayitOl2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKayitOl2.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonKayitOl2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buttonKayitOl2.Location = new System.Drawing.Point(374, 64);
            this.buttonKayitOl2.Name = "buttonKayitOl2";
            this.buttonKayitOl2.Size = new System.Drawing.Size(150, 54);
            this.buttonKayitOl2.TabIndex = 22;
            this.buttonKayitOl2.Text = "Kayıt Ol";
            this.buttonKayitOl2.UseVisualStyleBackColor = false;
            this.buttonKayitOl2.Click += new System.EventHandler(this.button3_Click);
            // 
            // labelMesaj2
            // 
            this.labelMesaj2.AutoSize = true;
            this.labelMesaj2.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelMesaj2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMesaj2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelMesaj2.Location = new System.Drawing.Point(16, 155);
            this.labelMesaj2.Name = "labelMesaj2";
            this.labelMesaj2.Size = new System.Drawing.Size(115, 22);
            this.labelMesaj2.TabIndex = 19;
            this.labelMesaj2.Text = "hata mesajı";
            // 
            // textBoxSifre2
            // 
            this.textBoxSifre2.BackColor = System.Drawing.SystemColors.Highlight;
            this.textBoxSifre2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSifre2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBoxSifre2.Font = new System.Drawing.Font("Candara", 14.25F);
            this.textBoxSifre2.Location = new System.Drawing.Point(193, 71);
            this.textBoxSifre2.Name = "textBoxSifre2";
            this.textBoxSifre2.Size = new System.Drawing.Size(100, 24);
            this.textBoxSifre2.TabIndex = 17;
            this.textBoxSifre2.Text = "textbox";
            this.textBoxSifre2.UseSystemPasswordChar = true;
            this.textBoxSifre2.Click += new System.EventHandler(this.textBox3_Click);
            // 
            // labelSifre2
            // 
            this.labelSifre2.AutoSize = true;
            this.labelSifre2.BackColor = System.Drawing.Color.Transparent;
            this.labelSifre2.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSifre2.ForeColor = System.Drawing.Color.White;
            this.labelSifre2.Location = new System.Drawing.Point(113, 72);
            this.labelSifre2.Name = "labelSifre2";
            this.labelSifre2.Size = new System.Drawing.Size(47, 23);
            this.labelSifre2.TabIndex = 15;
            this.labelSifre2.Text = "Şifre";
            // 
            // textBoxKullaniciAdi2
            // 
            this.textBoxKullaniciAdi2.BackColor = System.Drawing.SystemColors.Highlight;
            this.textBoxKullaniciAdi2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxKullaniciAdi2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBoxKullaniciAdi2.Font = new System.Drawing.Font("Candara", 14.25F);
            this.textBoxKullaniciAdi2.Location = new System.Drawing.Point(193, 41);
            this.textBoxKullaniciAdi2.Name = "textBoxKullaniciAdi2";
            this.textBoxKullaniciAdi2.Size = new System.Drawing.Size(100, 24);
            this.textBoxKullaniciAdi2.TabIndex = 16;
            this.textBoxKullaniciAdi2.Text = "textbox";
            this.textBoxKullaniciAdi2.Click += new System.EventHandler(this.textBox4_Click);
            // 
            // labelKullaniciAdi2
            // 
            this.labelKullaniciAdi2.AutoSize = true;
            this.labelKullaniciAdi2.BackColor = System.Drawing.Color.Transparent;
            this.labelKullaniciAdi2.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelKullaniciAdi2.ForeColor = System.Drawing.Color.White;
            this.labelKullaniciAdi2.Location = new System.Drawing.Point(55, 42);
            this.labelKullaniciAdi2.Name = "labelKullaniciAdi2";
            this.labelKullaniciAdi2.Size = new System.Drawing.Size(105, 23);
            this.labelKullaniciAdi2.TabIndex = 14;
            this.labelKullaniciAdi2.Text = "Kullanıcı Adı";
            // 
            // tablo1BindingSource
            // 
            this.tablo1BindingSource.DataMember = "Tablo1";
            // 
            // labelBolum
            // 
            this.labelBolum.AutoSize = true;
            this.labelBolum.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelBolum.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBolum.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelBolum.Location = new System.Drawing.Point(347, 30);
            this.labelBolum.Name = "labelBolum";
            this.labelBolum.Size = new System.Drawing.Size(64, 20);
            this.labelBolum.TabIndex = 23;
            this.labelBolum.Text = "[bölüm]";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelVersion.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelVersion.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelVersion.Location = new System.Drawing.Point(676, 268);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelVersion.Size = new System.Drawing.Size(61, 17);
            this.labelVersion.TabIndex = 24;
            this.labelVersion.Text = "[version]";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(756, 286);
            this.Controls.Add(this.panelKayitOl);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelGirisYap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hazır Giyim Otomasyonu - Giriş Ekranı";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelGirisYap.ResumeLayout(false);
            this.panelGirisYap.PerformLayout();
            this.panelKayitOl.ResumeLayout(false);
            this.panelKayitOl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablo1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelLogo;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.PictureBox pictureBoxMinimize;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.TextBox textBoxSifre;
        private System.Windows.Forms.TextBox textBoxKullaniciAdi;
        private System.Windows.Forms.Label labelSifre;
        private System.Windows.Forms.Label labelKullaniciAdi;
        private System.Windows.Forms.Button bttnGirisYap2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelMesaj;
        private System.Windows.Forms.Panel panelGirisYap;
        private System.Windows.Forms.Panel panelKayitOl;
        private System.Windows.Forms.Button bttnKayitOl;
        private System.Windows.Forms.Label labelMesaj2;
        private System.Windows.Forms.TextBox textBoxSifre2;
        private System.Windows.Forms.Label labelSifre2;
        private System.Windows.Forms.TextBox textBoxKullaniciAdi2;
        private System.Windows.Forms.Label labelKullaniciAdi2;
        private System.Windows.Forms.Button buttonKayitOl2;
        private System.Windows.Forms.Button buttonGirisYap;
        private System.Windows.Forms.BindingSource tablo1BindingSource;
        private System.Windows.Forms.Label labelBolum;
        private System.Windows.Forms.Label labelVersion;
    }
}