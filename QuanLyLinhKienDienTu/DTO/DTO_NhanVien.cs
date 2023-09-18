
using System;

namespace DTO
{
    public class DTO_NhanVien
    {
        private int _maNhanVien;
        private string _tenNhanVien;
        private string _taiKhoan;
        private string _matKhau;
        private bool _chucVu;
        private string _email;
        private string _ngayVaoLam;
        private bool _tinhtrang;
        private string _sodienthoai;
        private byte[] _hinhAnh;
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

        public bool ChucVu
        {
            get { return _chucVu; }
            set { _chucVu = value; }
        }
        public bool TinhTrang
        {
            get { return _tinhtrang; }
            set { _tinhtrang = value; }
        }
        public string SoDienThoai
        {
            get { return _sodienthoai; }
            set { _sodienthoai = value; }
        }
        public byte[] HinhAnh
        {
            get { return _hinhAnh; }
            set { _hinhAnh = value; }
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

        public DTO_NhanVien() { }

        public DTO_NhanVien(int manhanvien, string tennhanvien, string taikhoan,string email,string sdt, bool chucvu, bool tinhtrang) 
        {
            MaNhanVien = manhanvien;
            TenNhanVien= tennhanvien;
            TaiKhoan= taikhoan;
            Email= email;
            SoDienThoai= sdt;
            ChucVu = chucvu;
            TinhTrang= tinhtrang;
        }
        public DTO_NhanVien(string hoten, string taikhoan, string email, string sdt, bool chucvu, bool tinhtrang,string matkhau)
        {
            TenNhanVien= hoten;
            TaiKhoan= taikhoan;
            Email= email;
            SoDienThoai= sdt;
            ChucVu= chucvu;
            TinhTrang= tinhtrang;
            MatKhau= matkhau;
        }
        public DTO_NhanVien(string hoten, string taikhoan, string email, string sdt, bool chucvu, bool tinhtrang)
        {
            TenNhanVien = hoten;
            TaiKhoan = taikhoan;
            Email = email;
            SoDienThoai = sdt;
            ChucVu = chucvu;
            TinhTrang = tinhtrang;
        
        }
        public DTO_NhanVien( string taikhoan, string sdt, string email)
        {
            
            TaiKhoan = taikhoan;
            SoDienThoai = sdt;
            Email = email;

        }
        public DTO_NhanVien(string taikhoan, byte[] hinhanh) 
        {
            this.TaiKhoan = taikhoan;
            this.HinhAnh= hinhanh;
        }
        public DTO_NhanVien(string taikhoan)
        {
            this.TaiKhoan = taikhoan;
        }


    }
}
