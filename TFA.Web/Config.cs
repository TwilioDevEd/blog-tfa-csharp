using System.Web.Configuration;

namespace TFA.Web
{
    public class Config
    {
        public static string TwilioAccountSID => WebConfigurationManager.AppSettings["TwilioAccountSID"];

        public static string TwilioAuthToken => WebConfigurationManager.AppSettings["TwilioAuthToken"];

        public static string TwilioNumber => WebConfigurationManager.AppSettings["TwilioNumber"];
    }
}