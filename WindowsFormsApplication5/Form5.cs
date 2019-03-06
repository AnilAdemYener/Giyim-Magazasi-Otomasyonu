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
            // TODO: This line of code loads data into the 'itemler3DataSet.cocuk' table. You can move, or remove it, as needed.
            this.cocukTableAdapter.Fill(this.itemler3DataSet.cocuk);
            // TODO: This line of code loads data into the 'itemler3DataSet.kadin' table. You can move, or remove it, as needed.
            this.kadinTableAdapter.Fill(this.itemler3DataSet.kadin);
            // TODO: This line of code loads data into the 'itemler3DataSet.erkek' table. You can move, or remove it, as needed.
            this.erkekTableAdapter.Fill(this.itemler3DataSet.erkek);
            bttnKayitlariGoster2.Visible = false;
            bttnKontrolPaneli2.Visible = false;
            panelKayıtlar.Visible = false;
            panelKontrolPaneli.Visible = false;
            dataGridViewErkek.Visible = false;
            dataGridViewKadin.Visible = false;
            dataGridViewCocuk.Visible = false;
            lblMesaj.Text = "";
            lblKullaniciAdi.Text = Form3.kullaniciAdi+".";
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

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=itemler3.accdb");

        private void bttnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (comboBoxKitleSecim.SelectedItem == "Erkek")
            {
                OleDbCommand komutEkle = new OleDbCommand("insert into erkek values('" + txtID.Text + "','" + txtAdi.Text + "','" + txtRengi.Text + "','" + txtBedeni.Text+ "','" + txtFiyati.Text + "')", baglanti);
                komutEkle.ExecuteNonQuery();
                lblMesaj.ForeColor = Color.Lime;
                lblMesaj.Text = comboBoxKitleSecim.SelectedItem + " tablosuna eklendi.";
            }
            else if (comboBoxKitleSecim.SelectedItem == "Kadın")
            {
                OleDbCommand komutEkle = new OleDbCommand("insert into kadin values('" + txtID.Text + "','" + txtAdi.Text + "','" + txtRengi.Text + "','" + txtBedeni.Text + "','" + txtFiyati.Text + "')", baglanti);
                komutEkle.ExecuteNonQuery();
                lblMesaj.ForeColor = Color.Lime;
                lblMesaj.Text = comboBoxKitleSecim.SelectedItem + " tablosuna eklendi.";
            }
            else if (comboBoxKitleSecim.SelectedItem == "Çocuk")
            {
                OleDbCommand komutEkle = new OleDbCommand("insert into cocuk values('" + txtID.Text + "','" + txtAdi.Text + "','" + txtRengi.Text + "','" + txtBedeni.Text + "','" + txtFiyati.Text + "')", baglanti);
                komutEkle.ExecuteNonQuery();
                lblMesaj.ForeColor = Color.Lime;
                lblMesaj.Text = comboBoxKitleSecim.SelectedItem + " tablosuna eklendi.";
            }
            baglanti.Close();
        }

        private void bttnGuncelle_Click(object sender, EventArgs e)
        {
            if (comboBoxKitleSecim.SelectedItem == "Erkek")
            {
                this.erkekTableAdapter.Fill(this.itemler3DataSet.erkek);
                lblMesaj.ForeColor = Color.Lime;
                lblMesaj.Text = comboBoxKitleSecim.SelectedItem + " tablosu güncellendi.";
            }
            else if (comboBoxKitleSecim.SelectedItem == "Kadın")
            {
                this.kadinTableAdapter.Fill(this.itemler3DataSet.kadin);
                lblMesaj.ForeColor = Color.Lime;
                lblMesaj.Text = comboBoxKitleSecim.SelectedItem + " tablosu güncellendi.";
            }
            else if (comboBoxKitleSecim.SelectedItem == "Çocuk")
            {
                this.cocukTableAdapter.Fill(this.itemler3DataSet.cocuk);
                lblMesaj.ForeColor = Color.Lime;
                lblMesaj.Text = comboBoxKitleSecim.SelectedItem + " tablosu güncellendi.";
            }
        }

        private void bttnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (comboBoxKitleSecim.SelectedItem == "Erkek")
            {
                OleDbCommand komutSil = new OleDbCommand("delete from erkek where id='" + txtID.Text + "'", baglanti);
                komutSil.ExecuteNonQuery();
                lblMesaj.ForeColor = Color.Lime;
                lblMesaj.Text = comboBoxKitleSecim.SelectedItem + " tablosundan kayıt silindi.";
            }
            else if (comboBoxKitleSecim.SelectedItem == "Kadın")
            {
                OleDbCommand komutSil = new OleDbCommand("delete from kadin where id='" + txtID.Text + "'", baglanti);
                komutSil.ExecuteNonQuery();
                lblMesaj.ForeColor = Color.Lime;
                lblMesaj.Text = comboBoxKitleSecim.SelectedItem + " tablosundan kayıt silindi.";
            }
            else if (comboBoxKitleSecim.SelectedItem == "Çocuk")
            {
                OleDbCommand komutSil = new OleDbCommand("delete from cocuk where id='" + txtID.Text + "'", baglanti);
                komutSil.ExecuteNonQuery();
                lblMesaj.ForeColor = Color.Lime;
                lblMesaj.Text = comboBoxKitleSecim.SelectedItem + " tablosundan kayıt silindi.";
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
    }
}
