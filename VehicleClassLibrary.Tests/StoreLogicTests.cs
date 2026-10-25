/*
 * Bing [Last Name]
 * CST-250
 * 10/25/2026
 * Vehicle Class Library Tests
 * Activity 1
 * Resources: CST-250 Activity 1 Guide (Grand Canyon University, 2025)
 */

using VehicleClassLibrary.Models;
using VehicleClassLibrary.Services.BusinessLogicLayer;

namespace VehicleClassLibrary.Tests
{
    /// <summary>
    /// xUnit tests for the StoreLogic business logic layer (Red - Green - Refactor)
    /// </summary>
    public class StoreLogicTests
    {
        // Mark this method as a unit test using the [Fact] attribute from xUnit
        [Fact]
        public void AddVehicleToInventory_ShouldIncreaseInventoryCount()
        {
            // Arrange: Create an instance of StoreLogic (System Under Test - SUT)
            StoreLogic store = new StoreLogic();

            // Create a new CarModel object to add to inventory
            CarModel car = new CarModel
            {
                Id = 1,
                Make = "Toyota",
                Model = "Camry",
                Year = 2020,
                Price = 25000m,
                NumWheels = 4,
                IsConvertible = true,
                TrunkSize = 2.5m
            };

            // Act: Add the vehicle to the inventory
            store.AddVehicleToInventory(car);

            // Retrieve the current inventory
            List<VehicleModel> inventory = store.GetInventory();

            // Assert: Verify that the vehicle was added to inventory
            Assert.Contains(car, inventory);
        }

        // Test for GetInventory when no vehicles have been added
        [Fact]
        public void GetInventory_ShouldReturnEmptyList_WhenNoVehiclesAdded()
        {
            // Arrange: Create an instance of StoreLogic
            StoreLogic store = new StoreLogic();

            // Act: Retrieve the inventory without adding any vehicles
            List<VehicleModel> inventory = store.GetInventory();

            // Assert: The inventory should be empty
            Assert.Empty(inventory);
        }

        // Test adding a vehicle to the shopping cart
        [Fact]
        public void AddVehicleToCart_ShouldAddVehicle_WhenValidVehicleIdGiven()
        {
            // Arrange: Create an instance of StoreLogic
            StoreLogic store = new StoreLogic();

            // Create and add a vehicle to the inventory
            CarModel car = new CarModel
            {
                Id = 1,
                Make = "Honda",
                Model = "Civic",
                Year = 2019,
                Price = 20000m,
                NumWheels = 4,
                IsConvertible = true,
                TrunkSize = 2.5m
            };

            store.AddVehicleToInventory(car);

            // Act: Add the vehicle to the shopping cart using its VehicleId
            int result = store.AddVehicleToCart(car.Id);

            // Retrieve the shopping cart contents
            List<VehicleModel> cart = store.GetShoppingCart();

            // Assert: Verify that AddVehicleToCart returned success (assumed to be 1)
            Assert.Equal(1, result);

            // Assert: Verify that the cart contains the correct vehicle
            Assert.Contains(cart, verify => verify.Id == car.Id);
        }

        // Test that GetShoppingCart returns an empty list when no vehicles are added
        [Fact]
        public void GetShoppingCart_ShouldReturnEmptyList_WhenNoVehiclesAdded()
        {
            // Arrange: Create an instance of StoreLogic
            StoreLogic store = new StoreLogic();

            // Act: Retrieve the shopping cart without adding any vehicles
            List<VehicleModel> cart = store.GetShoppingCart();

            // Assert: The shopping cart should be empty
            Assert.Empty(cart);
        }

        // Test that Checkout returns the correct total and clears the shopping cart
        [Fact]
        public void Checkout_ShouldReturnCorrectTotal_AndClearCart()
        {
            // Arrange: Create an instance of StoreLogic
            StoreLogic store = new StoreLogic();

            // Create two vehicles to add to inventory and cart
            CarModel car1 = new CarModel
            {
                Id = 3,
                Make = "Ford",
                Model = "F-150",
                Year = 2021,
                Price = 40000m,
                NumWheels = 4,
                IsConvertible = true,
                TrunkSize = 2.5m
            };

            CarModel car2 = new CarModel
            {
                Id = 4,
                Make = "Chevrolet",
                Model = "Silverado",
                Year = 2022,
                Price = 45000m,
                NumWheels = 4,
                IsConvertible = true,
                TrunkSize = 2.5m
            };

            // Add both vehicles to inventory
            store.AddVehicleToInventory(car1);
            store.AddVehicleToInventory(car2);

            // Add both vehicles to the shopping cart
            store.AddVehicleToCart(car1.Id);
            store.AddVehicleToCart(car2.Id);

            // Act: Perform the checkout operation
            decimal total = store.Checkout();

            // Retrieve the shopping cart contents after checkout
            List<VehicleModel> cartAfterCheckout = store.GetShoppingCart();

            // Assert: Verify that the total is approximately correct
            // (Allowing small variance for business logic such as discounts, taxes, etc.)
            Assert.True(total >= (car1.Price + car2.Price) * 0.95m);
            Assert.True(total <= (car1.Price + car2.Price) * 1.05m);

            // Assert: Verify that the shopping cart is now empty after checkout
            Assert.Empty(cartAfterCheckout);
        }

        //----------------------------------------------------------------
        // Challenge tests
        //----------------------------------------------------------------

        // Test that adding an id that is not in the inventory leaves the cart unchanged
        [Fact]
        public void AddVehicleToCart_ShouldNotAddVehicle_WhenIdNotInInventory()
        {
            // Arrange
            StoreLogic store = new StoreLogic();
            store.AddVehicleToInventory(new VehicleModel(0, "Ford", "Fiesta", 2013, 800m, 4, "Red", 52000));

            // Act: Try to add vehicle 99 (does not exist)
            int result = store.AddVehicleToCart(99);

            // Assert: Nothing was added and VehicleExists reports false
            Assert.Equal(0, result);
            Assert.False(store.VehicleExists(99));
            Assert.True(store.VehicleExists(1));
        }

        // Test that the new Color and Miles properties are stored by the constructor
        [Fact]
        public void VehicleModel_ShouldStoreColorAndMiles_WhenConstructed()
        {
            // Arrange and Act
            PickupModel pickup = new PickupModel(0, "Toyota", "Tundra", 2001, 5000m, 4, "White", 120000, true, 8.3m);

            // Assert
            Assert.Equal("White", pickup.Color);
            Assert.Equal(120000, pickup.Miles);
        }

        // Test that RemoveVehicleFromCart removes the selected vehicle
        [Fact]
        public void RemoveVehicleFromCart_ShouldDecreaseCartCount_WhenValidIndexGiven()
        {
            // Arrange
            StoreLogic store = new StoreLogic();
            store.AddVehicleToInventory(new VehicleModel(0, "Ford", "Fiesta", 2013, 800m, 4, "Red", 52000));
            store.AddVehicleToCart(1);

            // Act
            int result = store.RemoveVehicleFromCart(0);

            // Assert
            Assert.Equal(0, result);
            Assert.Empty(store.GetShoppingCart());
        }

        // Test that SearchInventory matches on make, model, or year
        [Fact]
        public void SearchInventory_ShouldReturnMatchingVehicles_WhenTermMatchesMake()
        {
            // Arrange
            StoreLogic store = new StoreLogic();
            store.AddVehicleToInventory(new VehicleModel(0, "Ford", "Fiesta", 2013, 800m, 4, "Red", 52000));
            store.AddVehicleToInventory(new VehicleModel(0, "Honda", "Civic", 2019, 20000m, 4, "Blue", 30000));

            // Act
            List<VehicleModel> results = store.SearchInventory("ford");

            // Assert
            Assert.Single(results);
            Assert.Equal("Ford", results[0].Make);
        }

        // Test that SortInventory orders the inventory by price
        [Fact]
        public void SortInventory_ShouldOrderByPrice_WhenPriceSelected()
        {
            // Arrange
            StoreLogic store = new StoreLogic();
            store.AddVehicleToInventory(new VehicleModel(0, "Honda", "Civic", 2019, 20000m, 4, "Blue", 30000));
            store.AddVehicleToInventory(new VehicleModel(0, "Ford", "Fiesta", 2013, 800m, 4, "Red", 52000));

            // Act
            store.SortInventory("Price");

            // Assert: The cheapest vehicle is first
            Assert.Equal(800m, store.GetInventory()[0].Price);
        }

        // Test that IsDuplicate finds a vehicle with identical properties
        [Fact]
        public void IsDuplicate_ShouldReturnTrue_WhenIdenticalVehicleExists()
        {
            // Arrange
            StoreLogic store = new StoreLogic();
            store.AddVehicleToInventory(new CarModel(0, "Jeep", "Wrangler", 2019, 27000m, 4, "Black", 30000, true, 14.7m));
            CarModel sameCar = new CarModel(0, "Jeep", "Wrangler", 2019, 27000m, 4, "Black", 30000, true, 14.7m);
            CarModel differentCar = new CarModel(0, "Jeep", "Wrangler", 2019, 27000m, 4, "Black", 30000, false, 14.7m);

            // Act and Assert
            Assert.True(store.IsDuplicate(sameCar));
            Assert.False(store.IsDuplicate(differentCar));
        }

        // Test that the inventory can be written to the text file and read back
        [Fact]
        public void WriteInventory_ThenReadInventory_ShouldRestoreVehicles()
        {
            // Arrange: Save one of each vehicle type
            StoreLogic writer = new StoreLogic();
            writer.AddVehicleToInventory(new CarModel(0, "Jeep", "Wrangler", 2019, 27000m, 4, "Black", 30000, true, 14.7m));
            writer.AddVehicleToInventory(new MotorcycleModel(0, "Yamaha", "Bolt", 2015, 8000m, 2, "Blue", 8000, false, 44.1m));
            writer.AddVehicleToInventory(new PickupModel(0, "Toyota", "Tundra", 2001, 5000m, 4, "White", 120000, true, 8.3m));
            writer.AddVehicleToInventory(new VehicleModel(0, "Ford", "Fiesta", 2013, 800m, 4, "Red", 52000));

            // Act
            bool saved = writer.WriteInventory();
            StoreLogic reader = new StoreLogic();
            List<VehicleModel> inventory = reader.ReadInventory();

            // Assert: Every type is rebuilt (polymorphism) with its data intact
            Assert.True(saved);
            Assert.Equal(4, inventory.Count);
            Assert.IsType<CarModel>(inventory[0]);
            Assert.IsType<MotorcycleModel>(inventory[1]);
            Assert.IsType<PickupModel>(inventory[2]);
            Assert.IsType<VehicleModel>(inventory[3]);
            Assert.Equal(14.7m, ((CarModel)inventory[0]).TrunkSize);
            Assert.Equal("White", inventory[2].Color);
        }
    }
}
