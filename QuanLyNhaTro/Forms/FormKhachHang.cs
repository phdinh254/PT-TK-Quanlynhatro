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
            // Load danh sách tài khoản vào combobox
            LoadTaiKhoanToComboBox();
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

        private void LoadTaiKhoanToComboBox()
        {
            try
            {
                // Nếu form có ComboBox chọn tên khách (cần thêm vào Designer)
                // Tạm thời comment lại vì chưa có trong Designer
                /*
                string query = "SELECT TenDangNhap, HoTen FROM TaiKhoan WHERE VaiTro = 'User' ORDER BY HoTen";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                
                if (this.Controls.Find("cmbTenKhach", true).Length > 0)
                {
                    ComboBox cmb = (ComboBox)this.Controls.Find("cmbTenKhach", true)[0];
                    cmb.DataSource = dt;
                    cmb.DisplayMember = "HoTen";
                    cmb.ValueMember = "TenDangNhap";
                    cmb.SelectedIndex = -1;
                }
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            // Chỉ clear ghi chú
            txtGhiChu.Clear();
            
            // Bỏ chọn dòng trong DataGridView
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                dgvKhachHang.ClearSelection();
            }
        }

        private bool ValidateInput()
        {
            // Chỉ cho phép cập nhật ghi chú, không cần validate
            // Tất cả thông tin khách hàng đã được tạo tự động từ TaiKhoan
            // Chỉ cần kiểm tra có chọn khách hàng không (khi sửa)

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Khách hàng được tạo tự động từ tài khoản!\n\nVui lòng yêu cầu người dùng đăng ký tài khoản và cập nhật thông tin cá nhân.", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Lấy MaKhach từ row được chọn trong DataGridView
                if (dgvKhachHang.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maKhach = dgvKhachHang.SelectedRows[0].Cells["MaKhach"].Value?.ToString();
                if (string.IsNullOrEmpty(maKhach))
                {
                    MessageBox.Show("Không tìm thấy mã khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Chỉ cập nhật ghi chú
                string query = "UPDATE KhachHang SET GhiChu = @GhiChu WHERE MaKhach = @MaKhach";

                SqlParameter[] parameters = {
                    new SqlParameter("@MaKhach", maKhach),
                    new SqlParameter("@GhiChu", txtGhiChu.Text)
                };

                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật ghi chú thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (dgvKhachHang.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maKhach = dgvKhachHang.SelectedRows[0].Cells["MaKhach"].Value?.ToString();
                string tenKhach = dgvKhachHang.SelectedRows[0].Cells["TenKhach"].Value?.ToString();
                
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng '{tenKhach}'?\n\nLưu ý: Thao tác này không thể hoàn tác!", 
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string query = "DELETE FROM KhachHang WHERE MaKhach = @MaKhach";
                    SqlParameter[] parameters = { new SqlParameter("@MaKhach", maKhach) };

                    int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
                    if (result > 0)
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
                // Chỉ load ghi chú vào textbox
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