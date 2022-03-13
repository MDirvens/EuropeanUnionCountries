using EuropeanUnionCountries.Models;

namespace EuropeanUnionCountries.Methods
{
    public class ResponseDataMethods
    {
        private DataMethods _data = new();
        private List<ResponseData> _responsedata = new();
        private ResponseDataNoName _responseDataNoName;
        EUCountryData countryData;
        List<EUCountryData> countriesData;

        public List<ResponseData> ResponseTopTenPopulationCountriesData()
        {
            countriesData = _data.GetTopTenPopulationCountriesData();
            countriesData.ForEach(c => _responsedata.Add(ChangeCountryData(c)));

            return _responsedata; 
        }

        public List<ResponseData> ResponseTopTenDensityCountriesData()
        {
            countriesData = _data.GetTopTenDensityCountriesData();
            countriesData.ForEach(c => _responsedata.Add(ChangeCountryData(c)));

            return _responsedata; 
        }

        public ResponseDataNoName ResponseCountryData(string country)
        {
            countryData = _data.GetCountryData(country);
            _responseDataNoName = ChangeCountryDataNoName(countryData);

            return _responseDataNoName;
        }

        public ResponseData ChangeCountryData(EUCountryData countryData)
        {
            var country = new ResponseData()
            {
                name = countryData.name.common,
                nativeName = countryData.name.nativeName.First().Value.common,
                population = countryData.population,
                area = countryData.area,
                density = countryData.density,
                topLevelDomain = string.Join(", ", countryData.tld)
            };

            return country;
        }

        public ResponseDataNoName ChangeCountryDataNoName(EUCountryData countryData)
        {
            var country = new ResponseDataNoName
            {
                nativeName = countryData.name.nativeName.First().Value.common,
                population = countryData.population,
                area = countryData.area,
                density = countryData.density,
                topLevelDomain = string.Join(", ", countryData.tld)
            };

            return country;
        }
    }
}
