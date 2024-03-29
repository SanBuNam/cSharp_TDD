﻿using System;
using System.Collections.Generic;
using System.Text;

namespace cSharpConcepts.DesignPattern
{
    class BuilderPattern
    {
        /*
        Builder is a creational design pattern, which allows constructing complex objects step by step.
        Unlike other creational patterns, Builder doesn't require products to have a common interface.
        That makes it possible to produce different products using the same construction process.
         */

        // The Builder interface specifies methods for creating the different parts of the product objects.
        public interface IBuilder
        {
            void BuildPartA();
            void BuildPartB();
            void BuildPartC();
        }
        // The Concrete Builder classes follow the Builder interface and provide specific implementations of the building steps.
        // Your program may have several variations of Builders, implemented differently.
        public class ConcreteBuilder : IBuilder
        {
            private Product _product = new Product();
            // A fresh builder instance should contain a blank product object, which is used in further assembly.
            public ConcreteBuilder()
            {
                this.Reset();
            }
            public void Reset()
            {
                this._product = new Product();
            }
            // All production steps work with the same product instance.
            public void BuildPartA()
            {
                this._product.Add("PartA1");
            }
            public void BuildPartB()
            {
                this._product.Add("PartB1");
            }
            public void BuildPartC()
            {
                this._product.Add("PartC1");
            }
            // Concrete Builders are supposed to provide their own methods for retrieving results.
            // That's because various types of builders may create entirely different products that don't follow the same interface.
            // Therefore, such methods cannot be declared in the base Builder interface (at least in a statically typed programming language).
            // Usually, after returning the end result to the client, a builder instance is expected to be ready to start producing another product.
            // That's why it's a usual practice to call the reset method at the end of the `GetProduct` method body.
            // However, this behavior is not mandatory, and you can make yoru builders wait for an explicit reset call from the client code before disposing of the previous result.
            public Product GetProduct()
            {
                Product result = this._product;
                this.Reset();
                return result;
            }
        }
        // It makes sense to use the Builder pattern only when your products are quite complex and require extensive configuration.
        // Unlike in other creational patterns, different concrete builders can produce unrelated products.
        // In other words, results of various builders may not always follow the same interface.
        public class Product
        {
            private List<object> _parts = new List<object>();
            public void Add(string part)
            {
                this._parts.Add(part);
            }
            public string ListParts()
            {
                string str = string.Empty;
                for (int i = 0; i < this._parts.Count; i++)
                {
                    str += this._parts[i] + ", ";
                }
                str = str.Remove(str.Length - 2); // removing last ",C"
                return "Product parts: " + str + "\n";
            }
        }
        
        // The Director is only responsible for executing the building steps in a particular sequence.
        // It is helpful when producing products according to a specific order or configuration.
        // Strictly speaking, the Director class is optional, since the client can control builders directly.
        public class Director
        {
            private IBuilder _builder;
            public IBuilder Builder
            {
                set { _builder = value; }
            }
            // The Dicrector can construct several product variations using the same building steps.
            public void BuildMinimalViableProduct()
            {
                this._builder.BuildPartA();
            }
            public void BuildFullFeatureProduct()
            {
                this._builder.BuildPartA();
                this._builder.BuildPartB();
                this._builder.BuildPartC();
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                // The client code creates A builder object, passes it to the director and then initiates the construction process.
                // The end result is retrieved from the builder object.
                var director = new Director();
                var builder = new ConcreteBuilder();
                director.Builder = builder;
                Console.WriteLine("Standard basic product:");
                director.BuildMinimalViableProduct();
                Console.WriteLine(builder.GetProduct().ListParts());
                Console.WriteLine("Standard full featured product:");
                director.BuildFullFeatureProduct();
                Console.WriteLine(builder.GetProduct().ListParts());
                // Remember, the Builder pattern can be used without a Director class.
                Console.WriteLine("Custom product:");
                builder.BuildPartA();
                builder.BuildPartB();
                builder.BuildPartC();
                Console.Write(builder.GetProduct().ListParts());
            }
        }
    }
}
