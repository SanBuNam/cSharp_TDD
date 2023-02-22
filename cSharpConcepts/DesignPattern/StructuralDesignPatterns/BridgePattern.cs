using System;
using System.Collections.Generic;
using System.Text;

namespace cSharpConcepts.DesignPattern.StructuralDesignPatterns
{
    // Bridge is a structural design pattern that devides business logic or huge class into separate class hierarchies that can be developed independently.
    // Lets you split a large class or a set of closely related classes into two separate hierarchies - abstraction and implementation - which can be developed independently of each other.

    /*
    One of these hierarchies (often called the Abstraction) will get a reference to an object of the second hierarchy (implementation).
    The abstraction will be able to delegate some (sometimes, most) of its calls to the implementations object.
    Since all implementations will have a common interface, they'd be interchangeable inside the abstraction.

    Usage : The Bridge pattern is especially useful when dealing with cross-platform apps, supporting multiple types of database servers
            or working with several API providers of a certain kind (for example, cloud platforms, social networks, etc.)
     */

    // The BridgeAbstraction defines the interface for the "control" part of the two class hierarchies.
    // It maintains a reference to an object of the implementation hierarchy and delegates all of the real work to this object.
    class BridgeAbstraction
    {
        protected IImplementation _implementation;

        public BridgeAbstraction(IImplementation implementation)
        {
            this._implementation = implementation;
        }

        public virtual string Operation()
        {
            return "Abstract: Base operation with:\n" + _implementation.OperationImplementation();
        }
    }
    // You can extend the Abstraction without changing the Implementation classes.
    class ExtendedBridgeAbstraction : BridgeAbstraction
    {
        public ExtendedBridgeAbstraction(IImplementation implementation) : base(implementation)
        {
        }

        public override string Operation()
        {
            return "ExtendedAbstraction: Extended operation with:\n" +
                base._implementation.OperationImplementation();
        }
    }

    /*
     The Implementation defines the interface for all implementation classes.
     It doesn't have to match the Abstraction's interface. In fact, the two interfaces can entirely different.
     Typically the Implementation interface provides only primitive operations, while the Abstraction defines higher level operations based on those primitives.
     */
    public interface IImplementation
    {
        string OperationImplementation();
    }
    // Each Concrete Implementation corresponds to a specific platform and implements the implementation interface using that platform's API.
    class ConcreteImplementationA : IImplementation
    {
        public string OperationImplementation()
        {
            return "ConcreteImplementationA: The result in platform A.\n";
        }
    }

    class ConcreteImplementationB : IImplementation
    {
        public string OperationImplementation()
        {
            return "ConcreteImplementationA: The result in platform B.\n";
        }
    }

    class Client
    {
        /*
         Except for the initialization phase,
        where an Abstraction object gets linked with a specific Implementation object, the client code should only depend on the BridgeAbstraction class. 
        This way the client code can support any asbtraction-implementation combination.
         */
        public void ClientCode(BridgeAbstraction bridgeAbstraction)
        {
            Console.WriteLine(bridgeAbstraction.Operation());
        }
    }

    class BridgeProgram
    {
        static void Main(string[] vs)
        {
            Client client = new Client();

            BridgeAbstraction bridgeAbstraction;
            // The client code should be able to work with any pre-configured abstraction-implementation combination.
            bridgeAbstraction = new BridgeAbstraction(new ConcreteImplementationA());
            client.ClientCode(bridgeAbstraction);

            Console.WriteLine();

            bridgeAbstraction = new ExtendedBridgeAbstraction(new ConcreteImplementationB());
            client.ClientCode(bridgeAbstraction);
        }
    }

}
