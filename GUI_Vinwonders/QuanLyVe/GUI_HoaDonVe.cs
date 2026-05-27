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

namespace Vinwonders_Management.QuanLyVe
{
    public partial class GUI_HoaDonVe : UserControl
    {
        // Tạo instance của BUS_HoaDonVe để lấy dữ liệu
        BUS_HoaDonVe busHoaDonVe = new BUS_HoaDonVe();

        // Sự kiện Load của Form
        public void LoadData()
        {
            dgvHoaDonVe.AutoGenerateColumns = false;
            // Gán dữ liệu vào DataGridView
            dgvHoaDonVe.DataSource = busHoaDonVe.InDanhSach();
        }
        public GUI_HoaDonVe()
        {
            InitializeComponent();
        }

        private void GUI_HoaDoVe_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            GUI_ThemHoaDonVe themHoaDonVe = new GUI_ThemHoaDonVe();
            themHoaDonVe.ShowDialog();
        }
    }
}
