namespace QuanLyNhaTro.Forms
{
    partial class FormPhong
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            txtMoTa = new System.Windows.Forms.TextBox();
            pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            btnThem = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnLamMoi = new System.Windows.Forms.Button();
            btnDatPhong = new System.Windows.Forms.Button();
            cmbLoaiPhong = new System.Windows.Forms.ComboBox();
            cmbTrangThai = new System.Windows.Forms.ComboBox();
            txtDienTich = new System.Windows.Forms.TextBox();
            txtGiaPhong = new System.Windows.Forms.TextBox();
            txtTenPhong = new System.Windows.Forms.TextBox();
            txtMaPhong = new System.Windows.Forms.TextBox();
            lblMoTa = new System.Windows.Forms.Label();
            lblDienTich = new System.Windows.Forms.Label();
            lblLoaiPhong = new System.Windows.Forms.Label();
            lblTrangThai = new System.Windows.Forms.Label();
            lblGiaPhong = new System.Windows.Forms.Label();
            lblTenPhong = new System.Windows.Forms.Label();
            lblMaPhong = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            btnTimKiem = new System.Windows.Forms.Button();
            txtTimKiem = new System.Windows.Forms.TextBox();
            lblTimKiem = new System.Windows.Forms.Label();
            dgvPhong = new System.Windows.Forms.DataGridView();
            groupBox1.SuspendLayout();
            pnlButtons.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).BeginInit();
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
            lblTitle.Size = new System.Drawing.Size(1102, 62);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ PHÒNG";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(txtMoTa);
            groupBox1.Controls.Add(pnlButtons);
            groupBox1.Controls.Add(cmbLoaiPhong);
            groupBox1.Controls.Add(cmbTrangThai);
            groupBox1.Controls.Add(txtDienTich);
            groupBox1.Controls.Add(txtGiaPhong);
            groupBox1.Controls.Add(txtTenPhong);
            groupBox1.Controls.Add(txtMaPhong);
            groupBox1.Controls.Add(lblMoTa);
            groupBox1.Controls.Add(lblDienTich);
            groupBox1.Controls.Add(lblLoaiPhong);
            groupBox1.Controls.Add(lblTrangThai);
            groupBox1.Controls.Add(lblGiaPhong);
            groupBox1.Controls.Add(lblTenPhong);
            groupBox1.Controls.Add(lblMaPhong);
            groupBox1.Location = new System.Drawing.Point(19, 69);
            groupBox1.Margin = new System.Windows.Forms.Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4);
            groupBox1.Size = new System.Drawing.Size(1064, 272);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin phòng";
            // 
            // txtMoTa
            // 
            txtMoTa.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtMoTa.Location = new System.Drawing.Point(130, 137);
            txtMoTa.Margin = new System.Windows.Forms.Padding(4);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new System.Drawing.Size(871, 65);
            txtMoTa.TabIndex = 22;
            // 
            // pnlButtons
            // 
            pnlButtons.Anchor = System.Windows.Forms.AnchorStyles.Top;
            pnlButtons.Controls.Add(btnThem);
            pnlButtons.Controls.Add(btnSua);
            pnlButtons.Controls.Add(btnXoa);
            pnlButtons.Controls.Add(btnLamMoi);
            pnlButtons.Controls.Add(btnDatPhong);
            pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            pnlButtons.WrapContents = false;
            pnlButtons.Location = new System.Drawing.Point(275, 216);
            pnlButtons.Margin = new System.Windows.Forms.Padding(4);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.AutoSize = true;
            pnlButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            pnlButtons.BackColor = System.Drawing.Color.Transparent;
            pnlButtons.Size = new System.Drawing.Size(726, 48);
            pnlButtons.TabIndex = 21;
            // 
            // btnThem
            // 
            btnThem.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnThem.ForeColor = System.Drawing.Color.White;
            btnThem.Location = new System.Drawing.Point(342, 4);
            btnThem.Margin = new System.Windows.Forms.Padding(4);
            btnThem.Name = "btnThem";
            btnThem.Size = new System.Drawing.Size(100, 40);
            btnThem.TabIndex = 14;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSua.ForeColor = System.Drawing.Color.White;
            btnSua.Location = new System.Drawing.Point(234, 4);
            btnSua.Margin = new System.Windows.Forms.Padding(4);
            btnSua.Name = "btnSua";
            btnSua.Size = new System.Drawing.Size(100, 40);
            btnSua.TabIndex = 15;
            btnSua.Text = "✏️ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnXoa.ForeColor = System.Drawing.Color.White;
            btnXoa.Location = new System.Drawing.Point(126, 4);
            btnXoa.Margin = new System.Windows.Forms.Padding(4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new System.Drawing.Size(100, 40);
            btnXoa.TabIndex = 16;
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLamMoi.ForeColor = System.Drawing.Color.White;
            btnLamMoi.Location = new System.Drawing.Point(6, 4);
            btnLamMoi.Margin = new System.Windows.Forms.Padding(4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new System.Drawing.Size(112, 40);
            btnLamMoi.TabIndex = 17;
            btnLamMoi.Text = "🔄 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnDatPhong
            // 
            btnDatPhong.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnDatPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDatPhong.ForeColor = System.Drawing.Color.White;
            btnDatPhong.Location = new System.Drawing.Point(342, 52);
            btnDatPhong.Margin = new System.Windows.Forms.Padding(4);
            btnDatPhong.Name = "btnDatPhong";
            btnDatPhong.Size = new System.Drawing.Size(140, 40);
            btnDatPhong.TabIndex = 18;
            btnDatPhong.Text = "📝 Đặt phòng";
            btnDatPhong.UseVisualStyleBackColor = false;
            btnDatPhong.Visible = false;
            btnDatPhong.Click += btnDatPhong_Click;
            // 
            // cmbLoaiPhong
            // 
            cmbLoaiPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbLoaiPhong.FormattingEnabled = true;
            cmbLoaiPhong.Items.AddRange(new object[] { "Phòng đơn", "Phòng đôi", "Phòng VIP", "Phòng gia đình" });
            cmbLoaiPhong.Location = new System.Drawing.Point(802, 41);
            cmbLoaiPhong.Margin = new System.Windows.Forms.Padding(4);
            cmbLoaiPhong.Name = "cmbLoaiPhong";
            cmbLoaiPhong.Size = new System.Drawing.Size(199, 28);
            cmbLoaiPhong.TabIndex = 13;
            // 
            // cmbTrangThai
            // 
            cmbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbTrangThai.FormattingEnabled = true;
            cmbTrangThai.Items.AddRange(new object[] { "Trống", "Đã thuê", "Bảo trì" });
            cmbTrangThai.Location = new System.Drawing.Point(802, 91);
            cmbTrangThai.Margin = new System.Windows.Forms.Padding(4);
            cmbTrangThai.Name = "cmbTrangThai";
            cmbTrangThai.Size = new System.Drawing.Size(199, 28);
            cmbTrangThai.TabIndex = 12;
            // 
            // txtDienTich
            // 
            txtDienTich.Location = new System.Drawing.Point(434, 92);
            txtDienTich.Margin = new System.Windows.Forms.Padding(4);
            txtDienTich.Name = "txtDienTich";
            txtDienTich.Size = new System.Drawing.Size(199, 27);
            txtDienTich.TabIndex = 10;
            // 
            // txtGiaPhong
            // 
            txtGiaPhong.Location = new System.Drawing.Point(130, 87);
            txtGiaPhong.Margin = new System.Windows.Forms.Padding(4);
            txtGiaPhong.Name = "txtGiaPhong";
            txtGiaPhong.Size = new System.Drawing.Size(172, 27);
            txtGiaPhong.TabIndex = 9;
            // 
            // txtTenPhong
            // 
            txtTenPhong.Location = new System.Drawing.Point(434, 41);
            txtTenPhong.Margin = new System.Windows.Forms.Padding(4);
            txtTenPhong.Name = "txtTenPhong";
            txtTenPhong.Size = new System.Drawing.Size(199, 27);
            txtTenPhong.TabIndex = 8;
            // 
            // txtMaPhong
            // 
            txtMaPhong.Location = new System.Drawing.Point(130, 40);
            txtMaPhong.Margin = new System.Windows.Forms.Padding(4);
            txtMaPhong.Name = "txtMaPhong";
            txtMaPhong.Size = new System.Drawing.Size(172, 27);
            txtMaPhong.TabIndex = 7;
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new System.Drawing.Point(47, 140);
            lblMoTa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new System.Drawing.Size(51, 20);
            lblMoTa.TabIndex = 6;
            lblMoTa.Text = "Mô tả:";
            // 
            // lblDienTich
            // 
            lblDienTich.AutoSize = true;
            lblDienTich.Location = new System.Drawing.Point(344, 95);
            lblDienTich.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblDienTich.Name = "lblDienTich";
            lblDienTich.Size = new System.Drawing.Size(71, 20);
            lblDienTich.TabIndex = 5;
            lblDienTich.Text = "Diện tích:";
            // 
            // lblLoaiPhong
            // 
            lblLoaiPhong.AutoSize = true;
            lblLoaiPhong.Location = new System.Drawing.Point(707, 44);
            lblLoaiPhong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblLoaiPhong.Name = "lblLoaiPhong";
            lblLoaiPhong.Size = new System.Drawing.Size(87, 20);
            lblLoaiPhong.TabIndex = 4;
            lblLoaiPhong.Text = "Loại phòng:";
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new System.Drawing.Point(707, 94);
            lblTrangThai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new System.Drawing.Size(78, 20);
            lblTrangThai.TabIndex = 3;
            lblTrangThai.Text = "Trạng thái:";
            // 
            // lblGiaPhong
            // 
            lblGiaPhong.AutoSize = true;
            lblGiaPhong.Location = new System.Drawing.Point(44, 91);
            lblGiaPhong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblGiaPhong.Name = "lblGiaPhong";
            lblGiaPhong.Size = new System.Drawing.Size(81, 20);
            lblGiaPhong.TabIndex = 2;
            lblGiaPhong.Text = "Giá phòng:";
            // 
            // lblTenPhong
            // 
            lblTenPhong.AutoSize = true;
            lblTenPhong.Location = new System.Drawing.Point(344, 44);
            lblTenPhong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTenPhong.Name = "lblTenPhong";
            lblTenPhong.Size = new System.Drawing.Size(82, 20);
            lblTenPhong.TabIndex = 1;
            lblTenPhong.Text = "Tên phòng:";
            // 
            // lblMaPhong
            // 
            lblMaPhong.AutoSize = true;
            lblMaPhong.Location = new System.Drawing.Point(44, 44);
            lblMaPhong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMaPhong.Name = "lblMaPhong";
            lblMaPhong.Size = new System.Drawing.Size(80, 20);
            lblMaPhong.TabIndex = 0;
            lblMaPhong.Text = "Mã phòng:";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox2.Controls.Add(btnTimKiem);
            groupBox2.Controls.Add(txtTimKiem);
            groupBox2.Controls.Add(lblTimKiem);
            groupBox2.Controls.Add(dgvPhong);
            groupBox2.Location = new System.Drawing.Point(19, 359);
            groupBox2.Margin = new System.Windows.Forms.Padding(4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4);
            groupBox2.Size = new System.Drawing.Size(1064, 313);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách phòng";
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
            // dgvPhong
            // 
            dgvPhong.AllowUserToAddRows = false;
            dgvPhong.AllowUserToDeleteRows = false;
            dgvPhong.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhong.BackgroundColor = System.Drawing.Color.White;
            dgvPhong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhong.Location = new System.Drawing.Point(19, 69);
            dgvPhong.Margin = new System.Windows.Forms.Padding(4);
            dgvPhong.Name = "dgvPhong";
            dgvPhong.ReadOnly = true;
            dgvPhong.RowHeadersWidth = 51;
            dgvPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvPhong.Size = new System.Drawing.Size(1027, 232);
            dgvPhong.TabIndex = 0;
            dgvPhong.CellClick += dgvPhong_CellClick;
            // 
            // FormPhong
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            ClientSize = new System.Drawing.Size(1102, 691);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lblTitle);
            Margin = new System.Windows.Forms.Padding(4);
            MinimumSize = new System.Drawing.Size(1120, 738);
            Name = "FormPhong";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Quản lý phòng";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            pnlButtons.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnDatPhong;
        private System.Windows.Forms.ComboBox cmbLoaiPhong;
        private System.Windows.Forms.ComboBox cmbTrangThai;
        private System.Windows.Forms.TextBox txtDienTich;
        private System.Windows.Forms.TextBox txtGiaPhong;
        private System.Windows.Forms.TextBox txtTenPhong;
        private System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblDienTich;
        private System.Windows.Forms.Label lblLoaiPhong;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblGiaPhong;
        private System.Windows.Forms.Label lblTenPhong;
        private System.Windows.Forms.Label lblMaPhong;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.DataGridView dgvPhong;
    }
}



