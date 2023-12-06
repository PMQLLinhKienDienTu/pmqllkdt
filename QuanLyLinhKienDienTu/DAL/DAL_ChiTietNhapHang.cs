using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_ChiTietNhapHang : DbConnect
    {
        // Danh sách khách hàng 
        public DataTable DanhSachCTNhapHang()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachCTNhapHang";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Thêm phiếu nhập
        public bool ThemCTNhapHang(DTO_ChiTietNhapHang ctnhaphang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThemPhieuNhapHang";
                cmd.Parameters.AddWithValue("ma", ctnhaphang.Masanpham);
                cmd.Parameters.AddWithValue("sl", ctnhaphang.Soluongnhap);
                cmd.Parameters.AddWithValue("gianhap", ctnhaphang.Gianhap);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        // Sửa phiếu nhập
        public bool SuaCTNhapHang(DTO_ChiTietNhapHang ctnhaphang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SuaPhieuNhapHang";
                cmd.Parameters.AddWithValue("ma", ctnhaphang.Masanpham);
                cmd.Parameters.AddWithValue("sl", ctnhaphang.Soluongnhap);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        //Xóa phiếu nhập
        public bool XoaCTNhapHang(int masp)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "XoaPhieuNhapHang";
                cmd.Parameters.AddWithValue("ma", masp);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        // Lấy toàn bộ giá nhập
        public double GetTongTienNhapHang()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetTongTienNhapHang";
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }
        }

        // kiểm tra trùng sản phẩm trong bảng chi tiết nhập hàng
        public bool KiemTraNhapHangTrung(int id, int soluong)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "KiemTraNhapHangTrung";
                cmd.Parameters.AddWithValue("id_hanghoa", id);
                cmd.Parameters.AddWithValue("soluongnhap", soluong);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

    }
}
