namespace LogisticsDataCore.DTOs
{
    public class UserResponseDTO
    {
        public string UserName { get; set; }

        public int Age { get; set; }
        public byte[] Salt { get; set; }
        public byte[] Hash { get; set; }

        public string Password { get; set; }
        public string Role { get; set; }

    }
}
