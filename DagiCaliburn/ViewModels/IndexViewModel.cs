using Caliburn.Micro;
using DagiCaliburn.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DagiCaliburn.ViewModels
{
    class IndexViewModel : Conductor<object>
    {
        public static ApplicantsViewModel applicantsView;
        public static OrganizersViewModel organizersView;
        public static AnalyzeViewModel analyzeView;


        public IndexViewModel()
        {
            applicantsView = new ApplicantsViewModel();
            organizersView = new OrganizersViewModel();
            analyzeView = new AnalyzeViewModel();
            ActivateItem(analyzeView);
        }

        public void AnalyzeMenu()
        {
            ActivateItem(analyzeView);
        }

        public void OrganizersMenu()
        {
            ActivateItem(organizersView);
        }

        public void ApplicantsMenu()
        {
            ActivateItem(applicantsView);
        }
    }

}
