using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DagiCaliburn.Models
{
    class StudentModel
    {
        private string _name = "";
        private int _phone = 0;
        private string _email = "";
        private bool _params = true;
        private string _errors = "";
        private string _timestamp = "";
        private int _women = 0;
        private string _educationalbg = "";
        private string _shortthoughts = "";
        private string _teamleader = "";
        private string _type = "Individual";
        private char _gender;
        private int _score = 0;
        private List<StudentModel> _team = new List<StudentModel>();

        public string Name { get { return _name; } set { _name = value; } }
        public int Phone { get { return _phone; } set { _phone = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public bool Params { get { return _params; } set { _params = value; } }
        public string Errors { get { return _errors; } set { _errors = value; } }
        public string Timestamp { get { return _timestamp; } set { _timestamp = value; } }
        public int Women { get { return _women; } set { _women = value; } }
        public string EducationalBG { get { return _educationalbg; } set { _educationalbg = value; } }
        public string ShortThoughts { get { return _shortthoughts; } set { _shortthoughts = value; } }
        public string TeamLeader { get { return _teamleader; } set { _teamleader = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public char Gender { get { return _gender; } set { _gender = value; } }
        public int Score { get { return _score; } set { _score = value; } }
        public int HackV { get; set; }
        public string ph { get; set; }

        public List<StudentModel> Team { get { return _team; } set { _team = value; } }

        public StudentModel() { }

        
        

        public StudentModel(string email, int hack, int phone = 0, string name = "")
        {
            Email = email;
            if (phone.Equals(0))
            {
                ph = null;
            }
            else
            {
                ph = phone.ToString();
            }
            Name = name;
            HackV = hack;

        }

        public StudentModel(string name, string phone, string email)
        {
            if (Regex.IsMatch(name.Trim(), @"^[a-zA-z ]+$"))
            {
                Console.WriteLine($"Name Added: {name.Trim()}");
                Name = name.Trim();
            }
            else
            {
                Params = false;
                string errors = "Name Parsing Error. " + Errors;
                Errors = errors;
                Console.WriteLine($"Name.Length = 0 : {Params} : {Errors}");
            }

            if (phone.Trim().Contains("9") && phone.Trim().Length <= 10 && phone.Trim().Length >= 9 && !phone.Contains('@'))
            {
                var isPhone = 0;
                if (int.TryParse(phone, out isPhone))
                {
                    if (isPhone > 0)
                    {
                        Phone = isPhone;
                        Console.WriteLine($"Phone Added: {isPhone}");
                    }
                }
                else
                {
                    Params = false;
                    string errors = "Invalid Phone Number. " + Errors;
                    Errors = errors;
                    Console.WriteLine($"Phone Error : {Params} : {Errors}");
                }
            }
            else
            {
                Params = false;
                string errors = "Invalid Phone Number. " + Errors;
                Errors = errors;
                Console.WriteLine($"Phone Error : {Params} : {Errors}");
            }





            if (email.Contains('@') && email.Contains('.') && !email.Trim().Contains(" "))
            {
                Email = email.Trim();
                Console.WriteLine($"Email Added: {email.Trim()}");
            }
            else
            {
                Params = false;
                string errors = "Email Parsing Error. " + Errors;
                Errors = errors;
                Console.WriteLine($"Email Error : {Params} : {Errors}");
            }

            
            if (StudentModel.CheckForDuplicate(Email))
            {
                Params = false;
                string errors = "THIS APPLICANT HAS COMPETED BEFORE. " + Errors;
                Errors = errors;
                Console.WriteLine($"Dup APPLICANT Error : {Params} : {Errors}");
            }

        }

        public StudentModel(string name, string phone, string email, string timestamp, string women, string edbg, string thoughts, string gender, string type = "Individual")
        {
            if(Regex.IsMatch(name.Trim(), @"^[a-zA-z ]+$"))
            {
                Console.WriteLine($"Name Added: {name.Trim()}");
                Name = name.Trim();
            }
            else
            {
                Params = false;
                string errors = "Name Parsing Error. " + Errors;
                Errors = errors;
                Console.WriteLine($"Name.Length = 0 : {Params} : {Errors}");
            }

            if (phone.Trim().Contains("9") && phone.Trim().Length <= 10 && phone.Trim().Length >= 9 && !phone.Contains('@'))
            {
                var isPhone = 0;
                if (int.TryParse(phone, out isPhone))
                {
                    if (isPhone > 0)
                    {
                        Phone = isPhone;
                        Console.WriteLine($"Phone Added: {isPhone}");
                    }
                }
                else
                {
                    Params = false;
                    string errors = "Invalid Phone Number. " + Errors;
                    Errors = errors;
                    Console.WriteLine($"Phone Error : {Params} : {Errors}");
                }
            }
            else
            {
                Params = false;
                string errors = "Invalid Phone Number. " + Errors;
                Errors = errors;
                Console.WriteLine($"Phone Error : {Params} : {Errors}");
            }

            



            if (email.Contains('@') && email.Contains('.') && !email.Trim().Contains(" "))
            {
                Email = email.Trim();
                Console.WriteLine($"Email Added: {email.Trim()}");
            }
            else
            {
                Params = false;
                string errors = "Email Parsing Error. " + Errors;
                Errors = errors;
                Console.WriteLine($"Email Error : {Params} : {Errors}");
            }

            if(Regex.IsMatch(women.Trim(), @"^[0-9]+$"))
            {
                int isPhone;
                if (int.TryParse(women.Trim(), out isPhone))
                {
                    if (isPhone > 0)
                    {
                        if (type.Equals("Team Leader")) {
                            Women = isPhone;
                            Console.WriteLine($"Women Added: {isPhone}");
                        }
                        
                    }
                }
            }

            else
            {
                Console.WriteLine($"Women Error, Set to '0' by default");
            }

            

            EducationalBG = edbg;
            ShortThoughts = thoughts;
            Timestamp = timestamp;
            char g = '-';
            char.TryParse(gender.ToUpper(), out g);
            Gender = g;
            
            Type = type;
            if(Type.Equals("Individual") && Gender.Equals('F'))
            {
                Women = 1;
            }
            if (StudentModel.CheckForDuplicate(Email)){
                Params = false;
                string errors = "THIS APPLICANT HAS COMPETED BEFORE. " + Errors;
                Errors = errors;
                Console.WriteLine($"Dup APPLICANT Error : {Params} : {Errors}");
            }
            
        }

        public static List<StudentModel> GetStudents(string k, string teamleadername, out bool ap)
        {
            ap = true;
            List<StudentModel> students = new List<StudentModel>();
            try
            {
                string[] studentsString = k.Split(':');
                Console.WriteLine($"Students: {studentsString.Length}");
                foreach (string stustr in studentsString)
                {
                    Console.WriteLine($"Examining: {stustr}");
                    string[] studInfo = stustr.Split(',');
                    StudentModel stu = new StudentModel();
                    stu.TeamLeader = teamleadername;
                    stu.Type = "TM";
                    if (studInfo.Length == 0)
                    {
                        stu.Params = false;
                        stu.Errors = $"No attributes Entered";
                        Console.WriteLine($"Length = 0 : {stu.Params} : {stu.Errors}");
                        break;
                    }

                    else if (studInfo.Length < 3)
                    {
                        stu.Params = false;
                        stu.Errors = $"Only {studInfo.Length} attributes Entered.";
                        Console.WriteLine($"Length < 3 : {stu.Params} : {stu.Errors}");
                    }
                    else if (studInfo.Length > 3)
                    {
                        stu.Params = false;
                        stu.Errors = $"Attribute Errors.";
                        Console.WriteLine($"Length > 3 : {stu.Params} : {stu.Errors}");
                        StudentModel ck = stu;
                        students.Add(ck);
                        continue;
                    }
                    foreach (string attr in studInfo)
                    {

                        if (attr.Trim().Contains("9") && attr.Trim().Length <= 10 && attr.Trim().Length >=9 && !attr.Contains('@'))
                        {
                            var isPhone = 0;
                            if (int.TryParse(attr, out isPhone))
                            {
                                if (isPhone > 0)
                                {
                                    stu.Phone = isPhone;
                                    Console.WriteLine($"Phone Added: {isPhone}");
                                }
                            }
                            else
                            {
                                stu.Params = false;
                                string errors = "Invalid Phone Number. " + stu.Errors;
                                stu.Errors = errors;
                                Console.WriteLine($"Phone Error : {stu.Params} : {stu.Errors}");
                            }
                        }
                        else if (attr.Contains('@') && attr.Contains('.') && !attr.Trim().Contains(" "))
                        {
                            stu.Email = attr.Trim();
                            Console.WriteLine($"Email Added: {attr.Trim()}");
                            if (StudentModel.CheckForDuplicate(stu.Email))
                            {
                                stu.Params = false;
                                string errors = "THIS APPLICANT HAS COMPETED BEFORE. " + stu.Errors;
                                stu.Errors = errors;
                                Console.WriteLine($"Dup APPLICANT Error : {stu.Params} : {stu.Errors}");
                            }
                        }
                        else if (attr.Length > 3 && Regex.IsMatch(attr.Trim(), @"^[a-zA-z ]+$"))
                        {
                            stu.Name = attr.Trim();
                            Console.WriteLine($"Name Added: {attr.Trim()}");
                        }
                        else
                        {
                            Console.WriteLine($"On Else");
                            continue;
                        }
                    }
                    if (stu.Name.Length == 0)
                    {
                        stu.Params = false;
                        string errors = "Name Parsing Error. " + stu.Errors;
                        stu.Errors = errors;
                        Console.WriteLine($"Name.Length = 0 : {stu.Params} : {stu.Errors}");
                    }
                    if (stu.Email.Length == 0)
                    {
                        stu.Params = false;
                        string errors = "Email Parsing Error. " + stu.Errors;
                        stu.Errors = errors;
                        Console.WriteLine($"Email.Length = 0 : {stu.Params} : {stu.Errors}");
                        
                        
                    }
                    

                    Console.WriteLine($"All is Good, about to be Added");
                    StudentModel c = stu;
                    students.Add(c);

                }

                return students;
            }
            catch (Exception e) {
                ap = false;
                Console.WriteLine($"Error Happened, Message = {e.Message}");
                return students;
            }
        }

        public static string SaveApplicants(List<StudentModel> apps)
        {
            string issues = "";
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(Database.instance.LoadConnectionString()))
                {
                    foreach (StudentModel sk in apps)
                    {
                        string fname = sk.Name;
                        string silk = sk.Phone.ToString();
                        if (sk.Phone == 0)
                        {
                            silk = "No Phone";
                        }
                        if (sk.Name.Equals(""))
                        {
                            fname = "No Name";
                        }

                        if (!sk.Params)
                        {
                            if (sk.Errors.Contains("THIS APPLICANT HAS COMPETED BEFORE."))
                            {
                                issues += $"Error: {fname}, {silk} has Competed Before.\n";
                                continue;
                            }
                            else if (sk.Errors.Contains("Email Parsing Error."))
                            {
                                issues += $"Error: {fname}, {silk} has no appropriate Email.\n";
                                continue;
                            }
                        }
                        try
                        {
                            cnn.Execute("insert into competetors (email,phone,name) values (@Email,@Phone,@Name)", sk);
                            Console.WriteLine($"SaveApplicants Org: {sk.Name}");
                            issues += $"Success: {fname}, {silk} has been Saved.\n";
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"SAVE Error: {e.Message}");
                            issues += $"Error: {fname}, {silk} Saving Error Occured.\n";
                            continue;
                        }
                    }
                    return issues;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"General SaveApplicants Error: {e.Message}");
                return issues;
            }
            
        }

        public static bool CheckForDuplicate(string email)
        {

                bool dup = false;
                try
                {
                using (IDbConnection cnn = new SQLiteConnection(Database.instance.LoadConnectionString()))
                {
                    var output = cnn.Query<string>($"select COUNT(number) from competetors WHERE email = '{email}'").AsList();
                    Console.WriteLine($"DUP COUNT: {output[0]}");
                    
                    if(int.Parse(output[0]) > 0)
                    {
                        dup = true;
                    }
                    

                }

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Duplicate Exception: {e.Message}");
                
            }

                return dup;
            
        }

        public static bool SavetoSQLite(StudentModel[] mysqlmodel)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(Database.instance.LoadConnectionString()))
                {
                    foreach (StudentModel stu in mysqlmodel)
                    {
                        cnn.Execute("insert into organizers (name, hack) values (@Email,@HackV)", stu);
                        Console.WriteLine($"SavetoSQLite Org: {stu.Name}");
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine($"SavetoSQLite Error: {e.Message}");
                return false;
            }

            
        }
    }
}
