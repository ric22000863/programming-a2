using Microsoft.VisualStudio.TestTools.UnitTesting;
using HappyHomesProgram;
using System;

namespace HappyHomesTests
{
    [TestClass]
    // Test to check if staff availability is correctly managed
    public class StaffTests
    {
        [TestMethod]
        public void IsAvailable_WhenTimeNotBooked_ReturnsTrue()
        {
            // Arrange - Adding staff member and checking availability
            var staff = new Staff(1, "Janice Doe");
            DateTime time = DateTime.Now;

            // Act - Check if the staff member is available
            bool available = staff.IsAvailable(time);

            // Assert - Confirm that the staff member is available
            Assert.IsTrue(available);
        }

        [TestMethod]
        public void IsAvailable_WhenTimeBooked_ReturnsFalse()
        {
            // Arrange - Adding staff member and marking them as unavailable
            var staff = new Staff(2, "Jenson");
            DateTime time = DateTime.Now;
            staff.MarkUnavailable(time);

            // Act - Check if the staff member is available
            bool available = staff.IsAvailable(time);

            // Assert - Confirm that the staff member is not available
            Assert.IsFalse(available);
        }
    }
}
