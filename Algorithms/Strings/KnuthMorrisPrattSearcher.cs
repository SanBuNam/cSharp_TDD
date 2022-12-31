﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Strings
{
    public class KnuthMorrisPrattSearcher
    {

        /// </summary>
        /// <param name="str">The string to look in.</param>
        /// <param name="pat">The pattern to look for.</param>
        public IEnumerable<int> FindIndexes(string str, string pat)
        {
            var lps = FindLongestPrefixSuffixValues(pat);

            for (int i = 0, j = 0; i < str.Length;)
            {
                if (pat[j] == str[i])
                {
                    j++;
                    i++;
                }

                if (j == pat.Length)
                {
                    yield return i - j;
                    j = lps[j - 1];
                    continue;
                }

                if (i < str.Length && pat[j] != str[i])
                {
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        i += 1;
                    }
                }
            }
        }
        /// </summary>
        /// <param name="pat">pattern to seek.</param>
        /// <returns>The longest prefix suffix values for <paramref name="pat" />.</returns>
        public int[] FindLongestPrefixSuffixValues(string pat)
        {
            var lps = new int[pat.Length];
            for (int i = 1, len = 0; i < pat.Length;)
            {
                if (pat[i] == pat[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                    continue;
                }

                if (len != 0)
                {
                    len = lps[len - 1];
                }
                else
                {
                    lps[i] = 0;
                    i++;
                }
            }
            return lps;
        }
    }
}
