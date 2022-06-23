using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TranSmart.DAL;

namespace TranSmart
{
    public partial class ReportPaymentsPeriod : System.Web.UI.Page
    {
        PaymentDAL paymentActions = PaymentDAL.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request["type"] == "d")
                    {
                        lblHeader.Text = "Financial Daily Report";
                        lblPickDay.Visible = true; RadDatePicker1.Visible = true;
                        grdPayList.DataSource = paymentActions.GetAllPayments(DateTime.Today, DateTime.Today.AddDays(1));
                        grdPayList.DataBind();
                    }
                    else if (Request["type"] == "m")
                    {
                        lblHeader.Text = "Financial Monthly Report";
                        lblPickMonth.Visible = true; RadDatePicker2.Visible = true;
                        grdPayList.DataSource = paymentActions.GetAllPayments(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month),23,59,59));
                        grdPayList.DataBind();
                    }
                    if (!IsPostBack)
                    {
                        Static.Grd2Pdf.GrdPrepare(grdPayList, lblHeader.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
        protected void DownloadPDF_Click(object sender, EventArgs e)
        {
            grdPayList.MasterTableView.ExportToPdf();
        }

        protected void RadDatePicker1_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            grdPayList.DataSource = paymentActions.GetAllPayments(e.NewDate, e.NewDate.Value.AddDays(1));
            grdPayList.DataBind();
        }

        protected void RadDatePicker2_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            grdPayList.DataSource = paymentActions.GetAllPayments(new DateTime(e.NewDate.Value.Year, e.NewDate.Value.Month, 1), new DateTime(e.NewDate.Value.Year, e.NewDate.Value.Month, DateTime.DaysInMonth(e.NewDate.Value.Year, e.NewDate.Value.Month), 23, 59, 59));
            grdPayList.DataBind();
        }

        protected void grdPayList_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (grdPayList.IsExporting)
                Static.Grd2Pdf.FormatGridItem(e.Item);
        }
    }
}