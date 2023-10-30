using LogisticsDataCore.Constants;

namespace LogisticsDataCore.Models
{
    public class SystemTableFields
    {
        public string CreatedDateTime { get; set; } = DateTime.Now.ToString(GlobalConstants.DateTimeFormat);
    }
}
