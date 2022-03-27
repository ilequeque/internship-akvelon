using Newtonsoft.Json;
using System;
using Xunit;

namespace TestFraction
{
    public class UnitTest1
    {
        [Fact]
        public void Sum_Of_OldFractionClass_And_NewFractionClass()
        {
            //arrange
            var oldFraction = new FractionClass(1, 2);
            var newFraction = new Fraction(1, 2);
            var expectedFraction = new Fraction(2, 2);
            var expectedResult = JsonConvert.SerializeObject(expectedFraction);
            //act
            var result = oldFraction + newFraction;
            var actualResult = JsonConvert.SerializeObject(result);
            //assert
            Assert.Equal(expectedResult, actualResult);
            Assert.NotNull(oldFraction);
            Assert.NotNull(newFraction);
            Assert.NotNull(result);
        }
    }
}
