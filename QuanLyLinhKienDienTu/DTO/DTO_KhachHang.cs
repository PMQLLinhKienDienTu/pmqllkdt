
using System;

namespace DTO
{
    public class DTO_KhachHang
    {
        private int _maKhachHang;
        private string _hoTen;
        private int _sdt;
        private string _taiKhoan;
        private string _matKhau;
        private string _hangTV;
        private DateTime _ngayTaoThe;

        public int MaKhachHang
        {
            get { return _maKhachHang; }
            set { _maKhachHang = value; }
        }

        public string HoTen
        {
            get { return _hoTen; }
            set { _hoTen = value; }
        }

        public int SDT
        {
            get { return _sdt; }
            set { _sdt = value; }
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

        public string HangTV
        {
            get { return _hangTV; }
            set { _hangTV = value; }
        }

        public DateTime NgayTaoThe
        {
            get { return _ngayTaoThe; }
            set { _ngayTaoThe = value; }
        }
    }
}
