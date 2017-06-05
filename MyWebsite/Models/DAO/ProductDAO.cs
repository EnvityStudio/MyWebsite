using MyWebsite.Models.DTO;
using MyWebsite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.DAO
{
    public class ProductDAO
    {
        MyDbContext db;
        public ProductDAO()
        {
            db = new MyDbContext();
        }
        public int InsertProduct(string tenSP, int donGia, bool trangThai, bool noiBat, string hinhAnh, string moTa, string chiTiet, int maDM)
        {
            SAN_PHAM sp = new SAN_PHAM();
            sp.TenSP = tenSP;
            sp.DonGia = donGia;
            sp.TrangThai = trangThai;
            sp.NoiBat = noiBat;
            sp.HinhAnh = hinhAnh;
            sp.MoTa = moTa;
            sp.ChiTiet = chiTiet;
            sp.MaDM = maDM;

            db.SAN_PHAM.Add(sp);
            db.SaveChanges();
            return sp.MaSP;
        }

        public IQueryable<SAN_PHAM> Products
        {
            get { return db.SAN_PHAM; }
        }
        public IQueryable<SAN_PHAM> ListProduct()
        {
            var res = (from p in db.SAN_PHAM
                       where p.MaSP > 2 || p.TenSP.Length > 2
                       orderby p descending
                       select p);
            return res;
        }
        public int FindIdCategory(string name)
        {
            return db.SAN_PHAM.Single(m => m.TenSP == name).MaDM;
        }
        
        public List<SAN_PHAM> SearchListSP(int idCategory, string name,float priceFrom, float priceTo)
        {
            List<SAN_PHAM> list = db.SAN_PHAM.SqlQuery(@"search '" +idCategory+"','"+name+"','"+priceFrom+"','"+priceTo+"").ToList();
            return list;
        }
        public IQueryable<SAN_PHAM> ListProductFeatured()
        {
            var res = (from p in db.SAN_PHAM
                       where p.TrangThai == true
                       orderby p.MaSP ascending
                       select p);
            return res;
        }
        public IQueryable<ProductDTO> ListProductFields()
        {
            var rs = (from p in db.SAN_PHAM
                      join cat in db.DANH_MUC
                      on p.MaDM equals cat.MaDM
                      select new ProductDTO
                      {
                          MaSP = p.MaSP,
                          TenSP = p.TenSP,
                          DonGia = p.DonGia,
                          TrangThai = p.TrangThai,
                          NoiBat = p.NoiBat,
                          MoTa = p.MoTa,
                          TenDM = cat.TenDM
                      }
                      );
            return rs;
        }
        public IQueryable<SAN_PHAM> ListProductByCatID(int idCat)
        {
            var res = (from p in db.SAN_PHAM
                       where p.TrangThai == true & p.MaDM == idCat
                       orderby p.MaSP ascending
                       select p
                       );
            return res;
        }

        public void UpdateProduct(SAN_PHAM spTmp)
        {
            SAN_PHAM sp = db.SAN_PHAM.Find(spTmp.MaSP);
            if (sp != null)
            {
                sp.TenSP = spTmp.TenSP;
                sp.DonGia = spTmp.DonGia;
                sp.TrangThai = spTmp.TrangThai;
                sp.NoiBat = spTmp.NoiBat;
                sp.HinhAnh = spTmp.HinhAnh;
                sp.MoTa = spTmp.MoTa;
                sp.ChiTiet = spTmp.ChiTiet;
                sp.MaDM = spTmp.MaDM;

                db.SaveChanges();
            }
        }

        public void DeleteProduct(SAN_PHAM spTmp)
        {
            SAN_PHAM sp = db.SAN_PHAM.Find(spTmp.MaDM);
            if (sp != null)
            {
                db.SAN_PHAM.Remove(spTmp);
                db.SaveChanges();
            }
        }
        public SAN_PHAM FindProductByID(int MaSP)
        {
            return db.SAN_PHAM.Find(MaSP);
        }

        public IQueryable<SAN_PHAM> ListNewArrivals()
        {
            var res = (from p in db.SAN_PHAM
                       where p.TrangThai == true
                       orderby p.MaSP descending
                       select p
                ).Take(10);
            return res;
        }
        public IQueryable<SAN_PHAM> ListRandom()
        {
            var res = (from p in db.SAN_PHAM
                       where p.TrangThai == true
                       orderby Guid.NewGuid()// Random 
                       select p
                       ).Take(3);// lay 3 ban ghi

            return res;
        }
        public IQueryable<SAN_PHAM> ListCheapest()
        {
            var res = (from p in db.SAN_PHAM
                       where p.TrangThai == true
                       orderby p.DonGia ascending
                       select p

                ).Take(3);
            return res;
        }
        // lấy danh sách bánh liên quan 
        public IQueryable<SAN_PHAM> ListRelated(int id)
        {
            var res = (from p in db.SAN_PHAM
                       where p.TrangThai == true
                       orderby p.DonGia ascending
                       select p).Take(3);
            return res;
        }
        public IQueryable<SAN_PHAM> ListUpsellProduct()
        {
            var res = (from p in db.SAN_PHAM
                       where p.TrangThai == true
                       orderby p.DonGia ascending
                       select p

                ).Take(3);
            return res;
        }
        public IQueryable<SAN_PHAM> ListProductOrderByName(int id)
        {
            var res = (from p in db.SAN_PHAM
                       where p.TrangThai == true & p.MaDM == id
                       orderby p.TenSP descending
                       select p
                       );
            return res;
        }
        public IQueryable<SAN_PHAM> ListProductOrderByPrice(int id)
        {
            var res = (from p in db.SAN_PHAM
                       where p.TrangThai == true & p.MaDM == id
                       orderby p.DonGia descending
                       select p
                         );
            return res;
        }
    }
}