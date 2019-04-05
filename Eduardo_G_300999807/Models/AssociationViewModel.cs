using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduardo_G_300999807.Models
{    
    public class AssociationViewModel
    {
        public List<Club> Clubs { get; set; }
        public Player Player { get; set; }
        public int ClubId { get; set; }

        public AssociationViewModel()
        {
        }

        public AssociationViewModel(IEnumerable<Club> clubs, Player player)
        {            
            Clubs = clubs.ToList();
            ClubId = player.Club != null ? player.Club.ClubId : 0;

            Player = player;
        }
    }
}
