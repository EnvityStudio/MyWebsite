using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Models
{
    public class Category
    {
        public Category()
        {

        }
        public int CatID { get; set; }
        public string CatName { get; set; }
        public static IEnumerable<Category> getAll()
        {
            var st = new List<Category>();
            for (int i = 0; i < 7; i++)
            {
                Category a = new Category();
                a.CatID = i;
                a.CatName = "Category thứ " + i;
                st.Add(a);
            }
            st[0].CatName = "Bánh Mặn";
            st[1].CatName = "Bánh Ngọt";
            st[2].CatName = "Bánh Cưới";
            st[3].CatName = "Bánh Hội Nghị";
            st[4].CatName = "Bánh Sinh Nhật";
            st[5].CatName = "Sản phẩm kèm theo bánh";
            st[6].CatName = "Đồ ăn nhanh";
            return st;
        }

        public static IEnumerable<Category> getAll2()
        {
            var st = new List<Category>();
            for (int i = 0; i < 4; i++)
            {
                Category a = new Category();
                a.CatID = i;
                a.CatName = "Category thứ " + i;
                st.Add(a);
            }
            st[0].CatName = "Giới thiệu";
            st[1].CatName = "Tin tức";
            st[2].CatName = "Blog";
            st[3].CatName = "Liên hệ";
            return st;
        }

    }
}