using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmChiTietDonDatHang : Form
    {
        public FrmChiTietDonDatHang()
        {
            InitializeComponent();
        }
        private string jsonsanpham;
        public FrmChiTietDonDatHang(string jsonsanpham)
        {
            this.jsonsanpham = jsonsanpham;
            InitializeComponent();
        }
        public class Product
        {
            public int MaSP { get; set; }
            public string TenSP { get; set; }
            public int SoLuong { get; set; }
            public double DonGia { get; set; }
            public double ThanhTien { get; set; }
        }
        private void LoadJsonDataToDataGridView(string jsonData)
        {
            // Chuyển đổi chuỗi JSON thành danh sách đối tượng Product
            List<Product> productList = JsonConvert.DeserializeObject<List<Product>>(jsonData);

            // Gán danh sách đối tượng vào DataSource của DataGridView
            gvCTDatHang.DataSource = productList;
        }
        private void LoadGVCTDatHang()
        {
           

            foreach (DataGridViewColumn item in gvCTDatHang.Columns)
            {
                item.DividerWidth = 1;
            }

            gvCTDatHang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCTDatHang.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCTDatHang.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCTDatHang.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCTDatHang.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCTDatHang.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCTDatHang.Columns[4].DefaultCellStyle.Format = "C";
            gvCTDatHang.Columns[3].DefaultCellStyle.Format = "N";
        }
        private void FrmChiTietDonDatHang_Load(object sender, EventArgs e)
        {
            
            LoadJsonDataToDataGridView(jsonsanpham);
            LoadGVCTDatHang();
        }
    }
}
