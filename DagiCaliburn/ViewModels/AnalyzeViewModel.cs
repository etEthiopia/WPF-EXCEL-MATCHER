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
                WorkBook wb = WorkBook.Load(FFile);
                WorkSheet ws = wb.WorkSheets.First();
                string cellValue = ws["A1"].ToString();
                Console.WriteLine($"A2: {cellValue}");

            }
            string k = "Dagmawi Negussu, 0937886725. daginegussu@gmail.com" +
                ": Bereket Yohannes, 0912345678, bekijohn@gmail.com";
            bool ap;
            List<StudentModel> stus = StudentModel.GetStudents(k,out ap);
            if (ap)
            {
                foreach(StudentModel st in stus)
                {
                    Console.WriteLine("$$$ "+ st.Name + " : " + st.Phone + " : " + st.Email + " : " + st.Params + " : " + st.Errors);
                }
            }
        }
    }
}