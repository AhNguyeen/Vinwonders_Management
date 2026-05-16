using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vinwonders_Management.QuanLyTroChoiVaShow;

namespace Vinwonders_Management
{
    public partial class GUI_QuanLyTroChoi : Form
    {
        public GUI_QuanLyTroChoi()
        {
            InitializeComponent();
        }

        // Hàm này sẽ được gọi mỗi khi bấm vào nút "Trò Chơi" hoặc khi Load Form lần đầu để hiển thị tab Trò Chơi mặc định
        private void ShowTabTroChoi()
        {
            // Đổi màu nút khi được chọn
            btnTroChoi.FillColor = Color.FromArgb(255, 128, 0);
            btnTroChoi.ForeColor = Color.White;
            // Reset màu các nút khác về mặc định
            btnKhuVuc.FillColor = Color.White;
            btnKhuVuc.ForeColor = Color.Black;
            // Xóa các control cũ đang có trong Panel (nếu có)
            pnlTabs.Controls.Clear();
            // Khởi tạo Form con
            GUI_TroChoi troChoi = new GUI_TroChoi();
            // Bắt buộc phải có để nhúng Form vào Panel
            troChoi.TopLevel = false;
            troChoi.FormBorderStyle = FormBorderStyle.None;
            // QUAN TRỌNG NHẤT: Neo Form con full vào Panel để nó tự động điều chỉnh kích thước theo Panel
            troChoi.Dock = DockStyle.Fill;
            // Thêm Form con vào Panel và hiển thị
            pnlTabs.Controls.Add(troChoi);
            troChoi.Show();
        }

        // Hàm này sẽ được gọi mỗi khi bấm vào nút "Khu Vực"
        private void ShowTabKhuVuc()
        {
            // Đổi màu nút khi được chọn
            btnKhuVuc.FillColor = Color.FromArgb(255, 128, 0);
            btnKhuVuc.ForeColor = Color.White;
            // Reset màu các nút khác về mặc định
            btnTroChoi.FillColor = Color.White;
            btnTroChoi.ForeColor = Color.Black;
            // Xóa các control cũ đang có trong Panel (nếu có)
            pnlTabs.Controls.Clear();
            // Khởi tạo Form con
            GUI_KhuVuc khuVuc = new GUI_KhuVuc();
            // Bắt buộc phải có để nhúng Form vào Panel
            khuVuc.TopLevel = false;
            khuVuc.FormBorderStyle = FormBorderStyle.None;
            // QUAN TRỌNG NHẤT: Neo Form con full vào Panel để nó tự động điều chỉnh kích thước theo Panel
            khuVuc.Dock = DockStyle.Fill;
            // Thêm Form con vào Panel và hiển thị
            pnlTabs.Controls.Add(khuVuc);
            khuVuc.Show();
        }

        private void btnTroChoi_Click(object sender, EventArgs e)
        {
            ShowTabTroChoi();
        }

        private void GUI_QuanLyTroChoiVaShow_Load(object sender, EventArgs e)
        {
            ShowTabTroChoi();
        }

        private void btnKhuVuc_Click(object sender, EventArgs e)
        {
            ShowTabKhuVuc();
        }
    }
}
