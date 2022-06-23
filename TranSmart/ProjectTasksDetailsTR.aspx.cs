using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
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
    public partial class ProjectTasksDetailsTR : System.Web.UI.Page
    {
        TaskDAL taskActions = TaskDAL.GetInstance();
        private TaskDetailsDTO taskDetails;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request["taskid"] != null && Request["taskid"] != "")
                {
                    taskDetails = taskActions.GetTaskDetailsByID(Guid.Parse(Request["taskid"]));
                    FillData();
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }

        #region LoadTaskDetails
        private void FillData()
        {
            if (IsPostBack) return;
            lblTaskSerial.Text = taskDetails.TaskSerial;

            string taskStatus = "";
            if (LoggedUser.User.EmployeeID == taskDetails.ReviewerID)//LoggedUser.User.Employee.RoleID == 4) // reviewer case
            {
                taskStatus = FillReviewer();
            }
            else if (LoggedUser.User.EmployeeID == taskDetails.TranslatorID)//LoggedUser.User.Employee.RoleID == 5)  // translator case
            {
                taskStatus = FillTranslator();
            }
            hfStatusHeader.Value = taskStatus;
            txtFromLangg.Text = taskDetails.SourceLangg;
            txtToLangg.Text = taskDetails.TargetLangg;
            txtwordCount.Text = taskDetails.WordCount.ToString();
            txtProjectManager.Text = taskDetails.ProjectManager;
            txtTaskDesc.Text = taskDetails.TaskDescription;
            txtTranslatorQuality.Text = (taskDetails.TranslatorQuality == null ? "0" : taskDetails.TranslatorQuality.ToString());
        }
        #endregion
        string FillReviewer()
        {
            string taskStatus = "";
            txtJobType.Text = "Revision";
            txtTranslatorQuality.Enabled = true;
            txtStartDate.Text = (taskDetails.isReviewerProgress == null ? "Not yet" : taskDetails.isReviewerProgress.Value.ToString("yyyy/MM/dd"));
            txtFinishDate.Text = (taskDetails.isReviewerDone == null ? "Not yet" : taskDetails.isReviewerDone.Value.ToString("yyyy/MM/dd"));
            txtDeadline.Text = taskDetails.ReviewerDeadLine.ToString("yyyy/MM/dd");
            double? delay = 0;
            if (taskDetails.isReviewerDone != null && taskDetails.ReviewerDeadLine != null)
            {
                delay = (taskDetails.isReviewerDone - taskDetails.ReviewerDeadLine).Value.TotalDays;
            }
            if (delay >= 1)
            {
                int days = (int)delay;
                txtDelay.Text = days.ToString();
                txtDays.Text = "Days !";
            }
            else { txtDelay.Text = "None"; txtDays.Text = ""; }
            if (taskDetails.isReviewerProgress == null && taskDetails.isReviewerDone == null)
            {
                taskStatus = TaskStatus.New.ToString();
            }
            else if (taskDetails.isReviewerProgress != null && taskDetails.isReviewerDone == null)
            {
                taskStatus = TaskStatus.UnderProgress.ToString();
            }
            else if (taskDetails.isReviewerDone != null)
            {
                taskStatus = TaskStatus.Completed.ToString();
            }
            if (taskDetails.isReviewerReceived == null)
            { taskDetails.isReviewerReceived = DateTime.Now; taskActions.UpdateTask(taskDetails); }
            lblDownloadReceivedFile.Text = "Download Translator File:";
            if (taskDetails.TranslatorFile != null && taskDetails.TranslatorFile.Length > 0)
            {
                btnDownloadReceivedFile.Enabled = true;
                //btnDownloadReceivedFile.NavigateUrl = taskDetails.TaskFile;
                btnDownloadReceivedFile.Text = new System.IO.FileInfo(Server.MapPath(taskDetails.TranslatorFile)).Name;
            }
            else
                btnDownloadReceivedFile.Enabled = false;

            if (taskDetails.ReviewerFile != null && taskDetails.ReviewerFile.Length > 0)
            {
                btnSendTask.Enabled = btnDownloadFinishedFile.Enabled = true;
                //btnDownloadReceivedFile.NavigateUrl = taskDetails.TaskFile;
                btnDownloadFinishedFile.Text = new System.IO.FileInfo(Server.MapPath(taskDetails.ReviewerFile)).Name;

            }
            else
                btnSendTask.Enabled = btnDownloadFinishedFile.Enabled = false;
            return taskStatus;
        }
        string FillTranslator()
        {
            string taskStatus = "";
            txtJobType.Text = "Translation";
            txtTranslatorQuality.Enabled = false;
            txtStartDate.Text = (taskDetails.isTranslatorProgress == null ? "Not yet" : taskDetails.isTranslatorProgress.Value.ToString("yyyy/MM/dd"));
            txtFinishDate.Text = (taskDetails.isTranslatorDone == null ? "Not yet" : taskDetails.isTranslatorDone.Value.ToString("yyyy/MM/dd"));
            txtDeadline.Text = taskDetails.TranslatorDeadLine.Value.ToString("yyyy/MM/dd");
            double? delay = 0;
            if (taskDetails.isTranslatorDone != null && taskDetails.TranslatorDeadLine != null)
            {
                delay = (taskDetails.isTranslatorDone - taskDetails.TranslatorDeadLine).Value.TotalDays;
            }
            if (delay >= 1)
            {
                int days = (int)delay;
                txtDelay.Text = days.ToString();
                txtDays.Text = "Days !";
            }
            else { txtDelay.Text = "None"; txtDays.Text = ""; }
            if (taskDetails.isTranslatorProgress == null && taskDetails.isTranslatorDone == null)
            {
                taskStatus = TaskStatus.New.ToString();
            }
            else if (taskDetails.isTranslatorProgress != null && taskDetails.isTranslatorDone == null)
            {
                taskStatus = TaskStatus.UnderProgress.ToString();
            }
            else if (taskDetails.isTranslatorDone != null)
            {
                taskStatus = TaskStatus.Completed.ToString();
            }
            lblQuality.Visible = txtTranslatorQuality.Visible = false;

            if (taskDetails.isTranslatorReceived == null)
                taskDetails.isTranslatorReceived = DateTime.Now; taskActions.UpdateTask(taskDetails);

            if (taskDetails.TaskFile != null && taskDetails.TaskFile.Length > 0)
            {
                btnDownloadReceivedFile.Enabled = true;
                //btnDownloadReceivedFile.NavigateUrl = taskDetails.TaskFile;
                btnDownloadReceivedFile.Text = new System.IO.FileInfo(Server.MapPath(taskDetails.TaskFile)).Name;
            }
            else
                btnDownloadReceivedFile.Enabled = false;

            if (taskDetails.TranslatorFile != null && taskDetails.TranslatorFile.Length > 0)
            {
                btnSendTask.Enabled = btnDownloadFinishedFile.Enabled = true;
                //btnDownloadReceivedFile.NavigateUrl = taskDetails.TaskFile;
                btnDownloadFinishedFile.Text = new System.IO.FileInfo(Server.MapPath(taskDetails.TranslatorFile)).Name;
            }
            else
                btnSendTask.Enabled = btnDownloadFinishedFile.Enabled = false;
            return taskStatus;
        }
        protected void RadWizard1_FinishButtonClick(object sender, Telerik.Web.UI.WizardEventArgs e)
        {
            try
            {
                if (LoggedUser.User.Employee.RoleID == 4) // reviewer case
                {
                    FinishReviewer();
                }
                else if (LoggedUser.User.Employee.RoleID == 5)  // translator case
                {
                    FinishTranslator();
                }
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "MyAlert();", true);
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
        void FinishReviewer()
        {
            //TaskDetailsDTO taskDetailsDTO = new TaskDetailsDTO()
            //{
            //    TaskID = Guid.Parse(Request["taskid"]),
            //    ProjectID = taskDetails.ProjectID,// Guid.Parse(Request["projid"]),
            //    // isReviewerReceived= ,
            //    // isReviewerProgress = ,
            //    // isReviewerDone = ,
            //    // ReviewerFile = ,
            //    TranslatorQuality = (txtTranslatorQuality.Text == "0" ? (decimal?)null : decimal.Parse(txtTranslatorQuality.Text)),
            //    ReviewerDelay = (txtDelay.Text == "None" ? (int?)null : int.Parse(txtDelay.Text))
            //};
            taskDetails.TranslatorQuality = (txtTranslatorQuality.Text == "0" ? (decimal?)null : decimal.Parse(txtTranslatorQuality.Text));
            taskDetails.ReviewerDelay = (txtDelay.Text == "None" ? (int?)null : int.Parse(txtDelay.Text));
            if (uploadFinishedFile.UploadedFiles.Count > 0)
            {
                taskDetails.ReviewerFile = "~/ProjectsFiles/" + taskDetails.ProjectID +
                       "/" + taskDetails.TaskID + "/ReviewerFile." + uploadFinishedFile.UploadedFiles[0].GetName();
                taskDetails.isReviewerDone = DateTime.Now;
            }
            bool isSuccessUpdate = taskActions.UpdateTask(taskDetails);
            if (isSuccessUpdate)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "MyAlert();", true);
                foreach (UploadedFile f in uploadFinishedFile.UploadedFiles)
                {
                    Static.Files.DirectoryConfirm(Server.MapPath("~/ProjectsFiles/" + taskDetails.ProjectID.ToString() + "/"));
                    Static.Files.DirectoryConfirm(Server.MapPath("~/ProjectsFiles/" + taskDetails.ProjectID.ToString() + "/" + taskDetails.TaskID + "/"));
                    Static.Files.SaveFile(f, Server.MapPath("~/ProjectsFiles/" + taskDetails.ProjectID.ToString() +
                       "/" + taskDetails.TaskID + "/TaskFile." + f.GetName()));
                    //f.SaveAs(Server.MapPath("~/ProjectsFiles/" + taskDetailsDTO.ProjectID.ToString() +
                    //   "/" + taskDetailsDTO.TaskID + "/TaskFile." + f.GetName()), true);
                }

                //Response.Redirect("~/Projects.aspx", false);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ErrAlert();", true);
                //  RadWindowManager1.RadAlert("Project didn't saved for some reasons./nPlease contact system administrator.", null, null, "", "");
            }
        }

        void FinishTranslator()
        {
            //TaskDetailsDTO taskDetailsDTO = new TaskDetailsDTO()
            //{
            //    TaskID = Guid.Parse(Request["taskid"]),
            //    ProjectID = taskDetails.ProjectID,// Guid.Parse(Request["projid"]),
            //    // isTranslatorReceived = ,
            //    // isTranslatorProgress = ,
            //    // isTranslatorDone = ,
            //    //TranslatorFile = ,
            //    TranslatorDelay = (txtDelay.Text == "None" ? (int?)null : int.Parse(txtDelay.Text))
            //};
            taskDetails.TranslatorDelay = (txtDelay.Text == "None" ? (int?)null : int.Parse(txtDelay.Text));
            if (uploadFinishedFile.UploadedFiles.Count > 0)
            {
                taskDetails.TranslatorFile = "~/ProjectsFiles/" + taskDetails.ProjectID +
                       "/" + taskDetails.TaskID + "/TranslatorFile." + uploadFinishedFile.UploadedFiles[0].GetName();
                taskDetails.isTranslatorDone = DateTime.Now;
            }
            bool isSuccessUpdate = taskActions.UpdateTask(taskDetails);
            if (isSuccessUpdate)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "MyAlert();", true);
                foreach (UploadedFile f in uploadFinishedFile.UploadedFiles)
                {
                    Static.Files.DirectoryConfirm(Server.MapPath("~/ProjectsFiles/" + taskDetails.ProjectID.ToString() + "/"));
                    Static.Files.DirectoryConfirm(Server.MapPath("~/ProjectsFiles/" + taskDetails.ProjectID.ToString() + "/" + taskDetails.TaskID + "/"));
                    Static.Files.SaveFile(f, Server.MapPath("~/ProjectsFiles/" + taskDetails.ProjectID.ToString() +
                       "/" + taskDetails.TaskID + "/TranslatorFile." + f.GetName()));
                    //f.SaveAs(Server.MapPath("~/ProjectsFiles/" + taskDetailsDTO.ProjectID.ToString() +
                    //   "/" + taskDetailsDTO.TaskID + "/TaskFile." + f.GetName()), true);
                }

                //Response.Redirect("~/Projects.aspx", false);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ErrAlert();", true);
                //  RadWindowManager1.RadAlert("Project didn't saved for some reasons./nPlease contact system administrator.", null, null, "", "");
            }
        }
        protected void btnDownloadReceivedFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoggedUser.User.EmployeeID == taskDetails.TranslatorID &&
                    taskDetails.isTranslatorProgress == null)
                {
                    taskDetails.isTranslatorProgress = DateTime.Now;
                    taskActions.UpdateTask(taskDetails);
                }
                if (LoggedUser.User.EmployeeID == taskDetails.ReviewerID &&
                    taskDetails.isReviewerProgress == null)
                {
                    taskDetails.isReviewerProgress = DateTime.Now;
                    taskActions.UpdateTask(taskDetails);
                }
                Static.Files.DownloadFile(taskDetails.TaskFile, Response, Server);
            }
            catch (Exception ex)
            { Global.Log.Error(ex); }
        }
        protected void btnDownloadFinishedFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoggedUser.User.EmployeeID == taskDetails.TranslatorID &&
                    taskDetails.isTranslatorDone == null)
                {
                    taskDetails.isTranslatorDone = DateTime.Now;
                    taskActions.UpdateTask(taskDetails);
                }
                if (LoggedUser.User.EmployeeID == taskDetails.ReviewerID &&
                                    taskDetails.isReviewerDone == null)
                {
                    taskDetails.isReviewerDone = DateTime.Now;
                    taskActions.UpdateTask(taskDetails);
                }
                Static.Files.DownloadFile(taskDetails.TranslatorFile, Response, Server);
            }
            catch (Exception ex)
            { Global.Log.Error(ex); }
        }
        protected void btnSendTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoggedUser.User.Employee.RoleID == 4) // reviewer case
                {
                    SendAsReviewer();
                }
                else if (LoggedUser.User.Employee.RoleID == 5)  // translator case
                {
                    SendAsTranslator();
                }
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "MyAlert();", true);
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
        void SendAsReviewer()
        {
            try
            {
                //TaskDTO taskDTO_mail=TaskDAL.GetInstance().gett
                ProjectDetailsDTO projectDetails = ProjectDAL.GetInstance().GetProjectDetailsByID(taskDetails.ProjectID);// Guid.Parse(Request["projid"])));
                EmployeeDetailsDTO empDetails = EmployeeDAL.GetInstance().GetEmployeeDetailsByID(projectDetails.ManagerID);
                //CustomerDetailsDTO CustDetails = new CustomerDAL().GetCustomerDetailsByID(projectDetails.CustomerID);
                DateTime t = DateTime.Now;
                string strBody = MailBody.Template1_Short;
                strBody = strBody.Replace("[TITLE]", "Task Revission Done");
                strBody = strBody.Replace("[RECEPIENT.NAME]", empDetails.FullName);
                strBody = strBody.Replace("[MESSAGE]", "Kindly, be informed that the revission is done for task #" +taskDetails.TaskSerial +
                    "<br/><br/><a href='" + Request.Url.OriginalString.ToLower().Replace("tr.aspx", ".aspx") + "'>Task Details</a>");
                //strBody = strBody.Replace("[BUTTON.TEXT]", "Task Details");
                ////strBody = strBody.Replace("[BUTTON.HREF]", "~/ProjectDetails.aspx?projid=" + Request["projid"] + "&taskid=" + Request["taskid"]);
                //strBody = strBody.Replace("[BUTTON.HREF]", Request.Url.OriginalString);
                //strBody = strBody.Replace("[LINK.TEXT]", "");
                //strBody = strBody.Replace("[LINK.HREF]", "");
                //strBody = strBody.Replace("[BUTTON2.TEXT]", "");
                //strBody = strBody.Replace("[BUTTON2.URL]", "");


                Exception x = new MailSender().Send(empDetails.Email, "Transtec Task Revission Done", strBody);
                string msg = "Mail sent successfully!";
                if (x == null)
                {
                    if (taskDetails.isMailSentToReviewer == null) taskDetails.isMailSentToReviewer = DateTime.Now;
                    taskActions.UpdateTask(taskDetails);
                }
                else
                    msg = x.Message;
                RadWindowManager1.RadAlert(msg + " /nTime:" + ((TimeSpan)(DateTime.Now - t)).Seconds.ToString() + " sec", null, null, "", "");
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
         void    SendAsTranslator(){
            try
            {
                //TaskDTO taskDTO_mail=TaskDAL.GetInstance().gett
                //ProjectDetailsDTO projectDetails = ProjectDAL.GetInstance().GetProjectDetailsByID(taskDetails.ProjectID);// Guid.Parse(Request["projid"])));
                EmployeeDetailsDTO empDetails = EmployeeDAL.GetInstance().GetEmployeeDetailsByID((Guid)taskDetails.ReviewerID);
                //CustomerDetailsDTO CustDetails = new CustomerDAL().GetCustomerDetailsByID(projectDetails.CustomerID);
                DateTime t = DateTime.Now;
                string strBody = MailBody.Template1_Short;
                strBody = strBody.Replace("[TITLE]", "Task Translation Done");
                strBody = strBody.Replace("[RECEPIENT.NAME]", empDetails.FullName);
                strBody = strBody.Replace("[MESSAGE]", "Kindly, be informed that the translation is done for task #" + taskDetails.TaskSerial +
                    "<br/><br/><a href='" + Request.Url.OriginalString  + "'>Task Details</a>");
                //strBody = strBody.Replace("[BUTTON.TEXT]", "Task Details");
                ////strBody = strBody.Replace("[BUTTON.HREF]", "~/ProjectDetails.aspx?projid=" + Request["projid"] + "&taskid=" + Request["taskid"]);
                //strBody = strBody.Replace("[BUTTON.HREF]", Request.Url.OriginalString);
                //strBody = strBody.Replace("[LINK.TEXT]", "");
                //strBody = strBody.Replace("[LINK.HREF]", "");
                //strBody = strBody.Replace("[BUTTON2.TEXT]", "");
                //strBody = strBody.Replace("[BUTTON2.URL]", "");


                Exception x = new MailSender().Send(empDetails.Email, "Transtec Task Translation Done", strBody);
                string msg = "Mail sent successfully!";
                if (x == null)
                {
                    if (taskDetails.isMailSentToTranslator == null) taskDetails.isMailSentToTranslator = DateTime.Now;
                    taskActions.UpdateTask(taskDetails);
                }
                else
                    msg = x.Message;
                RadWindowManager1.RadAlert(msg + " \nTime:" + ((TimeSpan)(DateTime.Now - t)).Seconds.ToString() + " sec", null, null, "", "");
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
    }
}