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
//process
using System.Diagnostics;
//veritabanı
using System.Data.OleDb;
//
using System.IO;

namespace WindowsFormsApplication7
{
    public partial class Kullanici_Ayarlari : Form
    {
        public Kullanici_Ayarlari()
        {
            InitializeComponent();
        }

        GirisEkrani giris_ekrani = new GirisEkrani();

        // veritabanı
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=databases/veritabani.accdb");

        private void Kullanici_Ayarlari_Load(object sender, EventArgs e)
        {
            labelKullaniciAdi.Text = "Hoşgeldiniz sayın " + GirisEkrani.kullanici_adi + ".";
            labelMesaj.Text = "";
            textBoxKullaniciAyarlariKullaniciAdi.Enabled = false;
            textBoxKullaniciAyarlariKullaniciAdi.Text = GirisEkrani.kullanici_adi;
            // kullanıcı resmi
            cnn.Open();
            OleDbCommand cmdKullaniciResmi = new OleDbCommand("select * from kullanicilar where kullanici_adi='" + GirisEkrani.kullanici_adi + "'", cnn);
            OleDbDataReader readerKullaniciResmi = cmdKullaniciResmi.ExecuteReader();
            while (readerKullaniciResmi.Read())
            {
                textBoxKullaniciAyarlariSifre.UseSystemPasswordChar = true;
                textBoxKullaniciAyarlariSifre.Text = readerKullaniciResmi["sifre"].ToString();
                if (readerKullaniciResmi["kullanici_resmi"].ToString() == "none")
                {
                    kullaniciResimKontrol = false;
                    pictureBoxKullaniciResmi.Image = null;
                    pictureBoxKullaniciAyarlariKullaniciResmi.Image = null;
                }
                else
                {
                    kullaniciResimKontrol = true;
                    pictureBoxKullaniciResmi.Image = Image.FromFile("kullanicilar/" + readerKullaniciResmi["kullanici_resmi"].ToString());
                    pictureBoxKullaniciAyarlariKullaniciResmi.Image = Image.FromFile("kullanicilar/" + readerKullaniciResmi["kullanici_resmi"].ToString());
                }
            }
            cnn.Close();
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

        // çıkış yap
        private void ButtonCikisYap_Click(object sender, EventArgs e)
        {
            this.Hide();
            giris_ekrani.Show();
        }

        // kontrol paneli
        private void ButtonKontrolPaneli_Click(object sender, EventArgs e)
        {
            Kontrol_Paneli kontrolPaneli = new Kontrol_Paneli();
            this.Hide();
            kontrolPaneli.Show();
        }

        // şifreyi aç / kapat
        private void ButtonKullaniciAyarlariSifreyiAcKapat_Click(object sender, EventArgs e)
        {
            if (textBoxKullaniciAyarlariSifre.UseSystemPasswordChar == true)
            {
                textBoxKullaniciAyarlariSifre.UseSystemPasswordChar = false;
            }
            else if (textBoxKullaniciAyarlariSifre.UseSystemPasswordChar == false)
            {
                textBoxKullaniciAyarlariSifre.UseSystemPasswordChar = true;
            }
        }

        public string kullaniciResim;
        public Boolean kullaniciResimKontrol = false;

        // resim seç
        private void ButtonKullaniciAyarlariResimSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "JPG Resim(.jpg)|*.jpg";
            if (file.ShowDialog() == DialogResult.OK)
            {
                kullaniciResimKontrol = true;
                kullaniciResim = file.FileName;
            }
            else
            {
                kullaniciResimKontrol = false;
            }
        }

        // resim kaydet
        private void ButtonKullaniciAyarlariResimKaydet_Click(object sender, EventArgs e)
        {
            cnn.Open();
            OleDbCommand cmdTarih = new OleDbCommand("select Format(now(), 'ddMMyyy-hhmmss') as tarih", cnn);
            OleDbDataReader readerTarih = cmdTarih.ExecuteReader();
            while (readerTarih.Read())
            {
                if (kullaniciResimKontrol == true)
                {
                    File.Copy(kullaniciResim, "kullanicilar/" + readerTarih["tarih"].ToString() + "_" + "kullanici" + ".jpg");
                    OleDbCommand cmdUpdate = new OleDbCommand("update kullanicilar set kullanici_resmi=@p1 where kullanici_adi='"+GirisEkrani.kullanici_adi+"'", cnn);
                    cmdUpdate.Parameters.AddWithValue("@p1", readerTarih["tarih"].ToString() + "_" + "kullanici" + ".jpg");
                    cmdUpdate.ExecuteNonQuery();
                    panelTopRenk.BackColor = Color.Lime;
                    labelMesaj.ForeColor = Color.Green;
                    labelMesaj.Text = "Yeni resminiz başarıyla yüklendi!";
                    OleDbCommand cmdResimUpdate = new OleDbCommand("select * from kullanicilar where kullanici_adi='" + GirisEkrani.kullanici_adi + "'", cnn);
                    OleDbDataReader readerResimUpdate = cmdResimUpdate.ExecuteReader();
                    while (readerResimUpdate.Read())
                    {
                        pictureBoxKullaniciResmi.Image = Image.FromFile("kullanicilar/" + readerResimUpdate["kullanici_resmi"].ToString());
                        pictureBoxKullaniciAyarlariKullaniciResmi.Image = Image.FromFile("kullanicilar/" + readerResimUpdate["kullanici_resmi"].ToString());
                    }
                }
                else if (kullaniciResimKontrol == false)
                {
                    panelTopRenk.BackColor = Color.Red;
                    labelMesaj.ForeColor = Color.Red;
                    labelMesaj.Text = "Önce bir resim yüklemeniz gerek!";
                }
            }
            cnn.Close();
        }

        // resim sil
        private void ButtonKullaniciAyarlariResimSil_Click(object sender, EventArgs e)
        {
            if (kullaniciResimKontrol == true)
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("update kullanicilar set kullanici_resmi='none' where kullanici_adi='" + GirisEkrani.kullanici_adi + "'", cnn);
                cmd.ExecuteNonQuery();
                pictureBoxKullaniciResmi.Image = null;
                pictureBoxKullaniciAyarlariKullaniciResmi.Image = null;
                //cnn.Close();
                panelTopRenk.BackColor = Color.Lime;
                labelMesaj.ForeColor = Color.Green;
                labelMesaj.Text = "Resminiz başarıyla silindi.";
                cnn.Close();
                kullaniciResimKontrol = false;
            }
            else if (kullaniciResimKontrol == false)
            {
                panelTopRenk.BackColor = Color.Red;
                labelMesaj.ForeColor = Color.Red;
                labelMesaj.Text = "Zaten mevcut bir resminiz bulunmamaktadır.";
            }
        }

        // şifreyi değiştir
        private void buttonSifreyiDegistir_Click(object sender, EventArgs e)
        {
            Boolean control = false;
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from kullanicilar where kullanici_adi='"+GirisEkrani.kullanici_adi+"'",cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["sifre"].ToString() == textBoxMevcutSifreniz.Text)
                {
                    control = true;
                }
                else
                {
                    control = false;
                }
            }
            if (control == true)
            {
                if (textBoxYeniSifreniz.Text == textBoxYeniSifrenizTekrar.Text)
                {
                    OleDbCommand cmdUpdate = new OleDbCommand("update kullanicilar set sifre=@p1 where kullanici_adi=@p2",cnn);
                    cmdUpdate.Parameters.AddWithValue("@p1", textBoxYeniSifreniz.Text);
                    cmdUpdate.Parameters.AddWithValue("@p2", GirisEkrani.kullanici_adi);
                    cmdUpdate.ExecuteNonQuery();
                    panelTopRenk.BackColor = Color.Lime;
                    labelMesaj.ForeColor = Color.Green;
                    labelMesaj.Text = "Şifreniz başarıyla değişti!";
                }
                else
                {
                    panelTopRenk.BackColor = Color.Red;
                    labelMesaj.ForeColor = Color.Red;
                    labelMesaj.Text = "Şifrelerin uyuştuğundan emin olun!";
                }
            }
            else
            {
                panelTopRenk.BackColor = Color.Red;
                labelMesaj.ForeColor = Color.Red;
                labelMesaj.Text = "Mevcut şifrenizi doğru girdiğinizden emin olun!";
            }
            cnn.Close();
        }
    }
}