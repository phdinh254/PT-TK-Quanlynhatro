using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QuanLyNhaTro.Data;
using QuanLyNhaTro.Helpers;

namespace QuanLyNhaTro.Forms
{
    public partial class FormDonDatPhong : Form
    {
        public FormDonDatPhong()
        {
            InitializeComponent();
            InitializeUI();
            LoadData();
        }

        private void InitializeUI()
        {
            UIHelper.StandardizeForm(this);
            UIHelper.StylePrimaryButton(btnDuyet);
            UIHelper.StyleDangerButton(btnTuChoi);
            UIHelper.StyleButton(btnLamMoi, UIHelper.Colors.TextSecondary, UIHelper.Colors.White);
            UIHelper.StyleButton(btnTimKiem, UIHelper.Colors.Primary, UIHelper.Colors.White);
        }

        private void LoadData()
        {
            try
            {
                string query = @"
                    SELECT dd.MaDonDat, dd.MaPhong, p.TenPhong, p.LoaiPhong, p.GiaPhong,
                           dd.TenDangNhap, tk.HoTen, tk.Email,
                           dd.NgayDat, dd.TrangThai, dd.GhiChu, dd.NgayXuLy, dd.NguoiXuLy
                    FROM DonDatPhong dd
                    JOIN Phong p ON dd.MaPhong = p.MaPhong
                    JOIN TaiKhoan tk ON dd.TenDangNhap = tk.TenDangNhap
                    ORDER BY 
                        CASE dd.TrangThai 
                            WHEN N'Ch? x? lý' THEN 1
                            WHEN N'?ã duy?t' THEN 2
                            WHEN N'T? ch?i' THEN 3
                        END, dd.NgayDat DESC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgvDonDat.DataSource = dt;

                // Áp d?ng font Times New Roman cho DataGridView
                dgvDonDat.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 10F);
                dgvDonDat.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);

                if (dgvDonDat.Columns.Count > 0)
                {
                    dgvDonDat.Columns["MaDonDat"].HeaderText = "Mã ??n";
                    dgvDonDat.Columns["MaPhong"].HeaderText = "Mã phòng";
                    dgvDonDat.Columns["TenPhong"].HeaderText = "Tên phòng";
                    dgvDonDat.Columns["LoaiPhong"].HeaderText = "Lo?i phòng";
                    dgvDonDat.Columns["GiaPhong"].HeaderText = "Giá phòng";
                    dgvDonDat.Columns["TenDangNhap"].HeaderText = "Tên ?N";
                    dgvDonDat.Columns["HoTen"].HeaderText = "H? tên khách";
                    dgvDonDat.Columns["Email"].HeaderText = "Email";
                    dgvDonDat.Columns["NgayDat"].HeaderText = "Ngày ??t";
                    dgvDonDat.Columns["TrangThai"].HeaderText = "Tr?ng thái";
                    dgvDonDat.Columns["GhiChu"].HeaderText = "Ghi chú";
                    dgvDonDat.Columns["NgayXuLy"].HeaderText = "Ngày x? lý";
                    dgvDonDat.Columns["NguoiXuLy"].HeaderText = "Ng??i x? lý";

                    dgvDonDat.Columns["GiaPhong"].DefaultCellStyle.Format = "N0";
                    dgvDonDat.Columns["NgayDat"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvDonDat.Columns["NgayXuLy"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                    // Tô màu theo tr?ng thái
                    foreach (DataGridViewRow row in dgvDonDat.Rows)
                    {
                        string trangThai = row.Cells["TrangThai"].Value?.ToString();
                        if (trangThai == "Ch? x? lý")
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                        }
                        else if (trangThai == "?ã duy?t")
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                        }
                        else if (trangThai == "T? ch?i")
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightPink;
                        }
                    }
                }

                // ??m s? ??n ch? x? lý
                int soChoXuLy = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["TrangThai"].ToString() == "Ch? x? lý")
                        soChoXuLy++;
                }
                lblThongKe.Text = $"T?ng: {dt.Rows.Count} ??n | Ch? x? lý: {soChoXuLy} ??n";
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("L?i khi t?i d? li?u: " + ex.Message);
            }
        }

        private void dgvDonDat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDonDat.Rows[e.RowIndex];
                txtMaDonDat.Text = row.Cells["MaDonDat"].Value?.ToString();
                txtMaPhong.Text = row.Cells["MaPhong"].Value?.ToString();
                txtTenPhong.Text = row.Cells["TenPhong"].Value?.ToString();
                txtHoTenKhach.Text = row.Cells["HoTen"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
                lblTrangThai.Text = row.Cells["TrangThai"].Value?.ToString();

                // Ch? cho phép duy?t/t? ch?i ??n ch? x? lý
                string trangThai = row.Cells["TrangThai"].Value?.ToString()?.Trim().ToLower();
                btnDuyet.Enabled = (trangThai == "ch? x? lý");
                btnTuChoi.Enabled = (trangThai == "ch? x? lý");
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaDonDat.Text))
                {
                    UIHelper.ShowWarningMessage("Vui lòng ch?n ??n ??t phòng c?n duy?t!");
                    return;
                }

                if (UIHelper.ShowConfirmMessage($"B?n có ch?c mu?n duy?t ??n ??t phòng này?\n\nKhách hàng: {txtHoTenKhach.Text}\nPhòng: {txtTenPhong.Text}"))
                {
                    // C?p nh?t tr?ng thái ??n ??t
                    string updateQuery = @"
                        UPDATE DonDatPhong 
                        SET TrangThai = N'?ã duy?t', 
                            NgayXuLy = GETDATE(), 
                            NguoiXuLy = @NguoiXuLy
                        WHERE MaDonDat = @MaDonDat";

                    SqlParameter[] parameters = {
                        new SqlParameter("@MaDonDat", txtMaDonDat.Text),
                        new SqlParameter("@NguoiXuLy", CurrentUser.TenDangNhap)
                    };

                    DatabaseHelper.ExecuteNonQuery(updateQuery, parameters);

                    // C?p nh?t tr?ng thái phòng thành "?ã ??t"
                    string updatePhongQuery = "UPDATE Phong SET TrangThai = N'?ã ??t' WHERE MaPhong = @MaPhong";
                    SqlParameter[] phongParams = { new SqlParameter("@MaPhong", txtMaPhong.Text) };
                    DatabaseHelper.ExecuteNonQuery(updatePhongQuery, phongParams);

                    UIHelper.ShowSuccessMessage("?ã duy?t ??n ??t phòng!\n\nPhòng ?ã ???c chuy?n sang tr?ng thái '?ã ??t'.\nVui lòng liên h? v?i khách hàng qua email: " + txtEmail.Text);
                    LoadData();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("L?i khi duy?t ??n: " + ex.Message);
            }
        }

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaDonDat.Text))
                {
                    UIHelper.ShowWarningMessage("Vui lòng ch?n ??n ??t phòng c?n t? ch?i!");
                    return;
                }

                if (UIHelper.ShowConfirmMessage($"B?n có ch?c mu?n XÓA ??n ??t phòng này?\n\nKhách hàng: {txtHoTenKhach.Text}\nPhòng: {txtTenPhong.Text}\n\nL?u ý: ??n ??t s? b? xóa v?nh vi?n!"))
                {
                    // Xóa ??n ??t phòng
                    string deleteQuery = "DELETE FROM DonDatPhong WHERE MaDonDat = @MaDonDat";

                    SqlParameter[] parameters = { new SqlParameter("@MaDonDat", txtMaDonDat.Text) };

                    DatabaseHelper.ExecuteNonQuery(deleteQuery, parameters);

                    UIHelper.ShowSuccessMessage("?ã xóa ??n ??t phòng!");
                    LoadData();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("L?i khi xóa ??n: " + ex.Message);
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

                string query = @"
                    SELECT dd.MaDonDat, dd.MaPhong, p.TenPhong, p.LoaiPhong, p.GiaPhong,
                           dd.TenDangNhap, tk.HoTen, tk.Email,
                           dd.NgayDat, dd.TrangThai, dd.GhiChu, dd.NgayXuLy, dd.NguoiXuLy
                    FROM DonDatPhong dd
                    JOIN Phong p ON dd.MaPhong = p.MaPhong
                    JOIN TaiKhoan tk ON dd.TenDangNhap = tk.TenDangNhap
                    WHERE dd.MaDonDat LIKE @Search 
                       OR p.TenPhong LIKE @Search 
                       OR tk.HoTen LIKE @Search
                       OR dd.TrangThai LIKE @Search
                    ORDER BY dd.NgayDat DESC";

                SqlParameter[] parameters = { new SqlParameter("@Search", "%" + searchText + "%") };
                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                dgvDonDat.DataSource = dt;
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("L?i khi tìm ki?m: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtMaDonDat.Clear();
            txtMaPhong.Clear();
            txtTenPhong.Clear();
            txtHoTenKhach.Clear();
            txtEmail.Clear();
            txtGhiChu.Clear();
            lblTrangThai.Text = "";
            btnDuyet.Enabled = false;
            btnTuChoi.Enabled = false;
        }
    }
}
