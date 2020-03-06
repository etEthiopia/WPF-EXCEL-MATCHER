using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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


            //string query = $"SELECT Name from organizers";
            
            try
            {
                //MySqlCommand cmd = new MySqlCommand(query, Database.instance.connection);

                //Database.instance.OpenConnection();

                //MySqlDataReader reader = cmd.ExecuteReader();

                //while (reader.Read())
                //{

                //    orgs.Add(reader["Name"].ToString());

                //}
                //Database.instance.CloseConnection();

                using (IDbConnection cnn = new SQLiteConnection(Database.instance.LoadConnectionString()))
                {
                    var output = cnn.Query<string>($"SELECT name from organizers").ToList();
                    Console.WriteLine("ORGS: " + output.Count);
                    orgs = output;


                }


            }
            catch (Exception e)
            {
                Console.WriteLine($"Get Orgs Exception, {e.Message}");
                //Database.instance.CloseConnection();
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
                using (IDbConnection cnn = new SQLiteConnection(Database.instance.LoadConnectionString()))
                {
                    var output = cnn.Query<OrganizerModel>($"SELECT * from organizers WHERE Name='{name}' LIMIT 1", new DynamicParameters());
                    //Console.WriteLine($"GET ORG: {output.ToList()[0]}");

                    om = output.ToList()[0];


                }
                


            }
            catch (Exception e)
            {
                Console.WriteLine($"Get Org by Name Exception, {e.Message}");
                
            }

            return om;
        }

        public static string AddOrg(string name)
        {
            string response = "true";

            
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(Database.instance.LoadConnectionString()))
                {
                    OrganizerModel org = new OrganizerModel();
                    org.Name = name;
                        cnn.Execute($"insert into organizers (name) values (@Name)", org);
                        Console.WriteLine($"Add Org: {name}");
                    
                }
                


            }
            catch (Exception e)
            {
                Console.WriteLine($"Insert Org by Name Exception, {e.Message}");
                response = e.Message;
                
            }

            return response;
        }

        public static string UpdateOrg(int id, string name, int hacks)
        {
            string response = "true";

            
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(Database.instance.LoadConnectionString()))
                {
                    cnn.Execute($"UPDATE organizers SET Name ='{name}', hack={hacks} WHERE id = {id}");
                    Console.WriteLine($"Update Org: {id}: {name}");

                }
                


            }
            catch (Exception e)
            {
                Console.WriteLine($"Update Org by Name Exception, {e.Message}");
                response = e.Message;
                
            }

            return response;
        }


        public static string DeleteOrg(int id)
        {
            string response = "true";

            
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(Database.instance.LoadConnectionString()))
                {
                    cnn.Execute($"delete from organizers where id = {id}");
                    Console.WriteLine($"Delete Org: {id}");

                }
                


            }
            catch (Exception e)
            {
                Console.WriteLine($"Delete Org by Name Exception, {e.Message}");
                response = e.Message;
                
            }

            return response;
        }

        public static List<OrganizerModel> GetOrgs(string order = "ASC")
        {
            List<OrganizerModel> orgs = new List<OrganizerModel>();


            
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(Database.instance.LoadConnectionString()))
                {
                    var output = cnn.Query<OrganizerModel>($"SELECT * from organizers ORDER BY hack {order}", new DynamicParameters()).ToList();
                    
                    orgs = output;


                }
               


            }
            catch (Exception e)
            {
                Console.WriteLine($"Get Orgs Exception, {e.Message}");
                
            }

            return orgs;

        }

        public static string SetNextOrgs(List<OrganizerModel> next){

            string response = "true";

            
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(Database.instance.LoadConnectionString()))
                {
                    for(int j =0;  j < 5; j++)
                    {
                        //next[j].hp = next[j].Hack + 1;
                        cnn.Execute($"UPDATE organizers SET hack={next[j].Hack+1} WHERE id = {next[j].Id}");
                        //cnn.Execute($"insert into organizers (id,hack) values (@Id,@hp)", next[j]);
                        Console.WriteLine($"SetNetOrgs Org: {next[j].Id}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Update Next Org by Name Exception, {e.Message}");
                response = e.Message;
                
            }
            return response;
        }

    }
}
