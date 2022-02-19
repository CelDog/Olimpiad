using System.Configuration;
using System.Data.Entity;

namespace Olympiad
{
    internal class OlimpContext : DbContext
    {
        public DbSet<OlimpInfo> OlimpInfos { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CityCountry> CityCountries { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<PartiList> PartiLists { get; set; }
        public DbSet<KindSport> KindSports { get; set; }
        public DbSet<Result> Results { get; set; }

        public OlimpContext() : base(ConfigurationManager.ConnectionStrings["OlimpConnStr"].ConnectionString)
        { }

    }
}
