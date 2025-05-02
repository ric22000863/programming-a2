// See https://aka.ms/new-console-template for more information

//
using System.Transactions;
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
            AddProperty();
            break;

        case 3:
            // Call add staff method
            AddStaff();
            break;

        case 4:
            // Call update viewing status method
            UpdateViewingStatus();
            break;

        case 5:
            // Call filter customer method
            FilterCustomerByName();
            break;

        case 6:
            // Call filter property method
            FilterPropertyByName();
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

    // Method to store property details
    void AddProperty()
    {
        // User enters the details of the property
        Console.Write("Enter property address: ");
        string address = Console.ReadLine();
        Console.Write("Enter property type (Detached, Flat, etc.): ");
        string type = Console.ReadLine();

        Property property = new Property(nextPropertyId++, address, type);
        properties.Add(property);

        Console.WriteLine($"Property added successfully. \nProperty ID is: {property.Id}");
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
        c.Email.ToLower() == email || c.Telephone == phone);

    if (customer != null)
    {
        Console.WriteLine($"Existing customer found: ID {customer.Id}, Name: {customer.FullName}");
    }
    else
    {
        Console.Write("Full Name: ");
        string name = Console.ReadLine();
        Console.Write("Current Address: ");
        string address = Console.ReadLine();

        customer = new Customer(nextCustomerId++, name, email, address, phone);
        customers.Add(customer);

        Console.WriteLine($"New customer added. ID: {customer.Id}");
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

    Console.WriteLine("\nAvailable Staff:");
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

    // Createa a new viewing
    Viewing viewing = new Viewing(nextViewingId++, customer, property, staff, dateTime);
    viewings.Add(viewing);

    // After adding viewing
    staff.MarkUnavailable(dateTime);

    Console.WriteLine($"Viewing booked successfully. Viewing ID: {viewing.Id}");
}


// Method to add staff member
void AddStaff()
{
    // User enters the staff member details
    Console.Write("Enter staff name: ");
    string name = Console.ReadLine();
    Staff staff = new Staff(nextStaffId++, name);
    staffMembers.Add(staff);
    Console.WriteLine($"Staff member added successfully. \nStaff ID is: {staff.Id}");
}

// Method to update viewing status
void UpdateViewingStatus()
{
    // User enters the viewing ID to update
    Console.Write("Enter viewing ID: ");
    int viewingId = Convert.ToInt32(Console.ReadLine());
    Viewing viewing = viewings.FirstOrDefault(v => v.Id == viewingId);
    if (viewing == null)
    {
        // If the viewing isn't found, display message
        Console.WriteLine("Viewing not found.");
        return;
    }

    // User enters the new status for the viewing
    Console.Write("Enter new status: ");
    string status = Console.ReadLine();
    viewing.Status = status;

    // If the status is 'Missed', increment the customer's MissedViewings count
    if (status.Equals("Missed", StringComparison.OrdinalIgnoreCase))
    {
        viewing.Customer.MissedViewings += 1;
        Console.WriteLine("Customer's missed viewings count has been updated.");
    }

    Console.WriteLine($"Viewing status updated successfully. \nNew status is: {viewing.Status}");
}

// Method to filter customers by name
void FilterCustomerByName()
{
    // User enters the name to search for
    Console.Write("Enter customer name: ");
    string name = Console.ReadLine();
    List<Customer> foundCustomers = customers.Where(c => c.FullName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
    if (foundCustomers.Count == 0)
    {

        // If no customers are found, display message
        Console.WriteLine("No customers found with that name.");
        return;
    }
    foreach (var customer in foundCustomers)
    {
        // Outputs the customers details
        Console.WriteLine($"Customer ID: {customer.Id}, Name: {customer.FullName}, Email: {customer.Email}, Banned: {customer.IsBanned}");
    }

}

// Method to filter properties by name
void FilterPropertyByName()
{
    // User enters the address to search for
    Console.Write("Enter property address: ");
    string address = Console.ReadLine();
    List<Property> foundProperties = properties.Where(p => p.Address.Contains(address, StringComparison.OrdinalIgnoreCase)).ToList();
    if (foundProperties.Count == 0)
    {
        // If no properties are found, display message
        Console.WriteLine("No properties found with that address.");
        return;
    }
    foreach (var property in foundProperties)
    {
        // Outputs the properties details
        Console.WriteLine($"Property ID: {property.Id}, Address: {property.Address}, Type: {property.Type}");
    }
}