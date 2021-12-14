using System.Collections.Generic;
using DataStructures.Lists;

namespace Algorithms.Sorting
{
    /// <summary>
    /// Implements this Insertion Sort algorithm over ArrayLists.
    /// </summary>
    public static class InsertionSorter
    {
        // The quick insertion sort algorithm.
        // For any collection that implements the IList interface.
        public static void InsertionSort<T>(this IList<T> list, Comparer<T> comparer = null)
        {
           
        }


        // The quick insertion sort algorithm.
        // For the internal ArrayList<T>. Check the DataStructures.ArrayList.cs.
        public static void InsertionSort<T>(this ArrayList<T> list, Comparer<T> comparer = null)
        {
            // If the comparer is Null, then initialize it using a default typed comparer
         
        }

    }

}

