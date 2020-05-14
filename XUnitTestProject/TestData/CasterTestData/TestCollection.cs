using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace XUnitTestProject.TestData.CasterTestData
{
    public class TestCollection    
    {
        public Collection<int> Collection { get; set; }

        public TestCollection()
        {
            Collection = new Collection<int>
            {
                1,2,3,4,5
            };
        }
    }
}
