using System.Linq;
using EuropeanUnionCountries.DataStorage;
using EuropeanUnionCountries.Methods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EuropeanUnionCountries.Tests
{
    [TestClass]
    public class DataMethodsTests
    {
        public EUCountriesData allData;
        public DataMethods data;

        [TestInitialize]
        public void Setup()
        {
            allData = new();
            data = new();
        }

        [TestMethod]
        public void AddDensity_GiveCountryName_CountryDensityNotZero()
        {
            //Arange
            var name = "Gibraltar";
            
            //Act
            var densityBefore = EUCountriesData.EUCountriesDataList.First(c => c.name.common == name).density;
            data.AddDensity();
            var result = EUCountriesData.EUCountriesDataList.First(c => c.name.common == name).density;

            //Asert
            Assert.AreEqual(0, densityBefore);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public void GetCountryData_GiveCountryName_CountryDataNotNull()
        {
            //Arange
            var name = "Austria";

            //Act
            var result = data.GetCountryData(name);

            //Asert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetTopTenPopulationCountriesData_CallMethod_TenCountryDataSortedByPopulation()
        {
            //Arange
            int population;

            //Act
            var result = data.GetTopTenPopulationCountriesData();
            population = result[0].population;

            //Asert
            Assert.IsFalse(result.Any(c => c.population > population));
            Assert.AreEqual(10, result.Count);
        }

        [TestMethod]
        public void GetTopTenDensityCountriesData_CallMethod_TenCountryDataSortedByDensity()
        {
            //Arange
            double density;

            //Act
            var result = data.GetTopTenDensityCountriesData();
            density = result[0].density;

            //Asert
            Assert.IsFalse(result.Any(c => c.density > density));
            Assert.AreEqual(10, result.Count);
        }
    }
}