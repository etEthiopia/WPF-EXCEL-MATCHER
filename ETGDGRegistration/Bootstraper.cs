using Caliburn.Micro;
using ETGDGRegistration.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ETGDGRegistration
{
    class Bootstraper : BootstrapperBase
    {
        public Bootstraper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }

    }
}
