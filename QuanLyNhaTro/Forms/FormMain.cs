using System;
using System.Windows.Forms;
using QuanLyNhaTro.Data;
using QuanLyNhaTro.Helpers;

namespace QuanLyNhaTro.Forms
{
    public partial class FormMain : Form
    {
        private Form activeForm = null;

        public FormMain()
        {
            InitializeComponent();
            InitializeUI();
            ApplyRoleBasedAccess();
            LoadDashboardData();
        }

        private void InitializeUI()
        {
            // Chuẩn hóa toàn bộ giao diện
            UIHelper.StandardizeForm(this);
        }

        private void ApplyRoleBasedAccess()
        {
            string role = CurrentUser.VaiTro?.ToLower() ?? "";

            if (role == "admin")
            {
                // Admin có quyền truy cập tất cả
                mnuKhachHang.Enabled = true;
                mnuPhong.Enabled = true;
                mnuHopDong.Enabled = true;
                mnuHoaDon.Enabled = true;
                mnuTaiKhoan.Enabled = true;
            }
            else
            {
                // User chỉ được xem Phòng, Hợp đồng, Hóa đơn (không sửa)
                mnuKhachHang.Enabled = false;
                mnuPhong.Enabled = true;
                mnuHopDong.Enabled = true;
                mnuHoaDon.Enabled = true;
                mnuTaiKhoan.Enabled = false;
            }
        }

        public static bool IsAdmin()
        {
            return CurrentUser.VaiTro?.ToLower() == "admin";
        }


        private void LoadDashboardData()
        {
            try
            {
                string queryKhachHang = "SELECT COUNT(*) FROM KhachHang";
                string queryPhong = "SELECT COUNT(*) FROM Phong";
                string queryHopDong = "SELECT COUNT(*) FROM HopDong WHERE TrangThai = N'Đang hiệu lực'";
                string queryHoaDon = "SELECT COUNT(*) FROM HoaDon WHERE TrangThai = N'Chưa thanh toán'";

                lblStatKhachHangValue.Text = DatabaseHelper.ExecuteScalar(queryKhachHang)?.ToString() ?? "0";
                lblStatPhongValue.Text = DatabaseHelper.ExecuteScalar(queryPhong)?.ToString() ?? "0";
                lblStatHopDongValue.Text = DatabaseHelper.ExecuteScalar(queryHopDong)?.ToString() ?? "0";
                lblStatHoaDonValue.Text = DatabaseHelper.ExecuteScalar(queryHoaDon)?.ToString() ?? "0";
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        private void ShowDashboard()
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(pnlDashboard);
            pnlDashboard.Visible = true;
            pnlDashboard.Dock = DockStyle.Fill;
            LoadDashboardData();
        }

        // Menu Events
        private void mnuTongQuan_Click(object sender, EventArgs e)
        {
            ShowDashboard();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormKhachHang());
        }

        private void mnuPhong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormPhong());
        }

        private void mnuHopDong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormHopDong());
        }

        private void mnuHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormHoaDon());
        }

        private void mnuTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormTaiKhoan());
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            if (UIHelper.ShowConfirmMessage("Bạn có chắc chắn muốn đăng xuất?"))
            {
                this.Hide();
                FormDangNhap formDangNhap = new FormDangNhap();
                formDangNhap.Show();
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            if (UIHelper.ShowConfirmMessage("Bạn có chắc chắn muốn thoát?"))
            {
                Application.Exit();
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            // Tự động điều chỉnh kích thước các card thống kê theo kích thước form
            if (flowStats != null && this.ClientSize.Width > 0)
            {
                int availableWidth = pnlContent.ClientSize.Width - 50;
                int cardCount = 4;
                int spacing = 20;
                int cardWidth = (availableWidth - (spacing * (cardCount - 1))) / cardCount;
                
                if (cardWidth < 200) cardWidth = 200;
                if (cardWidth > 300) cardWidth = 300;

                foreach (Control ctrl in flowStats.Controls)
                {
                    if (ctrl is Panel panel)
                    {
                        panel.Width = cardWidth;
                    }
                }
            }
        }
    }
}
