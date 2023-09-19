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

    }
}
