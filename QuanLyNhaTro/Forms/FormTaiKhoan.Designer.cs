namespace QuanLyNhaTro.Forms
{
    partial class FormTaiKhoan
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
            groupBox1 = new System.Windows.Forms.GroupBox();
            pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            btnThem = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnLamMoi = new System.Windows.Forms.Button();
            chkTrangThai = new System.Windows.Forms.CheckBox();
            lblTrangThai = new System.Windows.Forms.Label();
            cmbVaiTro = new System.Windows.Forms.ComboBox();
            lblVaiTro = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
            lblEmail = new System.Windows.Forms.Label();
            txtHoTen = new System.Windows.Forms.TextBox();
            lblHoTen = new System.Windows.Forms.Label();
            txtMatKhau = new System.Windows.Forms.TextBox();
            lblMatKhau = new System.Windows.Forms.Label();
            txtTenDangNhap = new System.Windows.Forms.TextBox();
            lblTenDangNhap = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            btnTimKiem = new System.Windows.Forms.Button();
            txtTimKiem = new System.Windows.Forms.TextBox();
            lblTimKiem = new System.Windows.Forms.Label();
            dgvTaiKhoan = new System.Windows.Forms.DataGridView();
            groupBox1.SuspendLayout();
            pnlButtons.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            lblTitle.Location = new System.Drawing.Point(0, 0);
            lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(1125, 62);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ TÀI KHOẢN";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(pnlButtons);
            groupBox1.Controls.Add(chkTrangThai);
            groupBox1.Controls.Add(lblTrangThai);
            groupBox1.Controls.Add(cmbVaiTro);
            groupBox1.Controls.Add(lblVaiTro);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(lblEmail);
            groupBox1.Controls.Add(txtHoTen);
            groupBox1.Controls.Add(lblHoTen);
            groupBox1.Controls.Add(txtMatKhau);
            groupBox1.Controls.Add(lblMatKhau);
            groupBox1.Controls.Add(txtTenDangNhap);
            groupBox1.Controls.Add(lblTenDangNhap);
            groupBox1.Location = new System.Drawing.Point(19, 62);
            groupBox1.Margin = new System.Windows.Forms.Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4);
            groupBox1.Size = new System.Drawing.Size(1088, 206);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin tài khoản";
            // 
            // pnlButtons
            // 
            pnlButtons.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            pnlButtons.Controls.Add(btnThem);
            pnlButtons.Controls.Add(btnSua);
            pnlButtons.Controls.Add(btnXoa);
            pnlButtons.Controls.Add(btnLamMoi);
            pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            pnlButtons.Location = new System.Drawing.Point(82, 148);
            pnlButtons.Margin = new System.Windows.Forms.Padding(4);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new System.Drawing.Size(675, 50);
            pnlButtons.TabIndex = 17;
            // 
            // btnThem
            // 
            btnThem.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnThem.ForeColor = System.Drawing.Color.White;
            btnThem.Location = new System.Drawing.Point(571, 4);
            btnThem.Margin = new System.Windows.Forms.Padding(4);
            btnThem.Name = "btnThem";
            btnThem.Size = new System.Drawing.Size(100, 40);
            btnThem.TabIndex = 12;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSua.ForeColor = System.Drawing.Color.White;
            btnSua.Location = new System.Drawing.Point(463, 4);
            btnSua.Margin = new System.Windows.Forms.Padding(4);
            btnSua.Name = "btnSua";
            btnSua.Size = new System.Drawing.Size(100, 40);
            btnSua.TabIndex = 13;
            btnSua.Text = "✏️ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnXoa.ForeColor = System.Drawing.Color.White;
            btnXoa.Location = new System.Drawing.Point(355, 4);
            btnXoa.Margin = new System.Windows.Forms.Padding(4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new System.Drawing.Size(100, 40);
            btnXoa.TabIndex = 14;
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLamMoi.ForeColor = System.Drawing.Color.White;
            btnLamMoi.Location = new System.Drawing.Point(235, 4);
            btnLamMoi.Margin = new System.Windows.Forms.Padding(4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new System.Drawing.Size(112, 40);
            btnLamMoi.TabIndex = 15;
            btnLamMoi.Text = "🔄 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // chkTrangThai
            // 
            chkTrangThai.AutoSize = true;
            chkTrangThai.Checked = true;
            chkTrangThai.CheckState = System.Windows.Forms.CheckState.Checked;
            chkTrangThai.Location = new System.Drawing.Point(786, 94);
            chkTrangThai.Margin = new System.Windows.Forms.Padding(4);
            chkTrangThai.Name = "chkTrangThai";
            chkTrangThai.Size = new System.Drawing.Size(103, 24);
            chkTrangThai.TabIndex = 11;
            chkTrangThai.Text = "Hoạt động";
            chkTrangThai.UseVisualStyleBackColor = true;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new System.Drawing.Point(700, 95);
            lblTrangThai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new System.Drawing.Size(78, 20);
            lblTrangThai.TabIndex = 10;
            lblTrangThai.Text = "Trạng thái:";
            // 
            // cmbVaiTro
            // 
            cmbVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbVaiTro.FormattingEnabled = true;
            cmbVaiTro.Items.AddRange(new object[] { "Admin", "User" });
            cmbVaiTro.Location = new System.Drawing.Point(457, 90);
            cmbVaiTro.Margin = new System.Windows.Forms.Padding(4);
            cmbVaiTro.Name = "cmbVaiTro";
            cmbVaiTro.Size = new System.Drawing.Size(149, 28);
            cmbVaiTro.TabIndex = 9;
            // 
            // lblVaiTro
            // 
            lblVaiTro.AutoSize = true;
            lblVaiTro.Location = new System.Drawing.Point(376, 93);
            lblVaiTro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblVaiTro.Name = "lblVaiTro";
            lblVaiTro.Size = new System.Drawing.Size(55, 20);
            lblVaiTro.TabIndex = 8;
            lblVaiTro.Text = "Vai trò:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new System.Drawing.Point(112, 90);
            txtEmail.Margin = new System.Windows.Forms.Padding(4);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "abcxzy@gmail.com";
            txtEmail.Size = new System.Drawing.Size(249, 27);
            txtEmail.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new System.Drawing.Point(25, 95);
            lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new System.Drawing.Size(49, 20);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new System.Drawing.Point(765, 40);
            txtHoTen.Margin = new System.Windows.Forms.Padding(4);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new System.Drawing.Size(249, 27);
            txtHoTen.TabIndex = 5;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new System.Drawing.Point(700, 43);
            lblHoTen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new System.Drawing.Size(57, 20);
            lblHoTen.TabIndex = 4;
            lblHoTen.Text = "Họ tên:";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new System.Drawing.Point(457, 41);
            txtMatKhau.Margin = new System.Windows.Forms.Padding(4);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new System.Drawing.Size(186, 27);
            txtMatKhau.TabIndex = 3;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new System.Drawing.Point(376, 44);
            lblMatKhau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new System.Drawing.Size(73, 20);
            lblMatKhau.TabIndex = 2;
            lblMatKhau.Text = "Mật khẩu:";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new System.Drawing.Point(143, 41);
            txtTenDangNhap.Margin = new System.Windows.Forms.Padding(4);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new System.Drawing.Size(186, 27);
            txtTenDangNhap.TabIndex = 1;
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Location = new System.Drawing.Point(25, 44);
            lblTenDangNhap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new System.Drawing.Size(110, 20);
            lblTenDangNhap.TabIndex = 0;
            lblTenDangNhap.Text = "Tên đăng nhập:";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox2.Controls.Add(btnTimKiem);
            groupBox2.Controls.Add(txtTimKiem);
            groupBox2.Controls.Add(lblTimKiem);
            groupBox2.Controls.Add(dgvTaiKhoan);
            groupBox2.Location = new System.Drawing.Point(19, 275);
            groupBox2.Margin = new System.Windows.Forms.Padding(4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4);
            groupBox2.Size = new System.Drawing.Size(1088, 431);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách tài khoản";
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTimKiem.ForeColor = System.Drawing.Color.White;
            btnTimKiem.Location = new System.Drawing.Point(475, 25);
            btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new System.Drawing.Size(125, 35);
            btnTimKiem.TabIndex = 3;
            btnTimKiem.Text = "🔍 Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new System.Drawing.Point(100, 29);
            txtTimKiem.Margin = new System.Windows.Forms.Padding(4);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new System.Drawing.Size(349, 27);
            txtTimKiem.TabIndex = 2;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new System.Drawing.Point(25, 32);
            lblTimKiem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new System.Drawing.Size(73, 20);
            lblTimKiem.TabIndex = 1;
            lblTimKiem.Text = "Tìm kiếm:";
            // 
            // dgvTaiKhoan
            // 
            dgvTaiKhoan.AllowUserToAddRows = false;
            dgvTaiKhoan.AllowUserToDeleteRows = false;
            dgvTaiKhoan.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvTaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvTaiKhoan.BackgroundColor = System.Drawing.Color.White;
            dgvTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTaiKhoan.Location = new System.Drawing.Point(19, 69);
            dgvTaiKhoan.Margin = new System.Windows.Forms.Padding(4);
            dgvTaiKhoan.Name = "dgvTaiKhoan";
            dgvTaiKhoan.ReadOnly = true;
            dgvTaiKhoan.RowHeadersWidth = 51;
            dgvTaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvTaiKhoan.Size = new System.Drawing.Size(1050, 350);
            dgvTaiKhoan.TabIndex = 0;
            dgvTaiKhoan.CellClick += dgvTaiKhoan_CellClick;
            // 
            // FormTaiKhoan
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(1125, 725);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lblTitle);
            Margin = new System.Windows.Forms.Padding(4);
            MinimumSize = new System.Drawing.Size(1058, 676);
            Name = "FormTaiKhoan";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Quản lý tài khoản";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            pnlButtons.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.ComboBox cmbVaiTro;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.CheckBox chkTrangThai;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
    }
}
