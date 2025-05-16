//using DataAccessLayer.Interfaces.Base;
//using DataAccessLayer.Interfaces.Services;
//using DataAccessLayer.Models.Enums;
//using Microsoft.AspNetCore.Identity.UI.Services;

//namespace BusinessLogicLayer.Implements.Services
//{
//    public class EmailService(IUnitOfWork _unitOfWork, IEmailSender emailSender) : IEmailService
//    {
//        public async Task SendNotificationToAdminAsync()
//        {
//            var adminAccounts = await _unitOfWork.UserRepository.GetAllAsync(user => user.Role == RoleEnum.Admin);
//            var emails = adminAccounts.Select(adminAccounts => adminAccounts.Email).ToList();
//            foreach (var email in emails)
//            {
//                await emailSender.SendEmailAsync(email, "Notification", "You have a new notification.");
//            }
//        }
//    }
//}
