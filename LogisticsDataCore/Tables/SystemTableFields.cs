using LogisticsDataCore.Constants;

namespace LogisticsDataCore.Tables
{
    public class SystemTableFields
    {
        public string CreatedDateTime { get; set; } = GlobalConstants.getDateTimeNowFormatted();
    }
}
