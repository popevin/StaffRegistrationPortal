using StaffRegistrationPortal.Common;
using StaffRegistrationPortal.DTOs;

namespace StaffRegistrationPortal.Services
{
    public interface IUserService
    {
        Task<BaseResponse> CreateUser(CreateUser info, string createdBy);

        Task<BaseResponse> UpdateUser(UpdateUser info,string updatedBy);

        Task<BaseResponse> LogInUser(EmailandPassword info);

        Task<BaseResponse> LogOutUser(EmailandPassword info);

        Task<BaseResponse> DeactivateUser(DeactivateUser info,string deactivatedBy);

        Task<BaseResponse> ReactivateUser(ReactivateUser info, string reactivatedBy);

        Task<BaseResponse> FindUser(string userEmail);

        Task<BaseResponse> FindUser(long userId);

        Task<BaseResponse> GetAllUsers();

        Task<BaseResponse> GetAllActiveUsers();
    }
}
