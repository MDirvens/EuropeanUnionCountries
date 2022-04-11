using EuropeanUnionCountries.Core.Dto;

namespace EuropeanUnionCountries.Core.Services
{
    public interface ICountryService : IEntityService<CountryDto>
    {
        void AddDensity();
        bool CountryExist(string country);
    }
}
