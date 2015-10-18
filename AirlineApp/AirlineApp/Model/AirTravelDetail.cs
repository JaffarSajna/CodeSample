using System.Collections.Generic;

namespace AirlineApp.Model
{
    /// <summary>
    /// Air Travel Detail
    /// </summary>
    public class AirTravelDetail
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public AirTravelDetail()
        {
            FlightDetail = new FlightDetail();
            PassengerDetails = new List<PassengerDetail>();
        }
        /// <summary>
        /// Flight Detail
        /// </summary>
        public FlightDetail FlightDetail { get; set; }
        /// <summary>
        /// Passenger Details
        /// </summary>
        public List<PassengerDetail> PassengerDetails { get; set; }
    }

}
