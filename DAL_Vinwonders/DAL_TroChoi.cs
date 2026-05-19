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
    public class DAL_TroChoi
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable InDanhSachTroChoi()
        {
            connectDB.OpenConnect();
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_TroChoi"; //Chua co store GetAll
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

        public bool TaoTroChoi(ET_TroChoi et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Insert_TroChoi";    //Chua co store Insert
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@", et.MaTroChoi),
                    new SqlParameter("@", et.MaKhuVuc),
                    new SqlParameter("@", et.TenTroChoi),
                    new SqlParameter("@", et.PhanLoai),
                    new SqlParameter("@", et.ChieuCaoToiThieu),
                    new SqlParameter("@", et.DoTuoiToiThieu),
                    new SqlParameter("@", et.SucChua),
                    new SqlParameter("@", et.TrangThai),
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

        public bool XoaTroChoi(string ma)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Delete_TroChoi"; //Chua co store delete
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

        public bool SuaTroChoi(ET_TroChoi et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Update_TroChoi";//Chua co store update
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@", et.MaTroChoi),
                    new SqlParameter("@", et.MaKhuVuc),
                    new SqlParameter("@", et.TenTroChoi),
                    new SqlParameter("@", et.PhanLoai),
                    new SqlParameter("@", et.ChieuCaoToiThieu),
                    new SqlParameter("@", et.DoTuoiToiThieu),
                    new SqlParameter("@", et.SucChua),
                    new SqlParameter("@", et.TrangThai),
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

        public DataTable TimTroChoi(string tenKH = null)
        {
            DataTable kt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_GetAll_TroChoi"; //Chua co store delete
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
