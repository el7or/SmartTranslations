using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using TranSmart.cSession;
using TranSmart.DTO;
using TranSmart.Models;

namespace TranSmart.DAL
{
    public class ProjectDAL
    {
        // Get Object from Class
        private static ProjectDAL instance;
        private static object mutex = new object();
        public static ProjectDAL GetInstance()
        {
            lock (mutex)
            {
                if (instance == null)
                {
                    instance = new ProjectDAL();
                }
                return instance;
            }
        }

        TranSmartDBContext dbContext = null;
        public ProjectDAL()
        {
            dbContext = new TranSmartDBContext();
        }

        // Get all projects
        public IEnumerable<ProjectsListDTO> GetAllProjects()
        {
            try
            {
                var projectsList = new List<ProjectsListDTO>();
                int roleID = LoggedUser.User.Employee.RoleID;
                if (roleID == 3)
                {
                    projectsList = (from projects in dbContext.Projects
                                    where projects.IsDeleted == false && projects.ManagerID == LoggedUser.User.EmployeeID
                                    orderby projects.CreatedDate descending
                                    select new ProjectsListDTO
                                    {
                                        ProjectID = projects.ProjectID,
                                        CustomerID = projects.CustomerID,
                                        ManagerID = projects.ManagerID,
                                        ProjectSerial = projects.ProjectSerial.ToString(),
                                        CustomerName = projects.Customer.CustomerName,
                                        ProjectManager = projects.Employee.FullName,
                                        ProjectTitle = projects.ProjectTitle,
                                        CurrentStatus = projects.ProjectStatus,
                                        LanggFromTo = projects.SourceLangg + " >> " + projects.TargetLangg,
                                        TotalCost = (projects.WordCount * projects.WordPrice) + projects.VatValue - projects.DiscountValue,
                                        CreatedDate = SqlFunctions.DatePart("year", projects.CreatedDate) + "/" + SqlFunctions.DatePart("month", projects.CreatedDate) + "/" + SqlFunctions.DatePart("day", projects.CreatedDate),
                                        CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                        LastEditedDate = SqlFunctions.DatePart("year", projects.EditedDate) + "/" + SqlFunctions.DatePart("month", projects.EditedDate) + "/" + SqlFunctions.DatePart("day", projects.EditedDate),
                                        LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                    }).ToList();
                    return projectsList;
                }
                else
                {
                    projectsList = (from projects in dbContext.Projects
                                    where projects.IsDeleted == false
                                    orderby projects.CreatedDate descending
                                    select new ProjectsListDTO
                                    {
                                        ProjectID = projects.ProjectID,
                                        CustomerID = projects.CustomerID,
                                        ManagerID = projects.ManagerID,
                                        ProjectSerial = projects.ProjectSerial.ToString(),
                                        CustomerName = projects.Customer.CustomerName,
                                        ProjectManager = projects.Employee.FullName,
                                        ProjectTitle = projects.ProjectTitle,
                                        CurrentStatus = projects.ProjectStatus,
                                        LanggFromTo = projects.SourceLangg + " >> " + projects.TargetLangg,
                                        WordCount = projects.WordCount,
                                        WordPrice = projects.WordPrice,
                                        DiscountValue = projects.DiscountValue,
                                        VatValue = projects.VatValue,
                                        TotalCost = (projects.WordCount * projects.WordPrice) + projects.VatValue - projects.DiscountValue,
                                        Paid = (projects.Payments.Where(p => p.PaymentDirection == true).Count() > 0 ? projects.Payments.Where(p => p.PaymentDirection == true).Sum(p => p.Paid) : 0),
                                        Due = ((projects.WordCount * projects.WordPrice) + projects.VatValue - projects.DiscountValue) - ((projects.Payments.Where(p => p.PaymentDirection == true).Count() > 0 ? projects.Payments.Where(p => p.PaymentDirection == true).Sum(p => p.Paid) : 0)),
                                        CreatedDate = SqlFunctions.DatePart("year", projects.CreatedDate) + "/" + SqlFunctions.DatePart("month", projects.CreatedDate) + "/" + SqlFunctions.DatePart("day", projects.CreatedDate),
                                        CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                        LastEditedDate = SqlFunctions.DatePart("year", projects.EditedDate) + "/" + SqlFunctions.DatePart("month", projects.EditedDate) + "/" + SqlFunctions.DatePart("day", projects.EditedDate),
                                        LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                    }).ToList();
                    return projectsList;
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                return null;
            }
        }
        public IEnumerable<ProjectsListDTO> GetAllProjects(Guid id, ProjectBy type)
        {
            try
            {
                var projectsList = new List<ProjectsListDTO>();
                if (type == ProjectBy.Customer)
                {
                    projectsList = (from projects in dbContext.Projects
                                    where projects.IsDeleted == false && projects.CustomerID == id
                                    orderby projects.CreatedDate descending
                                    select new ProjectsListDTO
                                    {
                                        ProjectID = projects.ProjectID,
                                        CustomerID = projects.CustomerID,
                                        ManagerID = projects.ManagerID,
                                        ProjectSerial = projects.ProjectSerial.ToString(),
                                        CustomerName = projects.Customer.CustomerName,
                                        ProjectManager = projects.Employee.FullName,
                                        ProjectTitle = projects.ProjectTitle,
                                        CurrentStatus = projects.ProjectStatus,
                                        LanggFromTo = projects.SourceLangg + " >> " + projects.TargetLangg,
                                        WordCount = projects.WordCount,
                                        WordPrice = projects.WordPrice,
                                        DiscountValue = projects.DiscountValue,
                                        VatValue = projects.VatValue,
                                        TotalCost = (projects.WordCount * projects.WordPrice) + projects.VatValue - projects.DiscountValue,
                                        Paid = (projects.Payments.Where(p => p.PaymentDirection == true).Count() > 0 ? projects.Payments.Where(p => p.PaymentDirection == true).Sum(p => p.Paid) : 0),
                                        Due = ((projects.WordCount * projects.WordPrice) + projects.VatValue - projects.DiscountValue) - ((projects.Payments.Where(p => p.PaymentDirection == true).Count() > 0 ? projects.Payments.Where(p => p.PaymentDirection == true).Sum(p => p.Paid) : 0)),
                                        CreatedDate = SqlFunctions.DatePart("year", projects.CreatedDate) + "/" + SqlFunctions.DatePart("month", projects.CreatedDate) + "/" + SqlFunctions.DatePart("day", projects.CreatedDate),
                                        CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                        LastEditedDate = SqlFunctions.DatePart("year", projects.EditedDate) + "/" + SqlFunctions.DatePart("month", projects.EditedDate) + "/" + SqlFunctions.DatePart("day", projects.EditedDate),
                                        LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                    }).ToList();
                    return projectsList;
                }
                if (type == ProjectBy.ProjectManager)
                {
                    projectsList = (from projects in dbContext.Projects
                                    where projects.IsDeleted == false && projects.ManagerID == id
                                    orderby projects.CreatedDate descending
                                    select new ProjectsListDTO
                                    {
                                        ProjectID = projects.ProjectID,
                                        CustomerID = projects.CustomerID,
                                        ManagerID = projects.ManagerID,
                                        ProjectSerial = projects.ProjectSerial.ToString(),
                                        CustomerName = projects.Customer.CustomerName,
                                        ProjectManager = projects.Employee.FullName,
                                        ProjectTitle = projects.ProjectTitle,
                                        CurrentStatus = projects.ProjectStatus,
                                        LanggFromTo = projects.SourceLangg + " >> " + projects.TargetLangg,
                                        TotalCost = (projects.WordCount * projects.WordPrice) + projects.VatValue - projects.DiscountValue,
                                        CreatedDate = SqlFunctions.DatePart("year", projects.CreatedDate) + "/" + SqlFunctions.DatePart("month", projects.CreatedDate) + "/" + SqlFunctions.DatePart("day", projects.CreatedDate),
                                        CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                        LastEditedDate = SqlFunctions.DatePart("year", projects.EditedDate) + "/" + SqlFunctions.DatePart("month", projects.EditedDate) + "/" + SqlFunctions.DatePart("day", projects.EditedDate),
                                        LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                    }).ToList();
                    return projectsList;
                }
                return null;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                return null;
            }
        }

        // Get Project details by projectID
        public ProjectDetailsDTO GetProjectDetailsByID(Guid projectID)
        {
            try
            {
                ProjectDetailsDTO project = dbContext.Projects.Where(p => p.ProjectID == projectID)
                    .Select(projects => new ProjectDetailsDTO
                    {
                        ProjectID = projects.ProjectID,
                        ProjectSerial = projects.ProjectSerial.ToString(),
                        ProjectTitle = projects.ProjectTitle,
                        SourceLanggID = dbContext.ValLanguages.Where(l => l.LanguageText == projects.SourceLangg).Select(s => s.LanguageID).FirstOrDefault(),
                        TargetLanggID = dbContext.ValLanguages.Where(l => l.LanguageText == projects.TargetLangg).Select(s => s.LanguageID).FirstOrDefault(),
                        CustomerID = projects.CustomerID,
                        CustomerRequestDate = projects.CustomerRequestDate,
                        PromiseDeliveryDate = projects.PromiseDeliveryDate,
                        Notes = projects.Note,
                        WordCount = projects.WordCount,
                        WordPrice = projects.WordPrice,
                        DiscountValue = projects.DiscountValue,
                        VatValue = projects.VatValue,
                        PrevPayments = (projects.Payments.Where(p => p.PaymentDirection == true).Count() > 0 ? projects.Payments.Where(p => p.PaymentDirection == true).Sum(p => p.Paid) : 0),
                        NextPaymentDate = projects.Payments.OrderByDescending(n => n.CreatedBy).Select(n => n.NextPaymentDate).FirstOrDefault(),
                        CustomerFile = projects.CustomerFile,
                        FinalFile = projects.FinalFile,
                        ProjectManager = projects.Employee.FullName,
                        Translators = projects.ProjectTasks.Select(p => p.Employee.FullName).Distinct().ToList(),
                        Reviewers = projects.ProjectTasks.Select(p => p.Employee1.FullName).Distinct().ToList(),
                        ProjectStatus = projects.ProjectStatus,
                        isOfferSentToCustomer = projects.isOfferSentToCustomer,// (projects.isOfferSentToCustomer == null ? null : SqlFunctions.DatePart("year", projects.isOfferSentToCustomer) + "/" + SqlFunctions.DatePart("month", projects.isOfferSentToCustomer) + "/" + SqlFunctions.DatePart("day", projects.isOfferSentToCustomer)),
                        isCustomerApproved = projects.isCustomerApproved,// (projects.isCustomerApproved == null ? null : SqlFunctions.DatePart("year", projects.isCustomerApproved) + "/" + SqlFunctions.DatePart("month", projects.isCustomerApproved) + "/" + SqlFunctions.DatePart("day", projects.isCustomerApproved)),
                        //isTasksSent = (projects.ProjectTasks.Where(i => i.isMailSentToTranslator != null).Count() > 0 ? projects.ProjectTasks.OrderByDescending(o => o.isMailSentToTranslator).Select(i => i.isMailSentToTranslator.ToString()).FirstOrDefault() : null),
                        //isTasksInProgress = (projects.ProjectTasks.Where(i => i.isTranslatorProgress != null).Count() > 0 ? projects.ProjectTasks.OrderByDescending(o => o.isTranslatorProgress).Select(i => i.isTranslatorProgress.ToString()).FirstOrDefault() : null),
                        //isTasksFinished = (projects.ProjectTasks.Where(i => i.isReviewerDone != null).Count() == projects.ProjectTasks.Count() ? projects.ProjectTasks.OrderBy(o => o.isReviewerDone).Select(i => i.isReviewerDone.ToString()).FirstOrDefault() : null),
                        isTasksSent = (projects.ProjectTasks.Where(i => i.isMailSentToTranslator != null).Count() > 0 ? projects.ProjectTasks.OrderByDescending(o => o.isMailSentToTranslator).Select(i => i.isMailSentToTranslator.ToString()).FirstOrDefault() : null),
                        isTasksInProgress = (projects.ProjectTasks.Where(i => i.isTranslatorProgress != null).Count() > 0 ? projects.ProjectTasks.OrderByDescending(o => o.isTranslatorProgress).Select(i => i.isTranslatorProgress.ToString()).FirstOrDefault() : null),
                        isTasksFinished = (projects.ProjectTasks.Where(i => i.isReviewerDone != null).Count() == projects.ProjectTasks.Count() ? projects.ProjectTasks.OrderBy(o => o.isReviewerDone).Select(i => i.isReviewerDone.ToString()).FirstOrDefault() : null),
                        isProjectDelivered = projects.ActualDeliveryDate //(projects.ActualDeliveryDate == null ? null : projects.ActualDeliveryDate.ToString())
                    }).FirstOrDefault();
                return project;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                return null;
            }
        }

        // Create new project
        public Guid CreateProject(ProjectDTO projData)
        {
            try
            {
                Project newProject = new Project()
                {
                    ProjectID = projData.ProjectID, //Guid.NewGuid(),
                    CustomerID = projData.CustomerID,
                    ManagerID = projData.ManagerID,
                    ProjectTitle = projData.ProjectTitle,
                    ProjectStatus = ProjectStatus.New.ToString(),
                    CustomerRequestDate = projData.CustomerRequestDate,
                    CustomerFile = projData.CustomerFile,
                    SourceLangg = projData.SourceLangg,
                    TargetLangg = projData.TargetLangg,
                    WordCount = projData.WordCount,
                    WordPrice = projData.WordPrice,
                    DiscountValue = projData.DiscountValue,
                    VatValue = projData.VatValue,
                    isOfferSentToCustomer = projData.isOfferSentToCustomer,
                    isCustomerApproved = projData.isCustomerApproved,
                    PromiseDeliveryDate = projData.PromiseDeliveryDate,
                    FinalFile = projData.FinalFile,
                    ActualDeliveryDate = projData.ActualDeliveryDate,
                    Note = projData.Note,
                    IsActivated = true,
                    IsDeleted = false,
                    CreatedBy = projData.EditedBy,
                    CreatedDate = DateTime.Now,
                    EditedBy = projData.EditedBy,
                    EditedDate = DateTime.Now,
                    ProjectSerial=GetNewSerial()
                };
                dbContext.Projects.Add(newProject);
                if (projData.Paid > 0)
                {
                    Payment newPayment = new Payment()
                    {
                        PaymentID = Guid.NewGuid(),
                        Project = newProject,
                        Item = null,
                        PaymentDirection = true,
                        Paid = projData.Paid,
                        NextPaymentDate = projData.NextPaymentDate,
                        CreatedBy = projData.EditedBy,
                        CreatedDate = DateTime.Now
                    };
                    dbContext.Payments.Add(newPayment);
                }
                dbContext.SaveChanges();
                return newProject.ProjectID;
            }
            catch (Exception ex)
            {
                Global.Log.Error("ProjectDAL.Create", ex);
                return Guid.Empty;
            }
        }

        // Update existing project
        public bool UpdateProject(ProjectDetailsDTO projData)
        {
            try
            {
                Project project = dbContext.Projects.Find(projData.ProjectID);

                project.CustomerID = projData.CustomerID;
                project.ProjectTitle = projData.ProjectTitle;
                if (project.ProjectTasks.Where(i => i.isReviewerDone != null).Count() == project.ProjectTasks.Count() && project.ProjectTasks.Count() > 0)
                {
                    project.ProjectStatus = ProjectStatus.Completed.ToString();
                }
                else if (project.ProjectTasks.Where(i => i.isTranslatorProgress != null).Count() > 0)
                {
                    project.ProjectStatus = ProjectStatus.UnderProgress.ToString();
                }
                else
                {
                    project.ProjectStatus = ProjectStatus.New.ToString();
                }
                project.CustomerRequestDate = projData.CustomerRequestDate;
                project.CustomerFile = projData.CustomerFile;
                project.SourceLangg = projData.SourceLangg;
                project.TargetLangg = projData.TargetLangg;
                project.WordCount = projData.WordCount;
                project.WordPrice = projData.WordPrice;
                project.VatValue = projData.VatValue;
                project.DiscountValue = projData.DiscountValue;
                project.isOfferSentToCustomer = projData.isOfferSentToCustomer;
                project.isCustomerApproved = projData.isCustomerApproved;
                project.PromiseDeliveryDate = projData.PromiseDeliveryDate;
                project.FinalFile = projData.FinalFile;
                project.ActualDeliveryDate = projData.ActualDeliveryDate;
                project.Note = projData.Note;
                project.EditedBy = projData.EditedBy;
                project.EditedDate = DateTime.Now;

                dbContext.Entry(project).State = System.Data.Entity.EntityState.Modified;
                if (projData.Paid > 0)
                {
                    Payment newPayment = new Payment()
                    {
                        PaymentID = Guid.NewGuid(),
                        Project = project,
                        Item = null,
                        PaymentDirection = true,
                        Paid = projData.Paid,
                        NextPaymentDate = projData.NextPaymentDate,
                        CreatedBy = projData.EditedBy,
                        CreatedDate = DateTime.Now
                    };
                    dbContext.Payments.Add(newPayment);
                }
                else
                {
                    Payment lastPayment = dbContext.Payments.OrderByDescending(p => p.CreatedDate).FirstOrDefault();
                    lastPayment.NextPaymentDate = projData.NextPaymentDate;
                    dbContext.Entry(lastPayment).State = System.Data.Entity.EntityState.Modified;
                }
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                return false;
            }
        }

        // Cancel project
        public bool CancelProject(Guid projectID)
        {
            try
            {
                Project project = dbContext.Projects.Find(projectID);
                project.ProjectStatus = ProjectStatus.ProjectCanceled.ToString();
                project.IsActivated = false;
                dbContext.Entry(project).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                return false;
            }
        }

        // Activate project
        public bool ActivateProject(Guid projectID)
        {
            try
            {
                Project project = dbContext.Projects.Find(projectID);
                project.IsActivated = true;
                if (project.ProjectTasks.Where(i => i.isReviewerDone != null).Count() == project.ProjectTasks.Count() && project.ProjectTasks.Count() > 0)
                {
                    project.ProjectStatus = ProjectStatus.Completed.ToString();
                }
                else if (project.ProjectTasks.Where(i => i.isTranslatorProgress != null).Count() > 0)
                {
                    project.ProjectStatus = ProjectStatus.UnderProgress.ToString();
                }
                else
                {
                    project.ProjectStatus = ProjectStatus.New.ToString();
                }
                dbContext.Entry(project).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                return false;
            }
        }

        // Get last serial of project
        public int GetNewSerial()
        {
            int? lastSerial = dbContext.Projects.OrderByDescending(p => p.ProjectSerial).Select(s => s.ProjectSerial).FirstOrDefault();
            if (lastSerial == null || lastSerial==0)
            { lastSerial = 999; }
            return (int)(lastSerial + 1);
        }

        // Get Projects delivery soon for Admin or Project Manager
        public IEnumerable<ProjectsListDTO> GetProjectsSoon()
        {
            var projectsList = new List<ProjectsListDTO>();
            try
            {
                Guid? employeeID = LoggedUser.User.EmployeeID;
                int roleID = LoggedUser.User.Employee.RoleID;
                switch (roleID)
                {
                    case 1:
                    case 2:
                        projectsList = (from projects in dbContext.Projects
                                        where projects.IsDeleted == false && LoggedUser.User.AlertProject >= SqlFunctions.DateDiff("day", DateTime.Now, projects.PromiseDeliveryDate)
                                        orderby projects.CreatedDate descending
                                        select new ProjectsListDTO
                                        {
                                            ProjectID = projects.ProjectID,
                                            ProjectSerial = projects.ProjectSerial.ToString(),
                                            CustomerName = projects.Customer.CustomerName,
                                            ProjectManager = projects.Employee.FullName,
                                            ProjectTitle = projects.ProjectTitle,
                                            CurrentStatus = projects.ProjectStatus,
                                            PromiseDeliveryDate = projects.PromiseDeliveryDate,
                                            CustomerRequestDate = projects.CustomerRequestDate,
                                            LanggFromTo = projects.SourceLangg + " >> " + projects.TargetLangg,
                                            TotalCost = (projects.WordCount * projects.WordPrice) + projects.VatValue - projects.DiscountValue,
                                            CreatedDate = SqlFunctions.DatePart("year", projects.CreatedDate) + "/" + SqlFunctions.DatePart("month", projects.CreatedDate) + "/" + SqlFunctions.DatePart("day", projects.CreatedDate),
                                            CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                            LastEditedDate = SqlFunctions.DatePart("year", projects.EditedDate) + "/" + SqlFunctions.DatePart("month", projects.EditedDate) + "/" + SqlFunctions.DatePart("day", projects.EditedDate),
                                            LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                        }).ToList();
                        return projectsList;
                    case 3:
                        projectsList = (from projects in dbContext.Projects
                                        where projects.ManagerID == employeeID && projects.IsDeleted == false && LoggedUser.User.AlertProject >= SqlFunctions.DateDiff("day", DateTime.Now, projects.PromiseDeliveryDate)
                                        orderby projects.CreatedDate descending
                                        select new ProjectsListDTO
                                        {
                                            ProjectID = projects.ProjectID,
                                            ProjectSerial = projects.ProjectSerial.ToString(),
                                            CustomerName = projects.Customer.CustomerName,
                                            ProjectManager = projects.Employee.FullName,
                                            ProjectTitle = projects.ProjectTitle,
                                            CurrentStatus = projects.ProjectStatus,
                                            PromiseDeliveryDate = projects.PromiseDeliveryDate,
                                            CustomerRequestDate = projects.CustomerRequestDate,
                                            LanggFromTo = projects.SourceLangg + " >> " + projects.TargetLangg,
                                            TotalCost = (projects.WordCount * projects.WordPrice) + projects.VatValue - projects.DiscountValue,
                                            CreatedDate = SqlFunctions.DatePart("year", projects.CreatedDate) + "/" + SqlFunctions.DatePart("month", projects.CreatedDate) + "/" + SqlFunctions.DatePart("day", projects.CreatedDate),
                                            CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                            LastEditedDate = SqlFunctions.DatePart("year", projects.EditedDate) + "/" + SqlFunctions.DatePart("month", projects.EditedDate) + "/" + SqlFunctions.DatePart("day", projects.EditedDate),
                                            LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                        }).ToList();
                        return projectsList;
                    default:
                        return projectsList;
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                return projectsList;
            }
        }

        // Get pending Projects for Admin or Project Manager
        public IEnumerable<ProjectsListDTO> GetProjectsPending()
        {
            var projectsList = new List<ProjectsListDTO>();
            try
            {
                Guid? employeeID = LoggedUser.User.EmployeeID;
                int roleID = LoggedUser.User.Employee.RoleID;
                switch (roleID)
                {
                    case 1:
                    case 2:
                        projectsList = (from projects in dbContext.Projects
                                        where projects.IsDeleted == false && projects.CustomerRequestDate!=null && projects.isCustomerApproved == null
                                        orderby projects.CreatedDate descending
                                        select new ProjectsListDTO
                                        {
                                            ProjectID = projects.ProjectID,
                                            ProjectSerial = projects.ProjectSerial.ToString(),
                                            CustomerName = projects.Customer.CustomerName,
                                            ProjectManager = projects.Employee.FullName,
                                            ProjectTitle = projects.ProjectTitle,
                                            CurrentStatus = projects.ProjectStatus,
                                            PromiseDeliveryDate = projects.PromiseDeliveryDate,
                                            CustomerRequestDate = projects.CustomerRequestDate,
                                            LanggFromTo = projects.SourceLangg + " >> " + projects.TargetLangg,
                                            TotalCost = (projects.WordCount * projects.WordPrice) + projects.VatValue - projects.DiscountValue,
                                            CreatedDate = SqlFunctions.DatePart("year", projects.CreatedDate) + "/" + SqlFunctions.DatePart("month", projects.CreatedDate) + "/" + SqlFunctions.DatePart("day", projects.CreatedDate),
                                            CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                            LastEditedDate = SqlFunctions.DatePart("year", projects.EditedDate) + "/" + SqlFunctions.DatePart("month", projects.EditedDate) + "/" + SqlFunctions.DatePart("day", projects.EditedDate),
                                            LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                        }).ToList();
                        return projectsList;
                    case 3:
                        projectsList = (from projects in dbContext.Projects
                                        where projects.IsDeleted == false && projects.CustomerRequestDate != null && projects.isCustomerApproved == null && projects.ManagerID == employeeID
                                        orderby projects.CreatedDate descending
                                        select new ProjectsListDTO
                                        {
                                            ProjectID = projects.ProjectID,
                                            ProjectSerial = projects.ProjectSerial.ToString(),
                                            CustomerName = projects.Customer.CustomerName,
                                            ProjectManager = projects.Employee.FullName,
                                            ProjectTitle = projects.ProjectTitle,
                                            CurrentStatus = projects.ProjectStatus,
                                            PromiseDeliveryDate = projects.PromiseDeliveryDate,
                                            CustomerRequestDate = projects.CustomerRequestDate,
                                            LanggFromTo = projects.SourceLangg + " >> " + projects.TargetLangg,
                                            TotalCost = (projects.WordCount * projects.WordPrice) + projects.VatValue - projects.DiscountValue,
                                            CreatedDate = SqlFunctions.DatePart("year", projects.CreatedDate) + "/" + SqlFunctions.DatePart("month", projects.CreatedDate) + "/" + SqlFunctions.DatePart("day", projects.CreatedDate),
                                            CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                            LastEditedDate = SqlFunctions.DatePart("year", projects.EditedDate) + "/" + SqlFunctions.DatePart("month", projects.EditedDate) + "/" + SqlFunctions.DatePart("day", projects.EditedDate),
                                            LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                        }).ToList();
                        return projectsList;
                    default:
                        return projectsList;
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                return projectsList;
            }
        }

        // Get Projects in progress for Admin or Project Manager
        public IEnumerable<ProjectsListDTO> GetProjectsInProgress()
        {
            var projectsList = new List<ProjectsListDTO>();
            try
            {
                Guid? employeeID = LoggedUser.User.EmployeeID;
                int roleID = LoggedUser.User.Employee.RoleID;
                switch (roleID)
                {
                    case 1:
                    case 2:
                        projectsList = (from projects in dbContext.Projects
                                        where projects.IsDeleted == false
                                        && projects.isCustomerApproved != null
                                        && projects.ProjectTasks.Where(i => i.isReviewerDone != null).Count() < projects.ProjectTasks.Count() && projects.ProjectTasks.Count() > 0
                                        orderby projects.CreatedDate descending
                                        select new ProjectsListDTO
                                        {
                                            ProjectID = projects.ProjectID,
                                            CustomerID = projects.CustomerID,
                                            ManagerID = projects.ManagerID,
                                            ProjectSerial = projects.ProjectSerial.ToString(),
                                            CustomerName = projects.Customer.CustomerName,
                                            ProjectManager = projects.Employee.FullName,
                                            ProjectTitle = projects.ProjectTitle,
                                            CurrentStatus = projects.ProjectStatus,
                                            PromiseDeliveryDate = projects.PromiseDeliveryDate,
                                            CustomerRequestDate = projects.CustomerRequestDate,
                                            LanggFromTo = projects.SourceLangg + " >> " + projects.TargetLangg,
                                            TotalCost = (projects.WordCount * projects.WordPrice) + projects.VatValue - projects.DiscountValue,
                                            CreatedDate = SqlFunctions.DatePart("year", projects.CreatedDate) + "/" + SqlFunctions.DatePart("month", projects.CreatedDate) + "/" + SqlFunctions.DatePart("day", projects.CreatedDate),
                                            CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                            LastEditedDate = SqlFunctions.DatePart("year", projects.EditedDate) + "/" + SqlFunctions.DatePart("month", projects.EditedDate) + "/" + SqlFunctions.DatePart("day", projects.EditedDate),
                                            LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                        }).ToList();
                        return projectsList;
                    case 3:
                        projectsList = (from projects in dbContext.Projects
                                        where projects.IsDeleted == false
                                        && projects.ManagerID == employeeID
                                        && projects.isCustomerApproved != null
                                        && projects.ProjectTasks.Where(i => i.isReviewerDone != null).Count() < projects.ProjectTasks.Count() && projects.ProjectTasks.Count() > 0
                                        orderby projects.CreatedDate descending
                                        select new ProjectsListDTO
                                        {
                                            ProjectID = projects.ProjectID,
                                            CustomerID = projects.CustomerID,
                                            ManagerID = projects.ManagerID,
                                            ProjectSerial = projects.ProjectSerial.ToString(),
                                            CustomerName = projects.Customer.CustomerName,
                                            ProjectManager = projects.Employee.FullName,
                                            ProjectTitle = projects.ProjectTitle,
                                            CurrentStatus = projects.ProjectStatus,
                                            PromiseDeliveryDate = projects.PromiseDeliveryDate,
                                            CustomerRequestDate = projects.CustomerRequestDate,
                                            LanggFromTo = projects.SourceLangg + " >> " + projects.TargetLangg,
                                            TotalCost = (projects.WordCount * projects.WordPrice) + projects.VatValue - projects.DiscountValue,
                                            CreatedDate = SqlFunctions.DatePart("year", projects.CreatedDate) + "/" + SqlFunctions.DatePart("month", projects.CreatedDate) + "/" + SqlFunctions.DatePart("day", projects.CreatedDate),
                                            CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                            LastEditedDate = SqlFunctions.DatePart("year", projects.EditedDate) + "/" + SqlFunctions.DatePart("month", projects.EditedDate) + "/" + SqlFunctions.DatePart("day", projects.EditedDate),
                                            LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                        }).ToList();
                        return projectsList;
                    default:
                        return projectsList;
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                return projectsList;
            }
        }
        
        // Get Projects in progress for Admin or Project Manager
        public IEnumerable<ProjectsListDTO> GetProjectsDone()
        {
            var projectsList = new List<ProjectsListDTO>();
            try
            {
                Guid? employeeID = LoggedUser.User.EmployeeID;
                int roleID = LoggedUser.User.Employee.RoleID;
                switch (roleID)
                {
                    case 1:
                    case 2:
                        projectsList = (from projects in dbContext.Projects
                                        where projects.IsDeleted == false
                                        && projects.isCustomerApproved != null
                                        && projects.ProjectTasks.Where(i => i.isReviewerDone != null).Count() == projects.ProjectTasks.Count() && projects.ProjectTasks.Count()>0
                                        orderby projects.CreatedDate descending
                                        select new ProjectsListDTO
                                        {
                                            ProjectID = projects.ProjectID,
                                            CustomerID = projects.CustomerID,
                                            ManagerID = projects.ManagerID,
                                            ProjectSerial = projects.ProjectSerial.ToString(),
                                            CustomerName = projects.Customer.CustomerName,
                                            ProjectManager = projects.Employee.FullName,
                                            ProjectTitle = projects.ProjectTitle,
                                            CurrentStatus = projects.ProjectStatus,
                                            PromiseDeliveryDate = projects.PromiseDeliveryDate,
                                            CustomerRequestDate = projects.CustomerRequestDate,
                                            LanggFromTo = projects.SourceLangg + " >> " + projects.TargetLangg,
                                            TotalCost = (projects.WordCount * projects.WordPrice) + projects.VatValue - projects.DiscountValue,
                                            CreatedDate = SqlFunctions.DatePart("year", projects.CreatedDate) + "/" + SqlFunctions.DatePart("month", projects.CreatedDate) + "/" + SqlFunctions.DatePart("day", projects.CreatedDate),
                                            CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                            LastEditedDate = SqlFunctions.DatePart("year", projects.EditedDate) + "/" + SqlFunctions.DatePart("month", projects.EditedDate) + "/" + SqlFunctions.DatePart("day", projects.EditedDate),
                                            LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                        }).ToList();
                        return projectsList;
                    case 3:
                        projectsList = (from projects in dbContext.Projects
                                        where projects.IsDeleted == false
                                        && projects.ManagerID == employeeID
                                        && projects.isCustomerApproved != null
                                        && projects.ProjectTasks.Where(i => i.isReviewerDone != null).Count() == projects.ProjectTasks.Count() && projects.ProjectTasks.Count() > 0
                                        orderby projects.CreatedDate descending
                                        select new ProjectsListDTO
                                        {
                                            ProjectID = projects.ProjectID,
                                            CustomerID = projects.CustomerID,
                                            ManagerID = projects.ManagerID,
                                            ProjectSerial = projects.ProjectSerial.ToString(),
                                            CustomerName = projects.Customer.CustomerName,
                                            ProjectManager = projects.Employee.FullName,
                                            ProjectTitle = projects.ProjectTitle,
                                            CurrentStatus = projects.ProjectStatus,
                                            PromiseDeliveryDate = projects.PromiseDeliveryDate,
                                            CustomerRequestDate = projects.CustomerRequestDate,
                                            LanggFromTo = projects.SourceLangg + " >> " + projects.TargetLangg,
                                            TotalCost = (projects.WordCount * projects.WordPrice) + projects.VatValue - projects.DiscountValue,
                                            CreatedDate = SqlFunctions.DatePart("year", projects.CreatedDate) + "/" + SqlFunctions.DatePart("month", projects.CreatedDate) + "/" + SqlFunctions.DatePart("day", projects.CreatedDate),
                                            CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                            LastEditedDate = SqlFunctions.DatePart("year", projects.EditedDate) + "/" + SqlFunctions.DatePart("month", projects.EditedDate) + "/" + SqlFunctions.DatePart("day", projects.EditedDate),
                                            LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == projects.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                        }).ToList();
                        return projectsList;
                    default:
                        return projectsList;
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                return projectsList;
            }
        }
    }
}