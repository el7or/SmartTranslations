using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TranSmart.DTO
{
    public class PaymentDTO
    {
        public Guid PaymentID { get; set; }
        public string Item { get; set; }
        public bool PaymentDirection { get; set; }
        public decimal Paid { get; set; }
        public string Note { get; set; }
    }
    public class PaymentsListDTO
    {
        public Guid PaymentID { get; set; }
        public Guid? ProjectID { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string PaymentDirection { get; set; }
        public string Paid { get; set; }
        public DateTime PaymentDateTime { get; set; }
        public string PaymentTime { get; set; }
        public string By { get; set; }
        public string isProject{ get; set; }
        public string Note { get; set; }
    }
    public class PaymentsSoonDTO
    {
        public Guid ProjectID { get; set; }
        public Guid CustomerID { get; set; }
        public string ProjectSerial { get; set; }
        public string ProjectTitle { get; set; }
        public string CustomerName { get; set; }
        public string ProjectStatus { get; set; }
        public decimal TotalCost { get; set; }
        public decimal Paid { get; set; }
        public decimal Due { get; set; }
        public DateTime? DueDate { get; set; }
    }
}