
namespace DTO
{
    public class DTO_PhanLoaiSanPham
    {
        private int _maPhanLoai;
        private string _tenPhanLoai;
        private string _nhaSanXuat;

        public int MaPhanLoai
        {
            get { return _maPhanLoai; }
            set { _maPhanLoai = value; }
        }

        public string TenPhanLoai
        {
            get { return _tenPhanLoai; }
            set { _tenPhanLoai = value; }
        }

        public string NhaSanXuat
        {
            get { return _nhaSanXuat; }
            set { _nhaSanXuat = value; }
        }
        public DTO_PhanLoaiSanPham() { }

        public DTO_PhanLoaiSanPham(string tenloai, string nhaSX) 
        {
            this.TenPhanLoai = tenloai;
            this.NhaSanXuat= nhaSX;
        }

        public DTO_PhanLoaiSanPham(int id, string tenloai, string nhaSX)
        {
            this.MaPhanLoai= id;
            this.TenPhanLoai = tenloai;
            this.NhaSanXuat = nhaSX;
        }

    }
}
