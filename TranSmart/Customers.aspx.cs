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
    public partial class Customers : System.Web.UI.Page
    {
        DTO.CustomerDetailsDTO clintDetails = null;
        CustomerDAL clintActions = CustomerDAL.GetInstance();

        public object RadWindowManager1 { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Load_Combos(clintActions);
                if (Request["id"] != null && Request["id"] != "")
                {
                    clintDetails = clintActions.GetCustomerDetailsByID(Guid.Parse(Request["id"]));
                    RadTab tab = RadTabStrip1.FindTabByText("Add new");
                    tab.Text = "Edit";
                    RadTabStrip1.Tabs[1].Selected = true;
                    RadTabStrip1.Tabs[1].PageView.Selected = true;
                    Load_Customers(clintDetails);
                }
                else
                {
                    clintDetails = null;
                    RadTabStrip1.Tabs[0].Selected = true;
                    RadTabStrip1.Tabs[0].PageView.Selected = true;
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex.Message);
            }
        }

        private void Page_LoadComplete(object sender, EventArgs e)
        {
            try
            {
                grdClientList.DataSource = clintActions.GetAllCustomers();
                grdClientList.DataBind();
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }

        protected void Load_Combos(CustomerDAL clintActions)
        {
            if (IsPostBack) return;
            cmbTypeID.Items.Clear();
            cmbTypeID.DataSource = clintActions.GetCustomerTypesList();
            cmbTypeID.DataTextField = "CustomerTypeText";
            cmbTypeID.DataValueField = "CustomerTypeID";
            cmbTypeID.DataBind();

            cmbCountryID.Items.Clear();
            cmbCountryID.DataSource = clintActions.GetCountriesList();
            cmbCountryID.DataTextField = "CountryText";
            cmbCountryID.DataValueField = "CountryID";
            cmbCountryID.DataBind();
        }
        protected void Load_Customers(DTO.CustomerDetailsDTO clint)
        {
            if (IsPostBack) return;
            txtCustomerID.Text = clint.CustomerID.ToString();
            txtCustomerName.Text = clint.CustomerName;
            cmbTypeID.FindItemByText(clint.CustomerType.ToString()).Selected = true;
            txtEmail.Text = clint.CustomerEmail;
            txtPhone.Text = clint.CustomerPhone;
            cmbCountryID.FindItemByText(clint.CustomerCountry).Selected = true;
            txtAddress.Text = clint.CustomerAddress;
            txtNote.Text = clint.Note;
            txtCreatedBy.Text = clint.CreatedBy;
            txtCreatedDate.Text = clint.CreatedDate;
            txtEditedBy.Text = clint.LastEditedBy;
            txtEditedDate.Text = clint.LastEditedDate;
        }

        protected void Add_Customer()//DTO.EmployeeDetailsDTO empData)
        {
            try
            {
                if (!LoggedUser.isLogged) return;
                DTO.CustomerDTO clint = new DTO.CustomerDTO();
                clint.CustomerName = txtCustomerName.Text;
                int comboID = 0;
                if (int.TryParse(cmbTypeID.SelectedValue, out comboID)) clint.CustomerTypeID = comboID;
                if (int.TryParse(cmbCountryID.SelectedValue, out comboID)) clint.CustomerCountryID = comboID;
                clint.CustomerAddress = txtAddress.Text;
                clint.CustomerEmail = txtEmail.Text;
                clint.CustomerPhone = txtPhone.Text;
                clint.Note = txtNote.Text;
                clint.EditedBy = LoggedUser.User_PK;

                clintActions.CreateCustomer(clint);
                RadWindowManager2.RadAlert("Done successfully!", null, null, "", "");
                Response.Redirect("Customers.aspx", false);
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
        protected void Update_Customer()//DTO.EmployeeDetailsDTO empData)
        {
            try
            {
                if (!LoggedUser.isLogged || clintDetails == null) return;
                DTO.CustomerDTO clint = new DTO.CustomerDTO();
                clint.CustomerID = clintDetails.CustomerID;
                clint.CustomerName = txtCustomerName.Text;
                int comboID = 0;
                if (int.TryParse(cmbTypeID.SelectedValue, out comboID)) clint.CustomerTypeID = comboID;
                if (int.TryParse(cmbCountryID.SelectedValue, out comboID)) clint.CustomerCountryID = comboID;
                clint.CustomerAddress = txtAddress.Text;
                clint.CustomerEmail = txtEmail.Text;
                clint.CustomerPhone = txtPhone.Text;
                clint.Note = txtNote.Text;
                clint.EditedBy = LoggedUser.User_PK;

                CustomerUpdateStatus result = clintActions.UpdateCustomer(clint);
                switch (result)
                {
                    case CustomerUpdateStatus.CustomerNameExists:
                        RadWindowManager2.RadAlert("This name already exists! Please choose another!", null, null, "", "");
                        txtCustomerName.SelectionOnFocus = SelectionOnFocus.SelectAll;
                        txtCustomerName.Focus();
                        break;
                    case CustomerUpdateStatus.Success:
                        RadWindowManager2.RadAlert("Done successfully!", null, null, "", "");
                        Response.Redirect("Customers.aspx", false);
                        break;
                    case CustomerUpdateStatus.Error:
                        RadWindowManager2.RadAlert("Error!", null, null, "", "");
                        break;
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
        
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            if (Request["id"] != null && Request["id"] != "")
            { Update_Customer(); }
            else Add_Customer();
        }
        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            clintDetails = null;
            Response.Redirect("Customers.aspx", false);
        }

        protected void grdClientList_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                Guid CustomerID = (Guid)((GridDataItem)e.Item).GetDataKeyValue("CustomerID");
                clintActions.DeleteCustomer(CustomerID, LoggedUser.User_PK);
                //RadWindowManager2.RadAlert("Delete completed!", null, null, "", "");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "MyAlert();", true);
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }

    }
}