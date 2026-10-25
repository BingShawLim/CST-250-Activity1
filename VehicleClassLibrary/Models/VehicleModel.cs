/*
 * Bing Shaw Lim
 * CST-250
 * 10/25/2026
 * Vehicle Class Library
 * Activity 1
 * Resources: CST-250 Activity 1 Guide (Grand Canyon University, 2025)
 */

namespace VehicleClassLibrary.Models
{
    /// <summary>
    /// Base model for every vehicle in the store. Holds only data (no business logic)
    /// and is inherited by CarModel, MotorcycleModel, and PickupModel.
    /// </summary>
    public class VehicleModel
    {
        // Class level properties
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int NumWheels { get; set; }
        // Challenge properties (Console App Challenge 1)
        public string Color { get; set; }
        public int Miles { get; set; }

        /// <summary>
        /// Default constructor for a vehicle model
        /// </summary>
        public VehicleModel()
        {
            Id = 0;
            Make = "Unknown";
            Model = "Unknown";
            Year = 0;
            Price = 0m;
            NumWheels = 0;
            Color = "Unknown";
            Miles = 0;
        }

        /// <summary>
        /// Parameterized constructor for the vehicle model class
        /// </summary>
        /// <param name="id">Unique id of the vehicle</param>
        /// <param name="make">Manufacturer of the vehicle</param>
        /// <param name="model">Model name of the vehicle</param>
        /// <param name="year">Model year of the vehicle</param>
        /// <param name="price">Price of the vehicle</param>
        /// <param name="numWheels">Number of wheels on the vehicle</param>
        /// <param name="color">Exterior color of the vehicle</param>
        /// <param name="miles">Odometer reading of the vehicle</param>
        public VehicleModel(int id, string make, string model, int year, decimal price, int numWheels,
            string color, int miles)
        {
            Id = id;
            Make = make;
            Model = model;
            Year = year;
            Price = price;
            NumWheels = numWheels;
            Color = color;
            Miles = miles;
        }

        /// <summary>
        /// ToString method for printing a vehicle
        /// </summary>
        /// <returns>A formatted description of the vehicle</returns>
        public override string ToString()
        {
            // Print the vehicle in the following format
            // 1: 2013 Red Ford Fiesta with 4 wheels and 52,000 miles - $800.00
            return $"{Id}: {Year} {Color} {Make} {Model} with {NumWheels} wheels and {Miles:N0} miles - {Price:C2}";
        }

        /// <summary>
        /// Compares two vehicles on every property except the Id
        /// (GUI Challenge 6 support - duplicate detection)
        /// </summary>
        /// <param name="obj">Object to compare against</param>
        /// <returns>True when all properties (except Id) and the type match</returns>
        public override bool Equals(object? obj)
        {
            // A vehicle can only equal another vehicle of the exact same type
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }
            VehicleModel other = (VehicleModel)obj;
            return Make == other.Make && Model == other.Model && Year == other.Year &&
                Price == other.Price && NumWheels == other.NumWheels &&
                Color == other.Color && Miles == other.Miles;
        }

        /// <summary>
        /// Hash code that matches the Equals override
        /// </summary>
        /// <returns>Hash of the compared properties</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Make, Model, Year, Price, NumWheels, Color, Miles);
        }
    }
}
