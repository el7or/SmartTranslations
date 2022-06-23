using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.Device.Detection;
using Telerik.Web.UI;
using TranSmart.cSession;

namespace TranSmart
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                //Global.Log.Info("MasterPage_Load 0");
                if (!cSession.LoggedUser.isLogged || cSession.LoggedUser.User == null)
                {
                    //Global.Log.Info("MasterPage_Load 1");
                    cSession.cValues.TargetURL = Request.Url.OriginalString;
                    Response.Redirect("Login.aspx", true);
                    //Global.Log.Info("MasterPage_Load 2");
                }
            }
            catch (Exception ex)
            { Global.Log.Error(ex); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Global.Log.Info("MasterPage_Load 0");
                if (!cSession.LoggedUser.isLogged || cSession.LoggedUser.User == null)
                {
                    //Global.Log.Info("MasterPage_Load 1");
                    cSession.cValues.TargetURL = Request.Url.OriginalString;
                    Response.Redirect("Login.aspx", true);
                    //Global.Log.Info("MasterPage_Load 2");
                }
                {
                    //Global.Log.Info("MasterPage_Load 3");
                    nodeUser.Text = cSession.LoggedUser.User.UserName;
                    if (cSession.LoggedUser.User.Employee != null)
                    {
                        nodeUser.Text = cSession.LoggedUser.User.Employee.FullName;
                        lblMail.Text = cSession.LoggedUser.User.Employee.Email;
                        lblRole.Text = cSession.LoggedUser.User.Employee.ValEmployeeRole.RoleText;
                        //Global.Log.Info("MasterPage_Load 4");
                    }
                    //Global.Log.Info("MasterPage_Load 5");
                }
                string title = this.Page.Title;
                //Global.Log.Info("MasterPage_Load 6");
                RadMenuItem item = verticalMenu.FindItemByText(title);
                if (item != null)
                {
                    //Global.Log.Info("MasterPage_Load 7");
                    item.Selected = true;
                }
                //Global.Log.Info("MasterPage_Load 8");

                // show hide menu based on role
                RadMenuItem itemHome = verticalMenu.FindItemByValue("Home");
                RadMenuItem itemHomeTR = verticalMenu.FindItemByValue("HomeTR");
                RadMenuItem itemStaff = verticalMenu.FindItemByValue("Staff");
                RadMenuItem itemClients = verticalMenu.FindItemByValue("Clients");
                RadMenuItem itemProjects = verticalMenu.FindItemByValue("Projects");
                RadMenuItem itemTasks = verticalMenu.FindItemByValue("Tasks");
                RadMenuItem itemFinance = verticalMenu.FindItemByValue("Finance");
                RadMenuItem itemReports = verticalMenu.FindItemByValue("Reports");
                int roleID = LoggedUser.User.Employee.RoleID;
                switch (roleID)
                {
                    case 3:  // project manager
                        itemFinance.Visible = false;
                        itemReports.Visible = false;
                        break;
                    case 4: // reviewer
                    case 5: // translator
                        //verticalMenu.Visible = false; 
                        itemHome.Visible = false;
                        itemHomeTR.Visible = true;
                        itemStaff.Visible = false;
                        itemClients.Visible = false;
                        itemProjects.Visible = false;
                        itemTasks.Visible = false;
                        itemFinance.Visible = false;
                        itemReports.Visible = false; 
                        break;
                    case 6: // Accountant
                        itemHome.Visible = false;
                        itemStaff.Visible = false;
                        itemClients.Visible = false;
                        itemProjects.Visible = false;
                        itemTasks.Visible = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }

        protected override void OnInit(EventArgs e)
        {
            DeviceScreenDimensions screenDimensions = Detector.GetScreenDimensions(Request.UserAgent);
            LoadMobile(screenDimensions);
        }

        private void LoadMobile(DeviceScreenDimensions screenDimensions)
        {
            // Desktop Browser Detected
            if (screenDimensions.Height == 0 && screenDimensions.Width == 0)
            {
                var mobileNavigation = FolderContent.FindControl("MobileNavigation");
                if (mobileNavigation != null)
                {
                    mobileNavigation.Visible = false;
                    nav.Value = "desktop";
                }
            }
            // Mobile Browser Detected
            else
            {
                this.form1.Attributes.Add("class", "mobile clear");
                var desktopNavigation = FolderContent.FindControl("FolderNavigationControl");
                if (desktopNavigation != null)
                {
                    desktopNavigation.Visible = false;
                    nav.Value = "mobile";
                }
            }
        }

        protected void BtnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
            Session.Abandon();
        }
    }
}