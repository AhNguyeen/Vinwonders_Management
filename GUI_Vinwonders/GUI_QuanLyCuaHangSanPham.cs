using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vinwonders_Management.QuanLyCuaHangSanPham;
using Vinwonders_Management.QuanLyTroChoiVaShow;

namespace Vinwonders_Management
{
    public partial class GUI_QuanLyCuaHangSanPham : Form
    {
        public GUI_QuanLyCuaHangSanPham()
        {
            InitializeComponent();
        }

        // Hàm này sẽ được gọi mỗi khi bấm vào nút "Cửa Hàng" hoặc khi Load Form lần đầu để hiển thị tab Cửa Hàng mặc định
        private void ShowTabCuaHang()
        {
            // Đổi màu nút khi được chọn
            btnCuaHang.FillColor = Color.FromArgb(255, 128, 0);
            btnCuaHang.ForeColor = Color.White;
            // Reset màu các nút khác về mặc định
            btnHoaDonCH.FillColor = Color.White;
            btnHoaDonCH.ForeColor = Color.Black;
            btnSanPham.FillColor = Color.White;
            btnSanPham.ForeColor = Color.Black;
            // Xóa các control cũ đang có trong Panel (nếu có)
            pnlTabs.Controls.Clear();
            // Khởi tạo Form con
            GUI_CuaHang cuaHang = new GUI_CuaHang();    
            // Bắt buộc phải có để nhúng Form vào Panel
            cuaHang.TopLevel = false;
            cuaHang.FormBorderStyle = FormBorderStyle.None;
            // QUAN TRỌNG NHẤT: Neo Form con full vào Panel để nó tự động điều chỉnh kích thước theo Panel
            cuaHang.Dock = DockStyle.Fill;
            // Thêm Form con vào Panel và hiển thị
            pnlTabs.Controls.Add(cuaHang);
            cuaHang.Show();
        }

        // Ham này sẽ được gọi mỗi khi bấm vào nút "Hóa Đơn Cửa Hàng"
        private void ShowTabHoaDonCuaHang()
        {
            // Đổi màu nút khi được chọn
            btnHoaDonCH.FillColor = Color.FromArgb(255, 128, 0);
            btnHoaDonCH.ForeColor = Color.White;
            // Reset màu các nút khác về mặc định
            btnCuaHang.FillColor = Color.White;
            btnCuaHang.ForeColor = Color.Black;
            btnSanPham.FillColor = Color.White;
            btnSanPham.ForeColor = Color.Black;
            // Xóa các control cũ đang có trong Panel (nếu có)
            pnlTabs.Controls.Clear();
            // Khởi tạo Form con
            GUI_HoaDonCuaHang hoaDonCH = new GUI_HoaDonCuaHang();
            // Bắt buộc phải có để nhúng Form vào Panel
            hoaDonCH.TopLevel = false;
            hoaDonCH.FormBorderStyle = FormBorderStyle.None;
            // QUAN TRỌNG NHẤT: Neo Form con full vào Panel để nó tự động điều chỉnh kích thước theo Panel
            hoaDonCH.Dock = DockStyle.Fill;
            // Thêm Form con vào Panel và hiển thị
            pnlTabs.Controls.Add(hoaDonCH);
            hoaDonCH.Show();
        }

        // Hàm này sẽ được gọi mỗi khi bấm vào nút "Sản Phẩm"
        private void ShowTabSanPham()
        {
            // Đổi màu nút khi được chọn
            btnSanPham.FillColor = Color.FromArgb(255, 128, 0);
            btnSanPham.ForeColor = Color.White;
            // Reset màu các nút khác về mặc định
            btnCuaHang.FillColor = Color.White;
            btnCuaHang.ForeColor = Color.Black;
            btnHoaDonCH.FillColor = Color.White;
            btnHoaDonCH.ForeColor = Color.Black;
            btnSanPham.FillColor = Color.White;
            btnSanPham.ForeColor = Color.Black;
            // Xóa các control cũ đang có trong Panel (nếu có)
            pnlTabs.Controls.Clear();
            // Khởi tạo Form con
            GUI_SanPham sanPham = new GUI_SanPham();
            // Bắt buộc phải có để nhúng Form vào Panel
            sanPham.TopLevel = false;
            sanPham.FormBorderStyle = FormBorderStyle.None;
            // QUAN TRỌNG NHẤT: Neo Form con full vào Panel để nó tự động điều chỉnh kích thước theo Panel
            sanPham.Dock = DockStyle.Fill;
            // Thêm Form con vào Panel và hiển thị
            pnlTabs.Controls.Add(sanPham);
            sanPham.Show();
        }

        private void btnCuaHang_Click(object sender, EventArgs e)
        {
            ShowTabCuaHang();
        }

        private void GUI_QuanLyCuaHangSanPham_Load(object sender, EventArgs e)
        {
            ShowTabCuaHang();
        }

        private void btnHoaDonCH_Click(object sender, EventArgs e)
        {
            ShowTabHoaDonCuaHang();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            ShowTabSanPham();
        }
    }
}
