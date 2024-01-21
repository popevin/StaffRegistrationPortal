using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using StaffApplication.Repositories;
using StaffApplication.Services;
using StaffApplication.DTOs;
using StaffRegistrationPortal.Services;
using StaffRegistrationPortal.Common;
using StaffRegistrationPortal.Validatiors;
using FluentValidation;

namespace StaffApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("CreateEmployeeDetails")]

        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployee request)
        {
            var response = new BaseResponse();
            var validator = new CreateEmployeeValidator();
            var validateResult = await validator.ValidateAsync(request);
            string? validationMessage = string.Empty;

            if (validateResult.Errors.Count > 0)
            {
                var errors = new List<string>();
                validateResult.Errors.ForEach(x =>
                {
                    errors.Add(x.ErrorMessage);
                });
                validationMessage = Utils.ErrorBuilder(errors);
                response.ResponseCode = "401";
                response.ResponseMessage = $"{validationMessage}";
                response.Data = null;
                return Ok(response);
            }
            return Ok(await _employeeService.CreateEmployee(request));

        }

        [HttpPut("UpdateEmployeeDetails")]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployee request)
        {
            var response = new BaseResponse();
            var validator = new UpdateEmployeeValidator();
            var validateResult = await validator.ValidateAsync(request);
            string? validationMessage = string.Empty;

            if (validateResult.Errors.Count > 0)
            {
                var errors = new List<string>();
                validateResult.Errors.ForEach(x =>
                {
                    errors.Add(x.ErrorMessage);
                });
                validationMessage = Utils.ErrorBuilder(errors);
                response.ResponseCode = "401";
                response.ResponseMessage = $"{validationMessage}";
                response.Data = null;
                return Ok(response);
            }
            return Ok(await _employeeService.UpdateEmployee(request));
        }

        [HttpDelete("DeleteEmployeeDetails")]
        public async Task<IActionResult> DeleteEmployee(DeleteEmployee request)
        {

            var response = new BaseResponse();
            var validator = new DeleteEmployeeValidator();
            var validateResult = await validator.ValidateAsync(request);
            string? validationMessage = string.Empty;

            if (validateResult.Errors.Count > 0)
            {
                var errors = new List<string>();
                validateResult.Errors.ForEach(x =>
                {
                    errors.Add(x.ErrorMessage);
                });
                validationMessage = Utils.ErrorBuilder(errors);
                response.ResponseCode = "401";
                response.ResponseMessage = $"{validationMessage}";
                response.Data = null;
                return Ok(response);
            }
            return Ok(await _employeeService.DeleteEmployee(request));
        }


        [HttpGet("FindEmployeebyEmail")]

        public async Task<IActionResult> FindEmployeebyEmail([FromQuery] string Email)
        {
            var response=new BaseResponse();
            if (string.IsNullOrEmpty(Email))
            {
                response.ResponseCode = "401";
                response.ResponseMessage = "Email field is required";
                response.Data = null;
                return Ok(response);

            }
            return Ok(await _employeeService.FindEmployee(Email));
        }


        [HttpGet("FindEmployeebyId")]
        public async Task<IActionResult> FindEmployee([FromQuery] int userId)
        {
            var response=new BaseResponse();
            if (userId <= 0)
            {
                response.ResponseCode = "401";
                response.ResponseMessage = "UserId is required ";
                response.Data = null;
                return Ok(response);
            }

            var info = await _employeeService.FindEmployee(userId);
            return Ok(info);
        }

        [HttpGet("GetAllActiveEmployee")]
        public async Task<IActionResult> GetAllActiveEmployee()
        {
            return Ok(await _employeeService.GetAllActiveEmployee());
        }

        [HttpGet("GetAllEmployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            return Ok(await _employeeService.GetAllEmployee());
        }


    }
}







