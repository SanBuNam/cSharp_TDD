using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Algorithms.Strings;
using System.Linq;

namespace TDDcSharpAlgoAndData.AlgorithmsTests
{
    public static class NaiveStringSearchTests
    {
        [Fact]
        public static void ThreeMatchesFound_PassExpected()
        {
            // Arrange
            var pattern = "ABB";
            var content = "ABBBAAABBAABBBBAB";

            // Act
            var expectedOccurrences = new[] { 0, 6, 10 };
            var actualOccurrences = NaiveStringSearch.NaiveSearch(content, pattern);
            var sequencesAreEqual = expectedOccurrences.SequenceEqual(actualOccurrences);

            // Assert
            Assert.True(sequencesAreEqual);
        }

        [Fact]
        public static void OneMatchFound_PassExpected()
        {
            // Arrange
            var pattern = "BAAB";
            var content = "ABBBAAABBAABBBBAB";

            // Act
            var expectedOccurrences = new[] { 8 };
            var actualOccuurrences = NaiveStringSearch.NaiveSearch(content, pattern);
            var sequencesAreEqual = expectedOccurrences.SequenceEqual(actualOccuurrences);

            // Assert
            Assert.True(sequencesAreEqual);
        }

        [Fact]
        public static void NoMatchFound_PassExpected()
        {
            // Arrange
            var pattern = "XYZ";
            var content = "ABBBAAABBAABBBBAB";

            // Act
            var expectedOccurrences = new int[0];
            var actualOccurrences = NaiveStringSearch.NaiveSearch(content, pattern);
            var sequencesAreEqual = expectedOccurrences.SequenceEqual(actualOccurrences);

            // Assert
            Assert.True(sequencesAreEqual);
        }
    }
}
