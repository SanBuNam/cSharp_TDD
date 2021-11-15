using System;
using System.Collections.Generic;
using System.Text;

namespace cSharpConcepts
{
    // throw in c# Signals the occurrence of an exception during program execution.
    // The following example uses the throw statement to throw an IndexOutOfRangeException
    // if the argument passed to a method named GetNumber does not correspond to a valid index of an internal array.
    public class NumberGenerator
    {
        int[] numbers = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
        public int GetNumber(int index)
        {
            if (index < 0 || index >= numbers.Length)
            {
                throw new IndexOutOfRangeException();
            }
            return numbers[index];
        }
    }

    // Method callers then use a try-catch or try-catch-finally block to handle the thrown exception.
    // The example displays the following output:
    // IndexOutOfRangeException: 10 is outside the bounds of the array
    public class ThrowExample
    {
        public static void ThrowExamp()
        {
            var gen = new NumberGenerator();
            int index = 10;
            try
            {
                int value = gen.GetNumber(index);
                Console.WriteLine($"Retrieved {value}");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"{e.GetType()}: {index} is outside the bounds of the array");
            }
        }
    }

    // Re-throwing an exception
    // throw can also be used in a catch block to re-throw an exception handled in a catch block.
    // In this case, throw does not take an exception operand. It is most useful when a method passes on an argument from a caller to some other library method,
    // and the library method throws an exception that must be passed on to the caller. For example, the following example re-throws an NullReferenceException that is
    // thrown when attempting to retrieve the first character of an uninitialized string.
    public class Sentence
    {
        public Sentence(string s)
        {
            Value = s;
        }
        public string Value { get; set; }
        public char GetFirstCharacter()
        {
            try
            {
                return Value[0];
            }
            catch (NullReferenceException e)
            {
                throw;
            }
        }
    }

    public class RethrowExample
    {
        public static void RethrowExamp()
        {
            var s = new Sentence(null);
            Console.WriteLine($"The first character is {s.GetFirstCharacter()}");
        }
        // The example displays the following output:
        //    Unhandled Exception: System.NullReferenceException: Object reference not set to an instance of an object.
        //       at Sentence.GetFirstCharacter()
        //       at Example.Main()

        /* The throw expression */
        // Starting with C# 7.0 throw can be used as an expression as well as a statement.
        // This allows an exception to be thrown in contexts that were previously unsupported.
        // the conditional operator. The following examples uses a throw expression to throw an ArgumentException if a method is passed an empty string array.
        // Before C# 7.0 this logic would need to appear in an if/else statement.
        private static void DisplayFirstNumber(string[] args)
        {
            string arg = args.Length >= 1 ? args[0] : throw new ArgumentException("You must supply an argument");

            if (Int64.TryParse(arg, out var number))
                Console.WriteLine($"You entered {number:F0}");
            else
                Console.WriteLine($"{arg}  is not a number.");
        }

        // the null-coalescing operator. In the following example, a throw expression is used with a null-coalescing operator to throw an exception if the string assigned to a Name property is null.
        public string Name
        {
            get => Name;
            set => Name = value ??
                throw new ArgumentNullException(paramName: nameof(value), message: "Name connot be null" );
        }

        // an expression-bodied lambda or method. The following example illustrates an expression-bodied method that throws an InvalidCastException because a conversion to a DateTime value is not supported.
        DateTime ToDateTime(IFormatProvider provider) =>
            throw new InvalidCastException("Converation to a DateTime is not supported.");

    }

}
