using Dapper;
using Microsoft.AspNetCore.Mvc;
using StaffApplication.DTOs;
using System.Data.SqlClient;


namespace StaffApplication.Repositories
{
    public interface IEmployeeRepository
    {
        Task<dynamic> CreateEmployee(CreateEmployee info);

        Task<dynamic> UpdateEmployee(UpdateEmployee info);

        Task<int> DeleteEmployee(DeleteEmployee info);
        Task<Employee> FindEmployee(int userId);

        Task<Employee> FindEmployee(string userEmail);

        Task<IEnumerable<Employee>> GetAllEmployee();
        Task<IEnumerable<Employee>> GetAllActiveEmployee();
        

    }
}
