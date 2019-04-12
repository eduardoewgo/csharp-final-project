using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduardo_G_300999807.Models
{
    public class TransferPlayersViewModel
    {
        public IEnumerable<Player> Players { get; set; }
        public string Name { get; set; }
        public string ClubFrom { get; set; }
        public string ClubTo { get; set; }
        public DateTime DateTransfer { get; set; }
    }
}
