using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Algorithms.Numeric;


namespace TDDcSharpAlgoAndData.AlgorithmsTests
{
    public static class KeithNumberTest
    {
        [Theory]
        [InlineData(14)]
        [InlineData(47)]
        [InlineData(197)]
        [InlineData(7909)]
        public static void KeithNumberWork(int number)
        {
            var result = KeithNumberChecker.IsKeithNumber(number);

            Assert.True(result);
        }

        [Theory]
        [InlineData(-2)]
        public static void KeithNumberShouldThrowEx(int number)
        {
            Assert.Throws<ArgumentException>(() => KeithNumberChecker.IsKeithNumber(number));
        }

    }
}
