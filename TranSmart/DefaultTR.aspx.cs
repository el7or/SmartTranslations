using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Web.UI;
using TranSmart.DAL;
using TranSmart.DTO;

namespace TranSmart
{
    public partial class DefaultTR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!cSession.LoggedUser.isLogged) return;

                IEnumerable<TaskListDTO> TasksNew = TaskDAL.GetInstance().GetTasksNew();
                lblNewTasksCount.Text = TasksNew.Count().ToString();
                if (TasksNew.Count() > 0) grdNewTasks.Visible = true; grdNewTasks.DataSource = TasksNew;

                IEnumerable<TaskListDTO> TasksNow = TaskDAL.GetInstance().GetTasksInProgress();
                lblProgressTasksCount.Text = TasksNow.Count().ToString();
                if (TasksNew.Count() > 0) grdProgressTasks.Visible = true; grdProgressTasks.DataSource = TasksNow;
                
                IEnumerable<TaskListDTO> TasksDone = TaskDAL.GetInstance().GetTasksDone();
                lblDoneTasksCount.Text = TasksDone.Count().ToString();
                if (TasksNew.Count() > 0) grdDoneTasks.Visible = true; grdDoneTasks.DataSource = TasksDone;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
    }
}