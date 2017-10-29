using NLog;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;

namespace UserManagement.DAO
{
    public class SampleConnection
    {

        public SampleConnection() { }

        private static Logger log = LogManager.GetCurrentClassLogger();

        //public MySqlConnection GetConnection()
        //{

        //    log.Info("Get Connection");
        //    MySqlConnection connection = null;

        //    try
        //    {
        //        string connectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        //        connection = new MySqlConnection(connectionString);
        //        if(connection.State == ConnectionState.Closed)
        //            connection.Open();
        //        Console.WriteLine("Connected...");
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message);
        //        Console.WriteLine("Failed...");
        //    }

        //    return connection;

        //}

        public MySqlConnection GetConnection()
        {
            log.Info("Get connection");
            MySqlConnection connection = null;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

            return connection;
        }

        public void Close(MySqlConnection conn)
        {

            if (conn.State == ConnectionState.Open)
                conn.Close();

        }

    }
}