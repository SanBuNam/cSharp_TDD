using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cSharpConcepts
{
    public class OldClass
    {
        public int x = 100;
        public void Test1()
        {
            Console.WriteLine("Method one: " + this.x);
        }
        public void Test2()
        {
            Console.WriteLine("Method Two: " + this.x);
        }
    }

    // Now the requirement is to add new methods to the OldClass but we don't want to change the source code of OldClass.
    // That can be achieved by either inheritance or extension methods.
    public static class NewClass
    {
        public static void Text3(this OldClass O)
        {
            Console.WriteLine("Method Three");
        }
        public static void Text4(this OldClass O, int x)
        {
            Console.WriteLine("Method Four: " + x);
        }
        public static void  Text5(this OldClass O)
        {
            Console.WriteLine("Method Five: " + O.x);
        }
    }

    public class ProgramClass
    {
        static void MainEntry(string[] args)
        {
            OldClass obj = new OldClass();
            obj.Test1();
            obj.Test2();

            // Calling extension methods
            obj.Text3();
            obj.Text4(10);
            obj.Text5();

            Console.ReadLine();
        }
    }


    // Real life example by adding GetWordCount to String (is a built-in class)
    public static class StringExtension
    {
        public static int GetWordCount(this string inputstring)
        {
            if (!string.IsNullOrEmpty(inputstring))
            {
                string[] strArray = inputstring.Split(' ');
                return strArray.Count();
            }
            else
            {
                return 0;
            }
        }
    }

    class ProgramStringExt
    {
        static void MainStringExt(string[] args)
        {
            string myWord = "Welcome to Dotnet Tutorials Extension Methods Article.";
            int wordCount = myWord.GetWordCount();

            Console.WriteLine("string : " + myWord);
            Console.WriteLine("Count : " + wordCount);
            Console.Read();
        }
    }
}
/*
 Output:
Method One: 100
Method two: 100
Method Three
Method Four: 10
Method Five: 100
 */
/*
 Points to remember while working with C# Extension methods:
Extension methods must be defined only under the static class.
As an extension method is defined under a static class, compulsory that the method should be defined as static whereas once the method is bound with another class, the method changes into non-static.
The first parameter of an extension method is known as the binding parameter which should be the name of the class to which the method has to be bound and the binding parameter should be prefixed with this keyword.
An extension method can have only one binding parameter and that should be defined in the first place of the parameter list.
If required, an extension method can be defined with a normal parameter also starting from the second place of the parameter list.
 */