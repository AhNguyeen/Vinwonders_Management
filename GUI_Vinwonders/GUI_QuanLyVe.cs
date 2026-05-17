using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vinwonders_Management
{
    public partial class GUI_QuanLyVe : Form
    {
        public GUI_QuanLyVe()
        {
            InitializeComponent();
        }

        private void ShowHoaDonVe()
        {
            // Đổi màu nút khi được chọn
            btnHoaDonVe.FillColor = Color.FromArgb(255, 128, 0);
            btnHoaDonVe.ForeColor = Color.White;

            btnLoaiVe.FillColor = Color.White;
            btnLoaiVe.ForeColor = Color.Black;

            // Xóa các control cũ đang có trong Panel (nếu có)
            pnlTabs.Controls.Clear();

            // Khởi tạo Form con
            GUI_HoaDonVe hoaDonVe = new GUI_HoaDonVe();
            // Bắt buộc phải có để nhúng Form vào Panel
            hoaDonVe.TopLevel = false;
            hoaDonVe.FormBorderStyle = FormBorderStyle.None;

            // QUAN TRỌNG NHẤT: Neo Form con full vào Panel để nó tự động điều chỉnh kích thước theo Panel
            hoaDonVe.Dock = DockStyle.Fill;

            // Thêm Form con vào Panel và hiển thị
            pnlTabs.Controls.Add(hoaDonVe);
            hoaDonVe.Show();
        }

        private void ShowLoaiVe()
        {
            // Đổi màu nút khi được chọn
            btnLoaiVe.FillColor = Color.FromArgb(255, 128, 0);
            btnLoaiVe.ForeColor = Color.White;

            btnHoaDonVe.FillColor = Color.White;
            btnHoaDonVe.ForeColor = Color.Black;
            // Xóa các control cũ đang có trong Panel (nếu có)
            pnlTabs.Controls.Clear();

            // Khởi tạo Form con
            GUI_LoaiVe loaiVe = new GUI_LoaiVe();
            // Bắt buộc phải có để nhúng Form vào Panel
            loaiVe.TopLevel = false;
            loaiVe.FormBorderStyle = FormBorderStyle.None;
            // QUAN TRỌNG NHẤT: Neo Form con full vào Panel để nó tự động điều chỉnh kích thước theo Panel
            loaiVe.Dock = DockStyle.Fill;

            // Thêm Form con vào Panel và hiển thị
            pnlTabs.Controls.Add(loaiVe);
            loaiVe.Show();
        }

        private void GUI_QuanLyVe_Load(object sender, EventArgs e)
        {
            ShowHoaDonVe();
        }

        private void btnHoaDonVe_Click(object sender, EventArgs e)
        {
            ShowHoaDonVe();
        }

        private void btnLoaiVe_Click(object sender, EventArgs e)
        {
            ShowLoaiVe();
        }
    }
}
