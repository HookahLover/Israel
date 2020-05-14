using Israel.Casters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Israel.Mappers
{
    public class Mapper : IMapper
    {
        public TDestination Map<TDestination>(object sourceObject) where TDestination : class
        {
            return (TDestination)PrivateMap(sourceObject, typeof(TDestination));
        }

        public object Map(object sourceObject, Type destinationType)
        {
            return PrivateMap(sourceObject, destinationType);
        }


        private object PrivateMap(object sourceObject, Type destinationType)
        {
            var sourceType = sourceObject.GetType();

            var destinObject = Activator.CreateInstance(destinationType);

            IList<PropertyInfo> sourceProps = new List<PropertyInfo>(sourceType.GetProperties());
            IList<PropertyInfo> destinProps = new List<PropertyInfo>(destinationType.GetProperties());

            foreach (var sourceProp in sourceProps)
            {
                var currentDestinProp = destinProps.FirstOrDefault(i => i.Name.Equals(sourceProp.Name));
                if (currentDestinProp == null) continue;

                Type destinCurrentType = currentDestinProp.PropertyType;

                if (typeof(IEnumerable).IsAssignableFrom(destinCurrentType) && destinCurrentType != typeof(string))
                {
                    var values = (IEnumerable)sourceProp.GetValue(sourceObject);

                    if (destinCurrentType.IsGenericType)
                    {
                        var list = Caster.TryCastGenerics(values, currentDestinProp.PropertyType);
                        currentDestinProp.SetValue(destinObject, list);
                    }
                    else
                    {
                        var list = Caster.TryCastNonGenerics(values);
                        currentDestinProp.SetValue(destinObject, list);
                    }
                }
                else
                {
                    var sourcePropObj = sourceProp.GetValue(sourceObject);

                    Caster.TryCast(sourcePropObj, out object destinPropObj, destinCurrentType);

                    try
                    {
                        currentDestinProp.SetValue(destinObject, destinPropObj);
                    }
                    catch (ArgumentException e)
                    {
                        continue;
                    }
                }

            }

            return destinObject;
        }


    }
}
