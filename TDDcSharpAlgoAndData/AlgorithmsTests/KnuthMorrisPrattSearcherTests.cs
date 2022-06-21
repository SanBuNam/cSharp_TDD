using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Algorithms.Strings;

namespace TDDcSharpAlgoAndData.AlgorithmsTests
{
    public static class KnuthMorrisPrattSearcherTests
    {
        [Fact]
        public static void FindIndexes_ItemsPresent_PassExpected()
        {
            var searcher = new KnuthMorrisPrattSearcher();
            var str = "ABABAcdeABA";
            var pat = "ABA";

            var expectedItem = new[] { 0, 2, 8 };
            var actualItem = searcher.FindIndexes(str, pat);

            CollectionAttribute.Equals(expectedItem, actualItem);
        }

        [Fact]
        public static void FindIndexes_ItemsMissing_NoIndexesReturned()
        {
            var searcher = new KnuthMorrisPrattSearcher();
            var str = "ABABA";
            var pat = "ABB";

            var indexes = searcher.FindIndexes(str, pat);

            Assert.Empty(indexes);
        }

        [Fact]
        public static void LongestPrefixSuffixArray_PrefixSuffixOfLength1_PassExpected()
        {
            var searcher = new KnuthMorrisPrattSearcher();
            var s = "ABA";

            var expectedItem = new[] { 0, 0, 1 };
            var atualItem = searcher.FindLongestPrefixSuffixValues(s);

            CollectionAttribute.Equals(expectedItem, atualItem);
        }

        [Fact]
        public static void LongestPrefixSuffixArray_PrefixSuffixOfLength5_PassExpected()
        {
            var searcher = new KnuthMorrisPrattSearcher();
            var s = "AABAACAABAA";

            var expectedItem = new[] { 0, 1, 0, 1, 2, 0, 1, 2, 3, 4, 5 };
            var actualItem = searcher.FindLongestPrefixSuffixValues(s);

            CollectionAttribute.Equals(expectedItem, actualItem);
        }

        [Fact]
        public static void LongestPrefixSuffixArray_PrefixSuffixOfLength0_PassExpected()
        {
            var searcher = new KnuthMorrisPrattSearcher();
            var s = "AB";

            var expectedItem = new[] { 0, 0 };
            var actualItem = searcher.FindLongestPrefixSuffixValues(s);

            CollectionAttribute.Equals(expectedItem, actualItem);
        }
    }
}
