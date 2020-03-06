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
        
        private Database()
        {
            
            

        }
        public static Database instance = new Database();

       

        public string LoadConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        }

        


    }
}
