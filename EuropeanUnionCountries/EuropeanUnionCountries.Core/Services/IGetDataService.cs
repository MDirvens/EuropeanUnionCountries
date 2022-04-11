using System.Collections.Generic;
using EuropeanUnionCountries.Core.Models;

namespace EuropeanUnionCountries.Core.Services
{
    public interface IGetDataService 
    {
        List<Country> GetEuCountriesData();
    }
}
