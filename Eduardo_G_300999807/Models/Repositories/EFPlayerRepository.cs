using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eduardo_G_300999807.Models
{
    public class EFPlayerRepository : IPlayerRepository
    {
        private ApplicationDbContext context;

        public EFPlayerRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Player> Players => context.Players
                                            .Include(p => p.Club)
                                            .Include(p => p.TransferLog)
                                                .ThenInclude(t => t.FromClub)
                                            .Include(p => p.TransferLog)
                                                .ThenInclude(t => t.ToClub);

        public Player AddToClub(Player player, Club club)
        {
            Player updatingPlayer = Players.FirstOrDefault(p => p.PlayerId == player.PlayerId);
            saveTransferLog(updatingPlayer.Club, club, player);
            updatingPlayer.Club = club;
            updatingPlayer.Name = player.Name;
            updatingPlayer.Age = player.Age;
            updatingPlayer.Overall = player.Overall;
            context.SaveChanges();
            return updatingPlayer;
        }

        private void saveTransferLog(Club fromClub, Club toClub, Player player)
        {
            TransferLog tl = new TransferLog() { FromClub = fromClub, ToClub = toClub, Date = DateTime.Now };
            Player dbPlayer = Players.FirstOrDefault(p => p.PlayerId == player.PlayerId);
            if (dbPlayer.TransferLog == null)
            {
                dbPlayer.TransferLog = new List<TransferLog>();
            }
            dbPlayer.TransferLog.Add(tl);
            //save will be made by the caller method
        }

        public Player GetById(int playerId)
        {
            return Players.FirstOrDefault(p => p.PlayerId == playerId);
        }

        public Player Insert(Player player)
        {
            context.Players.Add(player);
            context.SaveChanges();
            return player;
        }
    }
}
