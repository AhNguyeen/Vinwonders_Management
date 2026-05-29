using ET_Vinwonders;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_Vinwonders
{
    public class DAL_BaoTriTroChoi
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable InDanhSachBaoTriTroChoi()
        {
            connectDB.OpenConnect();
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_BaoTriTroChoi"; //Chua co store GetAll
                dt = connectDB.ReadData(sql);
            }
            catch (Exception ex)
            {
                // X? lý l?i n?u c?n
                throw ex;
            }
            finally
            {
                connectDB.CloseConnect();
            }
            return dt;
        }

        public bool TaoBaoTriTroChoi(ET_BaoTriTroChoi et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Insert_BaoTriTroChoi";    //Chua co store Insert
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaBaoTri", et.MaBaoTri),
                    new SqlParameter("@MaTroChoi", et.MaTroChoi),
                    new SqlParameter("@MaNhanVien", et.MaNhanVien),
                    new SqlParameter("@NgayBatDau", et.NgayBatDau),
                    new SqlParameter("@NgayDuKienXong", et.NgayDuKienXong),
                    new SqlParameter("@MoTaLoi", et.MoTaLoi),
                    new SqlParameter("@ChiPhiBaoTri", et.ChiPhiBaoTri),
                    new SqlParameter("@TrangThai", et.TrangThai),
                };
                kt = connectDB.ChangeData(sql, sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connectDB.CloseConnect();
            }
            return kt;
        }

        public bool XoaBaoTriTroChoi(string ma)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Delete_BaoTriTroChoi"; //Chua co store delete
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@",ma),
                };
                kt = connectDB.ChangeData(sql, sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connectDB.CloseConnect();
            }
            return kt;
        }

        public bool SuaBaoTriTroChoi(ET_BaoTriTroChoi et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Update_BaoTriTroChoi";//Chua co store update
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaBaoTri", et.MaBaoTri),
                    new SqlParameter("@MaTroChoi", et.MaTroChoi),
                    new SqlParameter("@MaNhanVien", et.MaNhanVien),
                    new SqlParameter("@NgayBatDau", et.NgayBatDau),
                    new SqlParameter("@NgayDuKienXong", et.NgayDuKienXong),
                    new SqlParameter("@MoTaLoi", et.MoTaLoi),
                    new SqlParameter("@ChiPhiBaoTri", et.ChiPhiBaoTri),
                    new SqlParameter("@TrangThai", et.TrangThai),
                };
                kt = connectDB.ChangeData(sql, sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connectDB.CloseConnect();
            }
            return kt;
        }

        public DataTable TimBaoTriTroChoi(string tenKH = null)
        {
            DataTable kt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_GetAll_BaoTriTroChoi"; //Chua co store delete
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@",tenKH),
                };
                kt = connectDB.ReadData(sql, sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connectDB.CloseConnect();
            }
            return kt;
        }
    }
}
