using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietNhapHang
    {
        private string _mactnhhap;
        private int _masanpham;
        private int _soluongnhap;
        private float _gianhap;

        public string Mactnhhap { get => _mactnhhap; set => _mactnhhap = value; }
        public int Masanpham { get => _masanpham; set => _masanpham = value; }
        public int Soluongnhap { get => _soluongnhap; set => _soluongnhap = value; }
        public float Gianhap { get => _gianhap; set => _gianhap = value; }

        public DTO_ChiTietNhapHang() { }
        public DTO_ChiTietNhapHang(int masp, int soluongnhap,float gianhap) 
        {
            this.Masanpham = masp;
            this.Soluongnhap= soluongnhap;
            this.Gianhap= gianhap;
        }
        public DTO_ChiTietNhapHang(int masp, int soluongnhap)
        {
            this.Masanpham = masp;
            this.Soluongnhap = soluongnhap;
        }
    }
}
