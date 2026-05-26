using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Vinwonders
{
    public class DAL_LoaiVe
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable LayDanhSachLoaiVe()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_LoaiVe";
                dt = connectDB.ReadData(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
