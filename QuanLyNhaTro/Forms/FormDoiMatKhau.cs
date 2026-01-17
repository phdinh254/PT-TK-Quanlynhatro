using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QuanLyNhaTro.Data;
using QuanLyNhaTro.Helpers;

namespace QuanLyNhaTro.Forms
{
    public partial class FormDoiMatKhau : Form
    {
        private string tenDangNhap;

        public FormDoiMatKhau(string username)
        {
            InitializeComponent();
            this.tenDangNhap = username;
            InitializeUI();
        }

        private void InitializeUI()
        {
            UIHelper.StandardizeForm(this);
            UIHelper.StylePrimaryButton(btnDoiMatKhau);
            UIHelper.StyleSecondaryButton(btnHuy);

            txtMatKhauCu.PasswordChar = '?';
            txtMatKhauMoi.PasswordChar = '?';
            txtXacNhanMatKhau.PasswordChar = '?';
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(txtMatKhauCu.Text))
                {
                    UIHelper.ShowWarningMessage("Vui lòng nh?p m?t kh?u c?!");
                    txtMatKhauCu.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMatKhauMoi.Text))
                {
                    UIHelper.ShowWarningMessage("Vui lòng nh?p m?t kh?u m?i!");
                    txtMatKhauMoi.Focus();
                    return;
                }

                if (txtMatKhauMoi.Text != txtXacNhanMatKhau.Text)
                {
                    UIHelper.ShowWarningMessage("M?t kh?u xác nh?n không kh?p!");
                    txtXacNhanMatKhau.Focus();
                    return;
                }

                // Validate password strength
                if (!PasswordHelper.IsPasswordStrong(txtMatKhauMoi.Text, out string message))
                {
                    UIHelper.ShowWarningMessage(message);
                    txtMatKhauMoi.Focus();
                    return;
                }

                // L?y thông tin m?t kh?u hi?n t?i
                string query = "SELECT MatKhau, Salt FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
                SqlParameter[] parameters = { new SqlParameter("@TenDangNhap", tenDangNhap) };
                var dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count == 0)
                {
                    UIHelper.ShowErrorMessage("Không tìm th?y tài kho?n!");
                    return;
                }

                string storedPassword = dt.Rows[0]["MatKhau"].ToString();
                string salt = dt.Rows[0]["Salt"]?.ToString();

                // Ki?m tra m?t kh?u c?
                bool isOldPasswordValid = false;
                if (!string.IsNullOrEmpty(salt))
                {
                    // Password ?ã ???c hash
                    isOldPasswordValid = PasswordHelper.VerifyPassword(txtMatKhauCu.Text, storedPassword, salt);
                }
                else
                {
                    // Password c? ch?a hash
                    isOldPasswordValid = (txtMatKhauCu.Text == storedPassword);
                }

                if (!isOldPasswordValid)
                {
                    UIHelper.ShowErrorMessage("M?t kh?u c? không ?úng!");
                    txtMatKhauCu.Focus();
                    return;
                }

                // Hash m?t kh?u m?i
                string newHashedPassword = PasswordHelper.HashPassword(txtMatKhauMoi.Text, out string newSalt);

                // C?p nh?t m?t kh?u
                string updateQuery = "UPDATE TaiKhoan SET MatKhau = @MatKhau, Salt = @Salt WHERE TenDangNhap = @TenDangNhap";
                SqlParameter[] updateParams = {
                    new SqlParameter("@MatKhau", newHashedPassword),
                    new SqlParameter("@Salt", newSalt),
                    new SqlParameter("@TenDangNhap", tenDangNhap)
                };

                DatabaseHelper.ExecuteNonQuery(updateQuery, updateParams);

                UIHelper.ShowSuccessMessage("??i m?t kh?u thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("L?i khi ??i m?t kh?u: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
