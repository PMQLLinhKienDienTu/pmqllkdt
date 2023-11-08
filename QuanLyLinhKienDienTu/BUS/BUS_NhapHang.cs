using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BUS
{
   public class BUS_NhapHang
    {
       DAL_NhapHang nhaphang = new DAL_NhapHang();


        public bool ThemPhieuNhap(DTO_NhapHang nhanhangs)
        {
            return nhaphang.ThemPhieuNhap(nhanhangs);
        }
    }
}
