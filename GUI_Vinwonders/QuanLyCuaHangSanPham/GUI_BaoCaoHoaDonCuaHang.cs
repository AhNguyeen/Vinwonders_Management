using System;
using System.Data;
using System.Windows.Forms;
using Vinwonders_Management.QuanLyCuaHangSanPham;

namespace Vinwonders_Management.QuanLyCuaHangSanPham
{
    public partial class GUI_BaoCaoHoaDonCuaHang : Form
    {
        public GUI_BaoCaoHoaDonCuaHang()
        {
            InitializeComponent();
        }

        private void GUI_BaoCaoHoaDonCuaHang_Load(object sender, EventArgs e)
        {
            try
            {
                CR_HoaDonCuaHang rpt = new CR_HoaDonCuaHang();
                
                // (TODO: Nếu cần hiển thị dữ liệu thực tế, bạn sẽ lấy DataTable và gán vào qua DataSet)
                
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị báo cáo: " + ex.Message);
            }
        }
    }
}
