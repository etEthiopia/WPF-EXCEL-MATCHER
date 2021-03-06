﻿using DagiCaliburn.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DagiCaliburn.Views
{
    /// <summary>
    /// Interaction logic for OrganizersView.xaml
    /// </summary>
    public partial class OrganizersView : UserControl
    {
        public OrganizersView()
        {
            InitializeComponent();
        }

        private void Organizers_Selected(object sender, RoutedEventArgs e)
        {
            
            try
            {
                IndexViewModel.organizersView.ShowOrg(Organizers.SelectedItem.ToString());
                Console.WriteLine($"selected " + Organizers.SelectedItem);
            }
            catch (Exception)
            {
                IndexViewModel.organizersView.ShowOrg();
                Console.WriteLine($"selected " + "Nil Nil");
            }
            
        }
    }
}
