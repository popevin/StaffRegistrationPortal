using StaffRegistrationPortal.Common;
using StaffRegistrationPortal.DTOs;
using System.Threading.Tasks;

namespace StaffRegistrationPortal.Services
{
    public interface IEmployeeService
    {
        Task<BaseResponse> CreateEmployee(CreateEmployee info, string createdBy);

        Task<BaseResponse> UpdateEmployee(UpdateEmployee info,string updatedBy);

        Task<BaseResponse> DeleteEmployee(DeleteEmployee info,string deletedBy);

        Task<BaseResponse> FindEmployee(string userEmail);

        Task<BaseResponse> FindEmployee(int userId);

        Task<BaseResponse> GetAllActiveEmployee();

        Task<BaseResponse> GetAllEmployee();

    }
}
