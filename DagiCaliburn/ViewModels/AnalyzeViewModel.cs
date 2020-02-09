using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronXL;
using DagiCaliburn.Models;

namespace DagiCaliburn.ViewModels
{
    class AnalyzeViewModel : Screen
    {
        private bool _showDuplicatesIsVisible = true;
        private List<StudentModel> mouldedStudents = new List<StudentModel>();
        private string _ffile = "";
        

        public string FFile {
            get { return _ffile; }
            set { _ffile = value; NotifyOfPropertyChange(() => FFile); }
        }


        public bool ShowDuplicatesIsVisible
        {
            get { return _showDuplicatesIsVisible; }
            set
            {
                _showDuplicatesIsVisible = value;
                NotifyOfPropertyChange(() => ShowDuplicatesIsVisible);
            }
        }

        public void ShowDuplicatesBtn()
        {
            if (!FFile.Equals("")) {
                //WorkBook wb = WorkBook.Load(FFile);
                //WorkSheet ws = wb.WorkSheets.First();
                //string cellValue = ws["A1"].ToString();
                //Console.WriteLine($"A2: {cellValue}");
                ReadExcel();
                CreateExcel();
            }
            //string k = "Dagmawi Negussu, 0937886725. daginegussu@gmail.com" +
            //    ": Bereket Yohannes, 0912345678, bekijohn@gmail.com";
            //bool ap;
            //List<StudentModel> stus = StudentModel.GetStudents(k,out ap);
            //if (ap)
            //{
            //    foreach(StudentModel st in stus)
            //    {
            //        Console.WriteLine("$$$ "+ st.Name + " : " + st.Phone + " : " + st.Email + " : " + st.Params + " : " + st.Errors);
            //    }
            //}
        }

        private void ReadExcel()
        {
            try
            {
                WorkBook wb = WorkBook.Load(FFile);
                WorkSheet ws = wb.WorkSheets.First();
                foreach (RangeRow row in ws.Rows)
                {
                    if (row.First().Value.ToString().Trim().Equals("Timestamp"))
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("New Row >>  ");
                        List<IronXL.Cell> rowDatas = row.ToList();
                        StudentModel st = new StudentModel(rowDatas[2].Value.ToString(), rowDatas[3].Value.ToString(), rowDatas[1].Value.ToString(), rowDatas[0].Value.ToString(), rowDatas[7].Value.ToString(), rowDatas[8].Value.ToString(), rowDatas[10].Value.ToString(), rowDatas[4].Value.ToString());
                        if (rowDatas[5].Value.ToString().ToLower().Equals("yes"))
                        {
                            st.Type = "Team Leader";
                            st.Team = StudentModel.GetStudents(rowDatas[6].Value.ToString().Trim(), st.Name, out bool ap);
                        }
                        StudentModel tok = st;
                        mouldedStudents.Add(tok);
                        Console.WriteLine("$$$ " + st.Name + " : " + st.Phone + " : " + st.Email + " : " + st.Params + " : " + st.Errors + " : " + st.Timestamp + " : " + st.ShortThoughts + " : " + st.Women + " : " + st.EducationalBG+ " : "+st.Type + " : "+" : "+st.Gender+" : "+st.Team.Count);
                        st = null;
                        
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error : " + e.Message);
            }
        }

        private void CreateExcel()
        {
            string filename = "Data";
            WorkBook wb = WorkBook.Create(ExcelFileFormat.XLSX);
            wb.Metadata.Author = "GDG Filtering Software";
            WorkSheet ws = wb.CreateWorkSheet("Main Sheet");
            int counter = 2;
            string[] headers = new[] { "Type", "TimeStamp", "Email Address", "Full Name", "Phone Number", "Gender",
                "Number of Women", "Educational Background", "Thoughts", "Fully Parsed ? ", "Errors while Parsing" };
            char[] alphas = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' }; 
            for (int i=0; i < 11; i++)
            {
                ws[$"{alphas[i]}{1}"].Value = headers[i];
            }
            foreach(StudentModel student in mouldedStudents)
            {
                ws[$"A{counter}"].Value = student.Type;
                ws[$"B{counter}"].Value = student.Timestamp;
                ws[$"C{counter}"].Value = student.Email;
                ws[$"D{counter}"].Value = student.Name;
                ws[$"E{counter}"].Value = student.Phone;
                ws[$"F{counter}"].Value = student.Gender.ToString();
                ws[$"G{counter}"].Value = student.Women;
                ws[$"H{counter}"].Value = student.EducationalBG;
                ws[$"I{counter}"].Value = student.ShortThoughts;
                ws[$"J{counter}"].Value = student.Params;
                ws[$"K{counter}"].Value = student.Errors;
                if(student.Type.Equals("Team Leader"))
                {
                    Console.WriteLine($"{student.Name}, membs = {student.Team.Count}");
                    for(int mem = 0; mem < student.Team.Count; mem++)
                    {
                        counter++;
                        StudentModel member = student.Team[mem];
                        Console.WriteLine($"Mem: {mem}, {member.Name}");
                        ws[$"A{counter}"].Value = member.Type + " ("+member.TeamLeader+")";
                        ws[$"C{counter}"].Value = member.Email;
                        ws[$"D{counter}"].Value = member.Name;
                        ws[$"E{counter}"].Value = member.Phone;
                        ws[$"J{counter}"].Value = member.Params;
                        ws[$"K{counter}"].Value = member.Errors;
                        member = null;
                    }
                    counter++;
                }
            }

           
            ws["A1:L1"].Style.SetBackgroundColor("#f4efef");
            wb.SaveAs("Data.xlsx");
        }
    }
}