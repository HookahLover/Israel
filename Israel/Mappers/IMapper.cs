using System;
using System.Collections.Generic;
using System.Text;

namespace Israel.Mappers
{
    public interface IMapper
    {
        TDestination Map<TDestination>(object sourceObject) where TDestination : class;
        object Map(object sourceObject, Type destinationType);
    }
}
