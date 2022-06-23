//using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace TranSmart
{
    public class Global : System.Web.HttpApplication
    {
        public static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Global));
        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            Log.Info("Application_Start");
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //cSession.LoggedUser.Session = HttpContext.Current.Session;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex != null)// is ThreadAbortException)
                return;
            Log.Error("Application_Error", ex); 
            //Logger.Error(LoggerType.Global, ex, "Exception");
            //    Response.Redirect("unexpectederror.htm");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}