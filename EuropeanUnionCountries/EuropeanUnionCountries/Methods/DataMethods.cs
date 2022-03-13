using EuropeanUnionCountries.DataStorage;
using EuropeanUnionCountries.Models;

namespace EuropeanUnionCountries.Methods
{
    public class DataMethods 
    {
        private List<EUCountryData> _countries;
        private EUCountryData _countryData;

        public List<EUCountryData> GetTopTenPopulationCountriesData()
        {
            AddDensity();
            _countries = EUCountriesData.EUCountriesDataList.
                         OrderByDescending(f => f.population).ToList();

            return _countries.GetRange(0, 10);
        }

        public List<EUCountryData> GetTopTenDensityCountriesData()
        {
            AddDensity();
            _countries = EUCountriesData.EUCountriesDataList.
                         OrderByDescending(f => f.density).ToList();

            return _countries.GetRange(0, 10);
        }

        public EUCountryData GetCountryData(string country)
        {
            AddDensity();
            _countryData = EUCountriesData.EUCountriesDataList.
                           First(c => c.name.common.ToLower() == country.ToLower());

            return _countryData;
        }

        public void AddDensity()
        {
            EUCountriesData.EUCountriesDataList.ForEach(c => 
                c.density = Math.Round( c.population/c.area, 3));
        }
    }
}
