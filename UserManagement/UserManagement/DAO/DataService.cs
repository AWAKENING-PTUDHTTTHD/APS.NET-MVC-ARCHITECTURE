using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NLog;
using MySql.Data.MySqlClient;

namespace UserManagement.DAO
{
    public class DataService : IDataService
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        public void Delete(string query)
        {
            throw new NotImplementedException();
        }

        public void Insert(string query)
        {
            //throw new NotImplementedException();
            SampleConnection sample = new SampleConnection();
            MySqlConnection conn = sample.GetConnection();
            log.Info("Create...");
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            sample.Close(conn);
            return;
        }


        public MySqlDataReader Select(string query)
        {
            SampleConnection sample = new SampleConnection();
            MySqlConnection conn = sample.GetConnection();
            log.Info("Select...");
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            MySqlDataReader rd = cmd.ExecuteReader();
            sample.Close(conn);
            return rd;
        }

        public void Update(string query)
        {
            throw new NotImplementedException();
        }
    }
}