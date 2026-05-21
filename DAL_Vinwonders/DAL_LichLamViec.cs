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
    public class DAL_LichLamViec
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable InDanhSachLichLamViec()
        {
            connectDB.OpenConnect();
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_LichLamViec";
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

        public bool TaoLichLamViec(ET_LichLamViec et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Insert_LichLamViec";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaLich", et.MaLich),
                    new SqlParameter("@MaNhanVien", et.MaNhanVien),
                    new SqlParameter("@MaCa", et.MaCa),
                    new SqlParameter("@NgayLamViec", et.NgayLamViec),
                    new SqlParameter("@ViTriPhanCong", et.ViTriPhanCong),
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

        public bool XoaLichLamViec(string ma)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Delete_LichLamViec"; //Chua co store delete
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

        public bool SuaLichLamViec(ET_LichLamViec et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Update_LichLamViec";//Chua co store update
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@MaLich", et.MaLich),
                    new SqlParameter("@MaNhanVien", et.MaNhanVien),
                    new SqlParameter("@MaCa", et.MaCa),
                    new SqlParameter("@NgayLamViec", et.NgayLamViec),
                    new SqlParameter("@ViTriPhanCong", et.ViTriPhanCong),
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

        public DataTable TimLichLamViec(string tenKH = null)
        {
            DataTable kt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_GetAll_LichLamViec"; //Chua co store delete
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
