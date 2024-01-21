using Microsoft.AspNetCore.Mvc;
using StaffApplication.DTOs;

namespace StaffApplication.Repositories
{
    public interface IUserRepository
    {
        Task<dynamic> CreateUser(CreateUser info);

        Task<dynamic> UpdateUser(UpdateUser info);

        Task<int> LogInUser(EmailandPassword info);

        Task<int> LogOutUser(EmailandPassword info);
        Task<int> DeActivateUser(DeactivateUser info);

        Task<int> ReActivateUser(ReactivateUser info);

        Task<User> FindUser(string userEmail);
        Task<User> FindUser(long userId);

        Task<IEnumerable<User>> GetAllUsers();

        Task<IEnumerable<User>> GetAllActiveUsers();














    }
}
