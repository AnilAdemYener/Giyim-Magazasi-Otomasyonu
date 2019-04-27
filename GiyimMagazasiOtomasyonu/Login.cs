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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            labelMessage.Text = "";
            registerCheck(); // kayıt olma devre dışı mı kontrol et            
        }

        // veritabanı
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=files/databases/gmo.accdb");

        // kullanıcı adı
        public static string userId;

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

        void registerCheck()
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from program_settings", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["disable_register"].ToString() == "true")
                {
                    buttonRegister.Enabled = false;
                    buttonRegister.Text = "Kayıt Ol - DEVRE DIŞI";
                }
                else
                {
                    buttonRegister.Enabled = true;
                }
            }
            cnn.Close();
        }

        // kayıt ol
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            this.Hide();
            register.Show();
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
                if (textBoxUsername.Text == reader["user_id"].ToString() && textBoxPassword.Text == reader["user_password"].ToString())
                {
                    control = true;
                    OleDbCommand cmdSettings = new OleDbCommand("select * from program_settings", cnn);
                    OleDbDataReader readerSettings = cmdSettings.ExecuteReader();
                    while (readerSettings.Read())
                    {
                        if (readerSettings["disable_normal_users_login"].ToString() == "true")
                        {
                            if (reader["user_authority"].ToString() == "admin")
                            {
                                userId = reader["user_id"].ToString();
                                ControlPanel controlPanel = new ControlPanel();
                                this.Hide();
                                controlPanel.Show();
                            }
                            else
                            {
                                panelTopColor.BackColor = Color.Red;
                                labelMessage.ForeColor = Color.Red;
                                labelMessage.Text = "Şuanda sadece adminler giriş yapabilir!";
                            }
                        }
                        else
                        {
                            control = true;
                            userId = reader["user_id"].ToString();
                            ControlPanel controlPanel = new ControlPanel();
                            this.Hide();
                            controlPanel.Show();
                        }
                    }

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
