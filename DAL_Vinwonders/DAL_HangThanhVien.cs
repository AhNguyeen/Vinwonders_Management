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
    public class DAL_HangThanhVien
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable InDanhSachHangThanhVien()
        {
            connectDB.OpenConnect();
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_HangThanhVien";
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

        public bool TaoHangThanhVien(ET_HangThanhVien et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Insert_HangThanhVien";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@", et.MaHang),
                    new SqlParameter("@", et.TenHang),
                    new SqlParameter("@", et.DiemToiThieu),
                    new SqlParameter("@", et.TiLeGiamGia),
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

        public bool XoaHangThanhVien(string ma)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Delete_HangThanhVien"; //Chua co store delete
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

        public bool SuaHangThanhVien(ET_HangThanhVien et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Update_HangThanhVien";//Chua co store update
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@", et.MaHang),
                    new SqlParameter("@", et.TenHang),
                    new SqlParameter("@", et.DiemToiThieu),
                    new SqlParameter("@", et.TiLeGiamGia),
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

        public DataTable TimHangThanhVien(string tenKH = null)
        {
            DataTable kt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_GetAll_HangThanhVien"; //Chua co store delete
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
