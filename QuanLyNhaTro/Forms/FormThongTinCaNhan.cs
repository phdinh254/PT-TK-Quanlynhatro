using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QuanLyNhaTro.Data;
using QuanLyNhaTro.Helpers;
using System.Drawing;

namespace QuanLyNhaTro.Forms
{
    public partial class FormThongTinCaNhan : Form
    {
        private string tenDangNhap;

        public FormThongTinCaNhan(string username)
        {
            InitializeComponent();
            this.tenDangNhap = username;
            InitializeUI();
            LoadUserInfo();
        }

        private void InitializeUI()
        {
            UIHelper.StandardizeForm(this);
            UIHelper.StylePrimaryButton(btnCapNhat);
            UIHelper.StyleSecondaryButton(btnDong);

            // Căn giữa panelMain
            CenterPanel();
            
            // Khóa tên đăng nhập
            txtTenDangNhap.ReadOnly = true;
            txtTenDangNhap.BackColor = Color.LightGray;
        }

        private void CenterPanel()
        {
            // Căn giữa panelMain theo chiều ngang
            var panelMain = this.Controls.Find("panelMain", true);
            if (panelMain.Length > 0)
            {
                var panel = panelMain[0];
                panel.Left = (this.ClientSize.Width - panel.Width) / 2;
                
                // Căn giữa các controls bên trong panel
                CenterControlsInPanel(panel);
            }
        }
        
        private void CenterControlsInPanel(Control panel)
        {
            // Tìm width lớn nhất của các label và textbox
            int maxLabelWidth = 0;
            int maxControlWidth = 0;
            int leftMargin = 30; // Margin trái tối thiểu
            
            // Tìm tất cả label và textbox
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is Label lbl && !lbl.Name.Contains("Title"))
                {
                    if (lbl.Width > maxLabelWidth)
                        maxLabelWidth = lbl.Width;
                }
                else if (ctrl is TextBox || ctrl is ComboBox || ctrl is DateTimePicker)
                {
                    if (ctrl.Width > maxControlWidth)
                        maxControlWidth = ctrl.Width;
                }
            }
            
            // Tính vị trí căn giữa
            int totalWidth = maxLabelWidth + maxControlWidth + 30; // 30 = khoảng cách giữa label và control
            int startX = (panel.Width - totalWidth) / 2;
            
            if (startX < leftMargin)
                startX = leftMargin;
            
            // Căn giữa các controls
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is Label lbl && !lbl.Name.Contains("Title"))
                {
                    lbl.Left = startX;
                }
                else if (ctrl is TextBox || ctrl is ComboBox || ctrl is DateTimePicker)
                {
                    ctrl.Left = startX + maxLabelWidth + 20;
                }
            }
        }

        private void LoadUserInfo()
        {
            try
            {
                string query = @"
                    SELECT tk.TenDangNhap, tk.HoTen, tk.Email, 
                           kh.SoDienThoai, kh.CMND, kh.DiaChi, kh.NgaySinh, kh.GioiTinh
                    FROM TaiKhoan tk
                    LEFT JOIN KhachHang kh ON tk.HoTen = kh.TenKhach
                    WHERE tk.TenDangNhap = @TenDangNhap";

                SqlParameter[] parameters = { new SqlParameter("@TenDangNhap", tenDangNhap) };
                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtTenDangNhap.Text = row["TenDangNhap"].ToString();
                    txtHoTen.Text = row["HoTen"].ToString();
                    txtEmail.Text = row["Email"].ToString();
                    txtSoDienThoai.Text = row["SoDienThoai"]?.ToString() ?? "";
                    txtCMND.Text = row["CMND"]?.ToString() ?? "";
                    txtDiaChi.Text = row["DiaChi"]?.ToString() ?? "";

                    if (row["NgaySinh"] != DBNull.Value)
                    {
                        dtpNgaySinh.Value = Convert.ToDateTime(row["NgaySinh"]);
                    }

                    string gioiTinh = row["GioiTinh"]?.ToString();
                    if (!string.IsNullOrEmpty(gioiTinh))
                    {
                        cmbGioiTinh.SelectedItem = gioiTinh;
                    }
                }
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("Lỗi khi tải thông tin: " + ex.Message);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                // Cập nhật thông tin tài khoản
                string updateTaiKhoanQuery = @"
                    UPDATE TaiKhoan 
                    SET HoTen = @HoTen, Email = @Email
                    WHERE TenDangNhap = @TenDangNhap";

                SqlParameter[] tkParams = {
                    new SqlParameter("@HoTen", txtHoTen.Text.Trim()),
                    new SqlParameter("@Email", txtEmail.Text.Trim()),
                    new SqlParameter("@TenDangNhap", tenDangNhap)
                };

                DatabaseHelper.ExecuteNonQuery(updateTaiKhoanQuery, tkParams);

                // Kiểm tra xem đã có bản ghi khách hàng chưa
                string checkKhachHangQuery = @"
                    SELECT kh.MaKhach 
                    FROM KhachHang kh
                    INNER JOIN TaiKhoan tk ON kh.TenKhach = tk.HoTen
                    WHERE tk.TenDangNhap = @TenDangNhap";
                SqlParameter[] checkParams = { new SqlParameter("@TenDangNhap", tenDangNhap) };
                object maKhach = DatabaseHelper.ExecuteScalar(checkKhachHangQuery, checkParams);

                if (maKhach != null)
                {
                    // Cập nhật khách hàng
                    string updateKhachHangQuery = @"
                        UPDATE KhachHang 
                        SET SoDienThoai = @SoDienThoai, 
                            CMND = @CMND, 
                            DiaChi = @DiaChi, 
                            NgaySinh = @NgaySinh, 
                            GioiTinh = @GioiTinh
                        WHERE MaKhach = @MaKhach";

                    SqlParameter[] khParams = {
                        new SqlParameter("@SoDienThoai", txtSoDienThoai.Text.Trim()),
                        new SqlParameter("@CMND", txtCMND.Text.Trim()),
                        new SqlParameter("@DiaChi", txtDiaChi.Text.Trim()),
                        new SqlParameter("@NgaySinh", dtpNgaySinh.Value),
                        new SqlParameter("@GioiTinh", cmbGioiTinh.Text),
                        new SqlParameter("@MaKhach", maKhach.ToString())
                    };

                    DatabaseHelper.ExecuteNonQuery(updateKhachHangQuery, khParams);
                }
                else
                {
                    // Tạo mới khách hàng
                    string maKhachMoi = "KH" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    string insertKhachHangQuery = @"
                        INSERT INTO KhachHang (MaKhach, TenKhach, SoDienThoai, CMND, DiaChi, NgaySinh, GioiTinh, GhiChu)
                        VALUES (@MaKhach, @TenKhach, @SoDienThoai, @CMND, @DiaChi, @NgaySinh, @GioiTinh, @GhiChu)";

                    SqlParameter[] insertParams = {
                        new SqlParameter("@MaKhach", maKhachMoi),
                        new SqlParameter("@TenKhach", txtHoTen.Text.Trim()),
                        new SqlParameter("@SoDienThoai", txtSoDienThoai.Text.Trim()),
                        new SqlParameter("@CMND", txtCMND.Text.Trim()),
                        new SqlParameter("@DiaChi", txtDiaChi.Text.Trim()),
                        new SqlParameter("@NgaySinh", dtpNgaySinh.Value),
                        new SqlParameter("@GioiTinh", cmbGioiTinh.Text),
                        new SqlParameter("@GhiChu", "Tài khoản: " + tenDangNhap)
                    };

                    DatabaseHelper.ExecuteNonQuery(insertKhachHangQuery, insertParams);
                }

                UIHelper.ShowSuccessMessage("Cập nhật thông tin thành công!");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                UIHelper.ShowWarningMessage("Vui lòng nhập họ tên!");
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                UIHelper.ShowWarningMessage("Vui lòng nhập email!");
                txtEmail.Focus();
                return false;
            }

            if (!PasswordHelper.IsValidEmail(txtEmail.Text))
            {
                UIHelper.ShowWarningMessage("Email không hợp lệ!");
                txtEmail.Focus();
                return false;
            }

            // Kiểm tra các trường bắt buộc để tạo khách hàng
            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                UIHelper.ShowWarningMessage("Vui lòng nhập số điện thoại!");
                txtSoDienThoai.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCMND.Text))
            {
                UIHelper.ShowWarningMessage("Vui lòng nhập CMND/CCCD!");
                txtCMND.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                UIHelper.ShowWarningMessage("Vui lòng nhập địa chỉ!");
                txtDiaChi.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbGioiTinh.Text))
            {
                UIHelper.ShowWarningMessage("Vui lòng chọn giới tính!");
                cmbGioiTinh.Focus();
                return false;
            }

            // Kiểm tra tuổi >= 18
            int age = DateTime.Now.Year - dtpNgaySinh.Value.Year;
            if (dtpNgaySinh.Value.Date > DateTime.Now.AddYears(-age)) age--;
            if (age < 18)
            {
                UIHelper.ShowWarningMessage("Bạn phải đủ 18 tuổi!");
                return false;
            }

            return true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
