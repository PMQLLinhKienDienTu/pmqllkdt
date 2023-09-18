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
    public partial class FrmBaoCaoThongKe : Form
    {
        public FrmBaoCaoThongKe()
        {
            InitializeComponent();
            ColorChangeEventProvider.ColorChanged += ColorChangeEventProvider_ColorChanged;
        }
        private void ColorChangeEventProvider_ColorChanged(object sender, ColorChangedEventArgs e)
        {
            Guna.UI2.WinForms.Guna2Panel[] panels = { guna2Panel1, guna2Panel2, guna2Panel3, guna2Panel4, guna2Panel5 };

            foreach (var panel in panels)
            {
                panel.BackColor = e.NewColor;
            }

        }

        private void FrmBaoCaoThongKe_Load(object sender, EventArgs e)
        {

        }
    }
}
