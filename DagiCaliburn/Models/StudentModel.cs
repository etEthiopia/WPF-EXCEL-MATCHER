using System;
using System.Collections.Generic;
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
        private List<StudentModel> _team = new List<StudentModel>();

        public string Name { get { return _name; } set { _name = value; } }
        public int Phone { get { return _phone; } set { _phone = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public bool Params { get { return _params;  } set { _params = value; } }
        public string Errors { get { return _errors; } set { _errors = value; } }
        public List<StudentModel> Team { get { return _team; } set { _team = value; } }

        public static List<StudentModel> GetStudents(string k, out bool ap)
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

                        if (attr.Trim().Contains("09") && attr.Trim().Length == 10 && !attr.Contains('@'))
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
    }
}
