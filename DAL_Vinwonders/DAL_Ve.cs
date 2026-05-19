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
    public class DAL_Ve
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable InDanhSachVe()
        {
            connectDB.OpenConnect();
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_Ve"; //Chua co store GetAll
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

        public bool TaoVe(ET_Ve et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Insert_Ve";    //Chua co store Insert
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@", et.MaVe),
                    new SqlParameter("@", et.MaHoaDon),
                    new SqlParameter("@", et.MaLoaiVe),
                    new SqlParameter("@", et.DonGia),
                    new SqlParameter("@", et.NgaySuDung),
                    new SqlParameter("@", et.DaSuDung),
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

        public bool XoaVe(string ma)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Delete_Ve"; //Chua co store delete
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

        public bool SuaVe(ET_Ve et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Update_Ve";//Chua co store update
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@", et.MaVe),
                    new SqlParameter("@", et.MaHoaDon),
                    new SqlParameter("@", et.MaLoaiVe),
                    new SqlParameter("@", et.DonGia),
                    new SqlParameter("@", et.NgaySuDung),
                    new SqlParameter("@", et.DaSuDung),
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

        public DataTable TimVe(string tenKH = null)
        {
            DataTable kt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_GetAll_Ve"; //Chua co store delete
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
