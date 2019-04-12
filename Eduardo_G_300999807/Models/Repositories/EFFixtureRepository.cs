using Eduardo_G_300999807.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduardo_G_300999807.Models.Repositories
{
    public class EFFixtureRepository : IFixtureRepository
    {
        private ApplicationDbContext context;

        public EFFixtureRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Fixture> Fixtures => context.Fixtures
            .Include(f => f.Home)
            .Include(f => f.Away)
            .OrderBy(f => f.MatchTime);

        public IQueryable<Fixture> GetByDate(DateTime dateInit, DateTime dateEnd)
        {
            return Fixtures.Where(f => f.MatchTime >= dateInit && f.MatchTime <= dateEnd);
        }

        public Fixture GetById(int fixtureId)
        {
            return Fixtures.FirstOrDefault(f => f.FixtureId == fixtureId);
        }

        public Fixture Insert(Fixture fixture)
        {
            context.Fixtures.Add(fixture);
            context.SaveChanges();
            return fixture;
        }

        public void SetScore(Fixture fixture)
        {
            Fixture updatingFixture = context.Fixtures.FirstOrDefault(f => f.FixtureId == fixture.FixtureId);
            updatingFixture.HomeScore = fixture.HomeScore;
            updatingFixture.AwayScore = fixture.AwayScore;
            context.SaveChanges();
        }

        public bool isValid(Fixture fixture)
        {
            bool isHomeValid = context.Fixtures.FirstOrDefault(f => f.Home.ClubId == fixture.Home.ClubId
            && f.MatchTime.DayOfYear == fixture.MatchTime.DayOfYear) == null ? true : false;

            bool isAwayValid = context.Fixtures.FirstOrDefault(f => f.Away.ClubId == fixture.Away.ClubId
            && f.MatchTime.DayOfYear == fixture.MatchTime.DayOfYear) == null ? true : false;
            return (isHomeValid && isAwayValid) ? true : false;
        }
    }
}
