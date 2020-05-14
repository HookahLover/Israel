using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Israel.MapModels
{
    public abstract class BaseModel
    {
        public virtual void Display()
        {
            var sourceType = this.GetType();
            IList<PropertyInfo> sourceProps = new List<PropertyInfo>(sourceType.GetProperties());

            foreach(var prop in sourceProps)
            {
                if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string))
                {
                    var values = (IEnumerable)prop.GetValue(this);
                    Console.WriteLine(prop.Name);
                    foreach (var v in values)
                    {
                        Console.WriteLine("Item " + v);
                    }

                }
                else
                    Console.WriteLine(prop.Name + " is " + prop.GetValue(this));
            }
        }
    }
}
