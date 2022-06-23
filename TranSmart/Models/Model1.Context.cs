﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TranSmart.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TranSmartDBContext : DbContext
    {
        public TranSmartDBContext()
            : base("name=TranSmartDBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ValCity> ValCities { get; set; }
        public virtual DbSet<ValCountry> ValCountries { get; set; }
        public virtual DbSet<ValCustomerType> ValCustomerTypes { get; set; }
        public virtual DbSet<ValEmployeeRole> ValEmployeeRoles { get; set; }
        public virtual DbSet<ValEmployeeWorkMethod> ValEmployeeWorkMethods { get; set; }
        public virtual DbSet<ValLanguage> ValLanguages { get; set; }
        public virtual DbSet<ValState> ValStates { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ProjectTask> ProjectTasks { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
    }
}
