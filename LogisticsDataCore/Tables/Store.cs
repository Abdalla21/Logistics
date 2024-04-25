namespace LogisticsDataCore.Tables
{
    public class Store : SystemTableFields
    {

   [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StoreID { get; set; }

        public required string StoreName { get; set; }

        public required string StoreCityLocation { get; set; }

        public string StoreDescription { get; set; } = string.Empty;

        public int StoreGovernorateID { get; set; }

        public int StoreManagerID { get; set; }

    }
}
