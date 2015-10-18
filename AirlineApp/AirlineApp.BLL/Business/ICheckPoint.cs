using System.Collections.Generic;

namespace AirlineApp.BLL
{
    public interface ICheckPoint
    {
        bool ProcessAirTravelData(string inputFolderPath, string outputFolderPath);
    }
}