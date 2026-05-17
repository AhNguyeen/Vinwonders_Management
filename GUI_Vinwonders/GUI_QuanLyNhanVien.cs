using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vinwonders_Management.QuanLyNhanVien;

namespace Vinwonders_Management
{
    public partial class GUI_QuanLyNhanVien : Form
    {
        public GUI_QuanLyNhanVien()
        {
            InitializeComponent();
        }

        // Hàm này sẽ được gọi mỗi khi bấm vào nút "Nhân Viên" hoặc khi Load Form lần đầu để hiển thị tab Nhân Viên mặc định
        private void ShowNhanVien()
        {
            // Đổi màu nút khi được chọn
            btnNhanVien.FillColor = Color.FromArgb(255, 128, 0);
            btnNhanVien.ForeColor = Color.White;

            // Reset màu các nút khác về mặc định
            btnLichLamViec.FillColor = Color.White;
            btnLichLamViec.ForeColor = Color.Black;

            // Reset màu các nút khác về mặc định
            btnCaLamViec.FillColor = Color.White;
            btnCaLamViec.ForeColor = Color.Black;

            // Xóa các control cũ đang có trong Panel (nếu có)
            pnlTabs.Controls.Clear();
            // Khởi tạo Form con
            GUI_NhanVien nhanVien = new GUI_NhanVien();
            // Bắt buộc phải có để nhúng Form vào Panel
            nhanVien.TopLevel = false;
            nhanVien.FormBorderStyle = FormBorderStyle.None;
            // QUAN TRỌNG NHẤT: Neo Form con full vào Panel để nó tự động điều chỉnh kích thước theo Panel
            nhanVien.Dock = DockStyle.Fill;
            // Thêm Form con vào Panel và hiển thị
            pnlTabs.Controls.Add(nhanVien);
            nhanVien.Show();
        }

        // Hàm này sẽ được gọi mỗi khi bấm vào nút "Lịch Làm Việc"
        private void ShowLichLamViec()
        {
            // Đổi màu nút khi được chọn
            btnLichLamViec.FillColor = Color.FromArgb(255, 128, 0);
            btnLichLamViec.ForeColor = Color.White;
            // Reset màu các nút khác về mặc định
            btnNhanVien.FillColor = Color.White;
            btnNhanVien.ForeColor = Color.Black;
            // Reset màu các nút khác về mặc định
            btnCaLamViec.FillColor = Color.White;
            btnCaLamViec.ForeColor = Color.Black;
            // Xóa các control cũ đang có trong Panel (nếu có)
            pnlTabs.Controls.Clear();
            // Khởi tạo Form con
            GUI_LichLamViec lichLamViec = new GUI_LichLamViec();
            // Bắt buộc phải có để nhúng Form vào Panel
            lichLamViec.TopLevel = false;
            lichLamViec.FormBorderStyle = FormBorderStyle.None;
            // QUAN TRỌNG NHẤT: Neo Form con full vào Panel để nó tự động điều chỉnh kích thước theo Panel
            lichLamViec.Dock = DockStyle.Fill;
            // Thêm Form con vào Panel và hiển thị
            pnlTabs.Controls.Add(lichLamViec);
            lichLamViec.Show();
        }

        // Hàm này sẽ được gọi mỗi khi bấm vào nút "Ca Làm Việc"
        private void ShowCaLamViec()
        {
            // Đổi màu nút khi được chọn
            btnCaLamViec.FillColor = Color.FromArgb(255, 128, 0);
            btnCaLamViec.ForeColor = Color.White;
            // Reset màu các nút khác về mặc định
            btnNhanVien.FillColor = Color.White;
            btnNhanVien.ForeColor = Color.Black;
            // Reset màu các nút khác về mặc định
            btnLichLamViec.FillColor = Color.White;
            btnLichLamViec.ForeColor = Color.Black;
            // Xóa các control cũ đang có trong Panel (nếu có)
            pnlTabs.Controls.Clear();
            // Khởi tạo Form con
            GUI_CaLamViec caLamViec = new GUI_CaLamViec();
            // Bắt buộc phải có để nhúng Form vào Panel
            caLamViec.TopLevel = false;
            caLamViec.FormBorderStyle = FormBorderStyle.None;
            // QUAN TRỌNG NHẤT: Neo Form con full vào Panel để nó tự động điều chỉnh kích thước theo Panel
            caLamViec.Dock = DockStyle.Fill;
            // Thêm Form con vào Panel và hiển thị
            pnlTabs.Controls.Add(caLamViec);
            caLamViec.Show();
        }

        // Hàm này sẽ được gọi mỗi khi bấm vào nút "Nhân Viên"
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            ShowNhanVien();
        }

        private void GUI_QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            ShowNhanVien();
        }

        private void btnLichLamViec_Click(object sender, EventArgs e)
        {
            ShowLichLamViec();
        }

        private void btnCaLamViec_Click(object sender, EventArgs e)
        {
            ShowCaLamViec();
        }
    }
}
