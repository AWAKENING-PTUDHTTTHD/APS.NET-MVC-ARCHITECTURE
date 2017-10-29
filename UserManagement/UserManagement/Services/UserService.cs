using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManagement.DAO;
using UserManagement.Models;

namespace UserManagement.Services
{
    public class UserService : IUserService
    {
        public double getSpentTimeSinceRegisterDay(string usernameOrEmail)
        {
            DataService data = new DataService();
            string query = string.Format("SELECT * FROM User where email = '{0}' OR username = '{0}' ", usernameOrEmail);
            User u = null;
            using (MySqlDataReader rd = data.Select(query))
            {

                while (rd.Read())
                {
                    u = new User()
                    {
                        id = Convert.ToInt32(rd["id"].ToString()),
                        name = rd["name"].ToString(),
                        username = rd["username"].ToString(),
                        email = rd["email"].ToString(),
                        phone = rd["phone"].ToString(),
                        address = rd["address"].ToString(),
                        created_at = Convert.ToDateTime(rd["created_at"].ToString())
                    };
                }

            }
            if (u != null)
            {
                return -1;

            }


            else
            {
                //return HeplerClass.Hepler.getTotalDaysBetween(DateTime.Now(), u.created_At)
                return 1;
            }
            
        }
        public User UserLogin(string email_or_username, string Input_password)
        {
            DataService data = new DataService();
            string query = string.Format("SELECT * FROM User where email = '{0}' OR username = '{0}' ", email_or_username);
            User u = null;
            using (MySqlDataReader rd = data.Select(query))
            {

                while (rd.Read())
                {
                    u = new User()
                    {
                        id = Convert.ToInt32(rd["id"].ToString()),
                        name = rd["name"].ToString(),
                        username = rd["username"].ToString(),
                        email = rd["email"].ToString(),
                        phone = rd["phone"].ToString(),
                        address = rd["address"].ToString()
                    };
                }

            }
            if(u != null)
            {
                if(HeplerClass.Hepler.EncryptPassword(Input_password, u.salt) == u.password)
                {
                    return u;
                }
            }
            return null;
        }
        public void AddUser(User u)
        {
            //throw new NotImplementedException();
            DataService data = new DataService();
            string insertStr = string.Format(@"INSERT INTO USER(name, username, email, phone, address, salt, password)
                                            VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                                            u.name,
                                            u.username,
                                            u.email,
                                            u.phone,
                                            u.address,
                                            u.salt,
                                            u.password
                                            );
            data.Insert(insertStr);
        }

        public void DeleteUser(User u)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetAll(string keyWord = "")
        {
            //throw new NotImplementedException();
            DataService data = new DataService();

            IList<User> listUser = new List<User>();

            using (MySqlDataReader rd = data.Select("SELECT * FROM User"))
            {

                while (rd.Read())
                {
                    User u = new User()
                    {
                        id = Convert.ToInt32(rd["id"].ToString()),
                        name = rd["name"].ToString(),
                        username = rd["username"].ToString(),
                        email = rd["email"].ToString(),
                        phone = rd["phone"].ToString(),
                        address = rd["address"].ToString()
                    };

                    listUser.Add(u);
                }

            }

            return listUser;
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User u)
        {
            throw new NotImplementedException();
        }
    }
}