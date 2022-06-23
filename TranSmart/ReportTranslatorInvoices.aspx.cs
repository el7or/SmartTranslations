using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TranSmart.DAL;

namespace TranSmart
{
    public partial class ReportTranslatorInvoices : System.Web.UI.Page
    {
        EmployeeDAL empActions = EmployeeDAL.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            grdTransList.DataSource = empActions.GetTranslatorsInvoices();
            grdTransList.DataBind();
            if (!IsPostBack)
            {
                Static.Grd2Pdf.GrdPrepare(grdTransList, lblHeader.Text);
            }
        }
        protected void DownloadPDF_Click(object sender, EventArgs e)
        {
            grdTransList.MasterTableView.ExportToPdf();
        }

        protected void RadDatePicker2_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            grdTransList.DataSource = empActions.GetTranslatorsInvoices(new DateTime(e.NewDate.Value.Year, e.NewDate.Value.Month, 1), new DateTime(e.NewDate.Value.Year, e.NewDate.Value.Month, DateTime.DaysInMonth(e.NewDate.Value.Year, e.NewDate.Value.Month), 23, 59, 59));
            grdTransList.DataBind();
        }

        protected void grdTransList_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (grdTransList.IsExporting)
                Static.Grd2Pdf.FormatGridItem(e.Item);
        }
    }
}