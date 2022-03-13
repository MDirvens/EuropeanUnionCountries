using System.Net;
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
            foreach (var c in countries) _EUCountriesData.Add(GetEUCountryData(c.name));

            return _EUCountriesData;
        }

        public EUCountryData GetEUCountryData(string country)
        {
            var webClient = new WebClient();

            var json = string.Empty;
            try
            {
                json = webClient.DownloadString((string)configuration["Urls:urlV3"] + country);
            }
            catch (Exception)
            {
            }

            return JsonConvert.DeserializeObject<List<EUCountryData>>(json)[0];
        }

        public List<EUCountryName> GetEuCountriesNamesList()
        {
            var webClient = new WebClient();

            var json = string.Empty;
            try
            {
                json = webClient.DownloadString((string)configuration["Urls:urlV2"]);
            }
            catch (Exception)
            {

            }

            return JsonConvert.DeserializeObject<List<EUCountryName>>(json);
        }
    }
}
