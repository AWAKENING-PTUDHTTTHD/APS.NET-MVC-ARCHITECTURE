using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagement.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string salt { get; set; }
        public string password { get; set; }

        public DateTime created_at { get; set; }
    }
}