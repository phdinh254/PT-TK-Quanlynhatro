namespace QuanLyNhaTro.Forms
{
    partial class FormDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDangNhap));
            pnlMain = new System.Windows.Forms.Panel();
            pnlLogin = new System.Windows.Forms.Panel();
            panel1 = new System.Windows.Forms.Panel();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            btnThoat = new System.Windows.Forms.Button();
            btnDangNhap = new System.Windows.Forms.Button();
            txtMatKhau = new System.Windows.Forms.TextBox();
            txtTenDangNhap = new System.Windows.Forms.TextBox();
            lblTitle = new System.Windows.Forms.Label();
            lblStatus = new System.Windows.Forms.Label();
            pnlMain.SuspendLayout();
            pnlLogin.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(pnlLogin);
            pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlMain.Location = new System.Drawing.Point(0, 0);
            pnlMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new System.Drawing.Size(1002, 533);
            pnlMain.TabIndex = 0;
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = System.Drawing.Color.White;
            pnlLogin.BackgroundImage = (System.Drawing.Image)resources.GetObject("pnlLogin.BackgroundImage");
            pnlLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pnlLogin.Controls.Add(panel1);
            pnlLogin.Controls.Add(lblStatus);
            pnlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlLogin.Location = new System.Drawing.Point(0, 0);
            pnlLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Padding = new System.Windows.Forms.Padding(40, 50, 40, 50);
            pnlLogin.Size = new System.Drawing.Size(1002, 533);
            pnlLogin.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnThoat);
            panel1.Controls.Add(btnDangNhap);
            panel1.Controls.Add(txtMatKhau);
            panel1.Controls.Add(txtTenDangNhap);
            panel1.Controls.Add(lblTitle);
            panel1.Location = new System.Drawing.Point(80, 37);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(847, 461);
            panel1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(27, 60);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(386, 322);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnThoat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnThoat.ForeColor = System.Drawing.Color.White;
            btnThoat.Location = new System.Drawing.Point(651, 303);
            btnThoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new System.Drawing.Size(120, 45);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnDangNhap.FlatAppearance.BorderSize = 0;
            btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDangNhap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnDangNhap.ForeColor = System.Drawing.Color.White;
            btnDangNhap.Location = new System.Drawing.Point(491, 303);
            btnDangNhap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new System.Drawing.Size(120, 45);
            btnDangNhap.TabIndex = 6;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // txtMatKhau
            // 
            txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 12F);
            txtMatKhau.Location = new System.Drawing.Point(491, 233);
            txtMatKhau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '●';
            txtMatKhau.PlaceholderText = "Mật khẩu";
            txtMatKhau.Size = new System.Drawing.Size(280, 34);
            txtMatKhau.TabIndex = 5;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtTenDangNhap.Font = new System.Drawing.Font("Segoe UI", 12F);
            txtTenDangNhap.Location = new System.Drawing.Point(491, 167);
            txtTenDangNhap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.PlaceholderText = "Tên đăng nhâp";
            txtTenDangNhap.Size = new System.Drawing.Size(280, 34);
            txtTenDangNhap.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI Black", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            lblTitle.Location = new System.Drawing.Point(521, 87);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(219, 50);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Đăng nhập";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblStatus.Location = new System.Drawing.Point(381, 461);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(0, 20);
            lblStatus.TabIndex = 8;
            // 
            // FormDangNhap
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1002, 533);
            Controls.Add(pnlMain);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "FormDangNhap";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Đăng nhập - Quản lý nhà trọ";
            FormClosed += FormDangNhap_FormClosed;
            pnlMain.ResumeLayout(false);
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}