using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.Bean
{
    public class BakeryCart
    {
        public List<ItemCart> list = new List<ItemCart>();
        public void AddItem(int ID, string Name, int Amount, double Price,string Images)
        {
            bool check = false;
            if (list != null)
            {
                foreach (var i in list)
                {
                    if (i.ID == ID)
                    {
                        check = true;
                        i.Amount += Amount;
                        break;
                    }
                }
            }
            if (!check)
            {
                ItemCart item = new ItemCart();
                item.ID = ID;
                item.Name = Name;
                item.Amount = Amount;
                item.Price = Price;
                item.Images = Images;
                this.list.Add(item);
            }
        }

        public void addAmount(int ID, int Amount)
        {
            foreach (var item in list)
            {
                item.Amount += Amount;
                break;
            }
        }
      

        public void Delete(int ID)
        {
            foreach (var item in list)
            {
                list.Remove(item);
                break;
            }
        }

        public double getTotalCart()
        {
            double Total = 0;
            foreach (var item in list)
            {
                Total += item.getTotal();
            }
            return Total;
        }
        public double getAmount()
        {
            double Amount = 0;
            foreach (var item in list)
            {
                Amount += item.Amount;
            }
            return Amount;
        }
    }
}