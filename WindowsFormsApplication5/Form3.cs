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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBoxKullaniciAdi.Text = "_____";
            textBoxSifre.Text = "_____";
            button2.Visible = false;
            labelMesaj.Visible = false;
            panelKayitOl.Visible = false;
            labelMesaj2.Visible = false;
            labelBolum.Text = "| Giriş Yap";
            //LABELVERSİON TEST
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=version.accdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select version from version",baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                labelVersion.Text = oku["version"].ToString();
            }
            baglanti.Close();
        }

        public static string kullaniciAdi;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBoxKullaniciAdi.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBoxSifre.Text = "";
        }

        Form2 hata_mesaji = new Form2();

        private void button1_Click(object sender, EventArgs e)
        {
            /* ======================================================================================== */

            //string kontrolAdmin = "false";
            //OleDbConnection baglantiAdmin = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=admin.accdb");
            //baglantiAdmin.Open();
            //OleDbCommand komutAdmin = new OleDbCommand("select * from Tablo1", baglantiAdmin);
            //OleDbDataReader okuAdmin = komutAdmin.ExecuteReader();
            //while (okuAdmin.Read())
            //{
            //    if (textBox1.Text == okuAdmin["kullanici_adi"].ToString() && textBox2.Text == okuAdmin["sifre"].ToString())
            //    {
            //        kontrolAdmin = "true";
            //    }
            //}
            //if (kontrolAdmin == "true")
            //{
            //    MessageBox.Show("admin","başlık",MessageBoxButtons.OK,MessageBoxIcon.Hand);
            //}            
            //baglantiAdmin.Close();

            /* ======================================================================================== */

            char kontrol = 'f';
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database71.accdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from kullanicilar", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (textBoxKullaniciAdi.Text == oku["kullanici_adi"].ToString() && textBoxSifre.Text == oku["sifre"].ToString())
                {
                    kontrol = 't';
                }
            }
            if (kontrol == 'f')
            {
                labelMesaj.Visible = true;
                labelMesaj.ForeColor = Color.Red;
                labelMesaj.Text = "Doğru kullanıcı adı/şifre girdiğinizden emin olun.";
                kullaniciAdi = textBoxKullaniciAdi.Text;
            }
            else if (kontrol == 't')
            {
                kullaniciAdi = textBoxKullaniciAdi.Text;
                labelMesaj.Visible = false;
                //Form1 kullaniciPaneli = new Form1();
                //kullaniciPaneli.Show();
                Form5 kullaniciPaneli = new Form5();
                kullaniciPaneli.Show();
                this.Hide();
                textBoxKullaniciAdi.Text = "_________";
                textBoxSifre.Text = "_________";
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 10; i++)
            {
                hata_mesaji.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelKayitOl.Visible = true;
            textBoxKullaniciAdi2.Text = "_____";
            textBoxSifre2.Text = "_____";
            labelMesaj2.Visible = false;
            labelBolum.Text = "| Kayıt Ol";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panelKayitOl.Visible = false;
            labelMesaj.Text = "";
            textBoxKullaniciAdi.Text = "_____";
            textBoxSifre.Text = "_____";
            labelBolum.Text = "| Giriş Yap";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string kontrol = "f";
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database71.accdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from kullanicilar", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (textBoxKullaniciAdi2.Text == oku["kullanici_adi"].ToString())
                {
                    labelMesaj2.Visible = true;
                    labelMesaj2.ForeColor = Color.Red;
                    labelMesaj2.Text = "Bu kullanıcı adı zaten alınmış.";
                    kontrol = "t";
                }
            }
            if (kontrol == "f")
            {
                try
                {
                    OleDbCommand komutEkle = new OleDbCommand("insert into kullanicilar values('" + textBoxKullaniciAdi2.Text + "','" + textBoxSifre2.Text + "')", baglanti);
                    komutEkle.ExecuteNonQuery();
                    labelMesaj2.Visible = true;
                    labelMesaj2.ForeColor = Color.Lime;
                    labelMesaj2.Text = "Başarıyla kayıt olunmuştur.";                
                }
                catch
                {
                    labelMesaj2.Visible = true;
                    labelMesaj2.ForeColor = Color.Red;
                    labelMesaj2.Text = "Kayıt sırasında bir hata meydana geldi.";                     
                }
            }
            baglanti.Close();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBoxKullaniciAdi2.Text = "";
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBoxSifre2.Text = "";
        }

        Point lastPoint;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}