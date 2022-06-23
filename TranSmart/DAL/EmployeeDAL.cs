using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using TranSmart.DTO;
using TranSmart.Models;

namespace TranSmart.DAL
{
    public class EmployeeDAL
    {
        // Get Object from Class
        private static EmployeeDAL instance;
        private static object mutex = new object();
        public static EmployeeDAL GetInstance()
        {
            lock (mutex)
            {
                if (instance == null)
                {
                    instance = new EmployeeDAL();
                }
                return instance;
            }
        }

        TranSmartDBContext dbContext = null;
        public EmployeeDAL()
        {
            dbContext = new TranSmartDBContext();
        }

        // Create new employee
        public Guid CreateEmployee(EmployeeDTO employeeData)
        {
            try
            {
                Employee newEmloyee = new Employee()
                {
                    EmployeeID = Guid.NewGuid(),
                    FullName = employeeData.FullName,
                    RoleID = employeeData.RoleID,
                    JobStartDate = employeeData.JobStartDate,
                    WorkMethodID = employeeData.WorkMethodID,
                    Languages = employeeData.Languages,
                    WordPrice = employeeData.WordPrice,
                    BasicSalary = employeeData.BasicSalary,
                    Commission = employeeData.Commission,
                    Email = employeeData.Email,
                    Phone = employeeData.Phone,
                    Address = employeeData.Address,
                    Note = employeeData.Note,
                    IsActivated = true,
                    IsDeleted = false,
                    CreatedBy = employeeData.EditedBy,
                    CreatedDate = DateTime.Now,
                    EditedBy = employeeData.EditedBy,
                    EditedDate = DateTime.Now
                };
                dbContext.Employees.Add(newEmloyee);
                dbContext.SaveChanges();
                return newEmloyee.EmployeeID;
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }

        // Update existing employee
        public EmployeeUpdateStatus UpdateEmployee(EmployeeDTO employeeData)
        {
            try
            {
                if (dbContext.Employees.Where(e => e.FullName.Trim() == employeeData.FullName.Trim()
                && e.EmployeeID != employeeData.EmployeeID).Count() > 0)
                {
                    return EmployeeUpdateStatus.EmployeeNameExists;
                }
                else
                {
                    Employee employee = dbContext.Employees.Find(employeeData.EmployeeID);

                    employee.FullName = employeeData.FullName;
                    employee.RoleID = employeeData.RoleID;
                    employee.JobStartDate = employeeData.JobStartDate;
                    employee.WorkMethodID = employeeData.WorkMethodID;
                    employee.Languages = employeeData.Languages;
                    employee.WordPrice = employeeData.WordPrice;
                    employee.BasicSalary = employeeData.BasicSalary;
                    employee.Commission = employeeData.Commission;
                    employee.Email = employeeData.Email;
                    employee.Phone = employeeData.Phone;
                    employee.Address = employeeData.Address;
                    employee.Note = employeeData.Note;
                    employee.EditedBy = employeeData.EditedBy;
                    employee.EditedDate = DateTime.Now;

                    dbContext.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                    return EmployeeUpdateStatus.Success;
                }
            }
            catch (Exception)
            {

                return EmployeeUpdateStatus.Error;
            }
        }

        // Delete employee
        public bool DeleteEmployee(Guid employeeID, Guid EditedBy)
        {
            try
            {
                Employee employee = dbContext.Employees.Find(employeeID);
                employee.IsDeleted = true;
                employee.Users.FirstOrDefault().IsDeleted = true;
                employee.EditedBy = EditedBy;
                employee.EditedDate = DateTime.Now;

                dbContext.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Activate/Deactivate employee
        public bool ChangeEmployeeActivation(Guid employeeID, bool isActive, Guid EditedBy)
        {
            try
            {
                Employee employee = dbContext.Employees.Find(employeeID);
                employee.IsActivated = isActive;
                employee.Users.FirstOrDefault().IsActivated = isActive;
                employee.EditedBy = EditedBy;
                employee.EditedDate = DateTime.Now;

                dbContext.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Get all employees
        public IEnumerable<EmployeeListDTO> GetAllEmployees()
        {
            try
            {
                var employesList = (from employees in dbContext.Employees
                                    where employees.IsDeleted == false
                                    select new EmployeeListDTO
                                    {
                                        EmployeeID = employees.EmployeeID,
                                        FullName = employees.FullName,
                                        isHasLogin = (employees.Users.Where(u => u.IsDeleted == false && u.IsActivated == true).Count() > 0 ? true : false),
                                        StrHasLogin = (employees.Users.Where(u => u.IsDeleted == false && u.IsActivated == true).Count() > 0 ? "login" : "logoutred")

                                        //StrHasLogin = (employees.Users.Where(u => u.IsDeleted == false).Count() > 0 ?
                                        //"<img src='Content/Images/login.png' width='20' height='20' border='0' alt='login' title='login' />" :
                                        //"<img src='Content/Images/logoutred.png' width='20' height='20' border='0' alt='login' title='login' />")

                                        //Role = employees.ValEmployeeRole.RoleText,
                                        //JobStartDate = employees.JobStartDate,
                                        //WorkMethod = employees.ValEmployeeWorkMethod.WorkMethodText,
                                        //Languages = employees.Languages,
                                        //WordPrice = employees.WordPrice,
                                        //BasicSalary = employees.BasicSalary,
                                        //Commission = employees.Commission,
                                        //Email = employees.Email,
                                        //Phone = employees.Phone,
                                        //IsActivated = employees.IsActivated,
                                    }).ToList();
                return employesList;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        // Get Employees list by Role
        public IEnumerable<EmployeeListDTO> GetEmployeesByRole(int roleID)
        {
            try
            {
                var employesList = (from employees in dbContext.Employees
                                    where employees.IsDeleted == false && employees.RoleID == roleID
                                    select new EmployeeListDTO
                                    {
                                        EmployeeID = employees.EmployeeID,
                                        FullName = employees.FullName,
                                        //JobStartDate = employees.JobStartDate,
                                        //WorkMethod = employees.ValEmployeeWorkMethod.WorkMethodText,
                                        //Languages = employees.Languages,
                                        //WordPrice = employees.WordPrice,
                                        //BasicSalary = employees.BasicSalary,
                                        //Commission = employees.Commission,
                                        //Email = employees.Email,
                                        //Phone = employees.Phone,
                                        //IsActivated = employees.IsActivated,
                                    }).ToList();
                return employesList;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        // Get Translators list
        public IEnumerable<EmployeeListDTO> GetTranslatorsList()
        {
            try
            {
                var employesList = (from employees in dbContext.Employees
                                    where employees.IsDeleted == false && employees.RoleID == 5
                                    select new EmployeeListDTO
                                    {
                                        EmployeeID = employees.EmployeeID,
                                        FullName = employees.FullName
                                    }).ToList();
                return employesList;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        // Get Reviewers list
        public IEnumerable<EmployeeListDTO> GetReviewersList()
        {
            try
            {
                var employesList = (from employees in dbContext.Employees
                                    where employees.IsDeleted == false && employees.RoleID == 4
                                    select new EmployeeListDTO
                                    {
                                        EmployeeID = employees.EmployeeID,
                                        FullName = employees.FullName
                                    }).ToList();
                return employesList;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        // Get Employee details by EmployeeID
        public EmployeeDetailsDTO GetEmployeeDetailsByID(Guid employeeID)
        {
            try
            {
                EmployeeDetailsDTO selectedEmployee = (from employees in dbContext.Employees
                                                       where employees.EmployeeID == employeeID
                                                       select new EmployeeDetailsDTO
                                                       {
                                                           EmployeeID = employees.EmployeeID,
                                                           FullName = employees.FullName,
                                                           Role = employees.ValEmployeeRole.RoleID,
                                                           //JobStartDate = SqlFunctions.DatePart("year", employees.JobStartDate) + "/" + SqlFunctions.DatePart("month", employees.JobStartDate) + "/" + SqlFunctions.DatePart("day", employees.JobStartDate),
                                                           JobStartDate = employees.JobStartDate,
                                                           WorkMethod = employees.ValEmployeeWorkMethod.WorkMethodText,
                                                           Languages = employees.Languages,
                                                           WordPrice = employees.WordPrice,
                                                           BasicSalary = employees.BasicSalary,
                                                           Commission = employees.Commission,
                                                           Email = employees.Email,
                                                           Phone = employees.Phone,
                                                           Address = employees.Address,
                                                           Note = employees.Note,
                                                           IsActivated = employees.IsActivated,
                                                           CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == employees.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                                           CreatedDate = SqlFunctions.DatePart("year", employees.CreatedDate) + "/" + SqlFunctions.DatePart("month", employees.CreatedDate) + "/" + SqlFunctions.DatePart("day", employees.CreatedDate),
                                                           LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == employees.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                                           LastEditedDate = SqlFunctions.DatePart("year", employees.EditedDate) + "/" + SqlFunctions.DatePart("month", employees.EditedDate) + "/" + SqlFunctions.DatePart("day", employees.EditedDate)
                                                       }).FirstOrDefault();
                return selectedEmployee;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        // Get number projects of Projects Managers
        public IEnumerable<EmployeeListDTO> GetEmployeesProjectsCount(int roleID)
        {
            try
            {
                var EmployeesList = (from employees in dbContext.Employees
                                     where employees.IsDeleted == false && employees.RoleID == roleID
                                     select new EmployeeListDTO
                                     {
                                         EmployeeID = employees.EmployeeID,
                                         FullName = employees.FullName,
                                         Email = employees.Email,
                                         Phone = employees.Phone,
                                         JobStartDate = SqlFunctions.DatePart("year", employees.JobStartDate) + "/" + SqlFunctions.DatePart("month", employees.JobStartDate) + "/" + SqlFunctions.DatePart("day", employees.JobStartDate),
                                         ProjectsCount = (roleID==3? employees.Projects.Count():(roleID==4?employees.ProjectTasks.Count():employees.ProjectTasks1.Count()))
                                     }).ToList();
                return EmployeesList;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        // Get delays in Projects from managers
        public IEnumerable<EmployeeDelaysListDTO> GetProjectsDealys(int roleID)
        {
            try
            {
                switch (roleID)
                {
                    case 3: // project managers
                        var projectsDelays = (from projects in dbContext.Projects
                                              where projects.IsDeleted == false
                                              && projects.IsActivated == true
                                              && projects.Employee.IsDeleted == false
                                              && projects.ActualDeliveryDate != null
                                              && SqlFunctions.DateDiff("day", projects.PromiseDeliveryDate, projects.ActualDeliveryDate) > 0
                                              select new EmployeeDelaysListDTO
                                              {
                                                  ProjectID = projects.ProjectID,
                                                  ProjectSerial = projects.ProjectSerial.ToString(),
                                                  FullName = projects.Employee.FullName,
                                                  Email = projects.Employee.Email,
                                                  Phone = projects.Employee.Phone,
                                                  DeadLineDate = SqlFunctions.DatePart("year", projects.PromiseDeliveryDate) + "/" + SqlFunctions.DatePart("month", projects.PromiseDeliveryDate) + "/" + SqlFunctions.DatePart("day", projects.PromiseDeliveryDate),
                                                  ActualDeliveryDate = SqlFunctions.DatePart("year", projects.ActualDeliveryDate) + "/" + SqlFunctions.DatePart("month", projects.ActualDeliveryDate) + "/" + SqlFunctions.DatePart("day", projects.ActualDeliveryDate),
                                                  DelayedDays = (SqlFunctions.DateDiff("day", projects.PromiseDeliveryDate, projects.ActualDeliveryDate).ToString())
                                              }).ToList();
                        return projectsDelays;
                    case 4: // reviewers
                        var tasksDelays = (from tasks in dbContext.ProjectTasks
                                           where tasks.IsDeleted == false
                                           && tasks.IsActivated == true
                                           && tasks.Employee.IsDeleted == false
                                           && tasks.isReviewerDone != null
                                           && SqlFunctions.DateDiff("day", tasks.ReviewerDeadLine, tasks.isReviewerDone) > 0
                                           select new EmployeeDelaysListDTO
                                           {
                                               ProjectID = tasks.TaskID,
                                               ProjectSerial = tasks.TaskSerial + "-" + tasks.Project.ProjectSerial + "-" + tasks.Project.CreatedDate.Year.ToString(),
                                               FullName = tasks.Employee.FullName,
                                               Email = tasks.Employee.Email,
                                               Phone = tasks.Employee.Phone,
                                               DeadLineDate = SqlFunctions.DatePart("year", tasks.ReviewerDeadLine) + "/" + SqlFunctions.DatePart("month", tasks.ReviewerDeadLine) + "/" + SqlFunctions.DatePart("day", tasks.ReviewerDeadLine),
                                               ActualDeliveryDate = SqlFunctions.DatePart("year", tasks.isReviewerDone) + "/" + SqlFunctions.DatePart("month", tasks.isReviewerDone) + "/" + SqlFunctions.DatePart("day", tasks.isReviewerDone),
                                               DelayedDays = (SqlFunctions.DateDiff("day", tasks.ReviewerDeadLine, tasks.isReviewerDone).ToString())
                                           }).ToList();
                        return tasksDelays;
                    case 5: // Translators
                        var taskssDelays = (from tasks in dbContext.ProjectTasks
                                           where tasks.IsDeleted == false
                                           && tasks.IsActivated == true
                                           && tasks.Employee1.IsDeleted == false
                                           && tasks.isTranslatorDone != null
                                           && SqlFunctions.DateDiff("day", tasks.TranslatorDeadLine, tasks.isTranslatorDone) > 0
                                           select new EmployeeDelaysListDTO
                                           {
                                               ProjectID = tasks.TaskID,
                                               ProjectSerial = tasks.TaskSerial + "-" + tasks.Project.ProjectSerial + "-" + tasks.Project.CreatedDate.Year.ToString(),
                                               FullName = tasks.Employee1.FullName,
                                               Email = tasks.Employee1.Email,
                                               Phone = tasks.Employee1.Phone,
                                               DeadLineDate = SqlFunctions.DatePart("year", tasks.TranslatorDeadLine) + "/" + SqlFunctions.DatePart("month", tasks.TranslatorDeadLine) + "/" + SqlFunctions.DatePart("day", tasks.TranslatorDeadLine),
                                               ActualDeliveryDate = SqlFunctions.DatePart("year", tasks.isTranslatorDone) + "/" + SqlFunctions.DatePart("month", tasks.isTranslatorDone) + "/" + SqlFunctions.DatePart("day", tasks.isTranslatorDone),
                                               DelayedDays = (SqlFunctions.DateDiff("day", tasks.TranslatorDeadLine, tasks.isTranslatorDone).ToString())
                                           }).ToList();
                        return taskssDelays;
                    default:
                        return null;
                }                
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        // Get translators Invoices
        public IEnumerable<TranslatorsInvoicesDTO> GetTranslatorsInvoices()
        {
            try
            {
                var employesList = (from employees in dbContext.Employees
                                    where employees.IsDeleted == false && employees.RoleID == 5
                                    select new TranslatorsInvoicesDTO
                                    {
                                        EmployeeID = employees.EmployeeID,
                                        FullName = employees.FullName,
                                        TasksCount = employees.ProjectTasks1.Count(),
                                        TotalWordCount = employees.ProjectTasks1.Sum(w=>w.WordCount),
                                        WordPrice = employees.WordPrice,
                                        TotalTasksCost = employees.ProjectTasks1.Sum(w => w.WordCount) * employees.WordPrice,
                                        BasicSalary = employees.BasicSalary
                                    }).ToList();
                return employesList;
        }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        // Get translators Invoices
        public IEnumerable<TranslatorsInvoicesDTO> GetTranslatorsInvoices(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var employesList = (from employees in dbContext.Employees
                                    where employees.IsDeleted == false && employees.RoleID == 5
                                    select new TranslatorsInvoicesDTO
                                    {
                                        EmployeeID = employees.EmployeeID,
                                        FullName = employees.FullName,
                                        TasksCount = employees.ProjectTasks1.Where(t=>t.TranslatorDeadLine>= startDate&&t.TranslatorDeadLine<=endDate).Count(),
                                        TotalWordCount = employees.ProjectTasks1.Where(t => t.TranslatorDeadLine >= startDate && t.TranslatorDeadLine <= endDate).Sum(w => w.WordCount),
                                        WordPrice = employees.WordPrice,
                                        TotalTasksCost = employees.ProjectTasks1.Where(t => t.TranslatorDeadLine >= startDate && t.TranslatorDeadLine <= endDate).Sum(w => w.WordCount) * employees.WordPrice,
                                        BasicSalary = employees.BasicSalary
                                    }).ToList();
                return employesList;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        /***************** Employee System values *****************/
        // Get Employee Roles list
        public IEnumerable<ValEmployeeRole> GetRolesList()
        {
            try
            {
                return dbContext.ValEmployeeRoles.OrderBy(v => v.RoleID).ToList();
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        // Get Employee Work methods list
        public IEnumerable<ValEmployeeWorkMethod> GetWorkMethodsList()
        {
            try
            {
                return dbContext.ValEmployeeWorkMethods.OrderBy(v => v.WorkMethodID).ToList();
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        // Get Languges list
        public IEnumerable<ValLanguage> GetLanggList()
        {
            try
            {
                return dbContext.ValLanguages.OrderBy(v => v.LanguageID).ToList();
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

    }
}
