using DTO;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class DAL_ChiTietHoaDon :DbConnect
    {
        // Danh sách CT hóa đơn 
        public DataTable DanhSachCTHoaDon()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachCTHoaDon";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }
        // Thêm chi tiết hóa đơn

        public bool ThemCTHoaDon(DTO_ChiTietHoaDon chiTietHoaDon, int soluong)
        {

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThemCTHoaDon";
                cmd.Parameters.AddWithValue("productId", chiTietHoaDon.MaSP);
                cmd.Parameters.AddWithValue("quantity", soluong);
                cmd.Parameters.AddWithValue("unitPrice", chiTietHoaDon.Gia);
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
        // Lấy toàn bộ giá
        public double GetTotalPrice()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetTotalPrice";
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }
        }

        // Xóa sản phẩm trong bảng chi tiết hóa đơn
        public bool XoaSanPhamCTHoaDon(int id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "XoaSanPhamCTHoaDon";
                cmd.Parameters.AddWithValue("id", id);
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
        // Cập nhập sản phẩm trong bảng chi tiết hóa đơn
        public bool SuaSanPhamCTHoaDon(int id, int quantity)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SuaSanPhamCTHoaDon";
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("quantity", quantity);
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
