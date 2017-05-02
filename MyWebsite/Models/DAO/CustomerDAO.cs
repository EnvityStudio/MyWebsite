using MyWebsite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.DAO
{
    public class CustomerDAO
    {
        MyDbContext db;
        public CustomerDAO()
        {
            db = new MyDbContext();
        }

        public IQueryable<KHACH_HANG> ListCust()
        {
            var rs = (from item in db.KHACH_HANG select item);
            return rs;
        }
    }
}