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
    class IndexViewModel : Screen
    {
        private  BindableCollection<Filee> _typpes = new BindableCollection<Filee>();
        private string _oldHashh = "";
        private List<string> hashs = new List<string>();
        public static IndexViewModel ivm;
        
        public  BindableCollection<Filee> Typpes
        {
            get
            {
                return _typpes;
            }
            set
            {
                _typpes = value;

                NotifyOfPropertyChange(() => Typpes);
            }
        }

        public List<string> filees = new List<string>();

        public string OldHashh
        {
            get
            {
                return _oldHashh;
            }
            set
            {
                _oldHashh = value;
                NotifyOfPropertyChange(() => OldHashh);
            }
        }

        public IndexViewModel()
        {
            ivm = this;
            Preparehashes();
        }

        public void Preparehashes()
        {
            try
            {
                if (File.Exists(IndexView.path))
                {
                    Typpes = new BindableCollection<Filee>();
                    hashs = new List<string>();
                    using (StreamReader readText = new StreamReader(IndexView.path))
                    {
                        while (true)
                        {
                            string k = readText.ReadLine();
                            if(k == null)
                            {
                                break;
                            }
                            k = k.Trim();
                            
                            string[] div = k.Split('|');
                            if (div.Length > 1)
                            {
                                Typpes.Add(new Filee(div[0], div[1]));
                                hashs.Add(div[1]);
                                
                            }
                        }
                    }
                }
                Typpes = new BindableCollection<Filee>(Typpes.Reverse());
            }
            catch(Exception read)
            {
                MessageBox.Show($"Couldnt get the previous data: {read}");
            }
        }

        public void DriveSelected(string hs)
        {
            OldHashh = hs;
            //MessageBox.Show(hs);
        }

        public void Refresh()
        {
            Preparehashes();
        }
        
    }

    class Filee
    {
        public string FullPath { get; set; }
        public string Title { get; set; }
        public string Hash { get; set; }
        public Filee(string path, string hash)
        {
            FullPath = path;
            Title = GetName(path);
            Hash = hash;
        }

        public static string BackToFront(string back)
        {
            string front = "";
            front = back.Replace('\\', '/');
            return front;
        }

        public static string GetName(string fullpath)
        {
            string[] sep = fullpath.Split('\\');
            return sep.Last();
        }
    }
}
