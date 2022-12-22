using System;
using System.Collections.Generic;
using System.Text;

namespace cSharpConcepts.DesignPattern
{
    // -- CREATIONAL PATTERNS --
    // Factory is an ambigous term that stands for a function, method or class that supposed to be producing something.
    // Most commonly, factories produce objects. But they may also produce files, records in databases, etc.

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
     However, this would only work if the client code that calls the building steps is able to interact with builders using a common interface.
    
     - Director -
     You can extract a series of calls to the builder steps you use to construct a product into a separate class called director.
     The director class defines the order in which to execute the building steps, while the builder provides the implementation for those steps.
     The director class might be a good place to put various construction routines so you can reuse them across your program.
     In addition, the director class completely hides the details of product construction from the client code.
     */

    /*
     The Prototype pattern delegates the cloning process to the actual objects that are being cloned.
     The pattern declares a common interface for all objects that support clone. 
     This interface lets you clone an object without coupling your code to the class of that object.
     Usually, such an interface contains just a single clone method.
     
     The implementation of the clone method is very similar in all classes. The method creates an object of the current class 
     and carries over all of the field values of the old object into the new one. 
     You can even copy private fields because most programming languages let objects access private fields of other objects that belong to the same class.
     (Pre-buit prototype s can be an alternative to subcalssing)
     An objecat that supports cloning is called a prototype. When your objects have dozens of fields and hundreds of possible configurations, clonging them might serve as an alternative to subclassing.
     
     Use the Prototype pattern when your code shouldn't depend on the concrete classes of objects that you need to copy.
     */


    /* Singleton is a creational design pattern that lets you ensure that a class has only one instance, while providing a global access point to this instance.
    1. Ensure that a class has just a single instance 2. Provide a global access point to that instance
    Just like a global variable, the Singleton pattern lets you access some object from anywhere in the program.
    However, it also protects that instance from being overwritten by other code. */


    // -- example --
    /* The Creator class declares the factory method that is supposed to return an object of a Product class.
    The Creator's subclasses usually provide the implementation of this method. */
    // The Product interface declares the operations that all concrete products must implement.
    public interface IProduct
    {
        string Operation();
    }

    abstract class Creator
    {
        // Note that the Creator may also provide some default implementation of the factory method.
        public abstract IProduct FactoryMethod();
        /* Also note that, despite its name, the Creator's primary responsibility is not creating products.
       Usually, it contains some core business logic that relies on Product objects, returned by the factory method.
       Subclasses can indirectly change that business logic by overridding the factory method and returning a different type of product from it. */
        public string SomeOperation()
        {
            // Call the factory method to create a Product object.
            var product = FactoryMethod();
            // Now, use the product.
            var result = "Creator: The same creator's code has just worked with " + product.Operation();

            return result;
        }
    }

    // Concrete Creators override the factory method in order to change the resulting product's type.
    class ConcreteCreator1 : Creator
    {
        // Note that the signature of the method still uses the abstract product type,
        // even though the concrete product is actually returned from the method.
        // This way the Creator can stay independent of concrete product classes.
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct1();
        }
    }

    class ConcreteCreator2 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct2();
        }
    }

    // Concrete Products provide various implementations of the Product interface.
    class ConcreteProduct1 : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProduct1}";
        }
    }

    class ConcreteProduct2 : IProduct 
    { 
        public string Operation()
        {
            return "Result of ConcreteProduct2";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("App: Launched with the ConcreteCreator1.");
            ClientCode(new ConcreteCreator1());
            Console.WriteLine("");
            Console.WriteLine("App: Launched with the ConcreteCreator2.");
            ClientCode(new ConcreteCreator2());
        }
        // The client code works with an instance of a concrete creator, albeit through its base interface.
        // As long as the client keeps working with the creator via theh abse interface, you can pass it any creator's subclass.
        private void ClientCode(Creator creator)
        {
            Console.WriteLine("Client: I'm not aware of the creator's class," +
                "but it still works.\n" + creator.SomeOperation());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}
