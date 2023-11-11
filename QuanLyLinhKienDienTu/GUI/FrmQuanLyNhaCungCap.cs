using System;
using System.Windows.Forms;
using BUS;
namespace GUI
{
    public partial class FrmQuanLyNhaCungCap : Form
    {
        BUS_NhaCungCap nhacungcap = new BUS_NhaCungCap();
        public FrmQuanLyNhaCungCap()
        {
            InitializeComponent();
        }
        private void FrmQuanLyNhaCungCap_Load(object sender, EventArgs e)
        {
            this.LoadData();
            SetValue(true, false);
        }
        private void LoadData()
        {
            gvNhaCungCap.DataSource = nhacungcap.LoadNhaCungCap();
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SetValue(bool param, bool isLoad)
        {
            txtMaNCC.Text = null;
            txtTenNCC.Text = null;
            txtDiaChi.Text = null;
            txtEmail.Text = null;
            txtSDT.Text = null;
            btnThem.Enabled = param;

            txtTenNCC.Focus();
            if (isLoad)
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                btnSua.Enabled = !param;// !param == true
                btnXoa.Enabled = !param;// !param == true
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = nhacungcap.ThemNCC(txtTenNCC.Text, txtDiaChi.Text, txtEmail.Text, txtSDT.Text);
                if (result)
                {
                    MessageBox.Show("Thêm thành công");
                    SetValue(true, false);
                    this.LoadData();
                }
                else
                    MessageBox.Show("Thêm thất bại");
            }
            catch (Exception) { }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa nhà cung cấp này không", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    //string ma = gvNhaCungCap.CurrentRow.Cells[0].Value.ToString();
                    int maNCC = int.Parse(txtMaNCC.Text.Trim());
                    bool result = nhacungcap.XoaNCC(maNCC);
                    if (result)
                    {
                        MessageBox.Show("Xóa thành công");
                        SetValue(true, false);
                        this.LoadData();
                    }
                    else
                        MessageBox.Show("Xóa thất bại");
                }

            }
            catch (Exception) { }

        }

        private void gvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = btnXoa.Enabled = true;
            try
            {
                if (gvNhaCungCap.Rows.Count > 0)
                {
                    txtMaNCC.Text = gvNhaCungCap.CurrentRow.Cells[0].Value.ToString();
                    txtTenNCC.Text = gvNhaCungCap.CurrentRow.Cells[1].Value.ToString();
                    txtDiaChi.Text = gvNhaCungCap.CurrentRow.Cells[2].Value.ToString();
                    txtEmail.Text = gvNhaCungCap.CurrentRow.Cells[3].Value.ToString();
                    txtSDT.Text = gvNhaCungCap.CurrentRow.Cells[4].Value.ToString();
                }
            }
            catch (Exception) { }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                //string ma = gvNhaCungCap.CurrentRow.Cells[0].Value.ToString();
                int maNCC = int.Parse(txtMaNCC.Text.Trim());

                bool result = nhacungcap.SuaNCC(maNCC, txtTenNCC.Text, txtDiaChi.Text, txtEmail.Text, txtSDT.Text);
                if (result)
                {
                    MessageBox.Show(" Sửa thành công");
                    SetValue(true, false);
                    this.LoadData();
                }
                else
                    MessageBox.Show("Sửa thất bại");
            }
            catch (Exception) { }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            SetValue(true, false);
        }
        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                guna2Panel1.Capture = false;
                const int WM_NCLBUTTONDOWN = 0x00A1;
                const int HTCAPTION = 2;
                Message msg =
                    Message.Create(this.Handle, WM_NCLBUTTONDOWN,
                        new IntPtr(HTCAPTION), IntPtr.Zero);
                this.DefWndProc(ref msg);
            }
        }
    }
}
