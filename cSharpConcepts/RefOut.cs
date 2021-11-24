using System;
using System.Collections.Generic;
using System.Text;

namespace cSharpConcepts
{
    /*
     C# ref vs out
    Ref and out keywords in C# are used to pass arguments within a method or function. Both indicate that an argument/parameter is passed by reference. 
    By default parameters are passed to a method by value. By using these keywords (ref and out) we can pass a parameter by reference.

    Ref Keyword
    The ref keyword passes arguments by reference. It means any changes made to this argument in the method will be reflected in that variable when control returns to the calling method.
     */
    class RefOut
    {
        public static string GetNextNameByRef(ref int id)
        {
            string returnText = "Next-" + id.ToString();
            id += 1;
            return returnText;
        }

        public static void TestMain(string[] args)
        {
            int i = 1;
            Console.WriteLine("Previous value of integer i:" + i.ToString());
            string test = GetNextNameByRef(ref i);
            Console.WriteLine("Current vlaue of integer i:" + i.ToString());
        }

        // Out Keyword : The out keyword passes arguments by reference. This is very similar to the ref keyword.
        public static string GetNextNameByOut(out int id)
        {
            id = 1;
            string returnText = "Next-" + id.ToString();
            return returnText;
        }

        public static void Text2Main(string [] args)
        {
            int i = 0;
            Console.WriteLine("Previouse value of integer i:" + i.ToString());
            string test = GetNextNameByOut(out i);
            Console.WriteLine("Current value of integer i:" + i.ToString());
        }

        // Ref / Out keyword and method Overloading
        // Both ref and out are treated differently at run time and they are treated the same at compile time,
        // so methods cannot be overloaded if one method takes an argument as ref and the other takes an argument as an out.
        public static string GetNextName(ref int id)
        {
            string returnText = "Next-" + id.ToString();
            id += 1;
            return returnText;
        }

        //public static string GetNextName(out int id) // Cannot define overloaded method 'GetNextName' because it differs from another method only on ref and out
        //{
        //    id = 1;
        //    string returnText = "Next-" + id.ToString();
        //    return returnText;
        //}
        
        // However, method overloading can be possible when one method takes a ref or out argument and the other takes the same argument without ref or out.
        public static string GetNextName2(int id)
        {
            string returnText = "Next-" + id.ToString();
            id += 1;
            return returnText;
        }

        public static string GetNextName2(ref int id)
        {
            string returnText = "Next-" + id.ToString();
            id += 1;
            return returnText;
        }
        // The out and ref keywords are useful when we want to return a value in the same variables that are passed as an argument.
    }
}
