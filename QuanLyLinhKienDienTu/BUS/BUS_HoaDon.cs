using DAL;
using DTO;
using System.Data;
namespace BUS
{
    public class BUS_HoaDon
    {
        DAL_HoaDon dalhoadon = new DAL_HoaDon();

        public DataTable DanhSachHoaDon()
        {
            return dalhoadon.DanhSachHoaDon();
        }
        public bool ThemHoaDon(DTO_HoaDon hoadon)
        {
            return dalhoadon.ThemHoaDon(hoadon);
        }
        public double DoanhThuTheoNgay()
        {
            return dalhoadon.DoanhThuTheoNgay();

        }
        public int SoDonHang()
        {
            return dalhoadon.SoDonHang();
        }
        public int SoSanPhamBan()
        {
            return dalhoadon.SoSanPhamBan();
        }
        public DataTable TimKiemNgayHoaDon(string ngay)
        {
            return dalhoadon.TimKiemNgayHoaDon(ngay);
        }
        public string TopKhachHang()
        {
            return dalhoadon.TopKhachHang();
        }
        public string TopNhanVienWithTotal()
        {
            return dalhoadon.TopNhanVienWithTotal();
        }
        public string TinhTongDoanhThuSoVoiThangTruoc()
        {
            return dalhoadon.TinhTongDoanhThuSoVoiThangTruoc();
        }
        public string TinhTongDoanhThu()
        {
            return dalhoadon.TinhTongDoanhThu();
        }
        public double HoaDonThang1()
        {
            return dalhoadon.HoaDonThang1();
        }
        public double HoaDonThang2()
        {
            return dalhoadon.HoaDonThang2();
        }
        public double HoaDonThang3()
        {
            return dalhoadon.HoaDonThang3();
        }
        public double HoaDonThang4()
        {
            return dalhoadon.HoaDonThang4();
        }
        public double HoaDonThang5()
        {
            return dalhoadon.HoaDonThang5();
        }
        public double HoaDonThang6()
        {
            return dalhoadon.HoaDonThang6();
        }
        public double HoaDonThang7()
        {
            return dalhoadon.HoaDonThang7();
        }
        public double HoaDonThang8()
        {
            return dalhoadon.HoaDonThang8();
        }
        public double HoaDonThang9()
        {
            return dalhoadon.HoaDonThang9();
        }
        public double HoaDonThang10()
        {
            return dalhoadon.HoaDonThang10();
        }
        public double HoaDonThang11()
        {
            return dalhoadon.HoaDonThang11();
        }
        public double HoaDonThang12()
        {
            return dalhoadon.HoaDonThang12();
        }
    }
}
