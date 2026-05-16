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
    public partial class GUI_Menu : Form
    {
        public GUI_Menu()
        {
            InitializeComponent();
        }

        // 1. Khai báo một cái "cờ hiệu" (Biến toàn cục trên cùng của class FrmMenu)
        bool isLogout = false;

        // 2. Chỉnh lại Nút Đăng Xuất
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            isLogout = true;                         // Bật cờ hiệu Đăng xuất lên
            //this.DialogResult = DialogResult.Yes;    // Bắn tín hiệu "Đăng xuất" về cho GUI_Login
            this.Close();                            // Đóng form Menu
        }

        // 3. Chỉnh lại hàm FormClosing của Menu
        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            // LỚP BẢO VỆ: Nếu đang là Đăng Xuất thì KHÔNG HIỂN THỊ THÔNG BÁO GÌ CẢ, CHO ĐÓNG LUÔN
            if (isLogout == true)
            {
                return;
            }

            // Nếu không phải Đăng xuất (ví dụ bấm dấu X góc phải), thì mới hiện thông báo hỏi
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi phần mềm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        // Biến toàn cục lưu trữ vết của Form con đang được mở hiện tại trên màn hình
        private Form activeForm = null;

        private void OpenChildForm(Type formType)
        {
            // BƯỚC 1: KHỞI TẠO VÀ CÀI ĐẶT FORM MỚI TRƯỚC
            Form newForm = (Form)Activator.CreateInstance(formType);
            newForm.MdiParent = this;
            newForm.ControlBox = false;
            newForm.ShowIcon = false;
            newForm.Text = "";
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;

            // BƯỚC 2: HIỂN THỊ FORM MỚI ĐỂ CHE ĐI FORM CŨ
            newForm.Show();

            // BƯỚC 3: SAU KHI FORM MỚI ĐÃ LÊN HÌNH, MỚI ĐÓNG CÁC FORM CŨ ĐI
            foreach (Form childForm in this.MdiChildren)
            {
                // Kiểm tra: Nếu không phải là cái form vừa tạo thì mới Close
                if (childForm != newForm)
                {
                    childForm.Close();
                    childForm.Dispose(); // Ép dọn rác RAM ngay lập tức
                }
            }
        }


        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(typeof(GUI_Dashboard));
            lblGUI.Text = "Dashboard";
        }

        private void btnQuanLyVe_Click(object sender, EventArgs e)
        {
            OpenChildForm(typeof(GUI_QuanLyVe));
            lblGUI.Text = "Quản Lý Vé";
        }

        private void GUI_Menu_Load(object sender, EventArgs e)
        {
            OpenChildForm(typeof(GUI_Dashboard));
            lblGUI.Text = "Dashboard";
            lblDateTimeNow.Text = DateTime.Now.ToString("dddd, d MMMM yyyy");
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(typeof(GUI_QuanLyKhachHang));
            lblGUI.Text = "Quản Lý Khách Hàng";
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(typeof(GUI_QuanLyNhanVien));
            lblGUI.Text = "Quản Lý Nhân Viên";
        }
    }
}
