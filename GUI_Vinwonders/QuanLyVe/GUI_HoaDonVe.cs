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

namespace Vinwonders_Management
{
    public partial class GUI_HoaDonVe : Form
    {
        public GUI_HoaDonVe()
        {
            InitializeComponent();
        }

        // Tạo instance của BUS_HoaDonVe để lấy dữ liệu
        BUS_HoaDonVe busHoaDonVe = new BUS_HoaDonVe();

        // Sự kiện Load của Form
        public void LoadData()
        {
            // Gán dữ liệu vào DataGridView
            dgvHoaDonVe.DataSource = busHoaDonVe.InDanhSach();
        }

        private void GUI_HoaDonVe_Load(object sender, EventArgs e)
        {
            LoadData();
        }

    }
}
