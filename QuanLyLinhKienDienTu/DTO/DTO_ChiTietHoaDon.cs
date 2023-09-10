
namespace DTO
{
    public class DTO_ChiTietHoaDon
    {
        private int _maChiTietHoaDon;
        private float _tongTien;
        private float _giamGia;
        private int _maHoaDon;
        private int _maSP;

        public int MaChiTietHoaDon
        {
            get { return _maChiTietHoaDon; }
            set { _maChiTietHoaDon = value; }
        }

        public float TongTien
        {
            get { return _tongTien; }
            set { _tongTien = value; }
        }

        public float GiamGia
        {
            get { return _giamGia; }
            set { _giamGia = value; }
        }

        public int MaHoaDon
        {
            get { return _maHoaDon; }
            set { _maHoaDon = value; }
        }

        public int MaSP
        {
            get { return _maSP; }
            set { _maSP = value; }
        }
    }
}
