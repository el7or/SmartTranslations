using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TranSmart.DAL;

namespace TranSmart
{
    public partial class Payments : System.Web.UI.Page
    {
        PaymentDAL paymentActions = PaymentDAL.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                object o = paymentActions.GetBalance();
                 
                lblBalance.Text =(o==null?"0.0" : o.ToString() )+ " L.E";
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
                if (Request["clintid"] != null && Request["clintid"] != "")
                {
                    //grdPayList.DataSource = projectActions.GetAllPayments(Guid.Parse(Request["clintid"]), ProjectBy.Customer);
                    //grdPayList.DataBind();
                }
                else if(Request["projid"] != null && Request["projid"] != "")
                {
                    //grdPayList.DataSource = projectActions.GetAllPayments(Guid.Parse(Request["pmid"]), ProjectBy.ProjectManager);
                    //grdPayList.DataBind();
                }
                else
                {
                    grdPayList.DataSource = paymentActions.GetAllPayments();
                    grdPayList.DataBind();
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
    }
}