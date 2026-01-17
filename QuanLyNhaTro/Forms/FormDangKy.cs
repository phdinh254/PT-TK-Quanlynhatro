using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QuanLyNhaTro.Data;
using QuanLyNhaTro.Helpers;

namespace QuanLyNhaTro.Forms
{
    public partial class FormDangKy : Form
    {
        public FormDangKy()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            UIHelper.StandardizeForm(this);
            UIHelper.StylePrimaryButton(btnDangKy);
            UIHelper.StyleSecondaryButton(btnHuy);
            
            txtMatKhau.PasswordChar = '?';
            txtXacNhanMatKhau.PasswordChar = '?';
        }

        private bool ValidateInput()
        {
            // Ki?m tra tên ??ng nh?p
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                UIHelper.ShowWarningMessage("Vui lòng nh?p tên ??ng nh?p!");
                txtTenDangNhap.Focus();
                return false;
            }

            if (txtTenDangNhap.Text.Length < 3)
            {
                UIHelper.ShowWarningMessage("Tên ??ng nh?p ph?i có ít nh?t 3 ký t?!");
                txtTenDangNhap.Focus();
                return false;
            }

            // Ki?m tra h? tên
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                UIHelper.ShowWarningMessage("Vui lòng nh?p h? tên!");
                txtHoTen.Focus();
                return false;
            }

            // Ki?m tra email
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

            // Ki?m tra m?t kh?u
            if (!PasswordHelper.IsPasswordStrong(txtMatKhau.Text, out string message))
            {
                UIHelper.ShowWarningMessage(message);
                txtMatKhau.Focus();
                return false;
            }

            // Ki?m tra xác nh?n m?t kh?u
            if (txtMatKhau.Text != txtXacNhanMatKhau.Text)
            {
                UIHelper.ShowWarningMessage("M?t kh?u xác nh?n không kh?p!");
                txtXacNhanMatKhau.Focus();
                return false;
            }

            // Ki?m tra ?i?u kho?n
            if (!chkDongY.Checked)
            {
                UIHelper.ShowWarningMessage("Vui lòng ??ng ý v?i ?i?u kho?n s? d?ng!");
                return false;
            }

            return true;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                // Ki?m tra tên ??ng nh?p ?ã t?n t?i
                string checkQuery = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
                SqlParameter[] checkParams = { new SqlParameter("@TenDangNhap", txtTenDangNhap.Text.Trim()) };
                int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery, checkParams));

                if (count > 0)
                {
                    UIHelper.ShowWarningMessage("Tên ??ng nh?p ?ã t?n t?i!");
                    txtTenDangNhap.Focus();
                    return;
                }

                // Ki?m tra email ?ã t?n t?i
                string checkEmailQuery = "SELECT COUNT(*) FROM TaiKhoan WHERE Email = @Email";
                SqlParameter[] checkEmailParams = { new SqlParameter("@Email", txtEmail.Text.Trim()) };
                int emailCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkEmailQuery, checkEmailParams));

                if (emailCount > 0)
                {
                    UIHelper.ShowWarningMessage("Email ?ã ???c s? d?ng!");
                    txtEmail.Focus();
                    return;
                }

                // Hash m?t kh?u
                string hashedPassword = PasswordHelper.HashPassword(txtMatKhau.Text, out string salt);

                // T?o token xác th?c (trong th?c t? s? g?i qua email)
                string verificationToken = PasswordHelper.GenerateToken();

                // Thêm tài kho?n m?i
                string insertQuery = @"
                    INSERT INTO TaiKhoan (TenDangNhap, MatKhau, Salt, HoTen, Email, VaiTro, NgayTao, TrangThai, IsVerified, VerificationToken)
                    VALUES (@TenDangNhap, @MatKhau, @Salt, @HoTen, @Email, 'User', GETDATE(), 1, 1, @VerificationToken)";

                SqlParameter[] insertParams = {
                    new SqlParameter("@TenDangNhap", txtTenDangNhap.Text.Trim()),
                    new SqlParameter("@MatKhau", hashedPassword),
                    new SqlParameter("@Salt", salt),
                    new SqlParameter("@HoTen", txtHoTen.Text.Trim()),
                    new SqlParameter("@Email", txtEmail.Text.Trim()),
                    new SqlParameter("@VerificationToken", verificationToken)
                };

                DatabaseHelper.ExecuteNonQuery(insertQuery, insertParams);

                // T? ??ng t?o b?n ghi khách hàng
                string maKhach = "KH" + DateTime.Now.ToString("yyyyMMddHHmmss");
                string insertKhachHangQuery = @"
                    INSERT INTO KhachHang (MaKhach, TenKhach, SoDienThoai, CMND, DiaChi, NgaySinh, GioiTinh, GhiChu)
                    VALUES (@MaKhach, @TenKhach, '', '', '', NULL, '', N'Tài kho?n: ' + @TenDangNhap)";

                SqlParameter[] khachHangParams = {
                    new SqlParameter("@MaKhach", maKhach),
                    new SqlParameter("@TenKhach", txtHoTen.Text.Trim()),
                    new SqlParameter("@TenDangNhap", txtTenDangNhap.Text.Trim())
                };

                DatabaseHelper.ExecuteNonQuery(insertKhachHangQuery, khachHangParams);

                // Thông báo thành công (trong th?c t? s? yêu c?u xác th?c email)
                UIHelper.ShowSuccessMessage("??ng ký thành công! B?n có th? ??ng nh?p ngay.");
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("L?i khi ??ng ký: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void linkDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
