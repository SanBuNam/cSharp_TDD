using System;
using System.Collections.Generic;
using System.Text;

namespace cSharpConcepts
{
    // Inversion of Control and Dependency Injection
    // https://www.tutorialsteacher.com/ioc/dependency-injection
    public class CustomerBusinessLogic
    {
        DataAccess _dataAccess;
        public CustomerBusinessLogic()
        {
            _dataAccess = new DataAccess();
        }
        public string GetCustomerName(int id)
        {
            return _dataAccess.GetCustomerName(id);
        }
    }

    public class DataAccess
    {
        public DataAccess() {}
        public string GetCustomerName(int id)
        {
            return "Dummy Customer Name"; // get it from DB in real app
        }
    }
    // Dependency Injection(DI) is a design pattern used to implement IoC.It allows the creation of dependent objects outside of a class and provides those objects to a class through different ways.Using DI, we move the creation and binding of the dependent objects outside of the class that depends on them.

    // 
    // DIP
    public interface ICustomerDataAccess
    {
        string GetCustomerName(int id);
    }
    public class CustomerDataAccess : ICustomerDataAccess
    {
        public CustomerDataAccess() {}
        public string GetCustomerName(int id)
        {
            return "Dummy Customer Name";
        }
    }
    public class DataAccessFactory
    {
        public static ICustomerDataAccess GetCustomerDataAccessObj()
        {
            return new CustomerDataAccess();
        }
    }
    public class CustomerBusinessLogic1
    {
        ICustomerDataAccess _custDataAccess;

        public CustomerBusinessLogic1()
        {
            _custDataAccess = DataAccessFactory.GetCustomerDataAccessObj();
        }

        public string GetCustomerName(int id)
        {
            return _custDataAccess.GetCustomerName(id);
        }
    }
    // The problem with the above example is that we used DataAccessFactory inside the CustomerBusinessLogic class. So, suppose there is another implementation of ICustomerDataAccess and we want to use that new class inside CustomerBusinessLogic. Then, we need to change the source code of the CustomerBusinessLogic class as well. The Dependency injection pattern solves this problem by injecting dependent objects via a constructor, a property, or an interface.

    //
    // eq. Constructor Injection
    public interface ICustomerDataAccess2
    {
        string GetCustomerName2(int id);
    }
    public class CustomerDataAccess2 : ICustomerDataAccess2
    {
        public CustomerDataAccess2() { }
        public string GetCustomerName2(int id)
        {
            // get the customer name from the db in real application
            return "Dummy Customer Name";
        }
    }
    
    public class CustomerBusinessLogic2 
    {
        ICustomerDataAccess2 _dataAccess2;
        public CustomerBusinessLogic2(ICustomerDataAccess2 custDataAccess2)
        {
            _dataAccess2 = custDataAccess2;
        }
        public CustomerBusinessLogic2()
        {
            _dataAccess2 = new CustomerDataAccess2();
        }
        public string ProcessCustomerData(int id)
        {
            return _dataAccess2.GetCustomerName2(id);
        }
    }
    public class CustomerService
    {
        CustomerBusinessLogic2 _customerBL;
        public CustomerService()
        {
            _customerBL = new CustomerBusinessLogic2(new CustomerDataAccess2());
        }
        public string GetCustomerName(int id)
        {
            return _customerBL.ProcessCustomerData(id);
        }
    }
    // As you can see in the above example, the CustomerService class creates and injects the CustomerDataAccess object into the CustomerBusinessLogic class. Thus, the CustomerBusinessLogic class doesn't need to create an object of CustomerDataAccess using the new keyword or using factory class. The calling class (CustomerService) creates and sets the appropriate DataAccess class to the CustomerBusinessLogic class. In this way, the CustomerBusinessLogic and CustomerDataAccess classes become "more" loosely coupled classes.

    //
    // Property Injection
    public class CustomerBusinessLogic3
    {
        public CustomerBusinessLogic3() {}
        public string GetCustomerName(int id)
        {
            return DataAccess2.GetCustomerName2(id);
        }
        public ICustomerDataAccess2 DataAccess2 { get; set; }
    }

    public class CustomerService2
    {
        CustomerBusinessLogic3 _customerBL;
        public CustomerService2()
        {
            _customerBL = new CustomerBusinessLogic3();
            _customerBL.DataAccess2 = new CustomerDataAccess2();
        }
        public string GetCustomerName(int id)
        {
            return _customerBL.GetCustomerName(id);
        }
    }
    // As you can see above, the CustomerBusinessLogic class includes the public property named DataAccess, where you can set an instance of a class that implements ICustomerDataAccess. So, CustomerService class creates and sets CustomerDataAccess class using this public property.
    
    //
    // Method Injection
    interface IDataAccessDependency
    {
        void SetDependency(ICustomerDataAccess2 customerDataAccess2);
    }
    public class CustomerBusinessLogic4 : IDataAccessDependency
    {
        ICustomerDataAccess2 _dataAccess2;
        public CustomerBusinessLogic4() {}
        public string GetCustomerName(int id)
        {
            return _dataAccess2.GetCustomerName2(id);
        }
        public void SetDependency(ICustomerDataAccess2 customerDataAccess2)
        {
            _dataAccess2 = customerDataAccess2;
        }
    }
    public class CustomerService3
    {
        CustomerBusinessLogic4 _customerBL2;
        public CustomerService3()
        {
            _customerBL2 = new CustomerBusinessLogic4();
            ((IDataAccessDependency)_customerBL2).SetDependency(new CustomerDataAccess2());
        }
        public string GetCustomerName(int id)
        {
            return _customerBL2.GetCustomerName(id);
        }
    }
    // In the above example, the CustomerBusinessLogic class implements the IDataAccessDependency interface, which includes the SetDependency() method. So, the injector class CustomerService will now use this method to inject the dependent class (CustomerDataAccess) to the client class.


}
