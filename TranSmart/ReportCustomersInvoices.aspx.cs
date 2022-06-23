using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TranSmart.DAL;

namespace TranSmart
{
    public partial class ReportCustomersInvoices : System.Web.UI.Page
    {
        CustomerDAL clientActions = CustomerDAL.GetInstance();
        ProjectDAL projectsActions = ProjectDAL.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCustomerProject.Items.Clear();
                ddlCustomerProject.DataSource = clientActions.GetAllCustomers();
                ddlCustomerProject.DataTextField = "CustomerName";
                ddlCustomerProject.DataValueField = "CustomerID";
                ddlCustomerProject.DataBind();
                Static.Grd2Pdf.GrdPrepare(grdProjList, lblHeader.Text);
            }
            grdProjList.DataSource = projectsActions.GetAllProjects();
            grdProjList.DataBind();
        }

        protected void ddlCustomerProject_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            grdProjList.DataSource = projectsActions.GetAllProjects(Guid.Parse(e.Value), ProjectBy.Customer);
            grdProjList.DataBind();
        }
        protected void DownloadPDF_Click(object sender, EventArgs e)
        {
            grdProjList.MasterTableView.ExportToPdf();
        }

        protected void grdProjList_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (grdProjList.IsExporting)
                Static.Grd2Pdf.FormatGridItem(e.Item);
        }
    }
}