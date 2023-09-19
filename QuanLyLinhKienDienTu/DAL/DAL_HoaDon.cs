using DTO;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class DAL_HoaDon :DbConnect
    {
        // Danh sách hóa đơn
        public DataTable DanhSachHoaDon()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachHoaDon";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        //Thêm hóa đơn
        public bool ThemHoaDon(DTO_HoaDon hoadon)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThemHoaDon";
                cmd.Parameters.AddWithValue("employeeId", hoadon.MaNhanVien);
                cmd.Parameters.AddWithValue("customerId", hoadon.MaKhachHang);
                cmd.Parameters.AddWithValue("totalPrice", hoadon.TongTienHoaDon);
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
