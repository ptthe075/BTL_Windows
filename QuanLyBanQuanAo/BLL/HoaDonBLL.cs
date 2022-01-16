﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace BLL
{
    public class HoaDonBLL
    {
        private static HoaDonBLL instance;
        private List<DongHoaDon> chiTietHoaDon;
        private decimal tienHang = 0;
        private decimal giamGia = 0;
        private decimal khachTra = 0;
        private bool loaiHDAdmin = false;

        public static HoaDonBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HoaDonBLL();
                }
                return instance;
            }
        }

        public void HienThiDanhSachHoaDonBan(DataGridView dgvHoaDon, Label lblTongHD, Label lblTongTien, List<object> tuKhoa, int status)
        {
            List<HoaDon> dsHD;

            if (tuKhoa == null)
            {
                //Hiện tất cả
                dsHD = HoaDonDAL.Instance.LayTheoLoaiHD(true);
            }
            else
            {
                if (status == 2 && Convert.ToInt32(tuKhoa[0]) == 0)
                {
                    dsHD = HoaDonDAL.Instance.LayTheoLoaiHD(true);
                }
                else
                {
                    dsHD = HoaDonDAL.Instance.LayTheoDieuKien(tuKhoa, status, true);
                }
            }


            dgvHoaDon.DataSource = dsHD.Select(hd => new
            {
                MaHD = hd.MaHoaDon,
                ThoiGian = hd.ThoiGian,
                MaNV = hd.TaiKhoan.NhanViens.FirstOrDefault().MaNhanVien,
                HoTenNV = hd.TaiKhoan.NhanViens.FirstOrDefault().HoTen,
                KhuyenMai = 10,
                TongTien = hd.TongTien
            }).ToList();
            lblTongHD.Text = dsHD.Count().ToString();
            lblTongTien.Text = string.Format("{0:#,### đ}", dsHD.Sum(hd => hd.TongTien));

        }

        public void HienThiNhanVien(Label lblNhanVien, string tenDN)
        {
            TaiKhoan tk = TaiKhoanDAL.Instance.LayTaiKhoan(tenDN);
            if (tk != null)
            {
                DTO.NhanVien nv = tk.NhanViens.FirstOrDefault();
                lblNhanVien.Text = nv.MaNhanVien + " - " + nv.HoTen;
            }
        }

        public void HienThiMaNV(ComboBox cbx)
        {
            List<NhanVien> data = new List<NhanVien>();
            data.Add(new NhanVien() { IdTK = 0, MaNhanVien = "Toàn bộ nhân viên" });
            data.AddRange(NhanVienDAL.Instance.LayToanBo());

            cbx.DataSource = data;
            cbx.ValueMember = "IdTK";
            cbx.DisplayMember = "MaNhanVien";
        }

        public HoaDon LayHoaDonTheoMa(string maHD)
        {
            return HoaDonDAL.Instance.LayTheoMa(maHD);
        }

        public List<ChiTietHoaDonDTO> LayChiTietHoaDon(string maHD, bool status)
        {
            var dongHoaDons = HoaDonDAL.Instance.LayTheoMa(maHD).DongHoaDons;
            List<ChiTietHoaDonDTO> dsCTHD = new List<ChiTietHoaDonDTO>();
            foreach (var dhd in dongHoaDons)
            {
                var cthd = new ChiTietHoaDonDTO()
                {
                    SoLuong = dhd.SoLuong,
                };

                if (status)
                {
                    var kt = KichThuocDAL.Instance.LayTheoMa(dhd.ID_KichThuoc);
                    var sp = SanPhamDAL.Instance.LayTheoMa(dhd.MaSanPham);
                    cthd.TenSP = sp.TenSanPham;
                    cthd.DonGiaBan = sp.DonGiaBan;
                    cthd.Size = kt.Ten;
                }
                else
                {
                    cthd.TenSP = dhd.SanPham.TenSanPham;
                    cthd.Size = dhd.KichThuoc.Ten;
                    cthd.DonGiaBan = dhd.SanPham.DonGiaBan;
                }
                dsCTHD.Add(cthd);
            }

            return dsCTHD;
        }

        public decimal TienHang { get { return tienHang; } }
        public decimal GiamGia { get { return giamGia; } }
        public decimal KhachTra { get { return khachTra; } set { this.khachTra = value; } }

        public String TaoMaHoaDon(bool kiemTra)
        {

            if(kiemTra)
            {
                loaiHDAdmin = false;
            }
            else
            {
                loaiHDAdmin = true;
            }
            String ma = (kiemTra) ? "HDB-" : "HDN-";
            DateTime date = DateTime.Now;
            ma += date.ToString("ddMMyy-");
            ma += HoaDonDAL.Instance.LaySoHoaDon(ma).ToString("000");
            return ma;
        }

        public void HienThiSanPham(DataGridView dgv, string tenSP, int maLoaiSP)
        {
            List<SanPham> dsNV = new List<SanPham>();
            if (isEmpty(tenSP) && maLoaiSP == 0)
            {
                dsNV = SanPhamDAL.Instance.LayToanBo();
            }
            else
            {
                if (isEmpty(tenSP)) tenSP = null;
                dsNV = SanPhamDAL.Instance.LayTheoTuKhoa(tenSP, maLoaiSP);
            }

            if (loaiHDAdmin)
            {
                dgv.DataSource = dsNV.Select(sp => new
                {
                    sp.MaSanPham,
                    sp.TenSanPham,
                    LoaiSanPham = sp.LoaiSanPham.TenLoaiSanPham,
                    sp.DonGiaNhap
                }).ToList();
            }
            else
            {
                dgv.DataSource = dsNV.Select(sp => new
                {
                    sp.MaSanPham,
                    sp.TenSanPham,
                    SoLuongCo = sp.ChiTietSanPhams.Sum(ctsp => ctsp.SoLuongCon),
                    LoaiSanPham = sp.LoaiSanPham.TenLoaiSanPham,
                    sp.DonGiaBan,
                }).ToList();
            }

            dgv.ClearSelection();
        }

        public void TaoDSLoaiSP(ComboBox cbxLocLoaiSP)
        {
            List<LoaiSanPham> data = new List<LoaiSanPham>();
            data.Add(new LoaiSanPham() { MaLoaiSanPham = 0, TenLoaiSanPham = "Tất cả", SanPhams = null });
            data.AddRange(LoaiSanPhamDAL.Instance.LayToanBo());

            cbxLocLoaiSP.DataSource = data;
            cbxLocLoaiSP.ValueMember = "MaLoaiSanPham";
            cbxLocLoaiSP.DisplayMember = "TenLoaiSanPham";
        }

        public void HienThiKichThuc(List<ChiTietSanPham> chiTietSanPhams, ComboBox cbxSize)
        {
            List<KichThuoc> data = new List<KichThuoc>();
            if (chiTietSanPhams != null)
            {
                foreach (var ctsp in chiTietSanPhams)
                {
                    if (ctsp.SoLuongCon > 0)
                    {
                        data.Add(ctsp.KichThuoc);
                    }
                }
            }
            else
            {
                data = KichThuocDAL.Instance.LayToanBo().ToList();
            }
            cbxSize.DataSource = data;
            cbxSize.ValueMember = "ID_KichThuoc";
            cbxSize.DisplayMember = "Ten";
        }

        public DongHoaDon LayChiTietHDTheoMaSPVaKichThuoc(int maSP, int idKichThuoc)
        {
            return chiTietHoaDon.FirstOrDefault(cthd => cthd.MaSanPham == maSP && cthd.ID_KichThuoc == idKichThuoc);
        }

        public void CapNhatChiTietHoaDon(DataGridView dgv, int maSP, int idKichThuoc, int soLuong, int status)
        {
            if (chiTietHoaDon == null)
            {
                chiTietHoaDon = new List<DongHoaDon>();
            }

            switch (status)
            {
                case 0:
                    bool kt = true;
                    foreach (var cthd in chiTietHoaDon)
                    {
                        if (cthd.MaSanPham == maSP && cthd.ID_KichThuoc == idKichThuoc)
                        {
                            kt = false;
                            cthd.SoLuong += soLuong;
                        }
                    }

                    if (kt)
                    {
                        chiTietHoaDon.Add(new DongHoaDon()
                        {
                            MaSanPham = maSP,
                            ID_KichThuoc = idKichThuoc,
                            SoLuong = soLuong,
                            KichThuoc = KichThuocDAL.Instance.LayTheoMa(idKichThuoc),
                            SanPham = SanPhamDAL.Instance.LayTheoMa(maSP),
                        });
                    }
                    break;
                case 1:
                    foreach (var cthd in chiTietHoaDon)
                    {
                        if (cthd.MaSanPham == maSP && cthd.ID_KichThuoc == idKichThuoc)
                        {
                            cthd.SoLuong = soLuong;
                        }
                    }
                    break;
                case 2:
                    DongHoaDon itemRemove = new DongHoaDon();
                    foreach (var cthd in chiTietHoaDon)
                    {
                        if (cthd.MaSanPham == maSP && cthd.ID_KichThuoc == idKichThuoc)
                        {
                            itemRemove = cthd;
                        }
                    }
                    chiTietHoaDon.Remove(itemRemove);
                    break;
                case 3:
                    chiTietHoaDon = new List<DongHoaDon>();
                    tienHang = 0;
                    giamGia = 0;
                    khachTra = 0;
                    break;
            }

            if (loaiHDAdmin)
            {
                dgv.DataSource = chiTietHoaDon.Select(cthd => new
                {
                    MaSP = cthd.MaSanPham,
                    MaKT = cthd.ID_KichThuoc,
                    TenSP = cthd.SanPham.TenSanPham,
                    Size = cthd.KichThuoc.Ten,
                    SoLuongNhap = cthd.SoLuong,
                    DonGiaNhap = cthd.SanPham.DonGiaNhap,
                    ThanhTien = cthd.SoLuong * cthd.SanPham.DonGiaBan
                }).ToList();
            }
            else
            {
                dgv.DataSource = chiTietHoaDon.Select(cthd => new
                {
                    MaSP = cthd.MaSanPham,
                    MaKichThuoc = cthd.ID_KichThuoc,
                    TenSP = cthd.SanPham.TenSanPham,
                    Size = cthd.KichThuoc.Ten,
                    SoLuongMua = cthd.SoLuong,
                    DonGia = cthd.SanPham.DonGiaBan,
                    ThanhTien = cthd.SoLuong * cthd.SanPham.DonGiaBan
                }).ToList();
            }
            dgv.ClearSelection();

            tienHang = Convert.ToDecimal(chiTietHoaDon.Sum(cthd => cthd.SoLuong * cthd.SanPham.DonGiaBan));
        }

        public bool ThanhToanHoaDonBan(string maHD, string tenDangNhap)
        {
            TaiKhoan tk = TaiKhoanDAL.Instance.LayTaiKhoan(tenDangNhap);
            HoaDon hoaDon = new HoaDon()
            {
                MaHoaDon = maHD,
                ThoiGian = DateTime.Now,
                GiamGia = Convert.ToInt32(giamGia),
                TongTien = Convert.ToInt32(tienHang - giamGia),
                ID = tk.ID
            };

            if (loaiHDAdmin)
            {
                hoaDon.LoaiHoaDon = false;
            }
            else
            {
                hoaDon.LoaiHoaDon = true;
            }

            foreach (var cthd in chiTietHoaDon)
            {
                cthd.MaHoaDon = maHD;
                cthd.KichThuoc = null;
                cthd.SanPham = null;
            }

            try
            {
                HoaDonDAL.Instance.LuuHoaDon(hoaDon, chiTietHoaDon);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
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

        public List<SanPham_SoLuong> SanPhamBanChayNhat(int thang, int nam)
        {
            return HoaDonDAL.Instance.SanPhamBanChayNhat(thang, nam);
        }

        public object LayDanhSachHoaDonBan(int thang, int nam)
        {
            return HoaDonDAL.Instance.LayDanhSachHoaDonBan(thang, nam);
        }

        public object LayDanhSachHoaDonNhap(int thang, int nam)
        {
            return HoaDonDAL.Instance.LayDanhSachHoaDonNhap(thang, nam);
        }

        public int LayTongTienBan(int thang, int nam)
        {
            return HoaDonDAL.Instance.LayTongTienBan(thang, nam);
        }

        public int LayTongTienNhap(int thang, int nam)
        {
            return HoaDonDAL.Instance.LayTongTienNhap(thang, nam);
        }
    }
}
