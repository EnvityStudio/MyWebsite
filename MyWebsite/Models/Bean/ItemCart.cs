using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.Bean
{
    public class ItemCart
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public string Images { get; set; }

        public double getTotal()
        {
            return Amount * Price;
        }


    }
}