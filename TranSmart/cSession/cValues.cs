using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace TranSmart.cSession
{
    public class cValues
    {
        public static HttpSessionState Session = HttpContext.Current.Session;
        public static string TargetURL
        {
            get
            {
                if (Session != null && Session["TargetURL"] != null) return Session["TargetURL"].ToString();
                else return "";
            }
            set { Session["TargetURL"] = value; }
        }
        public static string LastMsg
        {
            get
            {
                if (Session != null && Session["LastMsg"] != null) return Session["LastMsg"].ToString();
                else return "";
            }
            set { Session["LastMsg"] = value; }
        }
    }
}
