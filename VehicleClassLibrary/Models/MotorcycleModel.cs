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
    /// Model for a motorcycle. Inherits the common vehicle data from VehicleModel
    /// and adds a motorcycle-specific properties.
    /// </summary>
    public class MotorcycleModel : VehicleModel
    {
        // Class level properties
        public bool HasSideCar { get; set; }
        public decimal SeatHeight { get; set; } // In inches

        /// <summary>
        /// Default constructor for a motorcycle
        /// </summary>
        public MotorcycleModel() : base()
        {
            HasSideCar = false;
            SeatHeight = 0m;
        }

        /// <summary>
        /// Parameterized constructor for a motorcycle
        /// </summary>
        /// <param name="id">Unique id of the vehicle</param>
        /// <param name="make">Manufacturer of the vehicle</param>
        /// <param name="model">Model name of the vehicle</param>
        /// <param name="year">Model year of the vehicle</param>
        /// <param name="price">Price of the vehicle</param>
        /// <param name="numWheels">Number of wheels on the vehicle</param>
        /// <param name="color">Exterior color of the vehicle</param>
        /// <param name="miles">Odometer reading of the vehicle</param>
        /// <param name="hasSideCar">Whether the motorcycle has a side car</param>
        /// <param name="seatHeight">Seat height in inches</param>
        public MotorcycleModel(int id, string make, string model, int year, decimal price, int numWheels,
            string color, int miles, bool hasSideCar, decimal seatHeight)
            : base(id, make, model, year, price, numWheels, color, miles)
        {
            HasSideCar = hasSideCar;
            SeatHeight = seatHeight;
        }

        /// <summary>
        /// ToString method for printing a motorcycle
        /// </summary>
        /// <returns>A formatted description of a motorcycle</returns>
        public override string ToString()
        {
            // Use a ternary operator (in-line if) to get the descriptive string
            //                 condition    if true   if false
            string sideCar = HasSideCar ? "with" : "without";

            // Print a motorcycle in the following format
            // 1: 2015 Blue Yamaha Bolt with 2 wheels and 8,000 miles and a 44.1 inch seat with(out) a side car - $8,000.00
            return $"{Id}: {Year} {Color} {Make} {Model} with {NumWheels} wheels and {Miles:N0} miles and a {SeatHeight} inch seat {sideCar} a side car - {Price:C2}";
        }

        /// <summary>
        /// Compares two motorcycles on every property except the Id (GUI Challenge 6)
        /// </summary>
        /// <param name="obj">Object to compare against</param>
        /// <returns>True when the base properties and the motorcycle properties match</returns>
        public override bool Equals(object? obj)
        {
            // Reuse the base comparison, then compare the specialty properties
            return base.Equals(obj) && obj is MotorcycleModel other &&
                HasSideCar == other.HasSideCar && SeatHeight == other.SeatHeight;
        }

        /// <summary>
        /// Hash code that matches the Equals override
        /// </summary>
        /// <returns>Hash of the compared properties</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), HasSideCar, SeatHeight);
        }
    }
}
