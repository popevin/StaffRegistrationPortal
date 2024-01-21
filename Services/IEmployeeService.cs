using StaffApplication.DTOs;
using StaffRegistrationPortal.Common;
using System.Threading.Tasks;

namespace StaffRegistrationPortal.Services
{
    public interface IEmployeeService
    {
        Task<BaseResponse> CreateEmployee(CreateEmployee info);

        Task<BaseResponse> UpdateEmployee(UpdateEmployee info);

        Task<BaseResponse> DeleteEmployee(DeleteEmployee info);

        Task<BaseResponse> FindEmployee(string userEmail);

        Task<BaseResponse> FindEmployee(int userId);

        Task<BaseResponse> GetAllActiveEmployee();

        Task<BaseResponse> GetAllEmployee();

    }
}
