using System;

namespace QuanLyNhaTro.Models
{
    public class KhachHang
    {
        public string MaKhach { get; set; }
        public string TenKhach { get; set; }
        public string SoDienThoai { get; set; }
        public string CMND { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string GhiChu { get; set; }

        public KhachHang()
        {
        }

        public KhachHang(string maKhach, string tenKhach, string soDienThoai, string cmnd, string diaChi, DateTime ngaySinh, string gioiTinh, string ghiChu = "")
        {
            MaKhach = maKhach;
            TenKhach = tenKhach;
            SoDienThoai = soDienThoai;
            CMND = cmnd;
            DiaChi = diaChi;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            GhiChu = ghiChu;
        }
    }
}