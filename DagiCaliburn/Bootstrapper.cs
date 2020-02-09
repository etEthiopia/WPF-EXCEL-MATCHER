using Caliburn.Micro;
using DagiCaliburn.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DagiCaliburn
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            
            Initialize();
        }

        
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<IndexViewModel>();
        }
        
    }
}
