using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_Vinwonders;

namespace Vinwonders_Management.QuanLyBaoTri
{
    public partial class GUI_InBaoCaoBaoTri : Form
    {
        BUS_BaoTriTroChoi busBaoTri = new BUS_BaoTriTroChoi();
        DateTime tuNgay;
        DateTime denNgay;

        public GUI_InBaoCaoBaoTri(DateTime tuNgay, DateTime denNgay)
        {
            InitializeComponent();
            this.tuNgay = tuNgay;
            this.denNgay = denNgay;
        }

        private void GUI_InBaoCaoBaoTri_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = busBaoTri.InDanhSachTheoNgay(tuNgay, denNgay);
                
                // Sau khi bạn tạo file CR_BaoCaoChiPhiBaoTri.rpt bằng giao diện thiết kế:
                // Uncomment và chỉnh sửa đoạn code dưới đây để load báo cáo.

                /*
                CR_BaoCaoChiPhiBaoTri report = new CR_BaoCaoChiPhiBaoTri();
                report.SetDataSource(dt);
                // Truyền tham số thời gian cho report nếu bạn có tạo Parameter Field "TuNgay", "DenNgay"
                // report.SetParameterValue("TuNgay", tuNgay.ToString("dd/MM/yyyy"));
                // report.SetParameterValue("DenNgay", denNgay.ToString("dd/MM/yyyy"));
                
                crvBaoTri.ReportSource = report;
                crvBaoTri.Refresh();
                */

                MessageBox.Show("Dữ liệu đã được lấy thành công (" + dt.Rows.Count + " dòng). Vui lòng thiết kế file Crystal Report (CR_BaoCaoChiPhiBaoTri.rpt) và bỏ comment code để hiển thị.", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
