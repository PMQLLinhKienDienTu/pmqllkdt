using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
   public class BUS_ChiTietNhapHang
    {
       DAL_ChiTietNhapHang ctnhaphang = new DAL_ChiTietNhapHang();

        public DataTable DanhSachCTNhapHang()
        {
            return ctnhaphang.DanhSachCTNhapHang();
        }

        public bool ThemCTNhapHang(DTO_ChiTietNhapHang hang)
        {
            return ctnhaphang.ThemCTNhapHang(hang);
        }
        public bool SuaCTNhapHang(DTO_ChiTietNhapHang hang)
        {
            return ctnhaphang.SuaCTNhapHang(hang);
        }
        public bool XoaCTNhapHang(int ma)
        {
            return ctnhaphang.XoaCTNhapHang(ma);
        }

        public double GetTongTienNhapHang()
        {
            return ctnhaphang.GetTongTienNhapHang();
        }
        public bool KiemTraNhapHangTrung(int id, int soluong)
        {
            return ctnhaphang.KiemTraNhapHangTrung(id,soluong);
        }
    }
}
