using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Numeric;
using Xunit;
using FluentAssertions;

namespace TDDcSharpAlgoAndData.AlgorithmsTests
{
    public class ModularExponentiationTest
    {
        [Theory]
        [InlineData(3, 6, 11, 3)]
        [InlineData(5, 3, 13, 8)]
        [InlineData(2, 7, 17, 9)]
        [InlineData(7, 4, 16, 1)]
        [InlineData(7, 2, 11, 5)]
        [InlineData(4, 13, 497, 445)]
        [InlineData(13, 3, 1, 0)]
        public void ModularExponentiationCorrect(int b, int e, int m, int expectedRes)
        {
            var modularExponentiation = new ModularExponentiation();
            var actualRes = modularExponentiation.ModularPow(b, e, m);
            actualRes.Equals(expectedRes);
        }

        [Theory]
        [InlineData(17, 7, -3)]
        [InlineData(11, 3, -5)]
        [InlineData(14, 3, 0)]
        public void ModularExponentiationNegativeMod(int b, int e, int m)
        {
            var modularExponentiation = new ModularExponentiation();
            Action res = () => modularExponentiation.ModularPow(b, e, m);
            res.Should().Throw<ArgumentException>()
            .WithMessage(String.Format("{0} is not a positive integer", m));
        }
    }
}
