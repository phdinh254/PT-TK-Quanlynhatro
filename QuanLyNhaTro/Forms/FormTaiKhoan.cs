using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using QuanLyNhaTro.Data;
using QuanLyNhaTro.Helpers;

namespace QuanLyNhaTro.Forms
{
    public partial class FormTaiKhoan : Form
    {
        public FormTaiKhoan()
        {
            InitializeComponent();
            InitializeUI();
            LoadData();
        }

        private void InitializeUI()
        {
            // Chuẩn hóa toàn bộ giao diện
            UIHelper.StandardizeForm(this);
            
            // Style riêng cho các nút
            UIHelper.StylePrimaryButton(btnThem);
            UIHelper.StyleSecondaryButton(btnSua);
            UIHelper.StyleDangerButton(btnXoa);
            UIHelper.StyleButton(btnLamMoi, UIHelper.Colors.TextSecondary, UIHelper.Colors.White);
            UIHelper.StyleButton(btnTimKiem, UIHelper.Colors.Primary, UIHelper.Colors.White);
        }

        private void LoadData()
        {
            try
            {
                string query = "SELECT * FROM TaiKhoan ORDER BY TenDangNhap";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgvTaiKhoan.DataSource = dt;
                
                // Đặt tên cột hiển thị
                if (dgvTaiKhoan.Columns.Count > 0)
                {
                    dgvTaiKhoan.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
                    dgvTaiKhoan.Columns["MatKhau"].HeaderText = "Mật khẩu";
                    dgvTaiKhoan.Columns["HoTen"].HeaderText = "Họ tên";
                    dgvTaiKhoan.Columns["Email"].HeaderText = "Email";
                    dgvTaiKhoan.Columns["VaiTro"].HeaderText = "Vai trò";
                    dgvTaiKhoan.Columns["NgayTao"].HeaderText = "Ngày tạo";
                    dgvTaiKhoan.Columns["TrangThai"].HeaderText = "Trạng thái";
                    
                    // Ẩn cột mật khẩu
                    dgvTaiKhoan.Columns["MatKhau"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void ClearInputs()
        {
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtHoTen.Clear();
            txtEmail.Clear();
            cmbVaiTro.SelectedIndex = -1;
            chkTrangThai.Checked = true;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                UIHelper.ShowWarningMessage("Vui lòng nhập tên đăng nhập!");
                txtTenDangNhap.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                UIHelper.ShowWarningMessage("Vui lòng nhập mật khẩu!");
                txtMatKhau.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                UIHelper.ShowWarningMessage("Vui lòng nhập họ tên!");
                txtHoTen.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                // Kiểm tra tên đăng nhập đã tồn tại chưa
                string checkQuery = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
                SqlParameter[] checkParams = { new SqlParameter("@TenDangNhap", txtTenDangNhap.Text) };
                int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery, checkParams));
                
                if (count > 0)
                {
                    UIHelper.ShowWarningMessage("Tên đăng nhập đã tồn tại!");
                    txtTenDangNhap.Focus();
                    return;
                }

                string query = @"INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, Email, VaiTro, NgayTao, TrangThai) 
                                VALUES (@TenDangNhap, @MatKhau, @HoTen, @Email, @VaiTro, @NgayTao, @TrangThai)";

                SqlParameter[] parameters = {
                    new SqlParameter("@TenDangNhap", txtTenDangNhap.Text),
                    new SqlParameter("@MatKhau", txtMatKhau.Text),
                    new SqlParameter("@HoTen", txtHoTen.Text),
                    new SqlParameter("@Email", txtEmail.Text),
                    new SqlParameter("@VaiTro", cmbVaiTro.Text),
                    new SqlParameter("@NgayTao", DateTime.Now),
                    new SqlParameter("@TrangThai", chkTrangThai.Checked)
                };

                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    UIHelper.ShowSuccessMessage("Thêm tài khoản thành công!");
                    LoadData();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("Lỗi khi thêm tài khoản: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTenDangNhap.Text))
                {
                    UIHelper.ShowWarningMessage("Vui lòng chọn tài khoản cần sửa!");
                    return;
                }

                if (!ValidateInput())
                    return;

                string query = @"UPDATE TaiKhoan SET MatKhau = @MatKhau, HoTen = @HoTen, Email = @Email, 
                                VaiTro = @VaiTro, TrangThai = @TrangThai WHERE TenDangNhap = @TenDangNhap";

                SqlParameter[] parameters = {
                    new SqlParameter("@TenDangNhap", txtTenDangNhap.Text),
                    new SqlParameter("@MatKhau", txtMatKhau.Text),
                    new SqlParameter("@HoTen", txtHoTen.Text),
                    new SqlParameter("@Email", txtEmail.Text),
                    new SqlParameter("@VaiTro", cmbVaiTro.Text),
                    new SqlParameter("@TrangThai", chkTrangThai.Checked)
                };

                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    UIHelper.ShowSuccessMessage("Cập nhật tài khoản thành công!");
                    LoadData();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("Lỗi khi cập nhật tài khoản: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTenDangNhap.Text))
                {
                    UIHelper.ShowWarningMessage("Vui lòng chọn tài khoản cần xóa!");
                    return;
                }

                if (txtTenDangNhap.Text == "admin")
                {
                    UIHelper.ShowWarningMessage("Không thể xóa tài khoản admin!");
                    return;
                }

                if (UIHelper.ShowConfirmMessage("Bạn có chắc chắn muốn xóa tài khoản này?"))
                {
                    string query = "DELETE FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
                    SqlParameter[] parameters = { new SqlParameter("@TenDangNhap", txtTenDangNhap.Text) };

                    int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
                    if (result > 0)
                    {
                        UIHelper.ShowSuccessMessage("Xóa tài khoản thành công!");
                        LoadData();
                        ClearInputs();
                    }
                }
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("Lỗi khi xóa tài khoản: " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtTimKiem.Text.Trim();
                if (string.IsNullOrEmpty(searchText))
                {
                    LoadData();
                    return;
                }

                string query = @"SELECT * FROM TaiKhoan WHERE 
                                TenDangNhap LIKE @Search OR HoTen LIKE @Search OR 
                                Email LIKE @Search OR VaiTro LIKE @Search";

                SqlParameter[] parameters = { new SqlParameter("@Search", "%" + searchText + "%") };
                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                dgvTaiKhoan.DataSource = dt;
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value?.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value?.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                cmbVaiTro.Text = row.Cells["VaiTro"].Value?.ToString();
                chkTrangThai.Checked = Convert.ToBoolean(row.Cells["TrangThai"].Value);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadData();
        }
    }
}