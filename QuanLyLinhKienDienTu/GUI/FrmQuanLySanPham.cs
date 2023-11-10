using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using BUS;
using System.Management.Instrumentation;
using DTO;
using System.Xml.Linq;
using static GUI.FrmMain;
using DAL;

namespace GUI
{
    public partial class FrmQuanLySanPham : Form
    {
        

        private string fileAddress;
        private byte[] img; // mã hóa hình ảnh lưu trử
        BUS_SanPham bus_sanpham = new BUS_SanPham();
        BUS_PhanLoaiSanPham busloai = new BUS_PhanLoaiSanPham();
        DTO_SanPham dtosanpham;

        BUS_NhanVien busEmployee = new BUS_NhanVien();


        private string[] Danhsachloaisp;
        private string[] DanhsachloaispSearh;
        private string tenloaisp, str;
        private int id;
        private string name;
        private string taikhoan;
        private char separator = '|';
        private string[] strlist;

        public FrmQuanLySanPham(string taikhoan)
        {
            InitializeComponent();
            this.taikhoan = taikhoan;
            ColorChangeEventProvider.ColorChanged += ColorChangeEventProvider_ColorChanged;
        }
        private void ColorChangeEventProvider_ColorChanged(object sender, ColorChangedEventArgs e)
        {
            Guna.UI2.WinForms.Guna2Panel[] panels = { guna2Panel1, guna2Panel2, guna2Panel3, guna2Panel4,guna2Panel5 };

            foreach (var panel in panels)
            {
                panel.BackColor = e.NewColor;
            }     

        }

        private void FrmQuanLySanPham_Load(object sender, EventArgs e)
        {
            gvSanpham.DataSource = bus_sanpham.DanhSachSanPham();
            LoadComboBox();
            LoadGridView();
            loadanh();
            txtName.Focus();
            LoadComboBoxTK();
            loadthongtinnhanvien();
        }

        private void LoadGridView()
        {

            gvSanpham.Columns[0].HeaderText = "Mã SP";
            gvSanpham.Columns[1].HeaderText = "Tên SP";
            gvSanpham.Columns[2].HeaderText = "Số lượng";
            gvSanpham.Columns[3].HeaderText = "Giá nhập";
            gvSanpham.Columns[4].HeaderText = "Giá bán";
            gvSanpham.Columns[5].HeaderText = "Hình ảnh";
            gvSanpham.Columns[6].HeaderText = "Loại";
            gvSanpham.Columns[7].HeaderText = "Ghi chú";

            foreach (DataGridViewColumn item in gvSanpham.Columns)
            {
                item.DividerWidth = 1;
            }
           

            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol = (DataGridViewImageColumn)gvSanpham.Columns[5];
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;

            gvSanpham.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvSanpham.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvSanpham.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvSanpham.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvSanpham.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvSanpham.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvSanpham.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvSanpham.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvSanpham.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        //Load ảnh mặt định
        private void loadanh()
        {


            
        }
        private void loadthongtinnhanvien()
        {
            str = busEmployee.LayNameChucVuNhanVien(taikhoan);
            strlist = str.Split(separator);
         
            string chucvu = strlist[1].Trim();

            if (chucvu == "1")
            {
                btnLoaiLK.Visible = true;
            }         
        }

        // thiết lặp giá trị
        private void SetValue(bool param, bool isLoad)
        {
            txtId.Text = null;

            txtName.Text = null;
            txtQuantity.Text = null;
            txtUnitPrice.Text = null;
            txtImportUnitPrice.Text = null;
            txtNote.Text = null;
            btnThem.Enabled = param;
            pcbProduct.Image = null;

            if (isLoad)
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                btnSua.Enabled = !param;
                btnXoa.Enabled = !param;
            }
        }


        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Kiểm tra số
        private bool CheckIsNummber(string text)
        {
            int s;
            return int.TryParse(text, out s);
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
        // mở  ảnh trong disk
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
                pcbProduct.Image = CloneImage(fileAddress);
                pcbProduct.ImageLocation = fileAddress;
                img = ImageToByteArray(pcbProduct);
            }
        }

        private void LoadComboBox()
        {

            Danhsachloaisp = busloai.DanhsachNameIDLoai();
            cbbLoai.Items.Clear();
            foreach (string item in Danhsachloaisp)
            {
                cbbLoai.Items.Add(item);
            }

           

        }
        private void LoadComboBoxTK()
        {
            DanhsachloaispSearh = busloai.DanhsachNameIDLoai();
            cbbTimKiemLoai.Items.Clear();

            foreach (string item in DanhsachloaispSearh)
            {
                cbbTimKiemLoai.Items.Add(item);
            }


        }

        private void btnLoaiLK_Click(object sender, EventArgs e)
        {
            FrmQuanLyLoaiSanPham loai = new FrmQuanLyLoaiSanPham();
            loai.Show();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!CheckIsNummber(txtQuantity.Text) || !CheckIsNummber(txtUnitPrice.Text) || !CheckIsNummber(txtImportUnitPrice.Text))
                MsgBox("Vui lòng nhập chữ số!", true);
            else if (txtName.Text == "")
                MsgBox("Thiếu trường thông tin!", true);
            else if (pcbProduct.Image == null)
                MsgBox("Vui lòng chọn hình cho sản phẩm!", true);
            else
            {

                tenloaisp = cbbLoai.SelectedItem.ToString();
                int maloai = busloai.LayIDLoaiSP(tenloaisp);
                dtosanpham = new DTO_SanPham
                (
                    txtName.Text,
                    int.Parse(txtQuantity.Text),
                    int.Parse(txtImportUnitPrice.Text),
                    int.Parse(txtUnitPrice.Text),

                    ImageToByteArray(pcbProduct),
                          maloai
                  ,
                    txtNote.Text
                );
                if (bus_sanpham.ThemSanPham(dtosanpham))
                {
                    gvSanpham.DataSource = bus_sanpham.DanhSachSanPham();
                    LoadGridView();
                    MsgBox("Thêm sản phẩm thành công");
                }
                else
                {
                    MsgBox("Thêm sản phẩm không được", true);
                }
            }
        }
        private void btnInsertPicture_Click(object sender, EventArgs e)
        {
            OpenImage();
        }
        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!CheckIsNummber(txtQuantity.Text) || !CheckIsNummber(txtUnitPrice.Text) || !CheckIsNummber(txtImportUnitPrice.Text))
                    MsgBox("Vui lòng nhập chữ số!", true);
                else if (txtName.Text == "")
                    MsgBox("Thiếu trường thông tin!", true);
                else if (pcbProduct.Image == null)
                    MsgBox("Vui lòng chọn hình!", true);
                else
                {

                    tenloaisp = cbbLoai.SelectedItem.ToString();
                    int maloai = busloai.LayIDLoaiSP(tenloaisp);
                    dtosanpham = new DTO_SanPham
                    (
                        int.Parse(txtId.Text),
                        txtName.Text,
                        int.Parse(txtQuantity.Text),
                        int.Parse(txtImportUnitPrice.Text),
                        int.Parse(txtUnitPrice.Text),

                        ImageToByteArray(pcbProduct),
                              maloai
                      ,
                        txtNote.Text
                    );
                    if (bus_sanpham.SuaSanPham(dtosanpham))
                    {
                        gvSanpham.DataSource = bus_sanpham.DanhSachSanPham();
                        LoadGridView();
                        MsgBox("Sửa sản phẩm thành công!");
                    }
                    else
                    {
                        MsgBox("Sửa sản phẩm không được", true);
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (bus_sanpham.XoaSanPham(int.Parse(txtId.Text)))
                {
                    gvSanpham.DataSource = bus_sanpham.DanhSachSanPham();
                    LoadGridView();
                    MsgBox("Xóa sản phẩm thành công");
                }
                else
                    MsgBox("Xóa không thành công!");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            name = txtSearch.Text.Trim();
            if (name == "")
            {
                FrmQuanLySanPham_Load(sender, e);
                txtSearch.Focus();
            }
            else
            {
                DataTable data = bus_sanpham.TimKiemSanPham(name);
                gvSanpham.DataSource = data;
            }
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            SetValue(true, false);
            FrmQuanLySanPham_Load(sender, e);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cbbTimKiemLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loaiyk = cbbTimKiemLoai.SelectedItem.ToString();
            if (loaiyk == "")
            {
                FrmQuanLySanPham_Load(sender, e);
                txtSearch.Focus();
            }
            else
            {
                DataTable data = bus_sanpham.TimKiemSanPhamTheoLoai(loaiyk);
                gvSanpham.DataSource = data;
            }
        }

        private void gvSanpham_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (gvSanpham.Rows.Count > 0)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                txtId.ReadOnly = true;
                txtId.Text = gvSanpham.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = gvSanpham.CurrentRow.Cells[1].Value.ToString();
                txtQuantity.Text = gvSanpham.CurrentRow.Cells[2].Value.ToString();
                txtImportUnitPrice.Text = gvSanpham.CurrentRow.Cells[3].Value.ToString();
                txtUnitPrice.Text = gvSanpham.CurrentRow.Cells[4].Value.ToString();
                MemoryStream memoryStream = new MemoryStream((byte[])gvSanpham.CurrentRow.Cells[5].Value);
                pcbProduct.Image = Image.FromStream(memoryStream);
                cbbLoai.SelectedItem = gvSanpham.CurrentRow.Cells[6].Value.ToString();
                txtNote.Text = gvSanpham.CurrentRow.Cells[7].Value.ToString();

            }
        }

    }
}
