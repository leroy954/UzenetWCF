using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UzenetKuldo.DatabaseManager
{
    public class DBManager
    {
        private const string connectionString = "SERVER = localhost;" +
                          "DATABASE= uzenetkuldo;" +
                          "UID = root;" +
                          "PASSWORD =;";

        public MySqlConnection OpenDB()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            return conn;
        }
    }
}