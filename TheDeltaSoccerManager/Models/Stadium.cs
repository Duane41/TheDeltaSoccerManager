using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDeltaSoccerManager.Models
{
    public class Stadium
    {
        public int StadiumId { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }

        public Club Club { get; set; }
    }
}
