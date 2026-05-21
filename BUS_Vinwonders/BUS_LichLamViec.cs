using DAL_Vinwonders;
using ET_Vinwonders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Vinwonders
{
    public class BUS_LichLamViec
    {
        DAL_LichLamViec dalLichLamViec = new DAL_LichLamViec();

        public DataTable InDanhSach()
        {
            return dalLichLamViec.InDanhSachLichLamViec();
        }
        public DataTable TimLichLamViec(string ten)
        {
            return dalLichLamViec.TimLichLamViec(ten);
        }
        public bool ThemLichLamViec(ET_LichLamViec et)
        {
            return dalLichLamViec.TaoLichLamViec(et);
        }
        public bool XoaLichLamViec(string ma)
        {
            return dalLichLamViec.XoaLichLamViec(ma);
        }
        public bool SuaLichLamViec(ET_LichLamViec et)
        {
            return dalLichLamViec.SuaLichLamViec(et);
        }
    }
}
