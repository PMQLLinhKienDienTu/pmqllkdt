using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NhapHang
    {
        private int _manhanhang;
        private DateTime _ngaynhan;
        private int _nhanhanvien;
        private int _manhacungcap;

        private double _thanhtien;

        public int Manhanhang { get => _manhanhang; set => _manhanhang = value; }
        public DateTime Ngaynhan { get => _ngaynhan; set => _ngaynhan = value; }
        public int Nhanhanvien { get => _nhanhanvien; set => _nhanhanvien = value; }
        public int Manhacungcap { get => _manhacungcap; set => _manhacungcap = value; }
        public double Thanhtien { get => _thanhtien; set => _thanhtien = value; }

        public DTO_NhapHang() { }

        public DTO_NhapHang(int manv, int mancc, double thanhtien) 
        { 
            this.Nhanhanvien= manv;
            this.Manhacungcap= mancc;
            this.Thanhtien = thanhtien;
        }
    }
}
