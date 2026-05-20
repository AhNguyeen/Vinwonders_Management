using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vinwonders_Management.QuanLyKhachHang;

namespace Vinwonders_Management
{
    public partial class GUI_QuanLyKhachHang : UserControl
    {
        public GUI_QuanLyKhachHang()
        {
            InitializeComponent();
        }
        private void ShowKhachHang()
        {
            // Đổi màu nút khi được chọn
            btnKhachHang.FillColor = Color.FromArgb(255, 128, 0);
            btnKhachHang.ForeColor = Color.White;

            btnHangThanhVien.FillColor = Color.White;
            btnHangThanhVien.ForeColor = Color.Black;
            // Xóa các control cũ đang có trong Panel (nếu có)
            pnlTabs.Controls.Clear();

            // Khởi tạo Form con
            GUI_KhachHang khachHang = new GUI_KhachHang();
            // Bắt buộc phải có để nhúng Form vào Panel
            khachHang.TopLevel = false;
            khachHang.FormBorderStyle = FormBorderStyle.None;
            // QUAN TRỌNG NHẤT: Neo Form con full vào Panel để nó tự động điều chỉnh kích thước theo Panel
            khachHang.Dock = DockStyle.Fill;

            // Thêm Form con vào Panel và hiển thị
            pnlTabs.Controls.Add(khachHang);
            khachHang.Show();
        }
        private void ShowHangThanhVien()
        {
            // Đổi màu nút khi được chọn
            btnHangThanhVien.FillColor = Color.FromArgb(255, 128, 0);
            btnHangThanhVien.ForeColor = Color.White;

            btnKhachHang.FillColor = Color.White;
            btnKhachHang.ForeColor = Color.Black;
            // Xóa các control cũ đang có trong Panel (nếu có)
            pnlTabs.Controls.Clear();

            // Khởi tạo Form con
            GUI_HangThanhVien hangThanhVien = new GUI_HangThanhVien();
            // Bắt buộc phải có để nhúng Form vào Panel
            hangThanhVien.TopLevel = false;
            hangThanhVien.FormBorderStyle = FormBorderStyle.None;
            // QUAN TRỌNG NHẤT: Neo Form con full vào Panel để nó tự động điều chỉnh kích thước theo Panel
            hangThanhVien.Dock = DockStyle.Fill;

            // Thêm Form con vào Panel và hiển thị
            pnlTabs.Controls.Add(hangThanhVien);
            hangThanhVien.Show();
        }
        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            ShowKhachHang();
        }

        private void GUI_QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            ShowKhachHang();
        }

        private void btnHangThanhVien_Click(object sender, EventArgs e)
        {
            ShowHangThanhVien();
        }
    }
}
