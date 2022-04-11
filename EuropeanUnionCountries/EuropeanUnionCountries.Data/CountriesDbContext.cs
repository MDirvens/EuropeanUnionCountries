using System.Threading.Tasks;
using EuropeanUnionCountries.Core.Dto;
using Microsoft.EntityFrameworkCore;

namespace EuropeanUnionCountries.Data
{
    public class CountriesDbContext : DbContext, ICountriesDbContext
    {
        public CountriesDbContext(DbContextOptions options) : base(options) { }
        public DbSet<CountryDto> Countries { get; set; }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
