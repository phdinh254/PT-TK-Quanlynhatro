namespace QuanLyNhaTro.Models
{
    public class Phong
    {
        public string MaPhong { get; set; }
        public string TenPhong { get; set; }
        public decimal GiaPhong { get; set; }
        public string TrangThai { get; set; } // "Trống", "Đã thuê"
        public string LoaiPhong { get; set; }
        public int DienTich { get; set; }
        public string MoTa { get; set; }

        public Phong()
        {
        }

        public Phong(string maPhong, string tenPhong, decimal giaPhong, string trangThai, string loaiPhong, int dienTich, string moTa = "")
        {
            MaPhong = maPhong;
            TenPhong = tenPhong;
            GiaPhong = giaPhong;
            TrangThai = trangThai;
            LoaiPhong = loaiPhong;
            DienTich = dienTich;
            MoTa = moTa;
        }
    }
}