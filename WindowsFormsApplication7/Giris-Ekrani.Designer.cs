namespace WindowsFormsApplication7
{
    partial class GirisEkrani
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisEkrani));
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBoxGitHub = new System.Windows.Forms.PictureBox();
            this.pictureBoxTwitter = new System.Windows.Forms.PictureBox();
            this.labelBaslik = new System.Windows.Forms.Label();
            this.pictureBoxMinimize = new System.Windows.Forms.PictureBox();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelTopRenk = new System.Windows.Forms.Panel();
            this.panelBottomRenk = new System.Windows.Forms.Panel();
            this.labelKullaniciAdi = new System.Windows.Forms.Label();
            this.labelSifre = new System.Windows.Forms.Label();
            this.textBoxKullaniciAdi = new System.Windows.Forms.TextBox();
            this.textBoxSifre = new System.Windows.Forms.TextBox();
            this.buttonGirisYap = new System.Windows.Forms.Button();
            this.buttonKayitOl = new System.Windows.Forms.Button();
            this.labelMesaj = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGitHub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTwitter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Black;
            this.panelTop.Controls.Add(this.pictureBoxGitHub);
            this.panelTop.Controls.Add(this.pictureBoxTwitter);
            this.panelTop.Controls.Add(this.labelBaslik);
            this.panelTop.Controls.Add(this.pictureBoxMinimize);
            this.panelTop.Controls.Add(this.pictureBoxClose);
            this.panelTop.Controls.Add(this.pictureBoxLogo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(720, 45);
            this.panelTop.TabIndex = 0;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseMove);
            // 
            // pictureBoxGitHub
            // 
            this.pictureBoxGitHub.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxGitHub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxGitHub.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxGitHub.Image")));
            this.pictureBoxGitHub.Location = new System.Drawing.Point(529, 22);
            this.pictureBoxGitHub.Name = "pictureBoxGitHub";
            this.pictureBoxGitHub.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxGitHub.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxGitHub.TabIndex = 11;
            this.pictureBoxGitHub.TabStop = false;
            this.pictureBoxGitHub.Click += new System.EventHandler(this.pictureBoxGitHub_Click);
            // 
            // pictureBoxTwitter
            // 
            this.pictureBoxTwitter.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTwitter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxTwitter.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTwitter.Image")));
            this.pictureBoxTwitter.Location = new System.Drawing.Point(503, 22);
            this.pictureBoxTwitter.Name = "pictureBoxTwitter";
            this.pictureBoxTwitter.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxTwitter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTwitter.TabIndex = 10;
            this.pictureBoxTwitter.TabStop = false;
            this.pictureBoxTwitter.Click += new System.EventHandler(this.pictureBoxTwitter_Click);
            // 
            // labelBaslik
            // 
            this.labelBaslik.AutoSize = true;
            this.labelBaslik.ForeColor = System.Drawing.Color.White;
            this.labelBaslik.Location = new System.Drawing.Point(54, 10);
            this.labelBaslik.Name = "labelBaslik";
            this.labelBaslik.Size = new System.Drawing.Size(183, 13);
            this.labelBaslik.TabIndex = 3;
            this.labelBaslik.Text = "Hazır Giyim Otomasyonu - Giriş Ekranı";
            // 
            // pictureBoxMinimize
            // 
            this.pictureBoxMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxMinimize.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMinimize.Image")));
            this.pictureBoxMinimize.Location = new System.Drawing.Point(633, 3);
            this.pictureBoxMinimize.Name = "pictureBoxMinimize";
            this.pictureBoxMinimize.Size = new System.Drawing.Size(39, 39);
            this.pictureBoxMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMinimize.TabIndex = 2;
            this.pictureBoxMinimize.TabStop = false;
            this.pictureBoxMinimize.Click += new System.EventHandler(this.pictureBoxMinimize_Click);
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.Image")));
            this.pictureBoxClose.Location = new System.Drawing.Point(678, 3);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(39, 39);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxClose.TabIndex = 1;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(45, 39);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // panelTopRenk
            // 
            this.panelTopRenk.BackColor = System.Drawing.Color.Orange;
            this.panelTopRenk.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopRenk.Location = new System.Drawing.Point(0, 0);
            this.panelTopRenk.Name = "panelTopRenk";
            this.panelTopRenk.Size = new System.Drawing.Size(720, 3);
            this.panelTopRenk.TabIndex = 1;
            // 
            // panelBottomRenk
            // 
            this.panelBottomRenk.BackColor = System.Drawing.Color.DodgerBlue;
            this.panelBottomRenk.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomRenk.Location = new System.Drawing.Point(0, 384);
            this.panelBottomRenk.Name = "panelBottomRenk";
            this.panelBottomRenk.Size = new System.Drawing.Size(720, 3);
            this.panelBottomRenk.TabIndex = 2;
            // 
            // labelKullaniciAdi
            // 
            this.labelKullaniciAdi.AutoSize = true;
            this.labelKullaniciAdi.BackColor = System.Drawing.Color.Transparent;
            this.labelKullaniciAdi.Location = new System.Drawing.Point(12, 150);
            this.labelKullaniciAdi.Name = "labelKullaniciAdi";
            this.labelKullaniciAdi.Size = new System.Drawing.Size(64, 13);
            this.labelKullaniciAdi.TabIndex = 3;
            this.labelKullaniciAdi.Text = "Kullanıcı A‍dı";
            // 
            // labelSifre
            // 
            this.labelSifre.AutoSize = true;
            this.labelSifre.BackColor = System.Drawing.Color.Transparent;
            this.labelSifre.Location = new System.Drawing.Point(48, 183);
            this.labelSifre.Name = "labelSifre";
            this.labelSifre.Size = new System.Drawing.Size(28, 13);
            this.labelSifre.TabIndex = 4;
            this.labelSifre.Text = "Şifre";
            // 
            // textBoxKullaniciAdi
            // 
            this.textBoxKullaniciAdi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxKullaniciAdi.Location = new System.Drawing.Point(130, 150);
            this.textBoxKullaniciAdi.Name = "textBoxKullaniciAdi";
            this.textBoxKullaniciAdi.Size = new System.Drawing.Size(205, 13);
            this.textBoxKullaniciAdi.TabIndex = 5;
            // 
            // textBoxSifre
            // 
            this.textBoxSifre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSifre.Location = new System.Drawing.Point(130, 183);
            this.textBoxSifre.Name = "textBoxSifre";
            this.textBoxSifre.Size = new System.Drawing.Size(205, 13);
            this.textBoxSifre.TabIndex = 6;
            this.textBoxSifre.UseSystemPasswordChar = true;
            // 
            // buttonGirisYap
            // 
            this.buttonGirisYap.BackColor = System.Drawing.Color.Transparent;
            this.buttonGirisYap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGirisYap.FlatAppearance.BorderSize = 0;
            this.buttonGirisYap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGirisYap.Location = new System.Drawing.Point(444, 54);
            this.buttonGirisYap.Name = "buttonGirisYap";
            this.buttonGirisYap.Size = new System.Drawing.Size(264, 155);
            this.buttonGirisYap.TabIndex = 7;
            this.buttonGirisYap.Text = "Giriş Yap";
            this.buttonGirisYap.UseVisualStyleBackColor = false;
            this.buttonGirisYap.Click += new System.EventHandler(this.buttonGirisYap_Click);
            this.buttonGirisYap.MouseEnter += new System.EventHandler(this.buttonGirisYap_MouseEnter);
            this.buttonGirisYap.MouseLeave += new System.EventHandler(this.buttonGirisYap_MouseLeave);
            // 
            // buttonKayitOl
            // 
            this.buttonKayitOl.BackColor = System.Drawing.Color.Transparent;
            this.buttonKayitOl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonKayitOl.FlatAppearance.BorderSize = 0;
            this.buttonKayitOl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKayitOl.Location = new System.Drawing.Point(444, 220);
            this.buttonKayitOl.Name = "buttonKayitOl";
            this.buttonKayitOl.Size = new System.Drawing.Size(264, 155);
            this.buttonKayitOl.TabIndex = 8;
            this.buttonKayitOl.Text = "Kayıt Ol";
            this.buttonKayitOl.UseVisualStyleBackColor = false;
            this.buttonKayitOl.Click += new System.EventHandler(this.buttonKayitOl_Click);
            this.buttonKayitOl.MouseEnter += new System.EventHandler(this.buttonKayitOl_MouseEnter);
            this.buttonKayitOl.MouseLeave += new System.EventHandler(this.buttonKayitOl_MouseLeave);
            // 
            // labelMesaj
            // 
            this.labelMesaj.AutoSize = true;
            this.labelMesaj.BackColor = System.Drawing.Color.Transparent;
            this.labelMesaj.Location = new System.Drawing.Point(14, 344);
            this.labelMesaj.Name = "labelMesaj";
            this.labelMesaj.Size = new System.Drawing.Size(35, 13);
            this.labelMesaj.TabIndex = 9;
            this.labelMesaj.Text = "Mesaj";
            // 
            // GirisEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(720, 387);
            this.Controls.Add(this.labelMesaj);
            this.Controls.Add(this.buttonKayitOl);
            this.Controls.Add(this.buttonGirisYap);
            this.Controls.Add(this.textBoxSifre);
            this.Controls.Add(this.textBoxKullaniciAdi);
            this.Controls.Add(this.labelSifre);
            this.Controls.Add(this.labelKullaniciAdi);
            this.Controls.Add(this.panelBottomRenk);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelTopRenk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GirisEkrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hazır Giyim Otomasyonu - Giriş Ekranı";
            this.Load += new System.EventHandler(this.GirisEkrani_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGitHub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTwitter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.PictureBox pictureBoxMinimize;
        private System.Windows.Forms.Panel panelTopRenk;
        private System.Windows.Forms.Panel panelBottomRenk;
        private System.Windows.Forms.Label labelBaslik;
        private System.Windows.Forms.Label labelKullaniciAdi;
        private System.Windows.Forms.Label labelSifre;
        private System.Windows.Forms.TextBox textBoxKullaniciAdi;
        private System.Windows.Forms.TextBox textBoxSifre;
        private System.Windows.Forms.Button buttonGirisYap;
        private System.Windows.Forms.Button buttonKayitOl;
        private System.Windows.Forms.Label labelMesaj;
        private System.Windows.Forms.PictureBox pictureBoxTwitter;
        private System.Windows.Forms.PictureBox pictureBoxGitHub;
    }
}

