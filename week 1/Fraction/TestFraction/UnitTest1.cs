using Newtonsoft.Json;
using System;
using Xunit;

namespace TestFraction
{
    public class UnitTest1
    {
        [Fact]
        public void Sum_Of_TwoFractions()
        {
            //arrange
            var oldFraction = new FractionClass(1, 3);
            var newFraction = new FractionClass(1, 3);
            var expectedFraction = new FractionClass(2, 3);
            //act
            var result = oldFraction + newFraction;
            //assert
            Assert.Equal(expectedFraction, result);
        }
    }
}
