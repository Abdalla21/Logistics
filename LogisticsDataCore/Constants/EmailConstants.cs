namespace LogisticsDataCore.Constants
{
    public interface EmailConstants
    {
        public static string Email = "logisticswebsite25@gmail.com";

        public static int SmtpPort = 587;

        public static string Subject = "Logistics Verification Code";

        public static string ServiceSmtpMail = "smtp.gmail.com";

        public static string GetEmailVerficationMsg(string code)
        {
            return $"Your Verification Code Is {code}";
        }
    }
}
