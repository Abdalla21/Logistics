namespace LogisticsDataCore.Constants
{
    public class GlobalConstants
    {
        public static string DateTimeFormat = "G";

        public static string getDateTimeNowFormatted()
        {
            return DateTime.Now.ToString(DateTimeFormat);
        }
    }
}
