﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Areas.Admin.Session
{
    [Serializable]
    public class UserSession
    {
        public int userID { get; set; }
        public string userName { get; set; }
    }
}