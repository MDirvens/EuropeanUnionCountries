using System.Collections.Generic;

namespace EuropeanUnionCountries.Core.Services
{
    public interface IEntityService<T>
    {
        IEnumerable<T> GetTopTenDensity();
        IEnumerable<T> GetTopTenPopulation();
        T GetByName(string country);
    }
}
