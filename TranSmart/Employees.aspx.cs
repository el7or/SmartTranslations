using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using TranSmart.DAL;
using TranSmart.cSession;

namespace TranSmart
{
    public partial class Employees : System.Web.UI.Page
    {
        DTO.EmployeeDetailsDTO empDetails = null;
        EmployeeDAL empActions = EmployeeDAL.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Page.LoadComplete += Page_LoadComplete;
                //grdEmpList.DataSource = empActions.GetAllEmployees();
                //grdEmpList.DataBind();
                if (!Page.IsPostBack)
                {
                    grdEmpList.ItemCommand += new GridCommandEventHandler(grdEmpList_ItemCommand);
                }
                Load_Combos(empActions);
                if (Request["id"] != null && Request["id"] != "")
                {
                    empDetails = empActions.GetEmployeeDetailsByID(Guid.Parse(Request["id"]));
                    Load_Employee(empDetails);
                    Btn_Update.Visible = true;
                    Btn_Save.Visible = false;
                    Btn_Add.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
        private void Page_LoadComplete(object sender, EventArgs e)
        {
            try
            {
                //Page.LoadComplete += Page_LoadComplete;

                grdEmpList.DataSource = empActions.GetAllEmployees();
                grdEmpList.DataBind();
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
            // throw new NotImplementedException();
        }
        protected void Load_Combos(EmployeeDAL empActions)
        {
            if (IsPostBack) return;
            cmbRoleID.Items.Clear();
            cmbRoleID.DataSource = empActions.GetRolesList();
            cmbRoleID.DataTextField = "RoleText";
            cmbRoleID.DataValueField = "RoleID";
            cmbRoleID.DataBind();

            cmbWorkMethodID.Items.Clear();
            cmbWorkMethodID.DataSource = empActions.GetWorkMethodsList();
            cmbWorkMethodID.DataTextField = "WorkMethodText";
            cmbWorkMethodID.DataValueField = "WorkMethodID";
            cmbWorkMethodID.DataBind();

            chkLanguages.Items.Clear();
            chkLanguages.DataSource = empActions.GetLanggList();
            chkLanguages.DataBindings.DataTextField = "LanguageText";
            chkLanguages.DataBindings.DataValueField = "LanguageID";
            chkLanguages.DataBind();
        }
        protected void Load_Employee(DTO.EmployeeDetailsDTO emp)
        {
            if (IsPostBack) return;
            txtEmployeeID.Text = emp.EmployeeID.ToString();
            txtFullName.Text = emp.FullName;
            //cmbRoleID.FindItemByText(emp.Role).Selected = true;
            cmbRoleID.FindItemByValue(emp.Role.ToString()).Selected = true;
            //dtJobStartDate.SelectedDate =DateTime.ParseExact( emp.JobStartDate,"yyyy-M-d",null);
            dtJobStartDate.SelectedDate = emp.JobStartDate;
            cmbWorkMethodID.FindItemByText(emp.WorkMethod).Selected = true;
            string[] languages = emp.Languages.Split(',');
            for (int i = 0; i < chkLanguages.Items.Count; i++)
            {
                if (languages.Contains(chkLanguages.Items[i].Text))
                {
                    chkLanguages.Items[i].Selected = true;
                }
            }
            txtWordPrice.Value = (double?)emp.WordPrice;
            txtBasicSalary.Value = (double?)emp.BasicSalary;
            txtCommission.Value = (double?)emp.Commission;
            txtEmail.Text = emp.Email;
            txtPhone.Text = emp.Phone;
            txtAddress.Text = emp.Address;

            txtNote.Text = emp.Note;
            chkActivated.Checked = emp.IsActivated;
            txtCreatedBy.Text = emp.CreatedBy;
            txtCreatedDate.Text = emp.CreatedDate;
            txtEditedBy.Text = emp.LastEditedBy;
            txtEditedDate.Text = emp.LastEditedDate;
        }
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            Add_Employee();
        }
        protected void Add_Employee()//DTO.EmployeeDetailsDTO empData)
        {
            try
            {

                if (!LoggedUser.isLogged) return;
                DTO.EmployeeDTO emp = new DTO.EmployeeDTO();
                //emp.EmployeeID = new Guid();
                emp.FullName = txtFullName.Text;
                int role = 0;
                if (int.TryParse(cmbRoleID.SelectedValue, out role)) emp.RoleID = role;
                if (int.TryParse(cmbWorkMethodID.SelectedValue, out role)) emp.WorkMethodID = role;
                emp.Address = txtAddress.Text;
                emp.BasicSalary = (decimal?)txtBasicSalary.Value;
                emp.WordPrice = (decimal?)txtWordPrice.Value;

                emp.Commission = (decimal?)txtCommission.Value;
                emp.Email = txtEmail.Text;
                emp.JobStartDate = (DateTime)dtJobStartDate.SelectedDate;
                emp.Phone = txtPhone.Text;
                //emp.Languages = txtLanguages.Text;
                string languages = "";
                for (int i = 0; i < chkLanguages.Items.Count; i++)
                {
                    if (chkLanguages.Items[i].Selected)
                    {
                        languages += chkLanguages.Items[i].Text + ",";
                    }
                }
                emp.Languages = languages.TrimEnd(',');
                emp.Note = txtNote.Text;
                emp.EditedBy = LoggedUser.User_PK;

                empActions.CreateEmployee(emp);
                RadWindowManager1.RadAlert("Insert completed", null, null, "", "");
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            Update_Employee();
        }
        protected void Update_Employee()//DTO.EmployeeDetailsDTO empData)
        {
            try
            {
                if (!LoggedUser.isLogged || empDetails == null) return;
                DTO.EmployeeDTO emp = new DTO.EmployeeDTO();
                emp.EmployeeID = empDetails.EmployeeID;
                emp.FullName = txtFullName.Text;
                int role = 0;
                if (int.TryParse(cmbRoleID.SelectedValue, out role)) emp.RoleID = role;
                if (int.TryParse(cmbWorkMethodID.SelectedValue, out role)) emp.WorkMethodID = role;
                emp.Address = txtAddress.Text;
                emp.BasicSalary = (decimal?)txtBasicSalary.Value;
                emp.WordPrice = (decimal?)txtWordPrice.Value;

                emp.Commission = (decimal?)txtCommission.Value;
                emp.Email = txtEmail.Text;
                emp.JobStartDate = (DateTime)dtJobStartDate.SelectedDate;
                emp.Phone = txtPhone.Text;
                //emp.Languages = txtLanguages.Text;
                string languages = "";
                for (int i = 0; i < chkLanguages.Items.Count; i++)
                {
                    if (chkLanguages.Items[i].Selected)
                    {
                        languages += chkLanguages.Items[i].Text + ",";
                    }
                }
                emp.Languages = languages.TrimEnd(',');
                emp.Note = txtNote.Text;
                emp.EditedBy = LoggedUser.User_PK;

                EmployeeUpdateStatus result = empActions.UpdateEmployee(emp);
                switch (result)
                {
                    case EmployeeUpdateStatus.EmployeeNameExists:
                        RadWindowManager1.RadAlert("This name already exists! Please choose another!", null, null, "", "");
                        txtFullName.SelectionOnFocus = SelectionOnFocus.SelectAll;
                        txtFullName.Focus();
                        break;
                    case EmployeeUpdateStatus.Success:
                        RadWindowManager1.RadAlert("Update completed", null, null, "", "");
                        break;
                    case EmployeeUpdateStatus.Error:
                        RadWindowManager1.RadAlert("Error!", null, null, "", "");
                        break;
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
        protected void grdEmpList_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                //object o = e.Item;
                Guid EmployeeID = (Guid)((GridDataItem)e.Item).GetDataKeyValue("EmployeeID");
                empActions.DeleteEmployee(EmployeeID, LoggedUser.User_PK);
                RadWindowManager1.RadAlert("Delete completed", null, null, "", "");
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
        protected void grdEmpList_ItemDeleted(object sender, Telerik.Web.UI.GridDeletedEventArgs e)
        {
            // object o = e.Item;
        }
        protected void Btn_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employees.aspx", false);
        }
        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            string[] arg = e.Argument.Split(',');
            switch (arg[0])
            {
                case "popup_emp_login":
                    popup_emp_login(arg[4], arg[1], arg[2], arg[3]);
                    break;
                default:
                    break;
            }
        }
        void popup_emp_login(string EmpID, string userName, string pass, string chkActivated)
        {
            try
            {
                Guid empGUID = Guid.Parse(EmpID);
                UserDAL usrDAL = UserDAL.GetInstance();
                DTO.UserDetailsDTO usrDetails = usrDAL.GetUserDetailsByEmployeeID(empGUID);
                DTO.UserDTO userDTO = new DTO.UserDTO();
                 
                
                userDTO.EmployeeID = empGUID;
                userDTO.UserName = userName;
                userDTO.Password = pass;
                userDTO.IsActivated = (chkActivated == "1");
                userDTO.EditedBy = LoggedUser.User_PK;
                string msg = "User Added";
                if (usrDetails == null)
                {
                    usrDAL.CreateUser(userDTO);
                }
                else
                {userDTO.UserID = usrDetails.UserID;
                    usrDAL.UpdateUser(userDTO);
                    msg = "User Updated";
                }
                grdEmpList.DataBind();

                RadWindowManager1.RadAlert(msg, null, null, "", "");
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }

        protected void grdEmpList_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                //object o = e.Item;
                Guid EmployeeID = (Guid)((GridDataItem)e.Item).GetDataKeyValue("EmployeeID");
                empActions.DeleteEmployee(EmployeeID, LoggedUser.User_PK);
                RadWindowManager1.RadAlert("Delete completed", null, null, "", "");
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }

        }
    }
}