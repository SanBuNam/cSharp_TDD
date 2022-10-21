using System;
using System.Collections.Generic;
using System.Text;

namespace cSharpConcepts
{
    public class FormalDelegate
    {
        /// <summary>
        ///     Action is a delegate type defined in the System namespace.
        ///     An Action type delegate is the same as Func delegate except that the Action delegate doesn't return a value. Like a void return type.
        ///     An Action delegate can take up to 16 input parameters of different types.
        /// </summary>
        public delegate void Print(int val);
        static void ConsolePrint(int i)
        {
            Console.Write(i);
        }
        static void Main(string[] vs)
        {
            Print prnt = ConsolePrint;
            prnt(10);
        }
    }

    // I can use an Action delegate instead of defining the above Print delegate, for example:
    public class ActionDelegate
    {
        static void ConsolePrint2(int i)
        {
            Console.WriteLine(i);
        }
        static void Main(string[] vs)
        {
            // Action<int> printActionDel = ConsolePrint2;

            // or I can initialize an Action delegate using the new keyword or by directly assigning a method:
            Action<int> printActionDel = new Action<int>(ConsolePrint2);

            printActionDel(10);
        }
    }

    //  An Anonymous method can also be assigned to an Action delegate, for example:
    public class AnonymousMethod
    {
        static void Main(string[] vs)
        {
            Action<int> printActionDel = delegate (int i)
            {
                Console.WriteLine(i);
            };
            printActionDel(10);
        }
    }

    // A Lambda expression also can be used with an Action delegate:
    public class LambdaExpress
    {
        static void Main(string[] stringps)
        {
            Action<int> printActionDel = i => Console.WriteLine(i);
            printActionDel(10);
        }
    }


}
