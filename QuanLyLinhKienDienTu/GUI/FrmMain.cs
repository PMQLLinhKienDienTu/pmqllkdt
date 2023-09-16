using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI
{
    public partial class FrmMain : Form
    {
        string email = "";

        BUS_NhanVien busEmployee = new BUS_NhanVien();

        FrmTrangChu frmTrangChu= new FrmTrangChu();
        FrmQuanLyNhanVien FrmQuanLyNhanVien = new FrmQuanLyNhanVien();
        FrmQuanLySanPham frmQuanLySanPham  = new FrmQuanLySanPham();
        FrmQuanLyKhachHang FrmQuanLyKhachHang = new FrmQuanLyKhachHang();
        FrmQuanLyDonDatHang FrmQuanLyDonDatHang = new FrmQuanLyDonDatHang();
        FrmBaoCaoThongKe FrmBaoCaoThongKe = new FrmBaoCaoThongKe();
        FrmBanHang FrmBanHang = new FrmBanHang();
        FrmThongTinTaiKhoan FrmThongTinTaiKhoan;



        public FrmMain(string taikhoan)
        {
            InitializeComponent();

            // Kiểm tra Chức vụ của nhân viên

            if (!busEmployee.GetChucVu(taikhoan))
            {
                btnNhanVien.Visible = false;
                btnDoanhThu.Visible = false;

                btn_TrangChu.Checked = true;
                
                frmTrangChu.TopLevel = false;
                pnlBody.Controls.Add(frmTrangChu);
                frmTrangChu.Dock = DockStyle.Fill;
                frmTrangChu.Show();
            }
            else
            {
                btn_TrangChu.Checked = true;
               
                frmTrangChu.TopLevel = false;
                pnlBody.Controls.Add(frmTrangChu);
                frmTrangChu.Dock = DockStyle.Fill;
                frmTrangChu.Show();

            }
            ////Khởi tạo tài khoản accout và Bán hoàng
            ///
            email = busEmployee.LayMailNhanVien(taikhoan);
            FrmThongTinTaiKhoan = new FrmThongTinTaiKhoan(email);

            //fBill = new frmHoadon(email);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }

        // đăng xuất
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.Close();
            }

           
        }
        // Thoát phần mềm 
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_TrangChu_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            frmTrangChu.TopLevel = false;
            pnlBody.Controls.Add(frmTrangChu);
            frmTrangChu.Dock = DockStyle.Fill;
            frmTrangChu.Show();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            frmQuanLySanPham.TopLevel = false;
            pnlBody.Controls.Add(frmQuanLySanPham);
            frmQuanLySanPham.Dock = DockStyle.Fill;
            frmQuanLySanPham.Show();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            FrmQuanLyKhachHang.TopLevel = false;
            pnlBody.Controls.Add(FrmQuanLyKhachHang);
            FrmQuanLyKhachHang.Dock = DockStyle.Fill;
            FrmQuanLyKhachHang.Show();
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            FrmBaoCaoThongKe.TopLevel = false;
            pnlBody.Controls.Add(FrmBaoCaoThongKe);
            FrmBaoCaoThongKe.Dock = DockStyle.Fill;
            FrmBaoCaoThongKe.Show();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            FrmQuanLyNhanVien.TopLevel = false;
            pnlBody.Controls.Add(FrmQuanLyNhanVien);
            FrmQuanLyNhanVien.Dock = DockStyle.Fill;         
            FrmQuanLyNhanVien.Show();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            FrmBanHang.TopLevel = false;
            pnlBody.Controls.Add(FrmBanHang);
            FrmBanHang.Dock = DockStyle.Fill;
            FrmBanHang.Show();
        }
        private void btnthongtintk_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            FrmThongTinTaiKhoan.TopLevel = false;
            pnlBody.Controls.Add(FrmThongTinTaiKhoan);
            FrmThongTinTaiKhoan.Dock = DockStyle.Fill;
            FrmThongTinTaiKhoan.Show();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát phầm mềm không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Application.Exit();
            } 
           
        }

       
    }
}
