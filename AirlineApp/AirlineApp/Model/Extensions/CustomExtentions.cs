using AirlineApp.Configuration;
using AirlineApp.Model.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineApp.Model.Extensions
{
    public static class Extension
    {
        public static string GetPathValue(this IEnumerable<DataFolder> dataFolders,params object[] name)
        {

            if (dataFolders != null)
            {
                DataFolder dataFolder = dataFolders.Where(x => x.Name == name.FirstOrDefault().ToString()).FirstOrDefault();
                if (dataFolder != null)
                    return dataFolder.Path;
            }

            return string.Empty;
        }
    }
}
