using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Demo.WhoIs.CDL
{
    /// <summary>
    /// Class for constants
    /// </summary>
    public class TConstants
    {
        private const string XML_PATH = "xmlPath";

        /// <summary>
        /// Time expiration => 5 min
        /// </summary>
        public const int EXPIRATION_TIME = 5;

        public static string SXmlPath
        {
            get
            {
                return ConfigurationManager.AppSettings[TConstants.XML_PATH];
            }
        }
    }
}
