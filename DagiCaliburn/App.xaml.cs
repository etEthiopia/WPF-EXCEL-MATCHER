using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DagiCaliburn
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static App app;
        public App()
        {
            app = this;
            Console.WriteLine("Started");
            
            //var app = (App)Application.Current;
            this.ChangeTheme("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml",
                "pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml",
                "pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.indigo.xaml",
                "pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.cyan.xaml");
            //foreach(var merg in Resources.MergedDictionaries[0].MergedDictionaries)
            //{
            //    Console.WriteLine($"{merg.Source}");
            //}
            Console.WriteLine($"Method  { Resources.MergedDictionaries.Count}");
        }
        public Collection<ResourceDictionary> lightdictonary
        {
            get
            {
                Console.WriteLine($"{Resources.MergedDictionaries.Count()}");
                
                return Application.Current.Resources.MergedDictionaries;
                //return  Resources.MergedDictionaries[0];
            }
        }
        public Collection<ResourceDictionary> defaultdictonary
        {
            get
            {
                Console.WriteLine($"{Resources.MergedDictionaries.Count()}");

                return Application.Current.Resources.MergedDictionaries;
                //return  Resources.MergedDictionaries[0];
            }
        }
        public Collection<ResourceDictionary> primarydictonary
        {
            get
            {
                Console.WriteLine($"{Resources.MergedDictionaries.Count()}");

                return Application.Current.Resources.MergedDictionaries;
                //return  Resources.MergedDictionaries[0];
            }
        }
        public Collection<ResourceDictionary> accentdictonary
        {
            get
            {
                Console.WriteLine($"{Resources.MergedDictionaries.Count()}");

                return Application.Current.Resources.MergedDictionaries;
                //return  Resources.MergedDictionaries[0];
            }
        }




        public void ChangeTheme(string uri, string uri2, string uri3, string uri4)
        {
            Resources.MergedDictionaries.Clear();
            if (Resources.MergedDictionaries.Count == 0)
            {
                //lightdictonary.Clear();
                //defaultdictonary.Clear();
                //primarydictonary.Clear();
                //accentdictonary.Clear();

                //Resources.MergedDictionaries[1].MergedDictionaries.Clear();
                //Resources.MergedDictionaries[2].MergedDictionaries.Clear();
                //Resources.MergedDictionaries[3].MergedDictionaries.Clear();


                Uri urik = new Uri(uri, UriKind.RelativeOrAbsolute);
                Uri urik2 = new Uri(uri2, UriKind.RelativeOrAbsolute);
                Uri urik3 = new Uri(uri3, UriKind.RelativeOrAbsolute);
                Uri urik4 = new Uri(uri4, UriKind.RelativeOrAbsolute);
                Console.WriteLine($"Inside  b { Resources.MergedDictionaries.Count}");
                //Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = urik });

                Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = urik });
                Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = urik2 });
                Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = urik3 });
                Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = urik4 });

                Console.WriteLine($"Inside  a { Resources.MergedDictionaries.Count}");
                //Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = urik2 });
                //Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = urik3 });
               // Resources.MergedDictionaries[0].MergedDictionaries.Add(new ResourceDictionary() { Source = urik4 });

            }
        }
    }
}
