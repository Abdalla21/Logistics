namespace LogisticsDataCore.Models
{
    public class Store : SystemTableFields
    {

        public int StoreID { get; set; }

        public string StoreName { get; set; }

        public string StoreCityLocation { get; set; }

        public string StoreDescription { get; set; }

        public int StoreGovernorateID { get; set; }

        public int StoreManagerID { get; set; }

    }
}
