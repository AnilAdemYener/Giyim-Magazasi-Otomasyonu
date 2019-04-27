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
    public partial class NewSale : Form
    {
        public NewSale()
        {
            InitializeComponent();
        }

        /*
         
         
         
         system
         
         
         
         */

        private void NewSale_Load(object sender, EventArgs e)
        {
            // panel
            panelSales.Visible = false;
            // enable
            textBoxCustomerName.Enabled = false;
            textBoxProductName.Enabled = false;
            textBoxProductPrice.Enabled = false;
            // satış
            cnn.Open();
            OleDbCommand cmdCustomer = new OleDbCommand("select * from customers", cnn);
            OleDbDataReader readerCustomer = cmdCustomer.ExecuteReader();
            while (readerCustomer.Read())
            {
                foreach (char customer in readerCustomer["customer_id"].ToString())
                {
                    comboBoxCustomerID.Items.Add(readerCustomer["customer_id"].ToString());
                }
            }
            OleDbCommand cmdProduct = new OleDbCommand("select * from products", cnn);
            OleDbDataReader readerProduct = cmdProduct.ExecuteReader();
            while (readerProduct.Read())
            {
                foreach (char product in readerProduct["product_id"].ToString())
                {
                    comboBoxProductID.Items.Add(readerProduct["product_id"].ToString());
                }
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

        // kaydet

        // kontrol paneli
        private void buttonControlPanel_Click(object sender, EventArgs e)
        {
            ControlPanel controlPanel = new ControlPanel();
            this.Hide();
            controlPanel.Show();
        }

        // combobox ürüne tıklandığında
        private void comboBoxProductID_SelectedIndexChanged(object sender, EventArgs e)
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from products where product_id='" + comboBoxProductID.Text + "'", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBoxProductName.Text = reader["product_name"].ToString();
                textBoxProductPrice.Text = reader["product_price"].ToString();
            }
            cnn.Close();
            numericUpDownProductNumber.Value = 1;
        }

        // müşteri id combobox tıklandığında
        private void comboBoxCustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from customers where customer_id='" + comboBoxCustomerID.Text + "'", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBoxCustomerName.Text = reader["customer_name"].ToString();
            }
            cnn.Close();
        }

        // miktar değeri değiştiğinde fiyatı değiştir
        private void numericUpDownProductNumber_ValueChanged(object sender, EventArgs e)
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from products where product_id='" + comboBoxProductID.Text + "'", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int buyPrice = Convert.ToInt32(numericUpDownProductNumber.Value);
                int price = Convert.ToInt32(reader["product_price"].ToString());
                textBoxProductPrice.Text = (price * buyPrice).ToString();
            }
            cnn.Close();
        }

        // satış yap
        private void buttonSell_Click(object sender, EventArgs e)
        {
            cnn.Open();
            OleDbCommand cmdDate = new OleDbCommand("select format(now(),'ddMMyyyy-hhmmss') as sold_time", cnn);
            OleDbDataReader readerDate = cmdDate.ExecuteReader();
            while (readerDate.Read())
            {
                OleDbCommand cmdInsert = new OleDbCommand("insert into sales values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,now,@p8)", cnn);
                cmdInsert.Parameters.AddWithValue("@p1", readerDate["sold_time"].ToString() + comboBoxCustomerID.Text);
                cmdInsert.Parameters.AddWithValue("@p2", comboBoxCustomerID.Text);
                cmdInsert.Parameters.AddWithValue("@p3", textBoxCustomerName.Text);
                cmdInsert.Parameters.AddWithValue("@p4", comboBoxProductID.Text);
                cmdInsert.Parameters.AddWithValue("@p5", textBoxProductName.Text);
                cmdInsert.Parameters.AddWithValue("@p6", numericUpDownProductNumber.Value);
                cmdInsert.Parameters.AddWithValue("@p7", textBoxProductPrice.Text);
                cmdInsert.Parameters.AddWithValue("@p8", Login.userId);
                cmdInsert.ExecuteNonQuery();
                panelTopColor.BackColor = Color.Lime;
                labelMessage.ForeColor = Color.Green;
                labelMessage.Text = "Satış başarıyla gerçekleşti!";
            }
            cnn.Close();
        }

        void updateAllSales()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select * from sales", cnn);
            adaptor.Fill(dt);
            dataGridViewSales.DataSource = dt;
        }

        // tüm satışlar
        private void buttonAllSales_Click(object sender, EventArgs e)
        {
            panelNewSale.Visible = false;
            panelSales.Visible = true;
            panelTopColor.BackColor = Color.Orange;
            labelMessage.Text = "";
            updateAllSales();
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from sales", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                foreach (char sale in reader["product_id"].ToString())
                {
                    comboBoxSellID.Items.Add(reader["sell_id"].ToString());
                }
            }
            cnn.Close();
        }

        // satışları kapat
        private void buttonCloseSales_Click(object sender, EventArgs e)
        {
            panelSales.Visible = false;
            panelNewSale.Visible = true;
            panelTopColor.BackColor = Color.Orange;
            labelMessage.Text = "";
        }

        // combobox tıklandığında
        private void comboBoxSellID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select * from sales where sell_id='" + comboBoxSellID.Text + "'", cnn);
            adaptor.Fill(dt);
            dataGridViewSales.DataSource = dt;
        }

        // satışı iptal et
        private void buttonCancelSell_Click(object sender, EventArgs e)
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("delete * from sales where sell_id='" + comboBoxSellID.Text + "'", cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            updateAllSales();
            panelTopColor.BackColor = Color.Lime;
            labelMessage.ForeColor = Color.Green;
            labelMessage.Text = "Satış iptal edildi!";
        }

        // tüm satışlara tıklandığında
        private void dataGridViewSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBoxSellID.Text = dataGridViewSales.CurrentRow.Cells["sell_id"].Value.ToString();
        }

        // tüm satışları göster
        private void buttonShowAllSales_Click(object sender, EventArgs e)
        {
            updateAllSales();
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
