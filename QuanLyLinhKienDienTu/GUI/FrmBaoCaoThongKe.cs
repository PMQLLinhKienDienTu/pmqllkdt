using BUS;
using System;
using System.Data;
using System.Windows.Forms;
using Guna.Charts.WinForms;
using static GUI.FrmMain;

namespace GUI
{
    public partial class FrmBaoCaoThongKe : Form
    {
        private string[] strlist, strlistnv, strlistthongke;
        private char separator = '|';
        private string str, strnv, strthongke;

        BUS_HoaDon hoadon = new BUS_HoaDon();

        public FrmBaoCaoThongKe()
        {
            InitializeComponent();
            ColorChangeEventProvider.ColorChanged += ColorChangeEventProvider_ColorChanged;
        }
        private void ColorChangeEventProvider_ColorChanged(object sender, ColorChangedEventArgs e)
        {
            Guna.UI2.WinForms.Guna2Panel[] panels = { guna2Panel1, guna2Panel2, guna2Panel3, guna2Panel4, guna2Panel5 };

            foreach (var panel in panels)
            {
                panel.BackColor = e.NewColor;
            }
        }
        public void Bar(GunaChart chart)
        {
            try
            {
                //Cấu hình biểu đồ
                chart.YAxes.GridLines.Display = false;
                //Tạo dữ liệu mới
                var dataset = new GunaBarDataset();
                chtImportProduct.Datasets.Clear();

                if (cbbQuy.SelectedValue.ToString() == "1")
                {
                    dataset.DataPoints.Add("Tháng 1", hoadon.HoaDonThang1()).ToString("C");
                    dataset.DataPoints.Add("Tháng 2", hoadon.HoaDonThang2()).ToString("C");
                    dataset.DataPoints.Add("Tháng 3", hoadon.HoaDonThang3()).ToString("C");
                }
                else if (cbbQuy.SelectedValue.ToString() == "2")
                {
                    dataset.DataPoints.Add("Tháng 4", hoadon.HoaDonThang4()).ToString("C");
                    dataset.DataPoints.Add("Tháng 5", hoadon.HoaDonThang5()).ToString("C");
                    dataset.DataPoints.Add("Tháng 6", hoadon.HoaDonThang6()).ToString("C");
                }
                else if (cbbQuy.SelectedValue.ToString() == "3")
                {
                    dataset.DataPoints.Add("Tháng 7", hoadon.HoaDonThang7()).ToString("C");
                    dataset.DataPoints.Add("Tháng 8", hoadon.HoaDonThang8()).ToString("C");
                    dataset.DataPoints.Add("Tháng 9", hoadon.HoaDonThang9()).ToString("C");
                }
                else if (cbbQuy.SelectedValue.ToString() == "4")
                {
                    dataset.DataPoints.Add("Tháng 10", hoadon.HoaDonThang10()).ToString("C");
                    dataset.DataPoints.Add("Tháng 11", hoadon.HoaDonThang11()).ToString("C");
                    dataset.DataPoints.Add("Tháng 12", hoadon.HoaDonThang12()).ToString("C");
                }
                else
                {
                    dataset.DataPoints.Add("Tháng 1", hoadon.HoaDonThang1()).ToString("C");
                    dataset.DataPoints.Add("Tháng 2", hoadon.HoaDonThang2()).ToString("C");
                    dataset.DataPoints.Add("Tháng 3", hoadon.HoaDonThang3()).ToString("C");
                    dataset.DataPoints.Add("Tháng 4", hoadon.HoaDonThang4()).ToString("C");
                    dataset.DataPoints.Add("Tháng 5", hoadon.HoaDonThang5()).ToString("C");
                    dataset.DataPoints.Add("Tháng 6", hoadon.HoaDonThang6()).ToString("C");
                    dataset.DataPoints.Add("Tháng 7", hoadon.HoaDonThang7()).ToString("C");
                    dataset.DataPoints.Add("Tháng 8", hoadon.HoaDonThang8()).ToString("C");
                    dataset.DataPoints.Add("Tháng 9", hoadon.HoaDonThang9()).ToString("C");
                    dataset.DataPoints.Add("Tháng 10", hoadon.HoaDonThang10()).ToString("C");
                    dataset.DataPoints.Add("Tháng 11", hoadon.HoaDonThang11()).ToString("C");
                    dataset.DataPoints.Add("Tháng 12", hoadon.HoaDonThang12()).ToString("C");
                }
                dataset.Label = "Tổng tiền";
                // Thêm tập dữ liệu mới vào biểu đồ.Datasets
                chart.Datasets.Add(dataset);
                // Một bản cập nhật đã được thực hiện để hiển thị lại biểu đồ
                chart.Update();
            }
            catch (Exception){}
        }
        public void Barload(GunaChart chart)
        {
            //Cấu hình biểu đồ
            chart.YAxes.GridLines.Display = false;
            chart.Update();
        }
        private void FrmBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            LoadTopKhachHang();
            loadNhanVien();
            LoadDoanhThu();
            LoadTongDoanhThu();
            LoadComBobox();
            Bar(chtImportProduct);      
        }
        private void LoadComBobox()
        {
            try
            {
                DataTable quyTable = new DataTable();
                quyTable.Columns.Add("MaQuy", typeof(int));
                quyTable.Columns.Add("TenQuy", typeof(string));

                quyTable.Rows.Add(0, "All");
                quyTable.Rows.Add(1, "Quý 1");
                quyTable.Rows.Add(2, "Quý 2");
                quyTable.Rows.Add(3, "Quý 3");
                quyTable.Rows.Add(4, "Quý 4");

                DataView quyDataView = new DataView(quyTable);
                cbbQuy.DataSource = quyDataView;

                cbbQuy.DisplayMember = "TenQuy";
                cbbQuy.ValueMember = "MaQuy";
                cbbQuy.SelectedIndex = 0;
            }
            catch (Exception) { }        
        }
        private void btnlammoi_Click(object sender, EventArgs e)
        {
            Barload(chtImportProduct);
            FrmBaoCaoThongKe_Load(sender,e);
        }
        private void cbbQuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bar(chtImportProduct);
        }
        private void LoadTopKhachHang()
        {
            try
            {
                str = hoadon.TopKhachHang();
                strlist = str.Split(separator);
                if (str != null)
                {
                    label_maKH.Text = "KH: " + strlist[0];
                    label_tenKH.Text = strlist[1];
                }
                else
                {
                    label_maKH.Text = "Chưa cập nhập";
                    label_tenKH.Text = "Chưa cập nhập";
                }
            }
            catch (Exception) { }        
        }
        private void loadNhanVien()
        {
            try
            {
                strnv = hoadon.TopNhanVienWithTotal();
                strlistnv = strnv.Split(separator);
                if (strnv != null)
                {
                    label_manhanvien.Text = "NV: " + strlistnv[0];
                    label_tennhanvien.Text = strlistnv[1];
                }
                else
                {
                    label_manhanvien.Text = "Chưa cập nhập";
                    label_tennhanvien.Text = "Chưa cập nhập";
                }
            }
            catch (Exception) { }          
        }
        private void LoadDoanhThu()
        {
            try
            {
                strthongke = hoadon.TinhTongDoanhThuSoVoiThangTruoc();
                strlistthongke = strthongke.Split(separator);

                double danhthuhientai = double.Parse(strlistthongke[0]);
                double danhthuthangtruoc = double.Parse(strlistthongke[1]);

                double danhthusovoithangtruoc = danhthuhientai - danhthuthangtruoc;

                if (danhthusovoithangtruoc < 0)
                {
                    string tuot = Convert.ToString(danhthusovoithangtruoc);
                    label_doanhthuthangnay.Text = tuot;
                    giam.Visible = true;
                }
                else
                {
                    tang.Visible = true;
                    label_doanhthuthangnay.Text = Convert.ToString(danhthusovoithangtruoc.ToString("C"));
                }
            }
            catch (Exception) { }
        }
        private void LoadTongDoanhThu()
        {
            try
            {
                double tongdoanhthu = double.Parse(hoadon.TinhTongDoanhThu());
                label_tongdoanhthu.Text = Convert.ToString(tongdoanhthu.ToString("C"));
            }
            catch (Exception) { }
        }
    }
}
