using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TranSmart.DAL;

namespace TranSmart
{
    public partial class ReportManagersDelays : System.Web.UI.Page
    {
        EmployeeDAL employeeActions = EmployeeDAL.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            grdManagersList.DataSource = employeeActions.GetProjectsDealys(3);
            grdManagersList.DataBind();
            try
            {
                if (Request["type"] == "pm")
                {
                    lblHeader.Text = "Delayed Days in Projects";
                    grdManagersList.DataSource = employeeActions.GetProjectsDealys(3);
                    grdManagersList.DataBind();
                    grdManagersList.MasterTableView.GetColumn("ProjectSerial").HeaderText = "Project Nr.";
                    grdManagersList.MasterTableView.GetColumn("FullName").HeaderText = "PM";
                    grdManagersList.Rebind();
                }
                if (Request["type"] == "tr")
                {
                    lblHeader.Text = "Delayed Days in Translators Tasks";
                    grdManagersList.DataSource = employeeActions.GetProjectsDealys(5);
                    grdManagersList.DataBind();
                    grdManagersList.MasterTableView.GetColumn("ProjectSerial").HeaderText = "Tasks Nr.";
                    grdManagersList.MasterTableView.GetColumn("FullName").HeaderText = "Translator";
                    grdManagersList.Rebind();
                }
                if (Request["type"] == "rev")
                {
                    lblHeader.Text = "Delayed Days in Revisors Tasks";
                    grdManagersList.DataSource = employeeActions.GetProjectsDealys(4);
                    grdManagersList.DataBind();
                    grdManagersList.MasterTableView.GetColumn("ProjectSerial").HeaderText = "Tasks Nr.";
                    grdManagersList.MasterTableView.GetColumn("FullName").HeaderText = "Revisor";
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