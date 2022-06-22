using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Algorithms.Strings;
using Algorithms.Numeric;
using System.Linq;

namespace TDDcSharpAlgoAndData.AlgorithmsTests
{
    public class PermutationTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("A")]
        [InlineData("abcd")]
        [InlineData("aabcd")]
        [InlineData("aabbbcd")]
        [InlineData("aabbbccccd")]
        public void Test_GetEveryUniquePermutation(string word)
        {
            var permutations = Permutation.GetEveryUniquePermutation(word);
            // We need to make sure that
            // 1. We have the right number of permutations
            // 2. Every string in permutations List is a permutation of word
            // 3. There are no repetitions

            // Start 1.
            // The number of unique permutations is
            // n!/(A1! * A2! * ... An!)
            // where n is the length of word and Ai is the number of occurrences if ith char in the string
            var charOccurrence = new Dictionary<char, int>();
            foreach (var c in word)
            {
                if (charOccurrence.ContainsKey(c))
                {
                    charOccurrence[c] += 1;
                }
                else
                {
                    charOccurrence[c] = 1;
                }
            }
            // now we know the values of A1, A2, ..., An
            // evaluate the above formula
            var expectedNumberOfAnagrams = Factorial.Calculate(word.Length);
            expectedNumberOfAnagrams = charOccurrence.Aggregate(expectedNumberOfAnagrams, (current, keyValuePair) => {
                return current / Factorial.Calculate(keyValuePair.Value);
            });
            Assert.Equal(expectedNumberOfAnagrams, permutations.Count);
            // string A is a permutation of string B if and only if sorted(A) == sorted(b)
            var wordSorted = SortString(word);
            foreach(var permutation in permutations)
            {
                Assert.Equal(wordSorted, SortString(permutation));
            }
            Assert.Equal(permutations.Count, new HashSet<string>(permutations).Count);
        }

        private static string SortString(string word)
        {
            var asArray = word.ToArray();
            Array.Sort(asArray);
            return new string(asArray);
        }
    }  
}
