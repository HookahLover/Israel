using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace XUnitTestProject.TestData.CasterTestData
{
    public static class GenericData
    {
        public static IEnumerable<object[]> Data =>
       new List<object[]>
       {
            new object[] { new Collection<int> {1, 2, 3 }, new List<int> {1, 2, 3 }, typeof(List<int>)},
            new object[] { new Collection<string> {"aaa", "dd", "f" }, new List<string> { "aaa", "dd", "f" }, typeof(List<string>)}
       };
    }
}
