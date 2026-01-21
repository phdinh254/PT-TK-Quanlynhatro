using System;
using System.Windows.Forms;
using QuanLyNhaTro.Helpers;

namespace QuanLyNhaTro.Forms
{
    public partial class FormNhapLyDo : Form
    {
        public string LyDo { get; private set; }

        public FormNhapLyDo(string title = "Nhập lý do")
        {
            InitializeComponent();
            this.Text = title;
            lblTitle.Text = title;
            InitializeUI();
        }

        private void InitializeUI()
        {
            UIHelper.StandardizeForm(this);
            UIHelper.StylePrimaryButton(btnXacNhan);
            UIHelper.StyleSecondaryButton(btnHuy);
            
            // Focus vào textbox
            txtLyDo.Focus();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string lyDo = txtLyDo.Text.Trim();
            
            if (string.IsNullOrEmpty(lyDo))
            {
                UIHelper.ShowWarningMessage("Vui lòng nhập lý do!");
                txtLyDo.Focus();
                return;
            }

            if (lyDo.Length < 10)
            {
                UIHelper.ShowWarningMessage("Lý do phải có ít nhất 10 ký tự!");
                txtLyDo.Focus();
                return;
            }

            LyDo = lyDo;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtLyDo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                btnXacNhan_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnHuy_Click(sender, e);
            }
        }

        private void FormNhapLyDo_Load(object sender, EventArgs e)
        {
            // Đặt một số lý do mẫu
            string[] lyDoMau = {
                "Phòng đã được đặt bởi khách khác",
                "Phòng đang trong quá trình bảo trì",
                "Khách hàng không đáp ứng yêu cầu",
                "Thông tin khách hàng không chính xác",
                "Phòng không còn phù hợp với yêu cầu"
            };

            // Thêm tooltip với gợi ý
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(txtLyDo, "Một số lý do thường gặp:\n" + string.Join("\n", lyDoMau));
        }
    }
}