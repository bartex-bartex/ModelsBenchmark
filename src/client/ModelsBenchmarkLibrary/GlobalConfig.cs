using ModelsBenchmarkLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsBenchmarkLibrary
{
    public static class GlobalConfig
    {
        public const string LeaderboardFile = "Leaderboard.csv";
        public static string ApiUrl = "http://127.0.0.1:5000/api";
        public static readonly string[] AvailableApiUrls = new string[]
        {
            "http://127.0.0.1:5000/api",
            "http://192.168.33.15:5000/api"
        };

        public static IDataConnection Connection { get; private set; }

        public static void SetupDefaultServer(string url)
        {
            ApiUrl = url;
        }

        public static void InitializeConnections(DataSourceType dataSource)
        {
            if (dataSource == DataSourceType.TextFile)
            {
                TextConnector text = new TextConnector();
                Connection = text;
            }
        }
    }
}
