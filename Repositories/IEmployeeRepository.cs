using Dapper;
using Microsoft.AspNetCore.Mvc;
using StaffRegistrationPortal.DTOs;
using System.Data.SqlClient;


namespace StaffApplication.Repositories
{
    public interface IEmployeeRepository
    {
        Task<dynamic> CreateEmployee(CreateEmployee info,string createdBy);

        Task<dynamic> UpdateEmployee(UpdateEmployee info,string updatedBy);

        Task<int> DeleteEmployee(DeleteEmployee info,string deletedBy);
        Task<Employee> FindEmployee(int userId);

        Task<Employee> FindEmployee(string userEmail);

        Task<IEnumerable<Employee>> GetAllEmployee();
        Task<IEnumerable<Employee>> GetAllActiveEmployee();
        

    }
}
