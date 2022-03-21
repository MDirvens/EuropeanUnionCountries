using EuropeanUnionCountries.Models;
using Newtonsoft.Json;

namespace EuropeanUnionCountries.Methods
{
    public class GetDataMethods
    {
        private readonly List<EUCountryData> _EUCountriesData = new();

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        public  List<EUCountryData> GetEuCountriesData(List<EUCountryName> countries)
        {
            _EUCountriesData.Clear();
            foreach (var c in countries) _EUCountriesData.Add(GetEUCountryDataAsync(c.name).Result);

            return _EUCountriesData;
        }

        public async Task<EUCountryData?> GetEUCountryDataAsync(string country)
        {
            HttpClient client = new HttpClient();

            var response = client.GetStringAsync((string)configuration["Urls:urlV3"] + country).Result;

            return JsonConvert.DeserializeObject<List<EUCountryData>>(response)[0];
        }

        public List<EUCountryName> GetEuCountriesNamesList()
        {
            HttpClient client = new HttpClient();

            var response = client.GetStringAsync((string)configuration["Urls:urlV2"]).Result;

            return JsonConvert.DeserializeObject<List<EUCountryName>>(response);
        }
    }
}
