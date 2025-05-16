namespace DataAccessLayer.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendNotificationToAdminAsync();
    }
}
