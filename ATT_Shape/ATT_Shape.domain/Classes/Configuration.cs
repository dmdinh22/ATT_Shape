using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace ATT_Shape.domain.Classes
{
    public class Configuration
    {
        public static string AccountSID
        {
            get { return WebConfigurationManager.AppSettings["TwilioAccountSid"]; }
        }
        public static string ApiKey
        {
            get { return WebConfigurationManager.AppSettings["TwilioApiKey"]; }
        }
        public static string ApiSecret
        {
            get { return WebConfigurationManager.AppSettings["TwilioApiSecret"]; }
        }
        public static string IpmServiceSID
        {
            get { return WebConfigurationManager.AppSettings["TwilioIpmServiceSid"]; }
        }
    }
}
