using System;
using Xunit;

namespace Fraction.Tests
{
    public class TestFractionOperations
    {
        [Fact]
        public void Sum_Of_TwoFractions()
        {
            var X = new FractionClass(1, 3);
            var Y = new FractionClass(1, 9);
            var expectedFraction = new FractionClass(4, 9);
            //act
            var result = X + Y;
            //assert
            Assert.Equal(expectedFraction.Normalization(), result.Normalization());
        }
        [Fact]
        public void Multiplication_Of_TwoFractions()
        {
            var X = new FractionClass(1, 3);
            var Y = new FractionClass(1, 3);
            var expectedFraction = new FractionClass(1, 9);
            //act
            var result = X * Y;
            //assert
            Assert.Equal(expectedFraction.Normalization(), result.Normalization());
        }
        [Fact]
        public void Division_Of_TwoFractions()
        {
            var X = new FractionClass(1, 3);
            var Y = new FractionClass(1, 2);
            var expectedFraction = new FractionClass(2, 3);
            //act
            var result = X / Y;
            //assert
            Assert.Equal(expectedFraction.Normalization(), result.Normalization());
        }
        [Fact]
        public void Subtraction_Of_TwoFractions()
        {
            var X = new FractionClass(2, 3);
            var Y = new FractionClass(1, 3);
            var expectedFraction = new FractionClass(1, 3);
            //act
            var result = X - Y;
            //assert
            Assert.Equal(expectedFraction.Normalization(), result.Normalization());
        }
    }
    public class TestFractionException
    {
        [Fact]
        public void DivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => new FractionClass(3, 0));
        }
    }
    public class TestEqualOperators
    {
        [Fact]
        public void Equals_ReturnTrue()
        {
            var X = new FractionClass(1, 2);
            var Y = new FractionClass(2, 4);

            Assert.True(X == Y);
        }
        [Fact]
        public void Equals_ReturnFalse()
        {
            var X = new FractionClass(5, 6);
            var Y = new FractionClass(1, 2);

            Assert.False(X == Y);
        }
        [Fact]
        public void NotEquals_ReturnTrue()
        {
            var X = new FractionClass(3, 2);
            var Y = new FractionClass(1, 2);

            Assert.True(X != Y);
        }
        [Fact]
        public void NotEquals_ReturnFalse()
        {
            var X = new FractionClass(3, 2);
            var Y = new FractionClass(3, 2);

            Assert.False(X != Y);
        }
    }
}