using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TranSmart.DAL;

namespace TranSmart
{
    public partial class ReportTasks : System.Web.UI.Page
    {
        TaskDAL tasksActions = TaskDAL.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request["type"] == "now")
                {
                    lblHeader.Text = "Current Tasks";
                    grdTaskList.DataSource = tasksActions.GetTasksInProgress();
                    grdTaskList.DataBind();
                }
                if (Request["type"] == "done")
                {
                    lblHeader.Text = "Finished Tasks";
                    grdTaskList.DataSource = tasksActions.GetTasksDone();
                    grdTaskList.DataBind();
                }
                if (!IsPostBack)
                {
                    Static.Grd2Pdf.GrdPrepare(grdTaskList, lblHeader.Text);
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
        protected void DownloadPDF_Click(object sender, EventArgs e)
        {
            grdTaskList.MasterTableView.ExportToPdf();
        }
        protected void grdTaskList_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (grdTaskList.IsExporting)
                Static.Grd2Pdf.FormatGridItem(e.Item);
        }
    }
}