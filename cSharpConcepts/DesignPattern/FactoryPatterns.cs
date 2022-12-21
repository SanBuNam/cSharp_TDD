using System;
using System.Collections.Generic;
using System.Text;

namespace cSharpConcepts.DesignPattern
{
    // The Factory Method is a creational design pattern that provides an interface for creating objects but allows subclasses to alter the type of an object that will be created.
    // If you have a creation method in base class and subclasses that extend it, you might be looking at the factory method.

    // The Abstract Factory is a creational design pattern that allows producing families of related or dependent objects without specifying their concrete classes.
    // If your program doesn't operate with product families, then you don't need an abstract factory.

    /*
     Builder is a creational design pattern that lets you construct complex objects step by step.
     The pattern allows you to produce different types and representations of an object using the same construction code.
     This is an approach that doesn't involve breeding subclasses.
     You can create a giant constructor right in the base House class with all possible parameters that control the house object.
     While this aproach indeed eliminates the need for subclasses, it creates another problem.
     In most cases most of the parameters will be unused, making "the contructor calls pretty ugly".
    
     You can create several different builder classes that implement the same set of building steps, but in a different manner.
     Then you can use these builders in the construction process to produce different kinds of objects. (Different builders execute the same task in various ways.
     
     */

}
