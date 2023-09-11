using DAL;
using DTO;
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
        public bool GetChucVu(string username)
        {
            return dalEmployee.GetChucVu(username);
        }
    }
}
