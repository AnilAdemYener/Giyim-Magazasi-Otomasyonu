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
    public partial class Admin_Paneli : Form
    {
        public Admin_Paneli()
        {
            InitializeComponent();
        }

        GirisEkrani giris_ekrani = new GirisEkrani();

        // veritabanı
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=databases/veritabani.accdb");

        private void Admin_Paneli_Load(object sender, EventArgs e)
        {
            // paneller
            panelKullaniciEkleSil.Visible = false;
            panelKayitEkleSil.Visible = false;
            panelKayitEkleSilUrunler.Visible = false;
            panelKayitEkleSilMusteriler.Visible = false;
            panelKayitEkleyenler.Visible = false;
            panelKayitSilenler.Visible = false;
            //font
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("fonts/Praktika-Light.otf");
            foreach (Control c in this.Controls)
            {
                c.Font = new Font(pfc.Families[0], 15, FontStyle.Regular);
                labelBaslik.Font = new Font(pfc.Families[0], 15, FontStyle.Bold);
                labelMesaj.Font = new Font(pfc.Families[0], 15, FontStyle.Bold);
            }
            //kullanıcı adı
            labelKullaniciAdi.Text = "Hoşgeldiniz sayın " + GirisEkrani.kullanici_adi + ".";
            labelMesaj.Text = "";
        }

        // kullanıcı tablosu
        void updateKullanicilar()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select * from kullanicilar", cnn);
            adaptor.Fill(dt);
            dataGridViewKullaniciEkleSil.DataSource = dt;
        }

        // kayıt tablosu
        void updateKayitlar()
        {
            ;
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

        // kullanıcı ekle sil
        private void ButtonKullaniciEkleSil_Click(object sender, EventArgs e)
        {
            if (panelKullaniciEkleSil.Visible == false)
            {
                panelKayitSilenler.Visible = false;
                panelKullaniciEkleSil.Visible = true;
                panelKayitEkleSil.Visible = false;
                panelKayitEkleyenler.Visible = false;
                updateKullanicilar();
                panelTopRenk.BackColor = Color.Orange;
                labelMesaj.ForeColor = Color.Black;
                labelMesaj.Text = "";
            }
            else if (panelKullaniciEkleSil.Visible == true)
            {
                panelKayitSilenler.Visible = false;
                panelKullaniciEkleSil.Visible = false;
                panelKayitEkleSil.Visible = false;
                panelKayitEkleyenler.Visible = false;
            }
        }

        // kayıt ekle sil
        private void ButtonKayitEkleSil_Click(object sender, EventArgs e)
        {
            if (panelKayitEkleSil.Visible == false)
            {
                panelKayitSilenler.Visible = false;
                panelKayitEkleSil.Visible = true;
                panelKullaniciEkleSil.Visible = false;
                panelKayitEkleyenler.Visible = false;
                panelTopRenk.BackColor = Color.Orange;
                labelMesaj.ForeColor = Color.Black;
                labelMesaj.Text = "";
            }
            else if (panelKayitEkleSil.Visible == true)
            {
                panelKayitSilenler.Visible = false;
                panelKayitEkleSil.Visible = false;
                panelKullaniciEkleSil.Visible = false;
                panelKayitEkleyenler.Visible = false;
            }
        }

        // kullanıcı ekle
        private void ButtonKullaniciEkle_Click(object sender, EventArgs e)
        {
            char control = 't';
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from kullanicilar", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (textBoxKullaniciEkleSilAdi.Text == reader["kullanici_adi"].ToString())
                {
                    control = 'f';
                    panelTopRenk.BackColor = Color.Red;
                    labelMesaj.ForeColor = Color.Red;
                    labelMesaj.Text = "Böyle bir kayıt zaten var.";
                }
            }
            if (control == 't')
            {
                string yetki;
                if (checkBoxKullaniciEkleSilYetkisi.Checked == true)
                {
                    yetki = "admin";
                }
                else// if (checkBoxKullaniciEkleSilYetkisi.Checked==false)
                {
                    yetki = "normal";
                }
                OleDbCommand cmdInsert = new OleDbCommand("insert into kullanicilar values(@p1,@p2,@p3)", cnn);
                cmdInsert.Parameters.AddWithValue("@p1", textBoxKullaniciEkleSilAdi.Text);
                cmdInsert.Parameters.AddWithValue("@p2", textBoxKullaniciEkleSilSifresi.Text);
                cmdInsert.Parameters.AddWithValue("@p3", yetki);
                cmdInsert.ExecuteNonQuery();
                panelTopRenk.BackColor = Color.Lime;
                labelMesaj.ForeColor = Color.Green;
                labelMesaj.Text = "Kayıt eklendi.";
                updateKullanicilar();
            }
            cnn.Close();
        }

        // kullanıcı güncelle
        private void ButtonKullaniciGuncelle_Click(object sender, EventArgs e)
        {
            char control = 'f';
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from kullanicilar", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (textBoxKullaniciEkleSilAdi.Text == reader["kullanici_adi"].ToString())
                {
                    control = 't';
                    string yetki;
                    if (checkBoxKullaniciEkleSilYetkisi.Checked == true)
                    {
                        yetki = "admin";
                    }
                    else
                    {
                        yetki = "normal";
                    }
                    OleDbCommand cmdUpdate = new OleDbCommand("update kullanicilar set sifre=@p1, yetki=@p2 where kullanici_adi=@p3", cnn);
                    cmdUpdate.Parameters.AddWithValue("@p1", textBoxKullaniciEkleSilSifresi.Text);
                    cmdUpdate.Parameters.AddWithValue("@p2", yetki);
                    cmdUpdate.Parameters.AddWithValue("@p3", textBoxKullaniciEkleSilAdi.Text);
                    cmdUpdate.ExecuteNonQuery();
                    panelTopRenk.BackColor = Color.Lime;
                    labelMesaj.ForeColor = Color.Green;
                    labelMesaj.Text = "Kayıt düzenlendi.";
                    updateKullanicilar();
                }
            }
            if (control == 'f')
            {
                panelTopRenk.BackColor = Color.Red;
                labelMesaj.ForeColor = Color.Red;
                labelMesaj.Text = "Böyle bir kayıt mevcut değil.";
            }
            cnn.Close();
        }

        // kullanıcı sil
        private void ButtonKullaniciSil_Click(object sender, EventArgs e)
        {
            char control = 'f';
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from kullanicilar", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (textBoxKullaniciEkleSilAdi.Text == reader["kullanici_adi"].ToString())
                {
                    control = 't';
                    OleDbCommand cmdDelete = new OleDbCommand("delete from kullanicilar where kullanici_adi=@p1", cnn);
                    cmdDelete.Parameters.AddWithValue("@p1", textBoxKullaniciEkleSilAdi.Text);
                    cmdDelete.ExecuteNonQuery();
                    panelTopRenk.BackColor = Color.Lime;
                    labelMesaj.ForeColor = Color.Green;
                    labelMesaj.Text = "Kayıt silindi.";
                    updateKullanicilar();
                }
            }
            if (control == 'f')
            {
                panelTopRenk.BackColor = Color.Red;
                labelMesaj.ForeColor = Color.Red;
                labelMesaj.Text = "Böyle bir kayıt mevcut değil.";
            }
            cnn.Close();
        }

        // tüm kayıtları sil
        private void ButtonTumKullanicilariSil_Click(object sender, EventArgs e)
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("delete * from kullanicilar where kullanici_adi not in (@p1)", cnn);
            cmd.Parameters.AddWithValue("@p1", GirisEkrani.kullanici_adi);
            cmd.ExecuteNonQuery();
            panelTopRenk.BackColor = Color.Lime;
            labelMesaj.ForeColor = Color.Green;
            labelMesaj.Text = "Tüm kayıtlar silindi.";
            updateKullanicilar();
            cnn.Close();
        }

        // kullanicilar tablosuna tıklandığında
        private void DataGridViewKullaniciEkleSil_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxKullaniciEkleSilAdi.Text = dataGridViewKullaniciEkleSil.CurrentRow.Cells["kullanici_adi"].Value.ToString();
            textBoxKullaniciEkleSilSifresi.Text = dataGridViewKullaniciEkleSil.CurrentRow.Cells["sifre"].Value.ToString();
            textBoxKullaniciEkleSilAra.Text = dataGridViewKullaniciEkleSil.CurrentRow.Cells["kullanici_adi"].Value.ToString();
            if (dataGridViewKullaniciEkleSil.CurrentRow.Cells["yetki"].Value.ToString() == "admin")
            {
                checkBoxKullaniciEkleSilYetkisi.Checked = true;
            }
            else
            {
                checkBoxKullaniciEkleSilYetkisi.Checked = false;
            }
        }

        

        // kontrol paneli
        private void ButtonKontrolPaneli_Click(object sender, EventArgs e)
        {
            Kontrol_Paneli kontrolPaneli = new Kontrol_Paneli();
            this.Hide();
            kontrolPaneli.Show();
        }





        /* kayıt ekle sil ================= */

        // kayıt ekle sil kullanıcı ara
        private void ButtonKullaniciEkleSilAra_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select * from kullanicilar where kullanici_adi='" + textBoxKullaniciEkleSilAra.Text + "' or sifre='" + textBoxKullaniciEkleSilAra.Text + "' or yetki='" + textBoxKullaniciEkleSilAra.Text + "'", cnn);
            adaptor.Fill(dt);
            dataGridViewKullaniciEkleSil.DataSource = dt;
        }

        // kayit ekle sil tüm kayıtlar
        private void ButtonKayitEkleSilTumKayitlar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select * from kullanicilar", cnn);
            adaptor.Fill(dt);
            dataGridViewKullaniciEkleSil.DataSource = dt;
        }

        // kayit ekle sil ürünler tablosu
        void updateKayitEkleSilUrunler()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select * from urunler", cnn);
            adaptor.Fill(dt);
            dataGridViewKayitEkleSilUrunler.DataSource = dt;
        }


        // kayıt ekle sil ürünler
        private void ButtonKayitEkleSilUrunler_Click(object sender, EventArgs e)
        {
            if (panelKayitEkleSilUrunler.Visible == false)
            {
                panelKayitSilenler.Visible = false;
                panelKayitEkleyenler.Visible = false;
                panelKayitEkleSilUrunler.Visible = true;
                panelKayitEkleSilMusteriler.Visible = false;
                panelTopRenk.BackColor = Color.Orange;
                labelMesaj.ForeColor = Color.Black;
                labelMesaj.Text = "";
                updateKayitEkleSilUrunler();
            }
            else if (panelKayitEkleSilUrunler.Visible == true)
            {
                panelKayitSilenler.Visible = false;
                panelKayitEkleyenler.Visible = false;
                panelKayitEkleSilUrunler.Visible = false;
                panelKayitEkleSilMusteriler.Visible = false;
            }
        }

        // kayıt ekle sil müşteriler
        private void ButtonKayitEkleSilMusteriler_Click(object sender, EventArgs e)
        {
            if (panelKayitEkleSilMusteriler.Visible == false)
            {
                panelKayitSilenler.Visible = false;
                panelKayitEkleyenler.Visible = false;
                panelKayitEkleSilMusteriler.Visible = true;
                panelKayitEkleSilUrunler.Visible = false;
                panelTopRenk.BackColor = Color.Orange;
                labelMesaj.ForeColor = Color.Black;
                labelMesaj.Text = "";
            }
            else if (panelKayitEkleSilMusteriler.Visible == true)
            {
                panelKayitEkleyenler.Visible = false;
                panelKayitSilenler.Visible = false;
                panelKayitEkleSilMusteriler.Visible = false;
                panelKayitEkleSilUrunler.Visible = false;
            }
        }

        // kayit ekle sil ürün tüm kayitlar
        private void ButtonKayitEkleSilUrunTumKayitlar_Click(object sender, EventArgs e)
        {
            updateKayitEkleSilUrunler();
            panelTopRenk.BackColor = Color.Lime;
            labelMesaj.ForeColor = Color.Green;
            labelMesaj.Text = "Tüm kayıtlar gösterildi.";
        }

        // kayit ekle sil ürün kayıt ara
        private void ButtonKayitEkleSilUrunAra_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select * from urunler where urun_id='" + textBoxKayitEkleSilUrunAra.Text + "'", cnn);
            adaptor.Fill(dt);
            dataGridViewKayitEkleSilUrunler.DataSource = dt;
            panelTopRenk.BackColor = Color.Lime;
            labelMesaj.ForeColor = Color.Green;
            labelMesaj.Text = textBoxKayitEkleSilUrunAra.Text + " ID'li kayıt gösterildi.";
        }

        // kayit ekle sil ürün sil
        private void ButtonKayitEkleSilUrunSil_Click(object sender, EventArgs e)
        {
            char control = 'f';
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from urunler", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (textBoxKayitEkleSilUrunAra.Text == reader["urun_id"].ToString())
                {
                    control = 't';
                    OleDbCommand cmdDelete = new OleDbCommand("delete from urunler where urun_id=@p1", cnn);
                    cmdDelete.Parameters.AddWithValue("@p1", textBoxKayitEkleSilUrunAra.Text);
                    cmdDelete.ExecuteNonQuery();
                    updateKayitEkleSilUrunler();
                    panelTopRenk.BackColor = Color.Lime;
                    labelMesaj.ForeColor = Color.Green;
                    labelMesaj.Text = textBoxKayitEkleSilUrunAra.Text + " ID'li kayıt silindi.";
                }
            }
            if (control == 'f')
            {
                panelTopRenk.BackColor = Color.Red;
                labelMesaj.ForeColor = Color.Red;
                labelMesaj.Text = textBoxKayitEkleSilUrunAra.Text + " ile kayıtlı ürün yok.";
            }
            cnn.Close();
        }

        // kayıt ekle sil ürünler tüm kayıtları sil
        private void ButtonKayitEkleSilUrunTumUrunleriSil_Click(object sender, EventArgs e)
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("delete * from urunler", cnn);
            cmd.ExecuteNonQuery();
            updateKayitEkleSilUrunler();
            panelTopRenk.BackColor = Color.Red;
            labelMesaj.ForeColor = Color.Red;
            labelMesaj.Text = "Tüm kayıtlar silindi.";
            cnn.Close();
        }






        /* kayıt ekleyenler ================= */
        
        // update kayit ekleyenler
        void updateKayitEkleyenler()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select urun_id, urun_adi, urun_ekleyen_kisi from urunler", cnn);
            adaptor.Fill(dt);
            dataGridViewKayitEkleyenlerUrunler.DataSource = dt;
            DataTable dt2 = new DataTable();
            OleDbDataAdapter adaptor2 = new OleDbDataAdapter("select musteri_id, musteri_adi, musteri_ekleyen_kisi from musteriler",cnn);
            adaptor2.Fill(dt2);
            dataGridViewKayitEkleyenlerMusteriler.DataSource = dt2;
        }

        // kayıt ekleyenler butonu
        private void ButtonKayitEkleyenler_Click(object sender, EventArgs e)
        {
            if (panelKayitEkleyenler.Visible == false)
            {
                panelKayitEkleyenler.Visible = true;
                panelKullaniciEkleSil.Visible = false;
                panelKayitSilenler.Visible = false;
                panelKayitEkleSil.Visible = false;
                updateKayitEkleyenler();
                panelTopRenk.BackColor = Color.Orange;
                labelMesaj.ForeColor = Color.Black;
                labelMesaj.Text = "";
            }
            else if (panelKayitEkleyenler.Visible==true)
            {
                panelKayitSilenler.Visible = false;
                panelKayitEkleyenler.Visible = false;
                panelKullaniciEkleSil.Visible = false;
                panelKayitEkleSil.Visible = false;
            }
        }
        
        // kayıt ekleyenler tüm ürünler
        private void ButtonKayitEkleyenlerTumKayitlar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select urun_id, urun_adi, urun_ekleyen_kisi from urunler", cnn);
            adaptor.Fill(dt);
            dataGridViewKayitEkleyenlerUrunler.DataSource = dt;
        }

        // kayıt ekleyenler kayit ara
        private void ButtonKayitEkleyenlerAra_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select urun_id, urun_adi, urun_ekleyen_kisi from urunler where urun_id='" + textBoxKayitEkleyenlerUrunID.Text + "' or urun_adi='" + textBoxKayitEkleyenlerUrunID.Text + "' or urun_ekleyen_kisi='" + textBoxKayitEkleyenlerUrunID.Text + "'", cnn);
            adaptor.Fill(dt);
            dataGridViewKayitEkleyenlerUrunler.DataSource = dt;
        }

        // kayıt ekleyenler müşteri tüm kayıtlar
        private void ButtonKayitEkleyenlerMusteriTumKayitlar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select musteri_id, musteri_adi, musteri_ekleyen_kisi from musteriler", cnn);
            adaptor.Fill(dt);
            dataGridViewKayitEkleyenlerMusteriler.DataSource = dt;
        }

        // kayıt ekleyenler müşteri ara
        private void ButtonKayitEkleyenlerMusteriAra_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select musteri_id, musteri_adi, musteri_ekleyen_kisi from musteriler where musteri_id='" + textBoxKayitEkleyenlerMusteriID.Text + "' or musteri_adi='" + textBoxKayitEkleyenlerMusteriID.Text + "' or musteri_ekleyen_kisi='" + textBoxKayitEkleyenlerMusteriID.Text + "'", cnn);
            adaptor.Fill(dt);
            dataGridViewKayitEkleyenlerMusteriler.DataSource = dt;
        }







        /* kayıt silenler ================= */

        // update kayıt silenler
        void updateKayitSilenler()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select urun_id, urun_adi, urun_silen_kisi from silinen_urunler",cnn);
            adaptor.Fill(dt);
            dataGridViewKayitSilenlerUrunler.DataSource = dt;
            DataTable dt2 = new DataTable();
            OleDbDataAdapter adaptor2 = new OleDbDataAdapter("select musteri_id, musteri_adi, musteri_silen_kisi from silinen_musteriler",cnn);
            adaptor2.Fill(dt2);
            dataGridViewKayitSilenlerMusteriler.DataSource = dt2;
        }

        // kayit silenler butonu
        private void ButtonKayitSilenler_Click(object sender, EventArgs e)
        {
            if (panelKayitSilenler.Visible==false)
            {
                panelKayitSilenler.Visible = true;
                panelKayitEkleyenler.Visible = false;
                panelKayitEkleSil.Visible = false;
                panelKullaniciEkleSil.Visible = false;
                updateKayitSilenler();
                panelTopRenk.BackColor = Color.Orange;
                labelMesaj.ForeColor = Color.Black;
                labelMesaj.Text = "";
            }
            else if (panelKayitSilenler.Visible==true)
            {
                panelKayitSilenler.Visible = false;
                panelKayitEkleyenler.Visible = false;
                panelKayitEkleSil.Visible = false;
                panelKullaniciEkleSil.Visible = false;
            }
        }

        // kayıt silenler tüm ürünler
        private void ButtonKayitSilenlerUrunTumKayitlar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select urun_id, urun_adi, urun_silen_kisi from silinen_urunler", cnn);
            adaptor.Fill(dt);
            dataGridViewKayitSilenlerUrunler.DataSource = dt;
        }

        // kayıt silenler ürün ara
        private void ButtonKayitSilenlerUrunAra_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select urun_id, urun_adi, urun_silen_kisi from silinen_urunler where urun_id='" + textBoxKayitSilenlerUrunID.Text + "' or urun_adi='" + textBoxKayitSilenlerUrunID.Text + "' or urun_silen_kisi='" + textBoxKayitSilenlerUrunID.Text + "'", cnn);
            adaptor.Fill(dt);
            dataGridViewKayitSilenlerUrunler.DataSource = dt;
        }

        // kayıt silenler ürün temizle
        private void ButtonKayitSilenlerUrunTemizle_Click(object sender, EventArgs e)
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("delete * from silinen_urunler",cnn);
            cmd.ExecuteNonQuery();
            updateKayitSilenler();
            cnn.Close();
        }

        // kayıt silenler tüm müşteriler
        private void ButtonKayitSilenlerMusteriTumKayitlar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select musteri_id, musteri_adi, musteri_silen_kisi from silinen_musteriler", cnn);
            adaptor.Fill(dt);
            dataGridViewKayitSilenlerMusteriler.DataSource = dt;
        }

        // kayıt silenler müşteri ara
        private void ButtonKayitSilenlerMusteriAra_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select musteri_id, musteri_adi, musteri_silen_kisi from silinen_musteriler where musteri_id='" + textBoxKayitSilenlerMusteriID.Text + "' or musteri_adi='" + textBoxKayitSilenlerMusteriID.Text + "' or musteri_silen_kisi='" + textBoxKayitSilenlerMusteriID.Text + "'", cnn);
            adaptor.Fill(dt);
            dataGridViewKayitSilenlerMusteriler.DataSource = dt;
        }

        // kayıt silenler müşteri temizle
        private void ButtonKayitSilenlerMusteriTemizle_Click(object sender, EventArgs e)
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("delete * from silinen_musteriler", cnn);
            cmd.ExecuteNonQuery();
            updateKayitSilenler();
            cnn.Close();
        }
    }
}