using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EuropeanUnionCountries.Core.Dto;
using EuropeanUnionCountries.Core.Models;
using EuropeanUnionCountries.Core.Services;
using EuropeanUnionCountries.Data;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EuropeanUnionCountries.Services
{
    public class GetDataService : EntityService<CountryDto>, IGetDataService
    {
        public GetDataService(ICountriesDbContext context) : base(context)
        {
            _CountriesData = new();
            EUCountriesNameList = new();
            EUCountriesDataList = new();
        }

        private readonly IConfigurationRoot _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();


        public List<Country> GetEuCountriesData()
        {
            EUCountriesNameList = GetEuCountriesNamesList();

            _CountriesData.Clear();
            if (EUCountriesNameList != null)
                foreach (var c in EUCountriesNameList)
                    _CountriesData.Add(GetEUCountryDataAsync(c.name).Result);
            return _CountriesData;
        }

        public async Task<Country?> GetEUCountryDataAsync(string country)
        {
            HttpClient client = new();

            var response = client.GetStringAsync((string)_configuration["Urls:urlV3"] + country).Result;

            return JsonConvert.DeserializeObject<List<Country>>(response)?[0];
        }

        public List<CountryName>? GetEuCountriesNamesList()
        {
            HttpClient client = new HttpClient();

            var response = client.GetStringAsync((string)_configuration["Urls:urlV2"]).Result;

            return JsonConvert.DeserializeObject<List<CountryName>>(response);
        }
    }
}
