using Dispose;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System;
using Xunit;

namespace DisposeTest
{
    [TestClass]
    public class CustomerTests
    {
        [Fact]
        public void DisposeShouldReleaseComObject()
        {
            Customer temp = new Customer();

            temp.Dispose();

            Xunit.Assert.True(temp._disposed);
        }
    }
}