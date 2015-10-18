using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AirlineApp.BLL
{
    /// <summary>
    /// CheckPoint 
    /// </summary>
    public class CheckPoint : ICheckPoint
    {
        List<string> records = new List<string>();

        /// <summary>
        /// Processing Air Travel Data
        /// </summary>
        /// <param name="inputFolderPath"></param>
        /// <param name="outputFolderPath"></param>
        /// <returns></returns>
        public bool ProcessAirTravelData(string inputFolderPath, string outputFolderPath)
        {
            ICheckPoint checkPoint = new CheckPoint();
            //List<string> reports = new List<string>();

            try
            {

                if (!inputFolderPath.IsValidPath())
                    throw new CustomException(string.Format(AirlineConstants.InvalidSourcePath, inputFolderPath));

                string[] files = Directory.GetFiles(inputFolderPath);


                foreach (string filePath in files)
                {
                    FileInfo info = new FileInfo(filePath);
                    var outputFolderName = string.Format(@"{0}\Report_{1}", outputFolderPath, info.Name);

                    var travelDetail = this.GetAirTravelData(filePath);

                    if (travelDetail == null)
                    {
                        //Log
                        Console.WriteLine(string.Format(AirlineConstants.InvalidData, filePath));
                        continue;
                    }

                    var report = this.GetSummaryReport(travelDetail);

                    if (!outputFolderPath.IsValidPath() || string.IsNullOrEmpty(report))
                    {
                        //Log
                        Console.WriteLine(string.Format(AirlineConstants.InvalidOutputPathErrorMessage, report));
                        continue;
                    }

                    using (StreamWriter sw = new StreamWriter(outputFolderName))
                    {
                        //Log
                        Console.WriteLine(string.Format(AirlineConstants.SuccessMessage, report, outputFolderName));
                        sw.WriteLine(report);
                    }
                    //reports.Add(report);
                };

            }
            catch (CustomException)
            {
                throw;
            }
            return true;
        }

        #region Private Methods
        /// <summary>
        /// Get Summary Report of Travel
        /// </summary>
        /// <param name="airtravelDetail"></param>
        /// <returns></returns>
        private string GetSummaryReport(AirTravelDetail airtravelDetail)
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
            catch (CustomException)
            {

                throw;
            }

        }

        /// <summary>
        /// Get Travel Detail
        /// </summary>
        /// <returns></returns>
        private AirTravelDetail GenerateAirTravelData()
        {
            try
            {
                AirTravelDetail airTravelDetail = new AirTravelDetail();
                List<string[]> passengers = new List<string[]>();


                string[] flightInfo = ExtractData(AirlineConstants.Aircraft).FirstOrDefault();
                string[] routeDetail = ExtractData(AirlineConstants.Route).FirstOrDefault();
                passengers.AddRange(ExtractData(AirlineConstants.General));
                passengers.AddRange(ExtractData(AirlineConstants.Loyalty));
                passengers.AddRange(ExtractData(AirlineConstants.Airline));


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
                throw new CustomException(AirlineConstants.InvalidData);
            }

        }

        /// <summary>
        /// Extract Detail from string array
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private List<string[]> ExtractData(string data)
        {
            List<string[]> extractedDatas = new List<string[]>();
            var filteredRecord = records.Where(x => x.Contains(data)).ToList();
            filteredRecord.ForEach(x =>
            {
                extractedDatas.Add(x.Substring(x.IndexOf(data)).Split(' '));
            }
            );
            return extractedDatas;
        }

        /// <summary>
        /// Get travel data
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private AirTravelDetail GetAirTravelData(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    throw new CustomException(string.Format(AirlineConstants.FileNotFoundErrorMessage, filePath));

                AirTravelDetail airTravelData = null;
                records = new List<string>();

                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        records.Add(sr.ReadLine());
                    }
                }

                airTravelData = GenerateAirTravelData();

                return airTravelData;
            }
            catch (CustomException ex)
            {
                if (ex.Message.Equals(AirlineConstants.InvalidData)) throw new CustomException(string.Format(ex.Message, filePath));

                throw;
            }

        }
        #endregion
    }



}

