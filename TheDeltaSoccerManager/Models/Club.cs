using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDeltaSoccerManager.Models
{
    public class Club
    {
        public long ClubId { get; set; }
        public string Name { get; set; }

        public ICollection<Player> Player { get; set; }

        public int StadiumId { get; set; }
        public Stadium Stadium { get; set; }
    }
}
