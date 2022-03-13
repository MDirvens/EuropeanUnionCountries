using EuropeanUnionCountries.DataStorage;
using EuropeanUnionCountries.Methods;
using Microsoft.AspNetCore.Mvc;
using EuropeanUnionCountries.Models;

namespace EuropeanUnionCountries.Controllers
{
    [Route("EUcountries")]
    [ApiController]
    public class TopTenPopulation : ControllerBase
    {
        public EUCountriesData EUCountriesData = new();
        private readonly ResponseDataMethods data = new();
        List<EUCountryName> countries; 

        [HttpGet]
        [Route("topten/population")]
        public IActionResult GetTopTenPopulation()
        {
            return Ok(data.ResponseTopTenPopulationCountriesData());
        }

        [HttpGet]
        [Route("topten/density")]
        public IActionResult GetTopTenDensity()
        {
            return Ok(data.ResponseTopTenDensityCountriesData());
        }

        [HttpGet]
        [Route("country/{country}")]
        public IActionResult GetCountryData(string country)
        {
            countries = EUCountriesData.EUCountriesNameList;

            if (countries.Any(c => c.name.ToLower() == country.ToLower()))
            {
                return Ok(data.ResponseCountryData(country));
            }
            
            return BadRequest("Not a EU country in English ");
        }
    }
}
