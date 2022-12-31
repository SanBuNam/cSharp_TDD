using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Algorithms.Numeric;

namespace TDDcSharpAlgoAndData.AlgorithmsTests
{
    public static class AliquotSumCalculatorTests
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(3, 1)]
        [InlineData(25, 6)]
        [InlineData(99, 57)]
        public static void CalcuulateSum_SumIsCorrect(int number, int expectedSum)
        {
            // Arrange

            // Act
            var result = AliquotSumCalculator.CalculateAliquotSum(number);

            // Assert
            result.Equals(expectedSum);
        }
    }
}
