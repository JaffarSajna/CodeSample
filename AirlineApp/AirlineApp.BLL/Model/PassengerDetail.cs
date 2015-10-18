
namespace AirlineApp.BLL
{

    /// <summary>
    /// Passenger Detail
    /// </summary>
    public class PassengerDetail
    {
        /// <summary>
        /// Passenger Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Passenger Age
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// LoyaltyPoints
        /// </summary>
        public int LoyaltyPoints { get; set; }
        /// <summary>
        /// IsRedeemed
        /// </summary>
        public bool IsRedeemed { get; set; }
        /// <summary>
        /// ExtraBaggage
        /// </summary>
        public bool ExtraBaggage { get; set; }
        /// <summary>
        /// Passenger Type
        /// </summary>
        public PassengerType Type { get; set; }
    }
}

