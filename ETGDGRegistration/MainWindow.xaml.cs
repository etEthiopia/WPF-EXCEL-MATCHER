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
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using _Excel = Microsoft.Office.Interop.Excel;

namespace ETGDGRegistration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    class excelStu
    {
        public string EXName { get; set; }
        public string EXId { get; set; }
    }


    class Excel
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        public Excel(string path, int Sheet = 1)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[Sheet];
        }
        public string ReadCell(int i, int j)
        {
            i++;
            j++;
            if (ws.Cells[i, j].Value2 != null)
            {
                return ws.Cells[i, j].Value2;
            }
            else
            {
                return "";
            }
        }

        public List<List<string>> ReadExcel()
        {
            List<List<string>> mainL = new List<List<string>>();
            int i = 2;
            int j = 1;
            while (ws.Cells[i, j].Value2 != null)
            {
                List<string> current = new List<string>();
                while (j <= 4)
                {
                    Console.WriteLine("item " + ws.Cells[i, j].Value2);

                    current.Add(ws.Cells[i, j].Value2 + "");
                    j++;
                }
                j = 1;
                mainL.Add(current);
                i++;


            }
            //MessageBox.Show("count " + mainL.Count.ToString());
            return mainL;
        }
    }
    

    public partial class MainWindow : System.Windows.Window
    {
        List<List<string>> fromEx;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /**
            Excel ex = new Excel("C:/Users/Dagi/Desktop/st.xlsx");
            //MessageBox.Show(ex.ReadCell(0, 0));

            fromEx = ex.ReadExcel();
            foreach (List<string> list in fromEx)
            {
                MessageBox.Show("student " +list[0] + "  " + list[1]);
                excelStudents.Items.Add(new excelStu() { EXId = list[0], EXName = list[1] });
            }
            excelStudents.Items.Refresh();
            **/
            addV3();
        }

        public void addV3()
        {
            string query = $"INSERT INTO competetors(name, email, phone, hackathon_v) " +
                "VALUES" +

               $"('Nebiyu Adem','nebiyuadem@gmail.com',920407025, 7) "
                ;


            if (Database.instance.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, Database.instance.connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                Database.instance.CloseConnection();
            }
                    













        }
    }
}





