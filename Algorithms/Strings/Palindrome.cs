using System;
using System.Text.RegularExpressions;

namespace Algorithms.Strings
{
    public static class Palindrome
    {
        // check if palindrome
        public static bool IsStringPalindrome(string word) => ToLowerAndTrim(word).Equals(ToLowerAndTrim(ReverseString(word)));

        // string to lower and remove white space
        private static string ToLowerAndTrim(string word) => Regex.Replace(word.ToLowerInvariant(), @"\s+", string.Empty);

        private static string ReverseString(string word)
        {
            var arr = word.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
