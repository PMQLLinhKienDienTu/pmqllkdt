using BUS;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmDangNhap : Form
    {

        BUS_NhanVien busEmployee = new BUS_NhanVien();
        public FrmDangNhap()
        {
            InitializeComponent();
        }
        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            panel_login.BackColor = Color.FromArgb(100, 0, 0, 0);

            txt_taikhoan.Text = "ngocthien";
            txt_matkhau.Text = "ngocthien";
            if (Properties.Settings.Default.isSave)
            {
                string srtmail = txt_taikhoan.Text.Trim();
                string strpass = txt_matkhau.Text.Trim();
                srtmail = Properties.Settings.Default.taikhoan;
                strpass = Properties.Settings.Default.mạtkhau;
                tglRememberMe.Checked = true;
            }
        }
        // Di chuyển tùy ý khung đăng nhập cho panel 
        private void panel_login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {             
                panel_login.Capture = false;            
                const int WM_NCLBUTTONDOWN = 0x00A1;
                const int HTCAPTION = 2;
                Message msg =
                    Message.Create(this.Handle, WM_NCLBUTTONDOWN,
                        new IntPtr(HTCAPTION), IntPtr.Zero);
                this.DefWndProc(ref msg);
            }
        }
        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_taikhoan.Text) && String.IsNullOrEmpty(txt_matkhau.Text))
            {
                MessageBox.Show("TÀI KHOẢN VÀ MẬT KHẨU KHÔNG ĐƯỢC ĐỂ TRỐNG");
                return;
            }
            if (String.IsNullOrEmpty(txt_taikhoan.Text))
            {
                MessageBox.Show("TÀI KHOẢN KHÔNG ĐƯỢC ĐỂ TRỐNG");
                return;
            }              
            if (String.IsNullOrEmpty(txt_matkhau.Text))
            {
                MessageBox.Show("MẬT KHẨU KHÔNG ĐƯỢC ĐỂ TRỐNG");
                return;
            }       
            if (txt_taikhoan.Text != "" && txt_matkhau.Text != "")
            {
                if (busEmployee.Login(txt_taikhoan.Text, txt_matkhau.Text))
                {
                    Properties.Settings.Default.isSave = tglRememberMe.Checked;
                    if (tglRememberMe.Checked)
                    {
                        Properties.Settings.Default.taikhoan = txt_taikhoan.Text;
                        Properties.Settings.Default.mạtkhau = txt_matkhau.Text;
                    }
                    Properties.Settings.Default.Save();
                    FrmMain fMain = new FrmMain(txt_taikhoan.Text);
                    MessageBox.Show("CHÀO MỪNG BẠN ĐÃ ĐĂNG NHẬP VÀO SHOP!!!");
                    this.Hide();
                    fMain.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_taikhoan.Text = "";
                    txt_matkhau.Text = "";
                    txt_taikhoan.Focus();
                }
            }
        }     
    }
}
