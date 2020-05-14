using Israel.Casters;
using Israel.MapModels;
using Israel.Mappers;
using Israel.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.ObjectModel;
using Xunit;

namespace UnitTests
{
    [TestClass]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [DataRow(0, 0.0, typeof(double))]
        [DataRow(1, "1", typeof(string))]
        [DataRow(2.0, 2, typeof(int))]
        [DataTestMethod]
        [Fact]
        public void Test1(object input, object output, Type type)
        {
            object result = default(object);
            Caster.TryCast(input, ref result, type);

            NUnit.Framework.Assert.AreEqual(output, result);
        }
    }
}