using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace RegisteredAnalytics.Models
{
    public class AppUser : IUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public AppUser[] ListOfUsers { get; set; }
        public bool AddUser(string userName, string password)
        {
            try
            {
                AppUser user = new AppUser();
                user.UserName = userName;
                user.Password = password;
                ListOfUsers.Append(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool VerifyUser(string userName, string password, out string id)
        {
            try
            {
                id = (from cust in ListOfUsers
                     where cust.UserName == userName
                     select cust.Id).ToString();
                return ListOfUsers.Any(u => u.UserName == userName && u.Password == password);
            }
            catch (Exception)
            {
                id = "0";
                return false;
            }
        }
        public AppUser[] UpdateUser(AppUser objUser) {
            try
            {
                foreach (AppUser user in ListOfUsers)
                {
                    if (user.Id == objUser.Id) {
                        user.UserName = objUser.UserName;
                        user.Password = objUser.Password;
                    }
                }
                return ListOfUsers;
            }
            catch (Exception) {
                return ListOfUsers;
            }
        }
        //Storing values in cookies as we are not using db
        public void initUserData()
        {
            ListOfUsers = new AppUser[] {
            new AppUser {
                Id = Guid.NewGuid().ToString(),
                UserName = "soumya",
                Password = "123456"
            },
            new AppUser {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin",
                Password = "8989"
            },
            new AppUser {
                Id = Guid.NewGuid().ToString(),
                UserName = "prasad",
                Password = "000"
            },
            new AppUser {
                Id = Guid.NewGuid().ToString(),
                UserName = "harry",
                Password = "000"
            },
            new AppUser {
                Id = Guid.NewGuid().ToString(),
                UserName = "Styles",
                Password = "000"
            },
            new AppUser {
                Id = Guid.NewGuid().ToString(),
                UserName = "louis",
                Password = "000"
            }

        };
    }
    }
}
