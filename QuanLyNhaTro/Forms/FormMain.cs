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
            CreateAccountMenu();
        }

        private void InitializeUI()
        {
            // Chuẩn hóa toàn bộ giao diện
            UIHelper.StandardizeForm(this);
        }

        private void CreateAccountMenu()
        {
            // Tạo MenuStrip nếu chưa có
            MenuStrip menuStrip = this.MainMenuStrip;
            if (menuStrip == null)
            {
                menuStrip = new MenuStrip();
                menuStrip.Dock = DockStyle.Top;
                this.Controls.Add(menuStrip);
                this.MainMenuStrip = menuStrip;
            }

            // Tạo menu tài khoản ở bên phải
            ToolStripMenuItem mnuTaiKhoan = new ToolStripMenuItem();
            mnuTaiKhoan.Text = $"👤 {CurrentUser.HoTen}";
            mnuTaiKhoan.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            mnuTaiKhoan.Alignment = ToolStripItemAlignment.Right;

            if (IsAdmin())
            {
                // Menu cho Admin
                ToolStripMenuItem mnuDangXuat = new ToolStripMenuItem("Đăng xuất");
                mnuDangXuat.Click += MnuDangXuat_Click;

                ToolStripMenuItem mnuThoat = new ToolStripMenuItem("Thoát");
                mnuThoat.Click += MnuThoat_Click;

                mnuTaiKhoan.DropDownItems.Add(mnuDangXuat);
                mnuTaiKhoan.DropDownItems.Add(mnuThoat);
            }
            else
            {
                // Menu cho User
                ToolStripMenuItem mnuThongTinCaNhan = new ToolStripMenuItem("Thông tin cá nhân");
                mnuThongTinCaNhan.Click += MnuThongTinCaNhan_Click;

                ToolStripMenuItem mnuDoiMatKhau = new ToolStripMenuItem("Đổi mật khẩu");
                mnuDoiMatKhau.Click += MnuDoiMatKhau_Click;

                ToolStripMenuItem mnuDangXuat = new ToolStripMenuItem("Đăng xuất");
                mnuDangXuat.Click += MnuDangXuat_Click;

                ToolStripMenuItem mnuThoat = new ToolStripMenuItem("Thoát");
                mnuThoat.Click += MnuThoat_Click;

                mnuTaiKhoan.DropDownItems.Add(mnuThongTinCaNhan);
                mnuTaiKhoan.DropDownItems.Add(mnuDoiMatKhau);
                mnuTaiKhoan.DropDownItems.Add(new ToolStripSeparator());
                mnuTaiKhoan.DropDownItems.Add(mnuDangXuat);
                mnuTaiKhoan.DropDownItems.Add(mnuThoat);
            }

            menuStrip.Items.Add(mnuTaiKhoan);
        }

        private void MnuThongTinCaNhan_Click(object sender, EventArgs e)
        {
            FormThongTinCaNhan form = new FormThongTinCaNhan(CurrentUser.TenDangNhap);
            form.ShowDialog(this);
        }

        private void MnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau form = new FormDoiMatKhau(CurrentUser.TenDangNhap);
            form.ShowDialog(this);
        }

        private void MnuDangXuat_Click(object sender, EventArgs e)
        {
            if (UIHelper.ShowConfirmMessage("Bạn có chắc chắn muốn đăng xuất?"))
            {
                // Xóa thông tin người dùng hiện tại
                CurrentUser.TenDangNhap = null;
                CurrentUser.HoTen = null;
                CurrentUser.VaiTro = null;

                // Đóng FormMain
                this.Hide();

                // Mở lại FormDangNhap
                FormDangNhap formDangNhap = new FormDangNhap();
                formDangNhap.Show();

                // Đóng form hiện tại khi form đăng nhập đóng
                formDangNhap.FormClosed += (s, args) => this.Close();
            }
        }

        private void MnuThoat_Click(object sender, EventArgs e)
        {
            if (UIHelper.ShowConfirmMessage("Bạn có chắc chắn muốn thoát ứng dụng?"))
            {
                Application.Exit();
            }
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
                
                // Admin thêm menu Quản lý đơn đặt phòng
                if (this.MainMenuStrip != null && !MenuHasItem(this.MainMenuStrip, "mnuDonDatPhong"))
                {
                    ToolStripMenuItem mnuDonDatPhong = new ToolStripMenuItem();
                    mnuDonDatPhong.Name = "mnuDonDatPhong";
                    mnuDonDatPhong.Text = "Đơn đặt phòng";
                    mnuDonDatPhong.Font = new System.Drawing.Font("Times New Roman", 10F);
                    mnuDonDatPhong.ForeColor = System.Drawing.Color.White;
                    mnuDonDatPhong.Click += MnuDonDatPhong_Click;
                    this.MainMenuStrip.Items.Insert(this.MainMenuStrip.Items.Count - 1, mnuDonDatPhong);
                }
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
            
            // Đổi màu chữ menu thành trắng
            SetMenuForeColor(System.Drawing.Color.White);
        }
        
        private bool MenuHasItem(MenuStrip menu, string itemName)
        {
            foreach (ToolStripItem item in menu.Items)
            {
                if (item.Name == itemName)
                    return true;
            }
            return false;
        }

        private void SetMenuForeColor(System.Drawing.Color color)
        {
            if (this.MainMenuStrip == null) return;
            
            foreach (ToolStripItem item in this.MainMenuStrip.Items)
            {
                item.ForeColor = color;
                item.Font = new System.Drawing.Font("Times New Roman", 10F);
            }
        }

        private void MnuDonDatPhong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDonDatPhong());
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
