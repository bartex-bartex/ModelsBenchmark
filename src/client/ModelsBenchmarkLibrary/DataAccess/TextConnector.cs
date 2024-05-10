using ModelsBenchmarkLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ModelsBenchmarkLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        public void TryAddScore(ScoreModel score)
        {
            List<ScoreModel> scoreModels = GlobalConfig.LeaderboardFile.GetFullFilePath().LoadFile().ConvertToScoreModels();

            scoreModels.Add(score);

            scoreModels = scoreModels.OrderBy(scoreModels => scoreModels.Score).Take(10).ToList();

            scoreModels.SaveToLeaderboardFile();
        }

        public List<ScoreModel> GetScores()
        {
            return GlobalConfig.LeaderboardFile.GetFullFilePath().LoadFile().ConvertToScoreModels().ToList();
        }
    }
}
