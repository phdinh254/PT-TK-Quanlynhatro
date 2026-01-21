namespace QuanLyNhaTro.Forms
{
    partial class FormDoiMatKhau
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
            lblNote = new System.Windows.Forms.Label();
            btnHuy = new System.Windows.Forms.Button();
            btnDoiMatKhau = new System.Windows.Forms.Button();
            txtXacNhanMatKhau = new System.Windows.Forms.TextBox();
            lblXacNhanMatKhau = new System.Windows.Forms.Label();
            txtMatKhauMoi = new System.Windows.Forms.TextBox();
            lblMatKhauMoi = new System.Windows.Forms.Label();
            txtMatKhauCu = new System.Windows.Forms.TextBox();
            lblMatKhauCu = new System.Windows.Forms.Label();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Font = UIHelper.Fonts.Title;
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            lblTitle.Location = new System.Drawing.Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(514, 80);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐỔI MẬT KHẨU";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMain
            // 
            panelMain.BackColor = System.Drawing.Color.White;
            panelMain.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelMain.Controls.Add(lblNote);
            panelMain.Controls.Add(btnHuy);
            panelMain.Controls.Add(btnDoiMatKhau);
            panelMain.Controls.Add(txtXacNhanMatKhau);
            panelMain.Controls.Add(lblXacNhanMatKhau);
            panelMain.Controls.Add(txtMatKhauMoi);
            panelMain.Controls.Add(lblMatKhauMoi);
            panelMain.Controls.Add(txtMatKhauCu);
            panelMain.Controls.Add(lblMatKhauCu);
            panelMain.Location = new System.Drawing.Point(23, 107);
            panelMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Size = new System.Drawing.Size(469, 440);
            panelMain.TabIndex = 1;
            // 
            // lblNote
            // 
            lblNote.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Italic);
            lblNote.ForeColor = System.Drawing.Color.Gray;
            lblNote.Location = new System.Drawing.Point(23, 280);
            lblNote.Name = "lblNote";
            lblNote.Size = new System.Drawing.Size(307, 53);
            lblNote.TabIndex = 6;
            lblNote.Text = "* Mật khẩu phải có ít nhât 6 ký tự bao gồm: Chữ hoa, chữ thường, và số.";
            // 
            // btnHuy
            // 
            btnHuy.BackColor = System.Drawing.Color.IndianRed;
            btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnHuy.Font = UIHelper.Fonts.Button;
            btnHuy.ForeColor = System.Drawing.Color.White;
            btnHuy.Location = new System.Drawing.Point(240, 353);
            btnHuy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new System.Drawing.Size(206, 53);
            btnHuy.TabIndex = 8;
            btnHuy.Text = "Đóng";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnDoiMatKhau
            // 
            btnDoiMatKhau.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnDoiMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDoiMatKhau.Font = UIHelper.Fonts.Button;
            btnDoiMatKhau.ForeColor = System.Drawing.Color.White;
            btnDoiMatKhau.Location = new System.Drawing.Point(23, 353);
            btnDoiMatKhau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnDoiMatKhau.Name = "btnDoiMatKhau";
            btnDoiMatKhau.Size = new System.Drawing.Size(206, 53);
            btnDoiMatKhau.TabIndex = 7;
            btnDoiMatKhau.Text = "Đổi mật khẩu";
            btnDoiMatKhau.UseVisualStyleBackColor = false;
            btnDoiMatKhau.Click += btnDoiMatKhau_Click;
            // 
            // txtXacNhanMatKhau
            // 
            txtXacNhanMatKhau.Font = UIHelper.Fonts.Default;
            txtXacNhanMatKhau.Location = new System.Drawing.Point(23, 233);
            txtXacNhanMatKhau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            txtXacNhanMatKhau.PasswordChar = '?';
            txtXacNhanMatKhau.Size = new System.Drawing.Size(422, 27);
            txtXacNhanMatKhau.TabIndex = 5;
            // 
            // lblXacNhanMatKhau
            // 
            lblXacNhanMatKhau.AutoSize = true;
            lblXacNhanMatKhau.Font = UIHelper.Fonts.Default;
            lblXacNhanMatKhau.Location = new System.Drawing.Point(23, 200);
            lblXacNhanMatKhau.Name = "lblXacNhanMatKhau";
            lblXacNhanMatKhau.Size = new System.Drawing.Size(140, 19);
            lblXacNhanMatKhau.TabIndex = 4;
            lblXacNhanMatKhau.Text = "Xác nhận mật khẩu:";
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Font = UIHelper.Fonts.Default;
            txtMatKhauMoi.Location = new System.Drawing.Point(23, 147);
            txtMatKhauMoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.PasswordChar = '?';
            txtMatKhauMoi.Size = new System.Drawing.Size(422, 27);
            txtMatKhauMoi.TabIndex = 3;
            // 
            // lblMatKhauMoi
            // 
            lblMatKhauMoi.AutoSize = true;
            lblMatKhauMoi.Font = UIHelper.Fonts.Default;
            lblMatKhauMoi.Location = new System.Drawing.Point(23, 113);
            lblMatKhauMoi.Name = "lblMatKhauMoi";
            lblMatKhauMoi.Size = new System.Drawing.Size(107, 19);
            lblMatKhauMoi.TabIndex = 2;
            lblMatKhauMoi.Text = "Mật khẩu mới:";
            // 
            // txtMatKhauCu
            // 
            txtMatKhauCu.Font = UIHelper.Fonts.Default;
            txtMatKhauCu.Location = new System.Drawing.Point(23, 60);
            txtMatKhauCu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.PasswordChar = '?';
            txtMatKhauCu.Size = new System.Drawing.Size(422, 27);
            txtMatKhauCu.TabIndex = 1;
            // 
            // lblMatKhauCu
            // 
            lblMatKhauCu.AutoSize = true;
            lblMatKhauCu.Font = UIHelper.Fonts.Default;
            lblMatKhauCu.Location = new System.Drawing.Point(23, 27);
            lblMatKhauCu.Name = "lblMatKhauCu";
            lblMatKhauCu.Size = new System.Drawing.Size(96, 19);
            lblMatKhauCu.TabIndex = 0;
            lblMatKhauCu.Text = "Mật khẩu cũ:";
            // 
            // FormDoiMatKhau
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(514, 573);
            Controls.Add(panelMain);
            Controls.Add(lblTitle);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormDoiMatKhau";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "??i m?t kh?u";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblMatKhauCu;
        private System.Windows.Forms.TextBox txtMatKhauCu;
        private System.Windows.Forms.Label lblMatKhauMoi;
        private System.Windows.Forms.TextBox txtMatKhauMoi;
        private System.Windows.Forms.Label lblXacNhanMatKhau;
        private System.Windows.Forms.TextBox txtXacNhanMatKhau;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Button btnDoiMatKhau;
        private System.Windows.Forms.Button btnHuy;
    }
}

