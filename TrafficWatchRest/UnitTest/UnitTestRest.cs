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
        public void TestCustomerGetList() //Tester efter om GetAllCustomers() metoden henter den rigtige m�ngde kunder fra databasen
        {
           CustomerController cc = new CustomerController();
           IEnumerable<Customer> customerList1 = cc.GetAllCustomers();
           Assert.AreEqual(4, customerList1.Count());

         //  IEnumerable<Customer> customerList2 = cc.GetAllCustomers();
         //  Assert.AreEqual(0, customerList1.Count());
        }

        [TestMethod]
        public void TestCustomerGetById() //Tester efter om navnet stemmer overens med det valgte ID fra databasen 
        {
            CustomerController cc = new CustomerController();
            Customer customer1 = cc.GetCustomerById(8);
            Assert.AreEqual(customer1.FirstName, "Marcel");

           //Customer customer2 = cc.GetCustomerById(6); 
           // Assert.AreEqual(customer2.FirstName, "Mrcel");
        }

        [TestMethod]
        public void TestCustomerGetByIdIsNull() //Tester efter p� vores "CustomerGetById" og om det kan v�re null
        {
            CustomerController cc = new CustomerController();
            Customer customer1 = cc.GetCustomerById(1); 
            Assert.IsNull(customer1);

           // Customer customer2 = cc.GetCustomerById(6);
           // Assert.IsNull(customer2);
        }

//        [TestMethod]
//        public void TestCustomerInsert() //Tester p� vores "AddCustomer" metode
//        {
//            CustomerController cc = new CustomerController();
//            IEnumerable<Customer> customerList = cc.GetAllCustomers();
//            int preCount = customerList.Count();
//            cc.InsertCustomer("6", "Joffrey@cunt.org", "Joffrey", "Baratheon", false);
//            Assert.AreEqual(preCount+1, customerList.Count());
//        }

        [TestMethod]
        public void TestCustomerUpdate() //Tester p� vores "AddCustomer" metode
        {
            CustomerController cc = new CustomerController();
            cc.UpdateCustomer(9, "Hans@gmail.com", "Hans", "Hansen", 1, 1, 1);
            Assert.AreEqual(cc.GetCustomerById(9).FirstName, "Hans");
        }


        //        [TestMethod]
        //        public void TestCustomerDelete() //Tester p� vores "DeleteCustomer" metode
        //        {
        //            CustomerController cc = new CustomerController();
        //            IEnumerable<Customer> customerList = cc.GetAllCustomers();
        //            int preCount = customerList.Count();
        //
        //            cc.DeleteCustomer(6);
        //            Assert.AreEqual(preCount-1, customerList.Count());
        //
        //        }
    }
}
