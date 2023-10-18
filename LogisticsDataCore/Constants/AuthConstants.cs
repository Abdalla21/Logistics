namespace LogisticsProject
{
    public class AuthConstants
    {

        public readonly static List<string> Roles = new List<string>()
        {
            "Admin",
            "Warehouse Manager",
            "Delivery"
        };

        public readonly static int JWTTokenExpireDateByHours = 1;

        public readonly static string TokenType = "JWT";

    }
}
