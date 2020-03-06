using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Data.SQLite;
using System.Configuration;
using System.Data;

namespace DagiCaliburn.Models
{
    class Database
    {
        public MySqlConnection connection { get; }
        private string server;
        private string database;
        private string uid;
        private string password;
        
        public MySqlCommand cmd;
        private Database()
        {
            server = "localhost";
            database = "gdg";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";" + "PORT=3306;";
            connection = new MySqlConnection(connectionString);
            

        }
        public static Database instance = new Database();

        public SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version = 3; New = True; Compress = True; ");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SQLite {ex.Message}");
            }
            return sqlite_conn;
        }


        public bool OpenConnection()
        {
            connection.Close();
            try
            {
                connection.Open();
                //MessageBox.Show("Connection opened");
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");

                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        MessageBox.Show("Failed to Connect, Restart the Database Server");
                        break;
                }
                return false;
            }
        }

        public string LoadConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Failed to close connection");
                return false;
            }
        }


    }
}
