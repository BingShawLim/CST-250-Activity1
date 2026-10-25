/*
 * Bing Shaw Lim
 * CST-250
 * 10/25/2026
 * Vehicle Store Console App
 * Activity 1
 * Resources: CST-250 Activity 1 Guide (Grand Canyon University, 2025);
 *   Microsoft Learn - int.TryParse / decimal.TryParse (Console Challenge 2)
 */

using VehicleClassLibrary.Models;
using VehicleClassLibrary.Services.BusinessLogicLayer;

//----------------------------------------------------------
// Start of the Main Method
//----------------------------------------------------------

// Print a welcome message to the user
Console.WriteLine("Welcome to the Vehicle Shop! To begin, please create a selection of vehicles and add them " +
    "to the inventory. Once the inventory is populated, you can proceed by adding vehicles to your cart. " +
    "Finally, when you're ready to complete your purchase, proceed to the checkout where your total bill " +
    "will be calculated.");

// Call the control loop method to manage the program running
ControlLoop();

//----------------------------------------------------------
// End of the Main Method
//----------------------------------------------------------

// Read an integer menu choice from the user
static int ReadChoice()
{
    // Declare and initialize
    // Set input as a nullable reference type
    string? input = "";
    int choice = -1;

    // Loop until the user enters a valid choice
    while (choice == -1)
    {
        // Print the users options
        Console.Write("Choose an action: \n0) Quit \n1) Print the inventory \n2) Print the shopping cart " +
            "\n3) Create a vehicle \n4) Add a vehicle to the shopping cart \n5) Checkout " +
            "\n6) Save inventory to a text file \n7) Load inventory from a text file \nInput: ");

        // Read the user input from the console
        input = Console.ReadLine();
        // Make sure the user entered a value
        if (!string.IsNullOrEmpty(input))
        {
            try
            {
                // Parse the input from the user to the choice variable
                choice = int.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Please enter a valid number. The number entered was either too small or too large.");
            }
            catch (Exception exp)
            {
                Console.WriteLine("There was an exception " + exp + ". Please try again.");
            }
        }
    }
    // Return the users input
    return choice;
}

// Console Challenge 2: keep asking until the user types a whole number in range
static int ReadInteger(string prompt, int min, int max)
{
    // Declare and initialize
    int result;
    // Loop until TryParse succeeds and the value is in range
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        if (int.TryParse(input, out result) && result >= min && result <= max)
        {
            return result;
        }
        Console.WriteLine($"Invalid entry. Please enter a whole number from {min} to {max}.");
    }
}

// Console Challenge 2: keep asking until the user types a valid non-negative decimal
static decimal ReadDecimal(string prompt)
{
    // Declare and initialize
    decimal result;
    // Loop until TryParse succeeds and the value is not negative
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        if (decimal.TryParse(input, out result) && result >= 0)
        {
            return result;
        }
        Console.WriteLine("Invalid entry. Please enter a positive number (for example 2.5).");
    }
}

// Console Challenge 2: keep asking until the user types true or false
static bool ReadBoolean(string prompt)
{
    // Declare and initialize
    bool result;
    // Loop until TryParse succeeds
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        if (bool.TryParse(input, out result))
        {
            return result;
        }
        Console.WriteLine("Invalid entry. Please type true or false.");
    }
}

// Console Challenge 2: keep asking until the user types some text
static string ReadText(string prompt)
{
    // Loop until the user enters something other than blank space
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            return input.Trim();
        }
        Console.WriteLine("Invalid entry. This field cannot be blank.");
    }
}

// Control the car store loop
static void ControlLoop()
{
    // Create an instance of the store logic class
    StoreLogic storeLogic = new StoreLogic();
    // Declare and initialize other variables
    int choice = -1, id = 0, year = 0, numWheels = 0, miles = 0, cartCount = 0;
    string make = "", model = "", color = "";
    decimal price = 0m, total = 0m;
    // Specialty vehicle variables
    bool isConvertible = false, hasSideCar = false, hasBedCover = false;
    decimal trunkSize = 0m, seatHeight = 0m, bedSize = 0m;
    List<VehicleModel> vehicleList = new List<VehicleModel>();
    VehicleModel vehicle = new VehicleModel();

    // Continue the loop until the user enters 0
    while (choice != 0)
    {
        // Get the input from the user
        choice = ReadChoice();

        // Use the users choice to switch between the options
        switch (choice)
        {
            // Quit
            case 0:
                Console.WriteLine("Have a great day");
                break;

            // Print the inventory
            case 1:
                // Get the inventory list from storeLogic
                vehicleList = storeLogic.GetInventory();
                // Print a title for the list
                Console.WriteLine("Inventory: ");
                // Let the user know when the inventory is empty
                if (vehicleList.Count == 0)
                {
                    Console.WriteLine("The inventory is empty.");
                }
                // Loop through the inventory list
                foreach (VehicleModel inventoryVehicle in vehicleList)
                {
                    // Print each vehicle from the inventory (each subtype uses its own ToString)
                    Console.WriteLine(inventoryVehicle);
                }
                Console.WriteLine();
                break;

            // Print the shopping cart
            case 2:
                // Get the shopping cart list from storeLogic
                vehicleList = storeLogic.GetShoppingCart();
                // Print a title for the list
                Console.WriteLine("Shopping Cart: ");
                // Let the user know when the cart is empty
                if (vehicleList.Count == 0)
                {
                    Console.WriteLine("The shopping cart is empty.");
                }
                // Loop through the shopping cart list
                foreach (VehicleModel shoppingCartVehicle in vehicleList)
                {
                    // Print each vehicle from the shopping cart
                    Console.WriteLine(shoppingCartVehicle);
                }
                Console.WriteLine();
                break;

            // Create a vehicle
            case 3:
                // Read the type of vehicle (Challenge 2: validated 1-4)
                choice = ReadInteger("Enter 1 to create a car, 2 to create a motorcycle, 3 to create a pickup, " +
                    "or 4 to create a vehicle: ", 1, 4);

                // Get the common properties for the vehicle
                make = ReadText("Enter the make of the vehicle: ");
                model = ReadText("Enter the model of the vehicle: ");
                year = ReadInteger("Enter the year of the vehicle: ", 1886, DateTime.Now.Year + 1);
                price = ReadDecimal("Enter the price of the vehicle: ");
                numWheels = ReadInteger("Enter the number of wheels on the vehicle: ", 1, 18);
                // Challenge 1: the two new properties
                color = ReadText("Enter the color of the vehicle: ");
                miles = ReadInteger("Enter the miles on the vehicle: ", 0, 2000000);

                // Switch statement to read the vehicle-specific properties
                switch (choice)
                {
                    // Car
                    case 1:
                        isConvertible = ReadBoolean("Enter if the car is a convertible (true/false): ");
                        trunkSize = ReadDecimal("Enter the trunk size of the car in cubic feet: ");
                        // Create a new car
                        vehicle = new CarModel(id, make, model, year, price, numWheels, color, miles,
                            isConvertible, trunkSize);
                        break;

                    // Motorcycle
                    case 2:
                        hasSideCar = ReadBoolean("Enter if the motorcycle has a side car (true/false): ");
                        seatHeight = ReadDecimal("Enter the seat height of the motorcycle in inches: ");
                        // Create a new motorcycle
                        vehicle = new MotorcycleModel(id, make, model, year, price, numWheels, color, miles,
                            hasSideCar, seatHeight);
                        break;

                    // Pickup
                    case 3:
                        hasBedCover = ReadBoolean("Enter if the pickup has a bed cover (true/false): ");
                        bedSize = ReadDecimal("Enter the bed size of the pickup in cubic feet: ");
                        // Create a new pickup
                        vehicle = new PickupModel(id, make, model, year, price, numWheels, color, miles,
                            hasBedCover, bedSize);
                        break;

                    // Vehicle
                    default:
                        // Create a new vehicle
                        vehicle = new VehicleModel(id, make, model, year, price, numWheels, color, miles);
                        break;
                }

                // Add the vehicle to the inventory
                id = storeLogic.AddVehicleToInventory(vehicle);
                Console.WriteLine($"Vehicle {id} was added to the inventory.");
                Console.WriteLine();
                // Reset choice so the outer loop does not treat the vehicle type as a menu option
                choice = -1;
                break;

            // Add a vehicle to the shopping cart
            case 4:
                // Challenge 2: stop early when there is nothing to buy
                if (storeLogic.GetInventory().Count == 0)
                {
                    Console.WriteLine("The inventory is empty. Create a vehicle first.");
                    Console.WriteLine();
                    break;
                }
                // Get the id of the vehicle from the user (validated whole number)
                id = ReadInteger("Enter the id of the vehicle you want to buy: ", int.MinValue, int.MaxValue);
                // Challenge 2: make sure the id is in the inventory before adding it
                if (storeLogic.VehicleExists(id))
                {
                    // Add the vehicle to the shopping cart
                    cartCount = storeLogic.AddVehicleToCart(id);
                    Console.WriteLine($"Vehicle {id} was added. Your cart has {cartCount} item(s).");
                }
                else
                {
                    Console.WriteLine($"There is no vehicle with id {id} in the inventory.");
                }
                Console.WriteLine();
                break;

            // Checkout
            case 5:
                // Checkout the user
                total = storeLogic.Checkout();
                // Print the total from the checkout method
                Console.WriteLine($"Your total is: {total:C2}");
                Console.WriteLine();
                break;

            // Save inventory to a text file
            case 6:
                // Use the business logic layer to write the inventory to the file
                if (storeLogic.WriteInventory())
                {
                    // Print out a success message
                    Console.WriteLine("The inventory has been saved to the text file");
                }
                else
                {
                    Console.WriteLine("The inventory could not be saved to the text file");
                }
                Console.WriteLine();
                break;

            // Load inventory from a text file
            case 7:
                // Use the business logic layer to read the inventory from the file
                storeLogic.ReadInventory();
                // Print out a success message
                Console.WriteLine("The inventory has been read from the text file");
                Console.WriteLine();
                break;

            // Other input
            default:
                Console.WriteLine("Invalid Choice");
                Console.WriteLine();
                break;
        }
    }
} // End of ControlLoop method
