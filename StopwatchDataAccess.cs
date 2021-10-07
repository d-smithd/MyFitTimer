using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using Dapper;
using System.Configuration;

namespace stopWatch
{
    public class StopwatchDataAccess
    {
        public static List<StopWatchTimerClass> LoadElaspedTimes()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var timeOutput = cnn.Query<StopWatchTimerClass>("select * from Time", new DynamicParameters());
                return timeOutput.ToList();
            }
        }
        public static void SaveTimes(StopWatchTimerClass times)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Time (ElapsedTime) values (@getElasped)", times);
            }
        }
        public static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
