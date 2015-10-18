using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineApp.Configuration
{
    public class DataFolder
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }

    public static class DataFolders
    {

        public static IEnumerable<DataFolder> DataFolderList { get { foreach (var dataFolder in _dataFolderList) { yield return dataFolder; } } }
        private static readonly List<DataFolder> _dataFolderList = new List<DataFolder>();

        /// <summary>
        /// Constructor.
        /// </summary>
        static DataFolders()
        {
            var customSection = ConfigurationManager.GetSection(CustomConfigurationSection.SectionName) as CustomConfigurationSection;
            if (customSection != null)
            {
                foreach (DataFolderElement dataFolderElement in customSection.DataFolders)
                {
                    var dataFolder = new DataFolder() { Name = dataFolderElement.Name, Path = dataFolderElement.Path };
                    AddDataFolder(dataFolder);
                }
            }
        }

        public static void AddDataFolder(DataFolder dataFolder)
        {
            if (dataFolder == null)
                return;

            if (!_dataFolderList.Contains(dataFolder))
                _dataFolderList.Add(dataFolder);
        }

    }
}
