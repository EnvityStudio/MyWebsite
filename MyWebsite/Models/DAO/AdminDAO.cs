using MyWebsite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.DAO
{

    public class AdminDAO
    {
        MyDbContext db;
        public AdminDAO()
        {
            db = new MyDbContext();
        }
        public IQueryable<ADMIN> ListAdmin()
        {
            var rs = (from item in db.ADMINs select item);
            return rs;
        }
        public ADMIN getByName(string tenDN)
        {
            return db.ADMINs.SingleOrDefault(x => x.TenDN == tenDN);
        }
        public bool Login(string userName, string passWord)
        {
            Object[] sqlPara =
            {
                new SqlParameter("@userName", userName),
                new SqlParameter("@passWord", passWord)
            };
            var result = db.Database.SqlQuery<bool>("PROC_Admin_Login @userName, @passWord", sqlPara).SingleOrDefault();

            return result;
        }
        

    }
}