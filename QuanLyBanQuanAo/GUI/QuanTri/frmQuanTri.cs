using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmQuanTri : Form
    {
        public frmQuanTri()
        {
            InitializeComponent();
        }

        private void loạiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmQuanLyLoaiSanPham().ShowDialog();
            this.Close();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new QuanTri.frmQuanLyNhanVien().ShowDialog();
            this.Close();
        }

        private void thốngKêDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new QuanTri.frmThongKe().ShowDialog();
            this.Close();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmDangNhap().ShowDialog();
            this.Close();
        }

        private void khuyếnMạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new QuanTri.frmQuanLyKhuyenMai().ShowDialog();
            this.Close();
        }
    }
}
