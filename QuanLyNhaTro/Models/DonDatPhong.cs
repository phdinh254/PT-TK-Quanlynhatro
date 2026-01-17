using System;

namespace QuanLyNhaTro.Models
{
    public class DonDatPhong
    {
        public string MaDonDat { get; set; }
        public string MaPhong { get; set; }
        public string TenDangNhap { get; set; }
        public DateTime NgayDat { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
        public DateTime? NgayXuLy { get; set; }
        public string NguoiXuLy { get; set; }
    }
}
