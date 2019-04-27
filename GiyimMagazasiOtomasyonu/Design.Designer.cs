namespace GiyimMagazasiOtomasyonu
{
    partial class Design
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Design));
            this.panelTopColor = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBoxUserAvatar = new System.Windows.Forms.PictureBox();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.labelHeader = new System.Windows.Forms.Label();
            this.pictureBoxMinimize = new System.Windows.Forms.PictureBox();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelBot = new System.Windows.Forms.Panel();
            this.labelMessage = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonProfileSettings = new System.Windows.Forms.Button();
            this.buttonAdminPanel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTopColor
            // 
            this.panelTopColor.BackColor = System.Drawing.Color.Orange;
            this.panelTopColor.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelTopColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopColor.Location = new System.Drawing.Point(0, 0);
            this.panelTopColor.Name = "panelTopColor";
            this.panelTopColor.Size = new System.Drawing.Size(991, 5);
            this.panelTopColor.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Black;
            this.panelTop.Controls.Add(this.pictureBoxUserAvatar);
            this.panelTop.Controls.Add(this.labelWelcome);
            this.panelTop.Controls.Add(this.labelHeader);
            this.panelTop.Controls.Add(this.pictureBoxMinimize);
            this.panelTop.Controls.Add(this.pictureBoxClose);
            this.panelTop.Controls.Add(this.pictureBoxLogo);
            this.panelTop.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 5);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(991, 47);
            this.panelTop.TabIndex = 1;
            // 
            // pictureBoxUserAvatar
            // 
            this.pictureBoxUserAvatar.Location = new System.Drawing.Point(369, 4);
            this.pictureBoxUserAvatar.Name = "pictureBoxUserAvatar";
            this.pictureBoxUserAvatar.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxUserAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxUserAvatar.TabIndex = 35;
            this.pictureBoxUserAvatar.TabStop = false;
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.BackColor = System.Drawing.Color.Transparent;
            this.labelWelcome.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelWelcome.ForeColor = System.Drawing.Color.White;
            this.labelWelcome.Location = new System.Drawing.Point(415, 8);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(100, 30);
            this.labelWelcome.TabIndex = 6;
            this.labelWelcome.Text = "Welcome";
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.BackColor = System.Drawing.Color.Transparent;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(79, 8);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(284, 30);
            this.labelHeader.TabIndex = 3;
            this.labelHeader.Text = "Giyim Mağazası Otomasyonu";
            // 
            // pictureBoxMinimize
            // 
            this.pictureBoxMinimize.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxMinimize.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMinimize.Image")));
            this.pictureBoxMinimize.Location = new System.Drawing.Point(902, 3);
            this.pictureBoxMinimize.Name = "pictureBoxMinimize";
            this.pictureBoxMinimize.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMinimize.TabIndex = 5;
            this.pictureBoxMinimize.TabStop = false;
            this.pictureBoxMinimize.Click += new System.EventHandler(this.pictureBoxMinimize_Click);
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.Image")));
            this.pictureBoxClose.Location = new System.Drawing.Point(948, 3);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxClose.TabIndex = 4;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(70, 41);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 3;
            this.pictureBoxLogo.TabStop = false;
            // 
            // panelBot
            // 
            this.panelBot.BackColor = System.Drawing.Color.DodgerBlue;
            this.panelBot.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBot.Location = new System.Drawing.Point(0, 612);
            this.panelBot.Name = "panelBot";
            this.panelBot.Size = new System.Drawing.Size(991, 5);
            this.panelBot.TabIndex = 2;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.BackColor = System.Drawing.Color.Transparent;
            this.labelMessage.Font = new System.Drawing.Font("Segoe UI", 13.75F);
            this.labelMessage.ForeColor = System.Drawing.Color.Black;
            this.labelMessage.Location = new System.Drawing.Point(7, 581);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(62, 25);
            this.labelMessage.TabIndex = 9;
            this.labelMessage.Text = "Mesaj";
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.Red;
            this.buttonLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLogout.FlatAppearance.BorderSize = 0;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.buttonLogout.ForeColor = System.Drawing.Color.White;
            this.buttonLogout.Location = new System.Drawing.Point(842, 578);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(149, 34);
            this.buttonLogout.TabIndex = 27;
            this.buttonLogout.Text = "Çıkış Yap";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonProfileSettings
            // 
            this.buttonProfileSettings.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonProfileSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonProfileSettings.FlatAppearance.BorderSize = 0;
            this.buttonProfileSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProfileSettings.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.buttonProfileSettings.ForeColor = System.Drawing.Color.White;
            this.buttonProfileSettings.Location = new System.Drawing.Point(693, 578);
            this.buttonProfileSettings.Name = "buttonProfileSettings";
            this.buttonProfileSettings.Size = new System.Drawing.Size(149, 34);
            this.buttonProfileSettings.TabIndex = 28;
            this.buttonProfileSettings.Text = "Profil Ayarları";
            this.buttonProfileSettings.UseVisualStyleBackColor = false;
            this.buttonProfileSettings.Click += new System.EventHandler(this.buttonProfileSettings_Click);
            // 
            // buttonAdminPanel
            // 
            this.buttonAdminPanel.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonAdminPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdminPanel.FlatAppearance.BorderSize = 0;
            this.buttonAdminPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdminPanel.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.buttonAdminPanel.ForeColor = System.Drawing.Color.White;
            this.buttonAdminPanel.Location = new System.Drawing.Point(544, 578);
            this.buttonAdminPanel.Name = "buttonAdminPanel";
            this.buttonAdminPanel.Size = new System.Drawing.Size(149, 34);
            this.buttonAdminPanel.TabIndex = 29;
            this.buttonAdminPanel.Text = "Admin Paneli";
            this.buttonAdminPanel.UseVisualStyleBackColor = false;
            this.buttonAdminPanel.Click += new System.EventHandler(this.buttonAdminPanel_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Orange;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(12, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(297, 53);
            this.button1.TabIndex = 30;
            this.button1.Text = "Ürünler";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Design
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(991, 617);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonAdminPanel);
            this.Controls.Add(this.buttonProfileSettings);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.panelBot);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelTopColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Design";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giyim Mağazası Otomasyonu";
            this.Load += new System.EventHandler(this.Design_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTopColor;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBot;
        private System.Windows.Forms.PictureBox pictureBoxMinimize;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonProfileSettings;
        private System.Windows.Forms.Button buttonAdminPanel;
        private System.Windows.Forms.PictureBox pictureBoxUserAvatar;
        private System.Windows.Forms.Button button1;
    }
}