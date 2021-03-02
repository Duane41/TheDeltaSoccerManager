using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDeltaSoccerManager.Models
{
    public class SoccerManagerContext: DbContext
    {
        public SoccerManagerContext(DbContextOptions<SoccerManagerContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
    }
}
