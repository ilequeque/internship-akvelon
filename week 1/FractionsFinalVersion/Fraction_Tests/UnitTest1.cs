using System;
using System.Collections.Generic;
using Xunit;

namespace Fraction_Tests
{
    public class UnitTest1
    {
        FractionClass Fraction1 = new(1, 3);
        [Fact]
        public void Sum_Of_TwoFractions()
        {
            //arrange
            FractionClass oldFraction = new(1, 3);
            var newFraction = new FractionClass(1, 3);
            var expectedFraction = new FractionClass(2, 3);
            //act
            var result = Fraction1 + newFraction;
            //assert
            Assert.Equal(expectedFraction, result);
        }
    }
}