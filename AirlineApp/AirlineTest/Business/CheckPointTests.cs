using Microsoft.VisualStudio.TestTools.UnitTesting;
using AirlineApp.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AirlineApp.BLL.Tests
{
    [TestClass()]
    public class CheckPointTests
    {
        string sampleDataPath = string.Empty;
        string inputFolderPath = string.Empty;
        string outputFolderPath = string.Empty;
        string InvalidDataFolderPath = string.Empty;
        ICheckPoint checkPoint;

        public CheckPointTests()
        {
            checkPoint = new CheckPoint();
            sampleDataPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\SampleData";
            inputFolderPath = sampleDataPath + @"\Input";
            outputFolderPath = sampleDataPath + @"\Output";
            InvalidDataFolderPath = sampleDataPath + @"\InvalidData";

        }

        [TestMethod()]
        [ExpectedException(typeof(CustomException))]
        public void GetAirTravelDetailsTestInvalidFileException()
        {
            inputFolderPath = outputFolderPath = "invalid path";
            checkPoint.ProcessAirTravelData(inputFolderPath, outputFolderPath);
        }

        [TestMethod()]
        public void GetAirTravelDetailsTestSuccess()
        {
            bool result = checkPoint.ProcessAirTravelData(inputFolderPath, outputFolderPath);
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void GetAirTravelDetailsTestInvalidSourceData()
        {
            try
            {
                bool result = checkPoint.ProcessAirTravelData(InvalidDataFolderPath, outputFolderPath);
            }
            catch (CustomException ex)
            {
                Assert.IsTrue(ex.Message.Contains(AirlineConstants.InvalidData.Substring(0, 10)));
            }

        }


    }

}
