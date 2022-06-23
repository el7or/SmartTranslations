using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TranSmart.DAL;

namespace TranSmart
{
    public partial class ReportManagersProjects : System.Web.UI.Page
    {
        EmployeeDAL employeeActions = EmployeeDAL.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request["type"] == "pm")
                {
                    lblHeader.Text = "Projects number for Managers";
                    grdManagersList.DataSource = employeeActions.GetEmployeesProjectsCount(3);
                    grdManagersList.DataBind();
                    grdManagersList.MasterTableView.GetColumn("ProjectsCount").HeaderText = "Projects Count";
                    grdManagersList.Rebind();
                }
                if (Request["type"] == "tr")
                {
                    lblHeader.Text = "Tasks number for Translators";
                    grdManagersList.DataSource = employeeActions.GetEmployeesProjectsCount(5);
                    grdManagersList.DataBind();
                    grdManagersList.MasterTableView.GetColumn("ProjectsCount").HeaderText = "Tasks Count";
                    grdManagersList.Rebind();
                }
                if (Request["type"] == "rev")
                {
                    lblHeader.Text = "Tasks number for Revisors";
                    grdManagersList.DataSource = employeeActions.GetEmployeesProjectsCount(4);
                    grdManagersList.DataBind();
                    grdManagersList.MasterTableView.GetColumn("ProjectsCount").HeaderText = "Tasks Count";
                    grdManagersList.Rebind();
                }
                if (!IsPostBack)
                {
                    Static.Grd2Pdf.GrdPrepare(grdManagersList, lblHeader.Text);
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
        protected void DownloadPDF_Click(object sender, EventArgs e)
        {
            grdManagersList.MasterTableView.ExportToPdf();
        }

        protected void grdManagersList_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (grdManagersList.IsExporting)
                Static.Grd2Pdf.FormatGridItem(e.Item);
        }
    }
}