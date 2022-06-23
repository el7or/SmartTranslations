using System;
using System.Collections.Generic;
using System.Linq;
using TranSmart.DAL;
using TranSmart.Models;

namespace TranSmart
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Static.Log.MyMethod1();
        }


        protected void btnContactSubmit_Click(object sender, EventArgs e)
        {
            UserDAL u = new UserDAL();
            Tuple<UserLoginStatus, User> t = u.CheckLogin2(txtUser.Text, txtPassword.Text);
            switch (t.Item1)
            {
                case UserLoginStatus.Success:
                    cSession.LoggedUser.User = t.Item2;
                    cSession.LoggedUser.User_PK = t.Item2.UserID;
                    if (cSession.cValues.TargetURL == "")
                    {
                        int roleID = cSession.LoggedUser.User.Employee.RoleID;
                        switch (roleID)
                        {
                            case 1:  // owner
                            case 2:  // admin                      
                            case 3:  // project manager
                                cSession.cValues.TargetURL = "Default.aspx";
                                break;
                            case 4: // reviewer
                            case 5: // translator
                                cSession.cValues.TargetURL = "DefaultTR.aspx";
                                break;
                            case 6: // Accountant
                                cSession.cValues.TargetURL = "Payments.aspx";
                                break;
                        }
                    }
                    Response.Redirect(cSession.cValues.TargetURL, false);
                    cSession.cValues.TargetURL = "";
                    break;
                case UserLoginStatus.WrongUserName:
                    lblError.Text = "Wrong UserName!"; break;
                case UserLoginStatus.WrongPassword:
                    lblError.Text = "Wrong Password!"; break;
                case UserLoginStatus.DeActivated:
                    lblError.Text = "DeActivated Account! Contact system admin, Please."; break;
                case UserLoginStatus.Error:
                    Exception ex = Server.GetLastError();
                    string msg = "Error : " + cSession.cValues.LastMsg;
                    if (ex != null) msg += "<br><label style='font-size:8px;'>" + ex.Message + "</label>";
                    lblError.Text = msg;

                    break;
                default:
                    break;
            }
        }
        //protected void login()
        //{
        //}

    }
}