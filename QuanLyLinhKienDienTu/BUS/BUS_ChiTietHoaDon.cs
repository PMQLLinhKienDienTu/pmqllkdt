﻿
using DAL;
using DTO;
using System.Data;
namespace BUS
{
    public class BUS_ChiTietHoaDon
    {
        DAL_ChiTietHoaDon dalchitiethoadon = new DAL_ChiTietHoaDon();

        public DataTable DanhSachCTHoaDon()
        {
            return dalchitiethoadon.DanhSachCTHoaDon();
        }
        public bool ThemCTHoaDon(DTO_ChiTietHoaDon billInfo)
        {
            return dalchitiethoadon.ThemCTHoaDon(billInfo);
        }
        public double GetTotalPrice()
        {
            return dalchitiethoadon.GetTotalPrice();
        }
        public bool XoaSanPhamCTHoaDon(int id)
        {
            return dalchitiethoadon.XoaSanPhamCTHoaDon(id);
        }
        public bool SuaSanPhamCTHoaDon(int id, int quantity)
        {
            return dalchitiethoadon.SuaSanPhamCTHoaDon(id, quantity);
        }
        public DataTable LayThongTinChiTietHoaDonSanPham()
        {
            return dalchitiethoadon.LayThongTinChiTietHoaDonSanPham();
        }
        public DataTable ThongTinNhapKho()
        {
            return dalchitiethoadon.ThongTinNhapKho();
        }
        public bool UpdateTrangThaiCTHoaDon()
        {
            return dalchitiethoadon.UpdateTrangThaiCTHoaDon();
        }
        public bool KiemTraMatHangTrung(int id, int soluong)
        {
            return dalchitiethoadon.KiemTraMatHangTrung(id, soluong);
        }
    }
}
