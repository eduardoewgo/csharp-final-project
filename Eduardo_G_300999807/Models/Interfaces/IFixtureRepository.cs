using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduardo_G_300999807.Models.Interfaces
{
    public interface IFixtureRepository
    {
        IQueryable<Fixture> Fixtures { get; }
        Fixture Insert(Fixture fixture);
        Fixture GetById(int fixtureId);
        IQueryable<Fixture> GetByDate(DateTime dateInit, DateTime dateEnd);
        void SetScore(Fixture fixture);
    }
}
