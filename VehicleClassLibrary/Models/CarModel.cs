/*
 * Bing [Last Name]
 * CST-250
 * 10/25/2026
 * Vehicle Class Library
 * Activity 1
 * Resources: CST-250 Activity 1 Guide (Grand Canyon University, 2025)
 */

namespace VehicleClassLibrary.Models
{
    /// <summary>
    /// Model for a car. Inherits the common vehicle data from VehicleModel
    /// and adds a car-specific properties.
    /// </summary>
    public class CarModel : VehicleModel
    {
        // Class level properties
        public bool IsConvertible { get; set; }
        public decimal TrunkSize { get; set; } // In cubic feet

        /// <summary>
        /// Default constructor for a car
        /// </summary>
        public CarModel() : base()
        {
            IsConvertible = false;
            TrunkSize = 0m;
        }

        /// <summary>
        /// Parameterized constructor for a car
        /// </summary>
        /// <param name="id">Unique id of the vehicle</param>
        /// <param name="make">Manufacturer of the vehicle</param>
        /// <param name="model">Model name of the vehicle</param>
        /// <param name="year">Model year of the vehicle</param>
        /// <param name="price">Price of the vehicle</param>
        /// <param name="numWheels">Number of wheels on the vehicle</param>
        /// <param name="color">Exterior color of the vehicle</param>
        /// <param name="miles">Odometer reading of the vehicle</param>
        /// <param name="isConvertible">Whether the car is a convertible</param>
        /// <param name="trunkSize">Trunk size in cubic feet</param>
        public CarModel(int id, string make, string model, int year, decimal price, int numWheels,
            string color, int miles, bool isConvertible, decimal trunkSize)
            : base(id, make, model, year, price, numWheels, color, miles)
        {
            IsConvertible = isConvertible;
            TrunkSize = trunkSize;
        }

        /// <summary>
        /// ToString method for printing a car
        /// </summary>
        /// <returns>A formatted description of a car</returns>
        public override string ToString()
        {
            // Use a ternary operator (in-line if) to get the descriptive string
            //                 condition    if true   if false
            string convertible = IsConvertible ? "with" : "without";

            // Print a car in the following format
            // 1: 2019 Black Jeep Wrangler with 4 wheels and 30,000 miles and a 14.7 cubic foot trunk with(out) a convertible top - $27,000.00
            return $"{Id}: {Year} {Color} {Make} {Model} with {NumWheels} wheels and {Miles:N0} miles and a {TrunkSize} cubic foot trunk {convertible} a convertible top - {Price:C2}";
        }

        /// <summary>
        /// Compares two cars on every property except the Id (GUI Challenge 6)
        /// </summary>
        /// <param name="obj">Object to compare against</param>
        /// <returns>True when the base properties and the car properties match</returns>
        public override bool Equals(object? obj)
        {
            // Reuse the base comparison, then compare the specialty properties
            return base.Equals(obj) && obj is CarModel other &&
                IsConvertible == other.IsConvertible && TrunkSize == other.TrunkSize;
        }

        /// <summary>
        /// Hash code that matches the Equals override
        /// </summary>
        /// <returns>Hash of the compared properties</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), IsConvertible, TrunkSize);
        }
    }
}
