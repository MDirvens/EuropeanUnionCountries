using System.Linq;
using EuropeanUnionCountries.Core.Dto;
using EuropeanUnionCountries.Core.Models;
using EuropeanUnionCountries.Core.Services;

namespace EuropeanUnionCountries.Services
{
    public class MapperService : IMapperService
    {
        private CountryDto _countryDto;

        public MapperService()
        {
        }

        public CountryDto CountryToCountryDto(Country country)
        {
            _countryDto = new();
            _countryDto.name = country.name.common;
            _countryDto.nativeName = country.name.nativeName.First().Value.common;
            _countryDto.population = country.population;
            _countryDto.area = country.area;
            _countryDto.density = country.density;
            _countryDto.topLevelDomain = string.Join(", ", country.tld);

            return _countryDto;
        }
    }
}
