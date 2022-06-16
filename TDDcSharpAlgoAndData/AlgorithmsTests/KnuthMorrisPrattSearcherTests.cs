using Algorithms.Strings;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TDDcSharpAlgoAndData.AlgorithmsTests
{
    public static class KnuthMorrisPrattSearcherTests
    {
        [Fact]
        public static void FindIndexes_ItemsPresent_PassExpected()
        {
            // Arrange
            var searcher = new KnuthMorrisPrattSearcher();
            var str = "ABABAcdeABA";
            var pat = "ABA";

            // Act
            var expectedItem = new[] { 0, 2, 8 };
            var actualItem = searcher.FindIndexes(str, pat);

            // Assert
            CollectionAttribute.Equals(expectedItem, actualItem);
        }

        [Fact]
        public static void FindIndexes_ItemsMissing_NoIndexesReturned()
        {
            // Arrange
            var searcher = new KnuthMorrisPrattSearcher();
            var str = "ABABA";
            var pat = "ABB";

            // Act & Assert
            var indexes = searcher.FindIndexes(str, pat);


            // Assert
            Assert.Empty(indexes);
        }

        [Fact]
        public static void LongestPrefixSuffixArray_PrefixSuffixOfLength1_PassExpected()
        {
            // Arrange
            var searcher = new KnuthMorrisPrattSearcher();
            var s = "ABA";

            // Act
            var expectedItem = new[] { 0, 0, 1 };
            var actualItem = searcher.FindLongestPrefixSuffixValues(s);


            // Assert
            CollectionAttribute.Equals(expectedItem, actualItem);
        }

        [Fact]
        public static void LongestPrefixSuffixArray_PrefixSuffixOfLength5_PassExpected()
        {
            // Arrange
            var searcher = new KnuthMorrisPrattSearcher();
            var s = "AABAACAABAA";

            // Act
            var expectedItem = new[] { 0, 1, 0, 1, 2, 0, 1, 2, 3, 4, 5 };
            var actualItem = searcher.FindLongestPrefixSuffixValues(s);

            // Assert
            CollectionAttribute.Equals(expectedItem, actualItem);
        }

        [Fact]
        public static void LongestPrefixSuffixArray_PrefixSuffixOfLength0_PassExpected()
        {
            // Arrange
            var searcher = new KnuthMorrisPrattSearcher();
            var s = "AB";

            // Act
            var expectedItem = new[] { 0, 0 };
            var actualItem = searcher.FindLongestPrefixSuffixValues(s);

            // Assert
            CollectionAttribute.Equals(expectedItem, actualItem);
        }
    }
}
