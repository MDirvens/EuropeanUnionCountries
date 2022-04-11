using EuropeanUnionCountries.Core.Models;
using EuropeanUnionCountries.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EuropeanUnionCountries.Controllers
{

    [Route("EUcountries")]
    [ApiController]
    public class TopTenPopulation : ApiControllerBase
    {
        public TopTenPopulation(ICountryService countryService,
                                IMapperService mapper,
                                IGetDataService getData,
                                IAddDataService addData)
        {
            _countryService = countryService;
            _mapper = mapper;
            _getData = getData;
            _addData = addData;
            
            _addData.addDataToDatabase(_getData.GetEuCountriesData());
            _countryService.AddDensity();
        }

        [HttpGet]
        [Route("topten/population")]
        public IActionResult GetTopTenPopulation1()
        {
            return Ok(_countryService.GetTopTenPopulation());
        }

        [HttpGet]
        [Route("topten/density")]
        public IActionResult GetTopTenDensity1()
        {
            return Ok(_countryService.GetTopTenDensity());
        }

        [HttpGet]
        [Route("country/{country}")]
        public IActionResult GetCountryData(string country)
        {
            if (_countryService.CountryExist(country))
            {
                return Ok(_countryService.GetByName(country));
            }

            return BadRequest("Not a EU country in English ");
        }
    }
}
