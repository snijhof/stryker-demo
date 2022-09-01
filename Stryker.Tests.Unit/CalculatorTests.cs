using FluentAssertions;
using System;
using Test;
using Xunit;

namespace Stryker.tests.unit
{
    public class CalculatorTests
    {
        private Calculator _sut = new();

        [Fact]
        public void Add_ValidNumbers_NumbersAreAdded()
        {
            // Arrange
            var a = 1;
            var b = 2;
            var expectedResult = a + b;

            // Act
            var result = _sut.Add(a, b);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void Divide_CantDivideByZero_ThrowsDivideByZeroException()
        {
            // Arrange
            var a = 10;

            // Act
            Action action = () => _sut.Divide(a, 0);

            // Assert
            action.Should()
                .Throw<DivideByZeroException>()
                .WithMessage($"Cannot divide {a} by 0");
        }

        [Fact]
        public void Divide_DiviationResultsInDecimals_ResultContainsDecimals()
        {
            // Arrang
            var a = 5;
            var b = 2;
            var expectedResult = (decimal)a / b;

            // Act
            var result = _sut.Divide(a, b);

            // Assert
            result.Should().Be(expectedResult);
        }


        [Fact]
        public void SubtractOrAdd_AIsBiggerThanB_AddBAndA()
        {
            // Arrange
            var a = 10;
            var b = 5;

            // Act
            var result = _sut.SubtractOrAdd(a, b);

            // Assert
            result.Should().Be(a + b);
        }

        [Fact]
        public void SubtractOrAdd_AIsSmallerThanB_SubtractBFromA()
        {
            // Arrange
            var a = 5;
            var b = 10;

            // Act
            var result = _sut.SubtractOrAdd(a, b);

            // Assert
            result.Should().Be(a - b);
        }

        [Fact]
        public void SubtractOrAdd_AIsEqualToB_AddAAndB()
        {
            // Arrange
            var a = 5;
            var b = 5;

            // Act
            var result = _sut.SubtractOrAdd(a, b);

            // Assert
            result.Should().Be(a + b);
        }

        [Fact]
        public void AddXTimes_AddAAndBTenTimes_BIsAddedTenTimes()
        {
            // Arrange
            var a = 1;
            var b = 1;
            var count = 10;
            var expectedResult = a + b * count;

            // Act
            var result = _sut.AddXTimes(a, b, count);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-999)]
        public void AddXTimes_CountIsZero_ThrowsArgumentException(int count)
        {
            // Arrange
            var a = 5;

            // Act
            Action action = () => _sut.AddXTimes(a, 1, count);

            // Assert
            action.Should()
                .Throw<ArgumentException>()
                .WithMessage("count must be 1 or higher");
        }
    }
}