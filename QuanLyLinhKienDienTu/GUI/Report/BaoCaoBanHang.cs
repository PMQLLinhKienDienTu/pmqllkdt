using BUS;
using DAL;
using DevExpress.Utils.Extensions;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
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
        BUS_HoaDon hoadon = new BUS_HoaDon();
        BUS_NhanVien busEmployee = new BUS_NhanVien();
        private char separator = '|';
        private string[] strlist;
        private string strnv, strkh, kh, taikhoan, time;
        private int ma_cthd;
        public BaoCaoBanHang(int ma_cthd, string taikhoan)
        {
            this.ma_cthd = ma_cthd;
            this.taikhoan = taikhoan;
            InitializeComponent();
            load_BaoCao();
            
        }
        public BaoCaoBanHang(string taikhoan, string kh, string time)
        {
            this.taikhoan = taikhoan;
            this.kh = kh;
            this.time = time;
            InitializeComponent();
            load_BaoCao();

        }
        private void load_BaoCao()
        {
            DataTable data = cthd.LayThongTinChiTietHoaDonSanPham();
            //DataRow row = data.Rows[0];
            List<string> tenSanPhamList = new List<string>();
            List<int> soLuongList = new List<int>();
            List<double> donGiaList = new List<double>();
            List<double> thanhTienList = new List<double>();
            double sum = 0;
            int taoma = 0;
            foreach (DataRow row in data.Rows)
            {
                string tenSanPham = row["TenSP"].ToString();
                int soluong = int.Parse(row["SoLuong"].ToString());
                int ma_hd = int.Parse(row["MaChiTietHoaDon"].ToString());
                double dongia = double.Parse(row["GiaBan"].ToString());
                double thanhtien = double.Parse(row["Gia"].ToString());
                sum += thanhtien;
                taoma += ma_hd;
                

                tenSanPhamList.Add(tenSanPham);
                soLuongList.Add(soluong);
                donGiaList.Add(dongia);
                thanhTienList.Add(thanhtien);
            }
            string tenSanPhamString = String.Join(",", tenSanPhamList.ToArray());
            tenSanPhamString = tenSanPhamString.Replace(",", "\n\n");

            string soluongstring = String.Join(",", soLuongList.ToArray());
            soluongstring = soluongstring.Replace(",", "\n\n");

            string dongiastring = String.Join(",", donGiaList.ToArray());
            dongiastring = dongiastring.Replace(",", "\n\n");

            string thanhtienstring = String.Join(",", thanhTienList.ToArray());
            thanhtienstring = thanhtienstring.Replace(",", "\n\n");

            this.Parameters["TenSanPham"].Value = tenSanPhamString;
            this.Parameters["SoLuong"].Value = soluongstring;
            this.Parameters["DonGia"].Value = dongiastring;
            this.Parameters["ThanhTien"].Value = thanhtienstring;
            this.Parameters["TienThanhToan"].Value = sum.ToString("C");
            this.Parameters["NgayTH"].Value = time.ToString();
            this.Parameters["SoHD"].Value = taoma;

            strkh = kh;
            if (strkh != null)
            {

                strlist = strkh.Split(separator);
                //label_maKH.Text = "KH: " + strlist[0];
                //label_tenKH.Text = strlist[1];
                this.Parameters["KhachHang"].Value = strlist[1];
            }
            // Lấy dữ liệu từ các cột trong hàng đầu tiên
            // Ví dụ: giả sử có một cột "TenSanPham" trong DataTable

            //int mahd = int.Parse(row["MaChiTietHoaDon"].ToString());

            string rootDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location); // Thư mục gốc hiện tại
            rootDir = Directory.GetParent(rootDir).Parent.FullName; // Lấy thư mục cha của thư mục cha, tức thư mục GUI
            string relativePath = @"ImagesShop\icon_shop.jpg"; // Đường dẫn tương đối
            string path = Path.Combine(rootDir, relativePath); // Đường dẫn đích

            string rootDir2 = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location); // Thư mục gốc hiện tại
            rootDir2 = Directory.GetParent(rootDir2).Parent.FullName; // Lấy thư mục cha của thư mục cha, tức thư mục GUI
            string relativePath2 = @"ImageSIUUUUUU\heart.png"; // Đường dẫn tương đối
            string path2 = Path.Combine(rootDir2, relativePath2);



            this.Parameters["LogoShop"].Value = path;
            this.Parameters["icon"].Value = path2;

            strnv = busEmployee.LayNameChucVuNhanVien(taikhoan);

            if (strnv != null)
            {
                strlist = strnv.Split(separator);
                this.Parameters["TenNhanVien"].Value = strlist[0].Trim();
            }
        }

    }
}
