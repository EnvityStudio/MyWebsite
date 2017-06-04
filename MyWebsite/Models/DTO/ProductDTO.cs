using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Models.DTO
{
    public class ProductDTO
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }

        public int DonGia { get; set; }

        public bool? TrangThai { get; set; }

        public bool? NoiBat { get; set; }

        public string MoTa { get; set; }

        public string TenDM { get; set; }
    }
}