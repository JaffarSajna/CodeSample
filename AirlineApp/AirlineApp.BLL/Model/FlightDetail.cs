namespace AirlineApp.BLL
{

    /// <summary>
    /// Flight Detail
    /// </summary>
    public class FlightDetail
    {
        /// <summary>
        /// Flight Name
        /// </summary>
        public string FlightName { get; set; }
        /// <summary>
        /// Number of seats
        /// </summary>
        public int NoOfSeats { get; set; }
        /// <summary>
        /// Route
        /// </summary>
        public Route Route { get; set; }
    }

}

