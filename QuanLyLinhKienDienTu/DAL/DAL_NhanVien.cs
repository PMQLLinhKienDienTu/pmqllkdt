﻿using DTO;
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
    }
}
