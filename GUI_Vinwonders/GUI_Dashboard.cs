using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BUS_Vinwonders;
using Guna.Charts.WinForms;

namespace Vinwonders_Management
{
    public partial class GUI_Dashboard : UserControl
    {
        BUS_Dashboard busDashboard = new BUS_Dashboard();

        public GUI_Dashboard()
        {
            InitializeComponent();
        }

        private void GUI_Dashboard_Load(object sender, EventArgs e)
        {
            // Khởi tạo ComboBox chọn tháng
            InitComboBox();

            // Load 4 thẻ tổng quan
            LoadStats();

            // Load danh sách hóa đơn gần đây
            LoadRecentInvoices();

            // Mặc định chọn tháng hiện tại
            int currentMonth = DateTime.Now.Month;
            cboCacThang.SelectedValue = currentMonth;
        }

        private void InitComboBox()
        {
            DataTable dtMonths = new DataTable();
            dtMonths.Columns.Add("MonthId", typeof(int));
            dtMonths.Columns.Add("MonthName", typeof(string));

            for (int i = 1; i <= 12; i++)
            {
                dtMonths.Rows.Add(i, "Tháng " + i);
            }

            cboCacThang.DataSource = dtMonths;
            cboCacThang.DisplayMember = "MonthName";
            cboCacThang.ValueMember = "MonthId";
        }

        private void LoadStats()
        {
            try
            {
                DataTable dtStats = busDashboard.GetStats();
                if (dtStats.Rows.Count > 0)
                {
                    DataRow row = dtStats.Rows[0];

                    // lblTongVeBan, lblKhachHang, lblDanhThu, lblDoanhThuCuaHang
                    lblTongVeBan.Text = Convert.ToDecimal(row["TongVeBan"]).ToString("N0");
                    lblKhachHang.Text = Convert.ToDecimal(row["KhachHangMoi"]).ToString("N0");

                    // Rút gọn tiền tỉ lệ triệu (M đ)
                    decimal doanhThuVe = Convert.ToDecimal(row["DoanhThuVe"]);
                    decimal doanhThuCH = Convert.ToDecimal(row["DoanhThuCuaHang"]);

                    if (doanhThuVe >= 1000000)
                        lblDanhThu.Text = string.Format("{0:0.#}M đ", doanhThuVe / 1000000);
                    else
                        lblDanhThu.Text = doanhThuVe.ToString("N0") + " đ";

                    if (doanhThuCH >= 1000000)
                        lblDoanhThuCuaHang.Text = string.Format("{0:0.#}M đ", doanhThuCH / 1000000);
                    else
                        lblDoanhThuCuaHang.Text = doanhThuCH.ToString("N0") + " đ";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi load stats: " + ex.Message);
            }
        }

        private void LoadRecentInvoices()
        {
            try
            {
                DataTable dtInvoices = busDashboard.GetRecentInvoices();
                dgvHoaDonGanDay.DataSource = dtInvoices;

                // Ẩn cột tự sinh nếu có
                dgvHoaDonGanDay.AutoGenerateColumns = false;

                // Ánh xạ cột (đảm bảo DataPropertyName khớp với tên cột trả về từ SP)
                if (dgvHoaDonGanDay.Columns.Contains("colMaHD"))
                    dgvHoaDonGanDay.Columns["colMaHD"].DataPropertyName = "MaHD";
                if (dgvHoaDonGanDay.Columns.Contains("colKhachHang"))
                    dgvHoaDonGanDay.Columns["colKhachHang"].DataPropertyName = "KhachHang";
                if (dgvHoaDonGanDay.Columns.Contains("colSoVe"))
                    dgvHoaDonGanDay.Columns["colSoVe"].DataPropertyName = "SoVe";
                if (dgvHoaDonGanDay.Columns.Contains("colTongTien"))
                {
                    dgvHoaDonGanDay.Columns["colTongTien"].DataPropertyName = "TongTien";
                    dgvHoaDonGanDay.Columns["colTongTien"].DefaultCellStyle.Format = "N0";
                }
                if (dgvHoaDonGanDay.Columns.Contains("colTrangThai"))
                    dgvHoaDonGanDay.Columns["colTrangThai"].DataPropertyName = "TrangThai";

            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi load hóa đơn gần đây: " + ex.Message);
            }
        }

        private void cboCacThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCacThang.SelectedValue != null && cboCacThang.SelectedValue is int thang)
            {
                int nam = DateTime.Now.Year;
                LoadLineChart(thang, nam);
                LoadDonutChart(thang, nam);
            }
        }

        private void LoadLineChart(int thang, int nam)
        {
            try
            {
                DataTable dtLine = busDashboard.GetRevenueByMonth(thang, nam);
                
                chrtTheoThang.Datasets.Clear();
                var dataset = new GunaSplineDataset();
                dataset.Label = "Doanh Thu";

                foreach (DataRow row in dtLine.Rows)
                {
                    string dayLabel = row["Ngay"].ToString();
                    double value = Convert.ToDouble(row["DoanhThu"]);
                    dataset.DataPoints.Add(dayLabel, value);
                }

                chrtTheoThang.Datasets.Add(dataset);
                chrtTheoThang.Update();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi vẽ line chart: " + ex.Message);
            }
        }

        private void LoadDonutChart(int thang, int nam)
        {
            try
            {
                DataTable dtDonut = busDashboard.GetTicketTypes(thang, nam);

                chrtLoaiVe.Datasets.Clear();
                var dataset = new GunaDoughnutDataset();
                dataset.Label = "Loại Vé Bán Ra";

                foreach (DataRow row in dtDonut.Rows)
                {
                    string label = row["TenLoaiVe"].ToString();
                    double value = Convert.ToDouble(row["SoLuong"]);
                    dataset.DataPoints.Add(label, value);
                }

                chrtLoaiVe.Datasets.Add(dataset);
                chrtLoaiVe.Update();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi vẽ donut chart: " + ex.Message);
            }
        }
    }
}
