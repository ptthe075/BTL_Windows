using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DTO;

namespace BLL
{
    public class SanPhamBLL
    {
        private static SanPhamBLL instance;

        public static SanPhamBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SanPhamBLL();
                }
                return instance;
            }
        }

        public SanPham LayTheoMa(int maSP)
        {
            return SanPhamDAL.Instance.LayTheoMa(maSP);
        }

        public void TaoDSLoaiSP(ComboBox cbx, bool tt)
        {
            List<LoaiSanPham> data = new List<LoaiSanPham>();
            if (tt)
            {
                data.Add(new LoaiSanPham() { MaLoaiSanPham = 0, TenLoaiSanPham = "Tất cả", SanPhams = null });
            }
            data.AddRange(LoaiSanPhamDAL.Instance.LayToanBo());

            cbx.DataSource = data;
            cbx.ValueMember = "MaLoaiSanPham";
            cbx.DisplayMember = "TenLoaiSanPham";
        }

        public void HienThiDanhSach(DataGridView dgv, int maLoaiSP, string tkTenSP)
        {
            List<SanPham> dsSanPham = new List<SanPham>();
            //maLoaiSP = 0, tkTenSP = null => Lấy toàn bộ
            if (isEmpty(tkTenSP) && maLoaiSP == 0)
            {
                dsSanPham = SanPhamDAL.Instance.LayToanBo();
            }
            else
            {
                if (isEmpty(tkTenSP)) tkTenSP = null;
                dsSanPham = SanPhamDAL.Instance.LayTheoTuKhoa(tkTenSP, maLoaiSP);
            }

            dgv.DataSource = dsSanPham.Select(sp => new { sp.MaSanPham, sp.TenSanPham, LoaiSP = sp.LoaiSanPham.TenLoaiSanPham, sp.DonGiaBan, sp.DonGiaNhap }).ToList();
            dgv.ClearSelection();
        }

        public void HienThiChiTietSP(DataGridView dgv, int maSP)
        {
            List<ChiTietSanPham> dsCTSP = new List<ChiTietSanPham>();
            if (maSP == -1)
            {
                var dsKT = KichThuocDAL.Instance.LayToanBo();
                foreach(var kt in dsKT)
                {
                    dsCTSP.Add(new ChiTietSanPham()
                    {
                        ID_KichThuoc = kt.ID_KichThuoc,
                        KichThuoc = kt,
                        SoLuongCon = 0
                    });
                }
            }
            else
            {
                dsCTSP = ChiTietSanPhamDAL.Instance.LayTheoMaSP(maSP);
            }

            dgv.DataSource = dsCTSP.Select(ctsp => new { Size = ctsp.KichThuoc.Ten, ctsp.SoLuongCon }).ToList();
            dgv.ClearSelection();
        }

        public void CapNhatSanPham(SanPham sp, int tt)
        {
            SanPhamDAL.Instance.CapNhatSanPham(sp, tt);
        }

        public bool isEmpty(string str)
        {
            if (str == null || str.Trim().Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
