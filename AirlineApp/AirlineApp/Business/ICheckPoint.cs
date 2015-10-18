using System.Collections.Generic;
using AirlineApp.Model;

namespace AirlineApp.Business
{
    public interface ICheckPoint
    {
        List<AirTravelDetail> GetAirTravelDetails(string filePath);
        string GetSummaryReport(AirTravelDetail airtravelDetails);
    }
}