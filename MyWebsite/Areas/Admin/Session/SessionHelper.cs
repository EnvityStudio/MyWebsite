using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Areas.Admin.Session
{
    public class SessionHelper
    {
        public static void setSessionUser(UserSession ss)
        {
            HttpContext.Current.Session["login_UserName"] = ss;
        }
        public static UserSession getUserSession()
        {
            var session = HttpContext.Current.Session["login_UserName"];
            if (session == null)
                return null;
            else
                return session as UserSession;
        }
    }
}