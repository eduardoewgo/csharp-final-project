using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduardo_G_300999807.Models
{
    public interface IPlayerRepository
    {
        IQueryable<Player> Players { get; }
        Player Insert(Player player);
        Player GetById(int playerId);
        Player AddToClub(Player player, Club club);
    }
}
