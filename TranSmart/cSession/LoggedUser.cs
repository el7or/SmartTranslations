using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace TranSmart.cSession
{
    public class LoggedUser
    {
        //public static HttpSessionState Session = HttpContext.Current.Session;

        public static HttpSessionState Session
        {
            get
            {
               return  HttpContext.Current.Session;
            }
        }
        public static Guid User_PK
        {
            get {if (Session["user_pk"] == null) return Guid.Empty;
               else return (Guid)Session["user_pk"]; }
            set { Session["user_pk"] = value; }
        }
        public static Models.User User
        {
            get {if (Session["User"] == null) return null;
               else return (Models.User)Session["User"]; }
            set { Session["User"] = value; }
        }
        public static bool isLogged
        {
            get { if (Session["user_pk"] == null) return false; else return true; }
        }
        public static string User_Name
        {
            get
            {
                if (Session["user_name"] == null) return "";
                else return Session["user_name"].ToString();
            }
            set { Session["user_name"] = value; }
        }
        public static bool Enabled
        {
            get { return (bool)Session["Enabled"]; }
            set { Session["Enabled"] = value; }
        }
    }
}