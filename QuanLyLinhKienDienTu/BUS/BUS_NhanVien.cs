using DAL;
using DTO;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace BUS
{
    public class BUS_NhanVien
    {
        DAL_NhanVien dalEmployee = new DAL_NhanVien();

        private string Encrytion(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            foreach (var item in encrypt)
            {
                builder.Append(item.ToString());
            }
            return builder.ToString();
        }

        public bool Login(string username, string password)
        {
            password = Encrytion(password);
            return dalEmployee.Login(username, password);
        }
        public bool IsExistUserName(string username)
        {
            return dalEmployee.IsExistTaiKhoan(username);
        }
        public bool GetChucVu(string taikhoan)
        {
            return dalEmployee.GetChucVu(taikhoan);
        }
        public DataTable DanhSachNhanVien()
        {
            return dalEmployee.DanhSachNhanVien();
        }

        public bool CapNhatMatKhauNhanVien(string email, string password)
        {
            password = Encrytion(password);
            return dalEmployee.CapNhatMatKhauNhanVien(email, password);
        }
        public bool ThemNhanVien(DTO_NhanVien nhanvien)
        {
            nhanvien.MatKhau = Encrytion(nhanvien.MatKhau);
            return dalEmployee.ThemNhanVien(nhanvien);
        }

        public bool LayChucVuNhanVien(string email)
        {
            return dalEmployee.LayChucVuNhanVien(email);
        }
        public bool ThayDoiMKChucVu(string email, string oldPassword, string newPassword)
        {
            oldPassword = Encrytion(oldPassword);
            newPassword = Encrytion(newPassword);
            return dalEmployee.ThayDoiMKChucVu(email, oldPassword, newPassword);
        }
        public bool SuaNhanVien(DTO_NhanVien nhanvien)
        {
            return dalEmployee.SuaNhanVien(nhanvien);
        }
        public bool XoaNhanVien(int id)
        {
            return dalEmployee.XoaNhanVien(id);
        }
        public DataTable TimKiemNhanVien(string hoten)
        {
            return dalEmployee.TimKiemNhanVien(hoten);
        }
        public bool CapNhatTKandSDT(DTO_NhanVien nhanvien)
        {
            return dalEmployee.CapNhatTKandSDT(nhanvien);
        }

        public string LayIDandHoten(string email)
        {
            return dalEmployee.LayNhanVienIDHoTen(email);
        }
        public string LayTKandSDT(string email)
        {
            return dalEmployee.LayTKandSDT(email);
        }
        public string GetRandomPassword()
        {
            Random r = new Random();
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(r.Next(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random r = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * r.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
            {
                return builder.ToString().ToUpper();
            }
            else return builder.ToString().ToLower();
        }
    }
}
