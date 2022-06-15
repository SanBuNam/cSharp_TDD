using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Strings
{
    public static class GeneralStringAlgorithms
    {
        /// <summary>
        ///     Finds character that creates longest consecutive substring with single character.
        /// <parm name="input">String to find in.</parm>
        /// <returns>Tuple containing char and number of times it apeared in a row.</return>
        /// </summary>
        public static Tuple<char, int> FindLongestConsecutiveCharacters(string input)
        {
            // which character?
            var maxChar = input[0];
            // how many?
            var max = 1;
            // compare current w/ previous longest
            var current = 1;

            for (var i = 1; i < input.Length; i++)
            {
                // if same as previous char
                if (input[i] == input[i - 1])
                {
                    // add 1
                    current++;
                    // if longer than previous longest
                    if (current > max)
                    {
                        // assign new longest
                        max = current;
                        maxChar = input[i];
                    }
                }
                else
                {
                    // reset current to new char
                    current = 1;
                }
            }
            return new Tuple<char, int>(maxChar, max);
        }
    }
}
