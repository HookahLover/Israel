using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Israel.MapModels
{
    public class CarToTest1 : BaseModel
    {
        public string Name { get; set; }
        public string MaxSpeed { get; set; }
        public string IsAutomaticTransmission { get; set; }
        public char WheelsQty { get; set; }

        public List<double> Numbers { get; set; }
        public ArrayList Array { get; set; }

        public CarToTest1()
        {
            Numbers = new List<double>();
            Array = new ArrayList();
        }
    }
}
