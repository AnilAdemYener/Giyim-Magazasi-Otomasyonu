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
    public partial class ProfileSettings : Form
    {
        public ProfileSettings()
        {
            InitializeComponent();
        }

        /*
         
         
         
         system
         
         
         
         */

        private void ProfileSettings_Load(object sender, EventArgs e)
        {
            // textboxlar
            textBoxUserID.Enabled = false;
            textBoxUserPassword.Enabled = false;
            textBoxUserAuthority.Enabled = false;
            textBoxUserPassword.UseSystemPasswordChar = true;
            // username
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from users where user_id='" + Login.userId + "'", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                labelUserName.Text = reader["user_name"].ToString();
                textBoxUserID.Text = reader["user_id"].ToString();
                textBoxUserPassword.Text = reader["user_password"].ToString();
                textBoxUserAuthority.Text = reader["user_authority"].ToString();
            }
            cnn.Close();
            userAvatar(); // kullanıcı avatarı
            adminPanel(); // admin paneli
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

        void adminPanel()
        {
            cnn.Open();
            OleDbCommand cmdAdminPanel = new OleDbCommand("select * from users where user_id='" + Login.userId + "'", cnn);
            OleDbDataReader readerAdminPanel = cmdAdminPanel.ExecuteReader();
            while (readerAdminPanel.Read())
            {
                if (readerAdminPanel["user_authority"].ToString() == "admin")
                {
                    buttonAdminPanel.Visible = true;
                }
                else
                {
                    buttonAdminPanel.Visible = false;
                }
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
                    pictureBoxProfileSettings.ImageLocation = null;
                }
                else
                {
                    pictureBoxUserAvatar.ImageLocation = "files/images/users/" + readerAvatar["user_avatar"].ToString();
                    pictureBoxProfileSettings.ImageLocation = "files/images/users/" + readerAvatar["user_avatar"].ToString();
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


        // avatar ekle
        private void buttonUploadAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "JPG Files|*.jpg";
            if (file.ShowDialog() == DialogResult.OK)
            {
                File.Delete("files/images/users/" + Login.userId + ".jpg");
                File.Copy(file.FileName, "files/images/users/" + Login.userId + ".jpg");

                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("update users set user_avatar=@p1 where user_id='" + Login.userId + "'", cnn);
                cmd.Parameters.AddWithValue("@p1", Login.userId + ".jpg");
                cmd.ExecuteNonQuery();
                cnn.Close();
                panelTopColor.BackColor = Color.Lime;
                labelMessage.ForeColor = Color.Green;
                labelMessage.Text = "Avatar başarıyla yüklendi!";
                userAvatar();
            }
        }

        // mevcut avatarı kaldır
        private void buttonDeleteAvatar_Click(object sender, EventArgs e)
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from users where user_id='" + Login.userId + "'", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["user_avatar"].ToString() == "none")
                {
                    panelTopColor.BackColor = Color.Red;
                    labelMessage.ForeColor = Color.Red;
                    labelMessage.Text = "Zaten bir avatarınız yok!";
                }
                else
                {
                    File.Delete("files/images/users/" + Login.userId + ".jpg");
                    OleDbCommand cmdUpdate = new OleDbCommand("update users set user_avatar=@p1 where user_id='" + Login.userId + "'", cnn);
                    cmdUpdate.Parameters.AddWithValue("@p1", "none");
                    cmdUpdate.ExecuteNonQuery();
                    panelTopColor.BackColor = Color.Lime;
                    labelMessage.ForeColor = Color.Green;
                    labelMessage.Text = "Avatar başarıyla silindi!";
                }
            }
            cnn.Close();
            userAvatar();
        }

        // kontrol paneli
        private void buttonControlPanel_Click(object sender, EventArgs e)
        {
            ControlPanel controlPanel = new ControlPanel();
            this.Hide();
            controlPanel.Show();
        }

        // admin paneli
        private void buttonAdminPanel_Click(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            this.Hide();
            adminPanel.Show();
        }

        // şifreyi aç kapat
        private void buttonShowHidePassword_Click(object sender, EventArgs e)
        {
            if (textBoxUserPassword.UseSystemPasswordChar == true)
            {
                textBoxUserPassword.UseSystemPasswordChar = false;
            }
            else if (textBoxUserPassword.UseSystemPasswordChar == false)
            {
                textBoxUserPassword.UseSystemPasswordChar = true;
            }
        }

        // profil ayarlarını değiştir
        private void buttonChangeProfileSettings_Click(object sender, EventArgs e)
        {
            ChangeProfileSettings changeProfileSettings = new ChangeProfileSettings();
            this.Hide();
            changeProfileSettings.Show();
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
