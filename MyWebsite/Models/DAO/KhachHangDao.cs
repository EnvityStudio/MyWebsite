using MyWebsite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.DAO
{
    public class KhachHangDao
    {
        MyDbContext db;
        public KhachHangDao()
        {
            db = new MyDbContext();
        }
        public int AddKH(string tenKH, string DiaChi, string SDT)
        {
            KHACH_HANG kh = new KHACH_HANG();
            kh.TenKH = tenKH;
            kh.DiaChi = DiaChi;
            kh.SDT = SDT;
            db.KHACH_HANG.Add(kh);
            db.SaveChanges();
            return kh.MaKH;
        }

    }
}