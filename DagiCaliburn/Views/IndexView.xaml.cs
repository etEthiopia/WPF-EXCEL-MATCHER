using DagiCaliburn.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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
    /// Interaction logic for IndexView.xaml
    /// </summary>
    public partial class IndexView : Window
    {
        public Rect workingArea;
        public string FFile = "";
        public string CFile = "";
        public static string path = "List.txt";
        public IndexView()
        {
            InitializeComponent();
            this.Top = 0.0;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight - System.Windows.SystemParameters.WindowCaptionHeight - 100;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth / 3;

            workingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = workingArea.Right/3;
            this.Top = 5.0;
        }

        private void TextBlock_PreviewDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] files1 = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                foreach (string file1 in files1)
                {
                    FFile = file1;
                    break;

                }

                //string file = (String)e.Data.GetData(DataFormats.FileDrop, false);
                DragText.Text = FFile;
                DragText.FontSize = 15;
                e.Handled = true;
                HashGrid.Visibility = Visibility.Visible;
            }
            catch(Exception exx)
            {
                MessageBox.Show("Couldn't Parse the Object "+exx.Message);
               
            }
            

        }

        private void TextBlock_PreviewDragEnter(object sender, DragEventArgs e)
        {

        }

        private void TextBlock_PreviewDragOver(object sender, DragEventArgs e)
        {

        }

        

        private void HashBtn_Click(object sender, RoutedEventArgs e)
        {
            byte[] buffer;
            int bytesRead;
            long size;
            long totalBytesRead = 0;
            try
            {
                try
                {
                    using (Stream file = File.OpenRead(FFile))
                    {

                        size = file.Length;
                        using (HashAlgorithm hasher = MD5.Create())
                        {
                            do
                            {
                                buffer = new byte[4096];
                                bytesRead = file.Read(buffer, 0, buffer.Length);
                                totalBytesRead += bytesRead;

                                hasher.TransformBlock(buffer, 0, bytesRead, null, 0);
                            }
                            while (bytesRead != 0);
                            {
                                hasher.TransformFinalBlock(buffer, 0, 0);
                                string hss = "";
                                foreach (byte b in hasher.Hash)
                                {
                                    hss += b.ToString("x2");
                                }
                                HashText.Text = hss;

                                
                                if (!File.Exists(path))
                                {
                                    File.Create(path);
                                    TextWriter tw = new StreamWriter(path);
                                    tw.WriteLine(DragText.Text.Trim() + "|" + HashText.Text);
                                    tw.Close();
                                    //Thread.Sleep(1000);
                                    //IndexViewModel.ivm.Preparehashes();

                                }
                                else if (File.Exists(path))
                                {
                                    using (var tw = new StreamWriter(path, true))
                                    {
                                        tw.WriteLine(DragText.Text.Trim() + "|" + HashText.Text);
                                        //Thread.Sleep(1000);
                                        //IndexViewModel.ivm.Preparehashes();
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception epp)
                {
                    MessageBox.Show($"Couldn't save hash: {epp.Message}");
                }
            }

            catch (Exception el)
            {
                MessageBox.Show($"Hashing not successful Try Again: {el.Message}");
            }
            }








        private void TextBlock_NPreviewDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] files1 = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                foreach (string file1 in files1)
                {
                    CFile = file1;
                    break;

                }

                //string file = (String)e.Data.GetData(DataFormats.FileDrop, false);
                DragNText.Text = CFile;
                DragNText.FontSize = 15;
                e.Handled = true;
                HashGrid.Visibility = Visibility.Visible;
            }
            catch (Exception exx)
            {
                MessageBox.Show("Couldn't Parse the Object " + exx.Message);

            }


        }

        private void TextBlock_NPreviewDragEnter(object sender, DragEventArgs e)
        {

        }

        private void TextBlock_NPreviewDragOver(object sender, DragEventArgs e)
        {

        }



        private void HashBtn_NClick(object sender, RoutedEventArgs e)
        {
            byte[] buffer;
            int bytesRead;
            long size;
            long totalBytesRead = 0;
            try
            {

                DragNText.Text = CFile;
                    using (Stream file = File.OpenRead(CFile))
                    {

                        size = file.Length;
                        using (HashAlgorithm hasher = MD5.Create())
                        {
                            do
                            {
                                buffer = new byte[4096];
                                bytesRead = file.Read(buffer, 0, buffer.Length);
                                totalBytesRead += bytesRead;

                                hasher.TransformBlock(buffer, 0, bytesRead, null, 0);
                            }
                            while (bytesRead != 0);
                            {
                                hasher.TransformFinalBlock(buffer, 0, 0);
                                string hss = "";
                                foreach (byte b in hasher.Hash)
                                {
                                    hss += b.ToString("x2");
                                }
                                NewHash.Text = hss;
                                

                                
                            }
                        }
                    }
                
                
            }

            catch (Exception el)
            {
                MessageBox.Show($"Hashing not successful Try Again: {el.Message}");
            }
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Pick_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CompareBtn_Click(object sender, RoutedEventArgs e)
        {
            if(NewHash.Text.Length == OldHash.Text.Length)
            {
                for(int i = 0; i < NewHash.Text.Length; i++)
                {
                    if (!(NewHash.Text[i].Equals(OldHash.Text[i])))
                    {
                        Bummer.Visibility = Visibility.Visible;
                        break;
                    }
                    
                }
                if(Bummer.Visibility == Visibility.Collapsed)
                {
                    Congra.Visibility = Visibility.Visible;
                }
            }
            else
            {
                Bummer.Visibility = Visibility.Visible;
            }
        }

        private void GreenClose_Click(object sender, RoutedEventArgs e)
        {
            Congra.Visibility = Visibility.Collapsed;
        }

        private void RedClose_Click(object sender, RoutedEventArgs e)
        {
            Bummer.Visibility = Visibility.Collapsed;
        }
    }
    }

