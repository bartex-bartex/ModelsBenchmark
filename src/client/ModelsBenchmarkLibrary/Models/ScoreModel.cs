using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsBenchmarkLibrary.Models
{
    public class ScoreModel
    {
        public string Model { get; set; }
        public List<string> Parameters { get; set; }
        public string Score { get; set; }
    }
}
