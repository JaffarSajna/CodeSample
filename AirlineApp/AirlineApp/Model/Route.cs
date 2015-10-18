namespace AirlineApp.Model
{
    /// <summary>
    /// Route
    /// </summary>
    public class Route
    {
        /// <summary>
        /// Origin
        /// </summary>
        public string Origin { get; set; }
        /// <summary>
        /// Destination
        /// </summary>
        public string Destination { get; set; }
        /// <summary>
        /// Cost Per Passenger
        /// </summary>
        public int CostPerPassenger { get; set; }
        /// <summary>
        /// Ticket Price
        /// </summary>
        public int TicketPrice { get; set; }
        /// <summary>
        /// Minimum Take Of Load Percentage
        /// </summary>
        public int MinimumTakeOfLoadPercentage { get; set; }
    }
}
