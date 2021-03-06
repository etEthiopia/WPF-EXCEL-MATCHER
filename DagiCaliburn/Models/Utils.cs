﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DagiCaliburn.Models
{
    class Utils
    {
        public static string BackToFront(string back)
        {
            string front = "";
            front = back.Replace('\\', '/');
            if (!front.Last().Equals('/'))
            {
                front += "/";
            }
            return front;

        }

        public static List<StudentModel> Suggestions(List<StudentModel> stus, out bool success)
        {
            success = true;
            List<StudentModel> sugesstions = stus;
            try
            {
                foreach (StudentModel student in sugesstions)
                {
                    if (student.Type.Equals("Team Leader") && student.Gender.Equals('F'))
                    {
                        student.Score += 3 + student.Women;
                        if (student.Team.Count > 0)
                        {
                            if (!student.Params)
                            {
                                student.Score -= student.Errors.Trim().Split('.').Length / 2;
                                if (student.Errors.Contains("THIS APPLICANT HAS COMPETED BEFORE."))
                                {
                                    student.Score -= 9;
                                }
                            }
                            foreach (StudentModel smb in student.Team)
                            {
                                if (!smb.Params)
                                {
                                    student.Score -= smb.Errors.Trim().Split('.').Length / 2;
                                    if (smb.Errors.Contains("THIS APPLICANT HAS COMPETED BEFORE."))
                                    {
                                        student.Score -= 5;
                                    }
                                }
                            }
                        }
                    }
                    else if (student.Type.Equals("Team Leader"))
                    {
                        student.Score += student.Women + 1;
                        if (student.Team.Count > 0)
                        {
                            if (!student.Params)
                            {
                                student.Score -= student.Errors.Trim().Split('.').Length / 2;
                                if (student.Errors.Contains("THIS APPLICANT HAS COMPETED BEFORE."))
                                {
                                    student.Score -= 9;
                                }
                            }
                            foreach (StudentModel smb in student.Team)
                            {
                                if (!smb.Params)
                                {
                                    student.Score -= smb.Errors.Trim().Split('.').Length /2;
                                    if (smb.Errors.Contains("THIS APPLICANT HAS COMPETED BEFORE."))
                                    {
                                        student.Score -= 5;
                                    }
                                }
                            }
                        }
                    }
                    else if (student.Type.Equals("Individual") && student.Gender.Equals('F'))
                    {
                        student.Score += 1;
                        if (!student.Params)
                        {
                            student.Score -= student.Errors.Trim().Split('.').Length / 2;
                            if (student.Errors.Contains("THIS APPLICANT HAS COMPETED BEFORE."))
                            {
                                student.Score -= 9;
                            }
                        }
                    }
                    else
                    {
                        if (!student.Params)
                        {
                            student.Score -= student.Errors.Trim().Split('.').Length / 2;
                            if (student.Errors.Contains("THIS APPLICANT HAS COMPETED BEFORE."))
                            {
                                student.Score -= 9;
                            }
                        }
                    }

                    if (student.Type.Equals("Team Leader"))
                    {
                        student.Type = "Team";
                    }

                    
                }
                sugesstions = sugesstions.OrderByDescending(c => c.Score).ToList();
                return sugesstions;
            }
            catch(Exception e)
            {
                success = false;
                return sugesstions;
            }

           
        }


        public static List<OrganizerModel> NextOrgs(int i)
        {
            List<OrganizerModel> organizers = new List<OrganizerModel>();
            int b = 0;
            try
            {
                Random rnd = new Random();
                organizers = OrganizerModel.GetOrgs();
                Console.WriteLine($"COUNTER {i}");
                int hk = organizers[4].Hack;
                
                for(int k =5; k < organizers.Count; k++)
                {
                    if(organizers[k].Hack <= hk)
                    {
                        int op = rnd.Next(0, 5);
                        if (organizers[op].Hack >= organizers[k].Hack) {

                            OrganizerModel tp = organizers[op];
                            organizers[op] = organizers[k];
                            organizers[k] = tp;

                        }
                    }
                }
                
                foreach (OrganizerModel ok in organizers)
                {

                    Console.WriteLine("PURE:" + ok.Name);
                }

                if (i < 2)
                {
                    foreach(OrganizerModel om in organizers)
                    {
                        Console.WriteLine("LOOKING: "+om.Name);
                        if (om.Name.Contains("Bereket Y"))
                        {
                            b = organizers.IndexOf(om);
                            break;
                        }
                    }
                    if(b >= 5 && organizers[b].Hack == 1)
                    {

                        int tk = rnd.Next(0, 5);
                        OrganizerModel tpp = organizers[tk];
                        organizers[tk] = organizers[b];
                        organizers[b] = tpp;
                    }
                    
                    
                }

                int tkt = rnd.Next(3, 5);
                int tkk = rnd.Next(0, 3);
                OrganizerModel tppt = organizers[tkt];
                organizers[tkt] = organizers[tkk];
                organizers[tkk] = tppt;
                return organizers.GetRange(0,5);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Next Orgs Exception {e.Message}");
                return organizers;
            }


            
        }
    }
}
