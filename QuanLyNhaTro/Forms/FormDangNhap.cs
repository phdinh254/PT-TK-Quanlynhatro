using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using QuanLyNhaTro.Data;
using QuanLyNhaTro.Helpers;

namespace QuanLyNhaTro.Forms
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
            InitializeUI();
            InitializeDatabase();
        }

        private void InitializeUI()
        {
            // Chuẩn hóa toàn bộ giao diện
            UIHelper.StandardizeForm(this);

            // Style riêng cho các nút
            UIHelper.StylePrimaryButton(btnDangNhap);
            UIHelper.StyleDangerButton(btnThoat);

            // Set default values for testing
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
        }

        private void InitializeDatabase()
        {
            try
            {
                // Kiểm tra kết nối
                if (!DatabaseHelper.TestConnection())
                {
                    // Thử tạo database nếu chưa tồn tại
                    try
                    {
                        DatabaseHelper.CreateDatabase();
                    }
                    catch (Exception createEx)
                    {
                        lblStatus.Text = "Không thể tạo database: " + createEx.Message;
                        lblStatus.ForeColor = UIHelper.Colors.Danger;
                        return;
                    }
                }

                // Khởi tạo các bảng
                DatabaseHelper.InitializeTables();

                lblStatus.Text = "Kết nối cơ sở dữ liệu thành công";
                lblStatus.ForeColor = UIHelper.Colors.Secondary;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Lỗi kết nối: " + ex.Message;
                lblStatus.ForeColor = UIHelper.Colors.Danger;

                // Hiển thị thông báo chi tiết
                string errorMessage = "Lỗi khởi tạo cơ sở dữ liệu:\n" + ex.Message +
                                    "\n\nVui lòng kiểm tra:\n" +
                                    "1. SQL Server đã được khởi động\n" +
                                    "2. Instance MSI\\MSSQLSERVER03 đang chạy\n" +
                                    "3. Quyền truy cập database\n" +
                                    "4. Connection string trong App.config";

                UIHelper.ShowErrorMessage(errorMessage, "Lỗi kết nối Database");
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Removed invalid KeyCode check, as EventArgs does not have KeyCode.
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                UIHelper.ShowWarningMessage("Vui lòng nhập đầy đủ thông tin đăng nhập!");
                return;
            }

            try
            {
                string query = "SELECT HoTen, VaiTro FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau AND TrangThai = 1";
                SqlParameter[] parameters = {
                    new SqlParameter("@TenDangNhap", tenDangNhap),
                    new SqlParameter("@MatKhau", matKhau)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    // Lưu thông tin người dùng hiện tại
                    CurrentUser.TenDangNhap = tenDangNhap;
                    CurrentUser.HoTen = dt.Rows[0]["HoTen"].ToString();
                    CurrentUser.VaiTro = dt.Rows[0]["VaiTro"].ToString();

                    // Tất cả vai trò đều mở FormMain, phân quyền sẽ xử lý trong FormMain
                    FormMain formMain = new FormMain();
                    formMain.Show();
                    this.Hide();
                }
                else
                {
                    UIHelper.ShowErrorMessage("Tên đăng nhập hoặc mật khẩu không đúng!");
                }
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }

    // Class để lưu thông tin người dùng hiện tại
    public static class CurrentUser
    {
        public static string TenDangNhap { get; set; }
        public static string HoTen { get; set; }
        public static string VaiTro { get; set; }
    }
}