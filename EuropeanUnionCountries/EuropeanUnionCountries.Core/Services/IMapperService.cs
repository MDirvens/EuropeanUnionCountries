using EuropeanUnionCountries.Core.Dto;
using EuropeanUnionCountries.Core.Models;

namespace EuropeanUnionCountries.Core.Services
{
    public interface IMapperService
    {
        CountryDto CountryToCountryDto(Country country);
    }
}
