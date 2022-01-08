﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmDangNhap());

            //Application.Run(new frmQuanLyLoaiSanPham());

            //Application.Run(new QuanTri.frmQuanLyNhanVien());
            Application.Run(new QuanTri.frmXemThongTinHoaDonBan());
            //Application.Run(new NhanVien.frmTaoHoaDonBan());
            //Application.Run(new NhanVien.frmInHoaDonBan("HDB-070122-006", 50000, false));
        }
    }
}
