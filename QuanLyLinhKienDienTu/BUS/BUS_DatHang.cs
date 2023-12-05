using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;
namespace BUS
{
    public class BUS_DatHang
    {
        DAL_DatHang daldathang = new DAL_DatHang();
        public DataTable DanhSachCTDatHang()
        {
            return daldathang.DanhSachCTDatHang();
        }
        public bool CapNhapTrangThaiDatHang(int id)
        {
            return daldathang.CapNhapTrangThaiDatHang(id);
        }
        public bool HuyDonDatHang(int madathang)
        {
            return daldathang.HuyDonDatHang(madathang);
        }
        public DataTable TimKiemKhachHangDatHang(string hoten)
        {
            return daldathang.TimKiemKhachHangDatHang(hoten);
        }
    }
}
