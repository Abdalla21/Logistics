namespace LogisticsDataCore.Tables
{
    public class Role
    {
        public int RoleID { get; set; }

        public required string RoleName { get; set; }

        public string RoleDescription { get; set; } = string.Empty;


    }
}
