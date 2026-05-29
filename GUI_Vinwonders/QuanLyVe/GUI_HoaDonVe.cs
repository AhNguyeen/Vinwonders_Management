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
        BUS_KhachHang busKhachHang = new BUS_KhachHang();
        BUS_HangThanhVien busHangThanhVien = new BUS_HangThanhVien();
        BUS_SuKien busSuKien = new BUS_SuKien();

        // Sự kiện Load của Form
        public void LoadData()
        {

        }
        public GUI_HoaDonVe()
        {
            InitializeComponent();
            // Khởi tạo trạng thái ban đầu cho các label
            ResetThongTinThanhVien();
            ResetThongTinSuKien();
        }

        private void GUI_HoaDoVe_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        #region Xử lý Checkbox Khách Vãng Lai

        /// <summary>
        /// Khi tick "Khách vãng lai": disable textbox tên/SDT, xóa nội dung, reset thông tin thành viên.
        /// Khi bỏ tick: enable lại textbox tên/SDT.
        /// </summary>
        private void chkBoxKhachVangLai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxKhachVangLai.Checked)
            {
                // Khách vãng lai => không cho nhập tên hay số điện thoại
                txtTenHoacSDT.Text = "";
                txtTenHoacSDT.Enabled = false;

                // Reset thông tin thành viên
                ResetThongTinThanhVien();
            }
            else
            {
                // Cho phép nhập lại
                txtTenHoacSDT.Enabled = true;
                txtTenHoacSDT.Focus();
            }
        }

        #endregion

        #region Xử lý tìm kiếm Khách hàng & Hiển thị Hạng Thành Viên

        /// <summary>
        /// Khi rời khỏi textbox Tên/SDT: tìm khách hàng theo tên hoặc SDT.
        /// Nếu tìm thấy và khách hàng có hạng thành viên => hiển thị tên hạng và % giảm giá.
        /// </summary>
        private void txtTenHoacSDT_Leave(object sender, EventArgs e)
        {
            string tuKhoa = txtTenHoacSDT.Text.Trim();

            // Nếu textbox trống hoặc đang là khách vãng lai thì reset
            if (string.IsNullOrEmpty(tuKhoa) || chkBoxKhachVangLai.Checked)
            {
                ResetThongTinThanhVien();
                return;
            }

            try
            {
                // Tìm khách hàng theo tên hoặc SDT
                DataTable dtKhachHang = busKhachHang.TimKhachHang(tuKhoa);

                if (dtKhachHang != null && dtKhachHang.Rows.Count > 0)
                {
                    // Lọc kết quả: tìm chính xác theo Tên hoặc SĐT
                    DataRow[] ketQua = dtKhachHang.Select(
                        "HoTen LIKE '%" + tuKhoa.Replace("'", "''") + "%' OR SoDienThoai = '" + tuKhoa.Replace("'", "''") + "'");

                    if (ketQua.Length > 0)
                    {
                        DataRow row = ketQua[0];
                        string maHang = row["MaHang"] != DBNull.Value ? row["MaHang"].ToString() : "";

                        if (!string.IsNullOrEmpty(maHang))
                        {
                            // Tìm thông tin hạng thành viên
                            DataTable dtHang = busHangThanhVien.InDanhSach();

                            if (dtHang != null && dtHang.Rows.Count > 0)
                            {
                                DataRow[] hangRows = dtHang.Select("MaHang = '" + maHang.Replace("'", "''") + "'");

                                if (hangRows.Length > 0)
                                {
                                    string tenHang = hangRows[0]["TenHang"].ToString();
                                    decimal tiLeGiam = Convert.ToDecimal(hangRows[0]["TiLeGiamGia"]);

                                    // Hiển thị thông tin hạng thành viên
                                    lblHangThanhVien.Text = tenHang;
                                    lblGiamGiaThanhVien.Text = tiLeGiam.ToString("0.##") + "%";
                                    return;
                                }
                            }
                        }

                        // Khách hàng tìm thấy nhưng không có hạng thành viên
                        lblHangThanhVien.Text = "Chưa có hạng";
                        lblGiamGiaThanhVien.Text = "0%";
                    }
                    else
                    {
                        // Không tìm thấy khách hàng khớp
                        ResetThongTinThanhVien();
                    }
                }
                else
                {
                    ResetThongTinThanhVien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm khách hàng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetThongTinThanhVien();
            }
        }

        /// <summary>
        /// Reset các label thông tin thành viên về trạng thái mặc định.
        /// </summary>
        private void ResetThongTinThanhVien()
        {
            lblHangThanhVien.Text = "---";
            lblGiamGiaThanhVien.Text = "---";
        }

        #endregion

        #region Xử lý tìm kiếm Sự Kiện Khuyến Mãi

        /// <summary>
        /// Khi rời khỏi textbox Mã sự kiện: kiểm tra mã sự kiện.
        /// Nếu đúng => hiển thị tên sự kiện, giảm giá tối đa, ngày bắt đầu, ngày kết thúc.
        /// </summary>
        private void txtMaSuKien_Leave(object sender, EventArgs e)
        {
            string maSK = txtMaSuKien.Text.Trim();

            // Nếu textbox trống thì reset
            if (string.IsNullOrEmpty(maSK))
            {
                ResetThongTinSuKien();
                return;
            }

            try
            {
                // Lấy danh sách sự kiện
                DataTable dtSuKien = busSuKien.InDanhSach();

                if (dtSuKien != null && dtSuKien.Rows.Count > 0)
                {
                    // Tìm sự kiện theo mã hoặc mã giảm giá
                    DataRow[] ketQua = dtSuKien.Select(
                        "MaSuKien = '" + maSK.Replace("'", "''") + "' OR MaGiamGia = '" + maSK.Replace("'", "''") + "'");

                    if (ketQua.Length > 0)
                    {
                        DataRow row = ketQua[0];

                        // Kiểm tra trạng thái sự kiện (còn hoạt động không)
                        bool trangThai = Convert.ToBoolean(row["TrangThai"]);
                        if (!trangThai)
                        {
                            MessageBox.Show("Sự kiện này đã kết thúc hoặc không còn hoạt động!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ResetThongTinSuKien();
                            return;
                        }

                        // Hiển thị thông tin sự kiện lên các label
                        string tenSuKien = row["TenSuKien"].ToString();
                        decimal phanTramGiam = Convert.ToDecimal(row["PhanTramGiam"]);
                        decimal giamToiDa = Convert.ToDecimal(row["GiamToiDa"]);
                        DateTime ngayBatDau = Convert.ToDateTime(row["NgayBatDau"]);
                        DateTime ngayKetThuc = Convert.ToDateTime(row["NgayKetThuc"]);

                        lblTenSuKien.Text = tenSuKien;
                        lblGiamToiDa.Text = phanTramGiam.ToString("0.##") + "% (Tối đa: " + giamToiDa.ToString("#,##0") + "đ)";
                        lblNgayBatDau.Text = ngayBatDau.ToString("dd/MM/yyyy");
                        lblNgayKetThuc.Text = ngayKetThuc.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sự kiện với mã: " + maSK, "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ResetThongTinSuKien();
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu sự kiện!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetThongTinSuKien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm sự kiện: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetThongTinSuKien();
            }
        }

        /// <summary>
        /// Reset các label thông tin sự kiện về trạng thái mặc định.
        /// </summary>
        private void ResetThongTinSuKien()
        {
            lblTenSuKien.Text = "---";
            lblGiamToiDa.Text = "---";
            lblNgayBatDau.Text = "---";
            lblNgayKetThuc.Text = "---";
        }

        #endregion

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
    }
}
