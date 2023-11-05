using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static GUI.FrmMain;

namespace GUI
{
    public partial class FrmBanHang : Form
    {
        BUS_ChiTietHoaDon buscthoadon = new BUS_ChiTietHoaDon();
        BUS_KhachHang buskhachhang = new BUS_KhachHang();
        BUS_SanPham bussanpham = new BUS_SanPham();
        BUS_NhanVien BUS_NhanVien= new BUS_NhanVien();
        BUS_HoaDon bushoadon  = new BUS_HoaDon();

        DTO_HoaDon dtoHoadon;
        DTO_ChiTietHoaDon dtoChitiethoadon;

        private string[] danhsachKH, danhsachSP;
        private DateTime dateTime = new DateTime();
        private string tensanpham, email, str;
        private char separator = '|';
        private string[] strlist;
        private Color savedColor;
        private Timer timer = new Timer();
        

        public FrmBanHang(string email)
        {
            InitializeComponent();
            ColorChangeEventProvider.ColorChanged += ColorChangeEventProvider_ColorChanged;
            this.email = email;
        }
        private void ColorChangeEventProvider_ColorChanged(object sender, ColorChangedEventArgs e)
        {
            Guna.UI2.WinForms.Guna2Panel[] panels = { guna2Panel1, guna2Panel2, guna2Panel4, 
                guna2Panel5, guna2Panel6, guna2Panel7, guna2Panel8, guna2Panel9, guna2Panel10,
                guna2Panel11 ,guna2Panel12, guna2Panel13, guna2Panel14 };

            foreach (var panel in panels)
            {
                panel.BackColor = e.NewColor;
            }
            guna2TabControlBanHang.TabMenuBackColor = e.NewColor;
        }

        private void FrmBanHang_Load(object sender, EventArgs e)
        {
            BanHangLoad();
            HoaDonLoad();
            NhapHangLoad();      
        }


        private void BanHangLoad()
        {
            txtQuantity.Text = null;
            txtUnitPrice.Text = null;
            txtTotalPrice.Text = null;

            gvCTHoaDon.DataSource = buscthoadon.DanhSachCTHoaDon();
            LoadGVCTHoaDon();
            LoadData();
        }

        private void HoaDonLoad()
        {
            // Hóa đơn 
            gvHoaDon.DataSource = bushoadon.DanhSachHoaDon();
            LoadGVHoaDon();
        }
        private void NhapHangLoad()
        {
          
        }
        // load dữ liệu 
        private void LoadData()
        {
            danhsachKH = buskhachhang.DanhSachKHtheoIDName();
            cboCustomerIdName.Items.Clear();

            foreach (string item in danhsachKH)
            {
                cboCustomerIdName.Items.Add(item);
            }

            timer.Interval = 10; 
            timer.Tick += new EventHandler(timer_hienhanh_Tick); // Đặt sự kiện tick cho timer
            timer.Start(); // Bắt đầu chạy timer

            danhsachSP = bussanpham.DanhSachSLNameSP();
            cboProductNameQuantity.Items.Clear();
            foreach (string item in danhsachSP)
            {
                cboProductNameQuantity.Items.Add(item);
            }

            txtEmployeeIdName.Text = BUS_NhanVien.LayIdHoTenNhanVien(email);
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            txtQuantity.Text = null;
            txtUnitPrice.Text = null; 
            LoadData();
        }

        private void cboProductNameQuantity_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = cboProductNameQuantity.SelectedItem.ToString();
            char separator = '|';
            String[] strlist = str.Split(separator);
            tensanpham = strlist[0].Trim();
            txtUnitPrice.Text = bussanpham.LayGiaSP(tensanpham).ToString();
        }

        //Thêm chi tiết hóa đơn
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                str = cboProductNameQuantity.SelectedItem.ToString();
                strlist = str.Split(separator);
                tensanpham = strlist[0].Trim();

                if (txtQuantity.Text != "")
                {
                    int id_sp = bussanpham.GetProductId(tensanpham);
                    int soluong = int.Parse(txtQuantity.Text);
                    double gia = double.Parse(txtUnitPrice.Text);

                    dtoChitiethoadon = new DTO_ChiTietHoaDon(id_sp, soluong, gia);                 
                    
                    if (buscthoadon.ThemCTHoaDon(dtoChitiethoadon, soluong))
                    {
                        danhsachSP = bussanpham.DanhSachSLNameSP();

                        BanHangLoad();
                        txtTotalPrice.Text = buscthoadon.GetTotalPrice().ToString();
                        MsgBox("Thêm hóa đơn thành công");
                    }
                    else
                        MsgBox("Thêm không thành công", true);
                }
                else
                    MsgBox("Vui lòng kiểm tra lại dữ liệu", true);
            }
            catch
            {
                MsgBox("Thêm không thành công", true);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int id = bussanpham.GetProductId(tensanpham);
            int soluong = int.Parse(txtQuantity.Text);
            str = cboProductNameQuantity.SelectedItem.ToString();
            strlist = str.Split(separator);
            if (buscthoadon.SuaSanPhamCTHoaDon(id, soluong))
            {
                BanHangLoad();
                txtTotalPrice.Text = buscthoadon.GetTotalPrice().ToString();
                MsgBox("Sửa sản phẩm thành công!");
            }
            else
            {
                MsgBox("Sửa sản phẩm không được", true);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = bussanpham.GetProductId(tensanpham);
            if (MessageBox.Show("Bạn có chắc muốn xóa", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (buscthoadon.XoaSanPhamCTHoaDon(id))
                {
                    MsgBox("Xóa thành công");
                    BanHangLoad();
                }
                else
                    MsgBox("Không xóa được", true);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                str = txtEmployeeIdName.Text.Trim();
                strlist = str.Split(separator);
                string employeeId = strlist[0].Trim();

                str = cboCustomerIdName.SelectedItem.ToString();
                strlist = str.Split(separator);
                string customerId = strlist[0].Trim();

                dtoHoadon = new DTO_HoaDon
                (
                    int.Parse(employeeId),
                    int.Parse(customerId),
                    double.Parse(txtTotalPrice.Text)
                );
                if (bushoadon.ThemHoaDon(dtoHoadon))
                {
                    MsgBox("Thanh toán thành công", false);
                    BanHangLoad();
                }
                else
                    MsgBox("Thanh toán không thành công", true);
            }
            catch
            {
                MsgBox("Chọn khách hàng cần thanh toán!!!", true);
            }
        }

        // Hàm thông báo
        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void timer_hienhanh_Tick(object sender, EventArgs e)
        {
            // lấy thời gian hiện tại
            dateTime = DateTime.Now;
            txtDateTime.Text = dateTime.ToString("dd/MM/yyyy") + " " + dateTime.ToString("HH:mm:ss"); // định dạnh ngày/tháng/năm
        }

        private void btnlammoihoadon_Click(object sender, EventArgs e)
        {
            //FrmBanHang_Load(sender,e);
             HoaDonLoad();
        }

        private void LoadGVCTHoaDon()
        {
            gvCTHoaDon.Columns[0].HeaderText = "Mã CTHD";
            gvCTHoaDon.Columns[1].HeaderText = "Tên sản phẩm";
            gvCTHoaDon.Columns[2].HeaderText = "Số lượng";
            gvCTHoaDon.Columns[3].HeaderText = "Giá";
           

            foreach (DataGridViewColumn item in gvCTHoaDon.Columns)
            {
                item.DividerWidth = 1;
            }
            gvCTHoaDon.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCTHoaDon.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCTHoaDon.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCTHoaDon.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCTHoaDon.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
        private void LoadGVHoaDon()
        {
            gvHoaDon.Columns[0].HeaderText = "Mã HD";
            gvHoaDon.Columns[1].HeaderText = "Tên nhân viên GD";
            gvHoaDon.Columns[2].HeaderText = "Tên khách hàng";
            gvHoaDon.Columns[3].HeaderText = "Ngày GD";
            gvHoaDon.Columns[4].HeaderText = "Thành tiền";

            gvHoaDon.Columns[0].Width= 70;
            foreach (DataGridViewColumn item in gvHoaDon.Columns)
            {
                item.DividerWidth = 1;
            }
            gvHoaDon.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvHoaDon.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvHoaDon.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvHoaDon.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvHoaDon.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvHoaDon.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

     
    }
}
