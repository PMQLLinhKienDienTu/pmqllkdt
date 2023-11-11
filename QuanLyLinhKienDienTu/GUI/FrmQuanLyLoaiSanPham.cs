using BUS;
using DTO;
using System;
using System.Windows.Forms;
using static GUI.FrmMain;

namespace GUI
{
    public partial class FrmQuanLyLoaiSanPham : Form
    {
        private int id;
        private string name;

        BUS_PhanLoaiSanPham busphanloaisp = new BUS_PhanLoaiSanPham();

        public FrmQuanLyLoaiSanPham()
        {
            InitializeComponent();

            ColorChangeEventProvider.ColorChanged += ColorChangeEventProvider_ColorChanged;
        }
        private void ColorChangeEventProvider_ColorChanged(object sender, ColorChangedEventArgs e)
        {
            Guna.UI2.WinForms.Guna2Panel[] panels = { guna2Panel1, guna2Panel2 };
            foreach (var panel in panels)
            {
                panel.BackColor = e.NewColor;
            }
        }
        private void FrmQuanLyLoaiSanPham_Load(object sender, EventArgs e)
        {
            gvLoaiSanPham.DataSource = busphanloaisp.DanhSachLoaiSP();
            LoadGridView();
            SetValue(true, false);
            txtTenLoai.Focus();
        }
        private void LoadGridView()
        {
            gvLoaiSanPham.Columns[0].HeaderText = "Mã loại";
            gvLoaiSanPham.Columns[1].HeaderText = "Tên loại";
            gvLoaiSanPham.Columns[2].HeaderText = "Nhà sản xuất";

            foreach (DataGridViewColumn item in gvLoaiSanPham.Columns)
            {
                item.DividerWidth = 1;
            }
            gvLoaiSanPham.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvLoaiSanPham.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvLoaiSanPham.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvLoaiSanPham.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Thiết lặt thao tác
        private void SetValue(bool param, bool isLoad)
        {
            txtTenLoai.Text = null;
            txtNSX.Text = null;
            txtTenLoai.Focus();

            if (isLoad) // true
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            else // false
            {
                btnSua.Enabled = !param;// !param == true
                btnXoa.Enabled = !param;// !param == true
            }
        }
        private void gvLoaiSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = btnXoa.Enabled = true;
            txtTenLoai.Text = gvLoaiSanPham.CurrentRow.Cells[1].Value.ToString();
            txtNSX.Text = gvLoaiSanPham.CurrentRow.Cells[2].Value.ToString();
        }
    
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenLoai.Text != "" && txtNSX.Text != "")
            {
                DTO_PhanLoaiSanPham dtophanploaisp = new DTO_PhanLoaiSanPham(txtTenLoai.Text, txtNSX.Text);
                if (busphanloaisp.ThemLoaiSP(dtophanploaisp))
                {
                    SetValue(false, true);
                    gvLoaiSanPham.DataSource = busphanloaisp.DanhSachLoaiSP();
                    LoadGridView();
                    MessageBox.Show("Thêm loại sản phẩm thành công");
                }
                else
                    MsgBox("Không thêm  loại sản phẩm được!", true);
            }
            else MsgBox("Thiếu trường thông tin!", true);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenLoai.Text != "" && txtNSX.Text != "")
            {
                id = int.Parse(gvLoaiSanPham.CurrentRow.Cells[0].Value.ToString());

                DTO_PhanLoaiSanPham dtophanploaisp = new DTO_PhanLoaiSanPham(id, txtTenLoai.Text, txtNSX.Text);
                if (busphanloaisp.SuaLoaiSP(dtophanploaisp))
                {
                    SetValue(false, true);
                    gvLoaiSanPham.DataSource = busphanloaisp.DanhSachLoaiSP();
                    LoadGridView();
                    MessageBox.Show("Sửa loại sản phẩm thành công");
                }
                else
                    MsgBox("Không Sửa loại sản phẩm được!", true);
            }
            else MsgBox("Thiếu trường thông tin!", true);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa loại sản phẩm này không", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                int ids = int.Parse(gvLoaiSanPham.CurrentRow.Cells[0].Value.ToString());

                if (busphanloaisp.XoaLoaiSP(ids))
                {
                    SetValue(true, false);
                    gvLoaiSanPham.DataSource = busphanloaisp.DanhSachLoaiSP();
                    MessageBox.Show("Xóa loại sản phẩm thành công");
                    LoadGridView();
                }
                else
                    MsgBox("Xóa loại sản phẩm không thành công", true);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            SetValue(true, false);
        }
    }
}
