using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eduardo_G_300999807.Models
{
    public class Player
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerId { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public int Overall { get; set; }
        
        public int? ClubId { get; set; }
        public virtual Club Club { get; set; }

        public Player()
        {            
        }
    }    
}
