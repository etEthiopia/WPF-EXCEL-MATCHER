using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DagiCaliburn.ViewModels
{
    class AnalyzeViewModel : Screen
    {
        private bool _showDuplicatesIsVisible = false;

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
            Console.WriteLine("DUPLICATE BTN CLICKED");
        }
    }
}