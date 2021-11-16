using System;
using System.Collections.Generic;
using System.Text;

namespace cSharpConcepts
{
    class ShallowCopyAndDeepCopy
    {
        // Understanding Shallow Copy in C#:
        static void ShallowCopy(string[] args)
        {
            Employee emp1 = new Employee();
            emp1.Name = "Anurag";
            emp1.Department = "IT";
            emp1.EmpAddress = new Address() { address = "BBSR" };
            Employee emp2 = emp1.GetClone();
            emp2.Name = "Pranaya";
            emp2.EmpAddress.address = "Mumbai";
            Console.WriteLine("Employee 1: ");
            Console.WriteLine("Name: " + emp1.Name + ", Address: " + emp1.EmpAddress.address + ", Dept: " + emp1.Department);
            Console.WriteLine("Employee 2: ");
            Console.WriteLine("Name: " + emp2.Name + ", Address: " + emp2.EmpAddress.address + ", Dept: " + emp2.Department);
            Console.Read();
        }
    }
    // Employee 1: Name: Anurag, Address: Mumbai, Dept: IT
    // Employee 2: Name: Pranaya, Address: Mumbai, Dept: IT
    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public Address EmpAddress { get; set; }

        public Employee GetClone()
        {
            return (Employee)this.MemberwiseClone();
        }
    }

    public class Address
    {
        public string address { get; set; }
    }
}

// Understanding Shallow Copy in C#:
namespace PrototypeDesignPattern
{
    class DeepCopy
    {
        static void DeepCopyMain(string[] args)
        {
            Employee emp1 = new Employee();
            emp1.Name = "Anurag";
            emp1.Department = "IT";
            emp1.EmpAddress = new Address() { address = "BBSR" };
            Employee emp2 = emp1.GetClone();
            emp2.Name = "Pranaya";
            emp2.EmpAddress.address = "Mumbai";
            Console.WriteLine("Employee 1: ");
            Console.WriteLine("Name: " + emp1.Name + ", Address: " + emp1.EmpAddress.address + ", Dept: " + emp1.Department);
            Console.WriteLine("Employee 2: ");
            Console.WriteLine("Name: " + emp2.Name + ", Address: " + emp2.EmpAddress.address + ", Dept: " + emp2.Department);
            Console.Read();
        }
    }
    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public Address EmpAddress { get; set; }
        public Employee GetClone()
        {
            Employee employee = (Employee)this.MemberwiseClone();
            employee.EmpAddress = EmpAddress.GetClone();
            return employee;
        }
    }
    public class Address
    {
        public string address { get; set; }
        public Address GetClone()
        {
            return (Address)this.MemberwiseClone();
        }
    }
    // Employee 1: Name: Anurag, Address: BBSR, Dept: IT
    // Employee 2: Name: Pranaya, Address: Mumbai, Dept: IT
}