using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TranSmart.DAL;

namespace TranSmart
{
    public partial class ProjectTasks : System.Web.UI.Page
    {
        TaskDAL tasksActions = TaskDAL.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnNew.PostBackUrl = "~/ProjectTasksDetails.aspx?projid=" + Request["projid"];
        }
        private void Page_LoadComplete(object sender, EventArgs e)
        {
            try
            {
                if (Request["projid"] != null && Request["projid"] != "")
                {
                    grdTaskList.DataSource = tasksActions.GetTasksByProject(Guid.Parse(Request["projid"]));
                    grdTaskList.DataBind();
                    btnNew.Enabled = true;
                }
                else
                {
                    grdTaskList.DataSource = tasksActions.GetAllTasks();
                    grdTaskList.DataBind();
                    btnNew.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                 
            }
        }
    }
}