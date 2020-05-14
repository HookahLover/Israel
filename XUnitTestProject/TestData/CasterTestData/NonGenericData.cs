using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestProject.TestData.CasterTestData
{
    public static class NonGenericData
    {
        public static IEnumerable<object[]> Data =>
      new List<object[]>
      {
            new object[] { new object[] {1, 2, 3 } },
            new object[] { new object[] { -4, -6, -10 } },
            new object[] { new object[] { "aaa", "dd", "f" } }
      };
    }
}
