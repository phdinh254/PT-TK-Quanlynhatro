using System;

namespace QuanLyNhaTro.Models
{
    public class HopDong
    {
        public string MaHopDong { get; set; }
        public string MaKhach { get; set; }
        public string MaPhong { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public decimal TienCoc { get; set; }
        public string TrangThai { get; set; } // "Đang hiệu lực", "Hết hạn", "Đã hủy"
        public string GhiChu { get; set; }

        public HopDong()
        {
        }

        public HopDong(string maHopDong, string maKhach, string maPhong, DateTime ngayBatDau, DateTime ngayKetThuc, decimal tienCoc, string trangThai, string ghiChu = "")
        {
            MaHopDong = maHopDong;
            MaKhach = maKhach;
            MaPhong = maPhong;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            TienCoc = tienCoc;
            TrangThai = trangThai;
            GhiChu = ghiChu;
        }
    }
}