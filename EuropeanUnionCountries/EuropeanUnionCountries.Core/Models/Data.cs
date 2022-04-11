using System.Collections.Generic;
using EuropeanUnionCountries.Core.Services;

namespace EuropeanUnionCountries.Core.Models
{
    public abstract class Data 
    {
        public List<Country> _CountriesData { get; set; }
        public List<CountryName> EUCountriesNameList { get; set; }
        public static List<Country> EUCountriesDataList { get; set; }
        public IMapperService _mapper { get; set; }
    }
}
