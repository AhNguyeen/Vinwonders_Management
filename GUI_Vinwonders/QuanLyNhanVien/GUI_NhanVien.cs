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

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvNhanVien.Columns[e.ColumnIndex].Name == "colSuaNhanVien")
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                
                ET_Vinwonders.ET_NhanVien nv = new ET_Vinwonders.ET_NhanVien();
                nv.MaNhanVien = row.Cells["colMaNhanVien"].Value?.ToString() ?? "";
                nv.MaTaiKhoan = row.Cells["colMaTaiKhoan"].Value?.ToString() ?? "";
                nv.HoTen = row.Cells["colHoTen"].Value?.ToString() ?? "";
                nv.GioTinh = row.Cells["colGioTinh"].Value?.ToString() ?? "";
                nv.NgaySinh = Convert.ToDateTime(row.Cells["colNgaySinh"].Value);
                nv.SoDienThoai = row.Cells["colSoDienThoai"].Value?.ToString() ?? "";
                nv.Email = row.Cells["colEmail"].Value?.ToString() ?? "";
                nv.CCCD = row.Cells["colCCCD"].Value?.ToString() ?? "";
                nv.ViTri = row.Cells["colViTri"].Value?.ToString() ?? "";
                nv.Luong = Convert.ToDecimal(row.Cells["colLuong"].Value);
                nv.NgayVaoLam = Convert.ToDateTime(row.Cells["colNgayVaoLam"].Value);

                GUI_CapNhatNhanVien capNhatNhanVien = new GUI_CapNhatNhanVien(nv);
                capNhatNhanVien.ShowDialog();
                LoadDanhSach();
            }
        }
    }
}
