using DTO;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class DAL_KhachHang :DbConnect
    {
        // Danh sách khách hàng 
        public DataTable DanhSachKhachHang()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachKhachHang";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Thêm khác hàng
        public bool ThemKhachHang(DTO_KhachHang khachang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThemKhachHang";
                cmd.Parameters.AddWithValue("hoten", khachang.HoTen);
                cmd.Parameters.AddWithValue("diachi", khachang.Diachi);
                cmd.Parameters.AddWithValue("email", khachang.Email);
                cmd.Parameters.AddWithValue("sdt", khachang.SDT);
                
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

        // Sửa khác hàng
        public bool SuaKhachHang(DTO_KhachHang khachang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SuaKhachHang";
                cmd.Parameters.AddWithValue("hoten", khachang.HoTen);
                cmd.Parameters.AddWithValue("diachi", khachang.Diachi);
                cmd.Parameters.AddWithValue("email", khachang.Email);
                cmd.Parameters.AddWithValue("sdt", khachang.SDT);

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

        // Sửa khác hàng
        public bool XoaKhachHang(int id )
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "XoaKhachHang";
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

        // Tìm kiếm khách hàng
        public DataTable TimKiemKhachHang(string hoten)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TimKiemKhachHang";
                cmd.Parameters.AddWithValue("Hoten", hoten);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
