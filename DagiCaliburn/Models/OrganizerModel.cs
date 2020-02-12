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

        public OrganizerModel() { }

        public OrganizerModel(int id, string name, int hack)
        {
            this.Id = id;
            this.Name = name;
            this.Hack = hack;
        }

        public static OrganizerModel GetOrg(string name)
        {
            OrganizerModel om = new OrganizerModel();
            string query = $"SELECT * from organizers WHERE Name='{name}' LIMIT 1";

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, Database.instance.connection);

                Database.instance.OpenConnection();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    om.Id =  int.Parse(reader["id"].ToString());
                    om.Name = reader["Name"].ToString();
                    om.Hack = int.Parse(reader["hacks"].ToString());

                }
                Database.instance.CloseConnection();


            }
            catch (Exception e)
            {
                Console.WriteLine($"Get Org by Name Exception, {e.Message}");
                Database.instance.CloseConnection();
            }

            return om;
        }

        public static string AddOrg(string name)
        {
            string response = "true";

            string query = $"INSERT INTO organizers (Name) VALUES('{name}')";

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, Database.instance.connection);

                Database.instance.OpenConnection();

                cmd.ExecuteNonQuery();

               
                Database.instance.CloseConnection();


            }
            catch (Exception e)
            {
                Console.WriteLine($"Insert Org by Name Exception, {e.Message}");
                response = e.Message;
                Database.instance.CloseConnection();
            }

            return response;
        }

        public static string UpdateOrg(int id, string name, int hacks)
        {
            string response = "true";

            string query = $"UPDATE organizers SET Name ='{name}', hacks={hacks} WHERE id = {id}";

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, Database.instance.connection);

                Database.instance.OpenConnection();

                cmd.ExecuteNonQuery();


                Database.instance.CloseConnection();


            }
            catch (Exception e)
            {
                Console.WriteLine($"Update Org by Name Exception, {e.Message}");
                response = e.Message;
                Database.instance.CloseConnection();
            }

            return response;
        }


        public static string DeleteOrg(int id)
        {
            string response = "true";

            string query = $"DELETE FROM organizers WHERE id = {id}";

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, Database.instance.connection);

                Database.instance.OpenConnection();

                cmd.ExecuteNonQuery();

                Database.instance.CloseConnection();


            }
            catch (Exception e)
            {
                Console.WriteLine($"Delete Org by Name Exception, {e.Message}");
                response = e.Message;
                Database.instance.CloseConnection();
            }

            return response;
        }

        public static List<OrganizerModel> GetOrgs(string order = "ASC")
        {
            List<OrganizerModel> orgs = new List<OrganizerModel>();


            string query = $"SELECT * from organizers ORDER BY hacks {order}";

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, Database.instance.connection);

                Database.instance.OpenConnection();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    orgs.Add(new OrganizerModel(int.Parse(reader["id"].ToString()), reader["Name"].ToString(), int.Parse(reader["hacks"].ToString())));

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

        public static string SetNextOrgs(List<OrganizerModel> next){

            string response = "true";

            string query = $"INSERT INTO organizers (id, hacks) VALUES ({next[0].Id}, {next[0].Hack +1})," +
                $"({next[1].Id}, {next[1].Hack +1})," +
                $"({next[2].Id}, {next[2].Hack +1})," +
                $"({next[3].Id}, {next[3].Hack +1})," +
                $"({next[4].Id}, {next[4].Hack +1})" +
                $"ON DUPLICATE KEY UPDATE id = VALUES(id), hacks = VALUES(hacks)";

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, Database.instance.connection);

                Database.instance.OpenConnection();

                cmd.ExecuteNonQuery();


                Database.instance.CloseConnection();

            }
            catch (Exception e)
            {
                Console.WriteLine($"Update Next Org by Name Exception, {e.Message}");
                response = e.Message;
                Database.instance.CloseConnection();
            }
            return response;
        }

    }
}
