using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Web.UI;
using TranSmart.DAL;
using TranSmart.DTO;

namespace TranSmart
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!cSession.LoggedUser.isLogged) return;

                IEnumerable<ProjectsListDTO> ProjectsSoon = ProjectDAL.GetInstance().GetProjectsSoon();
                lblSoonProjectsCount.Text = ProjectsSoon.Count().ToString();
                if (ProjectsSoon.Count() > 0) grdSoonProjects.Visible = true; grdSoonProjects.DataSource = ProjectsSoon;

                IEnumerable<ProjectsListDTO> ProjectsPending = ProjectDAL.GetInstance().GetProjectsPending();
                lblPendingProjectsCount.Text = ProjectsPending.Count().ToString();
                if (ProjectsPending.Count() > 0) grdPendingProjects.Visible = true; grdPendingProjects.DataSource = ProjectsPending;

                IEnumerable<ProjectsListDTO> ProjectsProgress = ProjectDAL.GetInstance().GetProjectsInProgress();
                lblProgressProjectsCount.Text = ProjectsProgress.Count().ToString();
                if (ProjectsProgress.Count() > 0) grdProgressProjects.Visible = true; grdProgressProjects.DataSource = ProjectsProgress;

                IEnumerable<ProjectsListDTO> ProjectsDone = ProjectDAL.GetInstance().GetProjectsDone();
                lblDoneProjectsCount.Text = ProjectsDone.Count().ToString();
                if (ProjectsDone.Count() > 0) grdDoneProjects.Visible = true; grdDoneProjects.DataSource = ProjectsDone;

                IEnumerable<TaskListDTO> TasksSoon = TaskDAL.GetInstance().GetTasksSoon(); 
                lblSoonTranslationsCount.Text = TasksSoon.Count().ToString();
                if (TasksSoon.Count() > 0) grdSoonTasks.Visible = true; grdSoonTasks.DataSource = TasksSoon;

                IEnumerable<PaymentsSoonDTO> PaymentsSoon = PaymentDAL.GetInstance().GetPaymentsSoon(); 
                lblSoonPaymentsCount.Text = PaymentsSoon.Count().ToString();
                if (PaymentsSoon.Count() > 0) grdSoonPayments.Visible = true; grdSoonPayments.DataSource = PaymentsSoon;




                //cSession.LoggedUser.User.Employee.Projects
                //Page.LoadComplete += Page_LoadComplete;
                // DTO.EmployeeDetailsDTO empDetails = null;
                //EmployeeDAL empActions = EmployeeDAL.GetInstance();

                //grdEmpList.DataSource = empActions.GetAllEmployees();
                //grdEmpList.DataBind();
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }

        protected void messages_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            //string lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            //DateTime date = DateTime.Now;
            //List<Message> messagesList = new List<Message>();

            //for (int i = 0; i < 30; i++)
            //{
            //    Message msg = new Message()
            //    {
            //        MessageID = i,
            //        Body = lorem,
            //        Received = i % 2 == 0 ? date : date.AddDays(2),
            //        From = "John.Doe@telerik.com",
            //        Subject = "Telerik WebMail"
            //    };

            //    messagesList.Add(msg);
            //}

            //messages.DataSource = messagesList;
        }
    }

    public class Message
    {
        //public int MessageID { get; set; }
        //public string Body { get; set; }
        //public string From { get; set; }
        //public string Email { get; set; }
        //public string Subject { get; set; }
        //public DateTime Received { get; set; }
    }
}