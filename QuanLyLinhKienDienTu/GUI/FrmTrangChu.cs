using System;
using System.Windows.Forms;
using BUS;
namespace GUI
{
    public partial class FrmTrangChu : Form
    {
        BUS_HoaDon hoadon = new BUS_HoaDon();

        public FrmTrangChu()
        {
            InitializeComponent();
      
        }
        private void FrmTrangChu_Load(object sender, EventArgs e)
        {
            LoadTrangChu();
        }

        public void RefreshForm()
        {
            LoadTrangChu();
        }
        private void LoadTrangChu()
        {
            try
            {
                label_doanhthu.Text = hoadon.DoanhThuTheoNgay().ToString("C");
                label_sodonhang.Text = hoadon.SoDonHang().ToString();
                label_soluongsanpham.Text = hoadon.SoSanPhamBan().ToString();
            }
            catch (Exception)
            {
            }
           
        }
        private int number = 1;
        private void loadanh()
        {
            if(number == 6)
            {
                number = 1;
            }
            pictureBox1.ImageLocation = string.Format(@"ImageTrangChu\{0}.jpg", number);
            number++;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            loadanh();
        }
    }
}
