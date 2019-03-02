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
            textBox1.Text = "_________";
            textBox2.Text = "_________";
            button2.Visible = false;
            label6.Visible = false;
            panel3.Visible = false;
            label8.Visible = false;
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
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
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
                if (textBox1.Text == oku["kullanici_adi"].ToString() && textBox2.Text == oku["sifre"].ToString())
                {
                    kontrol = 't';
                }
            }
            if (kontrol == 'f')
            {
                label6.Visible = true;
                label6.ForeColor = Color.Red;
                label6.Text = "Doğru kullanıcı adı/şifre girdiğinizden emin olun.";
                kullaniciAdi = textBox1.Text;
            }
            else if (kontrol == 't')
            {
                kullaniciAdi = textBox1.Text;
                label6.Visible = false;
                //Form1 kullaniciPaneli = new Form1();
                //kullaniciPaneli.Show();
                Form4 kullaniciPaneli = new Form4();
                kullaniciPaneli.Show();
                textBox1.Text = "_________";
                textBox2.Text = "_________";
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
            panel3.Visible = true;
            textBox4.Text = "_________";
            textBox3.Text = "_________";
            label8.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            label6.Text = "";
            textBox1.Text = "_________";
            textBox2.Text = "_________";
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
                if (textBox4.Text == oku["kullanici_adi"].ToString())
                {
                    label8.Visible = true;
                    label8.ForeColor = Color.Red;
                    label8.Text = "Bu kullanıcı adı zaten alınmış.";
                    kontrol = "t";
                }
            }
            if (kontrol == "f")
            {
                try
                {
                    OleDbCommand komutEkle = new OleDbCommand("insert into kullanicilar values('" + textBox4.Text + "','" + textBox3.Text + "')", baglanti);
                    komutEkle.ExecuteNonQuery();
                    label8.Visible = true;
                    label8.ForeColor = Color.Lime;
                    label8.Text = "Başarıyla kayıt olunmuştur.";                
                }
                catch
                {
                    label8.Visible = true;
                    label8.ForeColor = Color.Red;
                    label8.Text = "Kayıt sırasında bir hata meydana geldi.";                     
                }
            }
            baglanti.Close();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }
    }
}