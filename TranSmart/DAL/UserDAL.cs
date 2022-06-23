using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using TranSmart.DTO;
using TranSmart.Models;

namespace TranSmart.DAL
{
    public class UserDAL
    {
        // Get Object from Class
        private static UserDAL instance;
        private static object mutex = new object();
        public static UserDAL GetInstance()
        {
            lock (mutex)
            {
                if (instance == null)
                {
                    instance = new UserDAL();
                }
                return instance;
            }
        }

        TranSmartDBContext dbContext = null;
        public UserDAL()
        {
            dbContext = new TranSmartDBContext();
        }

        // Check login
        /// <summary>
        /// Check login data and return two types:
        /// 1-enaum for result of login, 2-Guid UserID if result is Success.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Tuple<UserLoginStatus, Guid> CheckLogin(string userName, string password)
        {
            try
            {
                User loginUser = dbContext.Users.Where(u => u.UserName == userName && u.IsDeleted == false).FirstOrDefault();
                if (loginUser == null)
                {
                    return Tuple.Create(UserLoginStatus.WrongUserName, Guid.Empty);
                }
                else
                {
                    if (loginUser.Password == password)
                    {
                        if (loginUser.IsActivated == true)
                        {
                            return Tuple.Create(UserLoginStatus.Success, loginUser.UserID);
                        }
                        else return Tuple.Create(UserLoginStatus.DeActivated, Guid.Empty);
                    }
                    else return Tuple.Create(UserLoginStatus.WrongPassword, Guid.Empty);
                }
            }
            catch (Exception)
            {
                return Tuple.Create(UserLoginStatus.Error, Guid.Empty);
            }
        }

        // Check login2
        /// <summary>
        /// Check login data and return two types:
        /// 1-enaum for result of login, 2- User data if result is Success.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Tuple<UserLoginStatus, User> CheckLogin2(string userName, string password)
        {
            User loginUser = null;
            try
            {
                if (dbContext.Database.Connection.State != System.Data.ConnectionState.Open) dbContext.Database.Connection.Open();
                loginUser = dbContext.Users.Where(u => u.UserName == userName).FirstOrDefault();
                if (loginUser == null)
                {
                    return Tuple.Create(UserLoginStatus.WrongUserName, loginUser);
                }
                else
                {
                    if (loginUser.Password == password)
                    {
                        if (loginUser.IsActivated == true)
                        {
                            return Tuple.Create(UserLoginStatus.Success, loginUser);
                        }
                        else return Tuple.Create(UserLoginStatus.DeActivated, loginUser);
                    }
                    else return Tuple.Create(UserLoginStatus.WrongPassword, loginUser);
                }
            }
            catch (Exception ex)
            {
                cSession.cValues.LastMsg = ex.Message;
                return Tuple.Create(UserLoginStatus.Error, loginUser);
            }
        }

        // Create new User
        /// <summary>
        /// Create User and return two types:
        /// 1-enaum to check if UserName is exists, 2-Guid UserID if result is Success.
        /// </summary>
        /// <param name="userData">UserDTO object must has: EmployeeID, UserName, Password, EditedBy</param>
        /// <returns></returns>
        public Tuple<UserUpdateStatus, Guid> CreateUser(UserDTO userData)
        {
            try
            {
                if (dbContext.Users.Where(e => e.EmployeeID == userData.EmployeeID).Count() > 0)
                {
                    return Tuple.Create(UserUpdateStatus.EmployeeHasUser, Guid.Empty);
                }
                else
                {
                    User checkUser = dbContext.Users.Where(u => u.UserName == userData.UserName).FirstOrDefault();
                    if (checkUser == null)
                    {
                        User newUser = new User()
                        {
                            UserID = Guid.NewGuid(),
                            EmployeeID = userData.EmployeeID,
                            UserName = userData.UserName,
                            Password = userData.Password,
                            AlertProject=3,
                            AlertTask=3,
                            AlertPayment=3,
                            IsActivated = true,
                            IsDeleted = false,
                            CreatedBy = userData.EditedBy,
                            CreatedDate = DateTime.Now,
                            EditedBy = userData.EditedBy,
                            EditedDate = DateTime.Now
                        };
                        dbContext.Users.Add(newUser);
                        dbContext.SaveChanges();
                        return Tuple.Create(UserUpdateStatus.Success, newUser.UserID);
                    }
                    else return Tuple.Create(UserUpdateStatus.UserNameExists, Guid.Empty);
                }
            }
            catch (Exception)
            {
                return Tuple.Create(UserUpdateStatus.Error, Guid.Empty);
            }
        }

        // Update existing user
        public UserUpdateStatus UpdateUser(UserDTO userData)
        {
            try
            {
                User checkUser = dbContext.Users.Where(u => u.UserName == userData.UserName && u.UserID != userData.UserID).FirstOrDefault();
                if (checkUser == null)
                {
                    User user = dbContext.Users.Find(userData.UserID);
                    user.UserName = userData.UserName;
                    user.Password = userData.Password;
                    user.IsActivated = userData.IsActivated;
                    user.EditedBy = userData.EditedBy;
                    user.EditedDate = DateTime.Now;

                    dbContext.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                    return UserUpdateStatus.Success;
                }
                else return UserUpdateStatus.UserNameExists;
            }
            catch (Exception)
            {
                return UserUpdateStatus.Error;
            }
        }

        // Delete user
        public bool DeleteUser(Guid userID, Guid EditedBy)
        {
            try
            {
                User user = dbContext.Users.Find(userID);
                user.IsDeleted = true;
                user.EditedBy = EditedBy;
                user.EditedDate = DateTime.Now;

                dbContext.Entry(user).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Activate/Deactivate user
        public bool ChangeUserActivation(Guid userID, bool isActive, Guid EditedBy)
        {
            try
            {
                User user = dbContext.Users.Find(userID);
                user.IsActivated = isActive;
                user.EditedBy = EditedBy;
                user.EditedDate = DateTime.Now;

                dbContext.Entry(user).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Get all users
        public IEnumerable<UserListDTO> GetAllUsers()
        {
            try
            {
                var usersList = (from users in dbContext.Users
                                 join employees in dbContext.Employees
                                 on users.EmployeeID equals employees.EmployeeID
                                 where users.IsDeleted == false
                                 orderby users.CreatedDate descending
                                 select new UserListDTO
                                 {
                                     UserID = users.UserID,
                                     FullName = employees.FullName,
                                     //UserName = users.UserName,
                                     //UserRole = employees.ValEmployeeRole.RoleText,
                                     //IsActivated = users.IsActivated
                                 }).ToList();
                return usersList;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        // Get User Details by UserID
        public UserDetailsDTO GetUserDetailsByUserID(Guid userID)
        {
            try
            {
                UserDetailsDTO selectedUser = (from users in dbContext.Users
                                               where users.UserID == userID && users.IsDeleted == false
                                               select new UserDetailsDTO
                                               {
                                                   UserID = users.UserID,
                                                   EmployeeID = users.EmployeeID,
                                                   UserName = users.UserName,
                                                   Password = users.Password,
                                                   IsActivated = users.IsActivated,
                                                   CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == users.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                                   CreatedDate = SqlFunctions.DatePart("year", users.CreatedDate) + "-" + SqlFunctions.DatePart("month", users.CreatedDate) + "-" + SqlFunctions.DatePart("day", users.CreatedDate),
                                                   LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == users.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                                   LastEditedDate = SqlFunctions.DatePart("year", users.EditedDate) + "-" + SqlFunctions.DatePart("month", users.EditedDate) + "-" + SqlFunctions.DatePart("day", users.EditedDate)
                                               }).FirstOrDefault();
                return selectedUser;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }

        // Get User Details by EmployeeID
        public UserDetailsDTO GetUserDetailsByEmployeeID(Guid employeeID)
        {
            try
            {
                UserDetailsDTO selectedUser = (from users in dbContext.Users
                                               where users.EmployeeID == employeeID && users.IsDeleted == false
                                               select new UserDetailsDTO
                                               {
                                                   UserID = users.UserID,
                                                   UserName = users.UserName,
                                                   Password = users.Password,
                                                   IsActivated = users.IsActivated,
                                                   CreatedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == users.CreatedBy).Select(e => e.FullName).FirstOrDefault(),
                                                   CreatedDate = SqlFunctions.DatePart("year", users.CreatedDate) + "-" + SqlFunctions.DatePart("month", users.CreatedDate) + "-" + SqlFunctions.DatePart("day", users.CreatedDate),
                                                   LastEditedBy = dbContext.Employees.Where(e => e.Users.Select(u => u.UserID).FirstOrDefault() == users.EditedBy).Select(e => e.FullName).FirstOrDefault(),
                                                   LastEditedDate = SqlFunctions.DatePart("year", users.EditedDate) + "-" + SqlFunctions.DatePart("month", users.EditedDate) + "-" + SqlFunctions.DatePart("day", users.EditedDate)
                                               }).FirstOrDefault();
                return selectedUser;
            }
            catch (Exception ex)
            {
                Global.Log.Error(ex);
                throw;
            }
        }
    }
}