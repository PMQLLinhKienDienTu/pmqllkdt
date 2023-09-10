
namespace DTO
{
    public class DTO_SanPham
    {
        private int _maSP;
        private string _tenSP;
        private int _soLuong;
        private float _giaNhap;
        private float _giaBan;
        private int _tGBaoHanh;
        private string _hinhAnh;
        private int _maPhanLoai;

        public int MaSP
        {
            get { return _maSP; }
            set { _maSP = value; }
        }

        public string TenSP
        {
            get { return _tenSP; }
            set { _tenSP = value; }
        }

        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }

        public float GiaNhap
        {
            get { return _giaNhap; }
            set { _giaNhap = value; }
        }

        public float GiaBan
        {
            get { return _giaBan; }
            set { _giaBan = value; }
        }

        public int TGBaoHanh
        {
            get { return _tGBaoHanh; }
            set { _tGBaoHanh = value; }
        }

        public string HinhAnh
        {
            get { return _hinhAnh; }
            set { _hinhAnh = value; }
        }

        public int MaPhanLoai
        {
            get { return _maPhanLoai; }
            set { _maPhanLoai = value; }
        }



        public DTO_SanPham() { }


    }
}
