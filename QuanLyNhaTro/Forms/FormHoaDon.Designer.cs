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
            lblTitle = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            btnThem = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnLamMoi = new System.Windows.Forms.Button();
            btnThanhToan = new System.Windows.Forms.Button();
            lblTongTien = new System.Windows.Forms.Label();
            lblTongTienTitle = new System.Windows.Forms.Label();
            lblTrangThai = new System.Windows.Forms.Label();
            cmbTrangThai = new System.Windows.Forms.ComboBox();
            lblGhiChu = new System.Windows.Forms.Label();
            txtGhiChu = new System.Windows.Forms.TextBox();
            lblTienKhac = new System.Windows.Forms.Label();
            txtTienKhac = new System.Windows.Forms.TextBox();
            lblTienPhong = new System.Windows.Forms.Label();
            txtTienPhong = new System.Windows.Forms.TextBox();
            lblChiSoNuocMoi = new System.Windows.Forms.Label();
            txtChiSoNuocMoi = new System.Windows.Forms.TextBox();
            lblChiSoNuocCu = new System.Windows.Forms.Label();
            txtChiSoNuocCu = new System.Windows.Forms.TextBox();
            lblChiSoDienMoi = new System.Windows.Forms.Label();
            txtChiSoDienMoi = new System.Windows.Forms.TextBox();
            lblChiSoDienCu = new System.Windows.Forms.Label();
            txtChiSoDienCu = new System.Windows.Forms.TextBox();
            lblNgayTao = new System.Windows.Forms.Label();
            dtpNgayTao = new System.Windows.Forms.DateTimePicker();
            lblMaHopDong = new System.Windows.Forms.Label();
            cmbMaHopDong = new System.Windows.Forms.ComboBox();
            lblMaHoaDon = new System.Windows.Forms.Label();
            txtMaHoaDon = new System.Windows.Forms.TextBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            txtTimKiem = new System.Windows.Forms.TextBox();
            lblTimKiem = new System.Windows.Forms.Label();
            btnTimKiem = new System.Windows.Forms.Button();
            dgvHoaDon = new System.Windows.Forms.DataGridView();
            groupBox1.SuspendLayout();
            pnlButtons.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
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
            lblTitle.Size = new System.Drawing.Size(1052, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ HÓA ĐƠN";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
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
            groupBox1.Location = new System.Drawing.Point(19, 69);
            groupBox1.Margin = new System.Windows.Forms.Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4);
            groupBox1.Size = new System.Drawing.Size(1020, 262);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin hóa đơn";
            // 
            // pnlButtons
            // 
            pnlButtons.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            pnlButtons.Controls.Add(btnThem);
            pnlButtons.Controls.Add(btnSua);
            pnlButtons.Controls.Add(btnXoa);
            pnlButtons.Controls.Add(btnLamMoi);
            pnlButtons.Controls.Add(btnThanhToan);
            pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            pnlButtons.Location = new System.Drawing.Point(211, 204);
            pnlButtons.Margin = new System.Windows.Forms.Padding(4);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new System.Drawing.Size(578, 50);
            pnlButtons.TabIndex = 30;
            // 
            // btnThem
            // 
            btnThem.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnThem.ForeColor = System.Drawing.Color.White;
            btnThem.Location = new System.Drawing.Point(474, 4);
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
            btnSua.Location = new System.Drawing.Point(366, 4);
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
            btnXoa.Location = new System.Drawing.Point(258, 4);
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
            btnLamMoi.Location = new System.Drawing.Point(138, 4);
            btnLamMoi.Margin = new System.Windows.Forms.Padding(4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new System.Drawing.Size(112, 40);
            btnLamMoi.TabIndex = 15;
            btnLamMoi.Text = "🔄 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnThanhToan
            // 
            btnThanhToan.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnThanhToan.ForeColor = System.Drawing.Color.White;
            btnThanhToan.Location = new System.Drawing.Point(5, 4);
            btnThanhToan.Margin = new System.Windows.Forms.Padding(4);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new System.Drawing.Size(125, 40);
            btnThanhToan.TabIndex = 16;
            btnThanhToan.Text = "💰 Thanh toán";
            btnThanhToan.UseVisualStyleBackColor = false;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = UIHelper.Fonts.TitleSmall;
            lblTongTien.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            lblTongTien.Location = new System.Drawing.Point(867, 144);
            lblTongTien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new System.Drawing.Size(23, 27);
            lblTongTien.TabIndex = 11;
            lblTongTien.Text = "0";
            // 
            // lblTongTienTitle
            // 
            lblTongTienTitle.AutoSize = true;
            lblTongTienTitle.Font = UIHelper.Fonts.Button;
            lblTongTienTitle.Location = new System.Drawing.Point(747, 150);
            lblTongTienTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTongTienTitle.Name = "lblTongTienTitle";
            lblTongTienTitle.Size = new System.Drawing.Size(82, 19);
            lblTongTienTitle.TabIndex = 28;
            lblTongTienTitle.Text = "Tổng tiền:";
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new System.Drawing.Point(546, 41);
            lblTrangThai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new System.Drawing.Size(78, 20);
            lblTrangThai.TabIndex = 26;
            lblTrangThai.Text = "Trạng thái:";
            // 
            // cmbTrangThai
            // 
            cmbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbTrangThai.FormattingEnabled = true;
            cmbTrangThai.Items.AddRange(new object[] { "Chưa thanh toán", "Đã thanh toán" });
            cmbTrangThai.Location = new System.Drawing.Point(632, 36);
            cmbTrangThai.Margin = new System.Windows.Forms.Padding(4);
            cmbTrangThai.Name = "cmbTrangThai";
            cmbTrangThai.Size = new System.Drawing.Size(157, 28);
            cmbTrangThai.TabIndex = 10;
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.Location = new System.Drawing.Point(23, 153);
            lblGhiChu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new System.Drawing.Size(61, 20);
            lblGhiChu.TabIndex = 27;
            lblGhiChu.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new System.Drawing.Point(113, 150);
            txtGhiChu.Margin = new System.Windows.Forms.Padding(4);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new System.Drawing.Size(558, 27);
            txtGhiChu.TabIndex = 9;
            // 
            // lblTienKhac
            // 
            lblTienKhac.AutoSize = true;
            lblTienKhac.Location = new System.Drawing.Point(747, 79);
            lblTienKhac.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTienKhac.Name = "lblTienKhac";
            lblTienKhac.Size = new System.Drawing.Size(74, 20);
            lblTienKhac.TabIndex = 25;
            lblTienKhac.Text = "Tiền khác:";
            // 
            // txtTienKhac
            // 
            txtTienKhac.Location = new System.Drawing.Point(829, 76);
            txtTienKhac.Margin = new System.Windows.Forms.Padding(4);
            txtTienKhac.Name = "txtTienKhac";
            txtTienKhac.Size = new System.Drawing.Size(124, 27);
            txtTienKhac.TabIndex = 8;
            // 
            // lblTienPhong
            // 
            lblTienPhong.AutoSize = true;
            lblTienPhong.Location = new System.Drawing.Point(22, 79);
            lblTienPhong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTienPhong.Name = "lblTienPhong";
            lblTienPhong.Size = new System.Drawing.Size(87, 20);
            lblTienPhong.TabIndex = 24;
            lblTienPhong.Text = "Tiền phòng:";
            // 
            // txtTienPhong
            // 
            txtTienPhong.Location = new System.Drawing.Point(113, 75);
            txtTienPhong.Margin = new System.Windows.Forms.Padding(4);
            txtTienPhong.Name = "txtTienPhong";
            txtTienPhong.Size = new System.Drawing.Size(124, 27);
            txtTienPhong.TabIndex = 7;
            // 
            // lblChiSoNuocMoi
            // 
            lblChiSoNuocMoi.AutoSize = true;
            lblChiSoNuocMoi.Location = new System.Drawing.Point(486, 79);
            lblChiSoNuocMoi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblChiSoNuocMoi.Name = "lblChiSoNuocMoi";
            lblChiSoNuocMoi.Size = new System.Drawing.Size(78, 20);
            lblChiSoNuocMoi.TabIndex = 23;
            lblChiSoNuocMoi.Text = "Nước mới:";
            // 
            // txtChiSoNuocMoi
            // 
            txtChiSoNuocMoi.Location = new System.Drawing.Point(572, 75);
            txtChiSoNuocMoi.Margin = new System.Windows.Forms.Padding(4);
            txtChiSoNuocMoi.Name = "txtChiSoNuocMoi";
            txtChiSoNuocMoi.Size = new System.Drawing.Size(99, 27);
            txtChiSoNuocMoi.TabIndex = 6;
            // 
            // lblChiSoNuocCu
            // 
            lblChiSoNuocCu.AutoSize = true;
            lblChiSoNuocCu.Location = new System.Drawing.Point(286, 79);
            lblChiSoNuocCu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblChiSoNuocCu.Name = "lblChiSoNuocCu";
            lblChiSoNuocCu.Size = new System.Drawing.Size(67, 20);
            lblChiSoNuocCu.TabIndex = 22;
            lblChiSoNuocCu.Text = "Nước cũ:";
            // 
            // txtChiSoNuocCu
            // 
            txtChiSoNuocCu.Location = new System.Drawing.Point(366, 75);
            txtChiSoNuocCu.Margin = new System.Windows.Forms.Padding(4);
            txtChiSoNuocCu.Name = "txtChiSoNuocCu";
            txtChiSoNuocCu.Size = new System.Drawing.Size(103, 27);
            txtChiSoNuocCu.TabIndex = 5;
            // 
            // lblChiSoDienMoi
            // 
            lblChiSoDienMoi.AutoSize = true;
            lblChiSoDienMoi.Location = new System.Drawing.Point(491, 114);
            lblChiSoDienMoi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblChiSoDienMoi.Name = "lblChiSoDienMoi";
            lblChiSoDienMoi.Size = new System.Drawing.Size(73, 20);
            lblChiSoDienMoi.TabIndex = 21;
            lblChiSoDienMoi.Text = "Điện mới:";
            // 
            // txtChiSoDienMoi
            // 
            txtChiSoDienMoi.Location = new System.Drawing.Point(572, 111);
            txtChiSoDienMoi.Margin = new System.Windows.Forms.Padding(4);
            txtChiSoDienMoi.Name = "txtChiSoDienMoi";
            txtChiSoDienMoi.Size = new System.Drawing.Size(99, 27);
            txtChiSoDienMoi.TabIndex = 4;
            // 
            // lblChiSoDienCu
            // 
            lblChiSoDienCu.AutoSize = true;
            lblChiSoDienCu.Location = new System.Drawing.Point(286, 116);
            lblChiSoDienCu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblChiSoDienCu.Name = "lblChiSoDienCu";
            lblChiSoDienCu.Size = new System.Drawing.Size(62, 20);
            lblChiSoDienCu.TabIndex = 20;
            lblChiSoDienCu.Text = "Điện cũ:";
            // 
            // txtChiSoDienCu
            // 
            txtChiSoDienCu.Location = new System.Drawing.Point(366, 111);
            txtChiSoDienCu.Margin = new System.Windows.Forms.Padding(4);
            txtChiSoDienCu.Name = "txtChiSoDienCu";
            txtChiSoDienCu.Size = new System.Drawing.Size(103, 27);
            txtChiSoDienCu.TabIndex = 3;
            // 
            // lblNgayTao
            // 
            lblNgayTao.AutoSize = true;
            lblNgayTao.Location = new System.Drawing.Point(286, 41);
            lblNgayTao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblNgayTao.Name = "lblNgayTao";
            lblNgayTao.Size = new System.Drawing.Size(73, 20);
            lblNgayTao.TabIndex = 19;
            lblNgayTao.Text = "Ngày tạo:";
            // 
            // dtpNgayTao
            // 
            dtpNgayTao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpNgayTao.Location = new System.Drawing.Point(366, 37);
            dtpNgayTao.Margin = new System.Windows.Forms.Padding(4);
            dtpNgayTao.Name = "dtpNgayTao";
            dtpNgayTao.Size = new System.Drawing.Size(149, 27);
            dtpNgayTao.TabIndex = 2;
            // 
            // lblMaHopDong
            // 
            lblMaHopDong.AutoSize = true;
            lblMaHopDong.Location = new System.Drawing.Point(23, 116);
            lblMaHopDong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMaHopDong.Name = "lblMaHopDong";
            lblMaHopDong.Size = new System.Drawing.Size(80, 20);
            lblMaHopDong.TabIndex = 18;
            lblMaHopDong.Text = "Hợp đồng:";
            // 
            // cmbMaHopDong
            // 
            cmbMaHopDong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbMaHopDong.FormattingEnabled = true;
            cmbMaHopDong.Location = new System.Drawing.Point(113, 111);
            cmbMaHopDong.Margin = new System.Windows.Forms.Padding(4);
            cmbMaHopDong.Name = "cmbMaHopDong";
            cmbMaHopDong.Size = new System.Drawing.Size(146, 28);
            cmbMaHopDong.TabIndex = 1;
            // 
            // lblMaHoaDon
            // 
            lblMaHoaDon.AutoSize = true;
            lblMaHoaDon.Location = new System.Drawing.Point(23, 41);
            lblMaHoaDon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMaHoaDon.Name = "lblMaHoaDon";
            lblMaHoaDon.Size = new System.Drawing.Size(59, 20);
            lblMaHoaDon.TabIndex = 17;
            lblMaHoaDon.Text = "Mã HĐ:";
            // 
            // txtMaHoaDon
            // 
            txtMaHoaDon.Location = new System.Drawing.Point(113, 37);
            txtMaHoaDon.Margin = new System.Windows.Forms.Padding(4);
            txtMaHoaDon.Name = "txtMaHoaDon";
            txtMaHoaDon.Size = new System.Drawing.Size(124, 27);
            txtMaHoaDon.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox2.Controls.Add(txtTimKiem);
            groupBox2.Controls.Add(lblTimKiem);
            groupBox2.Controls.Add(btnTimKiem);
            groupBox2.Controls.Add(dgvHoaDon);
            groupBox2.Location = new System.Drawing.Point(19, 344);
            groupBox2.Margin = new System.Windows.Forms.Padding(4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4);
            groupBox2.Size = new System.Drawing.Size(1020, 263);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách hóa đơn";
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
            lblTimKiem.TabIndex = 3;
            lblTimKiem.Text = "Tìm kiếm:";
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
            btnTimKiem.TabIndex = 1;
            btnTimKiem.Text = "🔍 Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AllowUserToDeleteRows = false;
            dgvHoaDon.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
            dgvHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Location = new System.Drawing.Point(8, 68);
            dgvHoaDon.Margin = new System.Windows.Forms.Padding(4);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.RowHeadersWidth = 51;
            dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.Size = new System.Drawing.Size(1004, 187);
            dgvHoaDon.TabIndex = 0;
            dgvHoaDon.CellClick += dgvHoaDon_CellClick;
            // 
            // FormHoaDon
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(1052, 620);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lblTitle);
            Margin = new System.Windows.Forms.Padding(4);
            MinimumSize = new System.Drawing.Size(900, 580);
            Name = "FormHoaDon";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
    }
}

