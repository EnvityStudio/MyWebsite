using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Models
{
    public class Product
    {
        public Product()
        {

        }
        public int ProID { get; set; }
        public string ProName { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public int CatID { get; set; }


        public static IEnumerable<Product> getList()
        {
            var list = new List<Product>();
            Product a = new Product();
            a.ProID = 1;
            a.ProName = "Bánh sinh nhật mứt xoài";
            a.Price = 180000;
            a.Image = "banh-sinh-nha-mut-xoai.jpg";
            a.Description = "Bánh gato mứt xoài";
            a.Details = "Bánh gato nhân kem phủ mứt xoài vị thanh nhẹ, thơm mát.";
            a.CatID = 4;
            list.Add(a);

            Product b = new Product();
            b.ProID = 2;
            b.ProName = "Bánh Nhân Xúc Xích";
            b.Price = 18000;
            b.Image = "banh-nhan-xuc-xich.jpg";
            b.Description = "Bánh xúc xích";
            b.Details = "Bánh mặn nhân xúc xích, thơm ngon bổ dưỡng.";
            b.CatID = 0;
            list.Add(b);

            Product c = new Product();
            c.ProID = 3;
            c.ProName = "Bánh Ngọt";
            c.Price = 30000;
            c.Image = "1.jpg";
            c.Description = "Bánh kem ngọt";
            c.Details = "Bánh kem ngọt, thơm mát";
            c.CatID = 1;
            list.Add(c);


            Product d = new Product();
            d.ProID = 4;
            d.ProName = "Bánh 1";
            d.Price = 40000;
            d.Image = "1.jpg";
            d.Description = "Bánh kem ngọt";
            d.Details = "Bánh kem ngọt, thơm mát";
            d.CatID = 1;
            list.Add(d);

            Product e = new Product();
            e.ProID = 5;
            e.ProName = "Bánh 2";
            e.Price = 50000;
            e.Image = "1.jpg";
            e.Description = "Bánh kem ngọt";
            e.Details = "Bánh kem ngọt, thơm mát";
            e.CatID = 2;
            list.Add(e);

            Product f = new Product();
            f.ProID = 6;
            f.ProName = "Bánh 3";
            f.Price = 60000;
            f.Image = "1.jpg";
            f.Description = "Bánh kem ngọt";
            f.Details = "Bánh kem ngọt, thơm mát";
            f.CatID = 3;
            list.Add(f);

            return list;
        }

        public static List<Product> getList(int CatID)
        {
            var list = Product.getList();
            var list2 = new List<Product>();
            foreach (var item in list)
            {
                if (item.CatID.Equals(CatID))
                {
                    list2.Add(item);
                }
            }
            return list2;
        }

        public static Product getProduct(int ProID)
        {
            var list = Product.getList();
            foreach (var item in list)
            {
                if (item.CatID.Equals(ProID))
                {
                    return item;
                }
            }
            return null;
        }
    }
}