
using System;

namespace DTO
{
    public class DTO_HoaDon
    {
        private int _maHoaDon;
        private DateTime _ngayTaoHD;
        private double _tongTienHoaDon;
        private int _maNhanVien;
        private int _maKhachHang;

        public int MaHoaDon
        {
            get { return _maHoaDon; }
            set { _maHoaDon = value; }
        }

        public DateTime NgayTaoHD
        {
            get { return _ngayTaoHD; }
            set { _ngayTaoHD = value; }
        }

        public double TongTienHoaDon
        {
            get { return _tongTienHoaDon; }
            set { _tongTienHoaDon = value; }
        }

        public int MaNhanVien
        {
            get { return _maNhanVien; }
            set { _maNhanVien = value; }
        }

        public int MaKhachHang
        {
            get { return _maKhachHang; }
            set { _maKhachHang = value; }
        }
        public DTO_HoaDon() { }
        public DTO_HoaDon(int manv, int makh, double thanhtien ) 
        {
            this.MaNhanVien= manv;
            this.MaKhachHang= makh;    
            this.TongTienHoaDon= thanhtien;
        }
    }
}
