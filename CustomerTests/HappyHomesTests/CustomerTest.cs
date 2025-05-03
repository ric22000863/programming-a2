using HappyHomesProgram;

namespace HappyHomesTests
{
    [TestClass]
    public class CustomerTests
    {
        // Testing the process of creating a new customer and storing their details
        [TestMethod]
        public void Customer_Creation_SetsAllProperties()
        {
            // Arrange – Set up test data for a new customer
            int id = 1;
            string name = "Jane Doe";
            string email = "janedoe@email.com";
            string address = "1 Anoymous Road";
            string phone = "07466 090066";

            // Act – Create a new customer with the given details
            var customer = new Customer(id, name, email, address, phone);

            // Assert - Confirm all the details are correctly stored
            Assert.AreEqual(id, customer.Id);
            Assert.AreEqual(name, customer.FullName);
            Assert.AreEqual(email, customer.Email);
            Assert.AreEqual(address, customer.CurrentAddress);
            Assert.AreEqual(phone, customer.Telephone);
            Assert.AreEqual(0, customer.MissedViewings); // New customers start with 0 missed viewings
            Assert.IsFalse(customer.IsBanned);           // New customers are not banned
        }
    }
}
