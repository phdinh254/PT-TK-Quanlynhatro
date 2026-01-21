namespace QuanLyNhaTro.Forms
{
    partial class FormThongTinCaNhan
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
            panelMain = new System.Windows.Forms.Panel();
            btnDong = new System.Windows.Forms.Button();
            btnCapNhat = new System.Windows.Forms.Button();
            cmbGioiTinh = new System.Windows.Forms.ComboBox();
            lblGioiTinh = new System.Windows.Forms.Label();
            dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            lblNgaySinh = new System.Windows.Forms.Label();
            txtDiaChi = new System.Windows.Forms.TextBox();
            lblDiaChi = new System.Windows.Forms.Label();
            txtCMND = new System.Windows.Forms.TextBox();
            lblCMND = new System.Windows.Forms.Label();
            txtSoDienThoai = new System.Windows.Forms.TextBox();
            lblSoDienThoai = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
            lblEmail = new System.Windows.Forms.Label();
            txtHoTen = new System.Windows.Forms.TextBox();
            lblHoTen = new System.Windows.Forms.Label();
            txtTenDangNhap = new System.Windows.Forms.TextBox();
            lblTenDangNhap = new System.Windows.Forms.Label();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            lblTitle.Location = new System.Drawing.Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(629, 80);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THÔNG TIN CÁ NHÂN";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMain
            // 
            panelMain.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            panelMain.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelMain.Controls.Add(btnDong);
            panelMain.Controls.Add(btnCapNhat);
            panelMain.Controls.Add(cmbGioiTinh);
            panelMain.Controls.Add(lblGioiTinh);
            panelMain.Controls.Add(dtpNgaySinh);
            panelMain.Controls.Add(lblNgaySinh);
            panelMain.Controls.Add(txtDiaChi);
            panelMain.Controls.Add(lblDiaChi);
            panelMain.Controls.Add(txtCMND);
            panelMain.Controls.Add(lblCMND);
            panelMain.Controls.Add(txtSoDienThoai);
            panelMain.Controls.Add(lblSoDienThoai);
            panelMain.Controls.Add(txtEmail);
            panelMain.Controls.Add(lblEmail);
            panelMain.Controls.Add(txtHoTen);
            panelMain.Controls.Add(lblHoTen);
            panelMain.Controls.Add(txtTenDangNhap);
            panelMain.Controls.Add(lblTenDangNhap);
            panelMain.Location = new System.Drawing.Point(23, 107);
            panelMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Size = new System.Drawing.Size(583, 747);
            panelMain.TabIndex = 1;
            // 
            // btnDong
            // 
            btnDong.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
            btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDong.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            btnDong.ForeColor = System.Drawing.Color.White;
            btnDong.Location = new System.Drawing.Point(389, 533);
            btnDong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnDong.Name = "btnDong";
            btnDong.Size = new System.Drawing.Size(171, 53);
            btnDong.TabIndex = 17;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = false;
            btnDong.Click += btnDong_Click;
            // 
            // btnCapNhat
            // 
            btnCapNhat.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCapNhat.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            btnCapNhat.ForeColor = System.Drawing.Color.White;
            btnCapNhat.Location = new System.Drawing.Point(183, 533);
            btnCapNhat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new System.Drawing.Size(171, 53);
            btnCapNhat.TabIndex = 16;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = false;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // cmbGioiTinh
            // 
            cmbGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbGioiTinh.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular);
            cmbGioiTinh.FormattingEnabled = true;
            cmbGioiTinh.Items.AddRange(new object[] { "Nam", "N?", "Khác" });
            cmbGioiTinh.Location = new System.Drawing.Point(183, 449);
            cmbGioiTinh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cmbGioiTinh.Name = "cmbGioiTinh";
            cmbGioiTinh.Size = new System.Drawing.Size(377, 27);
            cmbGioiTinh.TabIndex = 15;
            // 
            // lblGioiTinh
            // 
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular);
            lblGioiTinh.Location = new System.Drawing.Point(23, 453);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new System.Drawing.Size(75, 19);
            lblGioiTinh.TabIndex = 14;
            lblGioiTinh.Text = "Giới tính:";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular);
            dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new System.Drawing.Point(183, 396);
            dtpNgaySinh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new System.Drawing.Size(377, 27);
            dtpNgaySinh.TabIndex = 13;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular);
            lblNgaySinh.Location = new System.Drawing.Point(23, 400);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new System.Drawing.Size(81, 19);
            lblNgaySinh.TabIndex = 12;
            lblNgaySinh.Text = "Ngày sinh:";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular);
            txtDiaChi.Location = new System.Drawing.Point(183, 289);
            txtDiaChi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtDiaChi.Multiline = true;
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new System.Drawing.Size(377, 79);
            txtDiaChi.TabIndex = 11;
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular);
            lblDiaChi.Location = new System.Drawing.Point(23, 293);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new System.Drawing.Size(63, 19);
            lblDiaChi.TabIndex = 10;
            lblDiaChi.Text = "Địa chỉ:";
            // 
            // txtCMND
            // 
            txtCMND.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular);
            txtCMND.Location = new System.Drawing.Point(183, 236);
            txtCMND.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtCMND.Name = "txtCMND";
            txtCMND.Size = new System.Drawing.Size(377, 27);
            txtCMND.TabIndex = 9;
            // 
            // lblCMND
            // 
            lblCMND.AutoSize = true;
            lblCMND.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular);
            lblCMND.Location = new System.Drawing.Point(23, 240);
            lblCMND.Name = "lblCMND";
            lblCMND.Size = new System.Drawing.Size(114, 19);
            lblCMND.TabIndex = 8;
            lblCMND.Text = "CMND/CCCD:";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular);
            txtSoDienThoai.Location = new System.Drawing.Point(183, 183);
            txtSoDienThoai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new System.Drawing.Size(377, 27);
            txtSoDienThoai.TabIndex = 7;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular);
            lblSoDienThoai.Location = new System.Drawing.Point(23, 187);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new System.Drawing.Size(99, 19);
            lblSoDienThoai.TabIndex = 6;
            lblSoDienThoai.Text = "Số điện thoại";
            // 
            // txtEmail
            // 
            txtEmail.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular);
            txtEmail.Location = new System.Drawing.Point(183, 129);
            txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new System.Drawing.Size(377, 27);
            txtEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular);
            lblEmail.Location = new System.Drawing.Point(23, 133);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new System.Drawing.Size(54, 19);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular);
            txtHoTen.Location = new System.Drawing.Point(183, 76);
            txtHoTen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new System.Drawing.Size(377, 27);
            txtHoTen.TabIndex = 3;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular);
            lblHoTen.Location = new System.Drawing.Point(23, 80);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new System.Drawing.Size(60, 19);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Họ tên:";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular);
            txtTenDangNhap.Location = new System.Drawing.Point(183, 23);
            txtTenDangNhap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new System.Drawing.Size(377, 27);
            txtTenDangNhap.TabIndex = 1;
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular);
            lblTenDangNhap.Location = new System.Drawing.Point(23, 27);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new System.Drawing.Size(110, 19);
            lblTenDangNhap.TabIndex = 0;
            lblTenDangNhap.Text = "Tên đăng nhập:";
            // 
            // FormThongTinCaNhan
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            ClientSize = new System.Drawing.Size(629, 880);
            Controls.Add(panelMain);
            Controls.Add(lblTitle);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormThongTinCaNhan";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Thông tin cá nhân";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblCMND;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.ComboBox cmbGioiTinh;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnDong;
    }
}




