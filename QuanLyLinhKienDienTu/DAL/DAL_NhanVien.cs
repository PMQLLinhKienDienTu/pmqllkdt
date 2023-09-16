using DTO;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class DAL_NhanVien :DbConnect
    {

        //Kiểm tra đăng nhập
        public bool Login(string username, string password)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DangNhap";
                cmd.Parameters.AddWithValue("taikhoan", username);
                cmd.Parameters.AddWithValue("matkhau", password);
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {              
                System.Windows.Forms.MessageBox.Show("Đã xảy ra lỗi vui lòng xem lại!!!");
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        // Kiểm tra sự tồn tại của tài khoản
        public bool IsExistTaiKhoan(string taikhoan)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "IsExistTaiKhoan";
                cmd.Parameters.AddWithValue("taikhoan", taikhoan);
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
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

        // Lấy chức vụ của nhân viên 
        public bool GetChucVu(string taikhoan)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "LayChucVuNhanVien";
                cmd.Parameters.AddWithValue("taikhoan", taikhoan);
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
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

        // Danh sách nhân viên 
        public DataTable DanhSachNhanVien()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachNhanVien";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Thêm nhân viên
        public bool ThemNhanVien(DTO_NhanVien nhanvien)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThemNhanVien";
                cmd.Parameters.AddWithValue("hoten", nhanvien.TenNhanVien);
                cmd.Parameters.AddWithValue("taokhoan", nhanvien.TaiKhoan);
                cmd.Parameters.AddWithValue("email", nhanvien.Email);
                cmd.Parameters.AddWithValue("sodienthoai", nhanvien.SoDienThoai);
                cmd.Parameters.AddWithValue("role", nhanvien.ChucVu);
                cmd.Parameters.AddWithValue("status", nhanvien.TinhTrang);
                cmd.Parameters.AddWithValue("matkhau", nhanvien.MatKhau);
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

        // Cập nhật nhân viên
        public bool SuaNhanVien(DTO_NhanVien nhanvien)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SuaNhanVien";
                cmd.Parameters.AddWithValue("hoten", nhanvien.TenNhanVien);
                cmd.Parameters.AddWithValue("taokhoan", nhanvien.TaiKhoan);
                cmd.Parameters.AddWithValue("email", nhanvien.Email);
                cmd.Parameters.AddWithValue("sodienthoai", nhanvien.SoDienThoai);
                cmd.Parameters.AddWithValue("role", nhanvien.ChucVu);
                cmd.Parameters.AddWithValue("status", nhanvien.TinhTrang);
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

        // Cập nhật tài khoản, số điện thoại nhân viên
        public bool CapNhatTKandSDT(DTO_NhanVien nhanvien)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SuaTKandSDT";
                cmd.Parameters.AddWithValue("taikhoan", nhanvien.TaiKhoan);
                cmd.Parameters.AddWithValue("sodienthoai", nhanvien.SoDienThoai);
                cmd.Parameters.AddWithValue("email", nhanvien.Email);
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

        // Xóa nhân viên
        public bool XoaNhanVien(int id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "XoaNhanVien";
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

        // Tìm kiếm nhân viên
        public DataTable TimKiemNhanVien(string hoten)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TimKiemNhanVien";
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

        // Kiểm tra và cập nhập lại mật khẩu cho nhân viên
        public bool CapNhatMatKhauNhanVien(string email, string matkhau)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ThayDoiMatKhau";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("matkhau", matkhau);
                if (cmd.ExecuteNonQuery() != 0)
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

        // Lấy chức vụ của nhân viên 
        public bool LayChucVuNhanVien(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "LayChucVuNhanVien";
                cmd.Parameters.AddWithValue("email", email);
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
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

        // Lấy nhân viên theo ID, HoTen
        public string LayNhanVienIDHoTen(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LayIdHoTenNhanVien";
                cmd.Parameters.AddWithValue("email", email);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }
        }
        // Lấy tài khoản và sdt nhân viên
        public string LayTKandSDT(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LayTKandSDT";
                cmd.Parameters.AddWithValue("email", email);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }
        }
        // Lấy Mail nhân viên
        public string LayMailNhanVien(string taikhoan)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LayMailNhanVien";
                cmd.Parameters.AddWithValue("taikhoan", taikhoan);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }
        }

        // Thay đổi mật khẩu chức vụ của nhân viên
        public bool ThayDoiMKChucVu(string email, string oldPassword, string newPassword)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ThayDoiMatKhauChucVu";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("oldPassword", oldPassword);
                cmd.Parameters.AddWithValue("newPassword", newPassword);
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
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
