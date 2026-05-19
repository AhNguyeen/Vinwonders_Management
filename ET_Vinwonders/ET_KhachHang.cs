using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_Vinwonders
{
    internal class ET_KhachHang
    {
        private string MaKhachHang;
        private string MaDangKy;
        private string MaHang;
        private string HoTen;
        private string LoaiKhach;
        private DateTime NgaySinh;
        private string DiaChi;
        private string SoDienThoai;
        private string Email;
        private int DiemTichLuy;

        public ET_KhachHang(string maKhachHang, string maDangKy, string maHang, string hoTen, string loaiKhach, DateTime ngaySinh, string diaChi, string soDienThoai, string email, int diemTichLuy)
        {
            MaKhachHang = maKhachHang;
            MaDangKy = maDangKy;
            MaHang = maHang;
            HoTen = hoTen;
            LoaiKhach = loaiKhach;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            Email = email;
            DiemTichLuy = diemTichLuy;
        }
        public ET_KhachHang() { }
        public string MaKhachHang1 { get => MaKhachHang; set => MaKhachHang = value; }
        public string MaDangKy1 { get => MaDangKy; set => MaDangKy = value; }
        public string MaHang1 { get => MaHang; set => MaHang = value; }
        public string HoTen1 { get => HoTen; set => HoTen = value; }
        public string LoaiKhach1 { get => LoaiKhach; set => LoaiKhach = value; }
        public DateTime NgaySinh1 { get => NgaySinh; set => NgaySinh = value; }
        public string DiaChi1 { get => DiaChi; set => DiaChi = value; }
        public string SoDienThoai1 { get => SoDienThoai; set => SoDienThoai = value; }
        public string Email1 { get => Email; set => Email = value; }
        public int DiemTichLuy1 { get => DiemTichLuy; set => DiemTichLuy = value; }
    }
}
