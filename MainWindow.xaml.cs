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
using System.Windows.Threading;
using System.Diagnostics;
using System.Data;
using System.Data.SQLite;

namespace stopWatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StopWatchTimerClass timer;
        DispatcherTimer timerObject = new DispatcherTimer();
        List<StopWatchTimerClass> times = new List<StopWatchTimerClass>();
        public MainWindow()
        {
            InitializeComponent();
            timer = new StopWatchTimerClass();
            timerObject.Tick += new EventHandler(timerObject_Tick);
            timerObject.Interval = new TimeSpan(0, 0, 0, 0, 1);

        }
        void timerObject_Tick(object sender, EventArgs e)
        {
            this.LabelTimer.Content = timer.elapsed;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (timer.timeRunning())
            {
                timerObject.Stop();
                timer.stop();
                StopWatchTimerClass t = new StopWatchTimerClass();
                t.getElasped = timer.elapsed;
                StopwatchDataAccess.SaveTimes(t);
             
                
                LoadElapsedTimes();
               
                

            }
             
          
           

           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(!timer.timeRunning())
            {
                timer.reset();
                this.LabelTimer.Content = "00:00:00";
            }
            timerObject.Start();
            timer.start();
          
        }
        private void LoadElapsedTimes()
        {
            times = StopwatchDataAccess.LoadElaspedTimes();
            WireUpTimesList();


        }
        
        private void WireUpTimesList()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection(StopwatchDataAccess.LoadConnectionString());
            m_dbConnection.Open();

            SQLiteCommand sqlCom = new SQLiteCommand("SELECT ElapsedTime FROM Time", m_dbConnection);
            SQLiteDataReader sqlDataReader = sqlCom.ExecuteReader();

            while (sqlDataReader.Read())
            {
                if(!sqlDataReader.IsDBNull(0))
                {
                    timeList.Items.Add(sqlDataReader.GetValue(0));
                }
                
            }

        }
    }
}
