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
    public partial class ControlPanel : Form
    {
        public ControlPanel()
        {
            InitializeComponent();
        }

        /*
         
         
         
         system
         
         
         
         */

        private void ControlPanel_Load(object sender, EventArgs e)
        {
            userAvatar(); // kullanıcı avatarı
            adminPanel(); // admin paneli
            welcome(); // hoşgeldiniz yazısı
            checkRecordEditing(); // kayıt düzenleme devre dışı mı kontrol et
            labelMessage.Text = "";
            Login login = new Login();
            // paneller
            invisibleAllPanels();
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
                labelWelcome.Text = "| Hoşgeldiniz sayın " + reader["user_name"].ToString() + ".";
            }
            cnn.Close();
        }

        void checkRecordEditing()
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from program_settings", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // disable record editing
                if (reader["disable_record_editing"].ToString() == "true")
                {
                    // product
                    buttonProductImage.Enabled = false;
                    buttonProductInsert.Enabled = false;
                    buttonProductUpdate.Enabled = false;
                    buttonProductDelete.Enabled = false;
                    // stocks
                    buttonStockAdd.Enabled = false;
                    buttonStockUpdate.Enabled = false;
                    buttonStockDelete.Enabled = false;
                    // customers
                    buttonCustomerImage.Enabled = false;
                    buttonCustomerInsert.Enabled = false;
                    buttonCustomerUpdate.Enabled = false;
                    buttonCustomerDelete.Enabled = false;
                }
                else
                {
                    // product
                    buttonProductImage.Enabled = true;
                    buttonProductInsert.Enabled = true;
                    buttonProductUpdate.Enabled = true;
                    buttonProductDelete.Enabled = true;
                    // stocks
                    buttonStockAdd.Enabled = true;
                    buttonStockUpdate.Enabled = true;
                    buttonStockDelete.Enabled = true;
                    // customers
                    buttonCustomerImage.Enabled = true;
                    buttonCustomerInsert.Enabled = true;
                    buttonCustomerUpdate.Enabled = true;
                    buttonCustomerDelete.Enabled = true;
                }

                // disable new sale
                if (reader["disable_new_sale"].ToString() == "true")
                {
                    // new sale
                    buttonNewSale.Enabled = false;
                }
                else
                {
                    // new sale
                    buttonNewSale.Enabled = true;
                }
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

        void invisibleAllPanels()
        {
            panelProducts.Visible = false;
            panelStocks.Visible = false;
            panelCustomers.Visible = false;
            panelUsers.Visible = false;

            panelTopColor.BackColor = Color.Orange;
            labelMessage.Text = "";
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

        void updateProducts()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select * from products", cnn);
            adaptor.Fill(dt);
            dataGridViewProducts.DataSource = dt;
        }

        void updateStocks()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select * from stocks", cnn);
            adaptor.Fill(dt);
            dataGridViewStocks.DataSource = dt;
        }

        void updateUsers()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select user_id from users", cnn);
            adaptor.Fill(dt);
            dataGridViewUsers.DataSource = dt;
        }

        // ürünler
        private void buttonProducts_Click(object sender, EventArgs e)
        {
            if (panelProducts.Visible == false)
            {
                updateProducts();
                invisibleAllPanels();
                panelProducts.Visible = true;
            }
            else if (panelProducts.Visible == true)
            {
                invisibleAllPanels();
            }
        }

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

        // admin panel
        private void buttonAdminPanel_Click(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            this.Hide();
            adminPanel.Show();
        }

        // ürün resim seç
        private void buttonProductImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "JPF Files|*.jpg";
            if (file.ShowDialog() == DialogResult.OK)
            {
                productImageControl = true;
                productImage = file.FileName;
            }
        }

        // ürün ekle
        private void buttonProductInsert_Click(object sender, EventArgs e)
        {
            Boolean control = true;
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from products", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (textBoxProductID.Text == reader["product_id"].ToString())
                {
                    control = false;
                    panelTopColor.BackColor = Color.Red;
                    labelMessage.ForeColor = Color.Red;
                    labelMessage.Text = "Böyle bir kayıt zaten mevcut!";
                }
            }
            if (control == true)
            {
                if (productImageControl == false)
                {
                    OleDbCommand cmdInsert = new OleDbCommand("insert into products values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", cnn);
                    cmdInsert.Parameters.AddWithValue("@p1", textBoxProductID.Text);
                    cmdInsert.Parameters.AddWithValue("@p2", textBoxProductName.Text);
                    cmdInsert.Parameters.AddWithValue("@p3", textBoxProductType.Text);
                    cmdInsert.Parameters.AddWithValue("@p4", textBoxProductColor.Text);
                    cmdInsert.Parameters.AddWithValue("@p5", textBoxProductSize.Text);
                    cmdInsert.Parameters.AddWithValue("@p6", textBoxProductMass.Text);
                    cmdInsert.Parameters.AddWithValue("@p7", textBoxProductPrice.Text);
                    cmdInsert.Parameters.AddWithValue("@p8", "none");
                    cmdInsert.Parameters.AddWithValue("@p9", Login.userId);
                    cmdInsert.ExecuteNonQuery();
                    panelTopColor.BackColor = Color.Lime;
                    labelMessage.ForeColor = Color.Green;
                    labelMessage.Text = "Kayıt başarıyla eklendi!";
                    updateProducts();
                }
                else
                {
                    File.Delete("files/images/products/" + textBoxProductID.Text + ".jpg");
                    File.Copy(productImage, "files/images/products/" + textBoxProductID.Text + ".jpg");
                    OleDbCommand cmdInsert = new OleDbCommand("insert into products values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", cnn);
                    cmdInsert.Parameters.AddWithValue("@p1", textBoxProductID.Text);
                    cmdInsert.Parameters.AddWithValue("@p2", textBoxProductName.Text);
                    cmdInsert.Parameters.AddWithValue("@p3", textBoxProductType.Text);
                    cmdInsert.Parameters.AddWithValue("@p4", textBoxProductColor.Text);
                    cmdInsert.Parameters.AddWithValue("@p5", textBoxProductSize.Text);
                    cmdInsert.Parameters.AddWithValue("@p6", textBoxProductMass.Text);
                    cmdInsert.Parameters.AddWithValue("@p7", textBoxProductPrice.Text);
                    cmdInsert.Parameters.AddWithValue("@p8", textBoxProductID.Text + ".jpg");
                    cmdInsert.Parameters.AddWithValue("@p9", Login.userId);
                    cmdInsert.ExecuteNonQuery();
                    panelTopColor.BackColor = Color.Lime;
                    labelMessage.ForeColor = Color.Green;
                    labelMessage.Text = "Kayıt başarıyla eklendi!";
                    updateProducts();
                }
                // added records
                OleDbCommand cmdAddedRecordsProduct = new OleDbCommand("insert into added_records values(@p1,@p2,now,@p3,@p4)", cnn);
                cmdAddedRecordsProduct.Parameters.AddWithValue("@p1", textBoxProductID.Text);
                cmdAddedRecordsProduct.Parameters.AddWithValue("@p2", textBoxProductName.Text);
                cmdAddedRecordsProduct.Parameters.AddWithValue("@p3", Login.userId);
                cmdAddedRecordsProduct.Parameters.AddWithValue("@p4", "product");
                cmdAddedRecordsProduct.ExecuteNonQuery();
            }
            cnn.Close();
        }

        // ürünler cell click
        private void dataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from products where product_id='" + dataGridViewProducts.CurrentRow.Cells["product_id"].Value.ToString() + "'", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBoxProductID.Text = reader["product_id"].ToString();
                textBoxProductName.Text = reader["product_name"].ToString();
                textBoxProductType.Text = reader["product_type"].ToString();
                textBoxProductColor.Text = reader["product_color"].ToString();
                textBoxProductSize.Text = reader["product_size"].ToString();
                textBoxProductMass.Text = reader["product_mass"].ToString();
                textBoxProductPrice.Text = reader["product_price"].ToString();
                productImage = reader["product_image"].ToString();
                if (reader["product_image"].ToString() == "none")
                {
                    pictureBoxProductImage.ImageLocation = null;
                }
                else
                {
                    pictureBoxProductImage.ImageLocation = "files/images/products/" + reader["product_image"].ToString();
                }
            }
            cnn.Close();
        }

        // ürün güncelle
        private void buttonProductUpdate_Click(object sender, EventArgs e)
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from products where product_id='" + textBoxProductID.Text + "'", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (productImageControl == false)
                {
                    OleDbCommand cmdUpdate = new OleDbCommand("update products set product_name=@p1, product_type=@p2, product_color=@p3, product_size=@p4, product_mass=@p5, product_price=@p6 where product_id=@p7", cnn);
                    cmdUpdate.Parameters.AddWithValue("@p1", textBoxProductName.Text);
                    cmdUpdate.Parameters.AddWithValue("@p2", textBoxProductType.Text);
                    cmdUpdate.Parameters.AddWithValue("@p3", textBoxProductColor.Text);
                    cmdUpdate.Parameters.AddWithValue("@p4", textBoxProductSize.Text);
                    cmdUpdate.Parameters.AddWithValue("@p5", textBoxProductMass.Text);
                    cmdUpdate.Parameters.AddWithValue("@p6", textBoxProductPrice.Text);
                    cmdUpdate.Parameters.AddWithValue("@p7", textBoxProductID.Text);
                    cmdUpdate.ExecuteNonQuery();
                }
                else if (productImageControl == true)
                {
                    File.Delete("files/images/products/" + reader["product_image"].ToString());
                    File.Copy(productImage, "files/images/products/" + textBoxProductID.Text + ".jpg");
                    OleDbCommand cmdUpdate = new OleDbCommand("update products set product_name=@p1, product_type=@p2, product_color=@p3, product_size=@p4, product_mass=@p5, product_price=@p6, product_image=@p7 where product_id=@p8", cnn);
                    cmdUpdate.Parameters.AddWithValue("@p1", textBoxProductName.Text);
                    cmdUpdate.Parameters.AddWithValue("@p2", textBoxProductType.Text);
                    cmdUpdate.Parameters.AddWithValue("@p3", textBoxProductColor.Text);
                    cmdUpdate.Parameters.AddWithValue("@p4", textBoxProductSize.Text);
                    cmdUpdate.Parameters.AddWithValue("@p5", textBoxProductMass.Text);
                    cmdUpdate.Parameters.AddWithValue("@p6", textBoxProductPrice.Text);
                    cmdUpdate.Parameters.AddWithValue("@p7", textBoxProductID.Text + ".jpg");
                    cmdUpdate.Parameters.AddWithValue("@p8", textBoxProductID.Text);
                    cmdUpdate.ExecuteNonQuery();
                }
            }
            panelTopColor.BackColor = Color.Lime;
            labelMessage.ForeColor = Color.Green;
            labelMessage.Text = "Kayıt güncellendi!";
            cnn.Close();
            updateProducts();
            productImageControl = false;
        }

        // ürün sil
        private void buttonProductDelete_Click(object sender, EventArgs e)
        {
            Boolean control = false;
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from products", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (textBoxProductID.Text == reader["product_id"].ToString())
                {
                    // deleted records
                    OleDbCommand cmdDeletedRecordsProduct = new OleDbCommand("insert into deleted_records values(@p1,@p2,now,@p3,@p4)", cnn);
                    cmdDeletedRecordsProduct.Parameters.AddWithValue("@p1", textBoxProductID.Text);
                    cmdDeletedRecordsProduct.Parameters.AddWithValue("@p2", textBoxProductName.Text);
                    cmdDeletedRecordsProduct.Parameters.AddWithValue("@p3", Login.userId);
                    cmdDeletedRecordsProduct.Parameters.AddWithValue("@p4", "product");
                    cmdDeletedRecordsProduct.ExecuteNonQuery();
                    control = true;
                    OleDbCommand cmdImage = new OleDbCommand("select * from products where product_id='" + textBoxProductID.Text + "'", cnn);
                    OleDbDataReader readerImage = cmdImage.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["product_image"].ToString() == "none")
                        {
                            ;
                        }
                        else
                        {
                            File.Delete("files/images/products/" + textBoxProductID.Text + ".jpg");
                        }
                    }
                    OleDbCommand cmdDelete = new OleDbCommand("delete * from products where product_id='" + textBoxProductID.Text + "'", cnn);
                    cmdDelete.ExecuteNonQuery();
                    panelTopColor.BackColor = Color.Lime;
                    labelMessage.ForeColor = Color.Green;
                    labelMessage.Text = "Kayıt başarıyla silindi!";
                    updateProducts();
                }
            }
            if (control == false)
            {
                panelTopColor.BackColor = Color.Red;
                labelMessage.ForeColor = Color.Red;
                labelMessage.Text = "Böyle bir kayıt mevcut değil!";
            }
            cnn.Close();
        }

        // ürünler erkek
        private void buttonProductMale_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select * from products where product_mass='erkek'", cnn);
            adaptor.Fill(dt);
            dataGridViewProducts.DataSource = dt;
        }

        // kadın
        private void buttonProductFemale_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select * from products where product_mass='kadın'", cnn);
            adaptor.Fill(dt);
            dataGridViewProducts.DataSource = dt;
        }

        // çocuk
        private void buttonProductKid_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select * from products where product_mass='çocuk'", cnn);
            adaptor.Fill(dt);
            dataGridViewProducts.DataSource = dt;
        }

        // stoklar
        private void buttonStocks_Click(object sender, EventArgs e)
        {
            if (panelStocks.Visible == false)
            {
                invisibleAllPanels();
                panelStocks.Visible = true;
                updateStocks();
            }
            else if (panelStocks.Visible == true)
            {
                invisibleAllPanels();
            }
        }

        void updateCustomers()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("select * from customers", cnn);
            adaptor.Fill(dt);
            dataGridViewCustomers.DataSource = dt;
        }

        // müşteriler
        private void buttonCustomers_Click(object sender, EventArgs e)
        {
            if (panelCustomers.Visible == false)
            {
                invisibleAllPanels();
                panelCustomers.Visible = true;
                updateCustomers();
            }
            else if (panelCustomers.Visible == true)
            {
                invisibleAllPanels();
            }
        }

        // kullanıcılar
        private void buttonUsers_Click(object sender, EventArgs e)
        {
            if (panelUsers.Visible == false)
            {
                invisibleAllPanels();
                panelUsers.Visible = true;
                updateUsers();
                textBoxUserID.Enabled = false;
                textBoxUserName.Enabled = false;
                textBoxUserAuthority.Enabled = false;
            }
            else if (panelUsers.Visible == true)
            {
                invisibleAllPanels();
            }
        }

        // müşteri ekle
        private void buttonCustomerInsert_Click(object sender, EventArgs e)
        {
            Boolean control = true;
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from customers", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (textBoxCustomerID.Text == reader["customer_id"].ToString())
                {
                    control = false;
                    panelTopColor.BackColor = Color.Red;
                    labelMessage.ForeColor = Color.Red;
                    labelMessage.Text = "Böyle bir müşteri zaten kayıtlı!";
                }
            }
            if (control == true)
            {
                if (customerImageControl == true)
                {
                    File.Delete("files/images/customers/" + textBoxCustomerID.Text + ".jpg");
                    File.Copy(customerImage, "files/images/customers/" + textBoxCustomerID.Text + ".jpg");
                    OleDbCommand cmdInsert = new OleDbCommand("insert into customers values(@p1,@p2,@p3,@p4,@p5,@p6,now,@p7)", cnn);
                    cmdInsert.Parameters.AddWithValue("@p1", textBoxCustomerID.Text);
                    cmdInsert.Parameters.AddWithValue("@p2", textBoxCustomerName.Text);
                    cmdInsert.Parameters.AddWithValue("@p3", textBoxCustomerAddress.Text);
                    cmdInsert.Parameters.AddWithValue("@p4", textBoxCustomerNumber.Text);
                    cmdInsert.Parameters.AddWithValue("@p5", textBoxCustomerEmail.Text);
                    cmdInsert.Parameters.AddWithValue("@p6", textBoxCustomerID.Text + ".jpg");
                    cmdInsert.Parameters.AddWithValue("@p7", Login.userId);
                    cmdInsert.ExecuteNonQuery();
                    updateCustomers();
                }
                else
                {
                    OleDbCommand cmdInsert = new OleDbCommand("insert into customers values(@p1,@p2,@p3,@p4,@p5,@p6,now,@p7)", cnn);
                    cmdInsert.Parameters.AddWithValue("@p1", textBoxCustomerID.Text);
                    cmdInsert.Parameters.AddWithValue("@p2", textBoxCustomerName.Text);
                    cmdInsert.Parameters.AddWithValue("@p3", textBoxCustomerAddress.Text);
                    cmdInsert.Parameters.AddWithValue("@p4", textBoxCustomerNumber.Text);
                    cmdInsert.Parameters.AddWithValue("@p5", textBoxCustomerEmail.Text);
                    cmdInsert.Parameters.AddWithValue("@p6", "none");
                    cmdInsert.Parameters.AddWithValue("@p7", Login.userId);
                    cmdInsert.ExecuteNonQuery();
                    updateCustomers();
                }
                // added records
                OleDbCommand cmdAddedRecordsCustomer = new OleDbCommand("insert into added_records values(@p1,@p2,now,@p3,@p4)", cnn);
                cmdAddedRecordsCustomer.Parameters.AddWithValue("@p1", textBoxCustomerID.Text);
                cmdAddedRecordsCustomer.Parameters.AddWithValue("@p2", textBoxCustomerName.Text);
                cmdAddedRecordsCustomer.Parameters.AddWithValue("@p3", Login.userId);
                cmdAddedRecordsCustomer.Parameters.AddWithValue("@p4", "customer");
                cmdAddedRecordsCustomer.ExecuteNonQuery();
                panelTopColor.BackColor = Color.Lime;
                labelMessage.ForeColor = Color.Green;
                labelMessage.Text = "Müşteri başarıyla eklendi!";
            }
            cnn.Close();
        }

        // müşteri resim
        private void buttonCustomerImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "JPF Files|*.jpg";
            if (file.ShowDialog() == DialogResult.OK)
            {
                customerImageControl = true;
                customerImage = file.FileName;
            }
        }

        // müşteriler cellclick
        private void dataGridViewCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from customers where customer_id='" + dataGridViewCustomers.CurrentRow.Cells["customer_id"].Value.ToString() + "'", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBoxCustomerID.Text = dataGridViewCustomers.CurrentRow.Cells["customer_id"].Value.ToString();
                textBoxCustomerName.Text = dataGridViewCustomers.CurrentRow.Cells["customer_name"].Value.ToString();
                textBoxCustomerAddress.Text = dataGridViewCustomers.CurrentRow.Cells["customer_address"].Value.ToString();
                textBoxCustomerNumber.Text = dataGridViewCustomers.CurrentRow.Cells["customer_number"].Value.ToString();
                textBoxCustomerEmail.Text = dataGridViewCustomers.CurrentRow.Cells["customer_email"].Value.ToString();
                if (reader["customer_avatar"].ToString() == "none")
                {
                    pictureBoxCustomers.ImageLocation = null;
                }
                else
                {
                    pictureBoxCustomers.ImageLocation = "files/images/customers/" + reader["customer_avatar"].ToString();
                }
            }
            cnn.Close();
        }

        // müşteri sil
        private void buttonCustomerDelete_Click(object sender, EventArgs e)
        {
            Boolean control = false;
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from customers", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (textBoxCustomerID.Text == reader["customer_id"].ToString())
                {
                    // deleted records
                    OleDbCommand cmdDeletedRecordsCustomer = new OleDbCommand("insert into deleted_records values(@p1,@p2,now,@p3,@p4)", cnn);
                    cmdDeletedRecordsCustomer.Parameters.AddWithValue("@p1", textBoxCustomerID.Text);
                    cmdDeletedRecordsCustomer.Parameters.AddWithValue("@p2", textBoxCustomerName.Text);
                    cmdDeletedRecordsCustomer.Parameters.AddWithValue("@p3", Login.userId);
                    cmdDeletedRecordsCustomer.Parameters.AddWithValue("@p4", "customer");
                    cmdDeletedRecordsCustomer.ExecuteNonQuery();
                    control = true;
                    File.Delete("files/images/customers/" + textBoxCustomerID.Text + ".jpg");
                    OleDbCommand cmdDelete = new OleDbCommand("delete * from customers where customer_id='" + textBoxCustomerID.Text + "'", cnn);
                    cmdDelete.ExecuteNonQuery();
                    panelTopColor.BackColor = Color.Lime;
                    labelMessage.ForeColor = Color.Green;
                    labelMessage.Text = "Kayıt başarıyla silindi!";
                    updateCustomers();
                }
            }
            if (control == false)
            {
                panelTopColor.BackColor = Color.Red;
                labelMessage.ForeColor = Color.Red;
                labelMessage.Text = "Böyle bir kayıt mevcut değil!";
            }
            cnn.Close();
        }

        // müşteri güncelle
        private void buttonCustomerUpdate_Click(object sender, EventArgs e)
        {
            if (customerImageControl == true)
            {
                File.Delete("files/images/customers/" + textBoxCustomerID.Text + ".jpg");
                File.Copy(customerImage, "files/images/customers/" + textBoxCustomerID.Text + ".jpg");
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("update customers set customer_name=@p1, customer_address=@p2, customer_number=@p3, customer_email=@p4, customer_avatar=@p5 where customer_id=@p6", cnn);
                cmd.Parameters.AddWithValue("@p1", textBoxCustomerName.Text);
                cmd.Parameters.AddWithValue("@p2", textBoxCustomerAddress.Text);
                cmd.Parameters.AddWithValue("@p3", textBoxCustomerNumber.Text);
                cmd.Parameters.AddWithValue("@p4", textBoxCustomerEmail.Text);
                cmd.Parameters.AddWithValue("@p5", textBoxCustomerID.Text + ".jpg");
                cmd.Parameters.AddWithValue("@p6", textBoxCustomerID.Text);
                cmd.ExecuteNonQuery();
                cnn.Close();
                updateCustomers();
            }
            else
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("update customers set customer_name=@p1, customer_address=@p2, customer_number=@p3, customer_email=@p4 where customer_id=@p5", cnn);
                cmd.Parameters.AddWithValue("@p1", textBoxCustomerName.Text);
                cmd.Parameters.AddWithValue("@p2", textBoxCustomerAddress.Text);
                cmd.Parameters.AddWithValue("@p3", textBoxCustomerNumber.Text);
                cmd.Parameters.AddWithValue("@p4", textBoxCustomerEmail.Text);
                cmd.Parameters.AddWithValue("@p5", textBoxCustomerID.Text);
                cmd.ExecuteNonQuery();
                cnn.Close();
                updateCustomers();
            }
            panelTopColor.BackColor = Color.Lime;
            labelMessage.ForeColor = Color.Green;
            labelMessage.Text = "Kayıt güncellendi!";
            customerImageControl = false;
        }

        // stoklar cell click
        private void dataGridViewStocks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxStockID.Text = dataGridViewStocks.CurrentRow.Cells["stock_id"].Value.ToString();
            textBoxStockName.Text = dataGridViewStocks.CurrentRow.Cells["stock_name"].Value.ToString();
            textBoxStockType.Text = dataGridViewStocks.CurrentRow.Cells["stock_type"].Value.ToString();
            textBoxStockPrice.Text = dataGridViewStocks.CurrentRow.Cells["stock_price"].Value.ToString();
            textBoxStockNumber.Text = dataGridViewStocks.CurrentRow.Cells["stock_number"].Value.ToString();
        }

        // stok ekle
        private void buttonStockAdd_Click(object sender, EventArgs e)
        {
            Boolean control = true;
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from stocks", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (textBoxStockID.Text == reader["stock_id"].ToString())
                {
                    control = false;
                    panelTopColor.BackColor = Color.Red;
                    labelMessage.ForeColor = Color.Red;
                    labelMessage.Text = "Böyle bir stok zaten kayıtlı!";
                }
            }
            if (control == true)
            {
                OleDbCommand cmdInsert = new OleDbCommand("insert into stocks values(@p1,@p2,@p3,@p4,@p5,now,@p6)", cnn);
                cmdInsert.Parameters.AddWithValue("@p1", textBoxStockID.Text);
                cmdInsert.Parameters.AddWithValue("@p2", textBoxStockName.Text);
                cmdInsert.Parameters.AddWithValue("@p3", textBoxStockType.Text);
                cmdInsert.Parameters.AddWithValue("@p4", textBoxStockPrice.Text);
                cmdInsert.Parameters.AddWithValue("@p5", textBoxStockNumber.Text);
                cmdInsert.Parameters.AddWithValue("@p6", Login.userId);
                cmdInsert.ExecuteNonQuery();
                updateStocks();
                panelTopColor.BackColor = Color.Lime;
                labelMessage.ForeColor = Color.Green;
                labelMessage.Text = "Müşteri başarıyla eklendi!";
                // added records
                OleDbCommand cmdAddedRecordsStock = new OleDbCommand("insert into added_records values(@p1,@p2,now,@p3,@p4)", cnn);
                cmdAddedRecordsStock.Parameters.AddWithValue("@p1", textBoxStockID.Text);
                cmdAddedRecordsStock.Parameters.AddWithValue("@p2", textBoxStockName.Text);
                cmdAddedRecordsStock.Parameters.AddWithValue("@p3", Login.userId);
                cmdAddedRecordsStock.Parameters.AddWithValue("@p4", "stock");
                cmdAddedRecordsStock.ExecuteNonQuery();
            }
            cnn.Close();
        }

        // stok güncelle
        private void buttonStockUpdate_Click(object sender, EventArgs e)
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("update stocks set stock_name=@p1, stock_type=@p2, stock_price=@p3, stock_number=@p4 where stock_id=@p5", cnn);
            cmd.Parameters.AddWithValue("@p1", textBoxStockName.Text);
            cmd.Parameters.AddWithValue("@p2", textBoxStockType.Text);
            cmd.Parameters.AddWithValue("@p3", textBoxStockPrice.Text);
            cmd.Parameters.AddWithValue("@p4", textBoxStockNumber.Text);
            cmd.Parameters.AddWithValue("@p5", textBoxStockID.Text);
            cmd.ExecuteNonQuery();
            panelTopColor.BackColor = Color.Lime;
            labelMessage.ForeColor = Color.Green;
            labelMessage.Text = "Stok başarıyla güncellendi!";
            updateStocks();
            cnn.Close();
        }

        // kullanıcılar cellclick
        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from users where user_id='" + dataGridViewUsers.CurrentRow.Cells["user_id"].Value.ToString() + "'", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["user_avatar"].ToString() == "none")
                {
                    pictureBoxUsers.ImageLocation = null;
                }
                else
                {
                    pictureBoxUsers.ImageLocation = "files/images/users/" + reader["user_avatar"].ToString();
                }
                textBoxUserID.Text = reader["user_id"].ToString();
                textBoxUserName.Text = reader["user_name"].ToString();
                textBoxUserAuthority.Text = reader["user_authority"].ToString();
                if (reader["user_authority"].ToString() == "admin")
                {
                    labelUserAuthority.ForeColor = Color.Red;
                }
                else
                {
                    labelUserAuthority.ForeColor = Color.Black;
                }
            }
            cnn.Close();
        }

        // stok sil
        private void buttonStockDelete_Click(object sender, EventArgs e)
        {
            Boolean control = false;
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from stocks", cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (textBoxStockID.Text == reader["stock_id"].ToString())
                {
                    // deleted records
                    OleDbCommand cmdDeletedRecordsStock = new OleDbCommand("insert into deleted_records values(@p1,@p2,now,@p3,@p4)", cnn);
                    cmdDeletedRecordsStock.Parameters.AddWithValue("@p1", textBoxStockID.Text);
                    cmdDeletedRecordsStock.Parameters.AddWithValue("@p2", textBoxStockName.Text);
                    cmdDeletedRecordsStock.Parameters.AddWithValue("@p3", Login.userId);
                    cmdDeletedRecordsStock.Parameters.AddWithValue("@p4", "stock");
                    cmdDeletedRecordsStock.ExecuteNonQuery();
                    control = true;
                    OleDbCommand cmdDelete = new OleDbCommand("delete * from stocks where stock_id=@p1", cnn);
                    cmdDelete.Parameters.AddWithValue("@p1", textBoxStockID.Text);
                    cmdDelete.ExecuteNonQuery();
                    panelTopColor.BackColor = Color.Lime;
                    labelMessage.ForeColor = Color.Green;
                    labelMessage.Text = "Kayıt başarıyla silindi!";
                    updateStocks();
                }
            }
            if (control == false)
            {
                panelTopColor.BackColor = Color.Red;
                labelMessage.ForeColor = Color.Red;
                labelMessage.Text = "Böyle bir kayıt mevcut değil!";
            }
            cnn.Close();
        }

        // yeni satış
        private void buttonNewSale_Click(object sender, EventArgs e)
        {
            NewSale newSale = new NewSale();
            this.Hide();
            newSale.Show();
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

        public static string customerID;

        // müşteri detayları
        private void buttonCustomerDetails_Click(object sender, EventArgs e)
        {
            Boolean control = false;
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from customers",cnn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (textBoxCustomerID.Text == reader["customer_id"].ToString())
                {
                    control = true;
                    customerID = textBoxCustomerID.Text;
                    CustomerDetails customerDetails = new CustomerDetails();
                    this.Hide();
                    customerDetails.Show();
                }
            }
            if (control == false)
            {
                panelTopColor.BackColor = Color.Red;
                labelMessage.ForeColor = Color.Red;
                labelMessage.Text = "Böyle bir müşteri kayıtlı değil!";
            }
            cnn.Close();
        }
    }
}
