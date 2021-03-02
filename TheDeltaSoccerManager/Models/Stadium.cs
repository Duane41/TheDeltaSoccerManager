using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheDeltaSoccerManager.Models
{
    public class Stadium
    {
        public int StadiumId { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }
    }
}
