using System;
using System.Linq;
using EuropeanUnionCountries.Core.Dto;
using EuropeanUnionCountries.Core.Services;
using EuropeanUnionCountries.Data;

namespace EuropeanUnionCountries.Services
{
    public class CountryService : EntityService<CountryDto>, ICountryService
    {

        public CountryService(ICountriesDbContext context) : base(context)
        {
            _context = context;
        }

        public void AddDensity()
        {
            Query().ToList().ForEach(c =>
                c.density = Math.Round((double) (c.population / c.area), 3));
            _context.SaveChanges();
        }

        public bool CountryExist(string country)
        {
            return Get().Any(c => String.Equals(c.name, country, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
