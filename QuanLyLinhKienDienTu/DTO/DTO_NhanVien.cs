
using System;

namespace DTO
{
    public class DTO_NhanVien
    {
        private int _maNhanVien;
        private string _tenNhanVien;
        private string _taiKhoan;
        private string _matKhau;
        private string _chucVu;
        private string _email;
        private string _ngayVaoLam;

        public int MaNhanVien
        {
            get { return _maNhanVien; }
            set { _maNhanVien = value; }
        }

        public string TenNhanVien
        {
            get { return _tenNhanVien; }
            set { _tenNhanVien = value; }
        }

        public string TaiKhoan
        {
            get { return _taiKhoan; }
            set { _taiKhoan = value; }
        }

        public string MatKhau
        {
            get { return _matKhau; }
            set { _matKhau = value; }
        }

        public string ChucVu
        {
            get { return _chucVu; }
            set { _chucVu = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string NgayVaoLam
        {
            get { return _ngayVaoLam; }
            set { _ngayVaoLam = value; }
        }
    }
}
