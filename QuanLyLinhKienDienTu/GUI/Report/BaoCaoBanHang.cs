using BUS;
using DevExpress.XtraCharts;
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
    public partial class BaoCaoBanHang : DevExpress.XtraReports.UI.XtraReport
    {
        BUS_ChiTietHoaDon cthd = new BUS_ChiTietHoaDon();
        BUS_NhanVien busEmployee = new BUS_NhanVien();
        private char separator = '|';
        private string[] strlist;
        private string strnv, taikhoan;
        private int ma_cthd;
        public BaoCaoBanHang(int ma_cthd, string taikhoan)
        {
            this.ma_cthd = ma_cthd;
            this.taikhoan = taikhoan;
            InitializeComponent();
            load_BaoCao();
            
        }
        private void load_BaoCao()
        {
            DataTable data = cthd.LayThongTinChiTietHoaDonSanPham(ma_cthd);
            DataRow row = data.Rows[0];

            // Lấy dữ liệu từ các cột trong hàng đầu tiên
            // Ví dụ: giả sử có một cột "TenSanPham" trong DataTable
            string tenSanPham = row["TenSP"].ToString();
            int soluong = int.Parse(row["SoLuong"].ToString());
            double dongia = double.Parse(row["GiaBan"].ToString());
            double thanhtien = double.Parse(row["Gia"].ToString());
            int mahd = int.Parse(row["MaChiTietHoaDon"].ToString());

            string rootDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location); // Thư mục gốc hiện tại
            rootDir = Directory.GetParent(rootDir).Parent.FullName; // Lấy thư mục cha của thư mục cha, tức thư mục GUI
            string relativePath = @"ImagesShop\icon_shop.jpg"; // Đường dẫn tương đối
            string path = Path.Combine(rootDir, relativePath); // Đường dẫn đích

            DateTime ngayth = (DateTime)row["NgayTH"]; // Chuyển đổi từ object sang DateTime
            string ngay = ngayth.ToString("dd/MM/yyyy");
            this.Parameters["TenSanPham"].Value = tenSanPham;
            this.Parameters["SoLuong"].Value = soluong;
            this.Parameters["DonGia"].Value = dongia.ToString("C");
            this.Parameters["ThanhTien"].Value = thanhtien.ToString("C");
            this.Parameters["SoHD"].Value = mahd;
            this.Parameters["NgayTH"].Value = ngay;
            this.Parameters["LogoShop"].Value = path;

            strnv = busEmployee.LayNameChucVuNhanVien(taikhoan);

            if (strnv != null)
            {
                strlist = strnv.Split(separator);
                this.Parameters["TenNhanVien"].Value = strlist[0].Trim();
            }
        }

    }
}
