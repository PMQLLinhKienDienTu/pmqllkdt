using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BUS
{
    public class BUS_NhaCungCap
    {
        DAL_NhaCungCap nhacungcap = new DAL_NhaCungCap();

        public List<NhaCungCap> LoadNhaCungCap()
        {
            return nhacungcap.LoadNhaCungCap();
        }
        public bool ThemNCC(string tenNCC, string diachi, string email, string sdt)
        {
            return nhacungcap.ThemNCC(tenNCC, diachi, email, sdt);
        }
        public bool SuaNCC(int mancc, string tenNCC, string diachi, string email, string sdt)
        {
            return nhacungcap.SuaNCC(mancc, tenNCC, diachi, email, sdt);
        }
        public bool XoaNCC(int mancc)
        {
            return nhacungcap.XoaNCC(mancc);
        }
    }
}
