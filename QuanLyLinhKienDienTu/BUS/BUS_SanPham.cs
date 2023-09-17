using DAL;
using DTO;
using System.Data;

namespace BUS
{
    public class BUS_SanPham
    {
        DAL_SanPham dalsanpham = new DAL_SanPham();

        public DataTable DanhSachSanPham()
        {
            return dalsanpham.DanhSachSanPham();
        }

        public bool ThemSanPham(DTO_SanPham sp)
        {
            return dalsanpham.ThemSanPham(sp);
        }
        public bool SuaSanPham(DTO_SanPham sp)
        {
            return dalsanpham.SuaSanPham(sp);
        }
        public bool XoaSanPham(int id)
        {
            return dalsanpham.XoaSanPham(id);
        }
        public DataTable TimKiemSanPham(string hoten)
        {
            return dalsanpham.TimKiemSanPham(hoten);
        }

    }
}
