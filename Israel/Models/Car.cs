using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Principal;
using System.Text;

namespace Israel.Models
{
    public class Car
    {
        public string Name { get; set; }
        public float MaxSpeed { get; set; }
        public bool IsAutomaticTransmission { get; set; }
        public int WheelsQty { get; set; }

        public ICollection<int> Numbers { get; set; }

        public ArrayList Array { get; set; }

        public Car()
        {
            Numbers = new Collection<int>();
            Array = new ArrayList(5);
        }
    }
}
