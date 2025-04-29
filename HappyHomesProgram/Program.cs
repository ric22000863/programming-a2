// See https://aka.ms/new-console-template for more information

//
Console.WriteLine("Welcome to HappyHomes Property Viewing System!");
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
        break;

    case 2:
        // Call add property method
        break;

    case 3:
        // Call add staff method
        break;

    case 4:
        // Call add booking method
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