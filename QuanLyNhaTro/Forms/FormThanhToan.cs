using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QuanLyNhaTro.Helpers;

namespace QuanLyNhaTro.Forms
{
    public partial class FormThanhToan : Form
    {
        public FormThanhToan(string maHoaDon, decimal soTien)
        {
            InitializeComponent();
            UIHelper.StandardizeForm(this);

            lblMaHoaDonValue.Text = maHoaDon;
            lblSoTienValue.Text = soTien.ToString("N0") + " VND";

            // Nội dung chuyển khoản: kèm mã hóa đơn để dễ đối soát
            lblNoiDungValue.Text = $"Thanh toán trọ - {maHoaDon}";

            LoadQrImage();
        }

        public FormThanhToan()
        {
        }

        private void LoadQrImage()
        {
            string qrPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "qr.png");

            if (File.Exists(qrPath))
            {
                using (var fs = new FileStream(qrPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    picQr.Image = Image.FromStream(fs);
                }
            }
            else
            {
                lblQrStatus.Text = $"Không tìm thấy qr.png tại:\n{qrPath}";
                lblQrStatus.ForeColor = UIHelper.Colors.Danger;
            }
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();   
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}