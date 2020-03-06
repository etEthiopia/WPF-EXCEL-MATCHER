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
        private bool _suggestGridIsVisible = false;
        private bool _isVisibileSavedRGrid = false;
        private bool _isVisibileNextWGrid = false;
        private bool _isVisibileNextRGrid = false;
        private bool _deleteOrgGridIsVisible = false;
        private bool _saveOrgGridIsVisible = false;
        private bool _hacksIsVisibile = false;
        private bool _showNextOrgsIsVisible = true;
        private string _savedRText = "";
        private string _savedWText = "";
        private string _nextWText = "";
        private string _nextRText = "";
        private BindableCollection<OrganizerModel> _suggestedOrgs = new BindableCollection<OrganizerModel>();

        int k;

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

        public bool SuggestGridIsVisible { get { return _suggestGridIsVisible; }
            set { _suggestGridIsVisible = value; NotifyOfPropertyChange(() => SuggestGridIsVisible); } }

        public BindableCollection<OrganizerModel> SuggestedOrgs
        {
            get { return _suggestedOrgs; }
            set { _suggestedOrgs = value; NotifyOfPropertyChange(() => SuggestedOrgs); }
        }

        public bool ShowNextOrgsIsVisibile
        { get {return  _showNextOrgsIsVisible;} set { _showNextOrgsIsVisible = value 
                    ; NotifyOfPropertyChange(() => ShowNextOrgsIsVisibile); } }

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
                    
        public bool IsVisibileNextRGrid
        {
            get { return _isVisibileNextRGrid; }
            set
            {
                _isVisibileNextRGrid = value;
                NotifyOfPropertyChange(() => IsVisibileNextRGrid);
            }
        }

        public bool IsVisibileNextWGrid
        {
            get { return _isVisibileNextWGrid; }
            set
            {
                _isVisibileNextWGrid = value;
                NotifyOfPropertyChange(() => IsVisibileNextWGrid);
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

        public string NextRText
        {
            get { return _nextRText; }
            set { _nextRText = value; NotifyOfPropertyChange(() => NextRText); }
        }
        public string NextWText
        {
            get { return _nextWText; }
            set { _nextWText = value; NotifyOfPropertyChange(() => NextWText); }
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


        public void SuggestionBtn()
        {
            ++k;
            IsVisibileNextWGrid = false;
            IsVisibileNextRGrid = false;
            NextWText = "";
            NextRText = "";
            SuggestedOrgs = new BindableCollection<OrganizerModel>(Utils.NextOrgs(k));
            
        }

        public OrganizersViewModel()
        {
            Organizers = OrganizerModel.GetOrgsList();
            SuggestedOrgs = new BindableCollection<OrganizerModel>(Utils.NextOrgs(k));
            k = 0;
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

        public void ShowNext()
        {
            Console.WriteLine($"ShowNext");
            SuggestGridIsVisible = true;
            ShowNextOrgsIsVisibile = false;

        }

        public void CloseBtn()
        {
            SuggestGridIsVisible = false;
            ShowNextOrgsIsVisibile = true;
            k = 0;
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

        public void SaveSugOrgBtn()
        {
            string k = OrganizerModel.SetNextOrgs(SuggestedOrgs.ToList());
            if (k.Equals("true"))
            {
                Organizers = OrganizerModel.GetOrgsList();
                ShowNMessage("Organizers have been updated Successfuly", 'r');

            }
            else
            {
                ShowNMessage($"Error: {k}", 'w');
            }
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

        private void ShowNMessage(string message, char type)
        {
            Console.WriteLine($"Next: {message} : {type}");

            IsVisibileNextWGrid = false;
            IsVisibileNextRGrid = false;
            NextWText = "";
            NextRText = "";
            switch (type)
            {
                case 'w':
                    IsVisibileNextWGrid = true;
                    NextWText = message;
                    break;
                case 'r':
                    IsVisibileNextRGrid = true;
                    NextRText = message;
                    break;
                default:
                    IsVisibileNextWGrid = true;
                    NextWText = message;
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
