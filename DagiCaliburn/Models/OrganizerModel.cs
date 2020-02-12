using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DagiCaliburn.Models
{
    class OrganizerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hack { get; set; }

        public static List<string> GetOrgsList()
        {
            List<string> orgs = new List<string>();


            string query = $"SELECT Name from organizers";
            
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, Database.instance.connection);

                Database.instance.OpenConnection();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    orgs.Add(reader["Name"].ToString());

                }
                Database.instance.CloseConnection();


            }
            catch (Exception e)
            {
                Console.WriteLine($"Get Orgs Exception, {e.Message}");
                Database.instance.CloseConnection();
            }

            return orgs;

        }

    }
}
