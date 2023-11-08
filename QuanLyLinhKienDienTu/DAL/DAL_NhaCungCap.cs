using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NhaCungCap
    {
        QLLKDTDataContext qllinhkien = new QLLKDTDataContext();

        //Danh sách nhà cung cấp
        public List<NhaCungCap> LoadNhaCungCap()
        {
            List<NhaCungCap> nhaCungCapList = new List<NhaCungCap>();
            var query = from ncc in qllinhkien.NhaCungCaps
                        select ncc;
            nhaCungCapList = query.ToList();
            return nhaCungCapList;
        }

        //Thêm nhà cung cấp
        public bool ThemNCC(string tenNCC, string diachi, string email, string sdt)
        {
            NhaCungCap ncc = new NhaCungCap();
            ncc.TenNCC = tenNCC;
            ncc.DiaChi = diachi;
            ncc.Email = email;
            ncc.Sdt = sdt;

            try
            {
                qllinhkien.NhaCungCaps.InsertOnSubmit(ncc);
                qllinhkien.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Sửa nhà cung cấp
        public bool SuaNCC(int mancc, string tenNCC, string diachi, string email, string sdt)
        {
            NhaCungCap suaNCC = qllinhkien.NhaCungCaps.Where(ncc => ncc.MaNCC == mancc).FirstOrDefault();

            if (suaNCC != null)
            {
                suaNCC.TenNCC = tenNCC;
                suaNCC.DiaChi = diachi;
                suaNCC.Email = email;
                suaNCC.Sdt = sdt;
                qllinhkien.SubmitChanges();
                return true;
            }
            return false;
        }

        //Xóa nhà cung cấp
        public bool XoaNCC(int mancc)
        {
            NhaCungCap xoaNCC = qllinhkien.NhaCungCaps.Where(ncc => ncc.MaNCC == mancc).FirstOrDefault();
            if (xoaNCC != null)
            {
                qllinhkien.NhaCungCaps.DeleteOnSubmit(xoaNCC);
                qllinhkien.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
