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
    /// Model for a pickup. Inherits the common vehicle data from VehicleModel
    /// and adds a pickup-specific properties.
    /// </summary>
    public class PickupModel : VehicleModel
    {
        // Class level properties
        public bool HasBedCover { get; set; }
        public decimal BedSize { get; set; } // In cubic feet

        /// <summary>
        /// Default constructor for a pickup
        /// </summary>
        public PickupModel() : base()
        {
            HasBedCover = false;
            BedSize = 0m;
        }

        /// <summary>
        /// Parameterized constructor for a pickup
        /// </summary>
        /// <param name="id">Unique id of the vehicle</param>
        /// <param name="make">Manufacturer of the vehicle</param>
        /// <param name="model">Model name of the vehicle</param>
        /// <param name="year">Model year of the vehicle</param>
        /// <param name="price">Price of the vehicle</param>
        /// <param name="numWheels">Number of wheels on the vehicle</param>
        /// <param name="color">Exterior color of the vehicle</param>
        /// <param name="miles">Odometer reading of the vehicle</param>
        /// <param name="hasBedCover">Whether the pickup has a bed cover</param>
        /// <param name="bedSize">Bed size in cubic feet</param>
        public PickupModel(int id, string make, string model, int year, decimal price, int numWheels,
            string color, int miles, bool hasBedCover, decimal bedSize)
            : base(id, make, model, year, price, numWheels, color, miles)
        {
            HasBedCover = hasBedCover;
            BedSize = bedSize;
        }

        /// <summary>
        /// ToString method for printing a pickup
        /// </summary>
        /// <returns>A formatted description of a pickup</returns>
        public override string ToString()
        {
            // Use a ternary operator (in-line if) to get the descriptive string
            //                 condition    if true   if false
            string bedCover = HasBedCover ? "with" : "without";

            // Print a pickup in the following format
            // 1: 2001 White Toyota Tundra with 4 wheels and 120,000 miles and a 8.3 cubic foot bed with(out) a bed cover - $5,000.00
            return $"{Id}: {Year} {Color} {Make} {Model} with {NumWheels} wheels and {Miles:N0} miles and a {BedSize} cubic foot bed {bedCover} a bed cover - {Price:C2}";
        }

        /// <summary>
        /// Compares two pickups on every property except the Id (GUI Challenge 6)
        /// </summary>
        /// <param name="obj">Object to compare against</param>
        /// <returns>True when the base properties and the pickup properties match</returns>
        public override bool Equals(object? obj)
        {
            // Reuse the base comparison, then compare the specialty properties
            return base.Equals(obj) && obj is PickupModel other &&
                HasBedCover == other.HasBedCover && BedSize == other.BedSize;
        }

        /// <summary>
        /// Hash code that matches the Equals override
        /// </summary>
        /// <returns>Hash of the compared properties</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), HasBedCover, BedSize);
        }
    }
}
