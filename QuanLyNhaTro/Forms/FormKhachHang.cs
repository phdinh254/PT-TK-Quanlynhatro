using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using QuanLyNhaTro.Data;
using QuanLyNhaTro.Models;
using QuanLyNhaTro.Helpers;

namespace QuanLyNhaTro.Forms
{
    public partial class FormKhachHang : Form
    {
        public FormKhachHang()
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
                string query = "SELECT * FROM KhachHang ORDER BY MaKhach";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgvKhachHang.DataSource = dt;
                
                // Đặt tên cột hiển thị
                if (dgvKhachHang.Columns.Count > 0)
                {
                    dgvKhachHang.Columns["MaKhach"].HeaderText = "Mã khách";
                    dgvKhachHang.Columns["TenKhach"].HeaderText = "Họ tên";
                    dgvKhachHang.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
                    dgvKhachHang.Columns["CMND"].HeaderText = "CMND";
                    dgvKhachHang.Columns["DiaChi"].HeaderText = "Địa chỉ";
                    dgvKhachHang.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                    dgvKhachHang.Columns["GioiTinh"].HeaderText = "Giới tính";
                    dgvKhachHang.Columns["GhiChu"].HeaderText = "Ghi chú";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtMaKhach.Clear();
            txtTenKhach.Clear();
            txtSoDienThoai.Clear();
            txtCMND.Clear();
            txtDiaChi.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            cmbGioiTinh.SelectedIndex = -1;
            txtGhiChu.Clear();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaKhach.Text))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKhach.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenKhach.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhach.Focus();
                return false;
            }

            // Kiểm tra số điện thoại (nếu có nhập)
            if (!string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                if (txtSoDienThoai.Text.Length < 10 || txtSoDienThoai.Text.Length > 11)
                {
                    MessageBox.Show("Số điện thoại phải có 10-11 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoDienThoai.Focus();
                    return false;
                }
            }

            int age = DateTime.Now.Year - dtpNgaySinh.Value.Year;
            if (dtpNgaySinh.Value.Date > DateTime.Now.AddYears(-age)) age--;
            if (age < 18)
            {
                MessageBox.Show("Khách hàng phải đủ 18 tuổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Liên kết họ tên khách với tài khoản (nếu có)
            string checkAccountQuery = "SELECT COUNT(*) FROM TaiKhoan WHERE HoTen = @HoTen";
            SqlParameter[] accountParams = { new SqlParameter("@HoTen", txtTenKhach.Text.Trim()) };
            int accountCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkAccountQuery, accountParams));
            if (accountCount == 0)
            {
                MessageBox.Show("Chưa tìm thấy tài khoản có họ tên này trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                // Kiểm tra mã khách đã tồn tại chưa
                string checkQuery = "SELECT COUNT(*) FROM KhachHang WHERE MaKhach = @MaKhach";
                SqlParameter[] checkParams = { new SqlParameter("@MaKhach", txtMaKhach.Text) };
                int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery, checkParams));
                
                if (count > 0)
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaKhach.Focus();
                    return;
                }

                string query = @"INSERT INTO KhachHang (MaKhach, TenKhach, SoDienThoai, CMND, DiaChi, NgaySinh, GioiTinh, GhiChu) 
                                VALUES (@MaKhach, @TenKhach, @SoDienThoai, @CMND, @DiaChi, @NgaySinh, @GioiTinh, @GhiChu)";

                SqlParameter[] parameters = {
                    new SqlParameter("@MaKhach", txtMaKhach.Text),
                    new SqlParameter("@TenKhach", txtTenKhach.Text),
                    new SqlParameter("@SoDienThoai", txtSoDienThoai.Text),
                    new SqlParameter("@CMND", txtCMND.Text),
                    new SqlParameter("@DiaChi", txtDiaChi.Text),
                    new SqlParameter("@NgaySinh", dtpNgaySinh.Value),
                    new SqlParameter("@GioiTinh", cmbGioiTinh.Text),
                    new SqlParameter("@GhiChu", txtGhiChu.Text)
                };

                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaKhach.Text))
                {
                    MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateInput())
                    return;

                string query = @"UPDATE KhachHang SET TenKhach = @TenKhach, SoDienThoai = @SoDienThoai, CMND = @CMND, 
                                DiaChi = @DiaChi, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, GhiChu = @GhiChu 
                                WHERE MaKhach = @MaKhach";

                SqlParameter[] parameters = {
                    new SqlParameter("@MaKhach", txtMaKhach.Text),
                    new SqlParameter("@TenKhach", txtTenKhach.Text),
                    new SqlParameter("@SoDienThoai", txtSoDienThoai.Text),
                    new SqlParameter("@CMND", txtCMND.Text),
                    new SqlParameter("@DiaChi", txtDiaChi.Text),
                    new SqlParameter("@NgaySinh", dtpNgaySinh.Value),
                    new SqlParameter("@GioiTinh", cmbGioiTinh.Text),
                    new SqlParameter("@GhiChu", txtGhiChu.Text)
                };

                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaKhach.Text))
                {
                    MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string query = "DELETE FROM KhachHang WHERE MaKhach = @MaKhach";
                    SqlParameter[] parameters = { new SqlParameter("@MaKhach", txtMaKhach.Text) };

                    int deleteResult = DatabaseHelper.ExecuteNonQuery(query, parameters);
                    if (deleteResult > 0)
                    {
                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearInputs();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string query = @"SELECT * FROM KhachHang WHERE 
                                MaKhach LIKE @Search OR TenKhach LIKE @Search OR 
                                SoDienThoai LIKE @Search OR CMND LIKE @Search OR DiaChi LIKE @Search";

                SqlParameter[] parameters = { new SqlParameter("@Search", "%" + searchText + "%") };
                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                dgvKhachHang.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKhach.Text = row.Cells["MaKhach"].Value?.ToString();
                txtTenKhach.Text = row.Cells["TenKhach"].Value?.ToString();
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value?.ToString();
                txtCMND.Text = row.Cells["CMND"].Value?.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                
                if (DateTime.TryParse(row.Cells["NgaySinh"].Value?.ToString(), out DateTime ngaySinh))
                    dtpNgaySinh.Value = ngaySinh;
                
                cmbGioiTinh.Text = row.Cells["GioiTinh"].Value?.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadData();
        }
    }
}