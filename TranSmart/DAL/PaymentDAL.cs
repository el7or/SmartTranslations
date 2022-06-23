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
    public class PaymentDAL
    {
        // Get Object from Class
        private static PaymentDAL instance;
        private static object mutex = new object();
        public static PaymentDAL GetInstance()
        {
            lock (mutex)
            {
                if (instance == null)
                {
                    instance = new PaymentDAL();
                }
                return instance;
            }
        }

        TranSmartDBContext dbContext = null;
        public PaymentDAL()
        {
            dbContext = new TranSmartDBContext();
        }

        // Get all Payments for Admin or Project Manager
        public IEnumerable<PaymentsListDTO> GetAllPayments()
        {
            try
            {
                var paymentsList = new List<PaymentsListDTO>();
                Guid? employeeID = LoggedUser.User.EmployeeID;
                int roleID = LoggedUser.User.Employee.RoleID;
                switch (roleID)
                {
                    case 1:
                    case 2:
                    case 6:
                        paymentsList = (from payments in dbContext.Payments
                                        where payments.Paid >0
                                        orderby payments.CreatedDate descending
                                        select new PaymentsListDTO
                                        {
                                            PaymentID = payments.PaymentID,
                                            ProjectID = payments.ProjectID,
                                            Title = (payments.Item == null ? payments.Project.ProjectTitle : payments.Item),
                                            Type = (payments.Item == null ? "Project" : "Other"),
                                            PaymentDirection = (payments.PaymentDirection == true ? "In" : "Out"),
                                            Paid = payments.Paid.ToString(),
                                            PaymentDateTime = payments.CreatedDate,
                                            //PaymentDate = SqlFunctions.DatePart("year", payments.CreatedDate) + "/" + SqlFunctions.DatePart("month", payments.CreatedDate) + "/" + SqlFunctions.DatePart("day", payments.CreatedDate),
                                            //PaymentTime = SqlFunctions.DatePart("hour", payments.CreatedDate) + ":" + SqlFunctions.DatePart("minute", payments.CreatedDate),
                                            By = dbContext.Users.Where(u => u.UserID == payments.CreatedBy).Select(n => n.Employee.FullName).FirstOrDefault(),
                                            isProject = (payments.Item == null ? "Project Details" : null),
                                            Note = (payments.Item == null ? (payments.Project.Note == null || payments.Project.Note == "" ? "None!" : payments.Project.Note) : (payments.Note == null || payments.Note == "" ? "None!" : payments.Note))
                                        }).ToList();
                        return paymentsList;
                    case 3:
                        paymentsList = (from payments in dbContext.Payments
                                        where payments.CreatedBy == employeeID && payments.Paid > 0
                                        orderby payments.CreatedDate descending
                                        select new PaymentsListDTO
                                        {
                                            PaymentID = payments.PaymentID,
                                            ProjectID = payments.ProjectID,
                                            Title = (payments.Item == null ? payments.Project.ProjectTitle : payments.Item),
                                            Type = (payments.Item == null ? "Project" : "Other"),
                                            PaymentDirection = (payments.PaymentDirection == true ? "In" : "Out"),
                                            Paid = payments.Paid.ToString(),
                                            PaymentDateTime = payments.CreatedDate,
                                            //PaymentDate = SqlFunctions.DatePart("year", payments.CreatedDate) + "/" + SqlFunctions.DatePart("month", payments.CreatedDate) + "/" + SqlFunctions.DatePart("day", payments.CreatedDate),
                                            //PaymentTime = SqlFunctions.DatePart("hour", payments.CreatedDate) + ":" + SqlFunctions.DatePart("minute", payments.CreatedDate),
                                            By = dbContext.Users.Where(u => u.UserID == payments.CreatedBy).Select(n => n.Employee.FullName).FirstOrDefault(),
                                            isProject = (payments.Item == null ? "Project Details" : null),
                                            Note = (payments.Item == null ? (payments.Project.Note == null || payments.Project.Note == "" ? "None!" : payments.Project.Note) : (payments.Note == null || payments.Note == "" ? "None!" : payments.Note))
                                        }).ToList();
                        return paymentsList;
                    default:
                        return paymentsList;
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        // Get all Payments by period
        public IEnumerable<PaymentsListDTO> GetAllPayments(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var paymentsList = (from payments in dbContext.Payments
                                    orderby payments.CreatedDate descending
                                    where payments.CreatedDate >= startDate && payments.CreatedDate <= endDate
                                    && payments.Paid > 0
                                    select new PaymentsListDTO
                                    {
                                        PaymentID = payments.PaymentID,
                                        ProjectID = payments.ProjectID,
                                        Title = (payments.Item == null ? payments.Project.ProjectTitle : payments.Item),
                                        Type = (payments.Item == null ? "Project" : "Other"),
                                        PaymentDirection = (payments.PaymentDirection == true ? "In" : "Out"),
                                        Paid = payments.Paid.ToString(),
                                        PaymentDateTime = payments.CreatedDate,
                                        //PaymentDate = SqlFunctions.DatePart("year", payments.CreatedDate) + "/" + SqlFunctions.DatePart("month", payments.CreatedDate) + "/" + SqlFunctions.DatePart("day", payments.CreatedDate),
                                        //PaymentTime = SqlFunctions.DatePart("hour", payments.CreatedDate) + ":" + SqlFunctions.DatePart("minute", payments.CreatedDate),
                                        By = dbContext.Users.Where(u => u.UserID == payments.CreatedBy).Select(n => n.Employee.FullName).FirstOrDefault(),
                                        isProject = (payments.Item == null ? "Project Details" : null),
                                        Note = (payments.Item == null ? (payments.Project.Note == null || payments.Project.Note == "" ? "None!" : payments.Project.Note) : (payments.Note == null || payments.Note == "" ? "None!" : payments.Note))
                                    }).ToList();
                return paymentsList;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        // Get current balance:
        public decimal GetBalance()
        {
            decimal income = dbContext.Payments.Where(d => d.PaymentDirection == true).Sum(p => p.Paid);
            decimal outcome = dbContext.Payments.Where(d => d.PaymentDirection == false).Sum(p => p.Paid);
            return income - outcome;
        }

        // Get soon Payments for Admin or Project Manager
        public IEnumerable<PaymentsSoonDTO> GetPaymentsSoon()
        {
            try
            {
                var paymentsList = new List<PaymentsSoonDTO>();
                Guid? employeeID = LoggedUser.User.EmployeeID;
                int roleID = LoggedUser.User.Employee.RoleID;
                switch (roleID)
                {
                    case 1:
                    case 2:
                        paymentsList = (from projects in dbContext.Projects
                                        where projects.IsDeleted == false //&& projects.IsActivated==true 
                                        //&& LoggedUser.User.AlertPayment >= SqlFunctions.DateDiff("day", DateTime.Now, projects.Payments.OrderByDescending(x => x.NextPaymentDate).Select(x => x.NextPaymentDate).FirstOrDefault())
                                        select new PaymentsSoonDTO
                                        {
                                            ProjectID = projects.ProjectID,
                                            CustomerID = projects.CustomerID,
                                            ProjectSerial = projects.ProjectSerial.ToString(),
                                            ProjectTitle = projects.ProjectTitle,
                                            CustomerName = projects.Customer.CustomerName,
                                            ProjectStatus = projects.ProjectStatus,
                                            TotalCost = ((projects.WordCount * projects.WordPrice) - projects.DiscountValue) + projects.VatValue,
                                            Paid = (projects.Payments.Count > 0 ? projects.Payments.Sum(x => x.Paid) : 0),
                                            Due = (((projects.WordCount * projects.WordPrice) - projects.DiscountValue) + projects.VatValue) - (projects.Payments.Count > 0 ? projects.Payments.Sum(x => x.Paid) : 0),
                                            DueDate = projects.Payments.OrderByDescending(x => x.NextPaymentDate).Select(x => x.NextPaymentDate).FirstOrDefault()
                                        }).Where(p => p.Due > 0).ToList();
                        return paymentsList;
                    case 3:
                        paymentsList = (from projects in dbContext.Projects
                                        where projects.IsDeleted == false //&& projects.IsActivated==true 
                                        && projects.ManagerID == employeeID
                                        //&& LoggedUser.User.AlertPayment >= SqlFunctions.DateDiff("day", DateTime.Now, projects.Payments.OrderByDescending(x => x.NextPaymentDate).Select(x => x.NextPaymentDate).FirstOrDefault())
                                        select new PaymentsSoonDTO
                                        {
                                            ProjectID = projects.ProjectID,
                                            CustomerID = projects.CustomerID,
                                            ProjectSerial = projects.ProjectSerial.ToString(),
                                            ProjectTitle = projects.ProjectTitle,
                                            CustomerName = projects.Customer.CustomerName,
                                            ProjectStatus = projects.ProjectStatus,
                                            TotalCost = ((projects.WordCount * projects.WordPrice) - projects.DiscountValue) + projects.VatValue,
                                            Paid = (projects.Payments.Count > 0 ? projects.Payments.Sum(x => x.Paid) : 0),
                                            Due = (((projects.WordCount * projects.WordPrice) - projects.DiscountValue) + projects.VatValue) - (projects.Payments.Count > 0 ? projects.Payments.Sum(x => x.Paid) : 0),
                                            DueDate = projects.Payments.OrderByDescending(x => x.NextPaymentDate).Select(x => x.NextPaymentDate).FirstOrDefault()
                                        }).Where(p => p.Due > 0).ToList();
                        return paymentsList;
                    default:
                        return paymentsList;
                }
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        // Add new Payment
        public Guid AddPayment(PaymentDTO paymentData)
        {
            try
            {
                Payment newPayment = new Payment()
                {
                    PaymentID = paymentData.PaymentID,
                    ProjectID = null,
                    Item = paymentData.Item,
                    PaymentDirection = paymentData.PaymentDirection,
                    Paid = paymentData.Paid,
                    Note = paymentData.Note,
                    CreatedBy = LoggedUser.User_PK,
                    CreatedDate = DateTime.Now
                };
                dbContext.Payments.Add(newPayment);
                dbContext.SaveChanges();
                return newPayment.PaymentID;
            }
            catch (Exception ex)
            {
                Global.Log.Error("PaymentDAL.Create", ex);
                return Guid.Empty;
            }
        }
    }
}