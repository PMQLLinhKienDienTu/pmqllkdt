using BUS;
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
    public partial class BaoCaoNhapKho : DevExpress.XtraReports.UI.XtraReport
    {
        BUS_ChiTietHoaDon cthd = new BUS_ChiTietHoaDon();
        BUS_NhanVien busEmployee = new BUS_NhanVien();
        private char separator = '|';
        private string[] strlist;
        private string strnv, taikhoan, ncc, time;
        private int ma;
        public BaoCaoNhapKho(int ma, string taikhoan, string ncc)
        {
            this.ma = ma;
            this.taikhoan = taikhoan;
            this.ncc = ncc;
            InitializeComponent();
            load_BaoCao();
        }
        public BaoCaoNhapKho( string taikhoan, string ncc, string time)
        {
            this.taikhoan = taikhoan;
            this.ncc = ncc;
            this.time = time;
            InitializeComponent();
            load_BaoCao();
        }
        private void load_BaoCao()
        {
            DataTable data = cthd.ThongTinNhapKho();

            List<string> tenSanPhamList = new List<string>();
            List<int> soLuongList = new List<int>();
            List<double> donGiaList = new List<double>();
            List<double> thanhTienList = new List<double>();
            double sum = 0;
            int taoma = 0;
            foreach (DataRow row in data.Rows)
            {
                string tenSanPham = row["TenSP"].ToString();
                int soluongnhap = int.Parse(row["SoLuongNhap"].ToString());
                double dongia = double.Parse(row["GiaNhap"].ToString());
                double tongtien = double.Parse(soluongnhap.ToString()) * dongia;
                int manhap = int.Parse(row["MaNhap"].ToString());
                sum += tongtien;
                taoma += manhap;


                tenSanPhamList.Add(tenSanPham);
                soLuongList.Add(soluongnhap);
                donGiaList.Add(dongia);
                thanhTienList.Add(tongtien);
            }

            // Lấy dữ liệu từ các cột trong hàng đầu tiên
            // Ví dụ: giả sử có một cột "TenSanPham" trong DataTable
            strnv = busEmployee.LayNameChucVuNhanVien(taikhoan);

            if (strnv != null)
            {
                strlist = strnv.Split(separator);
                this.Parameters["TenNhanVien"].Value = strlist[0].Trim();
            }

            
            //int mahd = int.Parse(row["MaNhap"].ToString());
            

            string rootDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location); // Thư mục gốc hiện tại
            rootDir = Directory.GetParent(rootDir).Parent.FullName; // Lấy thư mục cha của thư mục cha, tức thư mục GUI
            string relativePath = @"ImagesShop\icon_shop.jpg"; // Đường dẫn tương đối
            string path = Path.Combine(rootDir, relativePath); // Đường dẫn đích

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
            this.Parameters["Sum"].Value = sum.ToString("C");
            this.Parameters["SoHD"].Value = taoma;
            this.Parameters["TenNhaCC"].Value = ncc;
            this.Parameters["LogoShop"].Value = path;
            this.Parameters["NgayTH"].Value = time;
        }

    }
}
