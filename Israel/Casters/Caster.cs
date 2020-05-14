using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Israel.Casters
{
    public static class Caster
    {
        public static void TryCast<T>(object obj, out T result, Type type)
        {
            result = default(T);
            var converter = TypeDescriptor.GetConverter(obj.GetType());
            if (converter.CanConvertTo(type))
            {
                try
                {
                    result = (T)converter.ConvertTo(obj, type);
                }
                catch(Exception e)
                {

                }
            }
        }


        public static IEnumerable TryCastGenerics(IEnumerable values, Type destinCurrentType)
        {
            var elementType = destinCurrentType.GetGenericArguments()[0];
            IList list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(elementType));

            foreach (var v in values)
            {
                var y = new object();
                if (elementType == typeof(string)) y = string.Empty;
                else
                    y = Activator.CreateInstance(elementType);
                Caster.TryCast(v, out y, elementType);
                list.Add(y);
            }
            
            return list;
        }

        public static IEnumerable TryCastNonGenerics(IEnumerable values)
        {
            IList list = (IList)Activator.CreateInstance(typeof(ArrayList));

            foreach (var v in values)
            {
                var y = new object();
                var typeOfValue = v.GetType();
                Caster.TryCast(v, out y, typeOfValue);
                list.Add(y);
            }

            return list;
        }


    }
}
