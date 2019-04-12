using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eduardo_G_300999807.Models
{
    public class FixtureAddViewModel
    {
        public Fixture Fixture { get; set; }
        public IEnumerable<Club> Clubs { get; set; }        
        public int HomeClubId { get; set; }
        public int AwayClubId { get; set; }
    }
}
