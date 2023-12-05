using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using DAL;
using DevExpress.Utils.Gesture;

namespace GUI
{
    public partial class FrmDonDatHang : Form
    {
        BUS_DatHang busdathang = new BUS_DatHang();
        BUS_HoaDon bushoadon = new BUS_HoaDon();
        DTO_HoaDon dtoHoadon;
        private string manhanvien;
        public FrmDonDatHang()
        {
            InitializeComponent();
        }
        public FrmDonDatHang(string manhanvien)
        {
            this.manhanvien = manhanvien;
            InitializeComponent();
        }

        private void FrmDonDatHang_Load(object sender, EventArgs e)
        {
            gvDatHang.DataSource = busdathang.DanhSachCTDatHang();
            LoadGVCTDatHang();
        }
        private void LoadGVCTDatHang()
        {
            gvDatHang.Columns[0].HeaderText = "Mã Đơn Đặt Hàng";
            gvDatHang.Columns[1].HeaderText = "Mã Khách Hàng";
            gvDatHang.Columns[2].HeaderText = "Tên Khách Hàng";
            gvDatHang.Columns[3].HeaderText = "Số Lượng Đặt";
            gvDatHang.Columns[4].HeaderText = "Tổng Tiền";
            gvDatHang.Columns[5].HeaderText = "Ngày Đặt";
            gvDatHang.Columns[6].HeaderText = "Trạng Thái";
            gvDatHang.Columns[7].HeaderText = "Json Sản Phẩm";

            gvDatHang.Columns[7].Visible = false;
            gvDatHang.Columns[1].Visible = false;
            gvDatHang.Columns[6].Visible = false;

            foreach (DataGridViewColumn item in gvDatHang.Columns)
            {
                item.DividerWidth = 1;
            }
            gvDatHang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvDatHang.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvDatHang.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvDatHang.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvDatHang.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvDatHang.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvDatHang.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvDatHang.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvDatHang.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnDuyetDonDatHang_Click(object sender, EventArgs e)
        {
            int madathang = int.Parse(gvDatHang.CurrentRow.Cells[0].Value.ToString());
            double gia = double.Parse(gvDatHang.CurrentRow.Cells[4].Value.ToString());
            int makhachhang = int.Parse(gvDatHang.CurrentRow.Cells[1].Value.ToString());
            dtoHoadon = new DTO_HoaDon
                (
                    int.Parse(manhanvien),
                    makhachhang,
                  gia
                );
            if (bushoadon.ThemHoaDon(dtoHoadon))
            {
                MessageBox.Show("Cập nhập thành công!");
                busdathang.CapNhapTrangThaiDatHang(madathang);
                gvDatHang.DataSource = busdathang.DanhSachCTDatHang();
                LoadGVCTDatHang();
            }
            else
            {
                MessageBox.Show("Cập nhập thất bại!");
            }
        }

        private void btnHuyDon_Click(object sender, EventArgs e)
        {
            int madathang = int.Parse(gvDatHang.CurrentRow.Cells[0].Value.ToString());
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy đơn hàng?", "Xác nhận hủy đơn hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra xem người dùng đã chọn Yes hay No trong hộp thoại xác nhận
            if (result == DialogResult.Yes)
            {
                // Nếu người dùng chọn Yes, thực hiện hủy đơn hàng
                if (busdathang.HuyDonDatHang(madathang))
                {
                    MessageBox.Show("Hủy Thành Công!");
                    gvDatHang.DataSource = busdathang.DanhSachCTDatHang();
                    LoadGVCTDatHang();
                }
                else
                {
                    MessageBox.Show("Hủy không thành công!");
                }
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            string jsondathang = gvDatHang.CurrentRow.Cells[7].Value.ToString();
            FrmChiTietDonDatHang frm = new FrmChiTietDonDatHang(jsondathang);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            gvDatHang.DataSource = busdathang.DanhSachCTDatHang();
            LoadGVCTDatHang();
            txtTimKiem.Text = "";
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string name = txtTimKiem.Text.Trim();
            if (name == "")
            {
                FrmDonDatHang_Load(sender, e);
                txtTimKiem.Focus();
            }
            else
            {
                DataTable data = busdathang.TimKiemKhachHangDatHang(name);
                gvDatHang.DataSource = data;
            }
        }
    }
}
