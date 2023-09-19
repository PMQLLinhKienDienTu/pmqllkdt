using DAL;
using DTO;
using System.Data;
using System.Xml.Linq;

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
        public string[] DanhSachSLNameSP()
        {
            return dalsanpham.DanhSachSLNameSP();
        }
        public double LayGiaSP(string name)
        {
            return dalsanpham.LayGiaSP(name);
        }
        public int GetProductId(string name) 
        {
            return dalsanpham.GetProductId(name);
        }
            

    }
}
