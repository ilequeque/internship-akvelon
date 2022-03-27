using Xunit;

namespace Fraction.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Sum_Of_TwoFractions()
        {
            var X = new FractionClass(1, 3);
            var Y = new FractionClass(1, 3);
            var expectedFraction = new FractionClass(2, 3);
            //act
            var result = X + Y;
            //assert
            Assert.Equal(expectedFraction, result);
        }
    }
}