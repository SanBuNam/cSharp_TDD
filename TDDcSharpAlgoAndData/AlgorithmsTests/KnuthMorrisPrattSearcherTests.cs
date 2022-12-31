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
            CollectionAttribute.Equals(expectedItem, actualItem);
        }

        [Fact]
        public static void FindIndexes_ItemsMissing_NoIndexesReturned()
        {
            var searcher = new KnuthMorrisPrattSearcher();
            var str = "ABABA";
            var pat = "ABB";
            Assert.Empty(indexes);
        }

        [Fact]
        public static void LongestPrefixSuffixArray_PrefixSuffixOfLength1_PassExpected()
        {
        }

        [Fact]
        public static void LongestPrefixSuffixArray_PrefixSuffixOfLength5_PassExpected()
        {
            CollectionAttribute.Equals(expectedItem, actualItem);
        }

        [Fact]
        public static void LongestPrefixSuffixArray_PrefixSuffixOfLength0_PassExpected()
        {
            CollectionAttribute.Equals(expectedItem, actualItem);
        }
    }
}
