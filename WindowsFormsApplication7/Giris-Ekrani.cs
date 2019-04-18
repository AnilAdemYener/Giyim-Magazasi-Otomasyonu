using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//custom font
using System.Drawing.Text;
//veritabanı
using System.Data.OleDb;
//process
using System.Diagnostics;

namespace WindowsFormsApplication7
{
    public partial class GirisEkrani : Form
    {
        public GirisEkrani()
        {
            InitializeComponent();
        }

        private void GirisEkrani_Load(object sender, EventArgs e)
        {
            // kayıt olmayı devre dışı bırak
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("select * from program_ayarlari where ayar_id=@p1",baglanti);
            cmd.Parameters.AddWithValue("@p1","program");
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["kayit_olmayi_devre_disi_birak"].ToString()=="true")
                {
                    buttonKayitOl.Enabled = false;
                }
                else if (reader["kayit_olmayi_devre_disi_birak"].ToString() == "false")
                {
                    buttonKayitOl.Enabled = true;
                }
            }
            baglanti.Close();
            // iconlar
            pictureBoxGitHub.Visible = false;
            pictureBoxTwitter.Visible = false;
            //mesaj
            labelMesaj.Text = "";
            //font
            //PrivateFontCollection pfc = new PrivateFontCollection();
            //pfc.AddFontFile("fonts/Praktika-Light.otf");
            //foreach (Control c in this.Controls)
            //{
            //    c.Font = new Font(pfc.Families[0], 15, FontStyle.Regular);
            //    labelBaslik.Font = new Font(pfc.Families[0], 15, FontStyle.Bold);
            //    labelMesaj.Font = new Font(pfc.Families[0], 15, FontStyle.Bold);
            //    textBoxKullaniciAdi.Font = new Font(pfc.Families[0], 15, FontStyle.Bold);
            //    textBoxSifre.Font = new Font(pfc.Families[0], 15, FontStyle.Bold);
            //}
        }

        //mouse ile pencere taşıma ====================================================================================
        Point lastPoint;

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        //kapatma butonu
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //küçültme butonu
        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // giriş yap buton hover ====================================================================================
        private void buttonGirisYap_MouseEnter(object sender, EventArgs e)
        {
            buttonGirisYap.BackColor = Color.Orange;
            buttonGirisYap.ForeColor = Color.White;

            buttonKayitOl.BackColor = Color.Transparent;

            //PrivateFontCollection pfc = new PrivateFontCollection();
            //pfc.AddFontFile("fonts/Praktika-Light.otf");
            //foreach (Control c in this.Controls)
            //{
            //    buttonGirisYap.Font = new Font(pfc.Families[0], 17, FontStyle.Bold);
            //}
        }

        private void buttonGirisYap_MouseLeave(object sender, EventArgs e)
        {
            buttonGirisYap.BackColor = Color.Transparent;
            buttonGirisYap.ForeColor = Color.Black;

            buttonKayitOl.BackColor = Color.Transparent;
            buttonKayitOl.ForeColor = Color.Black;

            //PrivateFontCollection pfc = new PrivateFontCollection();
            //pfc.AddFontFile("fonts/Praktika-Light.otf");
            //foreach (Control c in this.Controls)
            //{
            //    buttonGirisYap.Font = new Font(pfc.Families[0], 15, FontStyle.Regular);
            //}
        }

        // kayıt ol buton hover ====================================================================================
        private void buttonKayitOl_MouseEnter(object sender, EventArgs e)
        {
            buttonKayitOl.BackColor = Color.Orange;
            buttonKayitOl.ForeColor = Color.White;

            buttonGirisYap.BackColor = Color.Transparent;

            //PrivateFontCollection pfc = new PrivateFontCollection();
            //pfc.AddFontFile("fonts/Praktika-Light.otf");
            //foreach (Control c in this.Controls)
            //{
            //    buttonKayitOl.Font = new Font(pfc.Families[0], 17, FontStyle.Bold);
            //}
        }

        private void buttonKayitOl_MouseLeave(object sender, EventArgs e)
        {
            buttonKayitOl.BackColor = Color.Transparent;
            buttonKayitOl.ForeColor = Color.Black;

            buttonGirisYap.BackColor = Color.Transparent;
            buttonGirisYap.ForeColor = Color.Black;

            //PrivateFontCollection pfc = new PrivateFontCollection();
            //pfc.AddFontFile("fonts/Praktika-Light.otf");
            //foreach (Control c in this.Controls)
            //{
            //    buttonKayitOl.Font = new Font(pfc.Families[0], 15, FontStyle.Regular);
            //}
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=databases/veritabani.accdb");

        //kullanıcı adı
        public static string kullanici_adi;

        //giriş yap butonu
        public void buttonGirisYap_Click(object sender, EventArgs e)
        {
            char kontrol = 'f';
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select * from kullanicilar", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (textBoxKullaniciAdi.Text == oku["kullanici_adi"].ToString() && textBoxSifre.Text == oku["sifre"].ToString())
                {
                    kontrol = 't';
                    panelTopRenk.BackColor = Color.Lime;
                    labelMesaj.ForeColor = Color.Green;
                    kullanici_adi = textBoxKullaniciAdi.Text;
                    Kontrol_Paneli kontrol_paneli = new Kontrol_Paneli();
                    this.Hide();
                    kontrol_paneli.Show();
                }
            }
            if (kontrol == 'f')
            {
                panelTopRenk.BackColor = Color.Red;
                labelMesaj.ForeColor = Color.Red;
                labelMesaj.Text = "Yanlış kullanıcı adı/şifre.";
            }
            baglanti.Close();
        }

        //kayıt ol butonu
        private void buttonKayitOl_Click(object sender, EventArgs e)
        {
            if (textBoxKullaniciAdi.TextLength > 3 && textBoxSifre.TextLength > 3)
            {
                char kontrol = 'f';
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("Select * from kullanicilar", baglanti);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    if (textBoxKullaniciAdi.Text == oku["kullanici_adi"].ToString())
                    {
                        kontrol = 't';
                        panelTopRenk.BackColor = Color.Red;
                        labelMesaj.ForeColor = Color.Red;
                        labelMesaj.Text = "Böyle bir hesap zaten kayıtlı.";
                    }
                }
                if (kontrol == 'f')
                {
                    OleDbCommand komutEkle = new OleDbCommand("insert into kullanicilar values(@kullanici_adi,@sifre,@yetki,@kullanici_resmi)", baglanti);
                    komutEkle.Parameters.AddWithValue("@kullanici_adi", textBoxKullaniciAdi.Text);
                    komutEkle.Parameters.AddWithValue("@sifre", textBoxSifre.Text);
                    komutEkle.Parameters.AddWithValue("@yetki", "normal");
                    komutEkle.Parameters.AddWithValue("@kullanici_resmi", "none");
                    komutEkle.ExecuteNonQuery();
                    panelTopRenk.BackColor = Color.Lime;
                    labelMesaj.ForeColor = Color.Green;
                    labelMesaj.Text = "Kayıt başarıyla eklendi.";
                }
                baglanti.Close();
            }
            else
            {
                panelTopRenk.BackColor = Color.Red;
                labelMesaj.ForeColor = Color.Red;
                labelMesaj.Text = "Kullanıcı adı ve şifre en az 3 karakter olmalı.";
            }
        }

        //twitter butonu
        private void pictureBoxTwitter_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/anilademyener");
        }

        //github butonu
        private void pictureBoxGitHub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/AnilAdemYener/Hazir-Giyim-Otomasyonu");
        }
    }
}
