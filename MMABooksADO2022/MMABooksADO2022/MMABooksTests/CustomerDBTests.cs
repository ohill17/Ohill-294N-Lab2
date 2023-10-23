using MMABooksBusinessClasses;
using MMABooksDBClasses;
using NUnit.Framework;

namespace MMABooksTests
{
    public class CustomerDBTests
    {

        [Test]
        public void TestGetCustomer()
        {
            Customer c = CustomerDB.GetCustomer(1);
            Assert.AreEqual(1, c.CustomerID);
        }

        [Test]
        public void TestCreateCustomer()
        {
            Customer c = new Customer();
            c.Name = "Mickey Mouse";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";

            int customerID = CustomerDB.AddCustomer(c);
            c = CustomerDB.GetCustomer(customerID);
            Assert.AreEqual("Mickey Mouse", c.Name);
        }
        [Test]
        public void TestUpdateCustomer()
        {
            Customer c = new Customer();
            c.Name = "Mickey Mouse";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";

            int customerID = CustomerDB.AddCustomer(c);
            Assert.IsTrue(customerID > 0);
            c = CustomerDB.GetCustomer(customerID);

            Customer b = new Customer();
            b.Name = "Minney Mouse";
            b.Address = "102 Main Street";
            b.City = "Greeley";
            b.State = "AL";
            b.ZipCode = "15664";

            bool Update = CustomerDB.UpdateCustomer(c, b);

            Assert.IsTrue(Update);

        }

        [Test]
        public void TestDeleteCustomer()
        {
            Customer c = new Customer();
            c.Name = "Mickey Mouse";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";

            int customerID = CustomerDB.AddCustomer(c);
            Assert.IsTrue(customerID > 0);
            CustomerDB.DeleteCustomer(c);
            Assert.AreEqual(CustomerDB.GetCustomer(customerID), null);
            
            //Ive been messing with this for 1.5 hours and i dont think im gonna get it :(
        


        }
    }
}
