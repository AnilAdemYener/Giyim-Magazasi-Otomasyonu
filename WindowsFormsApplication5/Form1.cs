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
    public partial class Form1 : Form
    {
        Form2 hata_mesaji = new Form2();
        Form3 giris_ekrani = new Form3();

        public Form1()
        {
            InitializeComponent();
            //dataGridView1.Visible = false; //veritabanı
            //panel2.Visible = false; //kayıt ekleme bölümü
            //label7.Visible = false; //veritabanı kapat yazısı
            button8.Visible = false; //kontrol ekranı test butonu
            textBox1.Text = "________";
            textBox2.Text = "________";
            textBox3.Text = "________";
            textBox4.Text = "________";
            button9.Visible = false; //kayıtları göster hover butonu
            button10.Visible = false; //yeni kayıt ekle hover butonu
            label8.Visible = false;
            Form3 girisEkrani = new Form3();
            label9.Text = Form3.kullaniciAdi + "."; //kullanıcı adı
            panel4.Visible = false;
        }

        string kitlesi = " ";

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=items.accdb");

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close(); //kapatma butonu
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; //küçültme butonu
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button9.Visible = true;
            /* ==================== */
            //baglanti.Open();
            //OleDbCommand komut = new OleDbCommand("select * from erkek",baglanti);
            //OleDbDataReader oku = komut.ExecuteReader();
            //while (oku.Read())
            //{
            //    //listBox5.Items.Add(oku["id"].ToString());
            //    listBox1.Items.Add(oku["id"].ToString()+"         "+oku["adi"].ToString()+"         "+oku["rengi"].ToString()+"         "+oku["bedeni"].ToString()+"         "+oku["fiyati"].ToString());
            //    //listBox2.Items.Add(oku["rengi"].ToString());
            //    //listBox3.Items.Add(oku["bedeni"].ToString());
            //    //listBox4.Items.Add(oku["fiyati"].ToString());
            //}
            //baglanti.Close();
            /* ==================== */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            button1.Visible = false;
            button10.Visible = true;
        }

        private void label6_Click(object sender, EventArgs e) //çöööpppppp
        {
            panel2.Visible = false;
            textBox1.Text = "________";
            textBox2.Text = "________";
            textBox3.Text = "________";
            textBox4.Text = "________";
        }

        private void label7_Click(object sender, EventArgs e) //çöppppp
        {
            //label7.Visible = false;
            //dataGridView1.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {
           try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into Tablo1 values(@adi,@rengi,@bedeni,@fiyati,@kitlesi)", baglanti);
                komut.Parameters.AddWithValue("@adi", textBox1.Text);
                komut.Parameters.AddWithValue("@rengi", textBox2.Text);
                komut.Parameters.AddWithValue("@bedeni", textBox3.Text);
                komut.Parameters.AddWithValue("@fiyati", textBox4.Text);
                komut.Parameters.AddWithValue("@kitlesi", kitlesi);
                komut.ExecuteNonQuery();
                baglanti.Close();
                label8.Visible = true;
                label8.ForeColor = Color.Lime;
                label8.Text = "Kayıt başarıyla eklendi.";
                textBox1.Text = "________";
                textBox2.Text = "________";
                textBox3.Text = "________";
                textBox4.Text = "________";
            }
            catch
            {
                label8.Visible = true;
                label8.ForeColor = Color.Red;
                label8.Text = "Kayıt eklenirken bir hata oluştu.";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                label8.Visible = true;
                label8.ForeColor = Color.Lime;
                label8.Text = "Kayıt başarıyla güncellendi.";
            }
            catch
            {
                label8.Visible = true;
                label8.ForeColor = Color.Red;
                label8.Text = "Kayıt güncellenirken bir hata oluştu.";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean kontrol = false;
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from Tablo1 where kitlesi='"+kitlesi+"'", baglanti);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    if (textBox1.Text == oku["adi"].ToString())
                    {
                        kontrol = true;
                        OleDbCommand komutSil = new OleDbCommand("delete from Tablo1 where adi=@adi", baglanti);
                        komutSil.Parameters.AddWithValue("@adi", textBox1.Text);
                        komutSil.ExecuteNonQuery();
                        label8.Visible = true;
                        label8.ForeColor = Color.Lime;
                        label8.Text = "Kayıt başarıyla silindi.";
                    }
                }
                if (kontrol == false)
                {
                    label8.Visible = true;
                    label8.ForeColor = Color.Red;
                    label8.Text = "Kayıt silinirken bir hata oluştu.";
                }
                baglanti.Close();
            }
            catch
            {
                label8.Visible = true;
                label8.ForeColor = Color.Red;
                label8.Text = "Kayıt silinirken bir hata oluştu.";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //tablo1BindingSource3.MovePrevious();
            label8.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //tablo1BindingSource3.MoveNext();
            label8.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button9.Visible = false;
            button2.Visible = true;
            label8.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button10.Visible = false;
            button1.Visible = true;
            panel2.Visible = false;
            label8.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }
    }
}
