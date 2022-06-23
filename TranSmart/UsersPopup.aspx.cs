using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TranSmart.DAL;
using TranSmart.DTO;
using TranSmart.cSession;

namespace TranSmart
{
    public partial class UsersPopup : System.Web.UI.Page
    {
        UserDetailsDTO usrDTO;
        Guid id = Guid.Empty;
        UserDAL uDal = UserDAL.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (Request["id"] != null && Request["id"] != "" && Guid.TryParse(Request["id"], out id))
                {
                    if (Request["type"] != null && Request["type"] == "emp" && id != Guid.Empty)
                    {
                        
                        usrDTO = uDal.GetUserDetailsByEmployeeID(id);
                        if (usrDTO != null)
                            Load_User(usrDTO);
                            
                        //else
                        //    create_user();
                    }
                }
                
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
        protected void Load_User(UserDetailsDTO emp)
        {
            if (IsPostBack) return;
            txtUserName.Text = usrDTO.UserName;
            chkActivated.Checked = usrDTO.IsActivated;
            txtPassword.Text = txtConfirm.Text = usrDTO.Password;
        }
        //Tuple<UserUpdateStatus, Guid> create_user()
        //{
        //    UserDTO userDTO = new DTO.UserDTO();

        //    userDTO.EmployeeID = id;
        //    userDTO.UserName = txtUserName.Text;
        //    userDTO.Password = txtPassword.Text;
        //    userDTO.EditedBy = LoggedUser.User.UserID; 
            
        //   return  uDal.CreateUser(userDTO);

        //}
    }
}