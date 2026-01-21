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
                            WHEN N'Chờ xử lý' THEN 1
                            WHEN N'Đã duyệt' THEN 2
                            WHEN N'Từ chối' THEN 3
                        END, dd.NgayDat DESC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgvDonDat.DataSource = dt;

                // Áp dụng font Times New Roman cho DataGridView
                dgvDonDat.DefaultCellStyle.Font = UIHelper.Fonts.Grid;
                dgvDonDat.ColumnHeadersDefaultCellStyle.Font = UIHelper.Fonts.GridHeader;

                if (dgvDonDat.Columns.Count > 0)
                {
                    dgvDonDat.Columns["MaDonDat"].HeaderText = "Mã đơn";
                    dgvDonDat.Columns["MaPhong"].HeaderText = "Mã phòng";
                    dgvDonDat.Columns["TenPhong"].HeaderText = "Tên phòng";
                    dgvDonDat.Columns["LoaiPhong"].HeaderText = "Loại phòng";
                    dgvDonDat.Columns["GiaPhong"].HeaderText = "Giá phòng";
                    dgvDonDat.Columns["TenDangNhap"].HeaderText = "Tên ĐN";
                    dgvDonDat.Columns["HoTen"].HeaderText = "Họ tên khách";
                    dgvDonDat.Columns["Email"].HeaderText = "Email";
                    dgvDonDat.Columns["NgayDat"].HeaderText = "Ngày đặt";
                    dgvDonDat.Columns["TrangThai"].HeaderText = "Trạng thái";
                    dgvDonDat.Columns["GhiChu"].HeaderText = "Ghi chú";
                    dgvDonDat.Columns["NgayXuLy"].HeaderText = "Ngày xử lý";
                    dgvDonDat.Columns["NguoiXuLy"].HeaderText = "Người xử lý";

                    dgvDonDat.Columns["GiaPhong"].DefaultCellStyle.Format = "N0";
                    dgvDonDat.Columns["NgayDat"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvDonDat.Columns["NgayXuLy"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                    // Tô màu theo trạng thái
                    foreach (DataGridViewRow row in dgvDonDat.Rows)
                    {
                        string trangThai = row.Cells["TrangThai"].Value?.ToString();
                        if (trangThai == "Chờ xử lý")
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                        }
                        else if (trangThai == "Đã duyệt")
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                        }
                        else if (trangThai == "Từ chối")
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightPink;
                        }
                    }
                }

                // Đếm số đơn chờ xử lý
                int soChoXuLy = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["TrangThai"].ToString() == "Chờ xử lý")
                        soChoXuLy++;
                }
                lblThongKe.Text = $"Tổng: {dt.Rows.Count} đơn | Chờ xử lý: {soChoXuLy} đơn";
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void dgvDonDat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDonDat.Rows[e.RowIndex];
                
                // Điền thông tin vào các textbox
                txtMaDonDat.Text = row.Cells["MaDonDat"].Value?.ToString();
                txtMaPhong.Text = row.Cells["MaPhong"].Value?.ToString();
                txtTenPhong.Text = row.Cells["TenPhong"].Value?.ToString();
                txtHoTenKhach.Text = row.Cells["HoTen"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
                
                string trangThai = row.Cells["TrangThai"].Value?.ToString();
                lblTrangThai.Text = trangThai;
                
                // Cập nhật màu sắc trạng thái
                UpdateStatusColor(trangThai);

                // Kiểm tra quyền và trạng thái để enable/disable buttons
                bool hasPermission = CheckPermission();
                bool canProcess = (trangThai?.Trim() == "Chờ xử lý");
                
                btnDuyet.Enabled = hasPermission && canProcess;
                btnTuChoi.Enabled = hasPermission && canProcess;
                
                // Cập nhật tooltip cho buttons
                if (!hasPermission)
                {
                    btnDuyet.Text = "🔒 Duyệt";
                    btnTuChoi.Text = "🔒 Từ chối";
                }
                else if (!canProcess)
                {
                    btnDuyet.Text = "✅ Duyệt";
                    btnTuChoi.Text = "❌ Từ chối";
                }
                else
                {
                    btnDuyet.Text = "✅ Duyệt";
                    btnTuChoi.Text = "❌ Từ chối";
                }
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra quyền
                if (!CheckPermission())
                    return;

                if (string.IsNullOrEmpty(txtMaDonDat.Text))
                {
                    UIHelper.ShowWarningMessage("Vui lòng chọn đơn đặt phòng cần duyệt!");
                    return;
                }

                // Kiểm tra trạng thái hiện tại
                string currentStatus = lblTrangThai.Text?.Trim();
                if (currentStatus != "Chờ xử lý")
                {
                    UIHelper.ShowWarningMessage("Chỉ có thể duyệt đơn đặt phòng có trạng thái 'Chờ xử lý'!");
                    return;
                }

                // Kiểm tra phòng có còn trống không
                string checkPhongQuery = "SELECT TrangThai FROM Phong WHERE MaPhong = @MaPhong";
                SqlParameter[] checkParams = { new SqlParameter("@MaPhong", txtMaPhong.Text) };
                object phongStatus = DatabaseHelper.ExecuteScalar(checkPhongQuery, checkParams);
                
                if (phongStatus?.ToString() != "Trống")
                {
                    UIHelper.ShowWarningMessage($"Phòng {txtTenPhong.Text} hiện không còn trống!\nTrạng thái hiện tại: {phongStatus}\n\nVui lòng kiểm tra lại.");
                    return;
                }

                // Xác nhận duyệt
                string confirmMessage = $"🔍 DUYỆT ĐỚN ĐẶT PHÒNG\n\n" +
                                      $"📋 Mã đơn: {txtMaDonDat.Text}\n" +
                                      $"👤 Khách hàng: {txtHoTenKhach.Text}\n" +
                                      $"🏠 Phòng: {txtTenPhong.Text} ({txtMaPhong.Text})\n" +
                                      $"📧 Email: {txtEmail.Text}\n\n" +
                                      $"Sau khi duyệt:\n" +
                                      $"• Đơn đặt sẽ chuyển thành 'Đã duyệt'\n" +
                                      $"• Phòng sẽ chuyển thành 'Đã đặt'\n" +
                                      $"• Khách hàng sẽ được thông báo qua email\n\n" +
                                      $"Bạn có chắc chắn muốn duyệt?";

                if (UIHelper.ShowConfirmMessage(confirmMessage))
                {
                    // Bắt đầu transaction để đảm bảo tính nhất quán
                    using (var connection = DatabaseHelper.GetConnection())
                    {
                        connection.Open();
                        using (var transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // 1. Cập nhật trạng thái đơn đặt
                                string updateDonQuery = @"
                                    UPDATE DonDatPhong 
                                    SET TrangThai = N'Đã duyệt', 
                                        NgayXuLy = GETDATE(), 
                                        NguoiXuLy = @NguoiXuLy
                                    WHERE MaDonDat = @MaDonDat";

                                using (var cmd = new SqlCommand(updateDonQuery, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@MaDonDat", txtMaDonDat.Text);
                                    cmd.Parameters.AddWithValue("@NguoiXuLy", CurrentUser.TenDangNhap ?? "Admin");
                                    cmd.ExecuteNonQuery();
                                }

                                // 2. Cập nhật trạng thái phòng
                                string updatePhongQuery = "UPDATE Phong SET TrangThai = N'Đã đặt' WHERE MaPhong = @MaPhong";
                                using (var cmd = new SqlCommand(updatePhongQuery, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@MaPhong", txtMaPhong.Text);
                                    cmd.ExecuteNonQuery();
                                }

                                // 3. Ghi log hoạt động (nếu có bảng log)
                                try
                                {
                                    string logQuery = @"
                                        INSERT INTO ActivityLog (TenDangNhap, HanhDong, ChiTiet, NgayThucHien)
                                        VALUES (@TenDangNhap, N'Duyệt đơn đặt phòng', @ChiTiet, GETDATE())";
                                    
                                    using (var cmd = new SqlCommand(logQuery, connection, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@TenDangNhap", CurrentUser.TenDangNhap ?? "Admin");
                                        cmd.Parameters.AddWithValue("@ChiTiet", $"Duyệt đơn {txtMaDonDat.Text} - Phòng {txtTenPhong.Text} - Khách {txtHoTenKhach.Text}");
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                catch
                                {
                                    // Bỏ qua lỗi log nếu bảng không tồn tại
                                }

                                // Commit transaction
                                transaction.Commit();

                                // Thông báo thành công
                                string successMessage = $"✅ DUYỆT THÀNH CÔNG!\n\n" +
                                                       $"📋 Đơn đặt: {txtMaDonDat.Text}\n" +
                                                       $"🏠 Phòng: {txtTenPhong.Text} → Đã đặt\n" +
                                                       $"👤 Khách hàng: {txtHoTenKhach.Text}\n" +
                                                       $"📧 Email: {txtEmail.Text}\n\n" +
                                                       $"📞 Vui lòng liên hệ khách hàng để xác nhận và hướng dẫn thủ tục tiếp theo.";

                                UIHelper.ShowSuccessMessage(successMessage);

                                // Refresh data và clear inputs
                                LoadData();
                                ClearInputs();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                throw new Exception("Lỗi khi thực hiện duyệt đơn: " + ex.Message);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("Lỗi khi duyệt đơn: " + ex.Message);
            }
        }

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra quyền
                if (!CheckPermission())
                    return;

                if (string.IsNullOrEmpty(txtMaDonDat.Text))
                {
                    UIHelper.ShowWarningMessage("Vui lòng chọn đơn đặt phòng cần từ chối!");
                    return;
                }

                // Kiểm tra trạng thái hiện tại
                string currentStatus = lblTrangThai.Text?.Trim();
                if (currentStatus != "Chờ xử lý")
                {
                    UIHelper.ShowWarningMessage("Chỉ có thể từ chối đơn đặt phòng có trạng thái 'Chờ xử lý'!");
                    return;
                }

                // Hiển thị form nhập lý do từ chối
                string lyDoTuChoi = "";
                using (var formLyDo = new FormNhapLyDo("Nhập lý do từ chối đơn đặt phòng"))
                {
                    if (formLyDo.ShowDialog() == DialogResult.OK)
                    {
                        lyDoTuChoi = formLyDo.LyDo;
                    }
                    else
                    {
                        return; // Người dùng hủy
                    }
                }

                // Xác nhận từ chối
                string confirmMessage = $"❌ TỪ CHỐI ĐỚN ĐẶT PHÒNG\n\n" +
                                      $"📋 Mã đơn: {txtMaDonDat.Text}\n" +
                                      $"👤 Khách hàng: {txtHoTenKhach.Text}\n" +
                                      $"🏠 Phòng: {txtTenPhong.Text} ({txtMaPhong.Text})\n" +
                                      $"📧 Email: {txtEmail.Text}\n" +
                                      $"📝 Lý do: {lyDoTuChoi}\n\n" +
                                      $"⚠️ LƯU Ý: Đơn đặt sẽ bị XÓA VĨNH VIỄN!\n\n" +
                                      $"Bạn có chắc chắn muốn từ chối và xóa đơn này?";

                if (UIHelper.ShowConfirmMessage(confirmMessage))
                {
                    // Bắt đầu transaction
                    using (var connection = DatabaseHelper.GetConnection())
                    {
                        connection.Open();
                        using (var transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // 1. Ghi log trước khi xóa
                                try
                                {
                                    string logQuery = @"
                                        INSERT INTO ActivityLog (TenDangNhap, HanhDong, ChiTiet, NgayThucHien)
                                        VALUES (@TenDangNhap, N'Từ chối đơn đặt phòng', @ChiTiet, GETDATE())";
                                    
                                    using (var cmd = new SqlCommand(logQuery, connection, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@TenDangNhap", CurrentUser.TenDangNhap ?? "Admin");
                                        cmd.Parameters.AddWithValue("@ChiTiet", $"Từ chối và xóa đơn {txtMaDonDat.Text} - Phòng {txtTenPhong.Text} - Khách {txtHoTenKhach.Text} - Lý do: {lyDoTuChoi}");
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                catch
                                {
                                    // Bỏ qua lỗi log nếu bảng không tồn tại
                                }

                                // 2. Xóa đơn đặt phòng
                                string deleteQuery = "DELETE FROM DonDatPhong WHERE MaDonDat = @MaDonDat";
                                using (var cmd = new SqlCommand(deleteQuery, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@MaDonDat", txtMaDonDat.Text);
                                    int rowsAffected = cmd.ExecuteNonQuery();
                                    
                                    if (rowsAffected == 0)
                                    {
                                        throw new Exception("Không tìm thấy đơn đặt phòng để xóa!");
                                    }
                                }

                                // Commit transaction
                                transaction.Commit();

                                // Thông báo thành công
                                string successMessage = $"❌ ĐÃ TỪ CHỐI VÀ XÓA ĐỚN!\n\n" +
                                                       $"📋 Đơn đặt: {txtMaDonDat.Text}\n" +
                                                       $"👤 Khách hàng: {txtHoTenKhach.Text}\n" +
                                                       $"📧 Email: {txtEmail.Text}\n" +
                                                       $"📝 Lý do: {lyDoTuChoi}\n\n" +
                                                       $"📞 Khuyến nghị: Liên hệ khách hàng để thông báo và xin lỗi.";

                                UIHelper.ShowSuccessMessage(successMessage);

                                // Refresh data và clear inputs
                                LoadData();
                                ClearInputs();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                throw new Exception("Lỗi khi thực hiện từ chối đơn: " + ex.Message);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("Lỗi khi từ chối đơn: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị loading
                this.Cursor = Cursors.WaitCursor;
                
                // Lưu lại selection hiện tại (nếu có)
                string selectedMaDon = txtMaDonDat.Text;
                
                // Refresh data
                LoadData();
                
                // Khôi phục selection nếu có thể
                if (!string.IsNullOrEmpty(selectedMaDon))
                {
                    foreach (DataGridViewRow row in dgvDonDat.Rows)
                    {
                        if (row.Cells["MaDonDat"].Value?.ToString() == selectedMaDon)
                        {
                            row.Selected = true;
                            dgvDonDat.FirstDisplayedScrollingRowIndex = row.Index;
                            dgvDonDat_CellClick(dgvDonDat, new DataGridViewCellEventArgs(0, row.Index));
                            break;
                        }
                    }
                }
                else
                {
                    // Clear inputs nếu không có selection
                    ClearInputs();
                }
                
                // Thông báo thành công ngắn gọn
                string originalText = lblThongKe.Text;
                lblThongKe.Text = originalText + " - ✅ Đã làm mới";
                
                // Khôi phục text gốc sau 2 giây bằng cách đơn giản
                System.Threading.Tasks.Task.Delay(2000).ContinueWith(t =>
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() => LoadData()));
                    }
                    else
                    {
                        LoadData();
                    }
                });
            }
            catch (Exception ex)
            {
                UIHelper.ShowErrorMessage("Lỗi khi làm mới dữ liệu: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
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
                UIHelper.ShowErrorMessage("Lỗi khi tìm kiếm: " + ex.Message);
            }
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
            lblTrangThai.ForeColor = System.Drawing.Color.Gray;
            
            // Disable buttons
            btnDuyet.Enabled = false;
            btnTuChoi.Enabled = false;
            
            // Clear selection trong DataGridView
            dgvDonDat.ClearSelection();
        }

        /// <summary>
        /// Kiểm tra quyền thực hiện thao tác
        /// </summary>
        private bool CheckPermission()
        {
            // Chỉ Admin mới được duyệt/từ chối đơn
            if (CurrentUser.VaiTro?.ToLower() != "admin")
            {
                UIHelper.ShowWarningMessage("Bạn không có quyền thực hiện thao tác này!\nChỉ Admin mới có thể duyệt/từ chối đơn đặt phòng.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Cập nhật màu sắc trạng thái
        /// </summary>
        private void UpdateStatusColor(string trangThai)
        {
            switch (trangThai?.Trim())
            {
                case "Chờ xử lý":
                    lblTrangThai.ForeColor = System.Drawing.Color.Orange;
                    break;
                case "Đã duyệt":
                    lblTrangThai.ForeColor = System.Drawing.Color.Green;
                    break;
                case "Từ chối":
                    lblTrangThai.ForeColor = System.Drawing.Color.Red;
                    break;
                default:
                    lblTrangThai.ForeColor = System.Drawing.Color.Gray;
                    break;
            }
        }

        /// <summary>
        /// Thêm keyboard shortcuts
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    btnLamMoi_Click(null, null);
                    return true;
                case Keys.Control | Keys.D:
                    if (btnDuyet.Enabled)
                        btnDuyet_Click(null, null);
                    return true;
                case Keys.Control | Keys.R:
                    if (btnTuChoi.Enabled)
                        btnTuChoi_Click(null, null);
                    return true;
                case Keys.Escape:
                    ClearInputs();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
