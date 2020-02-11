using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronXL;
using DagiCaliburn.Models;
using System.Windows;
using System.Text.RegularExpressions;
using DagiCaliburn.Views;
using System.IO;

namespace DagiCaliburn.ViewModels
{
    class AnalyzeViewModel : Screen
    {
        private bool _showDuplicatesIsVisible = true;
        private bool _isVisibileSavedWGrid = false;
        private bool _isVisibileAnalyzedWGrid = false;
        private bool _isVisibileAnalyzedRGrid = false;
        private string _isVisibileAnalyzedRText = "";
        private string _isVisibileAnalyzedWText = "";
        private string _destinationText = "";
        private string _fileText = "";
        private bool _isVisibileDropExcel = true;
        private bool _isVisibileSuggestion = false;
        private List<StudentModel> mouldedStudents = new List<StudentModel>();
        private static BindableCollection<StudentModel> _suggestedStus = new BindableCollection<StudentModel>();
        private string _ffile = "";
        private string _dragText = "Drop Excel File here";
        private string _savedText = "";



        public string DragText { get { return _dragText; }
            set { _dragText = value; NotifyOfPropertyChange(() => DragText); } }
        public string SavedText
        {
            get { return _savedText; }
            set { _savedText = value; NotifyOfPropertyChange(() => SavedText); }
        }



        public bool IsVisibileAnalyzedWGrid { get { return _isVisibileAnalyzedWGrid; }
            set { _isVisibileAnalyzedWGrid = value;
                NotifyOfPropertyChange(() => IsVisibileAnalyzedWGrid);
            } }

        public bool IsVisibileAnalyzedRGrid
        {
            get { return _isVisibileAnalyzedRGrid; }
            set
            {
                _isVisibileAnalyzedRGrid = value;
                NotifyOfPropertyChange(() => IsVisibileAnalyzedRGrid);
            }
        }

        public bool IsVisibileSavedWGrid
        {
            get { return _isVisibileSavedWGrid; }
            set
            {
                _isVisibileSavedWGrid = value;
                NotifyOfPropertyChange(() => IsVisibileSavedWGrid);
            }
        }

        public string AnalyzedRText
        {
            get { return _isVisibileAnalyzedRText; }
            set { _isVisibileAnalyzedRText = value; NotifyOfPropertyChange(() => AnalyzedRText); }
        }

        public string DestinationText
        {
            get { return _destinationText; }
            set { _destinationText = value; NotifyOfPropertyChange(() => DestinationText); }
        }

        public BindableCollection<StudentModel> SuggestedStus { get { return _suggestedStus; }
            set { _suggestedStus = value; NotifyOfPropertyChange(() => SuggestedStus); } }

        public string FileText
        {
            get { return _fileText; }
            set { _fileText = value; NotifyOfPropertyChange(() => FileText); }
        }

        public string AnalyzedWText
        {
            get { return _isVisibileAnalyzedWText; }
            set { _isVisibileAnalyzedWText = value; NotifyOfPropertyChange(() => AnalyzedWText); }
        }

        public string FFile
        {
            get { return _ffile; }
            set { _ffile = value; NotifyOfPropertyChange(() => FFile); }
        }

        

        public bool IsVisibileDropExcel
        {
            get { return _isVisibileDropExcel; }
            set
            {
                _isVisibileDropExcel = value;
                NotifyOfPropertyChange(() => IsVisibileDropExcel);
            }
        }

        public bool IsVisibileSuggestion
        {
            get { return _isVisibileSuggestion; }
            set
            {
                _isVisibileSuggestion = value;
                NotifyOfPropertyChange(() => IsVisibileSuggestion);
            }
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

        public void SaveBtn()
        {
            ReadAppsExcel();
            SavedText =  StudentModel.SaveApplicants(mouldedStudents);
            IsVisibileSavedWGrid = true;
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
                bool sugsuc;
                SuggestedStus = new BindableCollection<StudentModel>(Utils.Suggestions(mouldedStudents, out sugsuc));
                
                if (sugsuc)
                {
                    IsVisibileSuggestion = true;
                    IsVisibileDropExcel = false;
                }

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

        public void ClearBtn()
        {
            IsVisibileAnalyzedRGrid = false;
            IsVisibileAnalyzedWGrid = false;
            IsVisibileSavedWGrid = false;
            AnalyzedWText = "";
            SavedText = "";
            AnalyzedRText = "";
            IsVisibileDropExcel = true;
            IsVisibileSuggestion = false;
            FFile = "";
            AnalyzeView.FFile = "";
            DestinationText = "";
            FileText = "";
            SuggestedStus.Clear();
            mouldedStudents.Clear();
            DragText = "Drop Excel File here";
        }

        private void ReadAppsExcel()
        {
            try
            {
                WorkBook wb = WorkBook.Load(FFile);
                WorkSheet ws = wb.WorkSheets.First();
                foreach (RangeRow row in ws.Rows)
                {
                    if (row.First().Value.ToString().Trim().Equals("Type"))
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("New apps Row >>  ");
                        List<IronXL.Cell> rowDatas = row.ToList();
                        StudentModel st;
                        
                            st = new StudentModel(rowDatas[3].Value.ToString(), rowDatas[4].Value.ToString(), rowDatas[2].Value.ToString());
                            
                        
                        StudentModel tok = st;
                        mouldedStudents.Add(tok);
                        Console.WriteLine("$$$ " + st.Name + " : " + st.Phone + " : " + st.Email + " : " + st.Params + " : " + st.Errors );
                        st = null;

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Apps : " + e.Message);
            }
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
                        StudentModel st;  
                        if (rowDatas[5].Value.ToString().ToLower().Equals("yes"))
                        {
                            st = new StudentModel(rowDatas[2].Value.ToString(), rowDatas[3].Value.ToString(), rowDatas[1].Value.ToString(), rowDatas[0].Value.ToString(), rowDatas[7].Value.ToString(),
                                rowDatas[8].Value.ToString(), rowDatas[9].Value.ToString(), rowDatas[4].Value.ToString(),"Team Leader");
                            st.Team = StudentModel.GetStudents(rowDatas[6].Value.ToString().Trim(), st.Name, out bool ap);
                        }
                        else
                        {
                            st = new StudentModel(rowDatas[2].Value.ToString(), rowDatas[3].Value.ToString(), rowDatas[1].Value.ToString(), rowDatas[0].Value.ToString(), rowDatas[7].Value.ToString(), rowDatas[8].Value.ToString(), rowDatas[9].Value.ToString(), rowDatas[4].Value.ToString());
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
            try
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
                for (int i = 0; i < 11; i++)
                {
                    ws[$"{alphas[i]}{1}"].Value = headers[i];


                }
                foreach (StudentModel student in mouldedStudents)
                {
                    Console.WriteLine("MOULDED STUDENT: " + student.Name+", " + student.Type+ " :: "+counter);
                    ws[$"A{counter}"].Value = student.Type;
                    ws[$"B{counter}"].Value = student.Timestamp;
                    ws[$"C{counter}"].Value = student.Email;
                    ws[$"D{counter}"].Value = student.Name;
                    if (student.Phone == 0)
                    {
                        ws[$"E{counter}"].Value = "";
                    }
                    else
                    {
                        ws[$"E{counter}"].Value = student.Phone;
                    }
                    ws[$"F{counter}"].Value = student.Gender.ToString();
                    ws[$"G{counter}"].Value = student.Women;
                    ws[$"H{counter}"].Value = student.EducationalBG;
                    ws[$"I{counter}"].Value = student.ShortThoughts;
                    ws[$"J{counter}"].Value = student.Params;
                    ws[$"K{counter}"].Value = student.Errors;
                    if (student.Errors.Length > 1)
                    {
                        ws[$"K{counter}"].Style.SetBackgroundColor("#e1ff00");
                        if (student.Errors.Contains("THIS APPLICANT HAS COMPETED BEFORE."))
                        {
                            ws.Rows[counter - 1].Style.SetBackgroundColor("#ff0000");
                        }
                        else if (student.Errors.Contains("Invalid Phone Number."))
                        {
                            ws[$"E{counter}"].Style.SetBackgroundColor("#e1ff00");
                        }
                        else if (student.Errors.Contains("Name Parsing Error."))
                        {
                            ws[$"D{counter}"].Style.SetBackgroundColor("#e1ff00");
                        }
                        else if (student.Errors.Contains("Email Parsing Error."))
                        {
                            ws[$"C{counter}"].Style.SetBackgroundColor("#e1ff00");
                        }
                    }
                    if (student.Type.Equals("Team Leader"))
                    {
                        Console.WriteLine($"{student.Name}, membs = {student.Team.Count}");
                        foreach(StudentModel member in student.Team)
                        {
                            ++counter;
                            Console.WriteLine("MOULDED STUDENT: " + student.Name + ", " + student.Type + " :: " + counter);
                            ws[$"A{counter}"].Value = member.Type + " (" + member.TeamLeader + ")";
                            ws[$"C{counter}"].Value = member.Email;
                            ws[$"D{counter}"].Value = member.Name;
                            if (member.Phone == 0)
                            {
                                ws[$"E{counter}"].Value = "";
                            }
                            else
                            {
                                ws[$"E{counter}"].Value = member.Phone;
                            }
                            ws[$"J{counter}"].Value = member.Params;
                            ws[$"K{counter}"].Value = member.Errors;
                            if (member.Errors.Length > 1)
                            {
                                ws[$"K{counter}"].Style.SetBackgroundColor("#e1ff00");
                                if (member.Errors.Contains("THIS APPLICANT HAS COMPETED BEFORE."))
                                {
                                    ws.Rows[counter - 1].Style.SetBackgroundColor("#ff0000");
                                }
                                else if (member.Errors.Contains("Invalid Phone Number."))
                                {
                                    ws[$"E{counter}"].Style.SetBackgroundColor("#e1ff00");
                                }
                                else if (member.Errors.Contains("Name Parsing Error."))
                                {
                                    ws[$"D{counter}"].Style.SetBackgroundColor("#e1ff00");
                                }
                                else if (member.Errors.Contains("Email Parsing Error."))
                                {
                                    ws[$"C{counter}"].Style.SetBackgroundColor("#e1ff00");
                                }
                            }
                           
                        }
                        //counter++;
                    }

                    ++counter;
                }


                ws["A1:L1"].Style.SetBackgroundColor("#c4c4c4");
                if(FileText.Equals(""))
                {
                    if (File.Exists("HackthonData.xlsx"))
                    {
                        ShowMessage($"File Name is Empty and there already exits a Document with the default name 'HacktonData'\n" +
                       $"Delete the old existing Doc, or give the new one another FileName.", 'w');

                    }
                    else
                    {
                        Console.WriteLine($"{FileText}");
                        wb.SaveAs("HackthonData.xlsx");
                        ShowMessage($"File Name is Empty\n" +
                            $"The Analyzed Data has been saved as 'HackthonData.xlsx' in this Program Folder.", 'r');
                    }
                } 
                else
                {
                    
                        if (Regex.IsMatch(FileText.Trim(), @"^[a-zA-z0-9 ]+$")) {
                        if (File.Exists($"{FileText.Trim()}.xlsx"))
                        {
                            ShowMessage($"File Name is Empty and there already exits a Document with the default name 'HacktonData'\n" +
                           $"Delete the old existing Doc, or give the new one another FileName.", 'w');

                        }
                        else
                        {
                            Console.WriteLine($"{FileText}");
                            //Utils.BackToFront(DestinationText + 
                            wb.SaveAs(FileText.Trim() + ".xlsx");
                            ShowMessage($"The Analyzed Data has been saved as '{FileText}.xlsx' in the Specified Destination.", 'r');
                        }
                        }
                        else
                        {
                        if (File.Exists("HackthonData.xlsx"))
                        {
                            ShowMessage($"File Name is Empty and there already exits a Document with the default name 'HacktonData'\n" +
                           $"Delete the old existing Doc, or give the new one another FileName.", 'w');

                        }
                        else
                        {
                            Console.WriteLine($"{FileText}");
                            //wb.SaveAs("Dsaf")
                            //Utils.BackToFront(DestinationText + 
                            wb.SaveAs("HackthonData.xlsx");
                            ShowMessage($"File Name was entered in a Wrong Format\n" +
                        $"The Analyzed Data has been saved as 'Data.xlsx' in the Specified Destination.", 'r');
                        }
                        }
                    
                    
                }
                
            }
            catch(Exception e)
            {
                ShowMessage($"Error Happened. {e.Message}.", 'w');
            }
        }

        private void ShowMessage(string message, char type)
        {
            IsVisibileAnalyzedRGrid = false;
            IsVisibileAnalyzedWGrid = false;
            AnalyzedWText = "";
            AnalyzedRText = "";
            switch (type){
                case 'w':
                    IsVisibileAnalyzedWGrid = true;
                    AnalyzedWText = message;
                    break;
                case 'r':
                    IsVisibileAnalyzedRGrid = true;
                    AnalyzedRText = message;
                    break;
                default:
                    IsVisibileAnalyzedWGrid = true;
                    AnalyzedWText = message;
                    break;
            }
        }
    }
}