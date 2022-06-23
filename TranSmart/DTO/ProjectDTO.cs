using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TranSmart.DAL;

namespace TranSmart.DTO
{
    public class ProjectDTO
    {
        public Guid ProjectID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid ManagerID { get; set; }
        public string ProjectTitle { get; set; }
        public DateTime CustomerRequestDate { get; set; }
        public string CustomerFile { get; set; }
        public string SourceLangg { get; set; }
        public string TargetLangg { get; set; }
        public long WordCount { get; set; }
        public decimal WordPrice { get; set; }
        public decimal VatValue { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal Paid { get; set; }
        public DateTime? NextPaymentDate { get; set; }
        public DateTime? isOfferSentToCustomer { get; set; }
        public DateTime? isCustomerApproved { get; set; }
        public DateTime? PromiseDeliveryDate { get; set; }
        public string FinalFile { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public string Note { get; set; }
        public Guid EditedBy { get; set; }
    }
    public class ProjectsListDTO
    {
        public Guid ProjectID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid ManagerID { get; set; }
        public string ProjectSerial { get; set; }
        public string CustomerName { get; set; }
        public string ProjectManager { get; set; }
        public string ProjectTitle { get; set; }
        public string CurrentStatus { get; set; }
        public string LanggFromTo { get; set; }
        public long? WordCount { get; set; }
        public decimal? WordPrice { get; set; }
        public decimal? DiscountValue { get; set; }
        public decimal? VatValue { get; set; }
        public decimal? TotalCost { get; set; }
        public decimal? Paid { get; set; }
        public decimal? Due { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string LastEditedBy { get; set; }
        public string LastEditedDate { get; set; }
        public DateTime CustomerRequestDate { get; set; }
        public DateTime? PromiseDeliveryDate { get; set; }
    }
    public class ProjectDetailsDTO
    {
        public Guid ProjectID { get; set; }
        public string ProjectSerial { get; set; }
        public string ProjectTitle { get; set; }
        public int SourceLanggID { get; set; }
        public int TargetLanggID { get; set; }
        public Guid CustomerID { get; set; }
        public DateTime CustomerRequestDate { get; set; }
        public DateTime? PromiseDeliveryDate { get; set; }
        public string Notes { get; set; }
        public long WordCount { get; set; }
        public decimal WordPrice { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal VatValue { get; set; }
        public decimal PrevPayments { get; set; }
        public DateTime? NextPaymentDate { get; set; }
        public string CustomerFile { get; set; }
        public string FinalFile { get; set; }
        public string ProjectManager { get; set; }
        public List<string> Reviewers { get; set; }
        public List<string> Translators { get; set; }
        public string ProjectStatus { get; set; }
        public DateTime? isOfferSentToCustomer { get; set; }
        public DateTime? isCustomerApproved { get; set; }
        public string isTasksSent { get; set; }
        public string isTasksInProgress { get; set; }
        public string isTasksFinished { get; set; }
        public DateTime? isProjectDelivered { get; set; }

        // by Hatem 12 Aug 2017
        public Guid ManagerID { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public string Note { get; set; }
        public string SourceLangg { get; set; }
        public string TargetLangg { get; set; }
        public decimal Paid { get; set; }
        public Guid EditedBy { get; set; }
    }
}