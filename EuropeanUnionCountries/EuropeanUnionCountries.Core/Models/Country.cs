using System.Collections.Generic;

namespace EuropeanUnionCountries.Core.Models
{
    public class Country
    {
        public Name name { get; set; }
        public double area { get; set; }
        public int population { get; set; }
        public string[] tld { get; set; }
        public double density { get; set; }
    }

    public class Name
    {
        public string common { get; set; }
        public Dictionary<string, LanguageCode> nativeName { get; set; }
    }

    public class LanguageCode
    {
        public string common { get; set; }
    }
}

