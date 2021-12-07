using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Sorting
{
    public static class ShellSorter
    {
        public static void ShellSort<T>(this IList<T> collection, Comparer<T> comparer = null) 
        { 
        }

        /// <summary>
        /// Public API: Sorts ascending
        /// </summary>
        public static void ShellSortAscending<T>(this IList<T> collection, Comparer<T> comparer)
        { 
        }

        /// <summary>
        /// Public API: Sorts descending
        /// </summary>
        public static void ShellSortDescending<T>(this IList<T> collection, Comparer<T> comparer)
        { 
        }
    }
}
