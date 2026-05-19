using ET_Vinwonders;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Vinwonders
{
    public class DAL_SuKien
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable InDanhSachSuKien()
        {
            connectDB.OpenConnect();
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_SuKien"; //Chua co store GetAll
                dt = connectDB.ReadData(sql);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
                throw ex;
            }
            finally
            {
                connectDB.CloseConnect();
            }
            return dt;
        }

        public bool TaoSuKien(ET_SuKien et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Insert_SuKien";    //Chua co store Insert
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@",et.MaSuKien),
                    new SqlParameter("@",et.TenSuKien),
                    new SqlParameter("@",et.MoTa),
                    new SqlParameter("@",et.NgayBatDau),
                    new SqlParameter("@",et.NgayKetThuc),
                    new SqlParameter("@",et.MaGiamGia),
                    new SqlParameter("@",et.PhanTramGiam),
                    new SqlParameter("@",et.GiamToiDa),
                    new SqlParameter("@",et.TrangThai),
                };
                kt = connectDB.ChangeData(sql, sp);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connectDB.CloseConnect();
            }
            return kt;
        }

        public bool XoaSuKien(string ma)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Delete_SuKien"; //Chua co store delete
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@",ma),
                };
                kt = connectDB.ChangeData(sql, sp);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connectDB.CloseConnect();
            }
            return kt;
        }

        public bool SuaSuKien(ET_SuKien et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Update_SuKien";//Chua co store update
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@",et.MaSuKien),
                    new SqlParameter("@",et.TenSuKien),
                    new SqlParameter("@",et.MoTa),
                    new SqlParameter("@",et.NgayBatDau),
                    new SqlParameter("@",et.NgayKetThuc),
                    new SqlParameter("@",et.MaGiamGia),
                    new SqlParameter("@",et.PhanTramGiam),
                    new SqlParameter("@",et.GiamToiDa),
                    new SqlParameter("@",et.TrangThai),
                };
                kt = connectDB.ChangeData(sql, sp);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connectDB.CloseConnect();
            }
            return kt;
        }

        public DataTable TimSuKien(string tenKH = null)
        {
            DataTable kt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_GetAll_SuKien"; //Chua co store delete
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@",tenKH),
                };
                kt = connectDB.ReadData(sql, sp);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connectDB.CloseConnect();
            }
            return kt;
        }
    }
}
