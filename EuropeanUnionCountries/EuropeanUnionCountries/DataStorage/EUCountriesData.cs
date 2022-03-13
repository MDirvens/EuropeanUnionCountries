using EuropeanUnionCountries.Methods;
using EuropeanUnionCountries.Models;

namespace EuropeanUnionCountries.DataStorage
{
    public class EUCountriesData
    {
        private static GetDataMethods _data = new();

        public List<EUCountryName> EUCountriesNameList { get; set; }

        public static List<EUCountryData> EUCountriesDataList { get; set; }

        public EUCountriesData()
        {
            EUCountriesNameList = _data.GetEuCountriesNamesList();
            EUCountriesDataList = _data.GetEuCountriesData(EUCountriesNameList);
        }
    }
}
