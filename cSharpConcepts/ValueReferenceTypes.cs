using System;
using System.Collections.Generic;
using System.Text;

namespace cSharpConcepts
{
    struct Point
    {
        // Put simply, Structs are cut-down classes. Imagine classes that don't support inheritance or finalizers, and you have cut-down version: the struct.
        // structs are defined in the same way as classes (except with the struct keyword), structs can have the same rich members, including fields, methods, properties and operators.
        private int x, y; // private fields

        public Point(int x, int y) // constructor
        {
            this.x = x;
            this.y = y;
        }

        public int X // property
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

    }
    /*
        Value and Reference Types
       Structs are value types, while classes are reference types.
       When a value-type instance is created, a single space in memory is allocated to store the value.
       Primitive types such as int, float, bool and char are also value types, and work in the same way.
       When the runtime deals with a value types, it's dealing directly with its underlying data and this can be very efficient, particularly with primitive types.

       With refrence types, however, an object is created in memory, and then handled through a separate reference-rather like a pointer.
       Suppose Point is a struct, and Form is a class.
    */
    class ValueReferenceTypes
    {
        Point p1 = new Point(); // Point is a struct
        Form f1 = new Form(); // Form is a class

        // In the first case, one space in memory is allocated for p1, wheras in the second case, two spaces are allocated:
        // one for a Form object and another for its reference(f1). 
        Form f1; // Allocate the reference
        f1 = new Form(); // Allocate the object
        // if we copy the objects to new variables:
        Point p2 = p1;
        Form f2 = f1;

        // p2, being a struct, becomes an independent copy of p1, with its own separate fields.
        // But in the case of f2, all we've copied is a reference, with the result that both f1 and f2 point to the same object.
        // This is of particular interest when passing parameters to methods. In C#, parameters are (by default) passed by value, meaning that they are implicitly copied when passed to the method.
        // For value-type parameters, this means physically copying the instance (in the same way p2 was copied),

        //  while for reference-type it means copying a reference (int the same way f2 was copied).

        Point myPoint = new Point(0, 0); // a new value-type variable
        Form myForm = new Form(); // a new reference-type variable
        Test(myPoint, myForm); // Test is a method defined below
        void Test(Point p, Form f)
        {
            p.X = 100; // No effect on MyPoint since p is a copy
            f.Text = "Hello, World!"; // This will chage myForm's caption since myForm and f point to the same object
            f = null; // No effect on myForm
        }

        /*
         Assigning null to f has no effect because f is a copy of a reference, and we've only erased the copy.
        We can change the way parameters are marshalled with the ref modifier. When passing by "reference", the method interacts directly with the caller's arguments. 
        In the example below, you can think of the parameters p and f being replaced by myPoint and myForm:
        */
        Point myPoint = new Point(0, 0);    // a new value-type variable
        Form myForm = new Form();           // a new reference-type variable
        Test(ref myPoint p, ref Form f);    // pass myPoint and myForm by reference

        void Test(ref Point p, ref Form f) {
            p.X = 100;                      // This will change myPoint's position
            f.Text = "Helo, World!";        // This will change MyForm's caption
            f = null;                       // This will nuke the myForm variable!
        }
        // In this case, assigning null to f also makes myForm null, because this time we're dealing with the original reference variable and not a copy of it.
    }
}
