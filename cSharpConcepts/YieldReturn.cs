using System;
using System.Collections;
using System.Collections.Generic;

namespace cSharpConcepts
{
    public class UsualWayExample
    {
        static void UsualWay()
        {
            int[] a = new int[10];
            a = func(2, 10);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(a[i]);
            }
            Console.Read();
        }
        public static int[] func(int start, int number)
        {
            int[] _number = new int[number];
            for (int i = 0; i < number; i++)
            {
                _number[i] = start + 2 * i;
            }
            return _number;
        }
    }
    // Instead we can use a yield return to make the code simpler, quick operation, reducing operating cost through other intermediaries, easy error checking code in the case of large volumne.
    class YieldReturnExample
    {
        static void Yield()
        {
            foreach(var item in func(2, 10))
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }
        static IEnumerable func(int start, int number)
        {
            for (int i = 0; i < number; i++)
            {
                yield return start + 2 * i;
            }
        }
        // This demonstrates that the program can jump back and forth between the two modes without losing their current state.
        public void Consumer()
        {
            foreach (int i in Integers())
            {
                Console.WriteLine(i.ToString());
            }
        }
        public IEnumerable<int> Integers()
        {
            yield return 1;
            yield return 2;
            yield return 4;
            yield return 8;
            yield return 16;
            yield return 16777216;
        }
        // The first call to Integers() returns 1. The second call returns 2 and the line yield return 1 is not executed again.
        // The nice things about using yield return is that it's a very quick way of implementing the iterator pattern, so things are evaluated lazly.
        // Yield has two great uses,
        // 1. It helps to provide custom iteration without creating temp collections.
        // 2. It helps to do stateful iteration.
    }

}
