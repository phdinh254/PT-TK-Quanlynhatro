namespace QuanLyNhaTro.Forms
{
    partial class FormDonDatPhong
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
            lblTrangThai = new System.Windows.Forms.Label();
            txtGhiChu = new System.Windows.Forms.TextBox();
            txtEmail = new System.Windows.Forms.TextBox();
            txtHoTenKhach = new System.Windows.Forms.TextBox();
            txtTenPhong = new System.Windows.Forms.TextBox();
            txtMaPhong = new System.Windows.Forms.TextBox();
            txtMaDonDat = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            btnDuyet = new System.Windows.Forms.Button();
            btnTuChoi = new System.Windows.Forms.Button();
            btnLamMoi = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            lblThongKe = new System.Windows.Forms.Label();
            btnTimKiem = new System.Windows.Forms.Button();
            txtTimKiem = new System.Windows.Forms.TextBox();
            lblTimKiem = new System.Windows.Forms.Label();
            dgvDonDat = new System.Windows.Forms.DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDonDat).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            lblTitle.Location = new System.Drawing.Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(1100, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ ĐƠN ĐẶT PHÒNG";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(lblTrangThai);
            groupBox1.Controls.Add(txtGhiChu);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtHoTenKhach);
            groupBox1.Controls.Add(txtTenPhong);
            groupBox1.Controls.Add(txtMaPhong);
            groupBox1.Controls.Add(txtMaDonDat);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnDuyet);
            groupBox1.Controls.Add(btnTuChoi);
            groupBox1.Controls.Add(btnLamMoi);
            groupBox1.Location = new System.Drawing.Point(20, 70);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(1060, 250);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin đơn đặt";
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            lblTrangThai.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            lblTrangThai.Location = new System.Drawing.Point(700, 30);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new System.Drawing.Size(0, 19);
            lblTrangThai.TabIndex = 16;
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new System.Drawing.Point(690, 60);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.ReadOnly = true;
            txtGhiChu.Size = new System.Drawing.Size(350, 60);
            txtGhiChu.TabIndex = 15;
            // 
            // txtEmail
            // 
            txtEmail.Location = new System.Drawing.Point(150, 165);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new System.Drawing.Size(300, 30);
            txtEmail.TabIndex = 14;
            // 
            // txtHoTenKhach
            // 
            txtHoTenKhach.Location = new System.Drawing.Point(150, 130);
            txtHoTenKhach.Name = "txtHoTenKhach";
            txtHoTenKhach.ReadOnly = true;
            txtHoTenKhach.Size = new System.Drawing.Size(300, 30);
            txtHoTenKhach.TabIndex = 13;
            // 
            // txtTenPhong
            // 
            txtTenPhong.Location = new System.Drawing.Point(150, 95);
            txtTenPhong.Name = "txtTenPhong";
            txtTenPhong.ReadOnly = true;
            txtTenPhong.Size = new System.Drawing.Size(300, 30);
            txtTenPhong.TabIndex = 12;
            // 
            // txtMaPhong
            // 
            txtMaPhong.Location = new System.Drawing.Point(150, 60);
            txtMaPhong.Name = "txtMaPhong";
            txtMaPhong.ReadOnly = true;
            txtMaPhong.Size = new System.Drawing.Size(150, 30);
            txtMaPhong.TabIndex = 11;
            // 
            // txtMaDonDat
            // 
            txtMaDonDat.Location = new System.Drawing.Point(150, 25);
            txtMaDonDat.Name = "txtMaDonDat";
            txtMaDonDat.ReadOnly = true;
            txtMaDonDat.Size = new System.Drawing.Size(150, 30);
            txtMaDonDat.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(620, 63);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(78, 22);
            label7.TabIndex = 9;
            label7.Text = "Ghi chú:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(620, 30);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(95, 22);
            label6.TabIndex = 8;
            label6.Text = "Trạng thái:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(30, 168);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(63, 22);
            label5.TabIndex = 7;
            label5.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(30, 133);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(96, 22);
            label4.TabIndex = 6;
            label4.Text = "Tên khách:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(30, 98);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(98, 22);
            label3.TabIndex = 5;
            label3.Text = "Tên phòng:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(30, 63);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(94, 22);
            label2.TabIndex = 4;
            label2.Text = "Mã phòng:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(30, 28);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(77, 22);
            label1.TabIndex = 3;
            label1.Text = "Mã đơn:";
            // 
            // btnDuyet
            // 
            btnDuyet.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnDuyet.Enabled = false;
            btnDuyet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDuyet.ForeColor = System.Drawing.Color.White;
            btnDuyet.Location = new System.Drawing.Point(690, 135);
            btnDuyet.Name = "btnDuyet";
            btnDuyet.Size = new System.Drawing.Size(100, 40);
            btnDuyet.TabIndex = 2;
            btnDuyet.Text = "Duyệt";
            btnDuyet.UseVisualStyleBackColor = false;
            btnDuyet.Click += btnDuyet_Click;
            // 
            // btnTuChoi
            // 
            btnTuChoi.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            btnTuChoi.Enabled = false;
            btnTuChoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTuChoi.ForeColor = System.Drawing.Color.White;
            btnTuChoi.Location = new System.Drawing.Point(800, 135);
            btnTuChoi.Name = "btnTuChoi";
            btnTuChoi.Size = new System.Drawing.Size(100, 40);
            btnTuChoi.TabIndex = 1;
            btnTuChoi.Text = "Từ chối";
            btnTuChoi.UseVisualStyleBackColor = false;
            btnTuChoi.Click += btnTuChoi_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLamMoi.ForeColor = System.Drawing.Color.White;
            btnLamMoi.Location = new System.Drawing.Point(910, 135);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new System.Drawing.Size(130, 40);
            btnLamMoi.TabIndex = 0;
            btnLamMoi.Text = "🔄 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox2.Controls.Add(lblThongKe);
            groupBox2.Controls.Add(btnTimKiem);
            groupBox2.Controls.Add(txtTimKiem);
            groupBox2.Controls.Add(lblTimKiem);
            groupBox2.Controls.Add(dgvDonDat);
            groupBox2.Location = new System.Drawing.Point(20, 330);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(1060, 340);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách đơn đặt";
            // 
            // lblThongKe
            // 
            lblThongKe.AutoSize = true;
            lblThongKe.Location = new System.Drawing.Point(20, 63);
            lblThongKe.Name = "lblThongKe";
            lblThongKe.Size = new System.Drawing.Size(0, 22);
            lblThongKe.TabIndex = 4;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTimKiem.ForeColor = System.Drawing.Color.White;
            btnTimKiem.Location = new System.Drawing.Point(450, 25);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new System.Drawing.Size(144, 30);
            btnTimKiem.TabIndex = 3;
            btnTimKiem.Text = "🔍 Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new System.Drawing.Point(100, 27);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new System.Drawing.Size(330, 30);
            txtTimKiem.TabIndex = 2;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new System.Drawing.Point(20, 30);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new System.Drawing.Size(68, 22);
            lblTimKiem.TabIndex = 1;
            lblTimKiem.Text = "🔍 Tìm";
            // 
            // dgvDonDat
            // 
            dgvDonDat.AllowUserToAddRows = false;
            dgvDonDat.AllowUserToDeleteRows = false;
            dgvDonDat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvDonDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDonDat.Location = new System.Drawing.Point(20, 90);
            dgvDonDat.Name = "dgvDonDat";
            dgvDonDat.ReadOnly = true;
            dgvDonDat.RowHeadersWidth = 51;
            dgvDonDat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvDonDat.Size = new System.Drawing.Size(1020, 240);
            dgvDonDat.TabIndex = 0;
            dgvDonDat.CellClick += dgvDonDat_CellClick;
            // 
            // FormDonDatPhong
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            ClientSize = new System.Drawing.Size(1100, 680);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lblTitle);
            Font = new System.Drawing.Font("Times New Roman", 12F);
            MinimumSize = new System.Drawing.Size(1116, 719);
            Name = "FormDonDatPhong";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Qu?n lý ??n ??t phòng";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDonDat).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtHoTenKhach;
        private System.Windows.Forms.TextBox txtTenPhong;
        private System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.TextBox txtMaDonDat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDuyet;
        private System.Windows.Forms.Button btnTuChoi;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblThongKe;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.DataGridView dgvDonDat;
    }
}



