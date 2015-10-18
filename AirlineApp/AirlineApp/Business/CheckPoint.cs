using AirlineApp.Model;
using AirlineApp.Model.Constants;
using AirlineApp.Model.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AirlineApp.Business
{
    /// <summary>
    /// CheckPoint 
    /// </summary>
    public class CheckPoint : ICheckPoint
    {
        List<string> records = new List<string>();

        /// <summary>
        /// Get TravelDetails
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<AirTravelDetail> GetAirTravelDetails(string filePath)
        {
            try
            {
                var airTravelDetails = new List<AirTravelDetail>();
                //var configuration = new AirlineConfigurationManager();
                records = new List<string>();

                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        records.Add(sr.ReadLine());
                    }
                }

                airTravelDetails.Add(GetAirTravelDetail());

                return airTravelDetails;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Get Summary Report of Travel
        /// </summary>
        /// <param name="airtravelDetail"></param>
        /// <returns></returns>
        public string GetSummaryReport(AirTravelDetail airtravelDetail)
        {
            try
            {
                var summaryReport = new SummaryReport(airtravelDetail)
                {
                    TotalPassengerCount = airtravelDetail.PassengerDetails.Count,
                    GeneralPassengerCount = airtravelDetail.PassengerDetails.Count(x => x.Type == PassengerType.general),
                    AirlinePassengerCount = airtravelDetail.PassengerDetails.Count(x => x.Type == PassengerType.airline),
                    LoyaltyPassengerCount = airtravelDetail.PassengerDetails.Count(x => x.Type == PassengerType.loyalty),
                    TotalLoyaltyPointsRedeemed = airtravelDetail.PassengerDetails.Where(x => x.IsRedeemed).Sum(x => x.LoyaltyPoints),
                };

                return summaryReport.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        #region Private Methods
        /// <summary>
        /// Get Travel Detail
        /// </summary>
        /// <returns></returns>
        private AirTravelDetail GetAirTravelDetail()
        {
            try
            {
                AirTravelDetail airTravelDetail = new AirTravelDetail();
                List<string[]> passengers = new List<string[]>();


                string[] flightInfo = ExtractDetail(AirlineConstants.Aircraft).FirstOrDefault();
                string[] routeDetail = ExtractDetail(AirlineConstants.Route).FirstOrDefault();
                passengers.AddRange(ExtractDetail(AirlineConstants.General));
                passengers.AddRange(ExtractDetail(AirlineConstants.Loyalty));
                passengers.AddRange(ExtractDetail(AirlineConstants.Airline));


                airTravelDetail.FlightDetail = new FlightDetail()
                {
                    FlightName = flightInfo[1],
                    NoOfSeats = Convert.ToInt32(flightInfo[2]),
                    Route = new Route()
                    {
                        Origin = routeDetail[1],
                        Destination = routeDetail[2],
                        CostPerPassenger = Convert.ToInt32(routeDetail[3]),
                        TicketPrice = Convert.ToInt32(routeDetail[4]),
                        MinimumTakeOfLoadPercentage = Convert.ToInt32(routeDetail[5])
                    }
                };

                passengers.ForEach(x =>
                {
                    airTravelDetail.PassengerDetails.Add(new PassengerDetail()
                    {
                        Type = (PassengerType)Enum.Parse(typeof(PassengerType), x[0]),
                        Name = x[1],
                        Age = Convert.ToInt32(x[2]),
                        LoyaltyPoints = x.Length > 3 ? Convert.ToInt32(x[3]) : 0,
                        IsRedeemed = x.Length > 4 ? Convert.ToBoolean(x[4]) : false,
                        ExtraBaggage = x.Length > 5 ? Convert.ToBoolean(x[5]) : false,
                    });
                });

                return airTravelDetail;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        /// <summary>
        /// Extract Detail from string array
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private List<string[]> ExtractDetail(string data)
        {
            List<string[]> extractedDetails = new List<string[]>();
            var filteredRecord = records.Where(x => x.Contains(data)).ToList();
            filteredRecord.ForEach(x =>
            {
                extractedDetails.Add(x.Substring(x.IndexOf(data)).Split(' '));
            }
            );
            return extractedDetails;
        }
        #endregion
    }



}

