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
                panelKullaniciEkleSil.Visible = true;
                panelKayitEkleSil.Visible = false;
                updateKullanicilar();
            }
            else if (panelKullaniciEkleSil.Visible == true)
            {
                panelKullaniciEkleSil.Visible = false;
                panelKayitEkleSil.Visible = false;
            }
        }

        // kayıt ekle sil
        private void ButtonKayitEkleSil_Click(object sender, EventArgs e)
        {
            if (panelKayitEkleSil.Visible == false)
            {
                panelKayitEkleSil.Visible = true;
                panelKullaniciEkleSil.Visible = false;
            }
            else if (panelKayitEkleSil.Visible == true)
            {
                panelKayitEkleSil.Visible = false;
                panelKullaniciEkleSil.Visible = false;
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

        // kullanıcı ara
        private void ButtonKullaniciEkleSilAra_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select * from kullanicilar where kullanici_adi='" + textBoxKullaniciEkleSilAra.Text + "' or sifre='" + textBoxKullaniciEkleSilAra.Text + "' or yetki='" + textBoxKullaniciEkleSilAra.Text + "'", cnn);
            adaptor.Fill(dt);
            dataGridViewKullaniciEkleSil.DataSource = dt;
        }

        // tüm kayıtlar
        private void ButtonKayitEkleSilTumKayitlar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select * from kullanicilar", cnn);
            adaptor.Fill(dt);
            dataGridViewKullaniciEkleSil.DataSource = dt;
        }
    }
}