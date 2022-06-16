using System;
using System.Text.RegularExpressions;

namespace Algorithms.Strings
{
    public static class Palindrome
    {
        // IsPalindrome?
        public static bool IsStringPalindrome(string word) => ToLowerAndTrim(word).Equals(ToLowerAndTrim(ReverseString(word)));
        // string to lower and trim
        private static string ToLowerAndTrim(string word) => Regex.Replace(word.ToLowerInvariant(), @"\s+", string.Empty);
        // reverse string
        private static string ReverseString(string word)
        {
            var arr = word.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
