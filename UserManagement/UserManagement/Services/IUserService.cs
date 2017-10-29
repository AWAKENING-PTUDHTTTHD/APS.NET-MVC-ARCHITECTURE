using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Services
{
    interface IUserService
    {

        void AddUser(User u);
        void UpdateUser(User u);
        void DeleteUser(User u);
        User GetUser(int id);
        User UserLogin(string email_or_username, string Input_password);
        IList<User> GetAll(string keyWord = "");

    }
}
