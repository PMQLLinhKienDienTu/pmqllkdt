using DTO;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class DAL_SanPham :DbConnect

    {
        // Danh sách Sản phẩm 
        public DataTable DanhSachSanPham()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachSanPham";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Thêm sản phẩm
        public bool ThemSanPham(DTO_SanPham sanpham)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThemSanPham";
                cmd.Parameters.AddWithValue("tensanpham", sanpham.TenSP);
                cmd.Parameters.AddWithValue("soluong", sanpham.SoLuong);
                cmd.Parameters.AddWithValue("gianhap", sanpham.GiaNhap);
                cmd.Parameters.AddWithValue("giaban", sanpham.GiaBan);
                cmd.Parameters.AddWithValue("hinhanh", sanpham.HinhAnh);
                cmd.Parameters.AddWithValue("phanloai", sanpham.MaPhanLoai);
                cmd.Parameters.AddWithValue("ghichu", sanpham.Ghichu);

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
        // Sửa sản phẩm
        public bool SuaSanPham(DTO_SanPham sanpham)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SuaSanPham";
                cmd.Parameters.AddWithValue("id", sanpham.MaSP);
                cmd.Parameters.AddWithValue("tensanpham", sanpham.TenSP);
                cmd.Parameters.AddWithValue("soluong", sanpham.SoLuong);
                cmd.Parameters.AddWithValue("gianhap", sanpham.GiaNhap);
                cmd.Parameters.AddWithValue("giaban", sanpham.GiaBan);
                cmd.Parameters.AddWithValue("hinhanh", sanpham.HinhAnh);
                cmd.Parameters.AddWithValue("phanloai", sanpham.MaPhanLoai);
                cmd.Parameters.AddWithValue("ghichu", sanpham.Ghichu);

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
        // Xóa sản phẩm
        public bool XoaSanPham(int id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "XoaSanPham";
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

        // Tìm kiếm sản phẩm theo tên
        public DataTable TimKiemSanPham(string hoten)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TimKiemSanPham";
                cmd.Parameters.AddWithValue("name", hoten);
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
