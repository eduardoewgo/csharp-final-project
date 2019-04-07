using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduardo_G_300999807.Models
{
    public interface IClubRepository
    {
        IQueryable<Club> Clubs { get; }
        Club Insert(Club club);
        Club Update(Club club);
        int Delete(int clubId);        
        Club GetById(int? clubId);
        IEnumerable<Player> GetPlayersByClubId(int clubId);
    }
}
