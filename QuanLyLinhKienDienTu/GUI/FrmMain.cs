using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TheArtOfDevHtmlRenderer.Adapters;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI
{
    public partial class FrmMain : Form
    {
        string email = "";
        string taikhoan;
        private string fileAddress, str;

        private char separator = '|';
        private string[] strlist;

        private byte[] img; // mã hóa hình ảnh lưu trử
        BUS_NhanVien busEmployee = new BUS_NhanVien();

        FrmTrangChu frmTrangChu = new FrmTrangChu();
        FrmQuanLyNhanVien FrmQuanLyNhanVien = new FrmQuanLyNhanVien();
        FrmQuanLySanPham frmQuanLySanPham = new FrmQuanLySanPham();
        FrmQuanLyKhachHang FrmQuanLyKhachHang = new FrmQuanLyKhachHang();
        FrmQuanLyDonDatHang FrmQuanLyDonDatHang = new FrmQuanLyDonDatHang();
        FrmBaoCaoThongKe FrmBaoCaoThongKe = new FrmBaoCaoThongKe();
        FrmBanHang FrmBanHang = new FrmBanHang();
        FrmThongTinTaiKhoan FrmThongTinTaiKhoan;

        DTO_NhanVien dtonhanvien;


        public FrmMain(string taikhoan)
        {
            this.taikhoan = taikhoan;
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
            FrmThongTinTaiKhoan = new FrmThongTinTaiKhoan(email,taikhoan);

            //fBill = new frmHoadon(email);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            loadanh();
            loadthongtinnhanvien();
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
        private void loadanh()
        {
            img = busEmployee.LayAnhNhanVien(taikhoan);
         
       
            if(img == null)
            {
                label_noti.Show();
            }    
            else
            {
                label_noti.Hide();
                MemoryStream memoryStream = new MemoryStream(img);
                pic_profile.Image = Image.FromStream(memoryStream);
            }    
        }
        private void loadthongtinnhanvien()
        {
            str = busEmployee.LayNameChucVuNhanVien(taikhoan);
            strlist = str.Split(separator);
            lb_name.Text = "Họ tên: " + strlist[0].Trim();
            string chucvu = strlist[1].Trim();

            if (chucvu == "1")
            {
                chucvu = "Quản lý";
            }
            else
            {
                chucvu = "Nhân viên";
            }
            lb_chucvu.Text = "Chức vụ: " + chucvu;

        }

        //Copy ảnh 
        private Image CloneImage(string path)
        {
            Image result;
            using (Bitmap original = new Bitmap(path))
            {
                result = (Bitmap)original.Clone();

            };
            return result;
        }
        //Lưu trử ảnh dạng mảng
        private byte[] ImageToByteArray(PictureBox pictureBox)
        {
            MemoryStream memoryStream = new MemoryStream();
            pictureBox.Image.Save(memoryStream, pictureBox.Image.RawFormat);
            return memoryStream.ToArray();
        }
        private void OpenImage()
        {
            OpenFileDialog open = new OpenFileDialog();
            //File ảnh cho phép đc upload
            open.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            open.Title = "Chọn ảnh cần upload";

            //Nếu chọn OK thì úp load ảnh
            if (open.ShowDialog() == DialogResult.OK)
            {
                fileAddress = open.FileName;
                pic_profile.Image = CloneImage(fileAddress);
                pic_profile.ImageLocation = fileAddress;
                img = ImageToByteArray(pic_profile);
            }
        }

        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void sw_nen_CheckedChanged(object sender, EventArgs e)
        {
            Color dark = Color.FromArgb(9, 2, 22);


            Color orin = Color.FromArgb(81 , 31 , 144);
            if (guna2Panel2.BackColor.ToArgb() == dark.ToArgb() && guna2Panel1.BackColor.ToArgb() == dark.ToArgb())
            {
               
                guna2Panel2.BackColor = orin;
                guna2Panel1.BackColor = orin;
                ColorChangeEventProvider.OnColorChanged(orin);
            }
            else
            {
               
                guna2Panel1.BackColor = dark;
                guna2Panel2.BackColor = dark;
                ColorChangeEventProvider.OnColorChanged(dark);
            }

        }

        private void pic_edit_Click(object sender, EventArgs e)
        {
            OpenImage();

            dtonhanvien = new DTO_NhanVien(taikhoan, ImageToByteArray(pic_profile));
            if (busEmployee.ThemAnhNhanVien(dtonhanvien))
            {
                FrmMain_Load(sender, e);
            }
            else
            {
                MsgBox("Sửa ảnh không được", true);
            }
        }

        // Trong một lớp hoặc form chung (Common class)
        public static class ColorChangeEventProvider
        {
            public static event EventHandler<ColorChangedEventArgs> ColorChanged;

            public static void OnColorChanged(Color newColor)
            {
                ColorChanged?.Invoke(null, new ColorChangedEventArgs(newColor));
            }
        }

        private void guna2Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                guna2Panel2.Capture = false;
                const int WM_NCLBUTTONDOWN = 0x00A1;
                const int HTCAPTION = 2;
                Message msg =
                    Message.Create(this.Handle, WM_NCLBUTTONDOWN,
                        new IntPtr(HTCAPTION), IntPtr.Zero);
                this.DefWndProc(ref msg);
            }
        }

        public class ColorChangedEventArgs : EventArgs
        {
            public Color NewColor { get; }

            public ColorChangedEventArgs(Color newColor)
            {
                NewColor = newColor;
            }
        }

    }
}
