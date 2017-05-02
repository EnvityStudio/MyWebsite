using MyWebsite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.DAO
{
    public class CategoryDAO
    {
        MyDbContext db;
        public CategoryDAO()
        {
            db = new MyDbContext();
        }
        public int InsertCategory(string tenDM, int? dmCha, int thuTu, bool trangThai)
        {
            DANH_MUC dm = new DANH_MUC();
            dm.TenDM = tenDM;
            dm.DmCha = dmCha;
            dm.ThuTu = thuTu;
            dm.TrangThai = trangThai;

            db.DANH_MUC.Add(dm);
            db.SaveChanges();
            return dm.MaDM;
        }

        public IQueryable<DANH_MUC> Categories
        {
            get { return db.DANH_MUC; }
        }
        public IQueryable<DANH_MUC> ListCategory()
        {
            var res = (from c in db.DANH_MUC
                       orderby c.TrangThai == true, c.ThuTu ascending, c.DmCha == 0
                       select c
                       );
            return res;
        }

        public void UpdateCategory(DANH_MUC dmTmp)
        {
            DANH_MUC dm = db.DANH_MUC.Find();
            if (dm != null)
            {
                dm.TenDM = dmTmp.TenDM;
                dm.DmCha = dmTmp.DmCha;
                dm.ThuTu = dmTmp.ThuTu;
                dm.TrangThai = dmTmp.TrangThai;

                db.SaveChanges();
            }
        }
        public void DeleteCategory(DANH_MUC dmTmp)
        {
            DANH_MUC dm = db.DANH_MUC.Find(dmTmp.MaDM);
            if (dm != null)
            {
                db.DANH_MUC.Remove(dmTmp);
                db.SaveChanges();
            }
        }
        public DANH_MUC FindCategoryByID(int MaDM)
        {
            return db.DANH_MUC.Find(MaDM);
        }
    }
}