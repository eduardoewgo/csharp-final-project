using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduardo_G_300999807.Models
{
    public class EFClubRepository: IClubRepository
    {
        private ApplicationDbContext context;

        public EFClubRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Club> Clubs => context.Clubs.Include(c => c.Players);

        public int Delete(int clubId)
        {
            Club deletingClub = context.Clubs.FirstOrDefault(c => c.ClubId == clubId);
            if (GetPlayersByClubId(deletingClub.ClubId).Any())
            {
                return 0;
            }

            context.Clubs.Remove(deletingClub);
            return context.SaveChanges();
        }

        public Club GetById(int? clubId)
        {
            Club club = context.Clubs.FirstOrDefault(c => c.ClubId == clubId);
            club.Players = GetPlayersByClubId(club.ClubId).ToList();
            return club;
        }

        public IEnumerable<Player> GetPlayersByClubId(int clubId)
        {
            return context.Players.Where(p => p.Club.ClubId == clubId);
        }

        public Club Insert(Club club)
        {
            context.Clubs.Add(club);
            context.SaveChanges();
            return club;
        }

        public Club Update(Club club)
        {
            Club updatingClub = context.Clubs.FirstOrDefault(c => c.ClubId == club.ClubId);
            updatingClub.Name = club.Name;
            updatingClub.League = club.League;
            context.SaveChanges();
            return updatingClub;
        }
    }
}
