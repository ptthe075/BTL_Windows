using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI.QuanTri
{
    public partial class frmQuanLySanPham : Form
    {
        public frmQuanLySanPham()
        {
            InitializeComponent();
        }

        private void frmQuanLySanPham_Load(object sender, EventArgs e)
        {
            HienThiMacDinh(true);
            SanPhamBLL.Instance.TaoDSLoaiSP(cbxLoaiSP, false);
            SanPhamBLL.Instance.TaoDSLoaiSP(cbxTimKiemLoaiSP, true);

        }

        private void txtTimKiemTenSP_TextChanged(object sender, EventArgs e)
        {
            SanPhamBLL.Instance.HienThiDanhSach(dgvSanPham, (int)cbxTimKiemLoaiSP.SelectedValue, txtTimKiemTenSP.Text);
        }

        private void cbxTimKiemLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            var maLoaiSP = cbxTimKiemLoaiSP.SelectedValue;
            if (maLoaiSP is LoaiSanPham) { return; }
            else
            {
                SanPhamBLL.Instance.HienThiDanhSach(dgvSanPham, (int)maLoaiSP, txtTimKiemTenSP.Text);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            /*if (txtTenSP.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tên sản phẩm không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtGiaBan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Đơn giá bán không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtGiaNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Đơn giá bán không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            SanPham sp = new SanPham()
            {
                TenSanPham = txtTenSP.Text,
                MaLoaiSanPham = Convert.ToInt32(cbxLoaiSP.SelectedValue),
                DonGiaBan = Convert.ToInt32(txtGiaBan.Text),
                DonGiaNhap = Convert.ToInt32(txtGiaNhap.Text),
                MoTa = txtMoTa.Text
            };

            try
            {
                SanPhamBLL.Instance.CapNhatSanPham(sp, 0);
                MessageBox.Show("Thêm mới thành công sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                HienThiMacDinh(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void HienThiMacDinh(bool tt)
        {
            if (tt)
            {
                SanPhamBLL.Instance.HienThiDanhSach(dgvSanPham, 0, null);
            }

            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtGiaBan.Text = "";
            txtGiaNhap.Text = "";
            txtMoTa.Text = "";

            SanPhamBLL.Instance.HienThiChiTietSP(dgvChiTietSP, -1);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            HienThiMacDinh(false);
        }
    }
}
