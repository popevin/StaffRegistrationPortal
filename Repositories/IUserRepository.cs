using Microsoft.AspNetCore.Mvc;
using StaffRegistrationPortal.DTOs;


namespace StaffApplication.Repositories
{
    public interface IUserRepository
    {
        Task<dynamic> CreateUser(CreateUser info, string createdBy);

        Task<dynamic> UpdateUser(UpdateUser info,string updatedBy);

        Task<int> LogInUser(EmailandPassword info);

        Task<int> LogOutUser(EmailandPassword info);
        Task<int> DeActivateUser(DeactivateUser info, string deactivatedBy);

        Task<int> ReActivateUser(ReactivateUser info, string reactivatedBy);

        Task<User> FindUser(string userEmail);
        Task<User> FindUser(int userId);

        Task<IEnumerable<User>> GetAllUsers();

        Task<IEnumerable<User>> GetAllActiveUsers();














    }
}
