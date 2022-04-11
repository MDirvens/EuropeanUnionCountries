using EuropeanUnionCountries.Core.Models;

namespace EuropeanUnionCountries.Core.Dto
{
    public class CountryDto : Entity
    {
        public string name { get; set; }
        public string nativeName { get; set; }
        public double area { get; set; }
        public int population { get; set; }
        public string topLevelDomain { get; set; }
        public double density { get; set; }
    }
}
