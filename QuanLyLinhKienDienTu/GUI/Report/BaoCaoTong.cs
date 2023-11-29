using BUS;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace GUI
{
    public partial class BaoCaoTong : DevExpress.XtraReports.UI.XtraReport
    {
        
        BUS_HoaDon hoadon = new BUS_HoaDon();
        BUS_NhanVien busEmployee = new BUS_NhanVien();
        private XtraReport report;
        private char separator = '|';
        private string[] strlist, strlistnv1;
        private string strnv, strkh, strnv1;
        private string taikhoan, index;
        public BaoCaoTong(string taikhoan,string index)
        {
            this.taikhoan = taikhoan;
            this.index = index;
            InitializeComponent();
            Load_Report();
        }
        private void SetTable()
        {
            tbTong.Visible = false;
            tbQuy1.Visible = false;
            tbQuy11.Visible = false;
            tbQuy2.Visible = false;
            tbQuy3.Visible = false;
            tbQuy4.Visible = false;
        }
        public void Load_Report()
        {
            report = new XtraReport();

            strnv = busEmployee.LayNameChucVuNhanVien(taikhoan);
            
            if (strnv != null)
            {
                strlist = strnv.Split(separator);
                this.Parameters["TenNhanVien"].Value = strlist[0].Trim();
            }
            strkh = hoadon.TopKhachHang();
            if (strkh != null)
            {
                
                strlist = strkh.Split(separator);
                //label_maKH.Text = "KH: " + strlist[0];
                //label_tenKH.Text = strlist[1];
                this.Parameters["TopKhachHang"].Value = strlist[1];
            }
            strnv1 = hoadon.TopNhanVienWithTotal();
            
            if (strnv1 != null)
            {
                strlistnv1 = strnv1.Split(separator);
                this.Parameters["TopNhanVien"].Value = strlistnv1[1];
            }
            SetTable();
            if (index == "1")
            {
                tbQuy11.Visible = true;
                this.Parameters["Quy"].Value = "QUÝ 1";
                this.Parameters["TienThang1"].Value = hoadon.HoaDonThang1().ToString("C");
                this.Parameters["TienThang2"].Value = hoadon.HoaDonThang2().ToString("C");
                this.Parameters["TienThang3"].Value = hoadon.HoaDonThang3().ToString("C");
                double tong = hoadon.HoaDonThang1() + hoadon.HoaDonThang2() + hoadon.HoaDonThang3();
                this.Parameters["TongDoanhThu"].Value = tong.ToString("C");
            }
            else if (index == "2")
            {
                tbQuy2.Visible = true;
                this.Parameters["Quy"].Value = "QUÝ 2";
                this.Parameters["TienThang4"].Value = hoadon.HoaDonThang4().ToString("C");
                this.Parameters["TienThang5"].Value = hoadon.HoaDonThang5().ToString("C");
                this.Parameters["TienThang6"].Value = hoadon.HoaDonThang6().ToString("C");
                double tong = hoadon.HoaDonThang4() + hoadon.HoaDonThang5() + hoadon.HoaDonThang6();
                this.Parameters["TongDoanhThu"].Value = tong.ToString("C");
            }
            else if (index == "3")
            {
                tbQuy3.Visible = true;
                this.Parameters["Quy"].Value = "QUÝ 3";
                this.Parameters["TienThang7"].Value = hoadon.HoaDonThang7().ToString("C");
                this.Parameters["TienThang8"].Value = hoadon.HoaDonThang8().ToString("C");
                this.Parameters["TienThang9"].Value = hoadon.HoaDonThang9().ToString("C");
                double tong = hoadon.HoaDonThang7() + hoadon.HoaDonThang8() + hoadon.HoaDonThang9();
                this.Parameters["TongDoanhThu"].Value = tong.ToString("C");
            }
            else if (index == "4")
            {
                tbQuy4.Visible = true;
                this.Parameters["Quy"].Value = "QUÝ 4";
                this.Parameters["TienThang10"].Value = hoadon.HoaDonThang10().ToString("C");
                this.Parameters["TienThang11"].Value = hoadon.HoaDonThang11().ToString("C");
                this.Parameters["TienThang12"].Value = hoadon.HoaDonThang12().ToString("C");
                double tong = hoadon.HoaDonThang10() + hoadon.HoaDonThang11() + hoadon.HoaDonThang12();
                this.Parameters["TongDoanhThu"].Value = tong.ToString("C");
            }
            else
            {
                tbTong.Visible = true;
                int currentYear = DateTime.Now.Year;
                string yearString = currentYear.ToString();
                this.Parameters["Quy"].Value = "NĂM "+yearString;
                this.Parameters["TienThang1"].Value = hoadon.HoaDonThang1().ToString("C");
                this.Parameters["TienThang2"].Value = hoadon.HoaDonThang2().ToString("C");
                this.Parameters["TienThang3"].Value = hoadon.HoaDonThang3().ToString("C");
                this.Parameters["TienThang4"].Value = hoadon.HoaDonThang4().ToString("C");
                this.Parameters["TienThang5"].Value = hoadon.HoaDonThang5().ToString("C");
                this.Parameters["TienThang6"].Value = hoadon.HoaDonThang6().ToString("C");
                this.Parameters["TienThang7"].Value = hoadon.HoaDonThang7().ToString("C");
                this.Parameters["TienThang8"].Value = hoadon.HoaDonThang8().ToString("C");
                this.Parameters["TienThang9"].Value = hoadon.HoaDonThang9().ToString("C");
                this.Parameters["TienThang10"].Value = hoadon.HoaDonThang10().ToString("C");
                this.Parameters["TienThang11"].Value = hoadon.HoaDonThang11().ToString("C");
                this.Parameters["TienThang12"].Value = hoadon.HoaDonThang12().ToString("C");
                this.Parameters["TongDoanhThu"].Value = double.Parse(hoadon.TinhTongDoanhThu()).ToString("C");
            }

            string rootDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location); // Thư mục gốc hiện tại
            rootDir = Directory.GetParent(rootDir).Parent.FullName; // Lấy thư mục cha của thư mục cha, tức thư mục GUI
            string relativePath = @"ImagesShop\icon_shop.jpg"; // Đường dẫn tương đối
            string path = Path.Combine(rootDir, relativePath); // Đường dẫn đích

            this.Parameters["LogoShop"].Value = path;
            System.DateTime date = System.DateTime.Now;
            this.Parameters["time"].Value = date.ToString("dd/MM/yyyy") + " " + date.ToString("HH:mm:ss");
            this.Parameters["LogoShop"].Visible = false;
        }
    }
}
