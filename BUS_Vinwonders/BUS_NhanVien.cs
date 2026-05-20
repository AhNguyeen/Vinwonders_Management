using DAL_Vinwonders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Vinwonders
{
    public class BUS_NhanVien
    {
        DAL_NhanVien nhanVien = new DAL_NhanVien();

        // In danh sách nhân viên
        public DataTable InDanhSachNhanVien()
        {
            return nhanVien.InDanhSachNhanVien();
        }
    }
}
