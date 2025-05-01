// See https://aka.ms/new-console-template for more information

//
using HappyHomesProgram;

List<Property> properties = new List<Property>();
List<Customer> customers = new List<Customer>();
List<Staff> staffMembers = new List<Staff>();
List<Viewing> viewings = new List<Viewing>();
int nextPropertyId = 1;
int nextCustomerId = 1;
int nextStaffId = 1;
int nextViewingId = 1;


Console.WriteLine("Welcome to HappyHomes Property Viewing System");
Console.WriteLine("Please select an option:");
Console.WriteLine("1. Add a Customer");
Console.WriteLine("2. Add a Property");
Console.WriteLine("3. Add a Staff Member");
Console.WriteLine("4. Book a Viewing");
Console.WriteLine("5. Update Viewing Status");
Console.WriteLine("6. Find Customer by Name");
Console.WriteLine("7. Find Property by Address");
Console.WriteLine("8. Exit");
Console.WriteLine("Enter your choice: ");

int choice = Convert.ToInt32(Console.ReadLine());

switch (choice)
{
    case 1:
        // Call add customer method
        AddCustomer();
        break;

    case 2:
        // Call add property method
        AddProperty();
        break;

    case 3:
        // Call add staff method
        break;

    case 4:
        // Call method to book a viewing
        AddBooking();
        break;
    
    case 5:
        // Call update viewing status method
        break;
    
    case 6:
        // Call find customer method
        break;
    
    case 7:
        // Call find property method
        break;
    
    case 8:
        // Exit program
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

// Method to store customer details
void AddCustomer()
{
    // User enters the cuatomer details
    Console.Write("Enter customer name: ");
    string name = Console.ReadLine();
    Console.Write("Enter customer email: ");
    string email = Console.ReadLine();
    Console.Write("Enter customer current address: ");
    string currentAddress = Console.ReadLine();
    Console.Write("Enter customer telephone: ");
    string telephone = Console.ReadLine();

    Customer customer = new Customer(nextCustomerId++, name, email, currentAddress, telephone);
    customers.Add(customer);
    Console.WriteLine($"Customer details added successfully. \nCustomer ID is: {customer.Id}");
}

// Method to book a viewing
void AddBooking()
{
    // User enters the customer ID for the booking
    Console.Write("Enter customer ID: ");
    int customerId = Convert.ToInt32(Console.ReadLine());
    Customer customer = customers.FirstOrDefault(c => c.Id == customerId);
    if (customer == null)
    {
        // If customer not found, display message
        Console.WriteLine("Customer not found.");
        return;
    }

    // User enters the property ID for the booking
    Console.Write("Enter property ID: ");
    int propertyId = Convert.ToInt32(Console.ReadLine());
    Property property = properties.FirstOrDefault(p => p.Id == propertyId);
    if (property == null)
    {
        Console.WriteLine("Property not found.");
        return;
    }
    // User enters the staff ID for the booking
    Console.Write("Enter staff ID: ");
    int staffId = Convert.ToInt32(Console.ReadLine());
    Staff staff = staffMembers.FirstOrDefault(s => s.Id == staffId);
    if (staff == null)
    {
        // If the staff member isn't found, display message
        Console.WriteLine("Staff member not found.");
        return;
    }
    // User inputs the date and time for the booking
    Console.Write("Enter date and time for viewing (yyyy-mm-dd hh:mm): ");
    DateTime dateTime = DateTime.Parse(Console.ReadLine());
    Viewing viewing = new Viewing(nextViewingId++, customer, property, staff, dateTime);
    viewings.Add(viewing);
    Console.WriteLine($"Viewing booked successfully. \nViewing ID is: {viewing.Id}");
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