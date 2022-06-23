using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TranSmart.cSession;
using TranSmart.DAL;
using TranSmart.DTO;

namespace TranSmart
{
    public partial class PaymentDetails : Page
    {
        PaymentDAL paymentActions = PaymentDAL.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlDirection.SelectedIndex = 0;
                txtCashPaid.Value = 1.00;
                txtTitleItem.Text = "";
                txtNote.Text = "";
            }
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!LoggedUser.isLogged) return;
                if (Decimal.Parse(txtCashPaid.Text) > 0)
                {
                    PaymentDTO paymentData = new PaymentDTO();
                    paymentData.PaymentID = Guid.NewGuid();
                    paymentData.PaymentDirection = (ddlDirection.SelectedValue == "0" ? false : true);
                    paymentData.Paid = Decimal.Parse(txtCashPaid.Text);
                    paymentData.Item = txtTitleItem.Text;
                    paymentData.Note = txtNote.Text;
                    paymentActions.AddPayment(paymentData);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "MyAlert();", true);
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex); 
            }
        }
        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Payments.aspx");
        }

    }
}