using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HoaDonDAL
    {
        private QLBanQuanAoContext db = new QLBanQuanAoContext();
        private static HoaDonDAL instance;

        public static HoaDonDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HoaDonDAL();
                }
                return instance;
            }
        }

        public int LaySoHoaDon(String maHD)
        {
            return db.HoaDons.Count(hd => hd.MaHoaDon.Contains(maHD)) + 1;

        }

        public void LuuHoaDon(HoaDon hoaDon, List<DongHoaDon> dongHoaDons)
        {
            db.HoaDons.Add(hoaDon);
            db.SaveChanges();

            db.DongHoaDons.AddRange(dongHoaDons);
            db.SaveChanges();
        }

        public List<HoaDon> LayTheoLoaiHD(bool loaiHD)
        {
            return db.HoaDons.Where(hd => hd.LoaiHoaDon == loaiHD).ToList();
        }

        public List<HoaDon> LayTheoDieuKien(List<object> tuKhoa,int status, bool loaiHD)
        {
            switch (status)
            {
                case 1:
                    //Mã hóa đơn
                    string maHD = Convert.ToString(tuKhoa[0]);
                    return db.HoaDons.Where(hd => hd.MaHoaDon.ToLower().Contains(maHD.ToLower().Trim()) && hd.LoaiHoaDon == loaiHD).ToList();
                case 2:
                    //Mã nhân viên
                    int idTK = Convert.ToInt32(tuKhoa[0]);
                    return db.HoaDons.Where(hd => hd.ID == idTK && hd.LoaiHoaDon == loaiHD).ToList();
                case 3:
                    //Ngày xuất
                    DateTime bd = Convert.ToDateTime(tuKhoa[0]);
                    DateTime kt = Convert.ToDateTime(tuKhoa[1]);
                    return db.HoaDons.Where(hd => hd.ThoiGian >= bd && hd.ThoiGian <= kt && hd.LoaiHoaDon == loaiHD).ToList();
                case 4:
                    //Tổng số tiền
                    int tienBd = Convert.ToInt32(tuKhoa[0]);
                    int tienKt = Convert.ToInt32(tuKhoa[1]);
                    return db.HoaDons.Where(hd => hd.TongTien >= tienBd && hd.TongTien <= tienKt && hd.LoaiHoaDon == loaiHD).ToList();
                    break;
            }
            return null;
        }

        public HoaDon LayTheoMa(string maHoaDon)
        {
            return db.HoaDons.FirstOrDefault(nv => nv.MaHoaDon == maHoaDon);
        }
    }
}
