using DAL;
using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BUS
{
    public class BUS_PhanLoaiSanPham 
    {
        DAL_PhanLoaiSanPham dalphanloaisp = new DAL_PhanLoaiSanPham();

        public DataTable DanhSachLoaiSP()
        {
            return dalphanloaisp.DanhSachLoaiSP();
        }
        public bool ThemLoaiSP(DTO_PhanLoaiSanPham loai)
        {
            return dalphanloaisp.ThemLoaiSP(loai);
        }
        public bool SuaLoaiSP(DTO_PhanLoaiSanPham loai)
        {
            return dalphanloaisp.SuaLoaiSP(loai);
        }
        public bool XoaLoaiSP(int id)
        {
            return dalphanloaisp.XoaLoaiSP(id);
        }
        public int LayIDLoaiSP(string name)
        {
            return dalphanloaisp.LayIDLoaiSP(name);
        }
        public string[] DanhsachNameIDLoai()
        {
            return dalphanloaisp.DanhsachNameIDLoai();
        }
    }
}
