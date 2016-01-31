using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MVCRequestLifeCycle.Configuration
{
    public class Redirect : ConfigurationElement
    {
        [ConfigurationProperty("Title")]
        public string Title
        {
            get { return (string)this["Title"]; }
        }

        [ConfigurationProperty("Old")]
        public string Old
        {
            get { return (string)this["Old"]; }
        }

        [ConfigurationProperty("New")]
        public string New
        {
            get { return (string)this["New"]; }
        }
    }
}