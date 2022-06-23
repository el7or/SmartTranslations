using System;
using TranSmart.DAL;

namespace TranSmart.DTO
{
    public class UserDTO
    {
        public Guid? UserID { get; set; }
        public Guid? EmployeeID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActivated { get; set; }
        public Guid EditedBy { get; set; }
    }
    public class UserListDTO
    {
        public Guid UserID { get; set; }
        public string FullName { get; set; }
        //public string UserName { get; set; }
        //public string UserRole { get; set; }
        //public bool IsActivated { get; set; }
    }
    public class UserDetailsDTO
    {
        public Guid UserID { get; set; }
        public Guid? EmployeeID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActivated { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string LastEditedBy { get; set; }
        public string LastEditedDate { get; set; }
    }
}