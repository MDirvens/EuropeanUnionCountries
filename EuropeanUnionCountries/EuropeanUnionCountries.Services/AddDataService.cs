using System.Collections.Generic;
using EuropeanUnionCountries.Core.Dto;
using EuropeanUnionCountries.Core.Models;
using EuropeanUnionCountries.Core.Services;
using EuropeanUnionCountries.Data;

namespace EuropeanUnionCountries.Services
{
    public class AddDataService : EntityService<CountryDto>, IAddDataService
    {
        public AddDataService(ICountriesDbContext context, IMapperService mapper) : base(context)
        { 
            _mapper = mapper;
        }

        public void addDataToDatabase(List<Country> countries)
        {
            _context.Countries.RemoveRange(_context.Countries);
            countries.ForEach(c => Create(_mapper.CountryToCountryDto(c)));
        }
    }
}
