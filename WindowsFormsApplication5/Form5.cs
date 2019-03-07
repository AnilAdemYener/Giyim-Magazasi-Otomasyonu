using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication5
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'itemler4DataSet.cocuk4' table. You can move, or remove it, as needed.
            this.cocuk4TableAdapter.Fill(this.itemler4DataSet.cocuk4);
            // TODO: This line of code loads data into the 'itemler4DataSet.erkek4' table. You can move, or remove it, as needed.
            this.erkek4TableAdapter.Fill(this.itemler4DataSet.erkek4);
            // TODO: This line of code loads data into the 'itemler4DataSet.kadin4' table. You can move, or remove it, as needed.
            this.kadin4TableAdapter.Fill(this.itemler4DataSet.kadin4);
            bttnKayitlariGoster2.Visible = false;
            bttnKontrolPaneli2.Visible = false;
            panelKayıtlar.Visible = false;
            panelKontrolPaneli.Visible = false;
            dataGridViewErkek.Enabled = false;
            dataGridViewKadin.Enabled = false;
            dataGridViewCocuk.Enabled = false;
            dataGridViewErkek.Visible = false;
            dataGridViewKadin.Visible = false;
            dataGridViewCocuk.Visible = false;
            lblMesaj.Text = "";
            lblKullaniciAdi.Text = Form3.kullaniciAdi + ".";
            this.comboBoxKitleSecim.DropDownStyle = ComboBoxStyle.DropDownList;
            listBox1.Visible = false; //TEST
            bttnEnYuksekFiyat.Visible = false; //TEST
            bttnEnDusukFiyat.Visible = false; //TEST
        }

        private void pictureClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //this.Close();
        }

        private void pictureMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bttnKayitlariGoster_Click(object sender, EventArgs e)
        {
            bttnKayitlariGoster.Visible = false;
            bttnKayitlariGoster2.Visible = true;
            panelKayıtlar.Visible = true;
        }

        private void bttnKontrolPaneli_Click(object sender, EventArgs e)
        {
            bttnKontrolPaneli.Visible = false;
            bttnKontrolPaneli2.Visible = true;
            panelKontrolPaneli.Visible = true;
        }

        private void bttnKayitlariGoster2_Click(object sender, EventArgs e)
        {
            bttnKayitlariGoster.Visible = true;
            bttnKayitlariGoster2.Visible = false;
            panelKayıtlar.Visible = false;
        }

        private void bttnKontrolPaneli2_Click(object sender, EventArgs e)
        {
            bttnKontrolPaneli.Visible = true;
            bttnKontrolPaneli2.Visible = false;
            panelKontrolPaneli.Visible = false;
            txtID.Text = "________________________";
            txtAdi.Text = "________________________";
            txtRengi.Text = "________________________";
            txtBedeni.Text = "________________________";
            txtFiyati.Text = "________________________";
        }

        private void bttnKitleGoster_Click(object sender, EventArgs e)
        {
            if (comboBoxKitleSecim.SelectedItem == "Erkek")
            {
                dataGridViewErkek.Visible = true;
                dataGridViewKadin.Visible = false;
                dataGridViewCocuk.Visible = false;
            }
            else if (comboBoxKitleSecim.SelectedItem == "Kadın")
            {
                dataGridViewErkek.Visible = false;
                dataGridViewKadin.Visible = true;
                dataGridViewCocuk.Visible = false;
            }
            else if (comboBoxKitleSecim.SelectedItem == "Çocuk")
            {
                dataGridViewErkek.Visible = false;
                dataGridViewKadin.Visible = false;
                dataGridViewCocuk.Visible = true;
            }
        }

        private void txtID_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
        }

        private void txtAdi_Click(object sender, EventArgs e)
        {
            txtAdi.Text = "";
        }

        private void txtRengi_Click(object sender, EventArgs e)
        {
            txtRengi.Text = "";
        }

        private void txtBedeni_Click(object sender, EventArgs e)
        {
            txtBedeni.Text = "";
        }

        private void txtFiyati_Click(object sender, EventArgs e)
        {
            txtFiyati.Text = "";
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=itemler4.accdb");

        private void bttnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (comboBoxKitleSecim.SelectedItem == "Erkek")
            {
                try
                {
                    OleDbCommand komutEkle = new OleDbCommand("insert into erkek4 values(@id,@adi,@rengi,@bedeni,@fiyati)", baglanti); //kitle
                    komutEkle.Parameters.AddWithValue("@id", txtID.Text);
                    komutEkle.Parameters.AddWithValue("@adi", txtAdi.Text);
                    komutEkle.Parameters.AddWithValue("@rengi", txtRengi.Text);
                    komutEkle.Parameters.AddWithValue("@bedeni", txtBedeni.Text);
                    komutEkle.Parameters.AddWithValue("@fiyati", int.Parse(txtFiyati.Text));
                    komutEkle.ExecuteNonQuery();
                    lblMesaj.ForeColor = Color.Lime;
                    lblMesaj.Text = comboBoxKitleSecim.SelectedItem + " tablosuna kayıt eklendi.";
                }
                catch
                {
                    lblMesaj.ForeColor = Color.Red;
                    lblMesaj.Text = "HATA!";
                }
            }
            else if (comboBoxKitleSecim.SelectedItem == "Kadın")
            {
                try
                {
                    OleDbCommand komutEkle = new OleDbCommand("insert into kadin4 values(@id,@adi,@rengi,@bedeni,@fiyati)", baglanti); //kitle
                    komutEkle.Parameters.AddWithValue("@id", txtID.Text);
                    komutEkle.Parameters.AddWithValue("@adi", txtAdi.Text);
                    komutEkle.Parameters.AddWithValue("@rengi", txtRengi.Text);
                    komutEkle.Parameters.AddWithValue("@bedeni", txtBedeni.Text);
                    komutEkle.Parameters.AddWithValue("@fiyati", int.Parse(txtFiyati.Text));
                    komutEkle.ExecuteNonQuery();
                    lblMesaj.ForeColor = Color.Lime;
                    lblMesaj.Text = comboBoxKitleSecim.SelectedItem + " tablosuna kayıt eklendi.";
                }
                catch
                {
                    lblMesaj.ForeColor = Color.Red;
                    lblMesaj.Text = "HATA!";
                }
            }
            else if (comboBoxKitleSecim.SelectedItem == "Çocuk")
            {
                try
                {
                    OleDbCommand komutEkle = new OleDbCommand("insert into cocuk4 values(@id,@adi,@rengi,@bedeni,@fiyati)", baglanti); //kitle
                    komutEkle.Parameters.AddWithValue("@id", txtID.Text);
                    komutEkle.Parameters.AddWithValue("@adi", txtAdi.Text);
                    komutEkle.Parameters.AddWithValue("@rengi", txtRengi.Text);
                    komutEkle.Parameters.AddWithValue("@bedeni", txtBedeni.Text);
                    komutEkle.Parameters.AddWithValue("@fiyati", int.Parse(txtFiyati.Text));
                    komutEkle.ExecuteNonQuery();
                    lblMesaj.ForeColor = Color.Lime;
                    lblMesaj.Text = "Başarıyla " + comboBoxKitleSecim.SelectedItem + " tablosuna kayıt eklendi.";
                }
                catch
                {
                    lblMesaj.ForeColor = Color.Red;
                    lblMesaj.Text = "HATA!";
                }
            }
            baglanti.Close();
        }

        private void bttnGuncelle_Click(object sender, EventArgs e)
        {
            if (comboBoxKitleSecim.SelectedItem == "Erkek")
            {
                this.erkek4TableAdapter.Fill(this.itemler4DataSet.erkek4);
                lblMesaj.ForeColor = Color.Lime;
                lblMesaj.Text = comboBoxKitleSecim.SelectedItem + " tablosu güncellendi.";
            }
            else if (comboBoxKitleSecim.SelectedItem == "Kadın")
            {
                this.kadin4TableAdapter.Fill(this.itemler4DataSet.kadin4);
                lblMesaj.ForeColor = Color.Lime;
                lblMesaj.Text = comboBoxKitleSecim.SelectedItem + " tablosu güncellendi.";
            }
            else if (comboBoxKitleSecim.SelectedItem == "Çocuk")
            {
                this.cocuk4TableAdapter.Fill(this.itemler4DataSet.cocuk4);
                lblMesaj.ForeColor = Color.Lime;
                lblMesaj.Text = comboBoxKitleSecim.SelectedItem + " tablosu güncellendi.";
            }
        }

        private void bttnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (comboBoxKitleSecim.SelectedItem == "Erkek")
            {
                Boolean kontrol = false;
                OleDbCommand komutOku = new OleDbCommand("select * from erkek4", baglanti);
                OleDbDataReader oku = komutOku.ExecuteReader();
                while (oku.Read())
                {
                    if (txtID.Text == oku["id"].ToString())
                    {
                        kontrol = true;
                    }
                }
                if (kontrol == true)
                {
                    OleDbCommand komutSil = new OleDbCommand("delete from erkek4 where id='" + txtID.Text + "'", baglanti);
                    komutSil.ExecuteNonQuery();
                    lblMesaj.ForeColor = Color.Lime;
                    lblMesaj.Text = comboBoxKitleSecim.SelectedItem + " tablosundan silindi.";
                }
                else if (kontrol == false)
                {
                    lblMesaj.ForeColor = Color.Red;
                    lblMesaj.Text = comboBoxKitleSecim.SelectedItem + " tablosunda böyle bir kayıt yok.";
                }
                baglanti.Close();
            }
            else if (comboBoxKitleSecim.SelectedItem == "Kadın")
            {
                Boolean kontrol = false;
                OleDbCommand komutOku = new OleDbCommand("select * from kadin4", baglanti);
                OleDbDataReader oku = komutOku.ExecuteReader();
                while (oku.Read())
                {
                    if (txtID.Text == oku["id"].ToString())
                    {
                        kontrol = true;
                    }
                }
                if (kontrol == true)
                {
                    OleDbCommand komutSil = new OleDbCommand("delete from kadin4 where id='" + txtID.Text + "'", baglanti);
                    komutSil.ExecuteNonQuery();
                    lblMesaj.ForeColor = Color.Lime;
                    lblMesaj.Text = comboBoxKitleSecim.SelectedItem + " tablosundan silindi.";
                }
                else if (kontrol == false)
                {
                    lblMesaj.ForeColor = Color.Red;
                    lblMesaj.Text = comboBoxKitleSecim.SelectedItem + " tablosunda böyle bir kayıt yok.";
                }
                baglanti.Close();
            }
            else if (comboBoxKitleSecim.SelectedItem == "Çocuk")
            {
                Boolean kontrol = false;
                OleDbCommand komutOku = new OleDbCommand("select * from cocuk4", baglanti);
                OleDbDataReader oku = komutOku.ExecuteReader();
                while (oku.Read())
                {
                    if (txtID.Text == oku["id"].ToString())
                    {
                        kontrol = true;
                    }
                }
                if (kontrol == true)
                {
                    OleDbCommand komutSil = new OleDbCommand("delete from cocuk4 where id='" + txtID.Text + "'", baglanti);
                    komutSil.ExecuteNonQuery();
                    lblMesaj.ForeColor = Color.Lime;
                    lblMesaj.Text = comboBoxKitleSecim.SelectedItem + " tablosundan silindi.";
                }
                else if (kontrol == false)
                {
                    lblMesaj.ForeColor = Color.Red;
                    lblMesaj.Text = comboBoxKitleSecim.SelectedItem + " tablosunda böyle bir kayıt yok.";
                }
                baglanti.Close();
            }
            baglanti.Close();
        }

        Point lastPoint;

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void pictureGitLogo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/AnilAdemYener/Hazir-Giyim-Otomasyonu");
        }

        private void bttnEnYuksekFiyat_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select id,max(fiyati) as [max fiyat] from erkek4 group by id having max(fiyati)", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            listBox1.Items.Clear();
            while (oku.Read())
            {
                listBox1.Items.Add("L " + oku["id"].ToString());
            }
            baglanti.Close();
        }

        private void bttnEnDusukFiyat_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select id,min(fiyati) as [min fiyat] from erkek4 group by id having min(fiyati)", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            listBox1.Items.Clear();
            while (oku.Read())
            {
                listBox1.Items.Add("L " + oku["id"].ToString());
            }
            baglanti.Close();
        }

        private void bttnGeri_Click(object sender, EventArgs e)
        {
            if (comboBoxKitleSecim.SelectedItem == "Erkek")
            {
                erkek4BindingSource.MovePrevious();
            }
            else if (comboBoxKitleSecim.SelectedItem == "Kadın")
            {
                kadin4BindingSource.MovePrevious();
            }
            else if (comboBoxKitleSecim.SelectedItem == "Çocuk")
            {
                cocuk4BindingSource.MovePrevious();
            }
        }

        private void bttnIleri_Click(object sender, EventArgs e)
        {
            if (comboBoxKitleSecim.SelectedItem == "Erkek")
            {
                erkek4BindingSource.MoveNext();
            }
            else if (comboBoxKitleSecim.SelectedItem == "Kadın")
            {
                kadin4BindingSource.MoveNext();
            }
            else if (comboBoxKitleSecim.SelectedItem == "Çocuk")
            {
                cocuk4BindingSource.MoveNext();
            }
        }
    }
}