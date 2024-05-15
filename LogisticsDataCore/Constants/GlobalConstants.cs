using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogisticsDataCore.Constants
{
    public class GlobalConstants
    {
        public static string DateTimeFormat = "G";

        public static string getDateTimeNowFormatted()
        {
            return DateTime.Now.ToString(DateTimeFormat);
        }

        public static string RateLimitFirstConfigurationName = "IpRateLimiting";

        public static string RateLimitSecondConfigurationName = "IpRateLimiting";

        public static string ExceptionEndPointName = "/error";
        public static string HealthCheckEndPointName = "/health";

        public static string DBConnectionName = "DefaultConnection";

    }
}
