using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using TranSmart.cSession;
using TranSmart.DAL;
using TranSmart.DTO;
using TranSmart.Static;

namespace TranSmart
{
    public partial class ProjectDetails : System.Web.UI.Page
    {
        ProjectDAL projectActions = ProjectDAL.GetInstance();
        EmployeeDAL staffActions = EmployeeDAL.GetInstance();
        CustomerDAL clientActions = CustomerDAL.GetInstance();
        private ProjectDetailsDTO projectDetails;
        CustomerDetailsDTO CustDetails;
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!cSession.LoggedUser.isLogged || cSession.LoggedUser.User == null)
            { 
                cSession.cValues.TargetURL = Request.Url.OriginalString;
                Response.Redirect("Login.aspx", true); 
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Load_Combos();
                if (Request["projid"] != null && Request["projid"] != "")
                    projectDetails = projectActions.GetProjectDetailsByID(Guid.Parse(Request["projid"]));
                else if (hfProjID.Value != "")
                    projectDetails = projectActions.GetProjectDetailsByID(Guid.Parse(hfProjID.Value));

                if (projectDetails == null)
                {
                    dtRequestCustomer.SelectedDate = DateTime.Now;
                    lblProjectManager.Text = LoggedUser.User.Employee.FullName;
                    lblProjSerial.Text = projectActions.GetNewSerial().ToString();
                    btnShowTasks.Enabled = false;
                    btnCancelProject.Enabled = false;
                    dtNextPayment.MinDate = DateTime.Now;
                    dtPromiseCustomer.MinDate = (DateTime)dtRequestCustomer.SelectedDate;
                    lblTranslatorsHead.Text = "";
                    lblReviewersHead.Text = "";

                    //string strBody = MailBody.Template1_Short;
                    //strBody = strBody.Replace("[TITLE]", "Translation Offer");
                    ////strBody = strBody.Replace("[RECEPIENT.NAME]", CustDetails.CustomerName);
                    ////strBody = strBody.Replace("[MESSAGE]", "test test test test test test test test ");
                    //lblMsgBody.Text = strBody;

                }
                else
                {
                    stepFiles.Visible = true;
                    stepFinance.Visible = true;
                    stepTeam.Visible = true;
                    btnShowTasks.Enabled = true;
                    btnCancelProject.Enabled = true;
                    FillStatus();
                    FillData();
                    CustDetails = new CustomerDAL().GetCustomerDetailsByID(projectDetails.CustomerID);
                    //FillOffer();
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }

        #region LoadProjectDetails
        private void FillStatus()
        {
            try
            {
                //if (projectDetails == null)
                //    projectDetails = projectActions.GetProjectDetailsByID(Guid.Parse(Request["projid"]));
                if (projectDetails != null)
                {
                    if (projectDetails.CustomerRequestDate != null)
                        hfIsCustomerRequest.Value = lblIsCustomerRequest.Text = projectDetails.CustomerRequestDate.ToString("yyyy/MM/dd hh:mm:ss");
                    if (projectDetails.isOfferSentToCustomer != null)
                        hfIsOfferSent.Value = lblIsOfferSent.Text = projectDetails.isOfferSentToCustomer.Value.ToString("yyyy/MM/dd hh:mm:ss");
                    if (projectDetails.isCustomerApproved != null)
                        hfIsCustomerApproved.Value = lblIsCustomerApproved.Text = projectDetails.isCustomerApproved.Value.ToString("yyyy/MM/dd hh:mm:ss");
                    if (projectDetails.isTasksSent != null)
                        hfIsTasksSent.Value = lblIsTasksSent.Text = DateTime.Parse(projectDetails.isTasksSent).ToString("yyyy/MM/dd hh:mm:ss");
                    if (projectDetails.isTasksInProgress != null)
                        hfIsTasksInProgress.Value = lblIsTasksInProgress.Text = DateTime.Parse(projectDetails.isTasksInProgress).ToString("yyyy/MM/dd hh:mm:ss");
                    if (projectDetails.isTasksFinished != null)
                        hfIsTasksDone.Value = lblIsTasksDone.Text = DateTime.Parse(projectDetails.isTasksFinished).ToString("yyyy/MM/dd hh:mm:ss");
                    if (projectDetails.isProjectDelivered != null)
                        hfIsProjectDelivered.Value = lblIsProjectDelivered.Text = projectDetails.isProjectDelivered.Value.ToString("yyyy/MM/dd hh:mm:ss");
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
        private void FillData()
        {            
            try
            {
                if (IsPostBack) return;
                if (projectDetails == null)projectDetails = projectActions.GetProjectDetailsByID(Guid.Parse(Request["projid"]));
                lblProjSerial.Text = projectDetails.ProjectSerial;
                txtTitleProject.Text = projectDetails.ProjectTitle;
                ddlFromLangg.SelectedValue = projectDetails.SourceLanggID.ToString();
                ddlToLangg.SelectedValue = projectDetails.TargetLanggID.ToString();
                ddlCustomerProject.SelectedValue = projectDetails.CustomerID.ToString();
                dtRequestCustomer.SelectedDate = projectDetails.CustomerRequestDate;
                txtOfferSent.Text = (projectDetails.isOfferSentToCustomer == null ? "" : projectDetails.isOfferSentToCustomer.Value.ToString("yyyy/MM/dd"));
                txtCustomerApproved.Text = (projectDetails.isCustomerApproved == null ? "" : projectDetails.isCustomerApproved.Value.ToString("yyyy/MM/dd"));
                dtPromiseCustomer.SelectedDate = projectDetails.PromiseDeliveryDate;
                txtDeliveredDate.Text = (projectDetails.ActualDeliveryDate == null ? "" : projectDetails.ActualDeliveryDate.Value.ToString("yyyy/MM/dd"));
                dtPromiseCustomer.MinDate = projectDetails.CustomerRequestDate;
                txtNoteProject.Text = projectDetails.Notes;
                txtWordCount.Text = projectDetails.WordCount.ToString();
                txtWordPrice.Text = projectDetails.WordPrice.ToString();
                txtDiscount.Text = projectDetails.DiscountValue.ToString();
                txtVatValue.Text = projectDetails.VatValue.ToString();
                txtPrevPay.Text = projectDetails.PrevPayments.ToString();
                dtNextPayment.SelectedDate = projectDetails.NextPaymentDate;
                if (projectDetails.CustomerFile != null && projectDetails.CustomerFile.Length > 0)
                {
                    btnOfferDownload.NavigateUrl = projectDetails.CustomerFile;
                    btnOfferDownload.Text = new System.IO.FileInfo(Server.MapPath(projectDetails.CustomerFile)).Name;
                    btnOfferDownload.Enabled = true;
                }
                else
                    btnOfferDownload.Enabled = false;

                if (projectDetails.FinalFile != null && projectDetails.FinalFile.Length > 0)
                {
                    btnDownloadFinalFile.NavigateUrl = projectDetails.FinalFile;
                    btnDownloadFinalFile.Text = new System.IO.FileInfo(Server.MapPath(projectDetails.FinalFile)).Name;
                    btnDownloadFinalFile.Enabled = btnSendFinalFile.Enabled = true;
                }
                else
                    btnDownloadFinalFile.Enabled = btnSendFinalFile.Enabled= false;
                lblProjectManager.Text = projectDetails.ProjectManager;
                if (projectDetails.Translators.Count() > 0)
                {
                    lblTranslatorsHead.Text = "Translators";
                    ulTranslators.DataSource = projectDetails.Translators;
                    ulTranslators.DataBind();
                }
                else { lblTranslatorsHead.Text = ""; }
                if (projectDetails.Reviewers.Count() > 0)
                {
                    lblReviewersHead.Text = "Reviewers";
                    ulRevewers.DataSource = projectDetails.Reviewers;
                    ulRevewers.DataBind();
                }
                else { lblReviewersHead.Text = ""; }
                hfStatusHeader.Value = projectDetails.ProjectStatus;
                if (projectDetails.ProjectStatus == ProjectStatus.ProjectCanceled.ToString())
                {
                    btnActiveProject.Visible = true;
                    btnCancelProject.Visible = false;
                }
                else
                {
                    btnActiveProject.Visible = false;
                    btnCancelProject.Visible = true;
                }
                
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
        //void FillOffer()
        //{
        //    CustDetails = new CustomerDAL().GetCustomerDetailsByID(projectDetails.CustomerID);
        //    DateTime t = DateTime.Now;
        //    string strBody = MailBody.Template1_Short;
        //    strBody = strBody.Replace("[TITLE]", "Translation Offer");
        //    strBody = strBody.Replace("[RECEPIENT.NAME]", CustDetails.CustomerName);
        //    strBody = strBody.Replace("[MESSAGE]", "test test test test test test test test ");
        //    lblMsgBody.Text = strBody;
        //}
        #endregion

        #region Add & Update Project
        protected void RadWizard1_FinishButtonClick(object sender, WizardEventArgs e)
        {
            SaveProject(true);
        }
        Guid? SaveProject(bool bFinish = true)
        {
            try
            {
                // Add new Project
                if (projectDetails == null)//Request["projid"] == null || Request["projid"] == "")
                {
                  return AddProject(bFinish);
                }
                // Update existing project
                else
                {
                  return UpdateProject(bFinish);
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
            return null;
        }
        Guid? AddProject(bool bFinish = true)
        {
            try
            {
                Guid projID = Guid.NewGuid();
                ProjectDTO projDTO = new ProjectDTO
                {
                    ProjectID = projID,
                    CustomerID = Guid.Parse(ddlCustomerProject.SelectedValue),
                    ManagerID = LoggedUser.User.Employee.EmployeeID,
                    ProjectTitle = txtTitleProject.Text,
                    SourceLangg = ddlFromLangg.SelectedItem.Text,
                    TargetLangg = ddlToLangg.SelectedItem.Text,
                    CustomerRequestDate = (DateTime)dtRequestCustomer.SelectedDate,
                    PromiseDeliveryDate = dtPromiseCustomer.SelectedDate,
                    Note = txtNoteProject.Text,
                    WordCount = long.Parse(txtWordCount.Text),
                    WordPrice = decimal.Parse(txtWordPrice.Text),
                    DiscountValue = decimal.Parse(txtDiscount.Text),
                    VatValue = decimal.Parse(txtVatValue.Text),
                    Paid = decimal.Parse(txtCurrentPay.Text),
                    NextPaymentDate = dtNextPayment.SelectedDate,
                    EditedBy = LoggedUser.User_PK,
                    // FinalFile = 
                    // ActualDeliveryDate =                 
                }; 
                if (uploadCustomerFile.UploadedFiles.Count > 0)
                {
                    projDTO.isOfferSentToCustomer = DateTime.Now;
                    projDTO.isCustomerApproved = DateTime.Now;
                    projDTO.CustomerFile = "~/ProjectsFiles/" + projID.ToString() + "/CustomerFile." +
                        uploadCustomerFile.UploadedFiles[0].GetName();
                }
                Guid resultID = projectActions.CreateProject(projDTO);
                if (resultID == projID)
                {
                    foreach (UploadedFile f in uploadCustomerFile.UploadedFiles)
                    {
                        SaveFile(f, Server.MapPath("~/ProjectsFiles/" + projID.ToString() + "/CustomerFile." + f.GetName()));
                        //try
                        //{
                        //    if (!System.IO.Directory.Exists(Server.MapPath("~/ProjectsFiles/" + projID.ToString() + "/")))
                        //        System.IO.Directory.CreateDirectory(Server.MapPath("~/ProjectsFiles/" + projID.ToString() + "/"));
                        //    f.SaveAs(Server.MapPath("~/ProjectsFiles/" + projID.ToString() + "/CustomerFile." + f.GetName()), true);
                        //}
                        //catch (Exception ex) { Global.Log.Error(ex); }
                    }

                    if (bFinish)
                        Response.Redirect("~/ProjectDetails.aspx?projid=" + projID, false);
                        //Response.Redirect("~/Projects.aspx", false);

                    hfProjID.Value = projID.ToString();
                    hfIsCustomerRequest.Value = lblIsCustomerRequest.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    return projID;
                }
                else
                {
                    RadWindowManager1.RadAlert("Project didn't saved for some reasons./nPlease contact system administrator.", null, null, "", "");
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
            return null;
        }
        void SaveFile(UploadedFile f, string path)
        {
            try
            {
                if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(path)))
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));
                f.SaveAs(path, true);
            }
            catch (Exception ex) { Global.Log.Error(ex); }
        }
        Guid?  UpdateProject(bool bFinish = true)
        {
            try
            {
                projectDetails.CustomerID = Guid.Parse(ddlCustomerProject.SelectedValue);
                //projectDetails.ManagerID = LoggedUser.User_PK;
                projectDetails.ProjectTitle = txtTitleProject.Text;
                projectDetails.SourceLangg = ddlFromLangg.SelectedItem.Text;
                projectDetails.TargetLangg = ddlToLangg.SelectedItem.Text;
                projectDetails.CustomerRequestDate = (DateTime)dtRequestCustomer.SelectedDate;
                projectDetails.PromiseDeliveryDate = dtPromiseCustomer.SelectedDate;
                projectDetails.Note = txtNoteProject.Text;
                projectDetails.WordCount = long.Parse(txtWordCount.Text);
                projectDetails.WordPrice = decimal.Parse(txtWordPrice.Text);
                projectDetails.DiscountValue = decimal.Parse(txtDiscount.Text);
                projectDetails.VatValue = decimal.Parse(txtVatValue.Text);
                projectDetails.Paid = decimal.Parse(txtCurrentPay.Text);
                projectDetails.NextPaymentDate = dtNextPayment.SelectedDate;
                projectDetails.EditedBy = LoggedUser.User_PK;

                if (uploadCustomerFile.UploadedFiles.Count > 0)
                {
                    if (projectDetails.isOfferSentToCustomer == null) projectDetails.isOfferSentToCustomer = DateTime.Now;
                    if (projectDetails.isCustomerApproved == null) projectDetails.isCustomerApproved = DateTime.Now;
                    projectDetails.CustomerFile = "~/ProjectsFiles/" + Request["projid"] + "/CustomerFile." + uploadCustomerFile.UploadedFiles[0].GetName();
                }
                if (uploadFinalFile.UploadedFiles.Count > 0)
                {
                    if (projectDetails.isOfferSentToCustomer == null) projectDetails.isOfferSentToCustomer = DateTime.Now;
                    if (projectDetails.isCustomerApproved == null) projectDetails.isCustomerApproved = DateTime.Now;
                    projectDetails.FinalFile = "~/ProjectsFiles/" + Request["projid"] + "/FinalFile." + uploadFinalFile.UploadedFiles[0].GetName();
                }
                bool isSuccessUpdate = projectActions.UpdateProject(projectDetails);
                if (isSuccessUpdate)
                {
                    foreach (UploadedFile f in uploadCustomerFile.UploadedFiles)
                    {
                        f.SaveAs(Server.MapPath("~/ProjectsFiles/" + projectDetails.ProjectID.ToString() + "/CustomerFile." + f.GetName()), true);
                    }
                    foreach (UploadedFile f in uploadFinalFile.UploadedFiles)
                    {
                        f.SaveAs(Server.MapPath("~/ProjectsFiles/" + projectDetails.ProjectID.ToString() + "/FinalFile." + f.GetName()), true);
                    }
                }
               if(bFinish) Response.Redirect("~/Projects.aspx", false);
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
           return projectDetails.ProjectID;
        }
        #endregion

        #region Cancel Project
        protected void btnCancelProject_Click(object sender, EventArgs e)
        {
            bool isSuccsessCancel = projectActions.CancelProject(Guid.Parse(Request["projid"]));
            Response.Redirect("~/Projects.aspx", false);
        }
        #endregion

        #region Re-Activate Project
        protected void btnActiveProject_Click(object sender, EventArgs e)
        {
            bool isSuccsessActivate = projectActions.ActivateProject(Guid.Parse(Request["projid"]));
            Response.Redirect("~/Projects.aspx", false);
        }
        #endregion

        protected void Load_Combos()
        {
            if (IsPostBack) return;
            try
            { 
                ddlCustomerProject.Items.Clear();
                ddlCustomerProject.DataSource = clientActions.GetAllCustomers();
                ddlCustomerProject.DataTextField = "CustomerName";
                ddlCustomerProject.DataValueField = "CustomerID";
                ddlCustomerProject.DataBind();

                ddlFromLangg.Items.Clear();
                ddlFromLangg.DataSource = staffActions.GetLanggList();
                ddlFromLangg.DataTextField = "LanguageText";
                ddlFromLangg.DataValueField = "LanguageID";
                ddlFromLangg.DataBind();

                ddlToLangg.Items.Clear();
                ddlToLangg.DataSource = staffActions.GetLanggList();
                ddlToLangg.DataTextField = "LanguageText";
                ddlToLangg.DataValueField = "LanguageID";
                ddlToLangg.DataBind();
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }

        protected void btnShowTasks_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ProjectTasks.aspx?projid=" + Request["projid"], false);
        }

        protected void dtRequestCustomer_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            dtPromiseCustomer.MinDate = (DateTime)dtRequestCustomer.SelectedDate;
        }

        protected void btnSendOffer_Click(object sender, EventArgs e)
        {
            Guid projID = Guid.Empty;
            try
            {
                object res = (Guid)SaveProject(false);
                if (res != null &&  res is Guid) projID = (Guid)res;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
            try
            {
                if (projectDetails == null && Request["projid"]!=null && Request["projid"]!="")
                    projectDetails = projectActions.GetProjectDetailsByID(Guid.Parse(Request["projid"]));
                if (projectDetails == null && projID != Guid.Empty)
                    projectDetails = projectActions.GetProjectDetailsByID(projID);

                //CustomerDetailsDTO CustDetails = new CustomerDAL().GetCustomerDetailsByID(projectDetails.CustomerID);
                CustomerDetailsDTO CustDetails = new CustomerDAL().GetCustomerDetailsByID(Guid.Parse(ddlCustomerProject.SelectedValue));
                DateTime t = DateTime.Now;
                //string strBody = MailBody.Template1_Short;
                //strBody = strBody.Replace("[TITLE]", "Translation Offer");
                //strBody = strBody.Replace("[RECEPIENT.NAME]", CustDetails.CustomerName);
                //strBody = strBody.Replace("[MESSAGE]", "test test test test test test test test ");
                //strBody = strBody.Replace("[BUTTON.TEXT]", "");
                //strBody = strBody.Replace("[BUTTON.HREF]", "");
                //strBody = strBody.Replace("[LINK.TEXT]", "");
                //strBody = strBody.Replace("[LINK.HREF]", "");
                //strBody = strBody.Replace("[BUTTON2.TEXT]", "");
                //strBody = strBody.Replace("[BUTTON2.URL]", "");

                Exception x = new MailSender().Send(CustDetails.CustomerEmail, "Transtec Offer ", lblMsgBody.Text);
                string msg = "Mail sent successfully!";
                if (x == null)
                {
                    RadAjaxManager1.ResponseScripts.Add(string.Format("AlertDone('{0}');", msg));
                    if (projectDetails.isOfferSentToCustomer == null)
                    {
                        projectDetails.isOfferSentToCustomer = DateTime.Now;
                        hfIsOfferSent.Value = lblIsOfferSent.Text = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");                        
                    } 
                    projectActions.UpdateProject(projectDetails);
                }
                else
                {
                    msg = x.Message;
                    Global.Log.Error(x);
                    RadAjaxManager1.ResponseScripts.Add(string.Format("AlertErr('{0}');", msg));
                }
                //RadWindowManager1.RadAlert(msg, null, null, "", "", "Content/Images/ok22.png");
                

                //ScriptManager.RegisterStartupScript(this.GetType(), "alert", "MyAlert('" + msg + "');", true);
                // + " \nTime:" + ((TimeSpan)(DateTime.Now - t)).Seconds.ToString() + " sec" 
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }


        protected void RadAjaxManager1_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
        {
            //RadAjaxManager1.Alert("AjaxRequest raised from the " + e.Argument);
            if (e.Argument == "2")
            {
                try
                {
                    if(CustDetails==null) CustDetails = new CustomerDAL().GetCustomerDetailsByID(Guid.Parse(ddlCustomerProject.SelectedValue));
                    string strBody = MailBody.Template_Quotation;
                    strBody = strBody.Replace("[TITLE]", "Translation Quotation");
                    strBody = strBody.Replace("[RECEPIENT.NAME]", CustDetails.CustomerName);
                    //strBody = strBody.Replace("[MESSAGE]", "test test test test test test test test ");
                    strBody = strBody.Replace("[QUOTATION.DATE]", DateTime.Now.ToString("dddd, dd MMM yyyy"));
                    strBody = strBody.Replace("[QUOTATION.NO]", lblProjSerial.Text);
                    strBody = strBody.Replace("[LANGUAGE]", ddlFromLangg.Text + " into " + ddlToLangg.Text);
                    strBody = strBody.Replace("[WORD.COUNT]", txtWordCount.Value + " word(s)");
                    strBody = strBody.Replace("[PAGE.RATE]", txtWordPrice.Value + " LE");
                    strBody = strBody.Replace("[DISCOUNT]", txtDiscount.Value + " %");
                    strBody = strBody.Replace("[VAT]", txtVatValue.Value + " %");
                    strBody = strBody.Replace("[TOTAL.PRICE]", txtWordCount.Value * txtWordPrice.Value * (1 + (txtVatValue.Value / 100) - (txtDiscount.Value / 100)) + " LE");
                    strBody = strBody.Replace("[DELIVERY]", txtDelivery.Text);
                    strBody = strBody.Replace("[PAYMENT.METHOD]", txtPaymentMethod.Text);

                    lblMsgBody.Text = strBody;
                }
                catch (Exception ex)
                {
                    Global.Log.Error(ex);
                }
            }
        }
    }
}