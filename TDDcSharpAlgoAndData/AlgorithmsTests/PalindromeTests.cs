using Algorithms.Strings;
using Xunit;

namespace UnitTest.AlgorithmsTests
{
    public static class PalindromeTests
    {
        public static void TextIsPalindrome_TrueExpected()
        {
            string test1 = "Anna";
            string test2 = "A Santa at Nasa";

            // Arrange
            // Act
            var isPalindrome = Palindrome.IsStringPalindrome(test1);
            var isPalindrome2 = Palindrome.IsStringPalindrome(test2);
            // Assert
            Assert.True(isPalindrome);
            Assert.True(isPalindrome2);
        }


        public static void TextNotPalindrome_FalseExpected()
        {
            string test1 = "hallo";
            string test2 = "Once upon a time";

            // Arrange
            // Act
            var isPalindrome = Palindrome.IsStringPalindrome(test1);
            var isPalindrome2 = Palindrome.IsStringPalindrome(test2);
            // Assert
            Assert.False(isPalindrome);
            Assert.False(isPalindrome2);
        }
    }
}
