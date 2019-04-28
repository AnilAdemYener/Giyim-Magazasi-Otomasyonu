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
    public partial class CustomerDetails : Form
    {
        public CustomerDetails()
        {
            InitializeComponent();
        }

        /*
         
         
         
         system
         
         
         
         */

        private void CustomerDetails_Load(object sender, EventArgs e)
        {
            customerSalesComboBox();
            customerSalesDataGridView();
            panelCustomerSales.Visible = false;
            customerInfo();
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

        void customerSalesComboBox()
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from sales where customer_id='" + ControlPanel.customerID + "'", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxUserSales.Items.Add(reader["sell_id"].ToString());
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

        void customerSalesDataGridView()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select * from sales where customer_id='" + ControlPanel.customerID + "'", cnn);
            adaptor.Fill(dt);
            dataGridViewCustomerSales.DataSource = dt;
        }

        void customerInfo()
        {
            textBoxCustomerID.Enabled = false;
            textBoxCustomerName.Enabled = false;
            textBoxCustomerAddress.Enabled = false;
            textBoxCustomerNumber.Enabled = false;
            textBoxCustomerEmail.Enabled = false;
            textBoxCustomerAddedTime.Enabled = false;
            textBoxCustomerAddedBy.Enabled = false;
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from customers where customer_id='" + ControlPanel.customerID + "'", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["customer_avatar"].ToString() == "none")
                {
                    pictureBoxCustomerImage.ImageLocation = null;
                }
                else
                {
                    pictureBoxCustomerImage.ImageLocation = "files/images/customers/" + reader["customer_avatar"].ToString();
                }
                textBoxCustomerID.Text = reader["customer_id"].ToString();
                textBoxCustomerName.Text = reader["customer_name"].ToString();
                textBoxCustomerAddress.Text = reader["customer_address"].ToString();
                textBoxCustomerNumber.Text = reader["customer_number"].ToString();
                textBoxCustomerEmail.Text = reader["customer_email"].ToString();
                textBoxCustomerAddedTime.Text = reader["customer_added_date"].ToString();
                textBoxCustomerAddedBy.Text = reader["customer_added_by"].ToString();
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

        // kontrol paneli
        private void buttonControlPanel_Click(object sender, EventArgs e)
        {
            ControlPanel controlPanel = new ControlPanel();
            this.Hide();
            controlPanel.Show();
        }

        // müşteri bilgisi / satışlar
        private void buttonCustomerInfoSales_Click(object sender, EventArgs e)
        {
            if (panelCustomerInfo.Visible == true)
            {
                panelCustomerInfo.Visible = false;
                panelCustomerSales.Visible = true;
            }
            else if (panelCustomerSales.Visible == true)
            {
                panelCustomerSales.Visible = false;
                panelCustomerInfo.Visible = true;
            }
        }

        // combobox text değiştiğinde
        private void comboBoxUserSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select * from sales where sell_id='" + comboBoxUserSales.Text + "'", cnn);
            adaptor.Fill(dt);
            dataGridViewCustomerSales.DataSource = dt;
        }

        // tüm satışları göster
        private void buttonShowAllSales_Click(object sender, EventArgs e)
        {
            customerSalesDataGridView();
        }
    }
}
