using BUS;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace GUI.Report
{
    public partial class BaoCaoNhapKho : DevExpress.XtraReports.UI.XtraReport
    {
        BUS_ChiTietHoaDon cthd = new BUS_ChiTietHoaDon();
        BUS_NhanVien busEmployee = new BUS_NhanVien();
        private char separator = '|';
        private string[] strlist;
        private string strnv, taikhoan, ncc;
        private int ma;
        public BaoCaoNhapKho(int ma, string taikhoan, string ncc)
        {
            this.ma = ma;
            this.taikhoan = taikhoan;
            this.ncc = ncc;
            InitializeComponent();
            load_BaoCao();
        }
        private void load_BaoCao()
        {
            DataTable data = cthd.ThongTinNhapKho(ma);
            DataRow row = data.Rows[0];

            // Lấy dữ liệu từ các cột trong hàng đầu tiên
            // Ví dụ: giả sử có một cột "TenSanPham" trong DataTable
            strnv = busEmployee.LayNameChucVuNhanVien(taikhoan);

            if (strnv != null)
            {
                strlist = strnv.Split(separator);
                this.Parameters["TenNhanVien"].Value = strlist[0].Trim();
            }

            string tenSanPham = row["TenSP"].ToString();
            int soluongnhap = int.Parse(row["SoLuongNhap"].ToString());
            double dongia = double.Parse(row["GiaNhap"].ToString());
            int mahd = int.Parse(row["MaNhap"].ToString());
            double tongtien = double.Parse(soluongnhap.ToString()) * dongia;

            string rootDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location); // Thư mục gốc hiện tại
            rootDir = Directory.GetParent(rootDir).Parent.FullName; // Lấy thư mục cha của thư mục cha, tức thư mục GUI
            string relativePath = @"ImagesShop\icon_shop.jpg"; // Đường dẫn tương đối
            string path = Path.Combine(rootDir, relativePath); // Đường dẫn đích

            this.Parameters["TenSanPham"].Value = tenSanPham;
            this.Parameters["SoLuong"].Value = soluongnhap;
            this.Parameters["DonGia"].Value = dongia.ToString("C");
            this.Parameters["ThanhTien"].Value = tongtien.ToString("C");
            this.Parameters["SoHD"].Value = mahd;
            this.Parameters["TenNhaCC"].Value = ncc;
            this.Parameters["LogoShop"].Value = path;

        }

    }
}
