using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheDeltaSoccerManager.Models;

namespace TheDeltaSoccerManager.Models
{
    public class SoccerManagerContext: DbContext
    {
        public SoccerManagerContext(DbContextOptions<SoccerManagerContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }

        public DbSet<TheDeltaSoccerManager.Models.Club> Club { get; set; }

        public DbSet<TheDeltaSoccerManager.Models.Stadium> Stadium { get; set; }
    }
}
