using System.Collections.Generic;
using System.Linq;
using EuropeanUnionCountries.Core.Dto;
using EuropeanUnionCountries.Core.Services;
using EuropeanUnionCountries.Data;

namespace EuropeanUnionCountries.Services
{
    public class EntityService<T> : Core.Models.Data, IEntityService<T> where T : CountryDto
    {
        protected ICountriesDbContext _context;

        public EntityService(ICountriesDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>();
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>();
        }

        public T GetByName(string country)
        {
            return Get().FirstOrDefault(c => c.name == country);
        }

        public IEnumerable<T> GetTopTenPopulation()
        {
            return _context.Set<T>().OrderByDescending(c => c.population).ToList().GetRange(0, 10);
        }

        public IEnumerable<T> GetTopTenDensity()
        {
            return _context.Set<T>().OrderByDescending(c => c.density).ToList().GetRange(0, 10);
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
    }
}
