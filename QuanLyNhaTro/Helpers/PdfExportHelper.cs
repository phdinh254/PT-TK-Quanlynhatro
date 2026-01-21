using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Data.SqlClient;
using QuanLyNhaTro.Data;

namespace QuanLyNhaTro.Helpers
{
    public static class PdfExportHelper
    {
        private static readonly Font FONT_TITLE = new Font(BaseFont.CreateFont("c:/windows/fonts/times.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED), 18, Font.BOLD);
        private static readonly Font FONT_HEADER = new Font(BaseFont.CreateFont("c:/windows/fonts/times.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED), 14, Font.BOLD);
        private static readonly Font FONT_NORMAL = new Font(BaseFont.CreateFont("c:/windows/fonts/times.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED), 12, Font.NORMAL);
        private static readonly Font FONT_SMALL = new Font(BaseFont.CreateFont("c:/windows/fonts/times.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED), 10, Font.NORMAL);

        public static void ExportHoaDonToPdf(string maHoaDon, string filePath)
        {
            try
            {
                // Lấy thông tin hóa đơn từ database
                var hoaDonData = GetHoaDonData(maHoaDon);
                if (hoaDonData == null)
                {
                    throw new Exception("Không tìm thấy hóa đơn!");
                }

                // Tạo document PDF
                Document document = new Document(PageSize.A4, 50, 50, 50, 50);
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                
                document.Open();

                // Header - Logo và thông tin công ty
                AddCompanyHeader(document);
                
                // Tiêu đề hóa đơn
                AddInvoiceTitle(document, hoaDonData);
                
                // Thông tin khách hàng và hợp đồng
                AddCustomerInfo(document, hoaDonData);
                
                // Chi tiết hóa đơn
                AddInvoiceDetails(document, hoaDonData);
                
                // Tổng tiền và chữ ký
                AddFooter(document, hoaDonData);

                document.Close();
                writer.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xuất PDF: {ex.Message}");
            }
        }

        private static DataRow GetHoaDonData(string maHoaDon)
        {
            string query = @"
                SELECT hd.*, 
                       kh.TenKhach, kh.SoDienThoai, kh.CMND, kh.DiaChi,
                       p.TenPhong, p.LoaiPhong, p.Tang,
                       hop.NgayBatDau, hop.NgayKetThuc
                FROM HoaDon hd
                JOIN HopDong hop ON hd.MaHopDong = hop.MaHopDong
                JOIN KhachHang kh ON hop.MaKhach = kh.MaKhach
                JOIN Phong p ON hop.MaPhong = p.MaPhong
                WHERE hd.MaHoaDon = @MaHoaDon";

            SqlParameter[] parameters = { new SqlParameter("@MaHoaDon", maHoaDon) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        private static void AddCompanyHeader(Document document)
        {
            // Logo và thông tin công ty
            PdfPTable headerTable = new PdfPTable(2);
            headerTable.WidthPercentage = 100;
            headerTable.SetWidths(new float[] { 1, 2 });

            // Logo (placeholder)
            PdfPCell logoCell = new PdfPCell();
            logoCell.Border = Rectangle.NO_BORDER;
            logoCell.AddElement(new Paragraph("LOGO", FONT_HEADER));
            headerTable.AddCell(logoCell);

            // Thông tin công ty
            PdfPCell companyCell = new PdfPCell();
            companyCell.Border = Rectangle.NO_BORDER;
            companyCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            
            Paragraph companyInfo = new Paragraph();
            companyInfo.Add(new Chunk("CÔNG TY QUẢN LÝ NHÀ TRỌ\n", FONT_HEADER));
            companyInfo.Add(new Chunk("Địa chỉ: 123 Đường ABC, Quận XYZ, TP.HCM\n", FONT_SMALL));
            companyInfo.Add(new Chunk("Điện thoại: 0123.456.789\n", FONT_SMALL));
            companyInfo.Add(new Chunk("Email: info@nhatro.com", FONT_SMALL));
            
            companyCell.AddElement(companyInfo);
            headerTable.AddCell(companyCell);

            document.Add(headerTable);
            document.Add(new Paragraph(" ")); // Khoảng trống
        }

        private static void AddInvoiceTitle(Document document, DataRow data)
        {
            // Tiêu đề hóa đơn
            Paragraph title = new Paragraph("HÓA ĐƠN TIỀN PHÒNG", FONT_TITLE);
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            // Mã hóa đơn và ngày tạo
            PdfPTable titleTable = new PdfPTable(2);
            titleTable.WidthPercentage = 100;
            titleTable.SpacingBefore = 20;

            PdfPCell leftCell = new PdfPCell(new Phrase($"Mã hóa đơn: {data["MaHoaDon"]}", FONT_NORMAL));
            leftCell.Border = Rectangle.NO_BORDER;
            titleTable.AddCell(leftCell);

            PdfPCell rightCell = new PdfPCell(new Phrase($"Ngày tạo: {Convert.ToDateTime(data["NgayTao"]):dd/MM/yyyy}", FONT_NORMAL));
            rightCell.Border = Rectangle.NO_BORDER;
            rightCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            titleTable.AddCell(rightCell);

            document.Add(titleTable);
            document.Add(new Paragraph(" "));
        }

        private static void AddCustomerInfo(Document document, DataRow data)
        {
            // Thông tin khách hàng
            PdfPTable customerTable = new PdfPTable(2);
            customerTable.WidthPercentage = 100;
            customerTable.SetWidths(new float[] { 1, 1 });

            // Cột trái - Thông tin khách hàng
            PdfPCell leftCell = new PdfPCell();
            leftCell.Border = Rectangle.NO_BORDER;
            leftCell.PaddingRight = 20;
            
            Paragraph customerInfo = new Paragraph();
            customerInfo.Add(new Chunk("THÔNG TIN KHÁCH HÀNG\n", FONT_HEADER));
            customerInfo.Add(new Chunk($"Họ tên: {data["TenKhach"]}\n", FONT_NORMAL));
            customerInfo.Add(new Chunk($"CMND: {data["CMND"]}\n", FONT_NORMAL));
            customerInfo.Add(new Chunk($"Điện thoại: {data["SoDienThoai"]}\n", FONT_NORMAL));
            customerInfo.Add(new Chunk($"Địa chỉ: {data["DiaChi"]}", FONT_NORMAL));
            
            leftCell.AddElement(customerInfo);
            customerTable.AddCell(leftCell);

            // Cột phải - Thông tin phòng
            PdfPCell rightCell = new PdfPCell();
            rightCell.Border = Rectangle.NO_BORDER;
            
            Paragraph roomInfo = new Paragraph();
            roomInfo.Add(new Chunk("THÔNG TIN PHÒNG\n", FONT_HEADER));
            roomInfo.Add(new Chunk($"Tên phòng: {data["TenPhong"]}\n", FONT_NORMAL));
            roomInfo.Add(new Chunk($"Loại phòng: {data["LoaiPhong"]}\n", FONT_NORMAL));
            roomInfo.Add(new Chunk($"Tầng: {data["Tang"]}\n", FONT_NORMAL));
            roomInfo.Add(new Chunk($"Mã hợp đồng: {data["MaHopDong"]}", FONT_NORMAL));
            
            rightCell.AddElement(roomInfo);
            customerTable.AddCell(rightCell);

            document.Add(customerTable);
            document.Add(new Paragraph(" "));
        }

        private static void AddInvoiceDetails(Document document, DataRow data)
        {
            // Bảng chi tiết hóa đơn
            PdfPTable detailTable = new PdfPTable(5);
            detailTable.WidthPercentage = 100;
            detailTable.SetWidths(new float[] { 3, 1.5f, 1.5f, 1.5f, 2 });
            detailTable.SpacingBefore = 20;

            // Header của bảng
            string[] headers = { "Khoản thu", "Chỉ số cũ", "Chỉ số mới", "Đơn giá", "Thành tiền" };
            foreach (string header in headers)
            {
                PdfPCell headerCell = new PdfPCell(new Phrase(header, FONT_HEADER));
                headerCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                headerCell.Padding = 8;
                detailTable.AddCell(headerCell);
            }

            // Tiền phòng
            detailTable.AddCell(new PdfPCell(new Phrase("Tiền phòng", FONT_NORMAL)) { Padding = 5 });
            detailTable.AddCell(new PdfPCell(new Phrase("-", FONT_NORMAL)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
            detailTable.AddCell(new PdfPCell(new Phrase("-", FONT_NORMAL)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
            detailTable.AddCell(new PdfPCell(new Phrase("-", FONT_NORMAL)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
            detailTable.AddCell(new PdfPCell(new Phrase(Convert.ToDecimal(data["TienPhong"]).ToString("N0") + " VNĐ", FONT_NORMAL)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5 });

            // Tiền điện
            detailTable.AddCell(new PdfPCell(new Phrase("Tiền điện", FONT_NORMAL)) { Padding = 5 });
            detailTable.AddCell(new PdfPCell(new Phrase(data["ChiSoDienCu"].ToString(), FONT_NORMAL)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
            detailTable.AddCell(new PdfPCell(new Phrase(data["ChiSoDienMoi"].ToString(), FONT_NORMAL)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
            detailTable.AddCell(new PdfPCell(new Phrase(Convert.ToDecimal(data["DonGiaDien"]).ToString("N0"), FONT_NORMAL)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
            detailTable.AddCell(new PdfPCell(new Phrase(Convert.ToDecimal(data["TienDien"]).ToString("N0") + " VNĐ", FONT_NORMAL)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5 });

            // Tiền nước
            detailTable.AddCell(new PdfPCell(new Phrase("Tiền nước", FONT_NORMAL)) { Padding = 5 });
            detailTable.AddCell(new PdfPCell(new Phrase(data["ChiSoNuocCu"].ToString(), FONT_NORMAL)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
            detailTable.AddCell(new PdfPCell(new Phrase(data["ChiSoNuocMoi"].ToString(), FONT_NORMAL)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
            detailTable.AddCell(new PdfPCell(new Phrase(Convert.ToDecimal(data["DonGiaNuoc"]).ToString("N0"), FONT_NORMAL)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
            detailTable.AddCell(new PdfPCell(new Phrase(Convert.ToDecimal(data["TienNuoc"]).ToString("N0") + " VNĐ", FONT_NORMAL)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5 });

            // Tiền khác (nếu có)
            decimal tienKhac = Convert.ToDecimal(data["TienKhac"]);
            if (tienKhac > 0)
            {
                detailTable.AddCell(new PdfPCell(new Phrase("Phí khác", FONT_NORMAL)) { Padding = 5 });
                detailTable.AddCell(new PdfPCell(new Phrase("-", FONT_NORMAL)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
                detailTable.AddCell(new PdfPCell(new Phrase("-", FONT_NORMAL)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
                detailTable.AddCell(new PdfPCell(new Phrase("-", FONT_NORMAL)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
                detailTable.AddCell(new PdfPCell(new Phrase(tienKhac.ToString("N0") + " VNĐ", FONT_NORMAL)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5 });
            }

            // Tổng tiền
            PdfPCell totalLabelCell = new PdfPCell(new Phrase("TỔNG CỘNG", FONT_HEADER));
            totalLabelCell.Colspan = 4;
            totalLabelCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            totalLabelCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            totalLabelCell.Padding = 8;
            detailTable.AddCell(totalLabelCell);

            PdfPCell totalValueCell = new PdfPCell(new Phrase(Convert.ToDecimal(data["TongTien"]).ToString("N0") + " VNĐ", FONT_HEADER));
            totalValueCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            totalValueCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            totalValueCell.Padding = 8;
            detailTable.AddCell(totalValueCell);

            document.Add(detailTable);
        }

        private static void AddFooter(Document document, DataRow data)
        {
            document.Add(new Paragraph(" "));

            // Ghi chú (nếu có)
            string ghiChu = data["GhiChu"]?.ToString();
            if (!string.IsNullOrEmpty(ghiChu))
            {
                Paragraph note = new Paragraph($"Ghi chú: {ghiChu}", FONT_NORMAL);
                document.Add(note);
                document.Add(new Paragraph(" "));
            }

            // Trạng thái thanh toán
            string trangThai = data["TrangThai"]?.ToString();
            Paragraph status = new Paragraph($"Trạng thái: {trangThai}", FONT_NORMAL);
            status.Alignment = Element.ALIGN_CENTER;
            document.Add(status);

            if (data["NgayThanhToan"] != DBNull.Value)
            {
                DateTime ngayThanhToan = Convert.ToDateTime(data["NgayThanhToan"]);
                Paragraph paymentDate = new Paragraph($"Ngày thanh toán: {ngayThanhToan:dd/MM/yyyy}", FONT_NORMAL);
                paymentDate.Alignment = Element.ALIGN_CENTER;
                document.Add(paymentDate);
            }

            document.Add(new Paragraph(" "));

            // Chữ ký
            PdfPTable signatureTable = new PdfPTable(2);
            signatureTable.WidthPercentage = 100;
            signatureTable.SpacingBefore = 30;

            PdfPCell customerSignCell = new PdfPCell();
            customerSignCell.Border = Rectangle.NO_BORDER;
            customerSignCell.HorizontalAlignment = Element.ALIGN_CENTER;
            Paragraph customerSign = new Paragraph();
            customerSign.Add(new Chunk("Khách hàng\n", FONT_NORMAL));
            customerSign.Add(new Chunk("(Ký và ghi rõ họ tên)\n\n\n\n", FONT_SMALL));
            customerSign.Add(new Chunk($"{data["TenKhach"]}", FONT_NORMAL));
            customerSignCell.AddElement(customerSign);
            signatureTable.AddCell(customerSignCell);

            PdfPCell adminSignCell = new PdfPCell();
            adminSignCell.Border = Rectangle.NO_BORDER;
            adminSignCell.HorizontalAlignment = Element.ALIGN_CENTER;
            Paragraph adminSign = new Paragraph();
            adminSign.Add(new Chunk("Người lập hóa đơn\n", FONT_NORMAL));
            adminSign.Add(new Chunk("(Ký và ghi rõ họ tên)\n\n\n\n", FONT_SMALL));
            adminSign.Add(new Chunk("Admin", FONT_NORMAL));
            adminSignCell.AddElement(adminSign);
            signatureTable.AddCell(adminSignCell);

            document.Add(signatureTable);

            // Footer với thời gian in
            document.Add(new Paragraph(" "));
            Paragraph printTime = new Paragraph($"In lúc: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", FONT_SMALL);
            printTime.Alignment = Element.ALIGN_CENTER;
            document.Add(printTime);
        }
    }
}