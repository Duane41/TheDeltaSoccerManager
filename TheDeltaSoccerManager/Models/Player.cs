using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDeltaSoccerManager.Models
{
    public class Player
    {
        public long PlayerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Height { get; set; }

        public int Speed { get; set; }

        public int Aggression { get; set; }

        public int BallControl { get; set; }

        public int ShootingAccuracy { get; set; }

        public int Defence { get; set; }

        public Club Club { get; set; }
    }
}
