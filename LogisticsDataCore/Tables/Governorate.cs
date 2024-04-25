namespace LogisticsDataCore.Tables
{
    public class Governorate
    {

   [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GovernorateID { get; set; }

        public required string GovernorateName { get; set; }
    }
}
