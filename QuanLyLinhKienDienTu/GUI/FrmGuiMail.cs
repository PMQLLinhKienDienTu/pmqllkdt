using BUS;
using System;
using System.Threading;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmGuiMail : Form
    {
        private string result;
        public string Result
        {
            get { return result; }
            set { result = value; }
        }
        public FrmGuiMail(string email,string taikhoan, string pass, bool isUpdate = false)
        {
            InitializeComponent();
            this.email = email;
            this.taikhoan= taikhoan;
            this.password = pass;
            this.isUpdate = isUpdate;
        }
        private string taikhoan; //taikhoan đăng nhập
        private string email; // email cần gửi tin
        private string password; // mật khẩu đăng nhập phần mềm
        private bool isUpdate;

        private void FrmGuiMail_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(Send);
            thread.IsBackground = true;
            thread.Start();
        }
        private void Send()
        {
            string loginEmail = "shopbanquanaonhom10@gmail.com";
            string loginPassword = "shopbanquanao123";
            BUS_Mail mail = new BUS_Mail(loginEmail, loginPassword);
            Result = mail.SendMail(email, taikhoan, password, isUpdate);
            pcbLoader.Invoke(new Action(() => Close()));
        }
    }
}
