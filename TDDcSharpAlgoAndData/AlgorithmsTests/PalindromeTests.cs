using Algorithms.Strings;
using Xunit;

namespace UnitTest.AlgorithmsTests
{
    public static class PalindromeTests
    {
        [Theory]
        [InlineData("Anna")]
        [InlineData("A Santa at Nasa")]
        public static void TextIsPalindrome_TrueExpected(string word)
        {
            // Arrange
            var isPalindrome = Palindrome.IsStringPalindrome(word);
            // Assert
            Assert.True(isPalindrome);
        }

        [Theory]
        [InlineData("hallo")]
        [InlineData("Once upon a time")]
        public static void TextNotPalindrome_FalseExpected(string word)
        {
            // Arrange
            var isPalindrome = Palindrome.IsStringPalindrome(word);
            // Assert
            Assert.False(isPalindrome);
        }
    }
}
