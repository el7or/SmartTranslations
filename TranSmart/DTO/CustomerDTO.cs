using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TranSmart.DTO
{
    public class CustomerDTO
    {
        public Guid CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int CustomerTypeID { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public int? CustomerCountryID { get; set; }
        public string CustomerAddress { get; set; }
        public string Note { get; set; }
        public Guid EditedBy { get; set; }
    }
    public class CustomersListDTO
    {
        public Guid CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerType { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerAddress { get; set; }
        public string FirstContactDate { get; set; }
        //public string FirstQuoteDate { get; set; }
        //public string FirstProjectDate { get; set; }
        public int? ProjectsCount { get; set; }
    }
    public class CustomerDetailsDTO
    {
        public Guid CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerType { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerAddress { get; set; }
        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string LastEditedBy { get; set; }
        public string LastEditedDate { get; set; }
    }

    public class CustomerRequestsListDTO
    {
        public Guid ProjectID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerRequestDate { get; set; }
        public bool isOfferSent { get; set; }
        public bool isCustomerApproved { get; set; }
        public string ProjectSerial { get; set; }
    }
    public class CountryListDTO
    {
        public int CountryID { get; set; }
        public string CountryText { get; set; }
    }
}