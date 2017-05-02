using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Areas.Admin.Models
{
    public class LoginDTO
    {
        public string userName { get; set; }
        public string passWord { get; set; }
        public bool rememberMe { get; set; }


    }
}