using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheDeltaSoccerManager.Models
{
    public class Club
    {
        public int ClubId { get; set; }
        public string Name { get; set; }

        public ICollection<Player> Player { get; set; }

        public Stadium? Stadium { get; set; }
    }
}
