using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UserManagement.DAO
{
    public interface IDataService
    {

        void Insert(string query);
        void Update(string query);
        void Delete(string query);
        MySqlDataReader Select(string query);




    }
}