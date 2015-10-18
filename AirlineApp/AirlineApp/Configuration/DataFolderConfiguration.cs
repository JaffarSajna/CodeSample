using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineApp.Configuration
{
    public class DataFolderCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DataFolderElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DataFolderElement)element).Name;
        }
    }

    public class DataFolderElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("path", IsRequired = true)]
        public string Path
        {
            get { return (string)this["path"]; }
            set { this["path"] = value; }
        }
    }
}
