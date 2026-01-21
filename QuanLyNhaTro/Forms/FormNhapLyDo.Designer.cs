namespace QuanLyNhaTro.Forms
{
    partial class FormNhapLyDo
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
            lblLyDo = new System.Windows.Forms.Label();
            txtLyDo = new System.Windows.Forms.TextBox();
            btnXacNhan = new System.Windows.Forms.Button();
            btnHuy = new System.Windows.Forms.Button();
            lblGhiChu = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            lblTitle.Location = new System.Drawing.Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(484, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "NHẬP LÝ DO TỪ CHỐI";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLyDo
            // 
            lblLyDo.AutoSize = true;
            lblLyDo.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular);
            lblLyDo.Location = new System.Drawing.Point(20, 70);
            lblLyDo.Name = "lblLyDo";
            lblLyDo.Size = new System.Drawing.Size(54, 19);
            lblLyDo.TabIndex = 1;
            lblLyDo.Text = "Lý do:";
            // 
            // txtLyDo
            // 
            txtLyDo.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular);
            txtLyDo.Location = new System.Drawing.Point(20, 100);
            txtLyDo.Multiline = true;
            txtLyDo.Name = "txtLyDo";
            txtLyDo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtLyDo.Size = new System.Drawing.Size(444, 120);
            txtLyDo.TabIndex = 2;
            txtLyDo.KeyDown += txtLyDo_KeyDown;
            // 
            // btnXacNhan
            // 
            btnXacNhan.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnXacNhan.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            btnXacNhan.ForeColor = System.Drawing.Color.White;
            btnXacNhan.Location = new System.Drawing.Point(250, 280);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new System.Drawing.Size(100, 35);
            btnXacNhan.TabIndex = 3;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.UseVisualStyleBackColor = false;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnHuy.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            btnHuy.ForeColor = System.Drawing.Color.White;
            btnHuy.Location = new System.Drawing.Point(364, 280);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new System.Drawing.Size(100, 35);
            btnHuy.TabIndex = 4;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // lblGhiChu
            // 
            lblGhiChu.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Italic);
            lblGhiChu.ForeColor = System.Drawing.Color.Gray;
            lblGhiChu.Location = new System.Drawing.Point(20, 230);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new System.Drawing.Size(444, 40);
            lblGhiChu.TabIndex = 5;
            lblGhiChu.Text = "* Lý do phải có ít nhất 10 ký tự\r\n* Nhấn Ctrl+Enter để xác nhận, Esc để hủy";
            // 
            // FormNhapLyDo
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            ClientSize = new System.Drawing.Size(484, 331);
            Controls.Add(lblGhiChu);
            Controls.Add(btnHuy);
            Controls.Add(btnXacNhan);
            Controls.Add(txtLyDo);
            Controls.Add(lblLyDo);
            Controls.Add(lblTitle);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormNhapLyDo";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Nhập lý do";
            Load += FormNhapLyDo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLyDo;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label lblGhiChu;
    }
}


