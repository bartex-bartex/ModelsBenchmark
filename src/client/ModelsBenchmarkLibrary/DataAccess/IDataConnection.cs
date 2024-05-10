using ModelsBenchmarkLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsBenchmarkLibrary.DataAccess
{
    public interface IDataConnection
    {
        void TryAddScore(ScoreModel score);
        List<ScoreModel> GetScores();
    }
}
