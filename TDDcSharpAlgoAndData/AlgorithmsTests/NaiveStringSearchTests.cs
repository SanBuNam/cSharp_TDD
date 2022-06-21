using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Algorithms.Strings;

namespace TDDcSharpAlgoAndData.AlgorithmsTests
{
    public static class NaiveStringSearchTests
    {
        [Fact]
        public static void ThreeMatchesFound_PassExpected()
        {
            var pattern = "ABB";
            var content = "ABBBAAABBAABBBBAB";

            var expectedOccurrences = new[] { 0, 6, 10 };
            var actualOccurrences = NaiveStringSearch.NaiveSearch(content, pattern);
            var sequencesAreEqual = expectedOccurrences.SequenceEqual(actualOccurrences);

            Assert.True(sequencesAreEqual);
        }


        [Fact]
        public static void OneMatchFound_PassExpected()
        {
            var pattern = "BAAB";
            var content = "ABBBAAABBAABBBBAB";

            var expectedOccurrences = new[] { 8 };
            var actualOccurrences = NaiveStringSearch.NaiveSearch(content, pattern);
            var sequencesAreEqual = expectedOccurrences.SequenceEqual(actualOccurrences);

            Assert.True(sequencesAreEqual);
        }

        [Fact]
        public static void NoMatchFound_PassExpected()
        {
            var pattern = "XYZ";
            var content = "ABBBAAABBAABBBBAB";

            var expectedOccurrences = new int[0];
            var actualOccurrences = NaiveStringSearch.NaiveSearch(content, pattern);
            var sequencesAreEqual = expectedOccurrences.SequenceEqual(actualOccurrences);

            Assert.True(sequencesAreEqual);
        }
    }
}
