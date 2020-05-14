using Israel.MapModels;
using Israel.Mappers;
using Israel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Israel
{
    class Program
    {
        static void Main()
        {
            var car = new Car
            {
                IsAutomaticTransmission = true,
                MaxSpeed = 300,
                Name = "Audi",
                WheelsQty = 4,
                Numbers = new Collection<int> { 1, 2, 3},
                Array = new System.Collections.ArrayList() { "a", "b", "c", 5}
            };
            var mapper = new Mapper();
            var mappedCar = (CarToTest1)mapper.Map(car, typeof(CarToTest1));
            mappedCar.Display();
        }

        

    }
}
