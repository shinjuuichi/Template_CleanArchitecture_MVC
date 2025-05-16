using BusinessLogicLayer.Commons;
using BusinessLogicLayer.Interfaces.Services;
using BusinessLogicLayer.Utils;
using DataAccessLayer.Commons.Exceptions;
using DataAccessLayer.Interfaces.Base;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Implements.Services
{
    public class AuthService(IUnitOfWork _unitOfWork, AppConfiguration configuration) : IAuthService
    {
        public async Task<User> LoginAsync(User loginUser)
        {
            loginUser.TryValidate();

            var user = await _unitOfWork.UserRepository.GetByEmailAsync(loginUser.Email);
            if (user == null || !CryptoUtil.IsPasswordCorrect(loginUser.Password, user.Password))
            {
                throw new InvalidDataException("Email or password is incorrect");
            }

            return user;
        }


        public async Task RegisterAsync(User user)
        {
            user.TryValidate();

            if (await _unitOfWork.UserRepository.IsEmailExistAsync(user.Email))
            {
                throw new DataConflictException(typeof(User), nameof(User.Email));
            }

            user.Password = CryptoUtil.EncryptPassword(user.Password);
            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
