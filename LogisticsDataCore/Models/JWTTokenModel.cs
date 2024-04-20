namespace LogisticsDataCore.Models
{
    public class JWTTokenModel
    {
        public required string Token { get; set; }
        public required string ExpireDate { get; set; }
        public required string TokenType { get; set; }
    }
}
