using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.NhanVien
{
    public partial class frmDoiMatKhau : Form
    {
        string tenDangNhap;
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        public frmDoiMatKhau(string tenDangNhap)
        {
            this.tenDangNhap = tenDangNhap;
            InitializeComponent();
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            new frmNhanVien(tenDangNhap).ShowDialog();

        }
    }
}
