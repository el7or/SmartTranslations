using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TranSmart.Models;

namespace TranSmart.DTO
{
    public class EmployeeDTO
    {
        public Guid? EmployeeID { get; set; }
        public string FullName { get; set; }
        public int RoleID { get; set; }
        public DateTime JobStartDate { get; set; }
        public int WorkMethodID { get; set; }
        public string Languages { get; set; }
        public decimal? WordPrice { get; set; }
        public decimal? BasicSalary { get; set; }
        public decimal? Commission { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public Guid EditedBy { get; set; }
    }
    public class EmployeeListDTO
    {
        public Guid? EmployeeID { get; set; }
        public string FullName { get; set; }
        public bool? isHasLogin { get; set; }
        public string StrHasLogin { get; set; }
        //public string Role { get; set; }
        public string JobStartDate { get; set; }
        //public string WorkMethod { get; set; }
        //public string Languages { get; set; }
        //public decimal? WordPrice { get; set; }
        //public decimal? BasicSalary { get; set; }
        //public decimal? Commission { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        //public string Address { get; set; }
        //public string Note { get; set; }
        //public bool IsActivated { get; set; }
        public int? ProjectsCount { get; set; }
    }
    public class EmployeeDetailsDTO
    {
        public Guid EmployeeID { get; set; }
        public string FullName { get; set; }
        public int Role { get; set; }
        public DateTime JobStartDate { get; set; }
        public string WorkMethod { get; set; }
        public string Languages { get; set; }
        public decimal? WordPrice { get; set; }
        public decimal? BasicSalary { get; set; }
        public decimal? Commission { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public bool IsActivated { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string LastEditedBy { get; set; }
        public string LastEditedDate { get; set; }
    }
    public class EmployeeDelaysListDTO
    {
        public Guid ProjectID { get; set; }
        public string ProjectSerial { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DeadLineDate { get; set; }
        public string ActualDeliveryDate { get; set; }
        public string DelayedDays { get; set; }
    }
    public class TranslatorsInvoicesDTO
    {
        public Guid EmployeeID { get; set; }
        public string FullName { get; set; }
        public int? TasksCount { get; set; }
        public decimal? TotalWordCount { get; set; }
        public decimal? WordPrice { get; set; }
        public decimal? TotalTasksCost { get; set; }
        public decimal? BasicSalary { get; set; }
        //public decimal? Commission { get; set; }
    }
}