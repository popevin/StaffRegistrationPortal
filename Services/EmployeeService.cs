using Microsoft.AspNetCore.Mvc;
using StaffApplication.DTOs;
using StaffRegistrationPortal.Common;
using StaffApplication.Repositories;
using StaffRegistrationPortal.Services;
using StaffRegistrationPortal.Enums;

namespace StaffApplication.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;
        public EmployeeService(IEmployeeRepository employeeRepository, IUserRepository userRepository)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
        }

        public async Task<BaseResponse> CreateEmployee(CreateEmployee info)
        {
            var response = new BaseResponse();

            try
            {
                var requesterDetails = await _userRepository.FindUser(info.CreatedBy);
                if (requesterDetails == null)
                {
                    response.ResponseMessage = "User details not found and not authorised to create an employee data";
                    response.ResponseCode = ResponseCode.NotFound.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }

                var userId = await _employeeRepository.FindEmployee(info.UserId);
                if (userId != null)
                {
                    response.ResponseMessage = "Employee details already exist. Use update employee details to update details if need be";
                    response.ResponseCode = ResponseCode.DuplicateError.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }
                var resp = await _employeeRepository.CreateEmployee(info);
                if (resp > 0)
                {
                    var newEmployee = await _employeeRepository.FindEmployee(info.UserId);

                    response.ResponseMessage = "Employee details Created Successfully";
                    response.ResponseCode = ResponseCode.Ok.ToString("D").PadLeft(2, '0');
                    response.Data = newEmployee;
                    return response;
                }
                else
                {
                    response.ResponseMessage = "An error occured while creating employee. Please contact admin";
                    response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.ResponseMessage = $"An exception occured while creating employee ==> Message: {ex.Message}";
                response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                response.Data = null;
                return response;
            }


        }

        public async Task<BaseResponse> UpdateEmployee(UpdateEmployee info)
        {
            var response = new BaseResponse();

            try
            {
               /* var requesterDetails = await _employeeRepository.FindEmployee(info.UpdatedBy);
                if (requesterDetails == null)
                {
                    response.ResponseMessage = "Employee details not found or probably deleted,  update fail";
                    response.ResponseCode = "404";
                    response.Data = null;
                    return response;
                }*/
                var userId = await _employeeRepository.FindEmployee(info.UserId);
                if (userId == null)
                {
                    response.ResponseMessage = "Employee userId cannot be found ,you can create a new employee,using create employeedetails";
                    response.ResponseCode = ResponseCode.NotFound.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }
                var resp = await _employeeRepository.UpdateEmployee(info);
                if (resp > 0)
                {
                    var updateEmployee = await _employeeRepository.FindEmployee(info.UserId);

                    response.ResponseMessage = "Employee details Updated Successfully";
                    response.ResponseCode = ResponseCode.Ok.ToString("D").PadLeft(2, '0');
                    response.Data = updateEmployee;
                    return response;
                }
                else
                {
                    response.ResponseMessage = "An error occured while Updating Employee. Please contact admin";
                    response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }


            }
            catch (Exception ex)
            {
                response.ResponseMessage = $"An exception occured while Updating Employee ==> Message: {ex.Message}";
                response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                response.Data = null;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteEmployee(DeleteEmployee info)
        {
            var response = new BaseResponse();
            try
            {

                var requesterDetails = await _employeeRepository.FindEmployee(info.DeletedBy);
                if (requesterDetails == null)
                {
                    response.ResponseMessage = "Employee details not found or probably deleted,  ";
                    response.ResponseCode = ResponseCode.NotFound.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }
                var resp = await _employeeRepository.DeleteEmployee(info);
                if (resp > 0)
                {
                    response.ResponseMessage = "Employee details Deleted Successfully";
                    response.ResponseCode = ResponseCode.Ok.ToString("D").PadLeft(2, '0');
                    response.Data = resp;
                    return response;
                }
                else
                {
                    response.ResponseMessage = "An error occured while Deleting Employee. Please contact admin";
                    response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }

            }
            catch (Exception ex)
            {
                response.ResponseMessage = $"An exception occured while Deleting Employee ==> Message: {ex.Message}";
                response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                response.Data = null;
                return response;
            }
        }

        public async Task<BaseResponse>FindEmployee(string userEmail)
        {
            var response = new BaseResponse();
            try
            {
                var requesterDetails = await _employeeRepository.FindEmployee(userEmail);
                if (requesterDetails == null)
                {
                    response.ResponseMessage = "Employee details cannot be found. Not a valid Employee";
                    response.ResponseCode = ResponseCode.NotFound.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }
                if (requesterDetails != null)
                {
                    response.ResponseMessage = "User details found";
                    response.ResponseCode = ResponseCode.Ok.ToString("D").PadLeft(2, '0');
                    response.Data = requesterDetails;
                    return response;

                }
                else
                {
                    response.ResponseMessage = "An error occured while searching for employee";
                    response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;

                }
            }
            catch (Exception ex)
            {
                response.ResponseMessage = $"An exception occured while Searching employee ==> Message: {ex.Message}";
                response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                response.Data = null;
                return response;
            }
        }

        public async Task<BaseResponse> FindEmployee(int userId)
        {
            var response = new BaseResponse();

            try
            {
                var requesterDetails = await _employeeRepository.FindEmployee(userId);
                if (requesterDetails == null)
                {
                    response.ResponseMessage = "Employee details cannot be found. Not a valid Employee";
                    response.ResponseCode = ResponseCode.NotFound.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }
                if (requesterDetails != null)
                {
                    response.ResponseMessage = "Employee details found";
                    response.ResponseCode = ResponseCode.Ok.ToString("D").PadLeft(2, '0');
                    response.Data = requesterDetails;
                    return response;

                }
                else
                {
                    response.ResponseMessage = "An error occured while searching for employee";
                    response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;

                }
            }
            catch (Exception ex)
            {
                response.ResponseMessage = $"An exception occured while Searching employee ==> Message: {ex.Message}";
                response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                response.Data = null;
                return response;
            }
        }

        public async Task<BaseResponse> GetAllActiveEmployee()
        {
            var response = new BaseResponse();
            try
            {
                var infos = await _employeeRepository.GetAllActiveEmployee();
                response.ResponseMessage = "Employee details found";
                response.ResponseCode = ResponseCode.Ok.ToString("D").PadLeft(2, '0');
                response.Data = infos;
                return response;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = $"An exception occured while trying to get all Active Employee ==> Message: {ex.Message}";
                response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                response.Data = null;
                return response;
            }
        }

        public async Task<BaseResponse> GetAllEmployee()
        {
            var response = new BaseResponse();
            try
            {
                var infos = await  _employeeRepository.GetAllEmployee();
                response.ResponseMessage = "Employee details found";
                response.ResponseCode = ResponseCode.Ok.ToString("D").PadLeft(2, '0');
                response.Data = infos;
                return response;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = $"An exception occured while trying to get all Employee ==> Message: {ex.Message}";
                response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0')   ;
                response.Data = null;
                return response;
            }
        }

    }
}
