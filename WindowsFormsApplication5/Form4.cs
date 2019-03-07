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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=itemlerr1.accdb");
        Form3 girisEkrani = new Form3();

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'itemlerr1DataSet.Tablo1' table. You can move, or remove it, as needed.
            this.tablo1TableAdapter.Fill(this.itemlerr1DataSet.Tablo1);
            dataGridView1.Enabled = false; //veritabanı
            label8.Text = ""; //hata mesajı
            label9.Text = Form3.kullaniciAdi + ".";
            button10.Visible = false; //yeni kayıt ekle
            button9.Visible = false; //kayıtları göster
            panel2.Visible = false; //kontrol paneli
            panel3.Visible = false; //veritabanı
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button10.Visible = true;

            panel2.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label8.Text = "";

            button1.Visible = true;
            button10.Visible = false;

            panel2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button9.Visible = true;

            panel3.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            button9.Visible = false;

            panel3.Visible = false;
        }
        /* kontrol paneli textleri */
        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }
        /* kontrol paneli textleri */
        private void button3_Click(object sender, EventArgs e) //ekle butonu
        {
            try
            {
                Boolean kontrol = false;
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from Tablo1", baglanti);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    if (textBox6.Text != oku["id"].ToString())
                    {
                        kontrol = true;
                    }
                    else if (textBox6.Text == oku["id"].ToString())
                    {
                        kontrol = false;
                    }
                }
                if (kontrol == true)
                {
                    OleDbCommand komutEkle = new OleDbCommand("insert into Tablo1 values(@id,@adi,@rengi,@bedeni,@kitlesi,@fiyati)", baglanti);
                    komutEkle.Parameters.AddWithValue("@id", textBox6.Text);
                    komutEkle.Parameters.AddWithValue("@adi", textBox1.Text);
                    komutEkle.Parameters.AddWithValue("@rengi", textBox2.Text);
                    komutEkle.Parameters.AddWithValue("@bedeni", textBox3.Text);
                    komutEkle.Parameters.AddWithValue("@kitlesi", textBox5.Text);
                    komutEkle.Parameters.AddWithValue("@fiyati", textBox4.Text + " " + "TL");
                    komutEkle.ExecuteNonQuery();
                    label8.ForeColor = Color.Lime;
                    label8.Text = "Kayıt başarıyla eklendi.";
                }
                else if (kontrol == false)
                {
                    label8.ForeColor = Color.Red;
                    label8.Text = "Bu ID ile zaten bir kayıt var.";
                }
                baglanti.Close();
            }
            catch (Exception)
            {
                label8.ForeColor = Color.Red;
                label8.Text = "Kayıt eklenirken hata oluştu.";
                //MessageBox.Show(hata.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e) //güncelle butonu
        {
            this.tablo1TableAdapter.Fill(this.itemlerr1DataSet.Tablo1);
            label8.ForeColor = Color.Lime;
            label8.Text = "Kayıt başarıyla güncellendi.";
        }

        private void button5_Click(object sender, EventArgs e) //sil butonu
        {
            try
            {
                Boolean kontrol = false;
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from Tablo1", baglanti);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    if (textBox6.Text == oku["id"].ToString())
                    {
                        kontrol = true;
                    }
                    else if (textBox6.Text != oku["id"].ToString())
                    {
                        kontrol = false;
                    }
                }
                if (kontrol == true)
                {
                    OleDbCommand komutSil = new OleDbCommand("delete from Tablo1 where id='" + textBox6.Text + "'", baglanti);
                    //komutSil.Parameters.AddWithValue("@id", textBox6.Text);
                    komutSil.ExecuteNonQuery();
                    label8.Text = "Kayıt başarıyla silindi.";
                    label8.ForeColor = Color.Lime;
                }
                else if (kontrol == false)
                {
                    label8.Text = "Böyle bir kayıt mevcut değil.";
                    label8.ForeColor = Color.Red;
                }
                baglanti.Close();
            }
            catch
            {
                label8.ForeColor = Color.Red;
                label8.Text = "Kayıt silinirken bir hata oluştu.";
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("delete * from Tablo1",baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("bütün kayıtlar silindi.");
            baglanti.Close();
        }

        private void Button7_Click(object sender, EventArgs e)
        {

        }
    }
}
