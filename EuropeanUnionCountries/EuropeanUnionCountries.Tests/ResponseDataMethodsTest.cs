using System.Linq;
using EuropeanUnionCountries.DataStorage;
using EuropeanUnionCountries.Methods;
using EuropeanUnionCountries.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EuropeanUnionCountries.Tests
{
    [TestClass]
    public class ResponseDataMethodsTest
    {
        public EUCountriesData allData;
        public ResponseDataMethods data;
        public EUCountryData countryData;

        [TestInitialize]
        public void Setup()
        {
            allData = new();
            data = new();
            countryData = EUCountriesData.EUCountriesDataList.First(c => c.name.common == "Latvia");
        }

        [TestMethod]
        public void ChangeCountryData_CountryData_ChangedEUCountryDataData()
        {
            //Act
            var result = data.ChangeCountryData(countryData);

            //Asert
            Assert.IsTrue(result is ResponseData);
        }

        [TestMethod]
        public void ChangeCountryDataNoName_CountryData_ChangedEUCountryDataDataNoName()
        {
            //Act
            var result = data.ChangeCountryDataNoName(countryData);

            //Asert
            Assert.IsTrue(result is ResponseDataNoName);
        }


        [TestMethod]
        public void ResponseTopTenPopulationCountriesData_CallMethod_ChangedEUCountryDataTopTenPopulation()
        {
            //Arange
            int population;
            countryData = EUCountriesData.EUCountriesDataList.First(c => c.name.common == "Germany");

            //Act
            var result = data.ResponseTopTenPopulationCountriesData();
            population = result[0].population;

            //Asert
            Assert.IsFalse(result.Any(c => c.population > population));
            Assert.AreEqual(countryData.name.common, result[0].name);
            Assert.AreEqual(10, result.Count);
        }

        [TestMethod]
        public void ResponseTopTenDensityCountryData_CallMethod_ChangedEUCountryDataTopTenDensity()
        {
            //Arange
            double density;
            countryData = EUCountriesData.EUCountriesDataList.First(c => c.name.common == "Gibraltar");

            //Act
            var result = data.ResponseTopTenDensityCountriesData();
            density = result[0].density;

            //Asert
            Assert.IsFalse(result.Any(c => c.density > density));
            Assert.AreEqual(countryData.name.common, result[0].name);
            Assert.AreEqual(10, result.Count);
        }

        [TestMethod]
        public void ResponseCountryData_CountryName_ChangedEUCountryData()
        {
            //Arange
            var name = "Latvia";

            //Act
            var result = data.ResponseCountryData(name);

            //Asert
            Assert.IsTrue(result is ResponseDataNoName);
            Assert.AreEqual(countryData.name.nativeName.First().Value.common, result.nativeName);
        }
    }
}