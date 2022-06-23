using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using TranSmart.DAL;

namespace TranSmart
{
    public partial class Projects : System.Web.UI.Page
    {
        //DTO.CustomerDetailsDTO clintDetails = null;
        ProjectDAL projectActions = ProjectDAL.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {            
            
        }
        private void Page_LoadComplete(object sender, EventArgs e)
        {
            try
            {
                if (Request["clintid"] != null && Request["clintid"] != "")
                {
                    grdProjList.DataSource = projectActions.GetAllProjects(Guid.Parse(Request["clintid"]), ProjectBy.Customer);
                    grdProjList.DataBind();
                }
                else if(Request["pmid"] != null && Request["pmid"] != "")
                {
                    grdProjList.DataSource = projectActions.GetAllProjects(Guid.Parse(Request["pmid"]), ProjectBy.ProjectManager);
                    grdProjList.DataBind();
                }
                else
                {
                    grdProjList.DataSource = projectActions.GetAllProjects();
                    grdProjList.DataBind();
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
            }
        }
    }
}