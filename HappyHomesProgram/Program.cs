using System;
using System.Collections.Generic;
using System.Linq;
using HappyHomesProgram;

List<Property> properties = new List<Property>();
List<Customer> customers = new List<Customer>();
List<Staff> staffMembers = new List<Staff>();
List<Viewing> viewings = new List<Viewing>();
int nextPropertyId = 1;
int nextCustomerId = 1;
int nextStaffId = 1;
int nextViewingId = 1;

bool running = true;
while (running)
{
    Console.WriteLine("Welcome to HappyHomes Property Viewing System");
    Console.WriteLine("Please select an option:");
    Console.WriteLine("1. Book a Viewing");
    Console.WriteLine("2. Add a Property");
    Console.WriteLine("3. Add a Staff Member");
    Console.WriteLine("4. Update a Viewing Status");
    Console.WriteLine("5. Find Customer by Name");
    Console.WriteLine("6. Find Property by Address");
    Console.WriteLine("7. Exit");
    Console.WriteLine("Enter your choice: ");

    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            // Call book viewing method
            AddBooking();
            break;

        case 2:
            // Call add property method
            Property.AddProperty(properties, ref nextPropertyId);
            break;

        case 3:
            // Call add staff method
            Staff.AddStaff(staffMembers, ref nextStaffId);
            break;

        case 4:
            // Call update viewing status method
            Viewing.UpdateViewingStatus(viewings);
            break;

        case 5:
            // Call filter customer method
            Customer.FilterCustomerByName(customers);
            break;

        case 6:
            // Call filter property method
            Property.FilterPropertyByName(properties);
            break;

        case 7:
            // Exit program
            Console.WriteLine("Exiting the program.");
            running = false;
            break;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}

// Method to book a viewing and store customer details
void AddBooking()
{
    // User enters the customer details
    Console.WriteLine("Enter Customer Email: ");
    string email = Console.ReadLine().Trim().ToLower();

    Console.Write("Enter Customer Phone: ");
    string phone = Console.ReadLine().Trim();

    // Try to find an existing customer
    Customer customer = customers.FirstOrDefault(c =>
        c.Email.ToLower() == email && c.Telephone == phone);

    if (customer != null)
    {
        Console.WriteLine($"Existing customer found: ID {customer.Id}, Name: {customer.FullName}");
    }
    else
    {
        Console.Write("Existing Customer Not Found. Enter Full Name: ");
        string name = Console.ReadLine();
        Console.Write("Current Address: ");
        string address = Console.ReadLine();

        customer = new Customer(nextCustomerId++, name, email, address, phone);
        customers.Add(customer);

        Console.WriteLine($"New customer added. Customer ID: {customer.Id}");
    }

    // Check if the customer is banned
    if (customer.MissedViewings >= 3)
    {
        Console.WriteLine("This customer is banned from booking viewings.");
        customer.IsBanned = true;
        return;
    }

    if (customer.IsBanned)
    {
        Console.WriteLine("This customer is banned from booking viewings.");
        return;
    }

    // Lists all available properties and staff members
    Console.WriteLine("\nAvailable Properties:");
    foreach (var p in properties)
        Console.WriteLine($"ID: {p.Id}, Address: {p.Address}, Type: {p.Type}");

    // User selects the property to book
    Console.Write("Enter property ID: ");
    int propertyId = Convert.ToInt32(Console.ReadLine());
    Property property = properties.FirstOrDefault(p => p.Id == propertyId);
    if (property == null)
    {
        Console.WriteLine("Property not found.");
        return;
    }

    Console.WriteLine("Staff:");
    foreach (var s in staffMembers)
        Console.WriteLine($"ID: {s.Id}, Name: {s.Name}");

    // Available staff member is selected
    Console.Write("Enter staff ID: ");
    int staffId = Convert.ToInt32(Console.ReadLine());
    Staff staff = staffMembers.FirstOrDefault(s => s.Id == staffId);
    if (staff == null)
    {
        Console.WriteLine("Staff member not found.");
        return;
    }

    // User enters the date and time for the viewing
    Console.Write("Enter date and time for viewing (yyyy-mm-dd hh:mm): ");
    DateTime dateTime = DateTime.Parse(Console.ReadLine());

    // Check if the staff member is available at that time
    if (!staff.IsAvailable(dateTime))
    {
        Console.WriteLine("The selected staff member is already booked at that time.");
        return;
    }

    // Create a new viewing
    Viewing viewing = new Viewing(nextViewingId++, customer, property, staff, dateTime);
    viewings.Add(viewing);

    // After adding viewing
    staff.MarkUnavailable(dateTime);

    Console.WriteLine($"Viewing booked successfully. Viewing ID: {viewing.Id}");
}
