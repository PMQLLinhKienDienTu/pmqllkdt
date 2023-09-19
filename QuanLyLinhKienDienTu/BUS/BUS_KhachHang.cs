using DAL;
using DTO;
using System.Data;
namespace BUS
{
    public class BUS_KhachHang
    {
        DAL_KhachHang dalKhachHang = new DAL_KhachHang();

        public DataTable DanhSachKhachHang()
        {
            return dalKhachHang.DanhSachKhachHang();
        }
        public bool ThemKhachHang(DTO_KhachHang khachHang)
        {
            return dalKhachHang.ThemKhachHang(khachHang);
        }
        public bool SuaKhachHang(DTO_KhachHang khachHang)
        {
            return dalKhachHang.SuaKhachHang(khachHang);
        }
        public bool XoaKhachHang(int id)
        {
            return dalKhachHang.XoaKhachHang(id);
        }
        public DataTable TimKiemKhachHang(string hoten)
        {
            return dalKhachHang.TimKiemKhachHang(hoten);
        }
        public string[] DanhSachKHtheoIDName()
        {
            return dalKhachHang.DanhSachKHtheoIDName();
        }
    }
}
