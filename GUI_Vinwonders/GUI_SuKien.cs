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

namespace Vinwonders_Management
{
    public partial class GUI_SuKien : UserControl
    {
        BUS_SuKien busSuKien = new BUS_SuKien();
        BUS_HoaDonVe busHoaDonVe = new BUS_HoaDonVe();
        DataTable dtSuKien;

        public GUI_SuKien()
        {
            InitializeComponent();
            this.Load += GUI_SuKien_Load;
            
            // Đăng ký sự kiện tìm kiếm
            if (txtTimKiem != null)
            {
                txtTimKiem.TextChanged += Guna2TextBox1_TextChanged;
            }
        }

        private void GUI_SuKien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dtSuKien = busSuKien.InDanhSach();
                dgvSuKien.DataSource = dtSuKien;

                // Định dạng lại các cột hiển thị
                if (dgvSuKien.Columns.Count > 0)
                {
                    if (dgvSuKien.Columns.Contains("MaSuKien"))
                    {
                        dgvSuKien.Columns["MaSuKien"].HeaderText = "Mã Sự Kiện";
                        dgvSuKien.Columns["MaSuKien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dgvSuKien.Columns["MaSuKien"].Width = 100;
                    }
                    if (dgvSuKien.Columns.Contains("TenSuKien"))
                        dgvSuKien.Columns["TenSuKien"].HeaderText = "Tên Sự Kiện";
                    
                    if (dgvSuKien.Columns.Contains("NgayBatDau"))
                    {
                        dgvSuKien.Columns["NgayBatDau"].HeaderText = "Bắt Đầu";
                        dgvSuKien.Columns["NgayBatDau"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }

                    if (dgvSuKien.Columns.Contains("NgayKetThuc"))
                    {
                        dgvSuKien.Columns["NgayKetThuc"].HeaderText = "Kết Thúc";
                        dgvSuKien.Columns["NgayKetThuc"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }

                    if (dgvSuKien.Columns.Contains("MaGiamGia"))
                        dgvSuKien.Columns["MaGiamGia"].HeaderText = "Mã Khuyến Mãi";
                    
                    if (dgvSuKien.Columns.Contains("PhanTramGiam"))
                    {
                        dgvSuKien.Columns["PhanTramGiam"].HeaderText = "% Giảm";
                        dgvSuKien.Columns["PhanTramGiam"].DefaultCellStyle.Format = "0.##'%'";
                    }
                    
                    if (dgvSuKien.Columns.Contains("GiamToiDa"))
                    {
                        dgvSuKien.Columns["GiamToiDa"].HeaderText = "Giảm Tối Đa";
                        dgvSuKien.Columns["GiamToiDa"].DefaultCellStyle.Format = "N0";
                    }
                    
                    if (dgvSuKien.Columns.Contains("MoTa"))
                        dgvSuKien.Columns["MoTa"].Visible = false; // Ẩn mô tả cho gọn
                        
                    if (dgvSuKien.Columns.Contains("TrangThai"))
                    {
                        dgvSuKien.Columns["TrangThai"].HeaderText = "Trạng Thái";
                        dgvSuKien.Columns["TrangThai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dgvSuKien.Columns["TrangThai"].Width = 100;
                    }
                }

                // Cập nhật các Lable thống kê
                CalculateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sự kiện: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateStatistics()
        {
            if (dtSuKien == null) return;

            int tongSuKien = dtSuKien.Rows.Count;
            int dangDienRa = 0;
            int daKetThuc = 0;

            DateTime now = DateTime.Now;
            foreach (DataRow row in dtSuKien.Rows)
            {
                DateTime ngayKetThuc = Convert.ToDateTime(row["NgayKetThuc"]);
                bool trangThai = Convert.ToBoolean(row["TrangThai"]);

                if (trangThai && ngayKetThuc >= now)
                {
                    dangDienRa++;
                }
                else
                {
                    daKetThuc++;
                }
            }

            if (lblTongSuKien != null) lblTongSuKien.Text = tongSuKien.ToString("N0");
            if (lblDangDienRa != null) lblDangDienRa.Text = dangDienRa.ToString("N0");
            if (lblDaKetThuc != null) lblDaKetThuc.Text = daKetThuc.ToString("N0");

            try
            {
                DataTable dtHoaDon = busHoaDonVe.InDanhSach();
                int luotSuDung = 0;
                if (dtHoaDon != null)
                {
                    foreach (DataRow r in dtHoaDon.Rows)
                    {
                        if (r.Table.Columns.Contains("MaSuKien") && r["MaSuKien"] != DBNull.Value && !string.IsNullOrWhiteSpace(r["MaSuKien"].ToString()))
                        {
                            luotSuDung++;
                        }
                    }
                }
                if (lblLuotSuDung != null) lblLuotSuDung.Text = luotSuDung.ToString("N0");
            }
            catch
            {
                if (lblLuotSuDung != null) lblLuotSuDung.Text = "0";
            }
        }

        private void Guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (dtSuKien == null) return;
            string keyword = txtTimKiem.Text.Trim();
            
            try
            {
                DataView dv = dtSuKien.DefaultView;
                if (!string.IsNullOrEmpty(keyword))
                {
                    // Lọc theo Tên sự kiện hoặc Mã giảm giá
                    dv.RowFilter = string.Format("TenSuKien LIKE '%{0}%' OR MaGiamGia LIKE '%{0}%'", keyword.Replace("'", "''"));
                }
                else
                {
                    dv.RowFilter = "";
                }
                dgvSuKien.DataSource = dv.ToTable();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void btnTaoSuKien_Click(object sender, EventArgs e)
        {
            QuanLySuKien.GUI_ThemSuKien themSuKienForm = new QuanLySuKien.GUI_ThemSuKien();
            themSuKienForm.ShowDialog();
            
            // Reload dữ liệu sau khi tắt form Thêm Sự Kiện để cập nhật danh sách mới nhất
            LoadData();
        }
    }
}
