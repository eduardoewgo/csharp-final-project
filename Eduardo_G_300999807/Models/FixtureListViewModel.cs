using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduardo_G_300999807.Models
{
    public class FixtureListViewModel
    {
        public IEnumerable<Fixture> Fixtures { get; set; }
        public DateTime Init { get; set; }
        public DateTime End { get; set; }
    }
}
