using BUS_Vinwonders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vinwonders_Management.QuanLyNhanVien
{
    public partial class GUI_NhanVien : UserControl
    {
        public GUI_NhanVien()
        {
            InitializeComponent();
        }

        BUS_NhanVien BUS_NhanVien = new BUS_NhanVien();

        public void LoadDanhSach()
        {
            dgvNhanVien.DataSource = BUS_NhanVien.InDanhSach();
        }

        private void GUI_NhanVien_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            GUI_ThemNhanVien themNhanVien = new GUI_ThemNhanVien();
            themNhanVien.ShowDialog();
            
            // Tải lại danh sách sau khi form thêm nhân viên đóng
            LoadDanhSach();
        }
    }
}
