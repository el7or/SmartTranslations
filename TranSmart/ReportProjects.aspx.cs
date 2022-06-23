using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using TranSmart.DAL;

namespace TranSmart
{
    public partial class ReportProjects : System.Web.UI.Page
    {
        ProjectDAL projectActions = ProjectDAL.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request["type"] == "now")
                {
                    lblHeader.Text = Page.Title = "Current Projects";
                    grdProjList.DataSource = projectActions.GetProjectsInProgress();
                    grdProjList.DataBind();
                }
                if (Request["type"] == "done")
                {
                    lblHeader.Text = Page.Title = "Finished Projects";
                    grdProjList.DataSource = projectActions.GetProjectsDone();
                    grdProjList.DataBind();
                }
                if (!IsPostBack)
                {
                    Static.Grd2Pdf.GrdPrepare(grdProjList, lblHeader.Text);
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
        protected void DownloadPDF_Click(object sender, EventArgs e)
        {
            grdProjList.MasterTableView.ExportToPdf();
        } 
        protected void grdProjList_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (grdProjList.IsExporting)
                Static.Grd2Pdf.FormatGridItem(e.Item);
        }        
    }
}