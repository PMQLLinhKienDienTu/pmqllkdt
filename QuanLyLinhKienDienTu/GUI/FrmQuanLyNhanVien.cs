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
using System.Xml.Linq;
using static GUI.FrmMain;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class FrmQuanLyNhanVien : Form
    {
        private int id;
        private string name;
        private bool role;
        private bool status;

        BUS_NhanVien busEmployee = new BUS_NhanVien();
        public FrmQuanLyNhanVien()
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
        private void FrmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            gvNhanVien.DataSource = busEmployee.DanhSachNhanVien();
            LoadGridView();
            SetValue(true, false);
            txtHoTen.Focus();
        }
        private void LoadGridView()
        {

            gvNhanVien.Columns[0].HeaderText = "Mã NV";
            gvNhanVien.Columns[1].HeaderText = "Họ tên NV";
            gvNhanVien.Columns[2].HeaderText = "Tài khoản";
            gvNhanVien.Columns[3].HeaderText = "Email";
            gvNhanVien.Columns[4].HeaderText = "Số điện thoại";
            gvNhanVien.Columns[5].HeaderText = "Vai trò";
            gvNhanVien.Columns[6].HeaderText = "Tình trạng";

            foreach (DataGridViewColumn item in gvNhanVien.Columns)
            {
                item.DividerWidth = 1;
            }
            gvNhanVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvNhanVien.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvNhanVien.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvNhanVien.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvNhanVien.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvNhanVien.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvNhanVien.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvNhanVien.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            txtTaiKhoan.Text = null;
            txtSoDienThoai.Text = null;
            btnThem.Enabled = param;
            txtHoTen.Text = null;
            radLam.Enabled = param;
            radNghiLam.Enabled = param;
            radNhanVien.Enabled = param;
            radQuanLy.Enabled = param;
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

            radNhanVien.Checked = true;
            radLam.Checked = true;
        }
    
       

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            SetValue(true, false);
        }

        private void txtTimKiemNhanVien_TextChanged(object sender, EventArgs e)
        {
            name = txtTimKiemNhanVien.Text.Trim();
            if (name == "")
            {
                FrmQuanLyNhanVien_Load(sender, e);
                txtTimKiemNhanVien.Focus();
            }
            else
            {
                DataTable data = busEmployee.TimKiemNhanVien(name);
                gvNhanVien.DataSource = data;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text != "" && txtEmail.Text != "" && txtHoTen.Text != ""
               && txtSoDienThoai.Text != "")
            {
                if (IsValidEmail(txtEmail.Text))
                {
                    role = radQuanLy.Checked;
                    status = radLam.Checked;
                    string password = busEmployee.GetRandomPassword();
                    DTO_NhanVien dtoNhanVien = new DTO_NhanVien(txtHoTen.Text, txtTaiKhoan.Text, txtEmail.Text, txtSoDienThoai.Text, role, status, password);
                    if (busEmployee.ThemNhanVien(dtoNhanVien))
                    {
                        SetValue(false, true);
                        gvNhanVien.DataSource = busEmployee.DanhSachNhanVien();
                        LoadGridView();
                        FrmGuiMail sendMail = new FrmGuiMail(dtoNhanVien.Email, dtoNhanVien.TaiKhoan, password);
                        sendMail.ShowDialog();
                        MsgBox(sendMail.Result);
                    }
                    else
                        MsgBox("Không thêm nhân viên được!", true);
                }
                else MsgBox("Email không đúng định dạng!", true);
            }
            else MsgBox("Thiếu trường thông tin!", true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text != "" && txtEmail.Text != "" && txtHoTen.Text != ""
              && txtSoDienThoai.Text != "")
            {
                role = radQuanLy.Checked;
                status = radLam.Checked;
                DTO_NhanVien dtoEmployee = new DTO_NhanVien(txtHoTen.Text, txtTaiKhoan.Text, txtEmail.Text, txtSoDienThoai.Text, role, status);
                if (busEmployee.SuaNhanVien(dtoEmployee))
                {
                    SetValue(true, false);
                    gvNhanVien.DataSource = busEmployee.DanhSachNhanVien();
                    MessageBox.Show("Sửa nhân viên thành công");
                    LoadGridView();
                }
                else
                    MsgBox("Sửa nhân viên không thành công!", true);
            }
            else MsgBox("Thiếu trường thông tin!", true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa vai trò của nhân viên này không", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                id = int.Parse(gvNhanVien.CurrentRow.Cells[0].Value.ToString());
                if (busEmployee.XoaNhanVien(id))
                {
                    SetValue(true, false);
                    gvNhanVien.DataSource = busEmployee.DanhSachNhanVien();
                    MessageBox.Show("Xóa nhân viên thành công");
                    LoadGridView();
                }
                else
                    MsgBox("Xóa nhân viên không thành công", true);
            }
        }

        private void gvNhanVien_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = btnXoa.Enabled = radLam.Enabled = true;
            radNghiLam.Enabled = true;
            radNhanVien.Enabled = true;
            radQuanLy.Enabled = true;
            txtEmail.ReadOnly = true;

            txtHoTen.Text = gvNhanVien.CurrentRow.Cells[1].Value.ToString();
            txtTaiKhoan.Text = gvNhanVien.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = gvNhanVien.CurrentRow.Cells[3].Value.ToString();
            txtSoDienThoai.Text = gvNhanVien.CurrentRow.Cells[4].Value.ToString();
            role = bool.Parse(gvNhanVien.CurrentRow.Cells[5].Value.ToString());
            status = bool.Parse(gvNhanVien.CurrentRow.Cells[6].Value.ToString());

            if (role)
                radQuanLy.Checked = true;
            else
                radNhanVien.Checked = true;
            if (status)
                radLam.Checked = true;
            else
                radNghiLam.Checked = true;
        }
    }
}
