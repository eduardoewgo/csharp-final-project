using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eduardo_G_300999807.Models
{
    public class Club
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClubId { get; set; }

        public string Name { get; set; }
        public string League { get; set; }

        public List<Player> Players { get; set; }
    }
}
