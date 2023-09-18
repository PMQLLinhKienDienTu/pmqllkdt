using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GUI.FrmMain;

namespace GUI
{
    public partial class FrmBanHang : Form
    {
        public FrmBanHang()
        {
            InitializeComponent();
            ColorChangeEventProvider.ColorChanged += ColorChangeEventProvider_ColorChanged;
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
            guna2TabControl1.TabMenuBackColor = e.NewColor;

        }

        private void FrmBanHang_Load(object sender, EventArgs e)
        {

        }
    }
}
