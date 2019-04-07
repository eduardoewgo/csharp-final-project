using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduardo_G_300999807.Models
{
    public class EFPlayerRepository: IPlayerRepository
    {
        private ApplicationDbContext context;

        public EFPlayerRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Player> Players => context.Players;

        public Player AddToClub(Player player, Club club)
        {
            Player updatingPlayer = context.Players.FirstOrDefault(p => p.PlayerId == player.PlayerId);
            updatingPlayer.Club = club;
            updatingPlayer.Name = player.Name;
            updatingPlayer.Age = player.Age;
            updatingPlayer.Overall = player.Overall;
            context.SaveChanges();
            return updatingPlayer;
        }

        public Player GetById(int playerId)
        {
            return context.Players.FirstOrDefault(p => p.PlayerId == playerId);
        }

        public Player Insert(Player player)
        {
            context.Players.Add(player);
            context.SaveChanges();
            return player;
        }
    }
}
