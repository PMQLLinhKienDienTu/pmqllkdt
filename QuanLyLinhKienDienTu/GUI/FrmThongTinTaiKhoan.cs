﻿using BUS;
using DTO;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static GUI.FrmMain;

namespace GUI
{
    public partial class FrmThongTinTaiKhoan : Form
    {
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        DTO_NhanVien dtoNhanVien;

        private byte[] img; // mã hóa hình ảnh lưu trử
        private string email, str;
        private char separator = '|';
        private string[] strlist;
        string taikhoan;

        public FrmThongTinTaiKhoan(string email,string taikhoan)
        {
            InitializeComponent();
            this.email = email;
            this.taikhoan = taikhoan;

            ColorChangeEventProvider.ColorChanged += ColorChangeEventProvider_ColorChanged;
        }
        private void ColorChangeEventProvider_ColorChanged(object sender, ColorChangedEventArgs e)
        {
           guna2Panel1.BackColor = e.NewColor;
        }

        private void LoadData()
        {
            // gọi hàm lấy ID, Name của  nhân viên in class BUS_Employee
            str = busNhanVien.LayIDandHoten(email);

            //Tách chuổi và phân cách 
            strlist = str.Split(separator);

            // Gán txtName.text = chuổi vừa tách
            txtName.Text = strlist[1].Trim();

            // gọi hàm lấy địa chỉ, số điện thoại của  nhân viên in class BUS_Employee
            str = busNhanVien.LayTKandSDT(email);

            //Tách chuổi và phân cách 
            strlist = str.Split(separator);

            //Gán txtTaiKhoan.text = chuổi vừa tách
            txtTaiKhoan.Text = strlist[0].Trim();

            //Gán txtPhoneNumber.Text = chuổi vừa tách
            txtPhoneNumber.Text = strlist[1].Trim();

            txtEmail.Text = email;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData(); // thiết lặp lại
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dtoNhanVien = new DTO_NhanVien(txtTaiKhoan.Text, txtPhoneNumber.Text, txtEmail.Text);

            //Gọi hàm update nhân viên theo địa chỉ, số điện thoại
            if (busNhanVien.CapNhatTKandSDT(dtoNhanVien))
            {
                MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không sửa được thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text != "")
            {
                if (txtNewPassword.Text == txtRepeatPassword.Text)
                {
                    busNhanVien = new BUS_NhanVien();

                    //Gọi hàm kiểm tra ThayDoiMJChucVu
                    if (busNhanVien.ThayDoiMKChucVu(txtEmail.Text, txtOldPassword.Text, txtNewPassword.Text))
                    {
                        MessageBox.Show("Đổi mật khẩu thành công, vui lòng đăng nhập lại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Properties.Settings.Default.mạtkhau = "";
                        Properties.Settings.Default.Save();
                        Application.Restart();
                    }
                    else MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Mật khẩu mới không trùng nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Vui lòng nhập mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }    
        private void loadanh()
        {
            img = busNhanVien.LayAnhNhanVien(taikhoan);

            if (img == null)
            {               
            }
            else
            {
                MemoryStream memoryStream = new MemoryStream(img);
                pic_profile.Image = Image.FromStream(memoryStream);
            }
        }
        private void FrmThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadData(); // Load dữ liệu lên form
            loadanh();
        }
    }
}
