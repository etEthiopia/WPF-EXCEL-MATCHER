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
        public Workbook wb;
        public Worksheet ws;
        public Excel(string path, int Sheet = 1)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[Sheet];

            //
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
            
            Excel ex = new Excel("C:/Users/Dagi/Desktop/try.xlsx");

            MessageBox.Show("12 "+ex.ReadCell(1, 2));
            var cell = (_Excel.Range)ex.ws.Cells[8, 2];
            cell.Value = "Hey Berket";
            MessageBox.Show("12 " + ex.ReadCell(1, 2));

            fromEx = ex.ReadExcel();

            ex.wb.Close();

            

            //foreach (List<string> list in fromEx)
            //{
            //    MessageBox.Show("student " +list[0] + "  " + list[1]);

            //    excelStudents.Items.Add(new excelStu() { EXId = list[0], EXName = list[1] });
            //}
            //excelStudents.Items.Refresh();

            //addV3();
        }

        public void addV3()
        {
            string query = $"INSERT INTO competetors(name, email, phone, hackathon_v) " +
                "VALUES" +
$"('Daniel Geremew','danielk1781@gmail.com', null, 6) ," +
$"('Dawit Yonas','dawityonas010@gmail.com', null, 6) ," +
$"('Dagmawi Negussu','daginegussu@gmail.com', null, 6) ," +
$"('Abduselam Assen','hassen.abduse@gmail.com', null, 6) ," +
$"('Hermella birhanu','Hermellabirhanu056@gmail.com', null, 6) ," +
$"('Elshadai Kassu Tegegn','elshadaikassutegegn@gmail.com', 911341088, 6) ," +
$"('Eden Berhan Alem','edenberhanalem@gmail.com', 945965896, 6) ," +
$"('Dagmawit Getachew Teferra','se.dagmawit.getachew@gmail.com', 933036685, 6) ," +
$"('Bethelhem Teshibelay Workneh','se.bethelhem.teshibelay@gmail.com', 0946748630, 6) ," +
$"('Nabek Abebe','se.nabek.abebe@gmail.com', 945169110, 6) ," +
$"('Abel Takele','Abeltakele3d@gmail.com', 0920162768, 6) ," +
$"('Ahmednur Jemal','hayamunegn@gmail.com', 921350487, 6) ," +
$"('Abel Tadesse','abel.tade.10@gmail.com', 944766648, 6) ," +
$"('Aman Yosheph','amanyosheph@gmail.com', 910715335, 6) ," +
$"('Dawit Alemayehu','dawitgebeta@gmail.com', null, 6) ," +
$"('Abenezer Sleshi Belay','abenezer.sbelay@gmail.com', 945685470, 6) ," +
$"('Ruth Kebede','ruthcr7kebede@gmail.com', 921320715, 6) ," +
$"('Meti Adane Bayissa','metiade7@gmail.com', null, 6) ," +
$"('Natnael Alemayehu','se.natnael.alemayehu@gmail.com', 929380835, 6) ," +
$"('Semere Habtu','se.semere.habtu@gmail.com', null, 6) ," +
$"('Amanuel Debebe Lakew','Amanueldebebe1000@gmail.com', 913081340, 6) ," +
$"('Mastewal Belete Tadesse','se.mastewal.belete@gmail.com', 935024844, 6) ," +
$"('biruk melese','Birukmelese93@gmail.com', 900035846, 6) ," +
$"('hasen awel','ianhas711@gmail.com', 942252827, 6) ," +
$"('ayantu deresse','Ayeyederese123@gmail. Com', 919182436, 6) ," +
$"('hizkeal alayu','hizkuman@gmail.com', 915596440, 6) ," +
$"('barnabas getachew','polytechs1@yahoo.com', 923622803, 6) ," +
$"('Cherinet Hailu','cherinethailu619@gmail.com', null, 6) ," +
$"('Beralign Tilahun','tilahunberalign@gmail.com', null, 6) ," +
$"('Amanuel Wendwessen','wendea000@gmailcom', null, 6) ," +
$"('Ayantu File','ayantufile37@gmail.com', null, 6) ," +
$"('Abenezer Tesfaye Sida','abenezertesfaye308@gmqil.com', 973856176, 6) ," +
$"('Samson Misganaw Desalegn','samsonmisganaw75@gmail.com', null, 6) ," +
$"('Amanuel Melese','amanuelMelesse38@gmail.com', 944329294, 6) ," +
$"('Kaleab Yalewdeg','KaleabYalewdeg46@gmail.com', 946947019, 6) ," +
$"('Yonas Halefom','yonet1355@gmail.com', 923937882, 6) ," +
$"('Sosna w/medhin','sosiwk11@gmail.com', 932152181, 6) ," +
$"('Samson Negash','sn828018@gmail.com', null, 6) ," +
$"('Brook Paul','brookgashe5710@gmail.com', 911633302, 6) ," +
$"('Amanuel Abiy','abenizertesfaye308@gmail.com', null, 6) ";



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





