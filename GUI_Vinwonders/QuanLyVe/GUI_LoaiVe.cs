using BUS_Vinwonders;
using System;
using System.Windows.Forms;

namespace Vinwonders_Management.QuanLyVe
{
    public partial class GUI_LoaiVe : UserControl
    {
        public GUI_LoaiVe()
        {
            InitializeComponent();
        }

        BUS_LoaiVe busLoaiVe = new BUS_LoaiVe();

        private void LoadDanhSachLoaiVe()
        {
            try
            {
                dgvLoaiVe.AutoGenerateColumns = false; // Tắt tự động tạo cột
                dgvLoaiVe.DataSource = busLoaiVe.InDanhSach();
                if(dgvLoaiVe.Columns.Contains("colSua"))
                {
                    dgvLoaiVe.Columns["colSua"].DisplayIndex = dgvLoaiVe.Columns.Count - 1;
                }
                if(dgvLoaiVe.Columns.Contains("colXoa"))
                {
                    dgvLoaiVe.Columns["colXoa"].DisplayIndex = dgvLoaiVe.Columns.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách loại vé: " + ex.Message);
            }
        }

        private void GUI_LoaiVe_Load(object sender, EventArgs e)
        {
            LoadDanhSachLoaiVe();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            GUI_ThemLoaiVe themLoaiVe = new GUI_ThemLoaiVe();
            themLoaiVe.ShowDialog();
            LoadDanhSachLoaiVe();
        }
    }
}
