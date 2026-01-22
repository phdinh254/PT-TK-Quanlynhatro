using System;
using System.Windows.Forms;
using QuanLyNhaTro.Data;
using QuanLyNhaTro.Helpers;
using System.Linq;

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
            
            // Handle resize để phân bố đều các panel stats
            this.Resize += FormMain_Resize;
            AdjustStatsLayout();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                AdjustStatsLayout();
            }
        }

        private void AdjustStatsLayout()
        {
            try
            {
                // Tìm flowStats panel
                var flowStats = pnlDashboard.Controls.Find("flowStats", false);
                if (flowStats.Length == 0) return;
                
                FlowLayoutPanel flow = flowStats[0] as FlowLayoutPanel;
                if (flow == null) return;
                
                // Đếm số panel stats
                int panelCount = 0;
                foreach (Control ctrl in flow.Controls)
                {
                    if (ctrl is Panel && ctrl.Name.StartsWith("pnlStat"))
                        panelCount++;
                }
                
                if (panelCount == 0) return;
                
                // Tính toán width cho mỗi panel
                int availableWidth = pnlDashboard.Width - 40; // Trừ margins
                int totalMargin = (panelCount - 1) * 19; // Margin giữa các panels
                int panelWidth = (availableWidth - totalMargin) / panelCount;
                
                // Đảm bảo width tối thiểu
                if (panelWidth < 200)
                    panelWidth = 275; // Width mặc định
                
                // Áp dụng width cho các panels
                foreach (Control ctrl in flow.Controls)
                {
                    if (ctrl is Panel && ctrl.Name.StartsWith("pnlStat"))
                    {
                        ctrl.Width = panelWidth;
                    }
                }
            }
            catch
            {
                // Ignore errors
            }
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
                // User chỉ được xem Phòng, Hợp đồng, Hóa đơn và Thanh toán theo tháng (không sửa)
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

        private void LoadStatsData()
        {
            try
            {
                // Lấy danh sách các card thống kê (panel có tên bắt đầu bằng "pnlStat")
                var statPanels = pnlDashboard.Controls.OfType<Panel>().Where(p => p.Name.StartsWith("pnlStat")).ToArray();

                // Nếu không có panel thống kê nào, thoát
                if (statPanels.Length == 0) return;

                // Tính toán số liệu thống kê cho từng panel
                foreach (var panel in statPanels)
                {
                    // Ví dụ: panel có tên "pnlStatKhachHang" sẽ lấy dữ liệu khách hàng
                    string statName = panel.Name.Substring(7); // Lấy phần tên sau "pnlStat"
                    string query = $"SELECT COUNT(*) FROM {statName}";

                    // Cập nhật giá trị cho nhãn trong panel thống kê
                    var lblValue = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "lblValue");
                    if (lblValue != null)
                    {
                        lblValue.Text = DatabaseHelper.ExecuteScalar(query)?.ToString() ?? "0";
                    }
                }
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("Lỗi khi tải dữ liệu thống kê: " + ex.Message);
            }
        }

        private void RefreshStatPanel(Panel statPanel, string query)
        {
            try
            {
                // Cập nhật dữ liệu cho panel thống kê
                var lblValue = statPanel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "lblValue");
                if (lblValue != null)
                {
                    lblValue.Text = DatabaseHelper.ExecuteScalar(query)?.ToString() ?? "0";
                }
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("Lỗi khi làm mới dữ liệu thống kê: " + ex.Message);
            }
        }
    }
}
