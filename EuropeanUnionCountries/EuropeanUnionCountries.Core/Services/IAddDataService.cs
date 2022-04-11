using System.Collections.Generic;
using EuropeanUnionCountries.Core.Models;

namespace EuropeanUnionCountries.Core.Services
{
    public interface IAddDataService
    {
        void addDataToDatabase(List<Country> countries);
    }
}
