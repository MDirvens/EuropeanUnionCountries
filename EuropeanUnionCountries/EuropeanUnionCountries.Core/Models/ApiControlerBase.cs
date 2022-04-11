using EuropeanUnionCountries.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EuropeanUnionCountries.Core.Models
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected ICountryService _countryService;
        public IMapperService _mapper;
        public IGetDataService _getData;
        public IAddDataService _addData;
    }
}
