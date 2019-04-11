using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eduardo_G_300999807.Models
{
    public class Fixture
    {
        [Key]
        public int FixtureId { get; set; }
        
        public Club Home { get; set; }
        public Club Away { get; set; }
        public DateTime MatchTime { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }
}
