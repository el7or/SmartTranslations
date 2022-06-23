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
    public partial class ProjectTasksDetails : System.Web.UI.Page
    {
        TaskDAL taskActions = TaskDAL.GetInstance();
        private TaskDetailsDTO taskDetails;
        EmployeeDAL staffActions = EmployeeDAL.GetInstance();
        private NewTaskDetailsDTO newTaskDetails;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Load_Combos();
                if (Request["taskid"] != null && Request["taskid"] != "")
                    taskDetails = taskActions.GetTaskDetailsByID(Guid.Parse(Request["taskid"]));

                if (taskDetails == null)
                {
                    newTaskDetails = taskActions.GetNewTaskDetailsByID(Guid.Parse(Request["projid"]));
                    lblTaskSerial.Text = newTaskDetails.TaskSerial;
                    txtProjWords.Text = newTaskDetails.ProjectWords.ToString();
                    txtOtherTasksWords.Text = newTaskDetails.TasksWords.ToString();
                    txtRemainingWords.Text = (newTaskDetails.ProjectWords - newTaskDetails.TasksWords).ToString();
                    txtProjectPromise.Text = newTaskDetails.ProjectPromiseDeliveryDate.Value.ToString("yyyy/MM/dd");
                    txtProjectManager.Text = LoggedUser.User.Employee.FullName;
                    btnCancelTask.Enabled = false;
                }
                else
                {
                    stepFiles.Visible = true;
                    stepWorkflow.Visible = true;
                    btnCancelTask.Enabled = true;

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
            taskDetails = taskActions.GetTaskDetailsByID(Guid.Parse(Request["taskid"]));
            lblTaskSerial.Text = taskDetails.TaskSerial;
            txtProjWords.Text = taskDetails.ProjectWords.ToString();
            txtOtherTasksWords.Text = taskDetails.TasksWords.ToString();
            txtWordCount.Text = taskDetails.WordCount.ToString();
            txtRemainingWords.Text = (taskDetails.ProjectWords - (taskDetails.TasksWords + taskDetails.WordCount)).ToString();
            txtTaskDesc.Text = taskDetails.TaskDescription;
            ddlTranslatorTask.SelectedValue = taskDetails.TranslatorID.ToString();
            ddlReviewerTask.SelectedValue = taskDetails.ReviewerID.ToString();
            //ddlTranslatorTask.FindItemByValue(taskDetails.TranslatorID.ToString()).Selected = true;
            //ddlReviewerTask.FindItemByValue(taskDetails.ReviewerID.ToString()).Selected = true;
            txtProjectManager.Text = taskDetails.ProjectManager;
            dtTranslatorDeadline.SelectedDate = taskDetails.TranslatorDeadLine;
            dtReviewerDeadline.SelectedDate = taskDetails.ReviewerDeadLine;
            txtTranslatorReceived.Text = (taskDetails.isTranslatorReceived == null ? "" : taskDetails.isTranslatorReceived.Value.ToString("yyyy/MM/dd hh:mm:ss"));
            txtTranslatorDone.Text = (taskDetails.isTranslatorDone == null ? "" : taskDetails.isTranslatorDone.Value.ToString("yyyy/MM/dd hh:mm:ss"));
            txtReviewerReceived.Text = (taskDetails.isReviewerReceived == null ? "" : taskDetails.isReviewerReceived.Value.ToString("yyyy/MM/dd hh:mm:ss"));
            txtReviewerDone.Text = (taskDetails.isReviewerDone == null ? "" : taskDetails.isReviewerDone.Value.ToString("yyyy/MM/dd hh:mm:ss"));
            txtProjectPromise.Text = taskDetails.ProjectPromiseDeliveryDate.Value.ToString("yyyy/MM/dd hh:mm:ss");
            txtTranslatorQuality.Text = (taskDetails.TranslatorQuality == null ? "0" : taskDetails.TranslatorQuality.ToString());
            if (taskDetails.TaskFile != null && taskDetails.TaskFile.Length > 0)
            {
                btnTaskDownload.Enabled = btnSendTask.Enabled = true;
                btnTaskDownload.NavigateUrl = taskDetails.TaskFile;
                btnTaskDownload.Text = new System.IO.FileInfo(Server.MapPath(taskDetails.TaskFile)).Name;
            }
            else
                btnTaskDownload.Enabled = btnSendTask.Enabled = false;

            if (taskDetails.TranslatorFile != null && taskDetails.TranslatorFile.Length > 0)
            {
                btnDownloadTaskTranslator.Enabled = true;
                btnDownloadTaskTranslator.NavigateUrl = taskDetails.TranslatorFile;
                btnDownloadTaskTranslator.Text = new System.IO.FileInfo(Server.MapPath(taskDetails.TranslatorFile)).Name;
            }
            else
                btnDownloadTaskTranslator.Enabled = false;

            if (taskDetails.ReviewerFile != null && taskDetails.ReviewerFile.Length > 0)
            {
                btnDownloadTaskReviewer.Enabled = true;
                btnDownloadTaskReviewer.NavigateUrl = taskDetails.ReviewerFile;
                btnDownloadTaskReviewer.Text = new System.IO.FileInfo(Server.MapPath(taskDetails.ReviewerFile)).Name;
            }
            else
                btnDownloadTaskReviewer.Enabled = false;

            hfStatusHeader.Value = taskDetails.TaskStatus;
            if (taskDetails.TaskStatus == TaskStatus.Canceled.ToString())
            {
                btnActiveTask.Visible = true;
                btnCancelTask.Visible = false;
            }
            else
            {
                btnActiveTask.Visible = false;
                btnCancelTask.Visible = true;
            }
            hfIsTranslatorReceived.Value = lblIsTranslatorReceived.Text = taskDetails.isTranslatorReceived.Value.ToString("yyyy/MM/dd hh:mm:ss");
            hfIsTranslatorInProgress.Value = lblIsTranslatorInProgress.Text = taskDetails.isTranslatorProgress.Value.ToString("yyyy/MM/dd hh:mm:ss");
            hfIsTranslatorDone.Value = lblIsTranslatorDone.Text = taskDetails.isTranslatorDone.Value.ToString("yyyy/MM/dd hh:mm:ss");
            hfIsReviewerReceived.Value = lblIsReviewerReceived.Text = taskDetails.isReviewerReceived.Value.ToString("yyyy/MM/dd hh:mm:ss");
            hfIsReviewerInProgress.Value = lblIsReviewerInProgress.Text = taskDetails.isReviewerProgress.Value.ToString("yyyy/MM/dd hh:mm:ss");
            hfIsReviewerDone.Value = lblIsReviewerDone.Text = taskDetails.isReviewerDone.Value.ToString("yyyy/MM/dd hh:mm:ss");
        }
        #endregion

        #region Add & Update Task
        protected void RadWizard1_FinishButtonClick(object sender, Telerik.Web.UI.WizardEventArgs e)
        {
            try
            {
                // Add new Task
                if (taskDetails == null)//Request["taskid"] == null || Request["taskid"] == "")
                {
                    AddTask();
                }
                // Update existing Task
                else
                {
                    UpdateTask();
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
        private void AddTask()
        {
            try
            {
                Guid taskID = Guid.NewGuid();
                TaskDTO taskDTO = new TaskDTO
                {
                    TaskID = taskID,
                    ProjectID =  Guid.Parse(Request["projid"]),
                    TranslatorID = Guid.Parse(ddlTranslatorTask.SelectedValue),
                    ReviewerID = Guid.Parse(ddlReviewerTask.SelectedValue),
                    TaskDescription = txtTaskDesc.Text,
                    WordCount = long.Parse(txtWordCount.Text),
                    TranslatorDeadLine = (DateTime)dtTranslatorDeadline.SelectedDate,
                    ReviewerDeadLine = (DateTime)dtReviewerDeadline.SelectedDate,
                    // TaskFile = 
                    // isMailSentToTranslator =
                    // isMailSentToReviewer = 
                };
                if (uploadTaskFile.UploadedFiles.Count > 0)
                {
                    //taskDTO.isOfferSentToCustomer = DateTime.Now;
                    //taskDTO.isCustomerApproved = DateTime.Now;

                    taskDTO.TaskFile = "~/ProjectsFiles/" + taskDTO.ProjectID +
                           "/" + taskDTO.TaskID + "/TaskFile." + uploadTaskFile.UploadedFiles[0].GetName();
                }
                Guid resultID = taskActions.CreateTask(taskDTO);
                //Response.Redirect("~/ProjectTasks.aspx?projid=" + Request["projid"]);

                //Guid resultID = projectActions.CreateProject(projDTO);
                if (resultID == taskID)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "MyAlert();", true);
                    foreach (UploadedFile f in uploadTaskFile.UploadedFiles)
                    {
                        Static.Files.DirectoryConfirm(Server.MapPath("~/ProjectsFiles/" + taskDTO.ProjectID.ToString() + "/"));
                        Static.Files.DirectoryConfirm(Server.MapPath("~/ProjectsFiles/" + taskDTO.ProjectID.ToString() + "/" + taskDTO.TaskID + "/"));

                        Static.Files.SaveFile(f, Server.MapPath("~/ProjectsFiles/" + taskDTO.ProjectID +
                           "/" + taskDTO.TaskID + "/TaskFile." + f.GetName()));
                        //f.SaveAs(Server.MapPath("~/ProjectsFiles/" + taskDTO.ProjectID + 
                        //   "/" + taskDTO.TaskID + "/TaskFile." + f.GetName()), true);
                    }

                    Response.Redirect("~/ProjectTasksDetails.aspx?projid=" + Request["projid"]+ "&taskid="+ taskID, false);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ErrAlert();", true);
                  //  RadWindowManager1.RadAlert("Project didn't saved for some reasons./nPlease contact system administrator.", null, null, "", "");
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }

        private void UpdateTask()
        {
            try
            {
                //TaskDetailsDTO taskDetailsDTO = new TaskDetailsDTO()
                //{
                //    TaskID = Guid.Parse(Request["taskid"]),
                //    ProjectID = taskDetails.ProjectID,//Guid.Parse(Request["projid"]),
                //    TranslatorID = Guid.Parse(ddlTranslatorTask.SelectedValue),
                //    ReviewerID = Guid.Parse(ddlReviewerTask.SelectedValue),
                //    TaskDescription = txtTaskDesc.Text,
                //    WordCount = long.Parse(txtWordCount.Text),
                //    TranslatorDeadLine = (DateTime)dtTranslatorDeadline.SelectedDate,
                //    ReviewerDeadLine = (DateTime)dtReviewerDeadline.SelectedDate,
                //    // TaskFile = 
                //    // isMailSentToTranslator =
                //    // isMailSentToReviewer = 
                //};
                taskDetails.TranslatorID = Guid.Parse(ddlTranslatorTask.SelectedValue);
                taskDetails.ReviewerID = Guid.Parse(ddlReviewerTask.SelectedValue);
                taskDetails.TaskDescription = txtTaskDesc.Text;
                taskDetails.WordCount = long.Parse(txtWordCount.Text);
                taskDetails.TranslatorDeadLine = (DateTime)dtTranslatorDeadline.SelectedDate;
                taskDetails.ReviewerDeadLine = (DateTime)dtReviewerDeadline.SelectedDate;

                if (uploadTaskFile.UploadedFiles.Count > 0)
                {
                    //taskDTO.isOfferSentToCustomer = DateTime.Now;
                    //taskDTO.isCustomerApproved = DateTime.Now;
                    taskDetails.TaskFile = "~/ProjectsFiles/" + taskDetails.ProjectID.ToString() +
                           "/" + taskDetails.TaskID + "/TaskFile." + uploadTaskFile.UploadedFiles[0].GetName();
                }
                
                bool isSuccessUpdate = taskActions.UpdateTask(taskDetails);                                
                if (isSuccessUpdate)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "MyAlert();", true);
                    foreach (UploadedFile f in uploadTaskFile.UploadedFiles)
                    {
                        Static.Files.DirectoryConfirm(Server.MapPath("~/ProjectsFiles/" + taskDetails.ProjectID.ToString() + "/"));
                        Static.Files.DirectoryConfirm(Server.MapPath("~/ProjectsFiles/" + taskDetails.ProjectID.ToString() + "/" + taskDetails.TaskID + "/"));
                        Static.Files.SaveFile( f, Server.MapPath("~/ProjectsFiles/" + taskDetails.ProjectID.ToString() +
                           "/" + taskDetails.TaskID + "/TaskFile." + f.GetName()));
                        //f.SaveAs(Server.MapPath("~/ProjectsFiles/" + taskDetailsDTO.ProjectID.ToString() +
                        //   "/" + taskDetailsDTO.TaskID + "/TaskFile." + f.GetName()), true);
                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "MyAlert();", true);
                    //Response.Redirect("~/Projects.aspx",false);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ErrAlert();", true);
                    //  RadWindowManager1.RadAlert("Project didn't saved for some reasons./nPlease contact system administrator.", null, null, "", "");
                }

                
                //Response.Redirect("~/ProjectTasks.aspx?projid=" + Request["projid"]);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "MyAlert();", true);
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
        //void SaveFile(UploadedFile f, string path)
        //{
        //    try
        //    {
        //        if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(path)))
        //            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));
        //        f.SaveAs(path, true);
        //    }
        //    catch (Exception ex) { Global.Log.Error(ex); }
        //}
        #endregion

        #region Cancel Task
        protected void btnCancelTask_Click(object sender, EventArgs e)
        {
            bool isSuccsessCancel = taskActions.CancelTask(Guid.Parse(Request["taskid"]));
            Response.Redirect("~/ProjectTasks.aspx?projid=" + Request["projid"], false);
        }
        #endregion

        #region Re-Activate Task
        protected void btnActiveTask_Click(object sender, EventArgs e)
        {
            bool isSuccsessActivate = taskActions.ActivateTask(Guid.Parse(Request["taskid"]));
            Response.Redirect("~/ProjectTasks.aspx?projid=" + Request["projid"], false);
        }
        #endregion

        protected void Load_Combos()
        {
            if (IsPostBack) return;
            ddlTranslatorTask.Items.Clear();
            ddlTranslatorTask.DataSource = staffActions.GetTranslatorsList();
            ddlTranslatorTask.DataTextField = "FullName";
            ddlTranslatorTask.DataValueField = "EmployeeID";
            ddlTranslatorTask.DataBind();

            ddlReviewerTask.Items.Clear();
            ddlReviewerTask.DataSource = staffActions.GetReviewersList();
            ddlReviewerTask.DataTextField = "FullName";
            ddlReviewerTask.DataValueField = "EmployeeID";
            ddlReviewerTask.DataBind();
        }

        protected void btnShowProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ProjectDetails.aspx?projid=" + Request["projid"], false);
        }
        protected void btnSendTask_Click(object sender, EventArgs e)
        {
            try
            {
                //TaskDTO taskDTO_mail=TaskDAL.GetInstance().gett
                ProjectDetailsDTO projectDetails = ProjectDAL.GetInstance().GetProjectDetailsByID(taskDetails.ProjectID);// Guid.Parse(Request["projid"])));
                EmployeeDetailsDTO empDetails = EmployeeDAL.GetInstance().GetEmployeeDetailsByID((Guid)taskDetails.TranslatorID);
                //CustomerDetailsDTO CustDetails = new CustomerDAL().GetCustomerDetailsByID(projectDetails.CustomerID);
                DateTime t = DateTime.Now;
                string strBody = MailBody.Template1_Short;
                strBody = strBody.Replace("[TITLE]", "New Translation Task");
                strBody = strBody.Replace("[RECEPIENT.NAME]", empDetails.FullName);
                strBody = strBody.Replace("[MESSAGE]", "Kindly, be informed that a new translation is assaigned to you."+
                    "<br/><br/><a href='"+ Request.Url.OriginalString.Replace(".aspx","tr.aspx") + "'>Task Details</a>"             );
                //strBody = strBody.Replace("[BUTTON.TEXT]", "Task Details");
                ////strBody = strBody.Replace("[BUTTON.HREF]", "~/ProjectDetails.aspx?projid=" + Request["projid"] + "&taskid=" + Request["taskid"]);
                //strBody = strBody.Replace("[BUTTON.HREF]", Request.Url.OriginalString);
                //strBody = strBody.Replace("[LINK.TEXT]", "");
                //strBody = strBody.Replace("[LINK.HREF]", "");
                //strBody = strBody.Replace("[BUTTON2.TEXT]", "");
                //strBody = strBody.Replace("[BUTTON2.URL]", "");


                Exception x = new MailSender().Send(empDetails.Email, "Transtec New Translation Task ", strBody);
                string msg = "Mail sent successfully!", head = "Success!", typ = "success";
                if (x == null)
                {
                    if (taskDetails.isMailSentToTranslator == null) taskDetails.isMailSentToTranslator = DateTime.Now;
                    taskActions.UpdateTask(taskDetails);
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ErrAlert();", true);
                //RadAjaxManager1.ResponseScripts.Add(string.Format("MyAlert2('{0}','{1}','{2}');", head, msg, typ));
                }
                else
                {
                    msg = x.Message;
                    RadWindowManager1.RadAlert(msg, null, null, "", "");// + " /nTime:" + ((TimeSpan)(DateTime.Now - t)).Seconds.ToString() + " sec"
                    head = "Faild!";typ = "error";
                }
                RadAjaxManager1.ResponseScripts.Add(string.Format("MyAlert2('{0}','{1}','{2}');", head, msg, typ));
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
    }
}