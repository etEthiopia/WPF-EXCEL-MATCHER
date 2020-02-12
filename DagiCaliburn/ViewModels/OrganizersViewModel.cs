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
        private List<string> _orgs;
        private bool New = false;
        public OrganizerModel org = new OrganizerModel();

        public string SelectedOrg { get { return _selectedOrg; }
            set { _selectedOrg = value; NotifyOfPropertyChange(() => SelectedOrg); }
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

        public void ShowOrg(string name)
        {

        }

    }
}
