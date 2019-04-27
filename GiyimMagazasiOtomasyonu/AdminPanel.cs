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
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        /*
         
         
         
         system
         
         
         
         */

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            userAvatar(); // kullanıcı avatarı
            welcome(); // hoşgeldiniz yazısı
            labelMessage.Text = "";
            Login login = new Login();
            // paneller
            invisibleAllPanels();
            // kullanıcı ayarları
            textBoxUserID.Enabled = false;
            textBoxUserAvatar.Enabled = false;
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

        void invisibleAllPanels()
        {
            panelUserSettings.Visible = false;
            panelProgramSettings.Visible = false;
            panelAddedRecords.Visible = false;
            panelDeletedRecords.Visible = false;
            panelTopColor.BackColor = Color.Orange;
            labelMessage.Text = "";
        }

        void addedRecords()
        {
            // products
            DataTable dtProducts = new DataTable();
            OleDbDataAdapter adaptorProducts = new OleDbDataAdapter("select * from added_records where record_category='product'", cnn);
            adaptorProducts.Fill(dtProducts);
            dataGridViewAddedProducts.DataSource = dtProducts;

            // stocks
            DataTable dtStocks = new DataTable();
            OleDbDataAdapter adaptorStocks = new OleDbDataAdapter("select * from added_records where record_category='stock'", cnn);
            adaptorStocks.Fill(dtStocks);
            dataGridViewAddedStocks.DataSource = dtStocks;

            // customers
            DataTable dtCustomers = new DataTable();
            OleDbDataAdapter adaptorCustomers = new OleDbDataAdapter("select * from added_records where record_category='customer'", cnn);
            adaptorCustomers.Fill(dtCustomers);
            dataGridViewAddedCustomers.DataSource = dtCustomers;
        }

        void deletedRecords()
        {
            // products
            DataTable dtProducts = new DataTable();
            OleDbDataAdapter adaptorProducts = new OleDbDataAdapter("select * from deleted_records where record_category='product'", cnn);
            adaptorProducts.Fill(dtProducts);
            dataGridViewDeletedProducts.DataSource = dtProducts;

            // stocks
            DataTable dtStocks = new DataTable();
            OleDbDataAdapter adaptorStocks = new OleDbDataAdapter("select * from deleted_records where record_category='stock'", cnn);
            adaptorStocks.Fill(dtStocks);
            dataGridViewDeletedStocks.DataSource = dtStocks;

            // customers
            DataTable dtCustomers = new DataTable();
            OleDbDataAdapter adaptorCustomers = new OleDbDataAdapter("select * from deleted_records where record_category='customer'", cnn);
            adaptorCustomers.Fill(dtCustomers);
            dataGridViewDeletedCustomers.DataSource = dtCustomers;
        }

        void userSettings()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select * from users", cnn);
            adaptor.Fill(dt);
            dataGridViewUserSettings.DataSource = dt;
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

        // kontrol paneli
        private void buttonControlPanel_Click(object sender, EventArgs e)
        {
            ControlPanel controlPanel = new ControlPanel();
            this.Hide();
            controlPanel.Show();
        }

        // kullanıcı ayarları
        private void buttonUserSettings_Click(object sender, EventArgs e)
        {
            if (panelUserSettings.Visible == false)
            {
                invisibleAllPanels();
                panelUserSettings.Visible = true;
                userSettings();
            }
            else if (panelUserSettings.Visible == true)
            {
                invisibleAllPanels();
            }
        }

        // program ayarları
        private void buttonProgramSettings_Click(object sender, EventArgs e)
        {
            if (panelProgramSettings.Visible == false)
            {
                invisibleAllPanels();
                panelProgramSettings.Visible = true;
                checkSettings(); // ayarları kontrol et
            }
            else if (panelProgramSettings.Visible == true)
            {
                invisibleAllPanels();
            }
        }

        // eklenmiş kayıtlar
        private void buttonAddedRecords_Click(object sender, EventArgs e)
        {
            if (panelAddedRecords.Visible == false)
            {
                invisibleAllPanels();
                panelAddedRecords.Visible = true;
                addedRecords();
            }
            else if (panelAddedRecords.Visible == true)
            {
                invisibleAllPanels();
            }
        }

        // silinmiş kayıtlar
        private void buttonDeletedRecords_Click(object sender, EventArgs e)
        {
            if (panelDeletedRecords.Visible == false)
            {
                invisibleAllPanels();
                panelDeletedRecords.Visible = true;
                deletedRecords();
            }
            else if (panelDeletedRecords.Visible == true)
            {
                invisibleAllPanels();
            }
        }

        // kullanıcı ayarları cellclick
        private void dataGridViewUserSettings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from users where user_id='" + dataGridViewUserSettings.CurrentRow.Cells["user_id"].Value.ToString() + "'", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBoxUserID.Text = reader["user_id"].ToString();
                textBoxUserName.Text = reader["user_name"].ToString();
                textBoxUserPassword.Text = reader["user_password"].ToString();
                textBoxUserEmail.Text = reader["user_email"].ToString();
                textBoxUserAddedTime.Text = reader["user_added_time"].ToString();
                textBoxUserAvatar.Text = reader["user_avatar"].ToString();
                // checkbox
                if (reader["user_authority"].ToString() == "admin")
                {
                    checkBoxUserAuthority.Checked = true;
                }
                else
                {
                    checkBoxUserAuthority.Checked = false;
                }
                // avatar
                if (reader["user_avatar"].ToString() == "none")
                {
                    pictureBoxUserSettings.ImageLocation = null;
                }
                else
                {
                    pictureBoxUserSettings.ImageLocation = "files/images/users/" + reader["user_avatar"].ToString();
                }
            }
            cnn.Close();
        }

        // kullanıcı ekle
        private void buttonUserInsert_Click(object sender, EventArgs e)
        {
            Boolean control = true;
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from users", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (textBoxUserID.Text == reader["user_id"].ToString())
                {
                    control = false;
                    panelTopColor.BackColor = Color.Red;
                    labelMessage.ForeColor = Color.Red;
                    labelMessage.Text = "Böyle bir kullanıcı zaten mevcut!";
                }
            }
            if (control == true)
            {
                OleDbCommand cmdInsert = new OleDbCommand("insert into users values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", cnn);
                cmdInsert.Parameters.AddWithValue("@p1", textBoxUserID.Text);
                cmdInsert.Parameters.AddWithValue("@p2", textBoxUserName.Text);
                cmdInsert.Parameters.AddWithValue("@p3", textBoxUserPassword.Text);
                cmdInsert.Parameters.AddWithValue("@p4", textBoxUserEmail.Text);
                cmdInsert.Parameters.AddWithValue("@p5", textBoxUserAddedTime.Text);
                cmdInsert.Parameters.AddWithValue("@p6", textBoxUserAvatar.Text);
                if (checkBoxUserAuthority.Checked == true)
                {
                    cmdInsert.Parameters.AddWithValue("@p7", "admin");
                }
                else
                {
                    cmdInsert.Parameters.AddWithValue("@p7", "normal");
                }
                cmdInsert.ExecuteNonQuery();
                panelTopColor.BackColor = Color.Lime;
                labelMessage.ForeColor = Color.Green;
                labelMessage.Text = "Kullanıcı başarıyla eklendi!";
                userSettings();
            }
            cnn.Close();
        }

        // kullanıcı güncelle
        private void buttonUserUpdate_Click(object sender, EventArgs e)
        {
            Boolean control = false;
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from users", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (textBoxUserID.Text == reader["user_id"].ToString())
                {
                    control = true;
                    OleDbCommand cmdUpdate = new OleDbCommand("update users set user_name=@p1, user_password=@p2, user_email=@p3, user_added_time=@p4, user_avatar=@p5, user_authority=@p6 where user_id=@p7", cnn);
                    cmdUpdate.Parameters.AddWithValue("@p1", textBoxUserName.Text);
                    cmdUpdate.Parameters.AddWithValue("@p2", textBoxUserPassword.Text);
                    cmdUpdate.Parameters.AddWithValue("@p3", textBoxUserEmail.Text);
                    cmdUpdate.Parameters.AddWithValue("@p4", textBoxUserAddedTime.Text);
                    cmdUpdate.Parameters.AddWithValue("@p5", textBoxUserAvatar.Text);
                    if (checkBoxUserAuthority.Checked == true)
                    {
                        cmdUpdate.Parameters.AddWithValue("@p6", "admin");
                    }
                    else
                    {
                        cmdUpdate.Parameters.AddWithValue("@p6", "normal");
                    }
                    cmdUpdate.Parameters.AddWithValue("@p7", textBoxUserID.Text);
                    cmdUpdate.ExecuteNonQuery();
                    panelTopColor.BackColor = Color.Lime;
                    labelMessage.ForeColor = Color.Green;
                    labelMessage.Text = "Kullanıcı başarıyla güncellendi!";
                    userSettings();
                }
            }
            if (control == false)
            {
                panelTopColor.BackColor = Color.Red;
                labelMessage.ForeColor = Color.Red;
                labelMessage.Text = "Böyle bir kullanıcı mevcut değil!";
            }
            cnn.Close();
        }

        // kullanıcı sil
        private void buttonUserDelete_Click(object sender, EventArgs e)
        {
            Boolean control = false;
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from users", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (textBoxUserID.Text == reader["user_id"].ToString())
                {
                    control = true;
                    OleDbCommand cmdDelete = new OleDbCommand("delete * from users where user_id=@p1", cnn);
                    cmdDelete.Parameters.AddWithValue("@p1", textBoxUserID.Text);
                    cmdDelete.ExecuteNonQuery();
                    panelTopColor.BackColor = Color.Lime;
                    labelMessage.ForeColor = Color.Green;
                    labelMessage.Text = "Kullanıcı başarıyla silindi!";
                    userSettings();
                }
            }
            if (control == false)
            {
                panelTopColor.BackColor = Color.Red;
                labelMessage.ForeColor = Color.Red;
                labelMessage.Text = "Böyle bir kullanıcı mevcut değil!";
            }
            cnn.Close();
        }

        void checkSettings()
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from program_settings", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // disable register
                if (reader["disable_register"].ToString() == "true")
                {
                    checkBoxDisableRegister.Checked = true;
                }
                else
                {
                    checkBoxDisableRegister.Checked = false;
                }

                // disable record editing
                if (reader["disable_record_editing"].ToString() == "true")
                {
                    checkBoxDisableRecordEditing.Checked = true;
                }
                else
                {
                    checkBoxDisableRecordEditing.Checked = false;
                }

                // disable new sale
                if (reader["disable_new_sale"].ToString() == "true")
                {
                    checkBoxDisableNewSale.Checked = true;
                }
                else
                {
                    checkBoxDisableNewSale.Checked = false;
                }

                // disable normal users login
                if (reader["disable_normal_users_login"].ToString() == "true")
                {
                    checkBoxDisableNormalUsersLogin.Checked = true;
                }
                else
                {
                    checkBoxDisableNormalUsersLogin.Checked = false;
                }
            }
            cnn.Close();
        }

        // ayarları kaydet
        private void buttonSaveProgramSettings_Click(object sender, EventArgs e)
        {
            string disable_register;
            string disable_record_editing;
            string disable_new_sale;
            string disable_normal_users_login;
            cnn.Open();

            // disable register
            if (checkBoxDisableRegister.Checked == true)
            {
                disable_register = "true";
            }
            else
            {
                disable_register = "false";
            }

            // disable record editing
            if (checkBoxDisableRecordEditing.Checked == true)
            {
                disable_record_editing = "true";
            }
            else
            {
                disable_record_editing = "false";
            }

            // disable new sale
            if (checkBoxDisableNewSale.Checked == true)
            {
                disable_new_sale = "true";
            }
            else
            {
                disable_new_sale = "false";
            }

            // disable normal users login
            if (checkBoxDisableNormalUsersLogin.Checked == true)
            {
                disable_normal_users_login = "true";
            }
            else
            {
                disable_normal_users_login = "false";
            }

            OleDbCommand cmd = new OleDbCommand("update program_settings set disable_register=@p1, disable_record_editing=@p2, disable_new_sale=@p3, disable_normal_users_login=@p4", cnn);
            cmd.Parameters.AddWithValue("@p1", disable_register);
            cmd.Parameters.AddWithValue("@p2", disable_record_editing);
            cmd.Parameters.AddWithValue("@p3", disable_new_sale);
            cmd.Parameters.AddWithValue("@p4", disable_normal_users_login);
            cmd.ExecuteNonQuery();
            cnn.Close();
            panelTopColor.BackColor = Color.Lime;
            labelMessage.ForeColor = Color.Green;
            labelMessage.Text = "Ayarlar başarıyla güncellendi!";
        }

        // silinmiş kayıtları temizle
        private void buttonClearDeletedRecords_Click(object sender, EventArgs e)
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("delete * from deleted_records", cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            deletedRecords();
            panelTopColor.BackColor = Color.Lime;
            labelMessage.ForeColor = Color.Green;
            labelMessage.Text = "Silinen kayıtlar temizlendi!";
        }

        // eklenmiş kayıtları temizle
        private void buttonClearAddedRecords_Click(object sender, EventArgs e)
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("delete * from added_records", cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            addedRecords();
            panelTopColor.BackColor = Color.Lime;
            labelMessage.ForeColor = Color.Green;
            labelMessage.Text = "Eklenen kayıtlar temizlendi!";
        }

        // eklenmiş kayıt ara
        private void buttonSearchAddedRecord_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select * from added_records where record_id like '" + textBoxSearchAddedRecord.Text + "' or record_name like '" + textBoxSearchAddedRecord.Text + "' or record_added_by like '" + textBoxSearchAddedRecord.Text + "' or record_category like '" + textBoxSearchAddedRecord.Text + "'", cnn);
            adaptor.Fill(dt);
            dataGridViewAddedProducts.DataSource = dt;
            dataGridViewAddedStocks.DataSource = null;
            dataGridViewAddedCustomers.DataSource = null;
        }

        // eklenen tüm kayıtlar
        private void buttonAllAddedRecords_Click(object sender, EventArgs e)
        {
            addedRecords();
        }

        // silinmiş kayıt ara
        private void buttonSearchDeletedRecord_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select * from deleted_records where record_id like '" + textBoxSearchDeletedRecord.Text + "' or record_name like '" + textBoxSearchDeletedRecord.Text + "' or record_deleted_by like '" + textBoxSearchDeletedRecord.Text + "' or record_category like '" + textBoxSearchDeletedRecord.Text + "'", cnn);
            adaptor.Fill(dt);
            dataGridViewDeletedProducts.DataSource = dt;
            dataGridViewDeletedStocks.DataSource = null;
            dataGridViewDeletedCustomers.DataSource = null;
        }

        // silinmiş tüm kayıtlar
        private void buttonAllDeletedRecords_Click(object sender, EventArgs e)
        {
            deletedRecords();
        }

        // silinmiş kayıtları temizle
        private void buttonClearDeletedRecords_Click_1(object sender, EventArgs e)
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("delete * from deleted_records", cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            deletedRecords();
            panelTopColor.BackColor = Color.Lime;
            labelMessage.ForeColor = Color.Green;
            labelMessage.Text = "Silinen kayıtlar temizlendi!";
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
