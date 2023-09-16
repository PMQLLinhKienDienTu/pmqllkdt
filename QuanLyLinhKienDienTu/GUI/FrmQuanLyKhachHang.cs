using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class FrmQuanLyKhachHang : Form
    {

        private int id;
        private string name;

        BUS_KhachHang busKhachHang = new BUS_KhachHang();
        public FrmQuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void FrmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            gvKhachhang.DataSource = busKhachHang.DanhSachKhachHang();
            LoadGridView();
            SetValue(true, false);
            txtHoTen.Focus();

        }
        private void LoadGridView()
        {

            gvKhachhang.Columns[0].HeaderText = "Mã KH";
            gvKhachhang.Columns[1].HeaderText = "Họ tên";
            gvKhachhang.Columns[2].HeaderText = "Địa chỉ";
            gvKhachhang.Columns[3].HeaderText = "Email";
            gvKhachhang.Columns[4].HeaderText = "Số điện thoại";


            foreach (DataGridViewColumn item in gvKhachhang.Columns)
            {
                item.DividerWidth = 1;
            }
            gvKhachhang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvKhachhang.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvKhachhang.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvKhachhang.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvKhachhang.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvKhachhang.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            txtEmail.ReadOnly = false; // guna FrameWork
            txtEmail.Text = null;
            txtDiaChi.Text = null;
            txtSoDienThoai.Text = null;
            btnThem.Enabled = param;
            txtHoTen.Text = null;
            txtHoTen.Focus();

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

        // kiểm tra Email có giá trị
        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void gvKhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = btnXoa.Enabled = true;              
            txtHoTen.Text = gvKhachhang.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi.Text = gvKhachhang.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = gvKhachhang.CurrentRow.Cells[3].Value.ToString();
            txtSoDienThoai.Text = gvKhachhang.CurrentRow.Cells[4].Value.ToString();  
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            SetValue(true, false);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtDiaChi.Text != "" && txtEmail.Text != "" && txtHoTen.Text != ""
              && txtSoDienThoai.Text != "")
            {
                if (IsValidEmail(txtEmail.Text))
                {
                    DTO_KhachHang dtokhachhang = new DTO_KhachHang(txtHoTen.Text, txtDiaChi.Text, txtEmail.Text, txtSoDienThoai.Text);
                    if (busKhachHang.ThemKhachHang(dtokhachhang))
                    {
                        SetValue(false, true);
                        gvKhachhang.DataSource = busKhachHang.DanhSachKhachHang();
                        LoadGridView();
                        MessageBox.Show("Thêm khách hàng thành công");
                    }
                    else
                        MsgBox("Không thêm nhân viên được!", true);
                }
                else MsgBox("Email không đúng định dạng!", true);
            }
            else MsgBox("Thiếu trường thông tin!", true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa khách hàng này không", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                id = int.Parse(gvKhachhang.CurrentRow.Cells[0].Value.ToString());
                if (busKhachHang.XoaKhachHang(id))
                {
                    SetValue(true, false);
                    gvKhachhang.DataSource = busKhachHang.DanhSachKhachHang();
                    MessageBox.Show("Xóa khách hàng thành công");
                    LoadGridView();
                }
                else
                    MsgBox("Xóa khách hàng không thành công", true);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtDiaChi.Text != "" && txtEmail.Text != "" && txtHoTen.Text != ""
              && txtSoDienThoai.Text != "")
            {
                DTO_KhachHang dtokhachhang = new DTO_KhachHang(txtHoTen.Text, txtDiaChi.Text, txtEmail.Text, txtSoDienThoai.Text);
                if (busKhachHang.SuaKhachHang(dtokhachhang))
                {
                    SetValue(true, false);
                    gvKhachhang.DataSource = busKhachHang.DanhSachKhachHang();
                    MessageBox.Show("Sửa khách hàng thành công");
                    LoadGridView();
                }
                else
                    MsgBox("Sửa khách hàng không thành công!", true);
            }
            else MsgBox("Thiếu trường thông tin!", true);
        }

        private void txtTimKiemKhachHang_TextChanged(object sender, EventArgs e)
        {
            name = txtTimKiemKhachHang.Text.Trim();
            if (name == "")
            {
                FrmQuanLyKhachHang_Load(sender, e);
                txtTimKiemKhachHang.Focus();
            }
            else
            {
                DataTable data = busKhachHang.TimKiemKhachHang(name);
                gvKhachhang.DataSource = data;
            }
        }
    }
}
