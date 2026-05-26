using DAL_Vinwonders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Vinwonders
{
    public class BUS_LoaiVe
    {
        DAL_LoaiVe dalLoaiVe = new DAL_LoaiVe();
    
        public object InDanhSach()
        {
            return dalLoaiVe.LayDanhSachLoaiVe();
        }
    }
}
