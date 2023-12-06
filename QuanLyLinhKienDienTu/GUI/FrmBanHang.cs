using BUS;
using DTO;
using System;
using System.Data;
using System.Windows.Forms;
using static GUI.FrmMain;
using DAL;
using GUI.Report;
using DevExpress.XtraReports.UI;
using System.Linq;
using Microsoft.ML;
using System.Collections.Generic;
using Microsoft.ML.Data;

namespace GUI
{
    public partial class FrmBanHang : Form
    {

        BUS_ChiTietHoaDon buscthoadon = new BUS_ChiTietHoaDon();
        BUS_KhachHang buskhachhang = new BUS_KhachHang();
        BUS_SanPham bussanpham = new BUS_SanPham();
        BUS_NhanVien BUS_NhanVien = new BUS_NhanVien();
        BUS_HoaDon bushoadon = new BUS_HoaDon();
        BUS_NhaCungCap busnhacungcap = new BUS_NhaCungCap();
        BUS_ChiTietNhapHang busctnhaphang = new BUS_ChiTietNhapHang();
        BUS_NhapHang busnhanhang = new BUS_NhapHang();

        DTO_HoaDon dtoHoadon;
        DTO_NhapHang dtonhanhang;
        DTO_ChiTietNhapHang dtoctnhaphang;
        DTO_ChiTietHoaDon dtoChitiethoadon;

        //Lin Q
        QLLKDTDataContext qllkdt = new QLLKDTDataContext();

        private string[] danhsachKH, danhsachSP;
        private DateTime dateTime = new DateTime();
        private DateTime dateTime2 = new DateTime();
        private string tensanpham, email, str;
        private int soluongsp;
        private char separator = '|';
        private string[] strlist;
        private Timer timer = new Timer();
        private Timer timer2 = new Timer();
        private string taikhoan;
        private MLContext mlContext;

        public FrmBanHang(string email, string taikhoan)
        {
            InitializeComponent();
            ColorChangeEventProvider.ColorChanged += ColorChangeEventProvider_ColorChanged;
            this.email = email;
            this.taikhoan = taikhoan;
        }
        private void ColorChangeEventProvider_ColorChanged(object sender, ColorChangedEventArgs e)
        {
            Guna.UI2.WinForms.Guna2Panel[] panels = { guna2Panel1, guna2Panel2, guna2Panel4,
                guna2Panel5, btnDuyetDon, guna2Panel7, guna2Panel8, guna2Panel9, guna2Panel10,
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
            LoadSanPhamBanCham();
            loadthongtinnhanvien();
            LoadSanPhamBanCham();
            SetValueBanHang(true, false);
            SetValueNhapHang(true, false);
            //cboCustomerIdName.SelectedIndex = 0;
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
        private void loadthongtinnhanvien()
        {
            str = BUS_NhanVien.LayNameChucVuNhanVien(taikhoan);
            strlist = str.Split(separator);

            string chucvu = strlist[1].Trim();

            if (chucvu == "1")
            {
                picNhaCungCap.Visible = true;
            }
        }
        private void LoadSanPhamBanCham()
        {
            try
            {
                var sanphams = qllkdt.SanPhams.Select(p => new ProductSalex { ProductId = p.MaSP, Name = p.TenSP, Features = (int)p.SoLuong }).ToList();

                var slowSellingProducts = sanphams.Where(p => p.Features >= 30).ToList();

                databancham.DataSource = slowSellingProducts;

                int soluongsanphambancham = slowSellingProducts.Count( p => p.Features >= 30);
                label_sosanphambancham.Text = Convert.ToString(soluongsanphambancham);
            }
            catch (Exception)
            {

                throw;
            }
          
        }
        private void HoaDonLoad()
        {
            // load giv
            gvHoaDon.DataSource = bushoadon.DanhSachHoaDon();
            LoadGVHoaDon();
            LoadData();
        }
        private void NhapHangLoad()
        {
            // Load combobox
            cbbNhaCungCap.DataSource = busnhacungcap.LoadNhaCungCap();
            cbbNhaCungCap.DisplayMember = "TenNCC";
            cbbNhaCungCap.ValueMember = "MaNCC";

            //Load giv
            gvnhaphang.DataSource = busctnhaphang.DanhSachCTNhapHang();
            LoadGVCTNhapHang();
            LoadData();
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

            timer2.Interval = 10;
            timer2.Tick += new EventHandler(timer_hienhanh_1_Tick);
            timer2.Start(); // Bắt đầu chạy timer

            danhsachSP = bussanpham.DanhSachSLNameSP();
            cboProductNameQuantity.Items.Clear();
            cbbSanPhamTonKho.Items.Clear();
            foreach (string item in danhsachSP)
            {
                cboProductNameQuantity.Items.Add(item);
                cbbSanPhamTonKho.Items.Add(item);
            }

            txtEmployeeIdName.Text = BUS_NhanVien.LayIdHoTenNhanVien(email);
            txtNhanVienNhapKho.Text = BUS_NhanVien.LayIdHoTenNhanVien(email);
        }

        //Thiết lặt thao tác cho bán hàng
        private void SetValueBanHang(bool param, bool isLoad)
        {
            btnThem.Enabled = param;

            txtUnitPrice.Text = null;
            txtQuantity.Text = null;
            txtQuantity.Focus();

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
        //Thiết lặt thao tác nhập hàng
        private void SetValueNhapHang(bool param, bool isLoad)
        {


            btnThemNhap.Enabled = param;

            txtSoLuongNhap.Text = null;
            txtDonGiaNhap.Text = null;

            if (isLoad) // true
            {
                btnSuaNhap.Enabled = false;
                btnXoaNhap.Enabled = false;
            }
            else // false
            {
                btnSuaNhap.Enabled = !param;// !param == true
                btnXoaNhap.Enabled = !param;// !param == true
            }
        }
        private void btnlammoi_Click(object sender, EventArgs e)
        {
            SetValueBanHang(true, false);

        }
        private void loadtongtien()
        {
            double tongtien = buscthoadon.GetTotalPrice();

            if (tongtien != null)
            {
                txtTotalPrice.Text = Convert.ToString(tongtien);
            }

        }
        private void loadtongtiennhap()
        {
            double tongtiens = busctnhaphang.GetTongTienNhapHang();

            if (tongtiens != null)
            {
                txtThanhTienNhap.Text = Convert.ToString(tongtiens);
            }

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
                int soluong = int.Parse(txtQuantity.Text);
                str = cboProductNameQuantity.SelectedItem.ToString();
                strlist = str.Split(separator);
                tensanpham = strlist[0].Trim();
                soluongsp = int.Parse(strlist[1].Trim());
                int id_sp = bussanpham.GetProductId(tensanpham);
                if (soluong > soluongsp)
                {
                    MsgBox("Số lượng thêm vượt quá tồn kho! Vui lòng nhập lại số lượng!");
                    BanHangLoad();
                    loadtongtien();
                    return;
                }

                if (txtQuantity.Text != "")
                {
                    
                    
                    double gia = double.Parse(txtUnitPrice.Text);
                    dtoChitiethoadon = new DTO_ChiTietHoaDon(id_sp, soluong, gia);
                    if (buscthoadon.KiemTraMatHangTrung(id_sp, soluong))
                    {
                        MsgBox("Mặt hàng bán đã có. Tăng số lượng thêm " + soluong + "!");
                        BanHangLoad();
                        loadtongtien();
                        SetValueBanHang(true, false);
                    }
                    else
                    {
                        if (buscthoadon.ThemCTHoaDon(dtoChitiethoadon))
                        {
                            danhsachSP = bussanpham.DanhSachSLNameSP();
                            txtTotalPrice.Text = buscthoadon.GetTotalPrice().ToString();
                            MsgBox("Thêm hóa đơn thành công");
                            BanHangLoad();
                            loadtongtien();
                            SetValueBanHang(true, false);
                        }
                        else
                            MsgBox("Thêm không thành công", true);
                    }
                    
                }
                else
                    MsgBox("Vui lòng kiểm tra lại dữ liệu", true);
            }
            catch
            {
                //MsgBox("Thêm không thành công", true);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {

            string masp = gvCTHoaDon.CurrentRow.Cells[1].Value.ToString();
            int id = bussanpham.GetProductId(masp);
            int soluong = int.Parse(txtQuantity.Text);

            //str = cboProductNameQuantity.SelectedItem.ToString();
            //strlist = str.Split(separator);

            if (buscthoadon.SuaSanPhamCTHoaDon(id, soluong))
            {
                txtTotalPrice.Text = buscthoadon.GetTotalPrice().ToString();
                MsgBox("Sửa sản phẩm thành công!");
                BanHangLoad();
                loadtongtien();
                SetValueBanHang(true, false);
            }
            else
            {
                MsgBox("Sửa sản phẩm không được", true);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string masp = gvCTHoaDon.CurrentRow.Cells[1].Value.ToString();
            int id = bussanpham.GetProductId(masp);
            if (MessageBox.Show("Bạn có chắc muốn xóa", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (buscthoadon.XoaSanPhamCTHoaDon(id))
                {
                    MsgBox("Xóa thành công");
                    BanHangLoad();
                    loadtongtien();
                    SetValueBanHang(true, false);
                }
                else
                    MsgBox("Không xóa được", true);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                //MsgBox("Thanh toán thành công", false);
                string kh = cboCustomerIdName.Text;
                string time = txtDateTime.Text;
                BaoCaoBanHang bc = new BaoCaoBanHang(taikhoan, kh, time);
                bc.CreateDocument();
                bc.ShowPreview();

                str = txtEmployeeIdName.Text.Trim();
                strlist = str.Split(separator);
                string employeeId = strlist[0].Trim();

                str = cboCustomerIdName.SelectedItem.ToString();
                strlist = str.Split(separator);


                string customerId = strlist[0].Trim();
                double gia = buscthoadon.GetTotalPrice();
                dtoHoadon = new DTO_HoaDon
                (
                    int.Parse(employeeId),
                    int.Parse(customerId),
                  gia
                );
                if (bushoadon.ThemHoaDon(dtoHoadon))
                {
                    
                    BanHangLoad();
                }
                else
                    MsgBox("Thanh toán không thành công", true);
            }
            catch
            {
                MessageBox.Show("Lỗi XD:");
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

        private void picNhaCungCap_Click(object sender, EventArgs e)
        {
            new FrmQuanLyNhaCungCap().ShowDialog();
        }

        private void cbbSanPhamTonKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = cbbSanPhamTonKho.SelectedItem.ToString();
            char separator = '|';
            String[] strlist = str.Split(separator);
            tensanpham = strlist[0].Trim();
            txtDonGiaNhap.Text = bussanpham.LayGiaNhapSP(tensanpham).ToString();
        }

        private void btnThemNhap_Click(object sender, EventArgs e)
        {
            try
            {
                str = cbbSanPhamTonKho.SelectedItem.ToString();
                strlist = str.Split(separator);
                tensanpham = strlist[0].Trim();

                if (txtSoLuongNhap.Text != "")
                {

                    int id_sp = bussanpham.GetProductId(tensanpham);
                    int soluong = int.Parse(txtSoLuongNhap.Text);
                    float gia = float.Parse(txtDonGiaNhap.Text);

                    dtoctnhaphang = new DTO_ChiTietNhapHang(id_sp, soluong, gia);
                    if (busctnhaphang.KiemTraNhapHangTrung(id_sp, soluong))
                    {
                        MsgBox("Mặt hàng nhập đã có. Tăng số lượng thêm "+soluong+"!");
                        NhapHangLoad();
                        loadtongtiennhap();
                        SetValueNhapHang(true, false);
                    }
                    else
                    {
                        if (busctnhaphang.ThemCTNhapHang(dtoctnhaphang))
                        {
                            danhsachSP = bussanpham.DanhSachSLNameSP();
                            MsgBox("Nhập hàng thành công");
                            NhapHangLoad();
                            loadtongtiennhap();
                            SetValueNhapHang(true, false);
                        }
                        else
                            MsgBox("Nhập hàng không thành công", true);
                    }
                    
                }
                else
                    MsgBox("Vui lòng kiểm tra lại dữ liệu", true);
            }
            catch
            {
                MsgBox("Nhập hàng không thành công", true);
            }
        }

        private void btnSuaNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string strmasp = gvnhaphang.CurrentRow.Cells[1].Value.ToString();
                int id = bussanpham.GetProductId(strmasp);
                int soluong = int.Parse(txtSoLuongNhap.Text);


                dtoctnhaphang = new DTO_ChiTietNhapHang(id, soluong);

                if (busctnhaphang.SuaCTNhapHang(dtoctnhaphang))
                {

                    MsgBox("Sửa thành công!");
                    NhapHangLoad();
                    loadtongtiennhap();
                    SetValueNhapHang(true, false);
                }
                else
                {
                    MsgBox("Sửa không được", true);
                }
            }
            catch (Exception)
            {
            }
        }
        private void btnXoaNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string strmasp = gvnhaphang.CurrentRow.Cells[1].Value.ToString();

                int id = bussanpham.GetProductId(strmasp);

                if (MessageBox.Show("Bạn có chắc muốn xóa", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (busctnhaphang.XoaCTNhapHang(id))
                    {
                        MsgBox("Xóa thành công");
                        NhapHangLoad();
                        loadtongtiennhap();
                        SetValueNhapHang(true, false);
                    }
                    else
                        MsgBox("Không xóa được", true);
                }
            }
            catch (Exception)
            {
            }

        }
        private void gvnhaphang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnSuaNhap.Enabled = btnXoaNhap.Enabled = true;
                if (gvnhaphang.Rows.Count > 0)
                {
                    txtSoLuongNhap.Text = gvnhaphang.CurrentRow.Cells[2].Value.ToString();
                    txtDonGiaNhap.Text = gvnhaphang.CurrentRow.Cells[3].Value.ToString();
                }
            }
            catch (Exception)
            {
            }
        }
        private void gvCTHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnSua.Enabled = btnXoa.Enabled = true;

                if (gvCTHoaDon.Rows.Count > 0)
                {
                    txtQuantity.Text = gvCTHoaDon.CurrentRow.Cells[2].Value.ToString();
                    txtUnitPrice.Text = gvCTHoaDon.CurrentRow.Cells[3].Value.ToString();
                }
            }
            catch (Exception)
            {
            }
        }
        private void btnLamMoiNhap_Click(object sender, EventArgs e)
        {
            SetValueNhapHang(true, false);
        }
        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            try
            {
                string ncc = cbbNhaCungCap.Text;
                string time = guna2TextBox4.Text;
                BaoCaoNhapKho bc = new BaoCaoNhapKho(taikhoan, ncc, time);
                bc.CreateDocument();
                bc.ShowPreview();

                str = txtNhanVienNhapKho.Text.Trim();
                strlist = str.Split(separator);
                string employeeId = strlist[0].Trim();
                string product = cbbNhaCungCap.SelectedValue.ToString();
                double gia = busctnhaphang.GetTongTienNhapHang();
                dtonhanhang = new DTO_NhapHang
                (
                    int.Parse(employeeId),
                    int.Parse(product),
                  gia
                );
                if (busnhanhang.ThemPhieuNhap(dtonhanhang))
                {
                   
                    NhapHangLoad();
                    SetValueNhapHang(true, false);
                }
                else
                    MsgBox("Nhập hàng không thành công", true);
            }
            catch (Exception)
            {

            }

        }
        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;

            string ngay = selectedDate.ToString("yyyy/MM/dd");

            if (ngay == "")
            {
                FrmBanHang_Load(sender, e);
                txtSearch.Focus();
            }
            else
            {
                DataTable data = bushoadon.TimKiemNgayHoaDon(ngay);
                gvHoaDon.DataSource = data;
            }
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                //int ma_cthd = int.Parse(gvCTHoaDon.CurrentRow.Cells[0].Value.ToString());
                string kh = cboCustomerIdName.Text;
                string time = txtDateTime.Text;
                BaoCaoBanHang bc = new BaoCaoBanHang(taikhoan, kh, time);
                bc.CreateDocument();
                bc.ShowPreview();
            }
            catch
            {

                MessageBox.Show("Vui lòng chọn khách hàng cần thanh toán!");
            }
        }
        private void LoadNgam()
        {
            LoadSanPhamBanChamTheoSL();
        }
        private void btnBaoCaoNhapKho_Click(object sender, EventArgs e)
        {
            //int ma = int.Parse(gvnhaphang.CurrentRow.Cells[0].Value.ToString());
            string ncc = cbbNhaCungCap.Text;
            string time = guna2TextBox4.Text;
            BaoCaoNhapKho bc = new BaoCaoNhapKho(taikhoan, ncc, time);
            bc.CreateDocument();
            bc.ShowPreview();
        }

        private void timer_hienhanh_1_Tick(object sender, EventArgs e)
        {
            dateTime2 = DateTime.Now;
            guna2TextBox4.Text = dateTime2.ToString("dd/MM/yyyy") + " " + dateTime2.ToString("HH:mm:ss"); // định dạnh ngày/tháng/năm
        }

        private void btnlammoihoadon_Click(object sender, EventArgs e)
        {
            //FrmBanHang_Load(sender,e);
            HoaDonLoad();

        }
        public class ProductSalex
        {
            public int ProductId { get; set; }
            public int Features { get; set; }
            public string Name { get; set; }

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
            gvCTHoaDon.Columns[3].DefaultCellStyle.Format = "N";
        }
        private void LoadGVCTNhapHang()
        {
            gvnhaphang.Columns[0].HeaderText = "Mã CTNH";
            gvnhaphang.Columns[1].HeaderText = "Tên sản phẩm";
            gvnhaphang.Columns[2].HeaderText = "Số lượng";
            gvnhaphang.Columns[3].HeaderText = "Giá";


            foreach (DataGridViewColumn item in gvnhaphang.Columns)
            {
                item.DividerWidth = 1;
            }
            gvnhaphang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvnhaphang.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvnhaphang.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvnhaphang.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvnhaphang.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvnhaphang.Columns[3].DefaultCellStyle.Format = "N";
        }
        private void LoadGVHoaDon()
        {
            gvHoaDon.Columns[0].HeaderText = "Mã HD";
            gvHoaDon.Columns[1].HeaderText = "Tên nhân viên GD";
            gvHoaDon.Columns[2].HeaderText = "Tên khách hàng";
            gvHoaDon.Columns[3].HeaderText = "Ngày GD";
            gvHoaDon.Columns[4].HeaderText = "Thành tiền";

            gvHoaDon.Columns[0].Width = 70;
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
            gvHoaDon.Columns[4].DefaultCellStyle.Format = "C";
        }

      
        // Class để lưu trữ dữ liệu sản phẩm
        public class ProductSale
        {
            public int ProductId { get; set; }
            public float[] Features { get; set; }
            public string Name { get; set; }

        }
      
        public class ProductSalePrediction
        {
            [ColumnName("PredictedLabel")]
            public bool Prediction { get; set; }
            // Các thuộc tính khác của dự đoán
        }

        private void LoadSanPhamBanChamTheoSL()
        {
            try
            {
                mlContext = new MLContext();

                // Chuyển đổi dữ liệu SoLuong thành mảng các số
                var sanphams = qllkdt.SanPhams.Select(p => new ProductSale
                {
                    ProductId = p.MaSP,
                    Name = p.TenSP,
                    Features = new float[] { p.SoLuong.GetValueOrDefault() }
                }).ToList();

                var data = mlContext.Data.LoadFromEnumerable<ProductSale>(sanphams);

                var trainedModel = TrainModel(data);

                var predictions = Predict(trainedModel, data);

                var slowSellingProducts = predictions.Where(p => p.Prediction).ToList();

                databancham.DataSource = slowSellingProducts;

                int soluongsanphambancham = slowSellingProducts.Count();

                label_sosanphambancham.Text = Convert.ToString(soluongsanphambancham);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnDuyetDonDatHang_Click(object sender, EventArgs e)
        {
            str = txtEmployeeIdName.Text.Trim();
            strlist = str.Split(separator);
            string employeeId = strlist[0].Trim();

            FrmDonDatHang frm = new FrmDonDatHang(employeeId);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void btnThongTinNhapHang_Click(object sender, EventArgs e)
        {
            new FrmThongTinNhapHang().ShowDialog();
        }

        private IEnumerable<ProductSalePrediction> Predict(ITransformer trainedModel, IDataView data)
        {
            throw new NotImplementedException();
        }

        private ITransformer TrainModel(IDataView data)
        {
            // Xây dựng pipeline để huấn luyện mô hình
            var pipeline = mlContext.Transforms.CopyColumns(inputColumnName: "Features", outputColumnName: "Features")
                .Append(mlContext.BinaryClassification.Trainers.LightGbm(labelColumnName: "IsSlowSelling"));

            // Huấn luyện mô hình với dữ liệu
            var trainedModel = pipeline.Fit(data);

            return trainedModel;
        }
        private IEnumerable<ProductSalePrediction> Predict(ITransformer model, IEnumerable<ProductSale> products)
        {
            // Dùng mô hình đã huấn luyện để dự đoán cho danh sách sản phẩm
            var predictionEngine = mlContext.Model.CreatePredictionEngine<ProductSale, ProductSalePrediction>(model);

            foreach (var product in products)
            {
                var prediction = predictionEngine.Predict(product);
                yield return prediction;
            }
        }

    }
}
