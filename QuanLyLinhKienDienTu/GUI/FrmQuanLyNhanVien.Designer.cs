namespace GUI
{
    partial class FrmQuanLyNhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.gvNhanVien = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.radActive = new Guna.UI2.WinForms.Guna2RadioButton();
            this.radNonActive = new Guna.UI2.WinForms.Guna2RadioButton();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.radEmployee = new Guna.UI2.WinForms.Guna2RadioButton();
            this.radAdmin = new Guna.UI2.WinForms.Guna2RadioButton();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnInsert = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDelete = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaiKhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvNhanVien)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.guna2GroupBox2.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.Controls.Add(this.gvNhanVien);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1015, 750);
            this.guna2Panel1.TabIndex = 0;
            // 
            // gvNhanVien
            // 
            this.gvNhanVien.AllowUserToAddRows = false;
            this.gvNhanVien.AllowUserToDeleteRows = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            this.gvNhanVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.gvNhanVien.ColumnHeadersHeight = 35;
            this.gvNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNhanVien,
            this.TenNhanVien,
            this.TaiKhoan,
            this.Email,
            this.ChucVu,
            this.TinhTrang});
            this.gvNhanVien.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvNhanVien.DefaultCellStyle = dataGridViewCellStyle18;
            this.gvNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvNhanVien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gvNhanVien.Location = new System.Drawing.Point(0, 335);
            this.gvNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.gvNhanVien.Name = "gvNhanVien";
            this.gvNhanVien.ReadOnly = true;
            this.gvNhanVien.RowHeadersVisible = false;
            this.gvNhanVien.RowHeadersWidth = 51;
            this.gvNhanVien.RowTemplate.Height = 35;
            this.gvNhanVien.Size = new System.Drawing.Size(1015, 415);
            this.gvNhanVien.TabIndex = 1;
            this.gvNhanVien.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gvNhanVien.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gvNhanVien.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gvNhanVien.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gvNhanVien.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gvNhanVien.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gvNhanVien.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gvNhanVien.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gvNhanVien.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gvNhanVien.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.gvNhanVien.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gvNhanVien.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvNhanVien.ThemeStyle.HeaderStyle.Height = 35;
            this.gvNhanVien.ThemeStyle.ReadOnly = true;
            this.gvNhanVien.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gvNhanVien.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gvNhanVien.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.gvNhanVien.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gvNhanVien.ThemeStyle.RowsStyle.Height = 35;
            this.gvNhanVien.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gvNhanVien.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(2)))), ((int)(((byte)(22)))));
            this.guna2Panel2.Controls.Add(this.guna2GroupBox2);
            this.guna2Panel2.Controls.Add(this.guna2GroupBox1);
            this.guna2Panel2.Controls.Add(this.label5);
            this.guna2Panel2.Controls.Add(this.txtSearch);
            this.guna2Panel2.Controls.Add(this.btnInsert);
            this.guna2Panel2.Controls.Add(this.btnRefresh);
            this.guna2Panel2.Controls.Add(this.btnUpdate);
            this.guna2Panel2.Controls.Add(this.label6);
            this.guna2Panel2.Controls.Add(this.btnDelete);
            this.guna2Panel2.Controls.Add(this.txtPhoneNumber);
            this.guna2Panel2.Controls.Add(this.label4);
            this.guna2Panel2.Controls.Add(this.txtAddress);
            this.guna2Panel2.Controls.Add(this.label3);
            this.guna2Panel2.Controls.Add(this.txtEmail);
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.Controls.Add(this.txtName);
            this.guna2Panel2.Controls.Add(this.label1);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1015, 335);
            this.guna2Panel2.TabIndex = 0;
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guna2GroupBox2.BorderColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox2.Controls.Add(this.radActive);
            this.guna2GroupBox2.Controls.Add(this.radNonActive);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox2.Location = new System.Drawing.Point(634, 161);
            this.guna2GroupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(336, 74);
            this.guna2GroupBox2.TabIndex = 33;
            // 
            // radActive
            // 
            this.radActive.Animated = true;
            this.radActive.AutoSize = true;
            this.radActive.Checked = true;
            this.radActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.radActive.CheckedState.BorderThickness = 0;
            this.radActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.radActive.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radActive.CheckedState.InnerOffset = -4;
            this.radActive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radActive.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.radActive.ForeColor = System.Drawing.Color.White;
            this.radActive.Location = new System.Drawing.Point(16, 25);
            this.radActive.Margin = new System.Windows.Forms.Padding(4);
            this.radActive.Name = "radActive";
            this.radActive.Size = new System.Drawing.Size(128, 32);
            this.radActive.TabIndex = 14;
            this.radActive.TabStop = true;
            this.radActive.Tag = "";
            this.radActive.Text = "Hoạt động";
            this.radActive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radActive.UncheckedState.BorderThickness = 2;
            this.radActive.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radActive.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // radNonActive
            // 
            this.radNonActive.Animated = true;
            this.radNonActive.AutoSize = true;
            this.radNonActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.radNonActive.CheckedState.BorderThickness = 0;
            this.radNonActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.radNonActive.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radNonActive.CheckedState.InnerOffset = -4;
            this.radNonActive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radNonActive.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radNonActive.ForeColor = System.Drawing.Color.White;
            this.radNonActive.Location = new System.Drawing.Point(162, 30);
            this.radNonActive.Margin = new System.Windows.Forms.Padding(4);
            this.radNonActive.Name = "radNonActive";
            this.radNonActive.Size = new System.Drawing.Size(183, 29);
            this.radNonActive.TabIndex = 15;
            this.radNonActive.Tag = "";
            this.radNonActive.Text = "Ngưng hoạt động";
            this.radNonActive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radNonActive.UncheckedState.BorderThickness = 2;
            this.radNonActive.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radNonActive.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.Controls.Add(this.radEmployee);
            this.guna2GroupBox1.Controls.Add(this.radAdmin);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(122, 161);
            this.guna2GroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(290, 74);
            this.guna2GroupBox1.TabIndex = 20;
            // 
            // radEmployee
            // 
            this.radEmployee.Animated = true;
            this.radEmployee.AutoSize = true;
            this.radEmployee.Checked = true;
            this.radEmployee.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.radEmployee.CheckedState.BorderThickness = 0;
            this.radEmployee.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.radEmployee.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radEmployee.CheckedState.InnerOffset = -4;
            this.radEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radEmployee.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.radEmployee.ForeColor = System.Drawing.Color.White;
            this.radEmployee.Location = new System.Drawing.Point(21, 23);
            this.radEmployee.Margin = new System.Windows.Forms.Padding(4);
            this.radEmployee.Name = "radEmployee";
            this.radEmployee.Size = new System.Drawing.Size(131, 34);
            this.radEmployee.TabIndex = 1;
            this.radEmployee.TabStop = true;
            this.radEmployee.Tag = "";
            this.radEmployee.Text = "Nhân viên";
            this.radEmployee.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radEmployee.UncheckedState.BorderThickness = 2;
            this.radEmployee.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radEmployee.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // radAdmin
            // 
            this.radAdmin.Animated = true;
            this.radAdmin.AutoSize = true;
            this.radAdmin.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.radAdmin.CheckedState.BorderThickness = 0;
            this.radAdmin.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.radAdmin.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radAdmin.CheckedState.InnerOffset = -4;
            this.radAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radAdmin.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.radAdmin.ForeColor = System.Drawing.Color.White;
            this.radAdmin.Location = new System.Drawing.Point(182, 23);
            this.radAdmin.Margin = new System.Windows.Forms.Padding(4);
            this.radAdmin.Name = "radAdmin";
            this.radAdmin.Size = new System.Drawing.Size(108, 34);
            this.radAdmin.TabIndex = 13;
            this.radAdmin.Tag = "";
            this.radAdmin.Text = "Quản lý";
            this.radAdmin.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radAdmin.UncheckedState.BorderThickness = 2;
            this.radAdmin.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radAdmin.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSearch.Animated = true;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.txtSearch.BorderRadius = 6;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(2)))), ((int)(((byte)(22)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Location = new System.Drawing.Point(680, 260);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "Nhập tên NV để tìm kiếm";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(321, 53);
            this.txtSearch.TabIndex = 28;
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnInsert.Animated = true;
            this.btnInsert.BorderRadius = 10;
            this.btnInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsert.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnInsert.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInsert.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInsert.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInsert.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInsert.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInsert.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnInsert.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnInsert.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnInsert.ForeColor = System.Drawing.Color.White;
            this.btnInsert.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnInsert.Location = new System.Drawing.Point(39, 260);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(127, 53);
            this.btnInsert.TabIndex = 18;
            this.btnInsert.Text = "Thêm";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRefresh.Animated = true;
            this.btnRefresh.BorderRadius = 10;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefresh.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnRefresh.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(505, 260);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(154, 53);
            this.btnRefresh.TabIndex = 25;
            this.btnRefresh.Text = "Làm mới";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUpdate.Animated = true;
            this.btnUpdate.BorderRadius = 10;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpdate.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUpdate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnUpdate.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(199, 260);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(127, 53);
            this.btnUpdate.TabIndex = 21;
            this.btnUpdate.Text = "Sửa";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(500, 186);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 30);
            this.label6.TabIndex = 32;
            this.label6.Text = "Tình trạng:";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDelete.Animated = true;
            this.btnDelete.BorderRadius = 10;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDelete.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelete.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(356, 260);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(127, 53);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Xoá";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(33, 184);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 30);
            this.label5.TabIndex = 31;
            this.label5.Text = "Chức vụ:";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPhoneNumber.Animated = true;
            this.txtPhoneNumber.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.txtPhoneNumber.BorderRadius = 6;
            this.txtPhoneNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhoneNumber.DefaultText = "";
            this.txtPhoneNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhoneNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPhoneNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhoneNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhoneNumber.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(2)))), ((int)(((byte)(22)))));
            this.txtPhoneNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPhoneNumber.ForeColor = System.Drawing.Color.Yellow;
            this.txtPhoneNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhoneNumber.Location = new System.Drawing.Point(680, 108);
            this.txtPhoneNumber.Margin = new System.Windows.Forms.Padding(5);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.PasswordChar = '\0';
            this.txtPhoneNumber.PlaceholderText = "";
            this.txtPhoneNumber.SelectedText = "";
            this.txtPhoneNumber.Size = new System.Drawing.Size(261, 44);
            this.txtPhoneNumber.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(526, 118);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 30);
            this.label4.TabIndex = 30;
            this.label4.Text = "Số điện thoại:";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAddress.Animated = true;
            this.txtAddress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.txtAddress.BorderRadius = 6;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(2)))), ((int)(((byte)(22)))));
            this.txtAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAddress.ForeColor = System.Drawing.Color.Yellow;
            this.txtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.Location = new System.Drawing.Point(680, 37);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(5);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PasswordChar = '\0';
            this.txtAddress.PlaceholderText = "";
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(261, 44);
            this.txtAddress.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(536, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 30);
            this.label3.TabIndex = 29;
            this.label3.Text = "Tài khoản:";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtEmail.Animated = true;
            this.txtEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.txtEmail.BorderRadius = 6;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(2)))), ((int)(((byte)(22)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtEmail.ForeColor = System.Drawing.Color.Yellow;
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(122, 108);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(261, 44);
            this.txtEmail.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(44, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 30);
            this.label2.TabIndex = 26;
            this.label2.Text = "Email:";
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtName.Animated = true;
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.txtName.BorderRadius = 6;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(2)))), ((int)(((byte)(22)))));
            this.txtName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtName.ForeColor = System.Drawing.Color.Yellow;
            this.txtName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtName.Location = new System.Drawing.Point(122, 38);
            this.txtName.Margin = new System.Windows.Forms.Padding(5);
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.PlaceholderText = "";
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(261, 44);
            this.txtName.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(34, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 30);
            this.label1.TabIndex = 17;
            this.label1.Text = "Họ tên:";
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.FillWeight = 53.47594F;
            this.MaNhanVien.HeaderText = "Mã NV";
            this.MaNhanVien.MinimumWidth = 6;
            this.MaNhanVien.Name = "MaNhanVien";
            this.MaNhanVien.ReadOnly = true;
            // 
            // TenNhanVien
            // 
            this.TenNhanVien.FillWeight = 111.631F;
            this.TenNhanVien.HeaderText = "Tên nhân viên";
            this.TenNhanVien.MinimumWidth = 6;
            this.TenNhanVien.Name = "TenNhanVien";
            this.TenNhanVien.ReadOnly = true;
            // 
            // TaiKhoan
            // 
            this.TaiKhoan.FillWeight = 111.631F;
            this.TaiKhoan.HeaderText = "Tài khoản";
            this.TaiKhoan.MinimumWidth = 6;
            this.TaiKhoan.Name = "TaiKhoan";
            this.TaiKhoan.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.FillWeight = 111.631F;
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // ChucVu
            // 
            this.ChucVu.FillWeight = 111.631F;
            this.ChucVu.HeaderText = "Chức vụ";
            this.ChucVu.MinimumWidth = 6;
            this.ChucVu.Name = "ChucVu";
            this.ChucVu.ReadOnly = true;
            // 
            // TinhTrang
            // 
            this.TinhTrang.HeaderText = "Tình Trạng";
            this.TinhTrang.MinimumWidth = 6;
            this.TinhTrang.Name = "TinhTrang";
            this.TinhTrang.ReadOnly = true;
            // 
            // FrmQuanLyNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1015, 750);
            this.Controls.Add(this.guna2Panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmQuanLyNhanVien";
            this.Text = "FrmQuanLyNhanVien";
            this.Load += new System.EventHandler(this.FrmQuanLyNhanVien_Load);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvNhanVien)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2GroupBox2.ResumeLayout(false);
            this.guna2GroupBox2.PerformLayout();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2DataGridView gvNhanVien;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private Guna.UI2.WinForms.Guna2RadioButton radActive;
        private Guna.UI2.WinForms.Guna2RadioButton radNonActive;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2RadioButton radEmployee;
        private Guna.UI2.WinForms.Guna2RadioButton radAdmin;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2GradientButton btnInsert;
        private Guna.UI2.WinForms.Guna2GradientButton btnRefresh;
        private Guna.UI2.WinForms.Guna2GradientButton btnUpdate;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2GradientButton btnDelete;
        private Guna.UI2.WinForms.Guna2TextBox txtPhoneNumber;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TinhTrang;
    }
}