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
    public class DAL_CuaHang
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable InDanhSachCuaHang()
        {
            connectDB.OpenConnect();
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_CuaHang"; //Chua co store GetAll
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

        public bool TaoCuaHang(ET_CuaHang et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Insert_CuaHang";    //Chua co store Insert
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@", et.MaKhachHang),
                    new SqlParameter("@", et.MaDangKy),
                    new SqlParameter("@", et.MaHang),
                    new SqlParameter("@", et.HoTen),
                    new SqlParameter("@", et.LoaiKhach),
                    new SqlParameter("@", et.NgaySinh),
                    new SqlParameter("@", et.DiaChi),
                    new SqlParameter("@", et.SoDienThoai),
                    new SqlParameter("@", et.Email),
                    new SqlParameter("@", et.DiemTichLuy),
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

        public bool XoaCuaHang(string ma)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Delete_CuaHang"; //Chua co store delete
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

        public bool SuaCuaHang(ET_CuaHang et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Update_CuaHang";//Chua co store update
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@", et.MaKhachHang),
                    new SqlParameter("@", et.MaDangKy),
                    new SqlParameter("@", et.MaHang),
                    new SqlParameter("@", et.HoTen),
                    new SqlParameter("@", et.LoaiKhach),
                    new SqlParameter("@", et.NgaySinh),
                    new SqlParameter("@", et.DiaChi),
                    new SqlParameter("@", et.SoDienThoai),
                    new SqlParameter("@", et.Email),
                    new SqlParameter("@", et.DiemTichLuy),
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

        public DataTable TimCuaHang(string tenKH = null)
        {
            DataTable kt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_GetAll_CuaHang"; //Chua co store delete
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
