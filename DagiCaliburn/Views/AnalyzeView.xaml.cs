using DagiCaliburn.ViewModels;
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
    /// Interaction logic for AnalyzeView.xaml
    /// </summary>
    public partial class AnalyzeView : UserControl
    {
        public static string FFile = "";
        public AnalyzeView()
        {
            InitializeComponent();
        }

        private void TextBlock_PreviewDrop(object sender, DragEventArgs e)
        {
            bool tre = false;
            try
            {
                string[] files1 = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                foreach (string file1 in files1)
                {
                    if (file1.Contains(".xlsx"))
                    {
                        tre = true;
                        FFile = file1;
                        break;
                    }
                    else
                    {
                        break;
                    }
                    
                    

                }

                //string file = (String)e.Data.GetData(DataFormats.FileDrop, false);
                if (tre)
                {
                    DragText.Text = FFile;
                    DragText.FontSize = 25;
                    e.Handled = true;
                    IndexViewModel.analyzeView.ShowDuplicatesIsVisible = true;
                    IndexViewModel.analyzeView.FFile = FFile;
                }
                else
                {
                    DragText.Text = "Please Enter a '.xlsx' File";
                }

            }
            catch (Exception exx)
            {
                MessageBox.Show("Couldn't Load the File " + exx.Message);

            }
        }

        private void TextBlock_PreviewDragEnter(object sender, DragEventArgs e)
        {

        }

        private void TextBlock_PreviewDragOver(object sender, DragEventArgs e)
        {

        }
    }
}
