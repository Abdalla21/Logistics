namespace LogisticsDataCore.Tables
{
    public class Role
    {

   [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleID { get; set; }

        public required string RoleName { get; set; }

        public string RoleDescription { get; set; } = string.Empty;


    }
}
