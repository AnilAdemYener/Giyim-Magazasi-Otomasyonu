using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace GiyimMagazasiOtomasyonu
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            labelMessage.Text = "";
        }

        // veritabanı
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=files/databases/gmo.accdb");

        // kapat
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // küçült
        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // kayıt ol
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (textBoxUserId.TextLength > 1)
            {
                Boolean control = true;
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("select * from users", cnn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (textBoxUserId.Text == reader["user_id"].ToString())
                    {
                        control = false;
                        panelTopColor.BackColor = Color.Red;
                        labelMessage.ForeColor = Color.Red;
                        labelMessage.Text = "Bu ID ile kayıtlı bir kullanıcı zaten var!";
                    }
                }
                if (control == true)
                {
                    OleDbCommand cmdInsert = new OleDbCommand("insert into users values(@p1,@p2,@p3,@p4,now,@p5,@p6,@p7)", cnn);
                    cmdInsert.Parameters.AddWithValue("@p1", textBoxUserId.Text);
                    cmdInsert.Parameters.AddWithValue("@p2", textBoxUserName.Text);
                    cmdInsert.Parameters.AddWithValue("@p3", textBoxPassword.Text);
                    cmdInsert.Parameters.AddWithValue("@p4", textBoxEmail.Text);
                    cmdInsert.Parameters.AddWithValue("@p5", "none");
                    cmdInsert.Parameters.AddWithValue("@p6", "normal");
                    cmdInsert.Parameters.AddWithValue("@p7", 0);
                    cmdInsert.ExecuteNonQuery();
                    panelTopColor.BackColor = Color.Lime;
                    labelMessage.ForeColor = Color.Green;
                    labelMessage.Text = "Kayıt başarıyla eklendi!";
                }
                cnn.Close();
            }
            else
            {
                panelTopColor.BackColor = Color.Red;
                labelMessage.ForeColor = Color.Red;
                labelMessage.Text = "ID alanını boş bırakmadığınızdan emin olun!";
            }
        }

        // giriş yap
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Boolean control = false;
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from users", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (textBoxUserId.Text == reader["user_id"].ToString() && textBoxPassword.Text == reader["user_password"].ToString())
                {
                    control = true;
                    MessageBox.Show("true");
                }
            }
            if (control == false)
            {
                panelTopColor.BackColor = Color.Red;
                labelMessage.ForeColor = Color.Red;
                labelMessage.Text = "Yanlış kullanıcı adı/şifre!";
            }
            cnn.Close();
        }

        // giriş ekranına git
        private void buttonBack_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        // mouse ile taşıma

        int mov;
        int movX;
        int movY;

        private void panelTop_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }
    }
}
