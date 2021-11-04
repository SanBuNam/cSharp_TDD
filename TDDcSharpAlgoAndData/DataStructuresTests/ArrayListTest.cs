using DataStructures.Lists;
using Xunit;

namespace TDDcSharpAlgoAndData.DataStructuresTests
{
    // https://github.com/aalhour/C-Sharp-Algorithms
    public static class ArrayListTest
    {
        [Fact]
        public static void DoTest()
        {
            int index = 0;
            var arrayList = new ArrayList<long>();

            for (long i = 1; i < 1000000; ++i)
            {
                arrayList.Add(i);
            }

            for (int i = 1000; i < 1100; i++)
            {
                arrayList.RemoveAt(i);
            }

            for (int i = 100000; i < 100100; i++)
            {
                arrayList.Remove(i);
            }




        }
    }
}
