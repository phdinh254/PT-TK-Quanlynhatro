using Microsoft.Data.SqlClient;
using QuanLyNhaTro.Data;
using System;
using System.Windows.Forms;

namespace QuanLyNhaTro.Forms
{
    partial class FormHoaDon
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
            lblTitle = new Label();
            groupBox1 = new GroupBox();
            pnlButtons = new FlowLayoutPanel();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnThanhToan = new Button();
            btnXuatPdf = new Button();
            lblTongTien = new Label();
            lblTongTienTitle = new Label();
            lblTrangThai = new Label();
            cmbTrangThai = new ComboBox();
            lblGhiChu = new Label();
            txtGhiChu = new TextBox();
            lblTienKhac = new Label();
            txtTienKhac = new TextBox();
            lblTienPhong = new Label();
            txtTienPhong = new TextBox();
            lblChiSoNuocMoi = new Label();
            txtChiSoNuocMoi = new TextBox();
            lblChiSoNuocCu = new Label();
            txtChiSoNuocCu = new TextBox();
            lblChiSoDienMoi = new Label();
            txtChiSoDienMoi = new TextBox();
            lblChiSoDienCu = new Label();
            txtChiSoDienCu = new TextBox();
            lblNgayTao = new Label();
            dtpNgayTao = new DateTimePicker();
            lblMaHopDong = new Label();
            cmbMaHopDong = new ComboBox();
            lblMaHoaDon = new Label();
            txtMaHoaDon = new TextBox();
            groupBox2 = new GroupBox();
            txtTimKiem = new TextBox();
            lblTimKiem = new Label();
            btnTimKiem = new Button();
            dgvHoaDon = new DataGridView();
            groupBox1.SuspendLayout();
            pnlButtons.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            lblTitle.Location = new System.Drawing.Point(0, 0);
            lblTitle.Margin = new Padding(5, 0, 5, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(1315, 75);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ HÓA ĐƠN";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(pnlButtons);
            groupBox1.Controls.Add(lblTongTien);
            groupBox1.Controls.Add(lblTongTienTitle);
            groupBox1.Controls.Add(lblTrangThai);
            groupBox1.Controls.Add(cmbTrangThai);
            groupBox1.Controls.Add(lblGhiChu);
            groupBox1.Controls.Add(txtGhiChu);
            groupBox1.Controls.Add(lblTienKhac);
            groupBox1.Controls.Add(txtTienKhac);
            groupBox1.Controls.Add(lblTienPhong);
            groupBox1.Controls.Add(txtTienPhong);
            groupBox1.Controls.Add(lblChiSoNuocMoi);
            groupBox1.Controls.Add(txtChiSoNuocMoi);
            groupBox1.Controls.Add(lblChiSoNuocCu);
            groupBox1.Controls.Add(txtChiSoNuocCu);
            groupBox1.Controls.Add(lblChiSoDienMoi);
            groupBox1.Controls.Add(txtChiSoDienMoi);
            groupBox1.Controls.Add(lblChiSoDienCu);
            groupBox1.Controls.Add(txtChiSoDienCu);
            groupBox1.Controls.Add(lblNgayTao);
            groupBox1.Controls.Add(dtpNgayTao);
            groupBox1.Controls.Add(lblMaHopDong);
            groupBox1.Controls.Add(cmbMaHopDong);
            groupBox1.Controls.Add(lblMaHoaDon);
            groupBox1.Controls.Add(txtMaHoaDon);
            groupBox1.Location = new System.Drawing.Point(24, 86);
            groupBox1.Margin = new Padding(5, 5, 5, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5, 5, 5, 5);
            groupBox1.Size = new System.Drawing.Size(1275, 328);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin hóa đơn";
            // 
            // pnlButtons
            // 
            pnlButtons.Anchor = AnchorStyles.Top;
            pnlButtons.BackColor = System.Drawing.Color.Transparent;
            pnlButtons.Controls.Add(btnThem);
            pnlButtons.Controls.Add(btnSua);
            pnlButtons.Controls.Add(btnXoa);
            pnlButtons.Controls.Add(btnLamMoi);
            pnlButtons.Controls.Add(btnThanhToan);
            pnlButtons.Controls.Add(btnXuatPdf);
            pnlButtons.FlowDirection = FlowDirection.LeftToRight;
            pnlButtons.WrapContents = false;
            pnlButtons.Location = new System.Drawing.Point(263, 256);
            pnlButtons.Margin = new Padding(5, 5, 5, 5);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.AutoSize = true;
            pnlButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            pnlButtons.Size = new System.Drawing.Size(722, 62);
            pnlButtons.TabIndex = 30;
            // 
            // btnThem
            // 
            btnThem.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.ForeColor = System.Drawing.Color.White;
            btnThem.Location = new System.Drawing.Point(592, 5);
            btnThem.Margin = new Padding(5, 5, 5, 5);
            btnThem.Name = "btnThem";
            btnThem.Size = new System.Drawing.Size(125, 50);
            btnThem.TabIndex = 12;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.ForeColor = System.Drawing.Color.White;
            btnSua.Location = new System.Drawing.Point(457, 5);
            btnSua.Margin = new Padding(5, 5, 5, 5);
            btnSua.Name = "btnSua";
            btnSua.Size = new System.Drawing.Size(125, 50);
            btnSua.TabIndex = 13;
            btnSua.Text = "✏️ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.ForeColor = System.Drawing.Color.White;
            btnXoa.Location = new System.Drawing.Point(322, 5);
            btnXoa.Margin = new Padding(5, 5, 5, 5);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new System.Drawing.Size(125, 50);
            btnXoa.TabIndex = 14;
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.ForeColor = System.Drawing.Color.White;
            btnLamMoi.Location = new System.Drawing.Point(172, 5);
            btnLamMoi.Margin = new Padding(5, 5, 5, 5);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new System.Drawing.Size(140, 50);
            btnLamMoi.TabIndex = 15;
            btnLamMoi.Text = "🔄 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnThanhToan
            // 
            btnThanhToan.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            btnThanhToan.FlatStyle = FlatStyle.Flat;
            btnThanhToan.ForeColor = System.Drawing.Color.White;
            btnThanhToan.Location = new System.Drawing.Point(6, 5);
            btnThanhToan.Margin = new Padding(5, 5, 5, 5);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new System.Drawing.Size(156, 50);
            btnThanhToan.TabIndex = 16;
            btnThanhToan.Text = "💰 Thanh toán";
            btnThanhToan.UseVisualStyleBackColor = false;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // btnXuatPdf
            // 
            btnXuatPdf.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnXuatPdf.FlatStyle = FlatStyle.Flat;
            btnXuatPdf.ForeColor = System.Drawing.Color.White;
            btnXuatPdf.Location = new System.Drawing.Point(592, 65);
            btnXuatPdf.Margin = new Padding(5, 5, 5, 5);
            btnXuatPdf.Name = "btnXuatPdf";
            btnXuatPdf.Size = new System.Drawing.Size(125, 50);
            btnXuatPdf.TabIndex = 17;
            btnXuatPdf.Text = "📄 Xuất PDF";
            btnXuatPdf.UseVisualStyleBackColor = false;
            btnXuatPdf.Click += btnXuatPdf_Click;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            lblTongTien.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            lblTongTien.Location = new System.Drawing.Point(1084, 180);
            lblTongTien.Margin = new Padding(5, 0, 5, 0);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new System.Drawing.Size(30, 35);
            lblTongTien.TabIndex = 11;
            lblTongTien.Text = "0";
            // 
            // lblTongTienTitle
            // 
            lblTongTienTitle.AutoSize = true;
            lblTongTienTitle.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            lblTongTienTitle.Location = new System.Drawing.Point(934, 188);
            lblTongTienTitle.Margin = new Padding(5, 0, 5, 0);
            lblTongTienTitle.Name = "lblTongTienTitle";
            lblTongTienTitle.Size = new System.Drawing.Size(85, 19);
            lblTongTienTitle.TabIndex = 28;
            lblTongTienTitle.Text = "Tổng tiền:";
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new System.Drawing.Point(682, 51);
            lblTrangThai.Margin = new Padding(5, 0, 5, 0);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new System.Drawing.Size(78, 20);
            lblTrangThai.TabIndex = 26;
            lblTrangThai.Text = "Trạng thái:";
            // 
            // cmbTrangThai
            // 
            cmbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrangThai.FormattingEnabled = true;
            cmbTrangThai.Items.AddRange(new object[] { "Chưa thanh toán", "Đã thanh toán" });
            cmbTrangThai.Location = new System.Drawing.Point(790, 45);
            cmbTrangThai.Margin = new Padding(5, 5, 5, 5);
            cmbTrangThai.Name = "cmbTrangThai";
            cmbTrangThai.Size = new System.Drawing.Size(195, 28);
            cmbTrangThai.TabIndex = 10;
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.Location = new System.Drawing.Point(29, 191);
            lblGhiChu.Margin = new Padding(5, 0, 5, 0);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new System.Drawing.Size(61, 20);
            lblGhiChu.TabIndex = 27;
            lblGhiChu.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new System.Drawing.Point(141, 188);
            txtGhiChu.Margin = new Padding(5, 5, 5, 5);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new System.Drawing.Size(696, 27);
            txtGhiChu.TabIndex = 9;
            // 
            // lblTienKhac
            // 
            lblTienKhac.AutoSize = true;
            lblTienKhac.Location = new System.Drawing.Point(934, 99);
            lblTienKhac.Margin = new Padding(5, 0, 5, 0);
            lblTienKhac.Name = "lblTienKhac";
            lblTienKhac.Size = new System.Drawing.Size(74, 20);
            lblTienKhac.TabIndex = 25;
            lblTienKhac.Text = "Tiền khác:";
            // 
            // txtTienKhac
            // 
            txtTienKhac.Location = new System.Drawing.Point(1036, 95);
            txtTienKhac.Margin = new Padding(5, 5, 5, 5);
            txtTienKhac.Name = "txtTienKhac";
            txtTienKhac.Size = new System.Drawing.Size(154, 27);
            txtTienKhac.TabIndex = 8;
            // 
            // lblTienPhong
            // 
            lblTienPhong.AutoSize = true;
            lblTienPhong.Location = new System.Drawing.Point(28, 99);
            lblTienPhong.Margin = new Padding(5, 0, 5, 0);
            lblTienPhong.Name = "lblTienPhong";
            lblTienPhong.Size = new System.Drawing.Size(87, 20);
            lblTienPhong.TabIndex = 24;
            lblTienPhong.Text = "Tiền phòng:";
            // 
            // txtTienPhong
            // 
            txtTienPhong.Location = new System.Drawing.Point(141, 94);
            txtTienPhong.Margin = new Padding(5, 5, 5, 5);
            txtTienPhong.Name = "txtTienPhong";
            txtTienPhong.Size = new System.Drawing.Size(154, 27);
            txtTienPhong.TabIndex = 7;
            // 
            // lblChiSoNuocMoi
            // 
            lblChiSoNuocMoi.AutoSize = true;
            lblChiSoNuocMoi.Location = new System.Drawing.Point(608, 99);
            lblChiSoNuocMoi.Margin = new Padding(5, 0, 5, 0);
            lblChiSoNuocMoi.Name = "lblChiSoNuocMoi";
            lblChiSoNuocMoi.Size = new System.Drawing.Size(78, 20);
            lblChiSoNuocMoi.TabIndex = 23;
            lblChiSoNuocMoi.Text = "Nước mới:";
            // 
            // txtChiSoNuocMoi
            // 
            txtChiSoNuocMoi.Location = new System.Drawing.Point(715, 94);
            txtChiSoNuocMoi.Margin = new Padding(5, 5, 5, 5);
            txtChiSoNuocMoi.Name = "txtChiSoNuocMoi";
            txtChiSoNuocMoi.Size = new System.Drawing.Size(123, 27);
            txtChiSoNuocMoi.TabIndex = 6;
            // 
            // lblChiSoNuocCu
            // 
            lblChiSoNuocCu.AutoSize = true;
            lblChiSoNuocCu.Location = new System.Drawing.Point(358, 99);
            lblChiSoNuocCu.Margin = new Padding(5, 0, 5, 0);
            lblChiSoNuocCu.Name = "lblChiSoNuocCu";
            lblChiSoNuocCu.Size = new System.Drawing.Size(67, 20);
            lblChiSoNuocCu.TabIndex = 22;
            lblChiSoNuocCu.Text = "Nước cũ:";
            // 
            // txtChiSoNuocCu
            // 
            txtChiSoNuocCu.Location = new System.Drawing.Point(458, 94);
            txtChiSoNuocCu.Margin = new Padding(5, 5, 5, 5);
            txtChiSoNuocCu.Name = "txtChiSoNuocCu";
            txtChiSoNuocCu.Size = new System.Drawing.Size(128, 27);
            txtChiSoNuocCu.TabIndex = 5;
            // 
            // lblChiSoDienMoi
            // 
            lblChiSoDienMoi.AutoSize = true;
            lblChiSoDienMoi.Location = new System.Drawing.Point(614, 142);
            lblChiSoDienMoi.Margin = new Padding(5, 0, 5, 0);
            lblChiSoDienMoi.Name = "lblChiSoDienMoi";
            lblChiSoDienMoi.Size = new System.Drawing.Size(73, 20);
            lblChiSoDienMoi.TabIndex = 21;
            lblChiSoDienMoi.Text = "Điện mới:";
            // 
            // txtChiSoDienMoi
            // 
            txtChiSoDienMoi.Location = new System.Drawing.Point(715, 139);
            txtChiSoDienMoi.Margin = new Padding(5, 5, 5, 5);
            txtChiSoDienMoi.Name = "txtChiSoDienMoi";
            txtChiSoDienMoi.Size = new System.Drawing.Size(123, 27);
            txtChiSoDienMoi.TabIndex = 4;
            // 
            // lblChiSoDienCu
            // 
            lblChiSoDienCu.AutoSize = true;
            lblChiSoDienCu.Location = new System.Drawing.Point(358, 145);
            lblChiSoDienCu.Margin = new Padding(5, 0, 5, 0);
            lblChiSoDienCu.Name = "lblChiSoDienCu";
            lblChiSoDienCu.Size = new System.Drawing.Size(62, 20);
            lblChiSoDienCu.TabIndex = 20;
            lblChiSoDienCu.Text = "Điện cũ:";
            // 
            // txtChiSoDienCu
            // 
            txtChiSoDienCu.Location = new System.Drawing.Point(458, 139);
            txtChiSoDienCu.Margin = new Padding(5, 5, 5, 5);
            txtChiSoDienCu.Name = "txtChiSoDienCu";
            txtChiSoDienCu.Size = new System.Drawing.Size(128, 27);
            txtChiSoDienCu.TabIndex = 3;
            // 
            // lblNgayTao
            // 
            lblNgayTao.AutoSize = true;
            lblNgayTao.Location = new System.Drawing.Point(358, 51);
            lblNgayTao.Margin = new Padding(5, 0, 5, 0);
            lblNgayTao.Name = "lblNgayTao";
            lblNgayTao.Size = new System.Drawing.Size(73, 20);
            lblNgayTao.TabIndex = 19;
            lblNgayTao.Text = "Ngày tạo:";
            // 
            // dtpNgayTao
            // 
            dtpNgayTao.Format = DateTimePickerFormat.Short;
            dtpNgayTao.Location = new System.Drawing.Point(458, 46);
            dtpNgayTao.Margin = new Padding(5, 5, 5, 5);
            dtpNgayTao.Name = "dtpNgayTao";
            dtpNgayTao.Size = new System.Drawing.Size(185, 27);
            dtpNgayTao.TabIndex = 2;
            // 
            // lblMaHopDong
            // 
            lblMaHopDong.AutoSize = true;
            lblMaHopDong.Location = new System.Drawing.Point(29, 145);
            lblMaHopDong.Margin = new Padding(5, 0, 5, 0);
            lblMaHopDong.Name = "lblMaHopDong";
            lblMaHopDong.Size = new System.Drawing.Size(80, 20);
            lblMaHopDong.TabIndex = 18;
            lblMaHopDong.Text = "Hợp đồng:";
            // 
            // cmbMaHopDong
            // 
            cmbMaHopDong.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaHopDong.FormattingEnabled = true;
            cmbMaHopDong.Location = new System.Drawing.Point(141, 139);
            cmbMaHopDong.Margin = new Padding(5, 5, 5, 5);
            cmbMaHopDong.Name = "cmbMaHopDong";
            cmbMaHopDong.Size = new System.Drawing.Size(182, 28);
            cmbMaHopDong.TabIndex = 1;
            // 
            // lblMaHoaDon
            // 
            lblMaHoaDon.AutoSize = true;
            lblMaHoaDon.Location = new System.Drawing.Point(29, 51);
            lblMaHoaDon.Margin = new Padding(5, 0, 5, 0);
            lblMaHoaDon.Name = "lblMaHoaDon";
            lblMaHoaDon.Size = new System.Drawing.Size(59, 20);
            lblMaHoaDon.TabIndex = 17;
            lblMaHoaDon.Text = "Mã HĐ:";
            // 
            // txtMaHoaDon
            // 
            txtMaHoaDon.Location = new System.Drawing.Point(141, 46);
            txtMaHoaDon.Margin = new Padding(5, 5, 5, 5);
            txtMaHoaDon.Name = "txtMaHoaDon";
            txtMaHoaDon.Size = new System.Drawing.Size(154, 27);
            txtMaHoaDon.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(txtTimKiem);
            groupBox2.Controls.Add(lblTimKiem);
            groupBox2.Controls.Add(btnTimKiem);
            groupBox2.Controls.Add(dgvHoaDon);
            groupBox2.Location = new System.Drawing.Point(24, 430);
            groupBox2.Margin = new Padding(5, 5, 5, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(5, 5, 5, 5);
            groupBox2.Size = new System.Drawing.Size(1275, 329);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách hóa đơn";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new System.Drawing.Point(125, 36);
            txtTimKiem.Margin = new Padding(5, 5, 5, 5);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new System.Drawing.Size(435, 27);
            txtTimKiem.TabIndex = 2;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new System.Drawing.Point(31, 40);
            lblTimKiem.Margin = new Padding(5, 0, 5, 0);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new System.Drawing.Size(73, 20);
            lblTimKiem.TabIndex = 3;
            lblTimKiem.Text = "Tìm kiếm:";
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.ForeColor = System.Drawing.Color.White;
            btnTimKiem.Location = new System.Drawing.Point(594, 31);
            btnTimKiem.Margin = new Padding(5, 5, 5, 5);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new System.Drawing.Size(156, 44);
            btnTimKiem.TabIndex = 1;
            btnTimKiem.Text = "🔍 Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AllowUserToDeleteRows = false;
            dgvHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
            dgvHoaDon.BorderStyle = BorderStyle.None;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Location = new System.Drawing.Point(10, 85);
            dgvHoaDon.Margin = new Padding(5, 5, 5, 5);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.RowHeadersWidth = 51;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.Size = new System.Drawing.Size(1255, 234);
            dgvHoaDon.TabIndex = 0;
            dgvHoaDon.CellClick += dgvHoaDon_CellClick;
            // 
            // FormHoaDon
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            ClientSize = new System.Drawing.Size(1315, 775);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lblTitle);
            Margin = new Padding(5, 5, 5, 5);
            MinimumSize = new System.Drawing.Size(1120, 713);
            Name = "FormHoaDon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý hóa đơn";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            pnlButtons.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Label lblMaHoaDon;
        private System.Windows.Forms.TextBox txtMaHoaDon;
        private System.Windows.Forms.Label lblMaHopDong;
        private System.Windows.Forms.ComboBox cmbMaHopDong;
        private System.Windows.Forms.Label lblNgayTao;
        private System.Windows.Forms.DateTimePicker dtpNgayTao;
        private System.Windows.Forms.Label lblChiSoDienCu;
        private System.Windows.Forms.TextBox txtChiSoDienCu;
        private System.Windows.Forms.Label lblChiSoDienMoi;
        private System.Windows.Forms.TextBox txtChiSoDienMoi;
        private System.Windows.Forms.Label lblChiSoNuocCu;
        private System.Windows.Forms.TextBox txtChiSoNuocCu;
        private System.Windows.Forms.Label lblChiSoNuocMoi;
        private System.Windows.Forms.TextBox txtChiSoNuocMoi;
        private System.Windows.Forms.Label lblTienPhong;
        private System.Windows.Forms.TextBox txtTienPhong;
        private System.Windows.Forms.Label lblTienKhac;
        private System.Windows.Forms.TextBox txtTienKhac;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cmbTrangThai;
        private System.Windows.Forms.Label lblTongTienTitle;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnXuatPdf;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
    }
}





