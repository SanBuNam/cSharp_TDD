using System;
using System.Collections.Generic;
namespace TDDcSharpAlgoAndData.AlgorithmsTests
{
    public static class NaiveStringSearchTests
    {
        [Fact]
        public static void ThreeMatchesFound_PassExpected()
        {
            var expectedOccurrences = new[] { 0, 6, 10 };
            var actualOccurrences = NaiveStringSearch.NaiveSearch(content, pattern);
            var sequencesAreEqual = expectedOccurrences.SequenceEqual(actualOccurrences);
            Assert.True(sequencesAreEqual);
        }

        [Fact]
        public static void NoMatchFound_PassExpected()
        {
            var expectedOccurrences = new int[0];
            var actualOccurrences = NaiveStringSearch.NaiveSearch(content, pattern);
            var sequencesAreEqual = expectedOccurrences.SequenceEqual(actualOccurrences);
            Assert.True(sequencesAreEqual);
        }
    }
}
