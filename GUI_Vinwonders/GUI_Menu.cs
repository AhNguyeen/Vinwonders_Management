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
        //private Form activeForm = null;

        //private void OpenChildForm(Type formType)
        //{
        //    // BƯỚC 1: KHỞI TẠO VÀ CÀI ĐẶT FORM MỚI TRƯỚC
        //    Form newForm = (Form)Activator.CreateInstance(formType);
        //    newForm.MdiParent = this;
        //    newForm.ControlBox = false;
        //    newForm.ShowIcon = false;
        //    newForm.Text = "";
        //    newForm.FormBorderStyle = FormBorderStyle.None;
        //    newForm.Dock = DockStyle.Fill;

        //    // BƯỚC 2: HIỂN THỊ FORM MỚI ĐỂ CHE ĐI FORM CŨ
        //    newForm.Show();

        //    // BƯỚC 3: SAU KHI FORM MỚI ĐÃ LÊN HÌNH, MỚI ĐÓNG CÁC FORM CŨ ĐI
        //    foreach (Form childForm in this.MdiChildren)
        //    {
        //        // Kiểm tra: Nếu không phải là cái form vừa tạo thì mới Close
        //        if (childForm != newForm)
        //        {
        //            childForm.Close();
        //            childForm.Dispose(); // Ép dọn rác RAM ngay lập tức
        //        }
        //    }
        //}
        private void OpenChildUserControl(Type controlType)
        {
            // BƯỚC 1: KHỞI TẠO USER CONTROL MỚI
            // Ép kiểu về UserControl thay vì Form
            UserControl newControl = (UserControl)Activator.CreateInstance(controlType);
            newControl.Dock = DockStyle.Fill;

            // BƯỚC 2: HIỂN THỊ VÀ ĐẨY LÊN TRÊN CÙNG
            // Thêm UserControl mới vào Panel chứa
            pnMainContent.Controls.Add(newControl);
            // Đẩy nó lên mặt trên cùng để che hết các cái cũ đi
            newControl.BringToFront();

            // BƯỚC 3: DỌN DẸP CÁC CONTROL CŨ ĐỂ CHỐNG TRÀN RAM
            // Phải lặp ngược từ dưới lên (Count - 1 về 0) để khi Remove không bị lỗi index
            for (int i = pnMainContent.Controls.Count - 1; i >= 0; i--)
            {
                Control oldControl = pnMainContent.Controls[i];

                // Kiểm tra: Nếu không phải là cái UserControl vừa tạo thì mới xóa
                if (oldControl != newControl)
                {
                    pnMainContent.Controls.Remove(oldControl); // Gỡ khỏi giao diện
                    oldControl.Dispose(); // Ép hệ thống dọn rác RAM ngay lập tức
                }
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(typeof(GUI_Dashboard));
            lblGUI.Text = "Dashboard";
        }

        private void btnQuanLyVe_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(typeof(GUI_QuanLyVe));
            lblGUI.Text = "Quản Lý Vé";
        }

        private void GUI_Menu_Load(object sender, EventArgs e)
        {
            OpenChildUserControl(typeof(GUI_Dashboard));
            lblGUI.Text = "Dashboard";
            lblDateTimeNow.Text = DateTime.Now.ToString("dddd, d MMMM yyyy");
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(typeof(GUI_QuanLyKhachHang));
            lblGUI.Text = "Quản Lý Khách Hàng";
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(typeof(GUI_QuanLyNhanVien));
            lblGUI.Text = "Quản Lý Nhân Viên";
        }

        private void btnKhuVuiChoi_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(typeof(GUI_QuanLyTroChoi));
            lblGUI.Text = "Quản Lý Khu Vui Chơi";
        }

        private void btnCuaHang_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(typeof(GUI_QuanLyCuaHang));
            lblGUI.Text = "Quản Lý Cửa Hàng Sản Phẩm";
        }

        private void btnSuKien_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(typeof(GUI_SuKien));
            lblGUI.Text = "Quản Lý Sự Kiện";
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
