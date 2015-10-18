using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AirlineApp.BLL
{
    public static class Extension
    {
        public static string GetPathValue(this IEnumerable<DataFolder> dataFolders, params object[] name)
        {

            if (dataFolders != null)
            {
                DataFolder dataFolder = dataFolders.Where(x => x.Name == name.FirstOrDefault().ToString()).FirstOrDefault();
                if (dataFolder != null)
                    return dataFolder.Path;
            }

            return string.Empty;
        }

        public static bool IsValidPath(this string path)
        {
            return string.IsNullOrEmpty(path) || !Directory.Exists(path) ? false : true;

        }
    }
}
