/*
 * Bing [Last Name]
 * CST-250
 * 10/25/2026
 * Vehicle Class Library
 * Activity 1
 * Resources: CST-250 Activity 1 Guide (Grand Canyon University, 2025)
 */

using VehicleClassLibrary.Models;

namespace VehicleClassLibrary.Services.DataAccessLayer
{
    /// <summary>
    /// Data access object for the vehicle store. Owns the inventory and shopping cart
    /// lists and is the only class that reads from or writes to the inventory text file.
    /// </summary>
    public class StoreDAO
    {
        // VehicleModel list for the store's inventory (holds any vehicle subtype - polymorphism)
        private List<VehicleModel> _inventory;
        // VehicleModel list for the user's shopping cart
        private List<VehicleModel> _shoppingCart;
        // The directory for the inventory text file
        private string _fileDirectory = "Data";
        // The name of the inventory text file
        private string _textFile = "inventory.txt";
        // The full path to the text file
        private string _filePath;

        /// <summary>
        /// Default constructor for StoreDAO
        /// </summary>
        public StoreDAO()
        {
            // Initialize the vehicle model lists
            _inventory = new List<VehicleModel>();
            _shoppingCart = new List<VehicleModel>();
            // Set up the full path to the inventory text file
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _fileDirectory, _textFile);
        }

        /// <summary>
        /// Get a list of vehicles in the inventory
        /// </summary>
        /// <returns>The inventory list</returns>
        public List<VehicleModel> GetInventory()
        {
            // Return the inventory list
            return _inventory;
        }

        /// <summary>
        /// Get a list of the vehicles in the user's shopping cart
        /// </summary>
        /// <returns>The shopping cart list</returns>
        public List<VehicleModel> GetShoppingCart()
        {
            // Return the shoppingCart list
            return _shoppingCart;
        }

        /// <summary>
        /// Add a new vehicle to the inventory
        /// </summary>
        /// <param name="vehicle">The vehicle to add</param>
        /// <returns>The id assigned to the new vehicle</returns>
        public int AddVehicleToInventory(VehicleModel vehicle)
        {
            // Set the id for the new vehicle
            vehicle.Id = _inventory.Count + 1;
            // Add the vehicle to the inventory list
            _inventory.Add(vehicle);
            // Return the id of the new vehicle
            return vehicle.Id;
        }

        /// <summary>
        /// Add a vehicle to the shopping cart based on the vehicle's id
        /// </summary>
        /// <param name="vehicleId">Id of the vehicle to add</param>
        /// <returns>The number of items in the shopping cart</returns>
        public int AddVehicleToCart(int vehicleId)
        {
            // Loop through the inventory to find the correct vehicle
            for (int i = 0; i < _inventory.Count; i++)
            {
                // Check if the inventory vehicle id matches the parameter
                if (_inventory[i].Id == vehicleId)
                {
                    // If so, add the vehicle to the shopping cart
                    _shoppingCart.Add(_inventory[i]);
                }
            }
            // Return the number of items in the shoppingCart
            return _shoppingCart.Count;
        }

        /// <summary>
        /// Remove a vehicle from the shopping cart (GUI Challenge 3)
        /// </summary>
        /// <param name="cartIndex">Position of the vehicle in the shopping cart</param>
        /// <returns>The number of items left in the shopping cart</returns>
        public int RemoveVehicleFromCart(int cartIndex)
        {
            // Only remove when the index points at a real cart item
            if (cartIndex >= 0 && cartIndex < _shoppingCart.Count)
            {
                _shoppingCart.RemoveAt(cartIndex);
            }
            // Return the number of items in the shoppingCart
            return _shoppingCart.Count;
        }

        /// <summary>
        /// Write the inventory to a text file
        /// </summary>
        /// <returns>True if the inventory was saved, false if an error occurred</returns>
        public bool WriteInventory()
        {
            // Get the folder that holds the text file
            string directory = Path.GetDirectoryName(_filePath) ?? _fileDirectory;
            // Check if the directory exists
            if (!Directory.Exists(directory))
            {
                // If the directory does not exist, create it
                Directory.CreateDirectory(directory);
            }

            // Catch any exceptions with the stream writer
            try
            {
                // Create the stream writer to write to the file
                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    // Loop through the inventory list
                    foreach (VehicleModel vehicle in _inventory)
                    {
                        Type vehicleType = vehicle.GetType();
                        switch (vehicleType.Name)
                        {
                            case "CarModel":
                                // Cast the vehicle to a car
                                CarModel car = (CarModel)vehicle;
                                // Write the car to the file
                                writer.WriteLine($"Car, {car.Make}, {car.Model}, {car.Year}, {car.Price}, " +
                                    $"{car.NumWheels}, {car.Color}, {car.Miles}, {car.IsConvertible}, {car.TrunkSize}");
                                break;

                            case "MotorcycleModel":
                                // Cast the vehicle to a motorcycle
                                MotorcycleModel motorcycle = (MotorcycleModel)vehicle;
                                // Write the motorcycle to the file
                                writer.WriteLine($"Motorcycle, {motorcycle.Make}, {motorcycle.Model}, " +
                                    $"{motorcycle.Year}, {motorcycle.Price}, {motorcycle.NumWheels}, " +
                                    $"{motorcycle.Color}, {motorcycle.Miles}, {motorcycle.HasSideCar}, " +
                                    $"{motorcycle.SeatHeight}");
                                break;

                            case "PickupModel":
                                // Cast the vehicle to a pickup
                                PickupModel pickup = (PickupModel)vehicle;
                                // Write the pickup to the file
                                writer.WriteLine($"Pickup, {pickup.Make}, {pickup.Model}, {pickup.Year}, " +
                                    $"{pickup.Price}, {pickup.NumWheels}, {pickup.Color}, {pickup.Miles}, " +
                                    $"{pickup.HasBedCover}, {pickup.BedSize}");
                                break;

                            default:
                                // Write the vehicle to the file
                                writer.WriteLine($"Vehicle, {vehicle.Make}, {vehicle.Model}, {vehicle.Year}, " +
                                    $"{vehicle.Price}, {vehicle.NumWheels}, {vehicle.Color}, {vehicle.Miles}");
                                break;
                        }
                    }
                }
                // Return true if all the data was saved to the file
                return true;
            }
            catch (Exception)
            {
                // Return false if an exception was thrown
                return false;
            }
        } // End of WriteInventory method

        /// <summary>
        /// Read the list of vehicles from a text file
        /// </summary>
        /// <returns>The inventory list after the file has been read</returns>
        public List<VehicleModel> ReadInventory()
        {
            // Declare and initialize
            string? line = "";
            string[] parts = [];
            string make = "", model = "", color = "";
            int year = 0, numWheels = 0, miles = 0;
            decimal price = 0m;
            // Specialty vehicle variables
            bool isConvertible = false, hasSideCar = false, hasBedCover = false;
            decimal trunkSize = 0m, seatHeight = 0m, bedSize = 0m;

            // Catch any exceptions with the stream reader
            try
            {
                // Check if the file exists
                if (File.Exists(_filePath))
                {
                    // Create a StreamReader to read the file
                    using (StreamReader reader = new StreamReader(_filePath))
                    {
                        // Read each line in the file
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Split the line on a comma-space
                            // Create a string array to put all the separate vehicle parts into
                            parts = line.Split(", ");

                            // Skip lines that do not hold the 8 common fields
                            if (parts.Length < 8)
                            {
                                continue;
                            }

                            // Use the parts array to get the common data
                            make = parts[1];
                            model = parts[2];
                            // Parse the year of the vehicle
                            year = ParseInteger(parts[3]);
                            // Parse the price of the vehicle
                            price = ParseDecimal(parts[4]);
                            // Parse the number of wheels of the vehicle
                            numWheels = ParseInteger(parts[5]);
                            // Read the color and parse the miles (challenge properties)
                            color = parts[6];
                            miles = ParseInteger(parts[7]);

                            // Use the first piece of data to create a switch for the specific model
                            switch (parts[0])
                            {
                                case "Car":
                                    // Parse the convertible status for the car
                                    isConvertible = ParseBoolean(parts[8]);
                                    // Parse the trunk size for the car
                                    trunkSize = ParseDecimal(parts[9]);
                                    // Create a new car using the read properties
                                    CarModel car = new CarModel(0, make, model, year, price, numWheels,
                                        color, miles, isConvertible, trunkSize);
                                    // Add the car to the inventory
                                    AddVehicleToInventory(car);
                                    break;

                                case "Motorcycle":
                                    // Parse the side car status for the motorcycle
                                    hasSideCar = ParseBoolean(parts[8]);
                                    // Parse the seat height for the motorcycle
                                    seatHeight = ParseDecimal(parts[9]);
                                    // Create a new motorcycle using the read properties
                                    MotorcycleModel motorcycle = new MotorcycleModel(0, make, model, year,
                                        price, numWheels, color, miles, hasSideCar, seatHeight);
                                    // Add the motorcycle to the inventory
                                    AddVehicleToInventory(motorcycle);
                                    break;

                                case "Pickup":
                                    // Parse the bed cover status for the pickup
                                    hasBedCover = ParseBoolean(parts[8]);
                                    // Parse the bed size for the pickup
                                    bedSize = ParseDecimal(parts[9]);
                                    // Create a new pickup using the read properties
                                    PickupModel pickup = new PickupModel(0, make, model, year, price,
                                        numWheels, color, miles, hasBedCover, bedSize);
                                    // Add the pickup to the inventory
                                    AddVehicleToInventory(pickup);
                                    break;

                                default:
                                    // Create a new vehicle using the read properties
                                    VehicleModel vehicle = new VehicleModel(0, make, model, year, price,
                                        numWheels, color, miles);
                                    // Add the vehicle to the inventory
                                    AddVehicleToInventory(vehicle);
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Return the inventory list as is
                return _inventory;
            }
            // Return the inventory list
            return _inventory;
        } // End of ReadInventory method

        /// <summary>
        /// Method to safely parse an integer
        /// </summary>
        /// <param name="input">Text to parse</param>
        /// <returns>The parsed integer, or 0 if parsing fails</returns>
        private int ParseInteger(string input)
        {
            try
            {
                // Parse the input and return
                return int.Parse(input);
            }
            catch (Exception)
            {
                // Return 0
                return 0;
            }
        }

        /// <summary>
        /// Method to safely parse a decimal
        /// </summary>
        /// <param name="input">Text to parse</param>
        /// <returns>The parsed decimal, or 0 if parsing fails</returns>
        private decimal ParseDecimal(string input)
        {
            try
            {
                // Parse the input and return
                return decimal.Parse(input);
            }
            catch (Exception)
            {
                // Return 0
                return 0m;
            }
        }

        /// <summary>
        /// Method to safely parse a boolean
        /// </summary>
        /// <param name="input">Text to parse</param>
        /// <returns>The parsed boolean, or false if parsing fails</returns>
        private bool ParseBoolean(string input)
        {
            try
            {
                // Parse the input and return
                return bool.Parse(input);
            }
            catch (Exception)
            {
                // Return false
                return false;
            }
        }

        /// <summary>
        /// Calculate the total cost of the shopping cart and empty the cart
        /// </summary>
        /// <returns>The total cost of the vehicles that were in the cart</returns>
        public decimal Checkout()
        {
            // Declare and initialize the total
            decimal total = 0m;
            // Loop through the shopping cart and add up each price
            foreach (VehicleModel vehicle in _shoppingCart)
            {
                total += vehicle.Price;
            }
            // Clear the shopping cart
            _shoppingCart.Clear();
            // Return the total cost
            return total;
        }
    }
}
