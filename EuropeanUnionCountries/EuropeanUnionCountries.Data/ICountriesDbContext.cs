using EuropeanUnionCountries.Core.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EuropeanUnionCountries.Data
{
    public interface ICountriesDbContext
    {
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
        DbSet<CountryDto> Countries { get; set; }
        int SaveChanges();
    }
}
