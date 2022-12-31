using System;
using System.Collections.Generic;
using System.Text;

namespace cSharpConcepts.DesignPattern.StructuralDesignPatterns
{
    // Structural design patterns explain how to assemble objects and classes into larger structures, while keeping these structures flexible and efficient.
    /*
    Adapter is a structural design pattern, which allows incompatible objects to collaborate.
    The Adapter acts as a wrapper between two objects. 
    It catches calls for one object and transforms them to format and interface recongnizable by the second object.
     */
    // The target defines the domain-specific interface used by the client code.
    public interface ITarget
    {
        string GetRequest();
    }

    /*
     The Adaptee contains some useful behavior, but its interface is incompatible with the existing client code.
     The Adptee needs some adptation before the client code can use it.
     */
    class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific request.";
        }
    }

    // The Adapter makes the Adaptee's interface compatible with the Target's interface.
    class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;
        public Adapter(Adaptee adaptee)
        {
            this._adaptee = adaptee;
        }
        public string GetRequest()
        {
            return $"This is '{this._adaptee.GetSpecificRequest()}'";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Adaptee interface is incompatible with the client.");
            Console.WriteLine("But with adapter client can call it's method.");

            Console.WriteLine(target.GetRequest());
            /*
             Output:
             Adaptee interface is incompatible with the client.
             But with adapter client can call it's method.
             This is 'Specific request.
             */
        }
    }
}
