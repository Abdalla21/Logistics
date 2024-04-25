namespace LogisticsDataCore.Tables
{
    public class Category
    {
   [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        public required string CategoryName { get; set; }

        public string CategoryDescription { get; set; } = string.Empty;

    }
}
