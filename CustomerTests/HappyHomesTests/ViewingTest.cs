using Microsoft.VisualStudio.TestTools.UnitTesting;
using HappyHomesProgram;
using System;

namespace HappyHomesTests
{
    [TestClass]
    public class ViewingTests
    {
        [TestMethod]
        // Testing if viewing details are stored correctly and are marked as booked by default
        public void Viewing_Creation_SetsDefaultStatusToBooked()
        {
            // Arrange – Set up the related customer, property, and staff
            var customer = new Customer(1, "Jack Doe", "jackdoe@email.com", "7 Flapjack Road", "07594059932");
            var property = new Property(1, "13 Cheesecake Road", "Detached");
            var staff = new Staff(1, "Jasmine Doe");
            DateTime dateTime = DateTime.Now;

            // Act – Create a viewing using the above details
            var viewing = new Viewing(1, customer, property, staff, dateTime);

            // Assert – Ensure all properties are assigned correctly and status defaults to "booked"
            Assert.AreEqual("booked", viewing.Status);
            Assert.AreEqual(customer, viewing.Customer);
            Assert.AreEqual(property, viewing.Property);
            Assert.AreEqual(staff, viewing.Staff);
            Assert.AreEqual(dateTime, viewing.DateTime);
        }
    }
}
