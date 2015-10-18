using System.Collections.Generic;
using System.Linq;

namespace AirlineApp.BLL
{
    /// <summary>
    /// Summary report
    /// </summary>
    public class SummaryReport
    {
        private AirTravelDetail _airTravelDetail;
        private bool _canFlightProceed = true;

        public SummaryReport(AirTravelDetail airtravelDetail)
        {
            _airTravelDetail = airtravelDetail;
        }

        public int TotalPassengerCount { get; set; }
        public int GeneralPassengerCount { get; set; }
        public int AirlinePassengerCount { get; set; }
        public int LoyaltyPassengerCount { get; set; }
        /// <summary>
        /// Calculating Total number of bags 
        /// TotalPassengerCount + ExtraBaggage
        /// </summary>
        public int TotalNumberofBags { get { return TotalPassengerCount + _airTravelDetail.PassengerDetails.Count(x => x.ExtraBaggage); } }
        public int TotalLoyaltyPointsRedeemed { get; set; }
        /// <summary>
        /// Calculating Total Cost Of Flight
        /// TotalPassengerCount * CostPerPassenger
        /// </summary>
        public int TotalCostOfFlight { get { return TotalPassengerCount * _airTravelDetail.FlightDetail.Route.CostPerPassenger; } }
        /// <summary>
        /// Calculating TotalUnAdjustedTicketRevenue
        /// TotalPassengerCount * TicketPrice
        /// </summary>
        public int TotalUnAdjustedTicketRevenue { get { return TotalPassengerCount * _airTravelDetail.FlightDetail.Route.TicketPrice; } }
        /// <summary>
        /// Calculating TotalAdjustedRevenue
        /// TotalUnAdjustedTicketRevenue - (AirlinePassengerCount * TicketPrice) - TotalLoyaltyPointsRedeemed)
        /// </summary>
        public int TotalAdjustedRevenue { get { return TotalUnAdjustedTicketRevenue - (AirlinePassengerCount * _airTravelDetail.FlightDetail.Route.TicketPrice) - TotalLoyaltyPointsRedeemed; } }
        public bool CanFlightProceed { get { return _canFlightProceed; } }

        public override string ToString()
        {
            List<string> sb = new List<string>();

            // Rule 1
            if (TotalAdjustedRevenue < TotalCostOfFlight)
                _canFlightProceed = false;
            //Rule 2
            else if (TotalPassengerCount > _airTravelDetail.FlightDetail.NoOfSeats)
                _canFlightProceed = false;
            //Rule 3
            else if ((TotalPassengerCount / _airTravelDetail.FlightDetail.NoOfSeats) * 100 < _airTravelDetail.FlightDetail.Route.MinimumTakeOfLoadPercentage)
                _canFlightProceed = false;

            

            sb.Add(TotalPassengerCount.ToString());
            sb.Add(GeneralPassengerCount.ToString());
            sb.Add(AirlinePassengerCount.ToString());
            sb.Add(LoyaltyPassengerCount.ToString());
            sb.Add(TotalNumberofBags.ToString());
            sb.Add(TotalLoyaltyPointsRedeemed.ToString());
            sb.Add(TotalCostOfFlight.ToString());
            sb.Add(TotalUnAdjustedTicketRevenue.ToString());
            sb.Add(TotalAdjustedRevenue.ToString());
            sb.Add(CanFlightProceed.ToString());

            return string.Join(" ", sb);
        }
    }
}
