namespace LogisticsDataCore.Interfaces.IEmailService
{
    public interface IEmailService
    {

        public Task SendEmailAsync(string email, string subject, string message, string password);

    }
}
