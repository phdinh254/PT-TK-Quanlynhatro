namespace QuanLyNhaTro.Forms
{
    partial class FormDangKy
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new System.Windows.Forms.Label();
            lblTenDangNhap = new System.Windows.Forms.Label();
            txtTenDangNhap = new System.Windows.Forms.TextBox();
            lblHoTen = new System.Windows.Forms.Label();
            txtHoTen = new System.Windows.Forms.TextBox();
            lblEmail = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
            lblMatKhau = new System.Windows.Forms.Label();
            txtMatKhau = new System.Windows.Forms.TextBox();
            lblXacNhanMatKhau = new System.Windows.Forms.Label();
            txtXacNhanMatKhau = new System.Windows.Forms.TextBox();
            chkDongY = new System.Windows.Forms.CheckBox();
            btnDangKy = new System.Windows.Forms.Button();
            btnHuy = new System.Windows.Forms.Button();
            linkDangNhap = new System.Windows.Forms.LinkLabel();
            panelMain = new System.Windows.Forms.Panel();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            lblTitle.Location = new System.Drawing.Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(571, 80);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐĂNG KÝ TÀI KHOẢN";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblTenDangNhap.Location = new System.Drawing.Point(23, 27);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new System.Drawing.Size(128, 23);
            lblTenDangNhap.TabIndex = 0;
            lblTenDangNhap.Text = "Tên đăng nhập:";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtTenDangNhap.Location = new System.Drawing.Point(23, 60);
            txtTenDangNhap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new System.Drawing.Size(457, 30);
            txtTenDangNhap.TabIndex = 1;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblHoTen.Location = new System.Drawing.Point(23, 113);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new System.Drawing.Size(66, 23);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtHoTen.Location = new System.Drawing.Point(23, 147);
            txtHoTen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new System.Drawing.Size(457, 30);
            txtHoTen.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblEmail.Location = new System.Drawing.Point(23, 200);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new System.Drawing.Size(55, 23);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtEmail.Location = new System.Drawing.Point(23, 233);
            txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new System.Drawing.Size(457, 30);
            txtEmail.TabIndex = 5;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblMatKhau.Location = new System.Drawing.Point(23, 287);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new System.Drawing.Size(86, 23);
            lblMatKhau.TabIndex = 6;
            lblMatKhau.Text = "Mật khẩu:";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtMatKhau.Location = new System.Drawing.Point(23, 320);
            txtMatKhau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '?';
            txtMatKhau.Size = new System.Drawing.Size(457, 30);
            txtMatKhau.TabIndex = 7;
            // 
            // lblXacNhanMatKhau
            // 
            lblXacNhanMatKhau.AutoSize = true;
            lblXacNhanMatKhau.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblXacNhanMatKhau.Location = new System.Drawing.Point(23, 373);
            lblXacNhanMatKhau.Name = "lblXacNhanMatKhau";
            lblXacNhanMatKhau.Size = new System.Drawing.Size(162, 23);
            lblXacNhanMatKhau.TabIndex = 8;
            lblXacNhanMatKhau.Text = "Xác nhận mật khẩu:";
            // 
            // txtXacNhanMatKhau
            // 
            txtXacNhanMatKhau.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtXacNhanMatKhau.Location = new System.Drawing.Point(23, 407);
            txtXacNhanMatKhau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            txtXacNhanMatKhau.PasswordChar = '?';
            txtXacNhanMatKhau.Size = new System.Drawing.Size(457, 30);
            txtXacNhanMatKhau.TabIndex = 9;
            // 
            // chkDongY
            // 
            chkDongY.AutoSize = true;
            chkDongY.Font = new System.Drawing.Font("Segoe UI", 9F);
            chkDongY.Location = new System.Drawing.Point(23, 460);
            chkDongY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            chkDongY.Name = "chkDongY";
            chkDongY.Size = new System.Drawing.Size(345, 24);
            chkDongY.TabIndex = 10;
            chkDongY.Text = "Tôi đồng ý với điều khoản và điều kiện sử dụng.";
            chkDongY.UseVisualStyleBackColor = true;
            // 
            // btnDangKy
            // 
            btnDangKy.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDangKy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnDangKy.ForeColor = System.Drawing.Color.White;
            btnDangKy.Location = new System.Drawing.Point(23, 507);
            btnDangKy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new System.Drawing.Size(223, 53);
            btnDangKy.TabIndex = 11;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = false;
            btnDangKy.Click += btnDangKy_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
            btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnHuy.ForeColor = System.Drawing.Color.White;
            btnHuy.Location = new System.Drawing.Point(257, 507);
            btnHuy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new System.Drawing.Size(223, 53);
            btnHuy.TabIndex = 12;
            btnHuy.Text = "Đóng";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // linkDangNhap
            // 
            linkDangNhap.AutoSize = true;
            linkDangNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            linkDangNhap.Location = new System.Drawing.Point(151, 575);
            linkDangNhap.Name = "linkDangNhap";
            linkDangNhap.Size = new System.Drawing.Size(200, 20);
            linkDangNhap.TabIndex = 13;
            linkDangNhap.TabStop = true;
            linkDangNhap.Text = "Đã có tài khoản? Đăng nhập.";
            linkDangNhap.LinkClicked += linkDangNhap_LinkClicked;
            // 
            // panelMain
            // 
            panelMain.BackColor = System.Drawing.Color.White;
            panelMain.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelMain.Controls.Add(linkDangNhap);
            panelMain.Controls.Add(btnHuy);
            panelMain.Controls.Add(btnDangKy);
            panelMain.Controls.Add(chkDongY);
            panelMain.Controls.Add(txtXacNhanMatKhau);
            panelMain.Controls.Add(lblXacNhanMatKhau);
            panelMain.Controls.Add(txtMatKhau);
            panelMain.Controls.Add(lblMatKhau);
            panelMain.Controls.Add(txtEmail);
            panelMain.Controls.Add(lblEmail);
            panelMain.Controls.Add(txtHoTen);
            panelMain.Controls.Add(lblHoTen);
            panelMain.Controls.Add(txtTenDangNhap);
            panelMain.Controls.Add(lblTenDangNhap);
            panelMain.Location = new System.Drawing.Point(34, 107);
            panelMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Size = new System.Drawing.Size(503, 613);
            panelMain.TabIndex = 1;
            // 
            // FormDangKy
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(571, 760);
            Controls.Add(panelMain);
            Controls.Add(lblTitle);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormDangKy";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Đăng ký tài khoản";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblXacNhanMatKhau;
        private System.Windows.Forms.TextBox txtXacNhanMatKhau;
        private System.Windows.Forms.CheckBox chkDongY;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.LinkLabel linkDangNhap;
        private System.Windows.Forms.Panel panelMain;
    }
}
