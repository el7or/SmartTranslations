//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            this.ProjectTasks = new HashSet<ProjectTask>();
            this.Payments = new HashSet<Payment>();
        }
    
        public System.Guid ProjectID { get; set; }
        public System.Guid CustomerID { get; set; }
        public System.Guid ManagerID { get; set; }
        public int ProjectSerial { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectStatus { get; set; }
        public System.DateTime CustomerRequestDate { get; set; }
        public string CustomerFile { get; set; }
        public string SourceLangg { get; set; }
        public string TargetLangg { get; set; }
        public long WordCount { get; set; }
        public decimal WordPrice { get; set; }
        public decimal VatValue { get; set; }
        public decimal DiscountValue { get; set; }
        public Nullable<System.DateTime> isOfferSentToCustomer { get; set; }
        public Nullable<System.DateTime> isCustomerApproved { get; set; }
        public Nullable<System.DateTime> PromiseDeliveryDate { get; set; }
        public string FinalFile { get; set; }
        public Nullable<System.DateTime> ActualDeliveryDate { get; set; }
        public string Note { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public System.Guid CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.Guid EditedBy { get; set; }
        public System.DateTime EditedDate { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectTask> ProjectTasks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}