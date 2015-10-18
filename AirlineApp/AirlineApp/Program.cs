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
                #region oldcode
                //if (string.IsNullOrEmpty(inputFolderPath)) throw new Exception(AirlineConstants.InValidPathErrorMessage);

                //string[] files = Directory.GetFiles(inputFolderPath);

                //foreach (string filePath in files)
                //{
                //    FileInfo info = new FileInfo(filePath);
                //    var outputFolderName = string.Format(@"{0}\{1}", outputFolderPath, info.Name);

                //    checkPoint.GetAirTravelDetails(filePath)
                //        .ForEach(travelDetail =>
                //        {
                //            var report = checkPoint.GetSummaryReport(travelDetail);

                //            if (string.IsNullOrEmpty(outputFolderPath) || string.IsNullOrEmpty(report))
                //            {
                //                Console.WriteLine(string.Format(AirlineConstants.InValidOutputPathErrorMessage, report));
                //                return;

                //            }

                //            using (StreamWriter sw = new StreamWriter(outputFolderName))
                //            {
                //                Console.WriteLine(string.Format(AirlineConstants.SuccessMessage, report, outputFolderName));
                //                sw.WriteLine(report);
                //            }
                //            reports.Add(report);
                //        });
                //}
                #endregion
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
