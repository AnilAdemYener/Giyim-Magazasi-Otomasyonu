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

namespace WindowsFormsApplication7
{
    public partial class Kontrol_Paneli : Form
    {
        public Kontrol_Paneli()
        {
            InitializeComponent();
        }

        GirisEkrani giris_ekrani = new GirisEkrani();

        private void Kontrol_Paneli_Load(object sender, EventArgs e)
        {
            labelMesaj.Text = "";
            //ters butonlar
            buttonUrunleriGoster2.Visible = false;
            buttonMusterileriGoster2.Visible = false;
            buttonKullanicilariGoster2.Visible = false;
            //paneller
            panelUrunler.Visible = false;
            panelMusteriler.Visible = false;
            panelKullanicilar.Visible = false;
            //font
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("fonts/Praktika-Light.otf");
            foreach (Control c in this.Controls)
            {
                c.Font = new Font(pfc.Families[0], 15, FontStyle.Regular);
                labelBaslik.Font = new Font(pfc.Families[0], 15, FontStyle.Bold);
                labelMesaj.Font = new Font(pfc.Families[0], 15, FontStyle.Bold);
                //ürünler tablosu
                textBoxUrunId.Font = new Font(pfc.Families[0], 15, FontStyle.Bold);
                textBoxUrunAdi.Font = new Font(pfc.Families[0], 15, FontStyle.Bold);
                textBoxUrunRengi.Font = new Font(pfc.Families[0], 15, FontStyle.Bold);
                textBoxUrunBedeni.Font = new Font(pfc.Families[0], 15, FontStyle.Bold);
                textBoxUrunFiyati.Font = new Font(pfc.Families[0], 15, FontStyle.Bold);
                textBoxUrunKitlesi.Font = new Font(pfc.Families[0], 15, FontStyle.Bold);
                //müşteri tablosu
                textBoxMusteriId.Font = new Font(pfc.Families[0], 15, FontStyle.Bold);
                textBoxMusteriAdi.Font = new Font(pfc.Families[0], 15, FontStyle.Bold);
                textBoxMusteriSoyadi.Font = new Font(pfc.Families[0], 15, FontStyle.Bold);
                textBoxMusteriAdresi.Font = new Font(pfc.Families[0], 15, FontStyle.Bold);
                textBoxMusteriAdresi.Font = new Font(pfc.Families[0], 15, FontStyle.Bold);
                textBoxMusteriTelefonu.Font = new Font(pfc.Families[0], 15, FontStyle.Bold);
            }
            //kullanıcı adı
            labelKullaniciAdi.Text = "Hoşgeldiniz sayın " + GirisEkrani.kullanici_adi + ".";
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

        //ürünleri göster butonu
        private void buttonUrunleriGoster1_Click(object sender, EventArgs e)
        {
            buttonUrunleriGoster1.Visible = false;
            buttonUrunleriGoster2.Visible = true;
            panelUrunler.Visible = true;
            panelMusteriler.Visible = false;
            panelKullanicilar.Visible = false;
            buttonMusterileriGoster1.Visible = true;
            buttonMusterileriGoster2.Visible = false;
            buttonKullanicilariGoster1.Visible = true;
            buttonKullanicilariGoster2.Visible = false;
            panelTopRenk.BackColor = Color.Orange;
            labelMesaj.ForeColor = Color.Black;
            labelMesaj.Text = "Ürünler tablosu gösterildi.";
        }

        //müşterileri göster butonu
        private void buttonMusterileriGoster1_Click(object sender, EventArgs e)
        {
            buttonMusterileriGoster1.Visible = false;
            buttonMusterileriGoster2.Visible = true;
            panelUrunler.Visible = false;
            panelMusteriler.Visible = true;
            panelKullanicilar.Visible = false;
            buttonUrunleriGoster1.Visible = true;
            buttonUrunleriGoster2.Visible = false;
            buttonKullanicilariGoster1.Visible = true;
            buttonKullanicilariGoster2.Visible = false;
            musteriGuncelle();
            panelTopRenk.BackColor = Color.Orange;
            labelMesaj.ForeColor = Color.Black;
            labelMesaj.Text = "Müşteriler tablosu gösterildi.";
        }

        //kullanıcıları göster butonu
        private void buttonKullanicilariGoster1_Click(object sender, EventArgs e)
        {
            buttonKullanicilariGoster1.Visible = false;
            buttonKullanicilariGoster2.Visible = true;
            panelUrunler.Visible = false;
            panelMusteriler.Visible = false;
            panelKullanicilar.Visible = true;
            buttonUrunleriGoster1.Visible = true;
            buttonUrunleriGoster2.Visible = false;
            buttonMusterileriGoster1.Visible = true;
            buttonMusterileriGoster2.Visible = false;
            kullanicilariGuncelle();
            panelTopRenk.BackColor = Color.Orange;
            labelMesaj.ForeColor = Color.Black;
            labelMesaj.Text = "Kullanıcılar tablosu gösterildi.";
        }

        //kullanıcılar tablosunu güncelle
        void kullanicilariGuncelle()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select kullanici_adi from kullanicilar", baglanti);
            adaptor.Fill(dt);
            dataGridViewKullanicilar.DataSource = dt;
        }

        //ters ürünleri göster butonu
        private void buttonUrunleriGoster2_Click(object sender, EventArgs e)
        {
            buttonUrunleriGoster1.Visible = true;
            buttonUrunleriGoster2.Visible = false;
            panelUrunler.Visible = false;
        }

        //ters müşterileri göster butonu
        private void buttonMusterileriGoster2_Click(object sender, EventArgs e)
        {
            buttonMusterileriGoster1.Visible = true;
            buttonMusterileriGoster2.Visible = false;
            panelMusteriler.Visible = false;
        }

        //ters kullanıcıları göster butonu
        private void buttonKullanicilariGoster2_Click(object sender, EventArgs e)
        {
            buttonKullanicilariGoster1.Visible = true;
            buttonKullanicilariGoster2.Visible = false;
            panelKullanicilar.Visible = false;
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=databases/veritabani.accdb");

        //kitle seç butonu
        private void buttonKitleSec_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            if (comboBoxKitleSecim.SelectedItem == "Erkek")
            {
                OleDbDataAdapter adaptor = new OleDbDataAdapter("select urun_id, urun_adi, urun_rengi, urun_bedeni, urun_fiyati from urunler where urun_kitlesi='erkek'", baglanti);
                adaptor.Fill(dt);
                panelTopRenk.BackColor = Color.Lime;
                labelMesaj.ForeColor = Color.Green;
                labelMesaj.Text = "Erkek tablosu gösterildi.";
            }
            else if (comboBoxKitleSecim.SelectedItem == "Kadın")
            {
                OleDbDataAdapter adaptor = new OleDbDataAdapter("select urun_id, urun_adi, urun_rengi, urun_bedeni, urun_fiyati from urunler where urun_kitlesi='kadın'", baglanti);
                adaptor.Fill(dt);
                panelTopRenk.BackColor = Color.Lime;
                labelMesaj.ForeColor = Color.Green;
                labelMesaj.Text = "Kadın tablosu gösterildi.";
            }
            else if (comboBoxKitleSecim.SelectedItem == "Çocuk")
            {
                OleDbDataAdapter adaptor = new OleDbDataAdapter("select urun_id, urun_adi, urun_rengi, urun_bedeni, urun_fiyati from urunler where urun_kitlesi='çocuk'", baglanti);
                adaptor.Fill(dt);
                panelTopRenk.BackColor = Color.Lime;
                labelMesaj.ForeColor = Color.Green;
                labelMesaj.Text = "Çocuk tablosu gösterildi.";
            }
            else
            {
                panelTopRenk.BackColor = Color.Red;
                labelMesaj.ForeColor = Color.Red;
                labelMesaj.Text = "Önce bir seçim yapın!";
            }
            dataGridViewUrunler.DataSource = dt;
            baglanti.Close();
        }

        //ürünler tablosunu güncelle
        void urunGuncelle()
        {
            DataTable dt = new DataTable();
            if (comboBoxKitleSecim.SelectedItem == "Erkek")
            {
                OleDbDataAdapter adaptor = new OleDbDataAdapter("select urun_id, urun_adi, urun_rengi, urun_bedeni, urun_fiyati from urunler where urun_kitlesi='erkek'", baglanti);
                adaptor.Fill(dt);
            }
            else if (comboBoxKitleSecim.SelectedItem == "Kadın")
            {
                OleDbDataAdapter adaptor = new OleDbDataAdapter("select urun_id, urun_adi, urun_rengi, urun_bedeni, urun_fiyati from urunler where urun_kitlesi='kadın'", baglanti);
                adaptor.Fill(dt);
            }
            else if (comboBoxKitleSecim.SelectedItem == "Çocuk")
            {
                OleDbDataAdapter adaptor = new OleDbDataAdapter("select urun_id, urun_adi, urun_rengi, urun_bedeni, urun_fiyati from urunler where urun_kitlesi='çocuk'", baglanti);
                adaptor.Fill(dt);
            }
            else
            {
                OleDbDataAdapter adaptor = new OleDbDataAdapter("select urun_id, urun_adi, urun_rengi, urun_bedeni, urun_fiyati, urun_kitlesi from urunler", baglanti);
                adaptor.Fill(dt);
            }
            dataGridViewUrunler.DataSource = dt;
        }

        //ürün ekle butonu
        private void buttonUrunEkle_Click(object sender, EventArgs e)
        {
            char kontrol = 't';
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from urunler", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (textBoxUrunId.Text == oku["urun_id"].ToString())
                {
                    kontrol = 'f';
                    panelTopRenk.BackColor = Color.Red;
                    labelMesaj.ForeColor = Color.Red;
                    labelMesaj.Text = "Böyle bir kayıt zaten mevcut.";
                }
            }
            if (kontrol == 't')
            {
                OleDbCommand komutEkle = new OleDbCommand("insert into urunler values(@urun_id, @urun_adi, @urun_rengi, @urun_bedeni, @urun_fiyati, @urun_kitlesi)", baglanti);
                komutEkle.Parameters.AddWithValue("@urun_id", textBoxUrunId.Text);
                komutEkle.Parameters.AddWithValue("@urun_adi", textBoxUrunAdi.Text);
                komutEkle.Parameters.AddWithValue("@urun_rengi", textBoxUrunRengi.Text);
                komutEkle.Parameters.AddWithValue("@urun_bedeni", textBoxUrunBedeni.Text);
                komutEkle.Parameters.AddWithValue("@urun_fiyati", textBoxUrunFiyati.Text);
                komutEkle.Parameters.AddWithValue("@urun_kitlesi", textBoxUrunKitlesi.Text);
                komutEkle.ExecuteNonQuery();
                panelTopRenk.BackColor = Color.Lime;
                labelMesaj.ForeColor = Color.Green;
                labelMesaj.Text = "Kayıt başarıyla eklendi.";
                urunGuncelle();
            }
            baglanti.Close();
        }

        //ürünleri güncelle butonu
        private void buttonUrunGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            if (comboBoxKitleSecim.SelectedItem == "Erkek")
            {
                OleDbDataAdapter adaptor = new OleDbDataAdapter("select urun_id, urun_adi, urun_rengi, urun_bedeni, urun_fiyati from urunler where urun_kitlesi='erkek'", baglanti);
                adaptor.Fill(dt);
            }
            else if (comboBoxKitleSecim.SelectedItem == "Kadın")
            {
                OleDbDataAdapter adaptor = new OleDbDataAdapter("select urun_id, urun_adi, urun_rengi, urun_bedeni, urun_fiyati from urunler where urun_kitlesi='kadın'", baglanti);
                adaptor.Fill(dt);
            }
            else if (comboBoxKitleSecim.SelectedItem == "Çocuk")
            {
                OleDbDataAdapter adaptor = new OleDbDataAdapter("select urun_id, urun_adi, urun_rengi, urun_bedeni, urun_fiyati from urunler where urun_kitlesi='çocuk'", baglanti);
                adaptor.Fill(dt);
            }
            else
            {
                OleDbDataAdapter adaptor = new OleDbDataAdapter("select urun_id, urun_adi, urun_rengi, urun_bedeni, urun_fiyati, urun_kitlesi from urunler", baglanti);
                adaptor.Fill(dt);
            }
            dataGridViewUrunler.DataSource = dt;
            baglanti.Close();
            panelTopRenk.BackColor = Color.Lime;
            labelMesaj.ForeColor = Color.Green;
            labelMesaj.Text = "Kayıt başarıyla güncellendi.";
        }

        //ürün sil butonu
        private void buttonUrunSil_Click(object sender, EventArgs e)
        {
            char kontrol = 'f';
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from urunler", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (textBoxUrunId.Text == oku["urun_id"].ToString())
                {
                    kontrol = 't';
                    OleDbCommand komutSil = new OleDbCommand("delete from urunler where urun_id=@urun_id", baglanti);
                    komutSil.Parameters.AddWithValue("@urun_id", textBoxUrunId.Text);
                    komutSil.ExecuteNonQuery();
                    panelTopRenk.BackColor = Color.Lime;
                    labelMesaj.ForeColor = Color.Green;
                    labelMesaj.Text = "Kayıt başarıyla silindi.";
                    urunGuncelle();
                }
            }
            if (kontrol == 'f')
            {
                panelTopRenk.BackColor = Color.Red;
                labelMesaj.ForeColor = Color.Red;
                labelMesaj.Text = "Böyle bir kayıt mevcut değil.";
            }
            baglanti.Close();
        }

        //ürünler tüm kayıtları göster butonu
        private void buttonUrunTumKayitlariGoster_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select urun_id, urun_adi, urun_rengi, urun_bedeni, urun_fiyati, urun_kitlesi from urunler", baglanti);
            adaptor.Fill(dt);
            dataGridViewUrunler.DataSource = dt;
            baglanti.Close();
            panelTopRenk.BackColor = Color.Lime;
            labelMesaj.ForeColor = Color.Green;
            labelMesaj.Text = "Tüm kayıtlar gösterildi.";
        }

        //müşteriler tablosunu güncelle
        void musteriGuncelle()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select * from musteriler", baglanti);
            adaptor.Fill(dt);
            dataGridViewMusteriler.DataSource = dt;
        }

        //müşteri ekle butonu
        private void buttonMusteriEkle_Click(object sender, EventArgs e)
        {
            char kontrol = 't';
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from musteriler", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (textBoxMusteriId.Text == oku["musteri_id"].ToString())
                {
                    kontrol = 'f';
                    panelTopRenk.BackColor = Color.Red;
                    labelMesaj.ForeColor = Color.Red;
                    labelMesaj.Text = "Böyle bir müşteri zaten kayıtlı.";
                }
            }
            if (kontrol == 't')
            {
                OleDbCommand komutEkle = new OleDbCommand("insert into musteriler values(@musteri_id, @musteri_adi, @musteri_soyadi, @musteri_adresi, @musteri_telefonu)", baglanti);
                komutEkle.Parameters.AddWithValue("@musteri_id", textBoxMusteriId.Text);
                komutEkle.Parameters.AddWithValue("@musteri_adi", textBoxMusteriAdi.Text);
                komutEkle.Parameters.AddWithValue("@musteri_soyadi", textBoxMusteriSoyadi.Text);
                komutEkle.Parameters.AddWithValue("@musteri_adresi", textBoxMusteriAdresi.Text);
                komutEkle.Parameters.AddWithValue("@musteri_telefonu", textBoxMusteriTelefonu.Text);
                komutEkle.ExecuteNonQuery();
                panelTopRenk.BackColor = Color.Lime;
                labelMesaj.ForeColor = Color.Green;
                labelMesaj.Text = "Müşteri başarıyla eklendi.";
                musteriGuncelle();
            }
            baglanti.Close();
        }

        //müşteri güncelle butonu
        private void buttonMusteriGuncelle_Click(object sender, EventArgs e)
        {
            panelTopRenk.BackColor = Color.Lime;
            labelMesaj.ForeColor = Color.Green;
            labelMesaj.Text = "Müşteri tablosu güncellendi.";
            musteriGuncelle();
        }

        //müşteri sil butonu
        private void buttonMusteriSil_Click(object sender, EventArgs e)
        {
            char kontrol = 'f';
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from musteriler", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (textBoxMusteriId.Text == oku["musteri_id"].ToString())
                {
                    kontrol = 't';
                    OleDbCommand komutSil = new OleDbCommand("delete from musteriler where musteri_id=@musteri_id", baglanti);
                    komutSil.Parameters.AddWithValue("@musteri_id", textBoxMusteriId.Text);
                    komutSil.ExecuteNonQuery();
                    panelTopRenk.BackColor = Color.Lime;
                    labelMesaj.ForeColor = Color.Green;
                    labelMesaj.Text = "Müşteri başarılı bir şekilde silindi.";
                    musteriGuncelle();
                }
            }
            if (kontrol == 'f')
            {
                panelTopRenk.BackColor = Color.Red;
                labelMesaj.ForeColor = Color.Red;
                labelMesaj.Text = "Bu ID ile kayıtlı müşteri bulunamadı.";
            }
            baglanti.Close();
        }

        //çıkış yap butonu
        private void buttonCikisYap_Click(object sender, EventArgs e)
        {
            this.Hide();
            giris_ekrani.Show();
        }
    }
}
