using MyWebsite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.DAO
{
    public class HoaDonDAO
    {
        MyDbContext db;
        public HoaDonDAO()
        {
            db = new MyDbContext();
        }
        public int AddHoaDon(int maKH , decimal tongTien)
        {
            DON_HANG donHang = new DON_HANG();
            donHang.MaKH = maKH;
            donHang.Ngay = DateTime.Now;
            donHang.TongTien = tongTien;
            db.DON_HANG.Add(donHang);
            db.SaveChanges();
            return donHang.MaDH;
        }
        public int AddChiTietHoaDon(int maSP,int maDH,int soLuong, int  donGia)

        {
            DON_HANG_CT donHangCT = new DON_HANG_CT();
            donHangCT.MaDH = maDH;
            donHangCT.MaSP = maSP;
            donHangCT.SoLuong = soLuong;
            donHangCT.DonGia = donGia;
            db.DON_HANG_CT.Add(donHangCT);
            db.SaveChanges();
            return 1;
        }

    }
}