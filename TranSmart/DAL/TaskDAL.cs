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
    public class TaskDAL
    {
        // Get Object from Class
        private static TaskDAL instance;
        private static object mutex = new object();
        public static TaskDAL GetInstance()
        {
            lock (mutex)
            {
                if (instance == null)
                {
                    instance = new TaskDAL();
                }
                return instance;
            }
        }

        TranSmartDBContext dbContext = null;
        public TaskDAL()
        {
            dbContext = new TranSmartDBContext();
        }

        // Get All Tasks
        public IEnumerable<TaskListDTO> GetAllTasks()
        {
            var tasksList = new List<TaskListDTO>();
            int roleID = LoggedUser.User.Employee.RoleID;
            if (roleID == 3)
            {
                tasksList = (from tasks in dbContext.ProjectTasks
                             where tasks.IsDeleted == false && tasks.Project.ManagerID == LoggedUser.User.EmployeeID
                             orderby tasks.Project.ProjectSerial descending, tasks.TaskSerial descending
                             select new TaskListDTO
                             {
                                 ProjectID = tasks.Project.ProjectID,
                                 ProjectSerial = tasks.Project.ProjectSerial.ToString(),
                                 TaskID = tasks.TaskID,
                                 TaskSerial = tasks.TaskSerial.ToString(),
                                 TranslatorName = dbContext.Employees.Where(e => e.EmployeeID == tasks.TranslatorID).Select(e => e.FullName).FirstOrDefault(),
                                 ReviewerName = dbContext.Employees.Where(e => e.EmployeeID == tasks.ReviewerID).Select(e => e.FullName).FirstOrDefault(),
                                 TaskStatus = (tasks.isTranslatorProgress == null ? TaskStatus.New.ToString() : (tasks.isReviewerDone == null ? "Under Progress" : TaskStatus.Completed.ToString())),
                                 WordCount = tasks.WordCount,
                                 CreatedDate = SqlFunctions.DatePart("year", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("month", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("day", tasks.CreatedDate),
                                 CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                 LastEditedDate = SqlFunctions.DatePart("year", tasks.EditedDate) + "/" + SqlFunctions.DatePart("month", tasks.EditedDate) + "/" + SqlFunctions.DatePart("day", tasks.EditedDate),
                                 LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                             }).ToList();
                return tasksList;
            }
            else
            {
                tasksList = (from tasks in dbContext.ProjectTasks
                             where tasks.IsDeleted == false
                             orderby tasks.Project.ProjectSerial descending, tasks.TaskSerial descending
                             select new TaskListDTO
                             {
                                 ProjectID = tasks.Project.ProjectID,
                                 ProjectSerial = tasks.Project.ProjectSerial.ToString(),
                                 TaskID = tasks.TaskID,
                                 TaskSerial = tasks.TaskSerial.ToString(),
                                 TranslatorName = dbContext.Employees.Where(e => e.EmployeeID == tasks.TranslatorID).Select(e => e.FullName).FirstOrDefault(),
                                 ReviewerName = dbContext.Employees.Where(e => e.EmployeeID == tasks.ReviewerID).Select(e => e.FullName).FirstOrDefault(),
                                 TaskStatus = (tasks.isTranslatorProgress == null ? TaskStatus.New.ToString() : (tasks.isReviewerDone == null ? "Under Progress" : TaskStatus.Completed.ToString())),
                                 WordCount = tasks.WordCount,
                                 CreatedDate = SqlFunctions.DatePart("year", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("month", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("day", tasks.CreatedDate),
                                 CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                 LastEditedDate = SqlFunctions.DatePart("year", tasks.EditedDate) + "/" + SqlFunctions.DatePart("month", tasks.EditedDate) + "/" + SqlFunctions.DatePart("day", tasks.EditedDate),
                                 LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                             }).ToList();
                return tasksList;
            }
        }

        // Get tasks by project
        public IEnumerable<TaskListDTO> GetTasksByProject(Guid projectID)
        {
            var tasksList = (from tasks in dbContext.ProjectTasks
                             where tasks.ProjectID == projectID && tasks.IsDeleted == false
                             select new TaskListDTO
                             {
                                 ProjectID = tasks.Project.ProjectID,
                                 ProjectSerial = tasks.Project.ProjectSerial.ToString(),
                                 TaskID = tasks.TaskID,
                                 TaskSerial = tasks.TaskSerial.ToString(),
                                 TranslatorName = dbContext.Employees.Where(e => e.EmployeeID == tasks.TranslatorID).Select(e => e.FullName).FirstOrDefault(),
                                 ReviewerName = dbContext.Employees.Where(e => e.EmployeeID == tasks.ReviewerID).Select(e => e.FullName).FirstOrDefault(),
                                 TaskStatus = (tasks.isTranslatorProgress == null ? TaskStatus.New.ToString() : (tasks.isReviewerDone == null ? "Under Progress" : TaskStatus.Completed.ToString())),
                                 WordCount = tasks.WordCount,
                                 //TranslatorWordPrice = tasks.TranslatorWordPrice,
                                 //TranslatorCost = tasks.WordCount * tasks.TranslatorWordPrice,
                                 //TranslatorDeadLine = SqlFunctions.DatePart("year", tasks.TranslatorDeadLine) + "/" + SqlFunctions.DatePart("month", tasks.TranslatorDeadLine) + "/" + SqlFunctions.DatePart("day", tasks.TranslatorDeadLine) + " - " + SqlFunctions.DatePart("hour", tasks.TranslatorDeadLine) + ":" + SqlFunctions.DatePart("minute", tasks.TranslatorDeadLine),
                                 //TranslatorReceivedAt = (tasks.isTranslatorReceived == null ? null : SqlFunctions.DatePart("year", tasks.isTranslatorReceived) + "/" + SqlFunctions.DatePart("month", tasks.isTranslatorReceived) + "/" + SqlFunctions.DatePart("day", tasks.isTranslatorReceived) + " - " + SqlFunctions.DatePart("hour", tasks.isTranslatorReceived) + ":" + SqlFunctions.DatePart("minute", tasks.isTranslatorReceived)),
                                 //TranslatorStartAt = (tasks.isTranslatorProgress == null ? null : SqlFunctions.DatePart("year", tasks.isTranslatorProgress) + "/" + SqlFunctions.DatePart("month", tasks.isTranslatorProgress) + "/" + SqlFunctions.DatePart("day", tasks.isTranslatorProgress) + " - " + SqlFunctions.DatePart("hour", tasks.isTranslatorProgress) + ":" + SqlFunctions.DatePart("minute", tasks.isTranslatorProgress)),
                                 //TranslatorDoneAt = (tasks.isTranslatorDone == null ? null : SqlFunctions.DatePart("year", tasks.isTranslatorDone) + "/" + SqlFunctions.DatePart("month", tasks.isTranslatorDone) + "/" + SqlFunctions.DatePart("day", tasks.isTranslatorDone) + " - " + SqlFunctions.DatePart("hour", tasks.isTranslatorDone) + ":" + SqlFunctions.DatePart("minute", tasks.isTranslatorDone)),
                                 //TranslatorDelay = (tasks.isTranslatorDone != null && tasks.isTranslatorDone > tasks.TranslatorDeadLine ? SqlFunctions.DateDiff("day", tasks.TranslatorDeadLine, tasks.isTranslatorDone).ToString() + " Day " + SqlFunctions.DateDiff("hour", tasks.TranslatorDeadLine, tasks.isTranslatorDone).ToString() + " Hour" : "None"),
                                 //ReviewerReceivedAt = (tasks.isReviewerReceived == null ? null : SqlFunctions.DatePart("year", tasks.isReviewerReceived) + "/" + SqlFunctions.DatePart("month", tasks.isReviewerReceived) + "/" + SqlFunctions.DatePart("day", tasks.isReviewerReceived) + " - " + SqlFunctions.DatePart("hour", tasks.isReviewerReceived) + ":" + SqlFunctions.DatePart("minute", tasks.isReviewerReceived)),
                                 //ReviewerStartAt = (tasks.isReviewerProgress == null ? null : SqlFunctions.DatePart("year", tasks.isReviewerProgress) + "/" + SqlFunctions.DatePart("month", tasks.isReviewerProgress) + "/" + SqlFunctions.DatePart("day", tasks.isReviewerProgress) + " - " + SqlFunctions.DatePart("hour", tasks.isReviewerProgress) + ":" + SqlFunctions.DatePart("minute", tasks.isReviewerProgress)),
                                 //ReviewerDoneAt = (tasks.isReviewerDone == null ? null : SqlFunctions.DatePart("year", tasks.isReviewerDone) + "/" + SqlFunctions.DatePart("month", tasks.isReviewerDone) + "/" + SqlFunctions.DatePart("day", tasks.isReviewerDone) + " - " + SqlFunctions.DatePart("hour", tasks.isReviewerDone) + ":" + SqlFunctions.DatePart("minute", tasks.isReviewerDone)),
                                 CreatedDate = SqlFunctions.DatePart("year", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("month", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("day", tasks.CreatedDate),
                                 CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                 LastEditedDate = SqlFunctions.DatePart("year", tasks.EditedDate) + "/" + SqlFunctions.DatePart("month", tasks.EditedDate) + "/" + SqlFunctions.DatePart("day", tasks.EditedDate),
                                 LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                 //TaskFile = tasks.TaskFile,
                                 //TranslatorFile = tasks.TranslatorFile,
                                 //ReviewerFile = tasks.ReviewerFile
                             }).ToList();
            return tasksList;
        }

        // Get task details by taskID
        public TaskDetailsDTO GetTaskDetailsByID(Guid taskID)
        {
            try
            {
                TaskDetailsDTO task = dbContext.ProjectTasks.Where(p => p.TaskID == taskID)
                    .Select(tasks => new TaskDetailsDTO
                    {
                        TaskID = tasks.TaskID,
                        ProjectID = tasks.ProjectID,
                        TaskSerial = tasks.TaskSerial.ToString(),
                        ProjectWords = tasks.Project.WordCount,
                        TasksWords = tasks.Project.ProjectTasks.Sum(t => t.WordCount) - tasks.WordCount,
                        WordCount = tasks.WordCount,
                        TaskDescription = tasks.TaskDescription,
                        TranslatorID = tasks.Employee1.EmployeeID,
                        ReviewerID = tasks.Employee.EmployeeID,
                        ProjectManager = tasks.Project.Employee.FullName,
                        TaskStatus = (tasks.isTranslatorProgress==null?TaskStatus.New.ToString():(tasks.isReviewerDone==null?TaskStatus.UnderProgress.ToString():TaskStatus.Completed.ToString())),
                        TranslatorDeadLine = tasks.TranslatorDeadLine,
                        isTranslatorReceived = tasks.isTranslatorReceived,
                        isTranslatorProgress = tasks.isTranslatorProgress,
                        isTranslatorDone = tasks.isTranslatorDone,
                        ReviewerDeadLine = tasks.ReviewerDeadLine,
                        isReviewerReceived = tasks.isReviewerReceived,
                        isReviewerProgress = tasks.isReviewerProgress,
                        isReviewerDone = tasks.isReviewerDone,
                        ProjectPromiseDeliveryDate = tasks.Project.PromiseDeliveryDate,
                        TaskFile = tasks.TaskFile,
                        TranslatorFile = tasks.TranslatorFile,
                        ReviewerFile = tasks.ReviewerFile,
                        TranslatorQuality = tasks.TranslatorQuality,
                        SourceLangg = tasks.Project.SourceLangg,
                        TargetLangg = tasks.Project.TargetLangg,
                        isMailSentToTranslator = tasks.isMailSentToTranslator,
                        isMailSentToReviewer = tasks.isMailSentToReviewer
                    }).FirstOrDefault();
                return task;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                return null;
            }
        }

        // Get task details by projectID
        public NewTaskDetailsDTO GetNewTaskDetailsByID(Guid projectID)
        {
            try
            {
                NewTaskDetailsDTO newTaskDetails = (from projects in dbContext.Projects
                                                where projects.ProjectID == projectID
                                                select new NewTaskDetailsDTO
                                                {
                                                    TaskSerial = projects.ProjectSerial + "-" + (projects.ProjectTasks.Count() == 0 ? 1 : (projects.ProjectTasks.OrderByDescending(p => p.TaskSerial).Select(s => s.TaskSerial).FirstOrDefault()) + 1) + "-" + projects.CreatedDate.Year.ToString(),
                                                    ProjectWords = projects.WordCount,
                                                    TasksWords = ( projects.ProjectTasks.Count() == 0 ?0:projects.ProjectTasks.Sum(t => t.WordCount)),
                                                    ProjectPromiseDeliveryDate = projects.PromiseDeliveryDate,
                                                }).FirstOrDefault();
            return newTaskDetails;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                return null;
            }
        }

        // Create new task
        public Guid CreateTask(TaskDTO taskData)
        {
            try
            {
                ProjectTask newTask = new ProjectTask()
                {
                    TaskID = taskData.TaskID,
                    ProjectID = taskData.ProjectID,
                    TranslatorID = taskData.TranslatorID,
                    ReviewerID = taskData.ReviewerID,
                    TaskSerial = (dbContext.ProjectTasks.Where(p => p.ProjectID == taskData.ProjectID).Count() == 0 ? 1 : (dbContext.ProjectTasks.Where(p => p.ProjectID == taskData.ProjectID).OrderByDescending(p => p.TaskSerial).Select(s => s.TaskSerial).FirstOrDefault()) + 1),
                    TaskStatus = TaskStatus.New.ToString(),
                    TaskFile = taskData.TaskFile,
                    TaskDescription = taskData.TaskDescription,
                    WordCount = taskData.WordCount,
                    TranslatorWordPrice = (int)dbContext.Employees.Where(e => e.EmployeeID == taskData.TranslatorID).Select(w => w.WordPrice).FirstOrDefault(),
                    ReviewerWordPrice = (int)dbContext.Employees.Where(e => e.EmployeeID == taskData.ReviewerID).Select(w => w.WordPrice).FirstOrDefault(),
                    TranslatorDeadLine = taskData.TranslatorDeadLine,
                    ReviewerDeadLine = taskData.ReviewerDeadLine,
                    isMailSentToTranslator = taskData.isMailSentToTranslator,
                    isMailSentToReviewer = taskData.isMailSentToReviewer,
                    IsActivated = true,
                    IsDeleted = false,
                    CreatedBy = LoggedUser.User_PK,
                    CreatedDate = DateTime.Now,
                    EditedBy = LoggedUser.User_PK,
                    EditedDate = DateTime.Now
                };
                dbContext.ProjectTasks.Add(newTask);
                dbContext.SaveChanges();
                return newTask.TaskID;
            }
            catch (Exception ex)
            {
                Global.Log.Error("TaskDAL.Create", ex);
                return Guid.Empty;
            }
        }

        // Update existing task for Admin , Project Manager , Translator or Reviewer
        public bool UpdateTask(TaskDetailsDTO taskData)
        {
            try
            {
                ProjectTask task = dbContext.ProjectTasks.Find(taskData.TaskID);

                int roleID = LoggedUser.User.Employee.RoleID;
                switch (roleID)
                {
                    case 1:  // owner
                    case 2:  // admin                      
                    case 3:  // project manager
                        task.TranslatorID = taskData.TranslatorID.Value;
                        task.ReviewerID = taskData.ReviewerID.Value;
                        if (task.isReviewerDone != null)
                        {
                            task.TaskStatus = TaskStatus.Completed.ToString();
                        }
                        else if (task.isTranslatorProgress != null)
                        {
                            task.TaskStatus = TaskStatus.UnderProgress.ToString();
                        }
                        else
                        {
                            task.TaskStatus = TaskStatus.New.ToString();
                        }
                        task.TaskFile = taskData.TaskFile;
                        task.TaskDescription = taskData.TaskDescription;
                        task.WordCount = taskData.WordCount.Value;
                        task.TranslatorDeadLine = taskData.TranslatorDeadLine.Value;
                        task.ReviewerDeadLine = taskData.ReviewerDeadLine;
                        task.isMailSentToTranslator = taskData.isMailSentToTranslator;
                        if (task.Project.ProjectTasks.Where(i => i.isReviewerDone != null).Count() == task.Project.ProjectTasks.Count() && task.Project.ProjectTasks.Count() > 0)
                        {
                            task.Project.ProjectStatus = ProjectStatus.Completed.ToString();
                        }
                        else if (task.Project.ProjectTasks.Where(i => i.isTranslatorProgress != null).Count() > 0)
                        {
                            task.Project.ProjectStatus = ProjectStatus.UnderProgress.ToString();
                        }
                        else
                        {
                            task.Project.ProjectStatus = ProjectStatus.New.ToString();
                        }
                        break;
                    case 4: // reviewer
                        task.isReviewerReceived = taskData.isReviewerReceived;
                        task.isReviewerProgress = taskData.isReviewerProgress;
                        task.isReviewerDone = taskData.isReviewerDone;
                        task.ReviewerFile = taskData.ReviewerFile;
                        task.TranslatorQuality = taskData.TranslatorQuality;
                        task.ReviewerDelay = taskData.ReviewerDelay;
                        if (task.Project.ProjectTasks.Where(i => i.isReviewerDone != null).Count() == task.Project.ProjectTasks.Count() && task.Project.ProjectTasks.Count() > 0)
                        {
                            task.Project.ProjectStatus = ProjectStatus.Completed.ToString();
                        }
                        else if (task.Project.ProjectTasks.Where(i => i.isTranslatorProgress != null).Count() > 0)
                        {
                            task.Project.ProjectStatus = ProjectStatus.UnderProgress.ToString();
                        }
                        else
                        {
                            task.Project.ProjectStatus = ProjectStatus.New.ToString();
                        }
                        break;
                    case 5: // translator
                        task.isTranslatorReceived = taskData.isTranslatorReceived;
                        task.isTranslatorProgress = taskData.isTranslatorProgress;
                        task.isTranslatorDone = taskData.isTranslatorDone;
                        task.TranslatorFile = taskData.TranslatorFile;
                        task.TranslatorDelay = taskData.TranslatorDelay;
                        if (task.Project.ProjectTasks.Where(i => i.isReviewerDone != null).Count() == task.Project.ProjectTasks.Count() && task.Project.ProjectTasks.Count() > 0)
                        {
                            task.Project.ProjectStatus = ProjectStatus.Completed.ToString();
                        }
                        else if (task.Project.ProjectTasks.Where(i => i.isTranslatorProgress != null).Count() > 0)
                        {
                            task.Project.ProjectStatus = ProjectStatus.UnderProgress.ToString();
                        }
                        else
                        {
                            task.Project.ProjectStatus = ProjectStatus.New.ToString();
                        }
                        break;
                }

                
                task.EditedBy = LoggedUser.User_PK;
                task.EditedDate = DateTime.Now;

                dbContext.Entry(task).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                return false;
            }
        }

        // Cancel task
        public bool CancelTask(Guid taskID)
        {
            try
            {
                ProjectTask task = dbContext.ProjectTasks.Find(taskID);
                task.TaskStatus =TaskStatus.Canceled.ToString();
                task.IsActivated = false;
                dbContext.Entry(task).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                return false;
            }
        }

        // Activate task
        public bool ActivateTask(Guid taskID)
        {
            try
            {
                ProjectTask task = dbContext.ProjectTasks.Find(taskID);                
                task.IsActivated = true;
                if (task.Project.ProjectTasks.Where(i => i.isReviewerDone != null).Count() == task.Project.ProjectTasks.Count() && task.Project.ProjectTasks.Count() > 0)
                {
                    task.Project.ProjectStatus = ProjectStatus.Completed.ToString();
                }
                else if (task.Project.ProjectTasks.Where(i => i.isTranslatorProgress != null).Count() > 0)
                {
                    task.Project.ProjectStatus = ProjectStatus.UnderProgress.ToString();
                }
                else
                {
                    task.Project.ProjectStatus = ProjectStatus.New.ToString();
                }
                dbContext.Entry(task).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                return false;
            }
        }

        // Get Tasks deadline soon for Admin , Project Manager , Translator or Reviewer
        public IEnumerable<TaskListDTO> GetTasksSoon()
        {
            try
            {
                var tasksList = new List<TaskListDTO>();
                Guid? employeeID = LoggedUser.User.EmployeeID;
                int roleID = LoggedUser.User.Employee.RoleID;
                switch (roleID)
                {
                    case 1: // owner
                    case 2: // admin
                        tasksList = (from tasks in dbContext.ProjectTasks
                                     where tasks.IsDeleted == false && LoggedUser.User.AlertTask >= SqlFunctions.DateDiff("day", DateTime.Now, tasks.ReviewerDeadLine)
                                     select new TaskListDTO
                                     {
                                         TaskID = tasks.TaskID,
                                         TaskSerial = tasks.TaskSerial.ToString(),
                                         TranslatorName = dbContext.Employees.Where(e => e.EmployeeID == tasks.TranslatorID).Select(e => e.FullName).FirstOrDefault(),
                                         ReviewerName = dbContext.Employees.Where(e => e.EmployeeID == tasks.ReviewerID).Select(e => e.FullName).FirstOrDefault(),
                                         TaskStatus = tasks.TaskStatus,
                                         WordCount = tasks.WordCount,
                                         CreatedDate = SqlFunctions.DatePart("year", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("month", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("day", tasks.CreatedDate),
                                         CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                         LastEditedDate = SqlFunctions.DatePart("year", tasks.EditedDate) + "/" + SqlFunctions.DatePart("month", tasks.EditedDate) + "/" + SqlFunctions.DatePart("day", tasks.EditedDate),
                                         LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                     }).ToList();
                        return tasksList;
                    case 3: // project manager
                        tasksList = (from tasks in dbContext.ProjectTasks
                                     where tasks.Project.ManagerID==employeeID && tasks.IsDeleted == false && LoggedUser.User.AlertTask >= SqlFunctions.DateDiff("day", DateTime.Now, tasks.ReviewerDeadLine)
                                     select new TaskListDTO
                                     {
                                         TaskID = tasks.TaskID,
                                         TaskSerial = tasks.TaskSerial.ToString(),
                                         TranslatorName = dbContext.Employees.Where(e => e.EmployeeID == tasks.TranslatorID).Select(e => e.FullName).FirstOrDefault(),
                                         ReviewerName = dbContext.Employees.Where(e => e.EmployeeID == tasks.ReviewerID).Select(e => e.FullName).FirstOrDefault(),
                                         TaskStatus = tasks.TaskStatus,
                                         WordCount = tasks.WordCount,
                                         CreatedDate = SqlFunctions.DatePart("year", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("month", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("day", tasks.CreatedDate),
                                         CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                         LastEditedDate = SqlFunctions.DatePart("year", tasks.EditedDate) + "/" + SqlFunctions.DatePart("month", tasks.EditedDate) + "/" + SqlFunctions.DatePart("day", tasks.EditedDate),
                                         LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                     }).ToList();
                        return tasksList;
                    case 4: // reviewer
                        tasksList = (from tasks in dbContext.ProjectTasks
                                     where tasks.ReviewerID == employeeID && tasks.IsDeleted == false && tasks.IsActivated == true && LoggedUser.User.AlertTask >= SqlFunctions.DateDiff("day", DateTime.Now, tasks.ReviewerDeadLine)
                                     select new TaskListDTO
                                     {
                                         TaskID = tasks.TaskID,
                                         TaskSerial = tasks.TaskSerial.ToString(),
                                         TranslatorName = dbContext.Employees.Where(e => e.EmployeeID == tasks.TranslatorID).Select(e => e.FullName).FirstOrDefault(),
                                         ReviewerName = dbContext.Employees.Where(e => e.EmployeeID == tasks.ReviewerID).Select(e => e.FullName).FirstOrDefault(),
                                         TaskStatus = tasks.TaskStatus,
                                         WordCount = tasks.WordCount,
                                         CreatedDate = SqlFunctions.DatePart("year", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("month", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("day", tasks.CreatedDate),
                                         CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                         LastEditedDate = SqlFunctions.DatePart("year", tasks.EditedDate) + "/" + SqlFunctions.DatePart("month", tasks.EditedDate) + "/" + SqlFunctions.DatePart("day", tasks.EditedDate),
                                         LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                     }).ToList();
                        return tasksList;
                    case 5: // translator
                        tasksList = (from tasks in dbContext.ProjectTasks
                                     where tasks.TranslatorID == employeeID && tasks.IsDeleted == false && tasks.IsActivated == true && LoggedUser.User.AlertTask >= SqlFunctions.DateDiff("day", DateTime.Now, tasks.TranslatorDeadLine)
                                     select new TaskListDTO
                                     {
                                         TaskID = tasks.TaskID,
                                         TaskSerial = tasks.TaskSerial.ToString(),
                                         TranslatorName = dbContext.Employees.Where(e => e.EmployeeID == tasks.TranslatorID).Select(e => e.FullName).FirstOrDefault(),
                                         ReviewerName = dbContext.Employees.Where(e => e.EmployeeID == tasks.ReviewerID).Select(e => e.FullName).FirstOrDefault(),
                                         TaskStatus = tasks.TaskStatus,
                                         WordCount = tasks.WordCount,
                                         CreatedDate = SqlFunctions.DatePart("year", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("month", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("day", tasks.CreatedDate),
                                         CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                         LastEditedDate = SqlFunctions.DatePart("year", tasks.EditedDate) + "/" + SqlFunctions.DatePart("month", tasks.EditedDate) + "/" + SqlFunctions.DatePart("day", tasks.EditedDate),
                                         LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                     }).ToList();
                        return tasksList;
                    default:
                        return tasksList;
                }

            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        // Get new Tasks for Translator or Reviewer
        public IEnumerable<TaskListDTO> GetTasksNew()
        {
            try
            {
                var tasksList = new List<TaskListDTO>();
                Guid? employeeID = LoggedUser.User.EmployeeID;
                int roleID = LoggedUser.User.Employee.RoleID;
                switch (roleID)
                {
                    case 4: // reviewer
                        tasksList = (from tasks in dbContext.ProjectTasks
                                     where tasks.ReviewerID == employeeID
                                     && tasks.IsDeleted == false && tasks.IsActivated == true
                                     && tasks.isMailSentToReviewer != null && tasks.isReviewerProgress == null
                                     select new TaskListDTO
                                     {
                                         TaskID = tasks.TaskID,
                                         TaskSerial = tasks.TaskSerial.ToString(),
                                         TranslatorName = dbContext.Employees.Where(e => e.EmployeeID == tasks.TranslatorID).Select(e => e.FullName).FirstOrDefault(),
                                         ReviewerName = dbContext.Employees.Where(e => e.EmployeeID == tasks.ReviewerID).Select(e => e.FullName).FirstOrDefault(),
                                         TaskStatus = "New",
                                         WordCount = tasks.WordCount,
                                         CreatedDate = SqlFunctions.DatePart("year", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("month", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("day", tasks.CreatedDate),
                                         CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                         LastEditedDate = SqlFunctions.DatePart("year", tasks.EditedDate) + "/" + SqlFunctions.DatePart("month", tasks.EditedDate) + "/" + SqlFunctions.DatePart("day", tasks.EditedDate),
                                         LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                     }).ToList();
                        return tasksList;
                    case 5: // translator
                        tasksList = (from tasks in dbContext.ProjectTasks
                                     where tasks.TranslatorID == employeeID
                                     && tasks.IsDeleted == false && tasks.IsActivated == true
                                     && tasks.isMailSentToTranslator != null && tasks.isTranslatorProgress == null
                                     select new TaskListDTO
                                     {
                                         TaskID = tasks.TaskID,
                                         TaskSerial = tasks.TaskSerial.ToString(),
                                         TranslatorName = dbContext.Employees.Where(e => e.EmployeeID == tasks.TranslatorID).Select(e => e.FullName).FirstOrDefault(),
                                         ReviewerName = dbContext.Employees.Where(e => e.EmployeeID == tasks.ReviewerID).Select(e => e.FullName).FirstOrDefault(),
                                         TaskStatus = "New",
                                         WordCount = tasks.WordCount,
                                         CreatedDate = SqlFunctions.DatePart("year", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("month", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("day", tasks.CreatedDate),
                                         CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                         LastEditedDate = SqlFunctions.DatePart("year", tasks.EditedDate) + "/" + SqlFunctions.DatePart("month", tasks.EditedDate) + "/" + SqlFunctions.DatePart("day", tasks.EditedDate),
                                         LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                     }).ToList();
                        return tasksList;
                    default:
                        return tasksList;
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        // Get Tasks in progress for Admin , Project Manager , Translator or Reviewer
        public IEnumerable<TaskListDTO> GetTasksInProgress()
        {
            try
            {
                var tasksList = new List<TaskListDTO>();
                Guid? employeeID = LoggedUser.User.EmployeeID;
                int roleID = LoggedUser.User.Employee.RoleID;
                switch (roleID)
                {
                    case 1: // owner
                    case 2: // admin
                        tasksList = (from tasks in dbContext.ProjectTasks
                                     where tasks.IsDeleted == false && tasks.IsActivated == true
                                     && tasks.isTranslatorProgress != null && tasks.isReviewerDone == null
                                     select new TaskListDTO
                                     {
                                         ProjectID = tasks.Project.ProjectID,
                                         ProjectSerial = tasks.Project.ProjectSerial.ToString(),
                                         TaskID = tasks.TaskID,
                                         TaskSerial = tasks.TaskSerial.ToString(),
                                         TranslatorName = dbContext.Employees.Where(e => e.EmployeeID == tasks.TranslatorID).Select(e => e.FullName).FirstOrDefault(),
                                         ReviewerName = dbContext.Employees.Where(e => e.EmployeeID == tasks.ReviewerID).Select(e => e.FullName).FirstOrDefault(),
                                         TaskStatus = tasks.TaskStatus,
                                         WordCount = tasks.WordCount,
                                         CreatedDate = SqlFunctions.DatePart("year", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("month", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("day", tasks.CreatedDate),
                                         CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                         LastEditedDate = SqlFunctions.DatePart("year", tasks.EditedDate) + "/" + SqlFunctions.DatePart("month", tasks.EditedDate) + "/" + SqlFunctions.DatePart("day", tasks.EditedDate),
                                         LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                     }).ToList();
                        return tasksList;
                    case 3: // project manager
                        tasksList = (from tasks in dbContext.ProjectTasks
                                     where tasks.IsDeleted == false && tasks.IsActivated == true
                                     && tasks.Project.ManagerID == employeeID
                                     && tasks.isTranslatorProgress != null && tasks.isReviewerDone == null
                                     select new TaskListDTO
                                     {
                                         ProjectID = tasks.Project.ProjectID,
                                         ProjectSerial = tasks.Project.ProjectSerial.ToString(),
                                         TaskID = tasks.TaskID,
                                         TaskSerial = tasks.TaskSerial.ToString(),
                                         TranslatorName = dbContext.Employees.Where(e => e.EmployeeID == tasks.TranslatorID).Select(e => e.FullName).FirstOrDefault(),
                                         ReviewerName = dbContext.Employees.Where(e => e.EmployeeID == tasks.ReviewerID).Select(e => e.FullName).FirstOrDefault(),
                                         TaskStatus = tasks.TaskStatus,
                                         WordCount = tasks.WordCount,
                                         CreatedDate = SqlFunctions.DatePart("year", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("month", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("day", tasks.CreatedDate),
                                         CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                         LastEditedDate = SqlFunctions.DatePart("year", tasks.EditedDate) + "/" + SqlFunctions.DatePart("month", tasks.EditedDate) + "/" + SqlFunctions.DatePart("day", tasks.EditedDate),
                                         LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                     }).ToList();
                        return tasksList;
                    case 4: // reviewer
                        tasksList = (from tasks in dbContext.ProjectTasks
                                     where tasks.ReviewerID == employeeID
                                     && tasks.IsDeleted == false && tasks.IsActivated == true
                                     && tasks.isReviewerProgress != null && tasks.isReviewerDone == null
                                     select new TaskListDTO
                                     {
                                         TaskID = tasks.TaskID,
                                         TaskSerial = tasks.TaskSerial.ToString(),
                                         TranslatorName = dbContext.Employees.Where(e => e.EmployeeID == tasks.TranslatorID).Select(e => e.FullName).FirstOrDefault(),
                                         ReviewerName = dbContext.Employees.Where(e => e.EmployeeID == tasks.ReviewerID).Select(e => e.FullName).FirstOrDefault(),
                                         TaskStatus = "Under Progress",
                                         WordCount = tasks.WordCount,
                                         CreatedDate = SqlFunctions.DatePart("year", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("month", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("day", tasks.CreatedDate),
                                         CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                         LastEditedDate = SqlFunctions.DatePart("year", tasks.EditedDate) + "/" + SqlFunctions.DatePart("month", tasks.EditedDate) + "/" + SqlFunctions.DatePart("day", tasks.EditedDate),
                                         LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                     }).ToList();
                        return tasksList;
                    case 5: // translator
                        tasksList = (from tasks in dbContext.ProjectTasks
                                     where tasks.TranslatorID == employeeID
                                     && tasks.IsDeleted == false && tasks.IsActivated == true
                                     && tasks.isTranslatorProgress != null && tasks.isTranslatorDone == null
                                     select new TaskListDTO
                                     {
                                         TaskID = tasks.TaskID,
                                         TaskSerial = tasks.TaskSerial.ToString(),
                                         TranslatorName = dbContext.Employees.Where(e => e.EmployeeID == tasks.TranslatorID).Select(e => e.FullName).FirstOrDefault(),
                                         ReviewerName = dbContext.Employees.Where(e => e.EmployeeID == tasks.ReviewerID).Select(e => e.FullName).FirstOrDefault(),
                                         TaskStatus = "Under Progress",
                                         WordCount = tasks.WordCount,
                                         CreatedDate = SqlFunctions.DatePart("year", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("month", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("day", tasks.CreatedDate),
                                         CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                         LastEditedDate = SqlFunctions.DatePart("year", tasks.EditedDate) + "/" + SqlFunctions.DatePart("month", tasks.EditedDate) + "/" + SqlFunctions.DatePart("day", tasks.EditedDate),
                                         LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                     }).ToList();
                        return tasksList;
                    default:
                        return tasksList;
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        // Get Completed Tasks for Admin , Project Manager , Translator or Reviewer
        public IEnumerable<TaskListDTO> GetTasksDone()
        {
            try
            {
                var tasksList = new List<TaskListDTO>();
                Guid? employeeID = LoggedUser.User.EmployeeID;
                int roleID = LoggedUser.User.Employee.RoleID;
                switch (roleID)
                {
                    case 1: // owner
                    case 2: // admin
                        tasksList = (from tasks in dbContext.ProjectTasks
                                     where tasks.IsDeleted == false && tasks.IsActivated == true
                                     && tasks.isReviewerDone != null
                                     select new TaskListDTO
                                     {
                                         ProjectID = tasks.Project.ProjectID,
                                         ProjectSerial = tasks.Project.ProjectSerial.ToString(),
                                         TaskID = tasks.TaskID,
                                         TaskSerial = tasks.TaskSerial.ToString(),
                                         TranslatorName = dbContext.Employees.Where(e => e.EmployeeID == tasks.TranslatorID).Select(e => e.FullName).FirstOrDefault(),
                                         ReviewerName = dbContext.Employees.Where(e => e.EmployeeID == tasks.ReviewerID).Select(e => e.FullName).FirstOrDefault(),
                                         TaskStatus = tasks.TaskStatus,
                                         WordCount = tasks.WordCount,
                                         CreatedDate = SqlFunctions.DatePart("year", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("month", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("day", tasks.CreatedDate),
                                         CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                         LastEditedDate = SqlFunctions.DatePart("year", tasks.EditedDate) + "/" + SqlFunctions.DatePart("month", tasks.EditedDate) + "/" + SqlFunctions.DatePart("day", tasks.EditedDate),
                                         LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                     }).ToList();
                        return tasksList;
                    case 3: // project manager
                        tasksList = (from tasks in dbContext.ProjectTasks
                                     where tasks.IsDeleted == false && tasks.IsActivated == true
                                     && tasks.Project.ManagerID == employeeID
                                     && tasks.isReviewerDone != null
                                     select new TaskListDTO
                                     {
                                         ProjectID = tasks.Project.ProjectID,
                                         ProjectSerial = tasks.Project.ProjectSerial.ToString(),
                                         TaskID = tasks.TaskID,
                                         TaskSerial = tasks.TaskSerial.ToString(),
                                         TranslatorName = dbContext.Employees.Where(e => e.EmployeeID == tasks.TranslatorID).Select(e => e.FullName).FirstOrDefault(),
                                         ReviewerName = dbContext.Employees.Where(e => e.EmployeeID == tasks.ReviewerID).Select(e => e.FullName).FirstOrDefault(),
                                         TaskStatus = tasks.TaskStatus,
                                         WordCount = tasks.WordCount,
                                         CreatedDate = SqlFunctions.DatePart("year", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("month", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("day", tasks.CreatedDate),
                                         CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                         LastEditedDate = SqlFunctions.DatePart("year", tasks.EditedDate) + "/" + SqlFunctions.DatePart("month", tasks.EditedDate) + "/" + SqlFunctions.DatePart("day", tasks.EditedDate),
                                         LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                     }).ToList();
                        return tasksList;
                    case 4: // reviewer
                        tasksList = (from tasks in dbContext.ProjectTasks
                                     where tasks.ReviewerID == employeeID
                                     && tasks.IsDeleted == false && tasks.IsActivated == true
                                     && tasks.isReviewerDone != null
                                     select new TaskListDTO
                                     {
                                         TaskID = tasks.TaskID,
                                         TaskSerial = tasks.TaskSerial.ToString(),
                                         TranslatorName = dbContext.Employees.Where(e => e.EmployeeID == tasks.TranslatorID).Select(e => e.FullName).FirstOrDefault(),
                                         ReviewerName = dbContext.Employees.Where(e => e.EmployeeID == tasks.ReviewerID).Select(e => e.FullName).FirstOrDefault(),
                                         TaskStatus = "Completed",
                                         WordCount = tasks.WordCount,
                                         CreatedDate = SqlFunctions.DatePart("year", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("month", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("day", tasks.CreatedDate),
                                         CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                         LastEditedDate = SqlFunctions.DatePart("year", tasks.EditedDate) + "/" + SqlFunctions.DatePart("month", tasks.EditedDate) + "/" + SqlFunctions.DatePart("day", tasks.EditedDate),
                                         LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                     }).ToList();
                        return tasksList;
                    case 5: // translator
                        tasksList = (from tasks in dbContext.ProjectTasks
                                     where tasks.TranslatorID == employeeID
                                     && tasks.IsDeleted == false && tasks.IsActivated == true
                                     && tasks.isTranslatorDone != null
                                     select new TaskListDTO
                                     {
                                         TaskID = tasks.TaskID,
                                         TaskSerial = tasks.TaskSerial.ToString(),
                                         TranslatorName = dbContext.Employees.Where(e => e.EmployeeID == tasks.TranslatorID).Select(e => e.FullName).FirstOrDefault(),
                                         ReviewerName = dbContext.Employees.Where(e => e.EmployeeID == tasks.ReviewerID).Select(e => e.FullName).FirstOrDefault(),
                                         TaskStatus = "Completed",
                                         WordCount = tasks.WordCount,
                                         CreatedDate = SqlFunctions.DatePart("year", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("month", tasks.CreatedDate) + "/" + SqlFunctions.DatePart("day", tasks.CreatedDate),
                                         CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                         LastEditedDate = SqlFunctions.DatePart("year", tasks.EditedDate) + "/" + SqlFunctions.DatePart("month", tasks.EditedDate) + "/" + SqlFunctions.DatePart("day", tasks.EditedDate),
                                         LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == tasks.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                     }).ToList();
                        return tasksList;
                    default:
                        return tasksList;
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }
    }
}
