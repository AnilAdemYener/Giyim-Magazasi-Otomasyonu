using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace GiyimMagazasiOtomasyonu
{
    public partial class ChangeProfileSettings : Form
    {
        public ChangeProfileSettings()
        {
            InitializeComponent();
        }

        /*
         
         
         
         system
         
         
         
         */

        private void ChangeProfileSettings_Load(object sender, EventArgs e)
        {
            // textboxlar
            textBoxUserID.Enabled = false;
            textBoxUserAddedTime.Enabled = false;
            textBoxUserAuthority.Enabled = false;
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from users where user_id='" + Login.userId + "'", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBoxUserID.Text = reader["user_id"].ToString();
                textBoxUserName.Text = reader["user_name"].ToString();
                textBoxUserPassword.Text = reader["user_password"].ToString();
                textBoxUserEmail.Text = reader["user_email"].ToString();
                textBoxUserAddedTime.Text = reader["user_added_time"].ToString();
                textBoxUserAuthority.Text = reader["user_authority"].ToString();
            }
            cnn.Close();
            userAvatar(); // kullanıcı avatarı
            welcome(); // hoşgeldiniz yazısı
            labelMessage.Text = "";
            Login login = new Login();
        }

        // veritabanı
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=files/databases/gmo.accdb");

        void welcome()
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from users where user_id='" + Login.userId + "'", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                labelWelcome.Text = "| Hoşgeldiniz sayın " + reader["user_name"].ToString() + ".";
            }
            cnn.Close();
        }

        void userAvatar()
        {
            cnn.Open();
            OleDbCommand cmdAvatar = new OleDbCommand("select * from users where user_id='" + Login.userId + "'", cnn);
            OleDbDataReader readerAvatar = cmdAvatar.ExecuteReader();
            while (readerAvatar.Read())
            {
                if (readerAvatar["user_avatar"].ToString() == "none")
                {
                    pictureBoxUserAvatar.ImageLocation = null;
                }
                else
                {
                    pictureBoxUserAvatar.ImageLocation = "files/images/users/" + readerAvatar["user_avatar"].ToString();
                }
            }
            cnn.Close();
        }


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

        /*
         
         
         
         form
         
         
         
         */


        // çıkış yap
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        // profil ayarları
        private void buttonProfileSettings_Click(object sender, EventArgs e)
        {
            ProfileSettings profileSettings = new ProfileSettings();
            this.Hide();
            profileSettings.Show();
        }

        // kaydet
        private void buttonSave_Click(object sender, EventArgs e)
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("update users set user_name=@p1, user_password=@p2, user_email=@p3 where user_id=@p4", cnn);
            cmd.Parameters.AddWithValue("@p1", textBoxUserName.Text);
            cmd.Parameters.AddWithValue("@p2", textBoxUserPassword.Text);
            cmd.Parameters.AddWithValue("@p3", textBoxUserEmail.Text);
            cmd.Parameters.AddWithValue("@p4", textBoxUserID.Text);
            cmd.ExecuteNonQuery();
            cnn.Close();
            panelTopColor.BackColor = Color.Lime;
            labelMessage.ForeColor = Color.Green;
            labelMessage.Text = "Ayarlarınız düzenlendi!";
            welcome();
        }

        // mevcut ayarlar
        private void buttonCurrentSettings_Click(object sender, EventArgs e)
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from users where user_id='" + Login.userId + "'", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBoxUserID.Text = reader["user_id"].ToString();
                textBoxUserName.Text = reader["user_name"].ToString();
                textBoxUserPassword.Text = reader["user_password"].ToString();
                textBoxUserEmail.Text = reader["user_email"].ToString();
                textBoxUserAddedTime.Text = reader["user_added_time"].ToString();
                textBoxUserAuthority.Text = reader["user_authority"].ToString();
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
