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

            // Khóa tên ??ng nh?p
            txtTenDangNhap.ReadOnly = true;
            txtTenDangNhap.BackColor = Color.LightGray;
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
                UIHelper.ShowErrorMessage("L?i khi t?i thông tin: " + ex.Message);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                // C?p nh?t thông tin tài kho?n
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

                // Ki?m tra xem ?ã có b?n ghi khách hàng ch?a
                string checkKhachHangQuery = @"
                    SELECT kh.MaKhach 
                    FROM KhachHang kh
                    INNER JOIN TaiKhoan tk ON kh.TenKhach = tk.HoTen
                    WHERE tk.TenDangNhap = @TenDangNhap";
                SqlParameter[] checkParams = { new SqlParameter("@TenDangNhap", tenDangNhap) };
                object maKhach = DatabaseHelper.ExecuteScalar(checkKhachHangQuery, checkParams);

                if (maKhach != null)
                {
                    // C?p nh?t khách hàng
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
                    // T?o m?i khách hàng
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
                        new SqlParameter("@GhiChu", "Tài kho?n: " + tenDangNhap)
                    };

                    DatabaseHelper.ExecuteNonQuery(insertKhachHangQuery, insertParams);
                }

                UIHelper.ShowSuccessMessage("C?p nh?t thông tin thành công!");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("L?i khi c?p nh?t: " + ex.Message);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                UIHelper.ShowWarningMessage("Vui lòng nh?p h? tên!");
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                UIHelper.ShowWarningMessage("Vui lòng nh?p email!");
                txtEmail.Focus();
                return false;
            }

            if (!PasswordHelper.IsValidEmail(txtEmail.Text))
            {
                UIHelper.ShowWarningMessage("Email không h?p l?!");
                txtEmail.Focus();
                return false;
            }

            // Ki?m tra các tr??ng b?t bu?c ?? t?o khách hàng
            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                UIHelper.ShowWarningMessage("Vui lòng nh?p s? ?i?n tho?i!");
                txtSoDienThoai.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCMND.Text))
            {
                UIHelper.ShowWarningMessage("Vui lòng nh?p CMND/CCCD!");
                txtCMND.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                UIHelper.ShowWarningMessage("Vui lòng nh?p ??a ch?!");
                txtDiaChi.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbGioiTinh.Text))
            {
                UIHelper.ShowWarningMessage("Vui lòng ch?n gi?i tính!");
                cmbGioiTinh.Focus();
                return false;
            }

            // Ki?m tra tu?i >= 18
            int age = DateTime.Now.Year - dtpNgaySinh.Value.Year;
            if (dtpNgaySinh.Value.Date > DateTime.Now.AddYears(-age)) age--;
            if (age < 18)
            {
                UIHelper.ShowWarningMessage("B?n ph?i ?? 18 tu?i!");
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
