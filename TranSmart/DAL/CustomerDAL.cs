using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using TranSmart.DTO;
using TranSmart.Models;

namespace TranSmart.DAL
{
    public class CustomerDAL
    {
        // Get Object from Class
        private static CustomerDAL instance;
        private static object mutex = new object();
        public static CustomerDAL GetInstance()
        {
            lock (mutex)
            {
                if (instance == null)
                {
                    instance = new CustomerDAL();
                }
                return instance;
            }
        }

        TranSmartDBContext dbContext = null;
        public CustomerDAL()
        {
            dbContext = new TranSmartDBContext();
        }

        // Create new Customer
        public Guid CreateCustomer(CustomerDTO customerData)
        {
            try
            {
                Customer newCustomer = new Customer()
                {
                    CustomerID = Guid.NewGuid(),
                    CustomerName = customerData.CustomerName,
                    CustomerTypeID = customerData.CustomerTypeID,
                    CustomerEmail = customerData.CustomerEmail,
                    CustomerPhone = customerData.CustomerPhone,
                    CustomerCountryID = customerData.CustomerCountryID,
                    CustomerAddress = customerData.CustomerAddress,
                    Note = customerData.Note,
                    IsDeleted = false,
                    CreatedBy = customerData.EditedBy,
                    CreatedDate = DateTime.Now,
                    EditedBy = customerData.EditedBy,
                    EditedDate = DateTime.Now
                };
                dbContext.Customers.Add(newCustomer);
                dbContext.SaveChanges();
                return newCustomer.CustomerID;
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }

        // Update existing Customer
        public CustomerUpdateStatus UpdateCustomer(CustomerDTO customerData)
        {
            try
            {
                if (dbContext.Customers.Where(c => c.CustomerName.Trim() == customerData.CustomerName.Trim()&&c.CustomerID!=customerData.CustomerID).Count() > 0)
                {
                    return CustomerUpdateStatus.CustomerNameExists;
                }
                else
                {
                    Customer customer = dbContext.Customers.Find(customerData.CustomerID);

                    customer.CustomerName = customerData.CustomerName;
                    customer.CustomerTypeID = customerData.CustomerTypeID;
                    customer.CustomerEmail = customerData.CustomerEmail;
                    customer.CustomerPhone = customerData.CustomerPhone;
                    customer.CustomerAddress = customerData.CustomerAddress;
                    customer.Note = customerData.Note;
                    customer.EditedBy = customerData.EditedBy;
                    customer.EditedDate = DateTime.Now;

                    dbContext.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                    return CustomerUpdateStatus.Success;
                }
            }
            catch (Exception)
            {
                return CustomerUpdateStatus.Error;
            }
        }

        // Delete Customer
        public bool DeleteCustomer(Guid customerID, Guid EditedBy)
        {
            try
            {
                Customer customer = dbContext.Customers.Find(customerID);
                customer.IsDeleted = true;
                customer.EditedBy = EditedBy;
                customer.EditedDate = DateTime.Now;

                dbContext.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Get all Customer
        public IEnumerable<CustomersListDTO> GetAllCustomers()
        {
            try
            {
                var customersList = (from customers in dbContext.Customers
                                     where customers.IsDeleted == false
                                     select new CustomersListDTO
                                     {
                                         CustomerID = customers.CustomerID,
                                         CustomerName = customers.CustomerName,
                                         CustomerType = customers.ValCustomerType.CustomerTypeText,
                                         CustomerEmail = customers.CustomerEmail,
                                         CustomerPhone = customers.CustomerPhone,
                                         CustomerCountry = customers.ValCountry.CountryText,
                                         CustomerAddress = customers.CustomerAddress,
                                         FirstContactDate = (customers.Projects.Count() > 0 ? customers.Projects.OrderByDescending(p => p.isCustomerApproved).Select(d => d.isCustomerApproved.ToString()).FirstOrDefault() : ""),
                                     }).ToList();
                return customersList;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        // Get Customer list by Category
        public IEnumerable<CustomersListDTO> GetCustomersByType(int customerTypeID)
        {
            try
            {
                var customersList = (from customers in dbContext.Customers
                                     where customers.IsDeleted == false && customers.CustomerTypeID == customerTypeID
                                     select new CustomersListDTO
                                     {
                                         CustomerID = customers.CustomerID,
                                         CustomerName = customers.CustomerName,
                                         //CustomerType = customers.ValCustomerType.CustomerTypeText,
                                         //CustomerEmail = customers.CustomerEmail,
                                         //CustomerPhone = customers.CustomerPhone,
                                         //CustomerCountry = customers.ValCountry.CountryText,
                                         //CustomerAddress = customers.CustomerAddress,
                                         FirstContactDate = (customers.Projects.Count() > 0 ? customers.Projects.OrderByDescending(p => p.isCustomerApproved).Select(d => d.isCustomerApproved.ToString()).FirstOrDefault() : ""),
                                     }).ToList();
                return customersList;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        // Get Customer by CustomerID
        public CustomerDetailsDTO GetCustomerDetailsByID(Guid customerID)
        {
            try
            {
                CustomerDetailsDTO selectedCustomer = (from customers in dbContext.Customers
                                                       where customers.CustomerID == customerID
                                                       select new CustomerDetailsDTO
                                                       {
                                                           CustomerID = customers.CustomerID,
                                                           CustomerName = customers.CustomerName,
                                                           CustomerType = customers.ValCustomerType.CustomerTypeText,
                                                           CustomerEmail = customers.CustomerEmail,
                                                           CustomerPhone = customers.CustomerPhone,
                                                           CustomerCountry = customers.ValCountry.CountryText,
                                                           CustomerAddress = customers.CustomerAddress,
                                                           Note = customers.Note,
                                                           CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == customers.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                                           CreatedDate = SqlFunctions.DatePart("year", customers.CreatedDate) + "/" + SqlFunctions.DatePart("month", customers.CreatedDate) + "/" + SqlFunctions.DatePart("day", customers.CreatedDate),
                                                           LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == customers.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                                           LastEditedDate = SqlFunctions.DatePart("year", customers.EditedDate) + "/" + SqlFunctions.DatePart("month", customers.EditedDate) + "/" + SqlFunctions.DatePart("day", customers.EditedDate)
                                                       }).FirstOrDefault();
                return selectedCustomer;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }
        
        // Get number projects of Customer
        public IEnumerable<CustomersListDTO> GetCustomersProjectsCount()
        {
            try
            {
                var customersList = (from customers in dbContext.Customers
                                     where customers.IsDeleted == false
                                     select new CustomersListDTO
                                     {
                                         CustomerID = customers.CustomerID,
                                         CustomerName = customers.CustomerName,
                                         CustomerType = customers.ValCustomerType.CustomerTypeText,
                                         CustomerEmail = customers.CustomerEmail,
                                         CustomerPhone = customers.CustomerPhone,
                                         CustomerCountry = customers.ValCountry.CountryText,
                                         CustomerAddress = customers.CustomerAddress,
                                         FirstContactDate = (customers.Projects.Count() > 0 ? customers.Projects.OrderByDescending(p => p.isCustomerApproved).Select(d => d.isCustomerApproved.ToString()).FirstOrDefault() : ""),
                                         ProjectsCount = customers.Projects.Count()
                                     }).ToList();
                return customersList;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        // Get Customer requests without offer or approval
        public IEnumerable<CustomerRequestsListDTO> GetCustomerRequests()
        {
            try
            {
                var customerRequests = (from projects in dbContext.Projects
                                        where projects.IsDeleted == false
                                        && projects.IsActivated == true
                                        && projects.Customer.IsDeleted == false
                                        && projects.CustomerRequestDate !=null && (projects.isOfferSentToCustomer==null || projects.isCustomerApproved==null)
                                        select new CustomerRequestsListDTO
                                        {
                                            ProjectID = projects.ProjectID,
                                            CustomerName = projects.Customer.CustomerName,
                                            CustomerPhone = projects.Customer.CustomerPhone,
                                            CustomerEmail = projects.Customer.CustomerEmail,
                                            CustomerRequestDate = SqlFunctions.DatePart("year", projects.CustomerRequestDate) + "/" + SqlFunctions.DatePart("month", projects.CustomerRequestDate) + "/" + SqlFunctions.DatePart("day", projects.CustomerRequestDate),
                                            isOfferSent = (projects.isOfferSentToCustomer==null?false:true),
                                            isCustomerApproved = (projects.isCustomerApproved==null?false:true),
                                            ProjectSerial= projects.ProjectSerial.ToString()
                                        }).ToList();
                return customerRequests;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        /***************** Customer System values *****************/
        // Get Customer Categories list
        public IEnumerable<ValCustomerType> GetCustomerTypesList()
        {
            try
            {
                return dbContext.ValCustomerTypes.OrderBy(c => c.CustomerTypeID).ToList();
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        // Get list of Countries
        public IEnumerable<CountryListDTO> GetCountriesList()
        {
            try
            {
                return dbContext.ValCountries.Select(c => new CountryListDTO
                {
                    CountryID = c.CountryID,
                    CountryText = c.CountryText
                }).ToList().OrderBy(c => c.CountryID);
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }
    }
}