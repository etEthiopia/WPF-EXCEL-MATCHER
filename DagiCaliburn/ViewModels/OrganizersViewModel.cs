using Caliburn.Micro;
using DagiCaliburn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DagiCaliburn.ViewModels
{
    class OrganizersViewModel : Screen
    {
        private string _selectedOrg;
        private string _orgHacksText;
        private List<string> _orgs;
        private string _orgNameText;
        private bool New = false;
        private bool _orgIsVisible = false;
        private bool _isVisibileSavedWGrid = false;
        private bool _isVisibileSavedRGrid = false;
        private bool _deleteOrgGridIsVisible = false;
        private bool _saveOrgGridIsVisible = false;
        private bool _hacksIsVisibile = false;
        private string _savedRText = "";
        private string _savedWText = "";

        public OrganizerModel org = new OrganizerModel();


        public string OrgNameText { get { return _orgNameText; }
            set { _orgNameText = value;
                NotifyOfPropertyChange(() => OrgNameText);
            } }

        public string OrgHacksText
        {
            get { return _orgHacksText; }
            set
            {
                _orgHacksText = value;
                NotifyOfPropertyChange(() => OrgHacksText);
            }
        }

        public bool OrgGridIsVisible { get { return _orgIsVisible; } set { _orgIsVisible = value; NotifyOfPropertyChange(() => OrgGridIsVisible); } }

        public string SelectedOrg { get { return _selectedOrg; }
            set { _selectedOrg = value; NotifyOfPropertyChange(() => SelectedOrg); }
        }

        public bool IsVisibileSavedRGrid
        {
            get { return _isVisibileSavedRGrid; }
            set
            {
                _isVisibileSavedRGrid = value;
                NotifyOfPropertyChange(() => IsVisibileSavedRGrid);
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

        public bool SaveOrgGridIsVisible { get { return _saveOrgGridIsVisible; }
            set { _saveOrgGridIsVisible = value;
                NotifyOfPropertyChange(() => SaveOrgGridIsVisible);
            } }

        public bool DeleteOrgGridIsVisible
        {
            get { return _deleteOrgGridIsVisible; }
            set
            {
                _deleteOrgGridIsVisible = value;
                NotifyOfPropertyChange(() => DeleteOrgGridIsVisible);
            }
        }

        public string SavedRText
        {
            get { return _savedRText; }
            set { _savedRText = value; NotifyOfPropertyChange(() => SavedRText); }
        }

        public string SavedWText
        {
            get { return _savedWText; }
            set { _savedWText = value; NotifyOfPropertyChange(() => SavedWText); }
        }

        public bool HacksIsVisibile
        {
            get { return _hacksIsVisibile; }
            set { _hacksIsVisibile = value; NotifyOfPropertyChange(() => HacksIsVisibile); }
        }

        









        public List<string> Organizers
        {
            get { return _orgs; }
            set { _orgs = value; NotifyOfPropertyChange(() => Organizers); }
        }

        public OrganizersViewModel()
        {
            Organizers = OrganizerModel.GetOrgsList();
        }


        public void AddBtn()
        {
            CloseOrg();
            New = true;
            OrgGridIsVisible = true;
            SaveOrgGridIsVisible = true;
            DeleteOrgGridIsVisible = false;
            HacksIsVisibile = false;

        }

        public void SaveBtn()
        {
            if (New)
            {
                string message = OrganizerModel.AddOrg(OrgNameText);
                if (message.Equals("true"))
                {
                    ShowMessage("Organizer has been Added Successfuly", 'r');
                }
                else
                {
                    ShowMessage($"Error: {message}", 'w');
                }
            }
            else
            {
                try
                {
                    string message = OrganizerModel.UpdateOrg(org.Id, OrgNameText, int.Parse(OrgHacksText));
                    if (message.Equals("true"))
                    {
                        ShowMessage("Organizer has been Updated Successfuly", 'r');
                    }
                    else
                    {
                        if(message.Contains("Duplicate entry"))
                        {
                            message = $"{OrgNameText} is already there.";
                        }
                        ShowMessage($"Error: {message}", 'w');
                    }
                }
                catch(Exception e)
                {
                    ShowMessage($"Error: Please Check the Fields", 'w');
                }
            }
            
            OrgGridIsVisible = true;
        }

        public void DeleteBtn()
        {
            string message = OrganizerModel.DeleteOrg(org.Id);
            if (message.Equals("true"))
            {
                ShowMessage("Organizer has been Deleted Successfuly", 'r');

            }
            else
            {
                ShowMessage($"Error: {message}", 'w');
            }
            
            OrgGridIsVisible = true;
        }

        private void ShowMessage(string message, char type)
        {
            Console.WriteLine($"Message: {message} : {type}");
            
            IsVisibileSavedWGrid = false;
            IsVisibileSavedRGrid = false;
            SavedWText = "";
            SavedRText = "";
            switch (type)
            {
                case 'w':
                    IsVisibileSavedWGrid = true;
                    SavedWText = message;
                    break;
                case 'r':
                    IsVisibileSavedRGrid = true;
                    SavedRText = message;
                    break;
                default:
                    IsVisibileSavedWGrid = true;
                    SavedWText = message;
                    break;
            }
        }

        public void CloseOrg()
        {
            IsVisibileSavedWGrid = false;
            IsVisibileSavedRGrid = false;
            SavedRText = "";
            SavedWText = "";
            OrgGridIsVisible = false;
            SaveOrgGridIsVisible = false;
            DeleteOrgGridIsVisible = false;
            HacksIsVisibile = false;
            org = new OrganizerModel();
            Organizers = OrganizerModel.GetOrgsList();
        }

        public void ShowOrg(string name="Nil Nil")
        {
            CloseOrg();
            if (name.Equals("Nil Nil"))
            {
                New = false;
                OrgGridIsVisible = false;
            }
            else
            {
                New = false;
                org = OrganizerModel.GetOrg(name);
                OrgNameText = org.Name;
                OrgHacksText = org.Hack.ToString();
                OrgGridIsVisible = true;
                HacksIsVisibile = true;
                SaveOrgGridIsVisible = true;
                DeleteOrgGridIsVisible = true;
            }
        }

    }
}
