using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafficWatchRest.Controllers;
using TrafficWatchRest.Model;
using System.Data.SqlClient;

namespace UnitTest
{
    [TestClass]
    public class UnitTestRest
    {
        [TestMethod]
        public void TestCustomerGetList() //Tester efter om GetAllCustomers() metoden henter den rigtige mængde kunder fra databasen
        {
           CustomerController cc = new CustomerController();
           IEnumerable<Customer> customerList1 = cc.GetAllCustomers();
           Assert.AreEqual(3, customerList1.Count());

         //  IEnumerable<Customer> customerList2 = cc.GetAllCustomers();
         //  Assert.AreEqual(0, customerList1.Count());
        }

        [TestMethod]
        public void TestCustomerGetById() //Tester efter om navnet stemmer overens med det valgte ID fra databasen 
        {
            CustomerController cc = new CustomerController();
            Customer customer1 = cc.GetCustomerByGoogleId("12234");
            Assert.AreEqual(customer1.FirstName, "liæl");

           //Customer customer2 = cc.GetCustomerById(6); 
           // Assert.AreEqual(customer2.FirstName, "Mrcel");
        }

        [TestMethod]
        public void TestCustomerGetByIdIsNull() //Tester efter på vores "CustomerGetById" og om det kan være null
        {
            CustomerController cc = new CustomerController();
            Customer customer1 = cc.GetCustomerByGoogleId("dnlk"); 
            Assert.IsNull(customer1);

           // Customer customer2 = cc.GetCustomerById(6);
           // Assert.IsNull(customer2);
        }

        [TestMethod]
        public void TestCustomerAdd() //Tester på vores "AddCustomer" metode
        {
            CustomerController cc = new CustomerController();
            IEnumerable<Customer> customerList = cc.GetAllCustomers();
            int preCount = customerList.Count();
            cc.AddCustomer(new Customer());
            Assert.AreEqual(preCount+1, customerList.Count());
        }

        [TestMethod]
        public void TestCustomerDelete() //Tester på vores "DeleteCustomer" metode
        {
            CustomerController cc = new CustomerController();
            IEnumerable<Customer> customerList = cc.GetAllCustomers();
            int preCount = customerList.Count();

            cc.DeleteCustomer(6);
            Assert.AreEqual(preCount-1, customerList.Count());

        }
    }
}
