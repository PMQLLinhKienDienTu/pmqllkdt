
using System.Runtime.InteropServices;

namespace DTO
{
    public class DTO_SanPham
    {
        private int _maSP;
        private string _tenSP;
        private int _soLuong;
        private double _giaNhap;
        private double _giaBan;
        private int _tGBaoHanh;
        private byte[] _hinhAnh;
        private int _maPhanLoai;
        private string _ghichu;
       

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
        public string Ghichu
        {
            get { return _ghichu; }
            set { _ghichu = value; }
        }

        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }

        public double GiaNhap
        {
            get { return _giaNhap; }
            set { _giaNhap = value; }
        }

        public double GiaBan
        {
            get { return _giaBan; }
            set { _giaBan = value; }
        }

        public int TGBaoHanh
        {
            get { return _tGBaoHanh; }
            set { _tGBaoHanh = value; }
        }

        public byte[] HinhAnh
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

        public DTO_SanPham(string tensp, int soluong, double gianhap, double giaban, byte[] hinhanh, int loai, string ghichu) 
        {
            this.TenSP= tensp;
            this.SoLuong= soluong;
            this.GiaNhap= gianhap;
            this.GiaBan= giaban;
            this.HinhAnh= hinhanh;
            this.MaPhanLoai= loai;
            this.Ghichu= ghichu;
        }
        public DTO_SanPham(int id, string tensp, int soluong, double gianhap, double giaban, byte[] hinhanh, int loai, string ghichu)
        {
            this.MaSP= id;
            this.TenSP = tensp;
            this.SoLuong = soluong;
            this.GiaNhap = gianhap;
            this.GiaBan = giaban;
            this.HinhAnh = hinhanh;
            this.MaPhanLoai = loai;
            this.Ghichu = ghichu;
        }
    }
}
