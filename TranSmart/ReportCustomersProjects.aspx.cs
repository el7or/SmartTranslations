using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TranSmart.DAL;

namespace TranSmart
{
    public partial class ReportCustomersProjects : System.Web.UI.Page
    {
        CustomerDAL clintActions = CustomerDAL.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            grdClientList.DataSource = clintActions.GetCustomersProjectsCount();
            grdClientList.DataBind();
            if (!IsPostBack)
            {
                Static.Grd2Pdf.GrdPrepare(grdClientList, lblHeader.Text);
            }
        }
        protected void DownloadPDF_Click(object sender, EventArgs e)
        {
            grdClientList.MasterTableView.ExportToPdf();
        }

        protected void grdClientList_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (grdClientList.IsExporting)
                Static.Grd2Pdf.FormatGridItem(e.Item);
        }
    }
}