using BUS;
using DAL;
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
    public partial class FrmThongTinNhapHang : Form
    {
        BUS_NhapHang nhaphang = new BUS_NhapHang();
        public FrmThongTinNhapHang()
        {
            InitializeComponent();
        }

        private void FrmThongTinNhapHang_Load(object sender, EventArgs e)
        {
            BanHangLoad();
        }
        private void BanHangLoad()
        {
            
            gvnhaphang.DataSource = nhaphang.DanhSachNhapHang();
            LoadGVCTNhapHang();
           
        }
        private void LoadGVCTNhapHang()
        {
            gvnhaphang.Columns[0].HeaderText = "Mã Nhập";
            gvnhaphang.Columns[1].HeaderText = "Nhân viên nhập";
            gvnhaphang.Columns[2].HeaderText = "Nhà cung cấp";
            gvnhaphang.Columns[3].HeaderText = "Ngày nhập";
            gvnhaphang.Columns[4].HeaderText = "Thành tiền";

            foreach (DataGridViewColumn item in gvnhaphang.Columns)
            {
                item.DividerWidth = 1;
            }
            gvnhaphang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvnhaphang.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvnhaphang.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvnhaphang.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvnhaphang.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvnhaphang.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvnhaphang.Columns[4].DefaultCellStyle.Format = "C";
        }
    }
}
