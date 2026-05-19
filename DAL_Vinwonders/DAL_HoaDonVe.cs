using ET_Vinwonders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Vinwonders
{
    public class DAL_HoaDonVe
    {
        Connection.ConnectData connectDB = new Connection.ConnectData();

        public DataTable InDanhSachHoaDonVe()
        {
            connectDB.OpenConnect();
            DataTable dt = new DataTable();
            try
            {
                string sql = "sp_GetAll_HoaDonVe";
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

        public bool TaoHoaDonVe(ET_HoaDonVe et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Insert_HoaDonVe";
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@",et.MaHoaDon),
                    new SqlParameter("@",et.MaKhachHang),
                    new SqlParameter("@",et.MaNhanVien),
                    new SqlParameter("@",et.MaSuKien),
                    new SqlParameter("@",et.NgayMua),
                    new SqlParameter("@",et.ChietKhauDoan),
                    new SqlParameter("@",et.TongTien),
                    new SqlParameter("@",et.PhuongThucThanhToan),
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

        public bool XoaHoaDonVe(string ma)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Delete_HoaDonVe"; //Chua co store delete
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

        public bool SuaHoaDonVe(ET_HoaDonVe et)
        {
            bool kt = false;
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_Update_HoaDonVe";//Chua co store update
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@",et.MaHoaDon),
                    new SqlParameter("@",et.MaKhachHang),
                    new SqlParameter("@",et.MaNhanVien),
                    new SqlParameter("@",et.MaSuKien),
                    new SqlParameter("@",et.NgayMua),
                    new SqlParameter("@",et.ChietKhauDoan),
                    new SqlParameter("@",et.TongTien),
                    new SqlParameter("@",et.PhuongThucThanhToan),
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

        public DataTable TimHoaDonVe(string tenKH = null)
        {
            DataTable kt = new DataTable();
            try
            {
                connectDB.OpenConnect();
                string sql = "sp_GetAll_HoaDonVe"; //Chua co store delete
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
