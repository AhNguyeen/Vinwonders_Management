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

namespace Vinwonders_Management.QuanLyTroChoi
{
    public partial class GUI_TroChoi : UserControl
    {
        public GUI_TroChoi()
        {
            InitializeComponent();
        }

        BUS_TroChoi busTroChoi = new BUS_TroChoi();

        private void LoadDanhSachTroChoi()
        {
            dgvTroChoi.AutoGenerateColumns = false;
            dgvTroChoi.DataSource = busTroChoi.InDanhSach();
            if (dgvTroChoi.Columns.Contains("colSua"))
            {
                dgvTroChoi.Columns["colSua"].DisplayIndex = dgvTroChoi.Columns.Count - 1;
            }
            if (dgvTroChoi.Columns.Contains("colXoa"))
            {
                dgvTroChoi.Columns["colXoa"].DisplayIndex = dgvTroChoi.Columns.Count - 1;
            }
        }

        private void GUI_TroChoi_Load(object sender, EventArgs e)
        {
            LoadDanhSachTroChoi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
    }
}
