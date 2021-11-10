using System;
using System.Collections.Generic;
using System.Text;

namespace cSharpConcepts
{
    // ref-https://exceptionnotfound.net/csharp-in-simple-terms-3-casting-conversion-parsing-is-as-and-typeof/
    class CastingConversionParsing
    {
        /* 
         Casting 
         is taking an object and attempting to "force" it to change types.
         Cast a value by placing the targeted type in parentheses () next to the value want to cast.
        */
        int five = 5;
        var doubleFive = (double)five;

        char a = 'a';
        var valueA = (int)a;

        float myFloat = 4.56F;
        decimal myMoney = (decimal)myFloat;

        // Some casts will fail because the types are not compatible, normal way to convert a string to any other type is through parsing.
        string myString = "This is a sentence";
        byte myByte = (byte)myString;

        /*
         Casting from a more-precise type to a less-precise type will result in a loss of precision
        b/c of this, I need to be careful when converting more-precise types (e.g. the floating-point numeric types)
        to less-precise types (int, long, char, etc).
         */
        decimal myMoney = 5.87M;
        int intMoney = (int)myMoney; // value is now 5; the .87 was lost

        /* 
         Conversion 
         is similar to a cast in that it takes a value of particular type and changes it into a value of another type.
         However, conversions are more forgiving than casts, generally do not lose precision, and take computationally longer to execute.
         .NET Framework provides us with a class called Convert. This class can take values from all the primitive types and attempt to convert them to all other primitive types.
        */
        int six = 6;
        decimal decSix = Convert.ToDecimal(six);
        decimal myDon = 6.67M;
        int intMyDon = Convert.ToInt32(myDon); // Value is not 6; the decimal value was rounded
        /* 
         When casting a floating-point numeric type to an integral numeric type, 
        the numbers after the decimal point are lost. When converting, 
        the value is instead rounded to the nearest whole number using a methodology known as "banker's rounding": 
        if the number is exactly halfway between two whole numbers the even number is returned 
        (e.g. if the number is 4.5, return 4; if the number is 5.5, return 6); otherwise, round to the nearest whole number.
        The Convert class can also handle numeric to non-numeric and vice-versa conversions, such as:
        Generally speaking, casting is fater but more prone to errors, and conversion is slower but more likely to succeed.
         */
        string seven = "7.0";
        decimal decSeven = Convert.ToDecimal(seven); // value is 7.0

        double myValue = 5.33;
        string stringValue = Convert.ToString(myValue); // value is "5.33"

        int intTrue = 1;
        bool isTrue = Convert.ToBoolean(intTue); // value is ture b/c number is not 0


        /*
         Parse()
        the string type has a unique place among the C# primitive types.
        Because it is a reference type, it needs special handling when converting from it to other types. I call this parsing.
        .NET Framework provides us with Parse() and TryParse() methods on each primitive type to handle converting from a string to that type.
         */
        string decString = "5.632";
        decimal decValue = decimal.Parse(decString); // value is 5.632M
        // if the string cannot be parsed to an acceptable value for the target type, the Parse() method will throw an exception:
        string testString = "10.22.2000";
        double decValue = double.Parse(testString); // Exception thrown here.

        string intTest = "this is a test string";
        int intValue = int.Parse(intTest); // Exception thrown

        // TryParse()
        // For situations where we don't know if the string value can be parsed to the desired type, we can use TryParse() :
        string value = "5.0";
        decimal result;
        bool isValid = decimal.TryParse(value, out result);
        // If isValid is true, then the string value was successfully parsed and is now the value of the variable result.


        /*
         Is Keyword
        There are occasions in which we do not know the specific type of a given object.
        Often this happens if the code retrieved the object from another source, such as an external database, API, or service.
        For this situation, C# provides us with the is keyword which tests if an object is of a particular type:
         */
        var myIsValue = 6.5M; // M literal means type will be decimal
        if(myIsValue is decimal) { /*...*/}
        // The is keyword returns true if the object is of the specified type, and false otherwise.

        /* 
         AS Keyword 
        For reference types, C# provides us with the as keyword to convert one reference type to another.
         */
        string testAsString = "This is a test AS"; // string is a reference type
        object objString = (object)testAsString; // Cast the string to an object
        string test2 = objString as string; // Will convert to string successfully
        // Note that this only works on valid conversions; types do not have a defined conversion will throw an exception:
        public class ClassA { /*...*/ }
        public class ClassB { /*...*/ }
        var myClass = new ClassA();
        var newClass = myClass as ClassB; // Exception thrown
        // However, classes which inherit from one another can be freely converted using as:
        public class ClassA2 { /*...*/ }
        public class ClassB2 : ClassA2 { /*...*/ }
        var myClass2 = new ClassB2();
        var convertedClass = myClass2 as ClassA2;

        /* GetType() and Typeof */
        // For any given object in C#, we can get its type as an object by calling the GetType() method:
        var sentense = "This is a sentence.";
        var type = sentense.GetType();
        // We can then check if the given type is a known type, such as a primitive, a class, or others by using the typeof Keyword
        if(Type == typeof(string)) { /*...*/ }
        else if (Type == typeof(int)) { /*...*/ }

        /*
        Glossary
        1. Casting - "Forcing" a value from one type to another type; prone to errors.
        2. Conversion - Attempting to change one object's type to another; more forgiving but computationally more expensive.
        3. Parsing - Attempting to convert a string to a different primitive type.

        New Keywords
        1. is - Used to check if a particular value is of a given type.
        2. as - Used to convert an object from one type to another.
        3. typeof - Returns the type of a given object.
        */
    }
}
