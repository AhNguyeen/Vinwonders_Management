using BUS_Vinwonders;
using ET_Vinwonders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vinwonders_Management.QuanLyCuaHangSanPham
{
    public partial class GUI_ThanhToanHoaDonCuaHang : UserControl
    {
        public GUI_ThanhToanHoaDonCuaHang()
        {
            InitializeComponent();
        }

        BUS_SanPham busSanPham = new BUS_SanPham();
        BUS_KhachHang busKhachHang = new BUS_KhachHang();
        BUS_HoaDonCuaHang busHoaDonCuaHang = new BUS_HoaDonCuaHang();
        BUS_ChiTietHDCH busChiTietHDCH = new BUS_ChiTietHDCH();
        private DataTable dtGioHang;

        private void LoadDanhSachSanPham()
        {
            dgvSanPham.AutoGenerateColumns = false;
            dgvSanPham.DataSource = busSanPham.InDanhSach();
        }

        private void LoadCboKhachHang()
        {
            cboKhachHang.DataSource = busKhachHang.InDanhSach();
            cboKhachHang.DisplayMember = "SoDienThoai";
            cboKhachHang.ValueMember = "MaKhachHang";
        }

        private void InitGioHang()
        {
            dtGioHang = new DataTable();
            dtGioHang.Columns.Add("MaSanPham", typeof(string));
            dtGioHang.Columns.Add("MaCTHDCH", typeof(string));
            dtGioHang.Columns.Add("MaHDCH", typeof(string));
            dtGioHang.Columns.Add("MaCuaHang", typeof(string)); // Thêm cột MaCuaHang
            dtGioHang.Columns.Add("TenSanPham", typeof(string));
            dtGioHang.Columns.Add("SoLuong", typeof(int));
            dtGioHang.Columns.Add("GiaBan", typeof(decimal));
            dgvGioHang.AutoGenerateColumns = false;
            dgvGioHang.DataSource = dtGioHang;
        }

        private void GUI_HoaDonCuaHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachSanPham();
            LoadCboKhachHang();
            InitGioHang();
        }

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maSP = dgvSanPham.Rows[e.RowIndex].Cells["colMaSanPham"].Value?.ToString() ?? "";
                string tenSP = dgvSanPham.Rows[e.RowIndex].Cells["colTenSanPham"].Value?.ToString() ?? "";
                string maCuaHang = dgvSanPham.Rows[e.RowIndex].Cells["colMaCuaHang"].Value?.ToString() ?? ""; // Lấy MaCuaHang
                
                decimal giaBan = 0;
                var giaBanValue = dgvSanPham.Rows[e.RowIndex].Cells["colGiaBan"].Value;
                if (giaBanValue != null && giaBanValue != DBNull.Value)
                {
                    try { giaBan = Convert.ToDecimal(giaBanValue); }
                    catch { decimal.TryParse(giaBanValue.ToString(), out giaBan); }
                }

                // Kiểm tra xem sản phẩm đã có trong giỏ hàng chưa
                bool found = false;
                foreach (DataRow row in dtGioHang.Rows)
                {
                    if (row["MaSanPham"].ToString() == maSP)
                    {
                        row["SoLuong"] = Convert.ToInt32(row["SoLuong"]) + 1;
                        found = true;
                        break;
                    }
                }

                // Nếu chưa có thì thêm mới
                if (!found)
                {
                    DataRow newRow = dtGioHang.NewRow();
                    newRow["MaSanPham"] = maSP;
                    newRow["MaCuaHang"] = maCuaHang;
                    newRow["TenSanPham"] = tenSP;
                    newRow["SoLuong"] = 1;
                    newRow["GiaBan"] = giaBan;
                    dtGioHang.Rows.Add(newRow);
                }
            }
        }

        private void dgvGioHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvGioHang.Columns[e.ColumnIndex].Name == "colBtnXoa")
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa sản phẩm này khỏi giỏ hàng?", 
                    "Xác nhận xóa", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    dtGioHang.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (dtGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string maKhachHang = cboKhachHang.SelectedValue.ToString();
                string maNhanVien = "NV01"; // Để tạm, sau này lấy từ tài khoản đăng nhập
                string maHDCH = "HDCH" + DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length - 6);
                string maCuaHang = dtGioHang.Rows[0]["MaCuaHang"].ToString(); // Lấy mã cửa hàng từ sản phẩm đầu tiên
                
                decimal tongTien = 0;
                foreach (DataRow row in dtGioHang.Rows)
                {
                    tongTien += Convert.ToInt32(row["SoLuong"]) * Convert.ToDecimal(row["GiaBan"]);
                }

                // Tạo hóa đơn
                ET_Vinwonders.ET_HoaDonCuaHang hd = new ET_Vinwonders.ET_HoaDonCuaHang(
                    maHDCH, maCuaHang, maKhachHang, maNhanVien, DateTime.Now, tongTien);

                if (busHoaDonCuaHang.ThemHoaDonCuaHang(hd))
                {
                    bool isDetailSuccess = true;
                    // Thêm chi tiết hóa đơn
                    foreach (DataRow row in dtGioHang.Rows)
                    {
                        string maCTHDCH = "CTHDCH" + Guid.NewGuid().ToString().Substring(0, 4).ToUpper();
                        string maSP = row["MaSanPham"].ToString();
                        int soLuong = Convert.ToInt32(row["SoLuong"]);
                        decimal donGia = Convert.ToDecimal(row["GiaBan"]);
                        decimal thanhTien = soLuong * donGia;

                        ET_Vinwonders.ET_ChiTietHDCH cthd = new ET_Vinwonders.ET_ChiTietHDCH(
                            maCTHDCH, maHDCH, maSP, soLuong, donGia, thanhTien);

                        if (!busChiTietHDCH.ThemChiTietHDCH(cthd))
                        {
                            isDetailSuccess = false;
                            break;
                        }
                    }

                    if (isDetailSuccess)
                    {
                        MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtGioHang.Clear(); // Xóa giỏ hàng
                    }
                    else
                    {
                        MessageBox.Show("Thanh toán thất bại khi lưu chi tiết hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Tạo hóa đơn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
