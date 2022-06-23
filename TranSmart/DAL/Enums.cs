using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TranSmart.DAL
{
    public enum UserLoginStatus
    {
        Success,
        DeActivated,
        WrongUserName,
        WrongPassword,
        Error
    }
    public enum UserUpdateStatus
    {
        EmployeeHasUser,
        UserNameExists,
        Success,
        Error
    }
    public enum EmployeeUpdateStatus
    {
        EmployeeNameExists,
        Success,
        Error
    }
    public enum CustomerUpdateStatus
    {
        CustomerNameExists,
        Success,
        Error
    }
    public enum ProjectStatus
    {
        CustomerRequest,
        OfferSent,
        CustomerApproved,
        New,
        UnderProgress,
        Completed,
        ProjectDelivered,
        ProjectCanceled
    }
    public enum TaskStatus
    {
        New,
        UnderProgress,
        Completed,
        Canceled
    }

    public enum ProjectBy
    {
        Customer,
        ProjectManager
    }
}