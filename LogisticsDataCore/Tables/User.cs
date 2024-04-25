namespace LogisticsDataCore.Tables
{
    public class User : SystemTableFields
    {

   [Key] 
 [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        public required string UserName { get; set; }

        public required string PasswordHash { get; set; }

        public required int Age { get; set; }

        public required string Email { get; set; }

        public required string Phone { get; set; }

        public string? Role { get; set; }

        public bool IsVerified { get; set; } = false;

        public string? VerificationCode { get; set; }

        public string? IsAccepted { get; set; }

        public DateTime? VerificationCodeExpireDate { get; set; } = DateTime.Now.AddMinutes(10);

    }
}
