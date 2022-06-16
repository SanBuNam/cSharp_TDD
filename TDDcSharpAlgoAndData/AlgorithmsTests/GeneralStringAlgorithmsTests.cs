using Algorithms.Strings;
using System;
using Xunit;

namespace TDDcSharpAlgoAndData.AlgorithmsTests
{
    public class GeneralStringAlgorithmsTests
    {
        [Theory]
        [InlineData("Griffith", 'f', 2)]
        [InlineData("Randomwoooord", 'o', 4)]
        public static void MaxCountCharIsObtained(string text, char expectedSymbol, int expectedCount)
        {
            var (symbol, count) = GeneralStringAlgorithms.FindLongestConsecutiveCharacters(text);

            Assert.Equal(expectedSymbol, symbol);
            Assert.Equal(expectedCount, count);
        }
    }
}
