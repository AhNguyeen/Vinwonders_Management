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
    public class DAL_NhanVien
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable InDanhSachNhanVien()
        {
            connectDB.OpenConnect();
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_NhanVien"; //Chua co store GetAll
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

        public bool TaoNhanVien(ET_NhanVien et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Insert_NhanVien";    //Chua co store Insert
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@", et.MaNhanVien),
                    new SqlParameter("@", et.MaTaiKhoan),
                    new SqlParameter("@", et.HoTen),
                    new SqlParameter("@", et.GioTinh),
                    new SqlParameter("@", et.NgaySinh),
                    new SqlParameter("@", et.SoDienThoai),
                    new SqlParameter("@", et.Email),
                    new SqlParameter("@", et.CCCD),
                    new SqlParameter("@", et.ViTri),
                    new SqlParameter("@", et.Luong),
                    new SqlParameter("@", et.NgayVaoLam),
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

        public bool XoaNhanVien(string ma)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Delete_NhanVien"; //Chua co store delete
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

        public bool SuaNhanVien(ET_NhanVien et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Update_NhanVien";//Chua co store update
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@", et.MaNhanVien),
                    new SqlParameter("@", et.MaTaiKhoan),
                    new SqlParameter("@", et.HoTen),
                    new SqlParameter("@", et.GioTinh),
                    new SqlParameter("@", et.NgaySinh),
                    new SqlParameter("@", et.SoDienThoai),
                    new SqlParameter("@", et.Email),
                    new SqlParameter("@", et.CCCD),
                    new SqlParameter("@", et.ViTri),
                    new SqlParameter("@", et.Luong),
                    new SqlParameter("@", et.NgayVaoLam),
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

        public DataTable TimNhanVien(string tenKH = null)
        {
            DataTable kt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_GetAll_NhanVien"; //Chua co store delete
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
