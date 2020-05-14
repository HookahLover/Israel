using Israel.MapModels;
using Israel.Mappers;
using Israel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xunit;

namespace XUnitTestProject
{
    public class MapperUnitTests
    {
        [Fact]
        public void TestMap()
        {
            var mapper = new Mapper();

            var car = new Car
            {
                IsAutomaticTransmission = true,
                MaxSpeed = 300,
                Name = "Audi",
                WheelsQty = 66,
                Numbers = new Collection<int> { 1, 2, 3 },
                Array = new System.Collections.ArrayList() { "a", "b", "c", 5 }
            };

            var mappedCar = (CarToTest1)mapper.Map(car, typeof(CarToTest1));

            Assert.Equal("True", mappedCar.IsAutomaticTransmission);
            Assert.Equal("300", mappedCar.MaxSpeed);
            Assert.Equal("Audi", mappedCar.Name);
            Assert.Equal('B', mappedCar.WheelsQty);
            Assert.Equal(new List<double> { 1,2,3}, mappedCar.Numbers);
            Assert.Equal(new System.Collections.ArrayList() { "a", "b", "c", 5 }, mappedCar.Array);
        }
    }
}
