using System;

namespace ET_Vinwonders
{
    public class ET_HoaDonCuaHang
    {
        private string maHDCH;
        private string maKhachHang;
        private string maNhanVien;
        private DateTime ngayMua;
        private decimal tongTien;
        private string phuongThucThanhToan;
        private string trangThai;

        public ET_HoaDonCuaHang(string maHDCH, string maKhachHang, string maNhanVien, DateTime ngayMua, decimal tongTien, string phuongThucThanhToan, string trangThai)
        {
            this.maHDCH = maHDCH;
            this.maKhachHang = maKhachHang;
            this.maNhanVien = maNhanVien;
            this.ngayMua = ngayMua;
            this.tongTien = tongTien;
            this.phuongThucThanhToan = phuongThucThanhToan;
            this.trangThai = trangThai;
        }

        public ET_HoaDonCuaHang() { }

        public string MaHDCH { get => maHDCH; set => maHDCH = value; }
        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public DateTime NgayMua { get => ngayMua; set => ngayMua = value; }
        public decimal TongTien { get => tongTien; set => tongTien = value; }
        public string PhuongThucThanhToan { get => phuongThucThanhToan; set => phuongThucThanhToan = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
