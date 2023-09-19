
namespace DTO
{
    public class DTO_ChiTietHoaDon
    {
        private int _maChiTietHoaDon;
        private int _soluong;
        private double _gia;
        private int _maSP;

        public int MaChiTietHoaDon
        {
            get { return _maChiTietHoaDon; }
            set { _maChiTietHoaDon = value; }
        }
        public double Gia
        {
            get { return _gia; }
            set { _gia = value; }
        }

        public int SoLuong
        {
            get { return _soluong; }
            set { _soluong = value; }
        }

        public int MaSP
        {
            get { return _maSP; }
            set { _maSP = value; }
        }

        public DTO_ChiTietHoaDon() { }

        public DTO_ChiTietHoaDon(int masp, int soluong, double gia)
        {
            this.MaSP= masp;
            this.SoLuong= soluong;
            this.Gia= gia;
        }

    }
}
