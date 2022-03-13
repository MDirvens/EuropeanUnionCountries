using System.Collections.Generic;
using System.Linq;
using EuropeanUnionCountries.Methods;
using EuropeanUnionCountries.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EuropeanUnionCountries.Tests
{
    [TestClass]
    public class GetDataMethodsTests
    {
        public GetDataMethods data;
        public List<EUCountryName> countries;

        [TestInitialize]
        public void Setup()
        {
            data = new();
            countries = new List<EUCountryName>()
            {
                new() {name = "Latvia"},
                new() {name = "Germany"},
                new() {name = "Austria"},
                new() {name = "Denmark"},
                new() {name = "Gibraltar"}
            };
        }

        [TestMethod]
        public void GetEuCountriesNamesList_CallMethod_EUCountryList()
        {
            //Arange
            var name = "Åland Islands";

            //Act
            var result = data.GetEuCountriesNamesList();

            //Asert
            Assert.AreEqual(name, result[0].name);
            Assert.AreEqual(31, result.Count);
        }

        [TestMethod]
        public void GetEUCountryData_CountryName_CountryData()
        {
            //Arange
            var country = "latvia";
            var nativeName = "Latvija";

            //Act
            var result = data.GetEUCountryData(country);

            //Asert
            Assert.AreEqual(nativeName, result.name.nativeName.First().Value.common);
        }

        [TestMethod]
        public void GetEuCountriesData_ListOfCountries_DataOfAllCountries()
        {
            //Arange
            var country = "Iceland";
            
            //Act
            var result = data.GetEuCountriesData(countries);

            //Asert
            Assert.IsFalse(result.Any(c => c.name.common == country));
            Assert.AreEqual(countries.Count, result.Count);
        }
    }
}