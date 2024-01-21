using StaffApplication.DTOs;
using StaffRegistrationPortal.Common;

namespace StaffRegistrationPortal.Services
{
    public interface IUserService
    {
        Task<BaseResponse> CreateUser(CreateUser info);

        Task<BaseResponse> UpdateUser(UpdateUser info);

        Task<BaseResponse> LogInUser(EmailandPassword info);

        Task<BaseResponse> LogOutUser(EmailandPassword info);

        Task<BaseResponse> DeactivateUser(DeactivateUser info);

        Task<BaseResponse> ReactivateUser(ReactivateUser info);

        Task<BaseResponse> FindUser(string userEmail);

        Task<BaseResponse> FindUser(long userId);

        Task<BaseResponse> GetAllUsers();

        Task<BaseResponse> GetAllActiveUsers();
    }
}
