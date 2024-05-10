using ModelsBenchmarkLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsBenchmarkLibrary.DataAccess
{
    public static class TextConnectorProcessor
    {
        public static string GetFullFilePath(this string fileName)
        {
            return Path.Combine(ConfigurationManager.AppSettings["filePath"], fileName);
        }

        public static List<string> LoadFile(this string path)
        {
            if (!File.Exists(path))
            {
                return new List<string>();
            }

            return File.ReadLines(path).ToList();
        }

        public static List<ScoreModel> ConvertToScoreModels(this List<string> lines)
        {
            // model,p1|p2|p3|p4|p5,score
            List<ScoreModel> output = new List<ScoreModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                ScoreModel p = new ScoreModel();
                p.Model = cols[0];
                p.Parameters = cols[1].Split('|').ToList();
                p.Score = cols[2];

                output.Add(p);
            }

            return output;
        }

        public static void SaveToLeaderboardFile(this List<ScoreModel> models)
        {
            List<string> lines = new List<string>();

            foreach (ScoreModel p in models)
            {
                lines.Add($"{ p.Model },{ string.Join("|", p.Parameters) },{ p.Score }");
            }

            File.WriteAllLines(GlobalConfig.LeaderboardFile.GetFullFilePath(), lines);
        }
    }
}
