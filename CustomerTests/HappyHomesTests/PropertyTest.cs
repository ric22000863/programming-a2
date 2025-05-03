using Microsoft.VisualStudio.TestTools.UnitTesting;
using HappyHomesProgram;

namespace HappyHomesTests
{
    [TestClass]
    public class PropertyTests
    {
        // Testing if property details are stored correctly
        [TestMethod]
        public void Property_Creation_SetsAllProperties()
        {
            // Arrange – Adding test property details
            int id = 2;
            string address = "5 Rocky Road";
            string type = "Semi-Detached";

            // Act – Create a new property
            var property = new Property(id, address, type);

            // Assert – Check if the details match
            Assert.AreEqual(id, property.Id);
            Assert.AreEqual(address, property.Address);
            Assert.AreEqual(type, property.Type);
        }
    }
}
