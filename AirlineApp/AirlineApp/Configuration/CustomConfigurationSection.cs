using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineApp.Configuration
{
    public class CustomConfigurationSection : ConfigurationSection
    {
        /// <summary>
		/// The name of this section in the app.config.
		/// </summary>
		public const string SectionName = "CustomConfigurationSection";

        private const string DataFolderCollectionName = "DataFolders";


        [ConfigurationProperty(DataFolderCollectionName)]
        [ConfigurationCollection(typeof(DataFolderCollection), AddItemName = "add")]
        public DataFolderCollection DataFolders { get { return (DataFolderCollection)base[DataFolderCollectionName]; } }


    }
}
