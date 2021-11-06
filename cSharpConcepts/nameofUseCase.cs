using System;
using System.Collections.Generic;
using System.Text;

namespace cSharpConcepts
{
    // A nameof expression produces the name of a variable, type, or member as the string contant: A nameof expression is available in C# 6 and later.
    /*
     Console.WriteLine(nameof(System.Collections.Generic));  // output: Generic
     Console.WriteLine(nameof(List<int>));  // output: List
     Console.WriteLine(nameof(List<int>.Count));  // output: Count
     Console.WriteLine(nameof(List<int>.Add));  // output: Add
     
     var numbers = new List<int> { 1, 2, 3 };
     Console.WriteLine(nameof(numbers));  // output: numbers
     Console.WriteLine(nameof(numbers.Count));  // output: Count
     Console.WriteLine(nameof(numbers.Add));  // output: Add
    */
    // As the preceding example shows, in the case of a type and a namespace, the produced name is not fully qualified.
    // In the case of verbatim identifiers, the @ charter is not the part of a name, as the following example shows:
    /*
       var @new = 5;
        Console.WriteLine(nameof(@new)); // output: new
     */

    // A nameof expression is evaluated at complie time and has no effect at run time.
    // You can use a nameof expression to make the argument-checking code more maintainable:

    /*
       public string Name
       {
           get => name;
           set => name = value ?? throw new ArgumentNullException(nameof(value), $"{nameof(Name)} cannot be null");
       }
     */

    /*
       switch (e.PropertyName)
       {
            case nameof(SomeProperty):
                { break; }
            
            // opposed to
            case "SomeOtherProperty":
                { break; }
        }
     */
}
