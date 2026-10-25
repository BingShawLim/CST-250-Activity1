/*
 * Bing Shaw Lim
 * CST-250
 * 10/25/2026
 * Vehicle Class Library
 * Activity 1
 * Resources: CST-250 Activity 1 Guide (Grand Canyon University, 2025);
 *   Microsoft Learn - Comparison<T> Delegate (used for the sort challenge)
 */

using VehicleClassLibrary.Models;
using VehicleClassLibrary.Services.DataAccessLayer;

namespace VehicleClassLibrary.Services.BusinessLogicLayer
{
    /// <summary>
    /// Business logic layer for the vehicle store. Passes data between the presentation
    /// layer (console or GUI) and the data access layer, and holds the store's rules
    /// (searching, sorting, duplicate checks).
    /// </summary>
    public class StoreLogic
    {
        // Data access object used for every data request
        private StoreDAO _storeDAO;

        /// <summary>
        /// Default constructor for StoreLogic
        /// </summary>
        public StoreLogic()
        {
            // Initialize the store data access object
            _storeDAO = new StoreDAO();
        }

        /// <summary>
        /// Get the inventory list from the data access layer
        /// </summary>
        /// <returns>The inventory list</returns>
        public List<VehicleModel> GetInventory()
        {
            return _storeDAO.GetInventory();
        }

        /// <summary>
        /// Get the shopping cart list from the data access layer
        /// </summary>
        /// <returns>The shopping cart list</returns>
        public List<VehicleModel> GetShoppingCart()
        {
            return _storeDAO.GetShoppingCart();
        }

        /// <summary>
        /// Add a vehicle to the inventory
        /// </summary>
        /// <param name="vehicle">The vehicle to add</param>
        /// <returns>The id assigned to the new vehicle</returns>
        public int AddVehicleToInventory(VehicleModel vehicle)
        {
            return _storeDAO.AddVehicleToInventory(vehicle);
        }

        /// <summary>
        /// Add a vehicle to the shopping cart by id
        /// </summary>
        /// <param name="vehicleId">Id of the vehicle to add</param>
        /// <returns>The number of items in the shopping cart</returns>
        public int AddVehicleToCart(int vehicleId)
        {
            return _storeDAO.AddVehicleToCart(vehicleId);
        }

        /// <summary>
        /// Remove a vehicle from the shopping cart (GUI Challenge 3)
        /// </summary>
        /// <param name="cartIndex">Position of the vehicle in the cart</param>
        /// <returns>The number of items left in the shopping cart</returns>
        public int RemoveVehicleFromCart(int cartIndex)
        {
            return _storeDAO.RemoveVehicleFromCart(cartIndex);
        }

        /// <summary>
        /// Write the inventory to the text file
        /// </summary>
        /// <returns>True if the inventory was saved</returns>
        public bool WriteInventory()
        {
            return _storeDAO.WriteInventory();
        }

        /// <summary>
        /// Read the inventory from the text file
        /// </summary>
        /// <returns>The inventory list after reading the file</returns>
        public List<VehicleModel> ReadInventory()
        {
            return _storeDAO.ReadInventory();
        }

        /// <summary>
        /// Check out the shopping cart
        /// </summary>
        /// <returns>The total cost of the cart</returns>
        public decimal Checkout()
        {
            return _storeDAO.Checkout();
        }

        /// <summary>
        /// Check whether a vehicle id exists in the inventory (Console Challenge 2)
        /// </summary>
        /// <param name="vehicleId">Id to look for</param>
        /// <returns>True when a vehicle with that id is in the inventory</returns>
        public bool VehicleExists(int vehicleId)
        {
            // Loop through the inventory looking for a matching id
            foreach (VehicleModel vehicle in _storeDAO.GetInventory())
            {
                if (vehicle.Id == vehicleId)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check whether an identical vehicle is already in the inventory (GUI Challenge 6)
        /// </summary>
        /// <param name="vehicle">The vehicle about to be added</param>
        /// <returns>True when a vehicle with identical properties already exists</returns>
        public bool IsDuplicate(VehicleModel vehicle)
        {
            // Contains uses the overridden Equals method in the model classes
            return _storeDAO.GetInventory().Contains(vehicle);
        }

        /// <summary>
        /// Search the inventory by make, model, or year (GUI Challenge 2)
        /// </summary>
        /// <param name="searchTerm">Text to look for</param>
        /// <returns>A new list with the matching vehicles</returns>
        public List<VehicleModel> SearchInventory(string searchTerm)
        {
            // An empty search returns the whole inventory
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return new List<VehicleModel>(_storeDAO.GetInventory());
            }

            // Declare and initialize the results list
            List<VehicleModel> results = new List<VehicleModel>();
            string term = searchTerm.Trim();

            // Keep any vehicle whose make, model, or year contains the term
            foreach (VehicleModel vehicle in _storeDAO.GetInventory())
            {
                if (vehicle.Make.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    vehicle.Model.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    vehicle.Year.ToString().Contains(term))
                {
                    results.Add(vehicle);
                }
            }
            return results;
        }

        /// <summary>
        /// Sort the inventory in place (GUI Challenge 4)
        /// </summary>
        /// <param name="sortBy">"Price", "Year", or "Make/Model"</param>
        public void SortInventory(string sortBy)
        {
            // Pick the Comparison delegate that matches the requested sort
            Comparison<VehicleModel> comparison = sortBy switch
            {
                "Price" => (first, second) => first.Price.CompareTo(second.Price),
                "Year" => (first, second) => first.Year.CompareTo(second.Year),
                _ => (first, second) =>
                {
                    // Sort by make, then by model when the makes match
                    int result = string.Compare(first.Make, second.Make, StringComparison.OrdinalIgnoreCase);
                    return result != 0
                        ? result
                        : string.Compare(first.Model, second.Model, StringComparison.OrdinalIgnoreCase);
                }
            };
            // Sort the list the DAO owns so every bound control sees the new order
            _storeDAO.GetInventory().Sort(comparison);
        }
    }
}
