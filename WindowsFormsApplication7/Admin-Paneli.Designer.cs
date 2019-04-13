namespace WindowsFormsApplication7
{
    partial class Admin_Paneli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_Paneli));
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTopRenk = new System.Windows.Forms.Panel();
            this.labelBaslik = new System.Windows.Forms.Label();
            this.pictureBoxMinimize = new System.Windows.Forms.PictureBox();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelBottomRenk = new System.Windows.Forms.Panel();
            this.labelMesaj = new System.Windows.Forms.Label();
            this.buttonCikisYap = new System.Windows.Forms.Button();
            this.labelKullaniciAdi = new System.Windows.Forms.Label();
            this.buttonKullaniciEkleSil = new System.Windows.Forms.Button();
            this.panelKullaniciEkleSil = new System.Windows.Forms.Panel();
            this.buttonKayitEkleSil = new System.Windows.Forms.Button();
            this.panelKayitEkleSil = new System.Windows.Forms.Panel();
            this.dataGridViewKayitEkleSil = new System.Windows.Forms.DataGridView();
            this.dataGridViewKullaniciEkleSil = new System.Windows.Forms.DataGridView();
            this.buttonKullaniciSil = new System.Windows.Forms.Button();
            this.buttonKullaniciGuncelle = new System.Windows.Forms.Button();
            this.buttonKullaniciEkle = new System.Windows.Forms.Button();
            this.buttonTumKullanicilariSil = new System.Windows.Forms.Button();
            this.textBoxKullaniciEkleSilAdi = new System.Windows.Forms.TextBox();
            this.labelKullaniciEkleSilAdi = new System.Windows.Forms.Label();
            this.textBoxKullaniciEkleSilSifresi = new System.Windows.Forms.TextBox();
            this.labelKullaniciEkleSilSifresi = new System.Windows.Forms.Label();
            this.checkBoxKullaniciEkleSilYetkisi = new System.Windows.Forms.CheckBox();
            this.textBoxKullaniciEkleSilAra = new System.Windows.Forms.TextBox();
            this.labelKullaniciEkleSilAra = new System.Windows.Forms.Label();
            this.buttonKullaniciEkleSilAra = new System.Windows.Forms.Button();
            this.buttonKayitEkleSilTumKayitlar = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelKullaniciEkleSil.SuspendLayout();
            this.panelKayitEkleSil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKayitEkleSil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKullaniciEkleSil)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Black;
            this.panelTop.Controls.Add(this.labelKullaniciAdi);
            this.panelTop.Controls.Add(this.panelTopRenk);
            this.panelTop.Controls.Add(this.labelBaslik);
            this.panelTop.Controls.Add(this.pictureBoxMinimize);
            this.panelTop.Controls.Add(this.pictureBoxClose);
            this.panelTop.Controls.Add(this.pictureBoxLogo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(979, 45);
            this.panelTop.TabIndex = 1;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseMove);
            // 
            // panelTopRenk
            // 
            this.panelTopRenk.BackColor = System.Drawing.Color.Orange;
            this.panelTopRenk.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopRenk.Location = new System.Drawing.Point(0, 0);
            this.panelTopRenk.Name = "panelTopRenk";
            this.panelTopRenk.Size = new System.Drawing.Size(979, 3);
            this.panelTopRenk.TabIndex = 12;
            // 
            // labelBaslik
            // 
            this.labelBaslik.AutoSize = true;
            this.labelBaslik.ForeColor = System.Drawing.Color.White;
            this.labelBaslik.Location = new System.Drawing.Point(54, 11);
            this.labelBaslik.Name = "labelBaslik";
            this.labelBaslik.Size = new System.Drawing.Size(212, 13);
            this.labelBaslik.TabIndex = 3;
            this.labelBaslik.Text = "Giyim Mağazası Otomasyonu - Admin Paneli";
            // 
            // pictureBoxMinimize
            // 
            this.pictureBoxMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxMinimize.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMinimize.Image")));
            this.pictureBoxMinimize.Location = new System.Drawing.Point(892, 3);
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
            this.pictureBoxClose.Location = new System.Drawing.Point(937, 3);
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
            // panelBottomRenk
            // 
            this.panelBottomRenk.BackColor = System.Drawing.Color.DodgerBlue;
            this.panelBottomRenk.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomRenk.Location = new System.Drawing.Point(0, 662);
            this.panelBottomRenk.Name = "panelBottomRenk";
            this.panelBottomRenk.Size = new System.Drawing.Size(979, 3);
            this.panelBottomRenk.TabIndex = 3;
            // 
            // labelMesaj
            // 
            this.labelMesaj.AutoSize = true;
            this.labelMesaj.BackColor = System.Drawing.Color.Transparent;
            this.labelMesaj.Location = new System.Drawing.Point(108, 628);
            this.labelMesaj.Name = "labelMesaj";
            this.labelMesaj.Size = new System.Drawing.Size(35, 13);
            this.labelMesaj.TabIndex = 29;
            this.labelMesaj.Text = "Mesaj";
            // 
            // buttonCikisYap
            // 
            this.buttonCikisYap.BackColor = System.Drawing.Color.Red;
            this.buttonCikisYap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCikisYap.FlatAppearance.BorderSize = 0;
            this.buttonCikisYap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCikisYap.ForeColor = System.Drawing.Color.White;
            this.buttonCikisYap.Location = new System.Drawing.Point(847, 628);
            this.buttonCikisYap.Name = "buttonCikisYap";
            this.buttonCikisYap.Size = new System.Drawing.Size(132, 34);
            this.buttonCikisYap.TabIndex = 30;
            this.buttonCikisYap.Text = "Çıkış Yap";
            this.buttonCikisYap.UseVisualStyleBackColor = false;
            this.buttonCikisYap.Click += new System.EventHandler(this.ButtonCikisYap_Click);
            // 
            // labelKullaniciAdi
            // 
            this.labelKullaniciAdi.AutoSize = true;
            this.labelKullaniciAdi.ForeColor = System.Drawing.Color.White;
            this.labelKullaniciAdi.Location = new System.Drawing.Point(507, 9);
            this.labelKullaniciAdi.Name = "labelKullaniciAdi";
            this.labelKullaniciAdi.Size = new System.Drawing.Size(64, 13);
            this.labelKullaniciAdi.TabIndex = 14;
            this.labelKullaniciAdi.Text = "Kullanıcı Adı";
            // 
            // buttonKullaniciEkleSil
            // 
            this.buttonKullaniciEkleSil.BackColor = System.Drawing.Color.Orange;
            this.buttonKullaniciEkleSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonKullaniciEkleSil.FlatAppearance.BorderSize = 0;
            this.buttonKullaniciEkleSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKullaniciEkleSil.ForeColor = System.Drawing.Color.White;
            this.buttonKullaniciEkleSil.Location = new System.Drawing.Point(0, 45);
            this.buttonKullaniciEkleSil.Name = "buttonKullaniciEkleSil";
            this.buttonKullaniciEkleSil.Size = new System.Drawing.Size(322, 50);
            this.buttonKullaniciEkleSil.TabIndex = 31;
            this.buttonKullaniciEkleSil.Text = "Kullanıcı Ekle/Sil";
            this.buttonKullaniciEkleSil.UseVisualStyleBackColor = false;
            this.buttonKullaniciEkleSil.Click += new System.EventHandler(this.ButtonKullaniciEkleSil_Click);
            // 
            // panelKullaniciEkleSil
            // 
            this.panelKullaniciEkleSil.BackColor = System.Drawing.Color.Transparent;
            this.panelKullaniciEkleSil.Controls.Add(this.buttonKayitEkleSilTumKayitlar);
            this.panelKullaniciEkleSil.Controls.Add(this.buttonKullaniciEkleSilAra);
            this.panelKullaniciEkleSil.Controls.Add(this.textBoxKullaniciEkleSilAra);
            this.panelKullaniciEkleSil.Controls.Add(this.labelKullaniciEkleSilAra);
            this.panelKullaniciEkleSil.Controls.Add(this.checkBoxKullaniciEkleSilYetkisi);
            this.panelKullaniciEkleSil.Controls.Add(this.textBoxKullaniciEkleSilSifresi);
            this.panelKullaniciEkleSil.Controls.Add(this.labelKullaniciEkleSilSifresi);
            this.panelKullaniciEkleSil.Controls.Add(this.textBoxKullaniciEkleSilAdi);
            this.panelKullaniciEkleSil.Controls.Add(this.labelKullaniciEkleSilAdi);
            this.panelKullaniciEkleSil.Controls.Add(this.buttonTumKullanicilariSil);
            this.panelKullaniciEkleSil.Controls.Add(this.buttonKullaniciSil);
            this.panelKullaniciEkleSil.Controls.Add(this.buttonKullaniciGuncelle);
            this.panelKullaniciEkleSil.Controls.Add(this.buttonKullaniciEkle);
            this.panelKullaniciEkleSil.Controls.Add(this.dataGridViewKullaniciEkleSil);
            this.panelKullaniciEkleSil.Location = new System.Drawing.Point(12, 101);
            this.panelKullaniciEkleSil.Name = "panelKullaniciEkleSil";
            this.panelKullaniciEkleSil.Size = new System.Drawing.Size(955, 521);
            this.panelKullaniciEkleSil.TabIndex = 32;
            // 
            // buttonKayitEkleSil
            // 
            this.buttonKayitEkleSil.BackColor = System.Drawing.Color.Orange;
            this.buttonKayitEkleSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonKayitEkleSil.FlatAppearance.BorderSize = 0;
            this.buttonKayitEkleSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKayitEkleSil.ForeColor = System.Drawing.Color.White;
            this.buttonKayitEkleSil.Location = new System.Drawing.Point(322, 45);
            this.buttonKayitEkleSil.Name = "buttonKayitEkleSil";
            this.buttonKayitEkleSil.Size = new System.Drawing.Size(657, 50);
            this.buttonKayitEkleSil.TabIndex = 33;
            this.buttonKayitEkleSil.Text = "Kayıt Ekle/Sil";
            this.buttonKayitEkleSil.UseVisualStyleBackColor = false;
            this.buttonKayitEkleSil.Click += new System.EventHandler(this.ButtonKayitEkleSil_Click);
            // 
            // panelKayitEkleSil
            // 
            this.panelKayitEkleSil.BackColor = System.Drawing.Color.Transparent;
            this.panelKayitEkleSil.Controls.Add(this.dataGridViewKayitEkleSil);
            this.panelKayitEkleSil.Location = new System.Drawing.Point(12, 101);
            this.panelKayitEkleSil.Name = "panelKayitEkleSil";
            this.panelKayitEkleSil.Size = new System.Drawing.Size(955, 521);
            this.panelKayitEkleSil.TabIndex = 33;
            // 
            // dataGridViewKayitEkleSil
            // 
            this.dataGridViewKayitEkleSil.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewKayitEkleSil.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewKayitEkleSil.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewKayitEkleSil.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewKayitEkleSil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKayitEkleSil.Location = new System.Drawing.Point(309, 90);
            this.dataGridViewKayitEkleSil.Name = "dataGridViewKayitEkleSil";
            this.dataGridViewKayitEkleSil.Size = new System.Drawing.Size(643, 357);
            this.dataGridViewKayitEkleSil.TabIndex = 1;
            // 
            // dataGridViewKullaniciEkleSil
            // 
            this.dataGridViewKullaniciEkleSil.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewKullaniciEkleSil.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewKullaniciEkleSil.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewKullaniciEkleSil.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewKullaniciEkleSil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKullaniciEkleSil.Location = new System.Drawing.Point(381, 3);
            this.dataGridViewKullaniciEkleSil.Name = "dataGridViewKullaniciEkleSil";
            this.dataGridViewKullaniciEkleSil.Size = new System.Drawing.Size(571, 515);
            this.dataGridViewKullaniciEkleSil.TabIndex = 2;
            this.dataGridViewKullaniciEkleSil.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewKullaniciEkleSil_CellClick);
            // 
            // buttonKullaniciSil
            // 
            this.buttonKullaniciSil.BackColor = System.Drawing.Color.Orange;
            this.buttonKullaniciSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonKullaniciSil.FlatAppearance.BorderSize = 0;
            this.buttonKullaniciSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKullaniciSil.ForeColor = System.Drawing.Color.White;
            this.buttonKullaniciSil.Image = ((System.Drawing.Image)(resources.GetObject("buttonKullaniciSil.Image")));
            this.buttonKullaniciSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonKullaniciSil.Location = new System.Drawing.Point(266, 396);
            this.buttonKullaniciSil.Name = "buttonKullaniciSil";
            this.buttonKullaniciSil.Size = new System.Drawing.Size(77, 51);
            this.buttonKullaniciSil.TabIndex = 31;
            this.buttonKullaniciSil.Text = "Sil";
            this.buttonKullaniciSil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonKullaniciSil.UseVisualStyleBackColor = false;
            this.buttonKullaniciSil.Click += new System.EventHandler(this.ButtonKullaniciSil_Click);
            // 
            // buttonKullaniciGuncelle
            // 
            this.buttonKullaniciGuncelle.BackColor = System.Drawing.Color.Orange;
            this.buttonKullaniciGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonKullaniciGuncelle.FlatAppearance.BorderSize = 0;
            this.buttonKullaniciGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKullaniciGuncelle.ForeColor = System.Drawing.Color.White;
            this.buttonKullaniciGuncelle.Image = ((System.Drawing.Image)(resources.GetObject("buttonKullaniciGuncelle.Image")));
            this.buttonKullaniciGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonKullaniciGuncelle.Location = new System.Drawing.Point(128, 396);
            this.buttonKullaniciGuncelle.Name = "buttonKullaniciGuncelle";
            this.buttonKullaniciGuncelle.Size = new System.Drawing.Size(138, 51);
            this.buttonKullaniciGuncelle.TabIndex = 30;
            this.buttonKullaniciGuncelle.Text = "Güncelle";
            this.buttonKullaniciGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonKullaniciGuncelle.UseVisualStyleBackColor = false;
            this.buttonKullaniciGuncelle.Click += new System.EventHandler(this.ButtonKullaniciGuncelle_Click);
            // 
            // buttonKullaniciEkle
            // 
            this.buttonKullaniciEkle.BackColor = System.Drawing.Color.Orange;
            this.buttonKullaniciEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonKullaniciEkle.FlatAppearance.BorderSize = 0;
            this.buttonKullaniciEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKullaniciEkle.ForeColor = System.Drawing.Color.White;
            this.buttonKullaniciEkle.Image = ((System.Drawing.Image)(resources.GetObject("buttonKullaniciEkle.Image")));
            this.buttonKullaniciEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonKullaniciEkle.Location = new System.Drawing.Point(31, 396);
            this.buttonKullaniciEkle.Name = "buttonKullaniciEkle";
            this.buttonKullaniciEkle.Size = new System.Drawing.Size(100, 51);
            this.buttonKullaniciEkle.TabIndex = 29;
            this.buttonKullaniciEkle.Text = "Ekle";
            this.buttonKullaniciEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonKullaniciEkle.UseVisualStyleBackColor = false;
            this.buttonKullaniciEkle.Click += new System.EventHandler(this.ButtonKullaniciEkle_Click);
            // 
            // buttonTumKullanicilariSil
            // 
            this.buttonTumKullanicilariSil.BackColor = System.Drawing.Color.Orange;
            this.buttonTumKullanicilariSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTumKullanicilariSil.FlatAppearance.BorderSize = 0;
            this.buttonTumKullanicilariSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTumKullanicilariSil.ForeColor = System.Drawing.Color.White;
            this.buttonTumKullanicilariSil.Image = ((System.Drawing.Image)(resources.GetObject("buttonTumKullanicilariSil.Image")));
            this.buttonTumKullanicilariSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTumKullanicilariSil.Location = new System.Drawing.Point(31, 447);
            this.buttonTumKullanicilariSil.Name = "buttonTumKullanicilariSil";
            this.buttonTumKullanicilariSil.Size = new System.Drawing.Size(312, 51);
            this.buttonTumKullanicilariSil.TabIndex = 32;
            this.buttonTumKullanicilariSil.Text = "Tüm Kullanıcıları Sil";
            this.buttonTumKullanicilariSil.UseVisualStyleBackColor = false;
            this.buttonTumKullanicilariSil.Click += new System.EventHandler(this.ButtonTumKullanicilariSil_Click);
            // 
            // textBoxKullaniciEkleSilAdi
            // 
            this.textBoxKullaniciEkleSilAdi.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxKullaniciEkleSilAdi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxKullaniciEkleSilAdi.Location = new System.Drawing.Point(163, 236);
            this.textBoxKullaniciEkleSilAdi.Multiline = true;
            this.textBoxKullaniciEkleSilAdi.Name = "textBoxKullaniciEkleSilAdi";
            this.textBoxKullaniciEkleSilAdi.Size = new System.Drawing.Size(180, 25);
            this.textBoxKullaniciEkleSilAdi.TabIndex = 34;
            // 
            // labelKullaniciEkleSilAdi
            // 
            this.labelKullaniciEkleSilAdi.AutoSize = true;
            this.labelKullaniciEkleSilAdi.Location = new System.Drawing.Point(17, 236);
            this.labelKullaniciEkleSilAdi.Name = "labelKullaniciEkleSilAdi";
            this.labelKullaniciEkleSilAdi.Size = new System.Drawing.Size(64, 13);
            this.labelKullaniciEkleSilAdi.TabIndex = 33;
            this.labelKullaniciEkleSilAdi.Text = "Kullanıcı Adı";
            // 
            // textBoxKullaniciEkleSilSifresi
            // 
            this.textBoxKullaniciEkleSilSifresi.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxKullaniciEkleSilSifresi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxKullaniciEkleSilSifresi.Location = new System.Drawing.Point(163, 267);
            this.textBoxKullaniciEkleSilSifresi.Multiline = true;
            this.textBoxKullaniciEkleSilSifresi.Name = "textBoxKullaniciEkleSilSifresi";
            this.textBoxKullaniciEkleSilSifresi.Size = new System.Drawing.Size(180, 25);
            this.textBoxKullaniciEkleSilSifresi.TabIndex = 36;
            // 
            // labelKullaniciEkleSilSifresi
            // 
            this.labelKullaniciEkleSilSifresi.AutoSize = true;
            this.labelKullaniciEkleSilSifresi.Location = new System.Drawing.Point(17, 267);
            this.labelKullaniciEkleSilSifresi.Name = "labelKullaniciEkleSilSifresi";
            this.labelKullaniciEkleSilSifresi.Size = new System.Drawing.Size(77, 13);
            this.labelKullaniciEkleSilSifresi.TabIndex = 35;
            this.labelKullaniciEkleSilSifresi.Text = "Kullanıcı Şifresi";
            // 
            // checkBoxKullaniciEkleSilYetkisi
            // 
            this.checkBoxKullaniciEkleSilYetkisi.AutoSize = true;
            this.checkBoxKullaniciEkleSilYetkisi.Location = new System.Drawing.Point(163, 298);
            this.checkBoxKullaniciEkleSilYetkisi.Name = "checkBoxKullaniciEkleSilYetkisi";
            this.checkBoxKullaniciEkleSilYetkisi.Size = new System.Drawing.Size(55, 17);
            this.checkBoxKullaniciEkleSilYetkisi.TabIndex = 37;
            this.checkBoxKullaniciEkleSilYetkisi.Text = "Admin";
            this.checkBoxKullaniciEkleSilYetkisi.UseVisualStyleBackColor = true;
            // 
            // textBoxKullaniciEkleSilAra
            // 
            this.textBoxKullaniciEkleSilAra.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxKullaniciEkleSilAra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxKullaniciEkleSilAra.Location = new System.Drawing.Point(163, 118);
            this.textBoxKullaniciEkleSilAra.Multiline = true;
            this.textBoxKullaniciEkleSilAra.Name = "textBoxKullaniciEkleSilAra";
            this.textBoxKullaniciEkleSilAra.Size = new System.Drawing.Size(180, 25);
            this.textBoxKullaniciEkleSilAra.TabIndex = 39;
            // 
            // labelKullaniciEkleSilAra
            // 
            this.labelKullaniciEkleSilAra.AutoSize = true;
            this.labelKullaniciEkleSilAra.Location = new System.Drawing.Point(17, 118);
            this.labelKullaniciEkleSilAra.Name = "labelKullaniciEkleSilAra";
            this.labelKullaniciEkleSilAra.Size = new System.Drawing.Size(64, 13);
            this.labelKullaniciEkleSilAra.TabIndex = 38;
            this.labelKullaniciEkleSilAra.Text = "Kullanıcı Adı";
            // 
            // buttonKullaniciEkleSilAra
            // 
            this.buttonKullaniciEkleSilAra.BackColor = System.Drawing.Color.Orange;
            this.buttonKullaniciEkleSilAra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonKullaniciEkleSilAra.FlatAppearance.BorderSize = 0;
            this.buttonKullaniciEkleSilAra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKullaniciEkleSilAra.ForeColor = System.Drawing.Color.White;
            this.buttonKullaniciEkleSilAra.Location = new System.Drawing.Point(220, 149);
            this.buttonKullaniciEkleSilAra.Name = "buttonKullaniciEkleSilAra";
            this.buttonKullaniciEkleSilAra.Size = new System.Drawing.Size(123, 43);
            this.buttonKullaniciEkleSilAra.TabIndex = 40;
            this.buttonKullaniciEkleSilAra.Text = "Ara";
            this.buttonKullaniciEkleSilAra.UseVisualStyleBackColor = false;
            this.buttonKullaniciEkleSilAra.Click += new System.EventHandler(this.ButtonKullaniciEkleSilAra_Click);
            // 
            // buttonKayitEkleSilTumKayitlar
            // 
            this.buttonKayitEkleSilTumKayitlar.BackColor = System.Drawing.Color.Orange;
            this.buttonKayitEkleSilTumKayitlar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonKayitEkleSilTumKayitlar.FlatAppearance.BorderSize = 0;
            this.buttonKayitEkleSilTumKayitlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKayitEkleSilTumKayitlar.ForeColor = System.Drawing.Color.White;
            this.buttonKayitEkleSilTumKayitlar.Location = new System.Drawing.Point(20, 149);
            this.buttonKayitEkleSilTumKayitlar.Name = "buttonKayitEkleSilTumKayitlar";
            this.buttonKayitEkleSilTumKayitlar.Size = new System.Drawing.Size(200, 43);
            this.buttonKayitEkleSilTumKayitlar.TabIndex = 41;
            this.buttonKayitEkleSilTumKayitlar.Text = "Tüm Kayıtlar";
            this.buttonKayitEkleSilTumKayitlar.UseVisualStyleBackColor = false;
            this.buttonKayitEkleSilTumKayitlar.Click += new System.EventHandler(this.ButtonKayitEkleSilTumKayitlar_Click);
            // 
            // Admin_Paneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(979, 665);
            this.Controls.Add(this.buttonKayitEkleSil);
            this.Controls.Add(this.buttonKullaniciEkleSil);
            this.Controls.Add(this.buttonCikisYap);
            this.Controls.Add(this.labelMesaj);
            this.Controls.Add(this.panelBottomRenk);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelKullaniciEkleSil);
            this.Controls.Add(this.panelKayitEkleSil);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Admin_Paneli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hazır Giyim Otomasyonu - Kontrol Paneli";
            this.Load += new System.EventHandler(this.Admin_Paneli_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelKullaniciEkleSil.ResumeLayout(false);
            this.panelKullaniciEkleSil.PerformLayout();
            this.panelKayitEkleSil.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKayitEkleSil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKullaniciEkleSil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelBaslik;
        private System.Windows.Forms.PictureBox pictureBoxMinimize;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Panel panelTopRenk;
        private System.Windows.Forms.Panel panelBottomRenk;
        private System.Windows.Forms.Label labelMesaj;
        private System.Windows.Forms.Button buttonCikisYap;
        private System.Windows.Forms.Label labelKullaniciAdi;
        private System.Windows.Forms.Button buttonKullaniciEkleSil;
        private System.Windows.Forms.Panel panelKullaniciEkleSil;
        private System.Windows.Forms.Button buttonKayitEkleSil;
        private System.Windows.Forms.Panel panelKayitEkleSil;
        private System.Windows.Forms.DataGridView dataGridViewKullaniciEkleSil;
        private System.Windows.Forms.DataGridView dataGridViewKayitEkleSil;
        private System.Windows.Forms.Button buttonKullaniciSil;
        private System.Windows.Forms.Button buttonKullaniciGuncelle;
        private System.Windows.Forms.Button buttonKullaniciEkle;
        private System.Windows.Forms.Button buttonTumKullanicilariSil;
        private System.Windows.Forms.CheckBox checkBoxKullaniciEkleSilYetkisi;
        private System.Windows.Forms.TextBox textBoxKullaniciEkleSilSifresi;
        private System.Windows.Forms.Label labelKullaniciEkleSilSifresi;
        private System.Windows.Forms.TextBox textBoxKullaniciEkleSilAdi;
        private System.Windows.Forms.Label labelKullaniciEkleSilAdi;
        private System.Windows.Forms.TextBox textBoxKullaniciEkleSilAra;
        private System.Windows.Forms.Label labelKullaniciEkleSilAra;
        private System.Windows.Forms.Button buttonKullaniciEkleSilAra;
        private System.Windows.Forms.Button buttonKayitEkleSilTumKayitlar;
    }
}