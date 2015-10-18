using AirlineApp.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace AirlineApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ICheckPoint checkPoint = new CheckPoint();
            try
            {
                var dataFolders = DataFolders.DataFolderList;

                string inputFolderPath = dataFolders.GetPathValue(AirlineConstants.Input);
                string outputFolderPath = dataFolders.GetPathValue(AirlineConstants.Output);

                checkPoint.ProcessAirTravelData(inputFolderPath, outputFolderPath);
                
            }
            catch (CustomException ex)
            {
                Console.WriteLine(string.Format("Exception :{0}", ex.Message));
                //throw;
            }

            Console.ReadLine();
        }
    }
}
