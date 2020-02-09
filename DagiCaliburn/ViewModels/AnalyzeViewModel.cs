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
                //ReadExcel();
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
                        StudentModel st = new StudentModel(rowDatas[2].Value.ToString(), rowDatas[3].Value.ToString(), rowDatas[1].Value.ToString(), rowDatas[0].Value.ToString(), rowDatas[7].Value.ToString(), rowDatas[8].Value.ToString(), rowDatas[10].Value.ToString());
                        Console.WriteLine("$$$ " + st.Name + " : " + st.Phone + " : " + st.Email + " : " + st.Params + " : " + st.Errors+" : "+st.Timestamp+" : "+st.ShortThoughts+" : "+st.Women +" : "+st.EducationalBG);
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
            string[] headers = new[] { "Type", "TimeStamp", "Email Address", "Full Name", "Phone Number", "Gender", "Number of Women", "Educational Background", "Thoughts", "Fully Parsed", "Errors while Parsing" };
            char[] alphas = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' }; 
            for (int i=0; i < 11; i++)
            {
                ws[$"{alphas[i]}{1}"].Value = headers[i];
            }
           
            ws["A1:M1"].Style.SetBackgroundColor("#f4efef");
            wb.SaveAs("Data.xlsx");
        }
    }
}