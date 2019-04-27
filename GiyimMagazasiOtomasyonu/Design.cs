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
    public partial class Design : Form
    {
        public Design()
        {
            InitializeComponent();
        }

        /*
         
         
         
         system
         
         
         
         */

        private void Design_Load(object sender, EventArgs e)
        {
            userAvatar(); // kullanıcı avatarı
            adminPanel(); // admin paneli
            welcome(); // hoşgeldiniz yazısı
            labelMessage.Text = "";
            Login login = new Login();
        }

        // veritabanı
        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=files/databases/gmo.accdb");

        string productImage, customerImage;
        Boolean productImageControl = false, customerImageControl = false;

        void welcome()
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from users where user_id='" + Login.userId + "'", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                labelWelcome.Text = "| Hoşgeldiniz sayın " + reader["user_name"].ToString();
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

        }

        // admin panel
        private void buttonAdminPanel_Click(object sender, EventArgs e)
        {

        }
    }
}
