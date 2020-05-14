using Israel.Casters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;
using XUnitTestProject.TestData.CasterTestData;

namespace XUnitTestProject
{
    public class CasterUnitTest
    {

        [Theory]
        [InlineData(5, "5", typeof(string))]
        [InlineData(10, 10.0, typeof(double))]
        [InlineData(65, 'A', typeof(char))]
        [InlineData(2.43, 2, typeof(int))]
        public void TestTryCast(object value, object result, Type type)
        {
            Caster.TryCast(value, out object output, type);
            Assert.Equal(result, output);
        }

        [Theory]
        [MemberData(nameof(NonGenericData.Data), MemberType = typeof(NonGenericData))]
        public void TestTryCastNonGenerics(object [] values)
        {
            var list = Caster.TryCastNonGenerics(values);
            Assert.Equal(values, list);
        }

        [Theory]
        [MemberData(nameof(GenericData.Data), MemberType = typeof(GenericData))]
        public void TestTryCastGenerics(IEnumerable values, IEnumerable result, Type type)
        {
            var list = Caster.TryCastGenerics(values, type);
            Assert.Equal(result, list);
            Assert.Equal(list.GetType(), type);
        }



       

        
    }
}
