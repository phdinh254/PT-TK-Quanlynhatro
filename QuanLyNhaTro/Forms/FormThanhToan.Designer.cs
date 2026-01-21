using System;

namespace QuanLyNhaTro.Forms
{
    partial class FormThanhToan
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
            picQr = new System.Windows.Forms.PictureBox();
            btnHoanTat = new System.Windows.Forms.Button();
            btnDong = new System.Windows.Forms.Button();
            lblMaHoaDon = new System.Windows.Forms.Label();
            lblSoTien = new System.Windows.Forms.Label();
            lblNoiDung = new System.Windows.Forms.Label();
            lblMaHoaDonValue = new System.Windows.Forms.Label();
            lblSoTienValue = new System.Windows.Forms.Label();
            lblNoiDungValue = new System.Windows.Forms.Label();
            grpInfo = new System.Windows.Forms.GroupBox();
            lblBankInfo = new System.Windows.Forms.Label();
            lblQrStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)picQr).BeginInit();
            grpInfo.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Font = UIHelper.Fonts.TitleSmall;
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            lblTitle.Location = new System.Drawing.Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(946, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THANH TOÁN";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picQr
            // 
            picQr.Location = new System.Drawing.Point(25, 70);
            picQr.Name = "picQr";
            picQr.Size = new System.Drawing.Size(220, 220);
            picQr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picQr.TabIndex = 1;
            picQr.TabStop = false;
            // 
            // btnHoanTat
            // 
            btnHoanTat.Location = new System.Drawing.Point(298, 328);
            btnHoanTat.Name = "btnHoanTat";
            btnHoanTat.Size = new System.Drawing.Size(205, 35);
            btnHoanTat.TabIndex = 5;
            btnHoanTat.Text = "Hoàn tất thanh toán";
            btnHoanTat.UseVisualStyleBackColor = true;
            btnHoanTat.Click += new EventHandler(btnHoanTat_Click);
            // 
            // btnDong
            // 
            btnDong.Location = new System.Drawing.Point(549, 328);
            btnDong.Name = "btnDong";
            btnDong.Size = new System.Drawing.Size(80, 35);
            btnDong.TabIndex = 6;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += new EventHandler(btnDong_Click);
            // 
            // lblMaHoaDon
            // 
            lblMaHoaDon.AutoSize = true;
            lblMaHoaDon.Location = new System.Drawing.Point(12, 30);
            lblMaHoaDon.Name = "lblMaHoaDon";
            lblMaHoaDon.Size = new System.Drawing.Size(92, 20);
            lblMaHoaDon.TabIndex = 0;
            lblMaHoaDon.Text = "Mã hóa đơn:";
            // 
            // lblSoTien
            // 
            lblSoTien.AutoSize = true;
            lblSoTien.Location = new System.Drawing.Point(12, 70);
            lblSoTien.Name = "lblSoTien";
            lblSoTien.Size = new System.Drawing.Size(58, 20);
            lblSoTien.TabIndex = 2;
            lblSoTien.Text = "Số tiền:";
            // 
            // lblNoiDung
            // 
            lblNoiDung.AutoSize = true;
            lblNoiDung.Location = new System.Drawing.Point(12, 110);
            lblNoiDung.Name = "lblNoiDung";
            lblNoiDung.Size = new System.Drawing.Size(74, 20);
            lblNoiDung.TabIndex = 4;
            lblNoiDung.Text = "Nội dung:";
            // 
            // lblMaHoaDonValue
            // 
            lblMaHoaDonValue.AutoSize = true;
            lblMaHoaDonValue.Font = UIHelper.Fonts.LabelBold;
            lblMaHoaDonValue.Location = new System.Drawing.Point(12, 48);
            lblMaHoaDonValue.Name = "lblMaHoaDonValue";
            lblMaHoaDonValue.Size = new System.Drawing.Size(0, 20);
            lblMaHoaDonValue.TabIndex = 1;
            // 
            // lblSoTienValue
            // 
            lblSoTienValue.AutoSize = true;
            lblSoTienValue.Font = UIHelper.Fonts.LabelBold;
            lblSoTienValue.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            lblSoTienValue.Location = new System.Drawing.Point(12, 88);
            lblSoTienValue.Name = "lblSoTienValue";
            lblSoTienValue.Size = new System.Drawing.Size(0, 20);
            lblSoTienValue.TabIndex = 3;
            // 
            // lblNoiDungValue
            // 
            lblNoiDungValue.AutoSize = true;
            lblNoiDungValue.Font = UIHelper.Fonts.LabelBold;
            lblNoiDungValue.Location = new System.Drawing.Point(12, 128);
            lblNoiDungValue.Name = "lblNoiDungValue";
            lblNoiDungValue.Size = new System.Drawing.Size(0, 20);
            lblNoiDungValue.TabIndex = 5;
            // 
            // grpInfo
            // 
            grpInfo.Controls.Add(lblNoiDungValue);
            grpInfo.Controls.Add(lblSoTienValue);
            grpInfo.Controls.Add(lblMaHoaDonValue);
            grpInfo.Controls.Add(lblNoiDung);
            grpInfo.Controls.Add(lblSoTien);
            grpInfo.Controls.Add(lblMaHoaDon);
            grpInfo.Location = new System.Drawing.Point(265, 70);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new System.Drawing.Size(497, 175);
            grpInfo.TabIndex = 3;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin thanh toán";
            // 
            // lblBankInfo
            // 
            lblBankInfo.Location = new System.Drawing.Point(265, 248);
            lblBankInfo.Name = "lblBankInfo";
            lblBankInfo.Size = new System.Drawing.Size(497, 77);
            lblBankInfo.TabIndex = 4;
            lblBankInfo.Text = "Ngân hàng: Sacombank\r\nSố tài khoản: 070145453974\r\nChủ tài khoản: Trần Hoàng Long";
            // 
            // lblQrStatus
            // 
            lblQrStatus.Location = new System.Drawing.Point(25, 295);
            lblQrStatus.Name = "lblQrStatus";
            lblQrStatus.Size = new System.Drawing.Size(220, 40);
            lblQrStatus.TabIndex = 2;
            // 
            // FormThanhToan
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(946, 390);
            Controls.Add(btnDong);
            Controls.Add(btnHoanTat);
            Controls.Add(lblBankInfo);
            Controls.Add(grpInfo);
            Controls.Add(lblQrStatus);
            Controls.Add(picQr);
            Controls.Add(lblTitle);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormThanhToan";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Thanh toán";
            ((System.ComponentModel.ISupportInitialize)picQr).EndInit();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picQr;
        private System.Windows.Forms.Label lblQrStatus;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblMaHoaDon;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.Label lblMaHoaDonValue;
        private System.Windows.Forms.Label lblSoTienValue;
        private System.Windows.Forms.Label lblNoiDungValue;
        private System.Windows.Forms.Label lblBankInfo;
        private System.Windows.Forms.Button btnHoanTat;
        private System.Windows.Forms.Button btnDong;
    }
}
