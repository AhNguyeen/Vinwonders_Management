using DAL_Vinwonders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Vinwonders
{
    public class BUS_HoaDonVe
    {
        DAL_HoaDonVe dalHoaDonVe = new DAL_HoaDonVe();
    
        public DataTable InDanhSach()
        {
            return dalHoaDonVe.InDanhSachHoaDonVe();
        }
    }
}
