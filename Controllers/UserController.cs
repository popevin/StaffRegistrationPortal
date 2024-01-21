using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using StaffApplication.Repositories;
using StaffApplication.Services;
using StaffApplication.DTOs;
using StaffRegistrationPortal.Services;
using StaffRegistrationPortal.Common;
using StaffRegistrationPortal.Validatiors;
using StaffRegistrationPortal.Enums;

namespace StaffApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUser request)
        {
            var response = new BaseResponse();

            var validator = new CreateUserValidator();
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

                //_logger.LogError($"Validation Error ==> {validationMessage}");

                //response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                response.ResponseCode = ResponseCode.ValidationError.ToString("D").PadLeft(2, '0'); 
                response.ResponseMessage = $"{validationMessage}";
                response.Data = null;
                return Ok(response);
            }

            return Ok(await _userService.CreateUser(request));
        }
        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUser request)
        {
            var response = new BaseResponse();

            var validator = new UpdateUserValidator();
            var validateResult= await validator.ValidateAsync(request);
            string? validationMessage = string.Empty;

            if (validateResult.Errors.Count > 0) 
            { 
                var errors= new List<string>();
                validateResult.Errors.ForEach(x =>
                {
                    errors.Add(x.ErrorMessage);

                });
                validationMessage = Utils.ErrorBuilder(errors);

                response.ResponseCode = response.ResponseCode = ResponseCode.ValidationError.ToString("D").PadLeft(2, '0');
                response.ResponseMessage = $"{validationMessage}";
                response.Data = null;
                return Ok(response);
            
            }

            return Ok(await _userService.UpdateUser(request));
        }

        [HttpPost("LoginUser")]
       public async Task<IActionResult> LoginUser(EmailandPassword info)

        {
            var response= new BaseResponse();
            var validator = new EmailandPasswordValidator();
            var validateResult = await validator.ValidateAsync(info);
            string? validationMessage = string.Empty;

            if(validateResult.Errors.Count > 0)
            {
                var errors=new List<string>();
                validateResult.Errors.ForEach(x =>
                {
                    errors.Add(x.ErrorMessage);
                });
                validationMessage = Utils.ErrorBuilder(errors);

                response.ResponseCode = response.ResponseCode = ResponseCode.ValidationError.ToString("D").PadLeft(2, '0');
                response.ResponseMessage = $"{validationMessage}";
                response.Data = null;
                return Ok(response);
            }


            return Ok(await _userService.LogInUser(info));
        }

        [HttpPost("LogOutUser")]
        public async Task<IActionResult> LogOutUser(EmailandPassword info)

        {
            var response = new BaseResponse();
            var validator = new EmailandPasswordValidator();
            var validateResult = await validator.ValidateAsync(info);
            string? validationMessage = string.Empty;

            if (validateResult.Errors.Count > 0)
            {
                var errors = new List<string>();
                validateResult.Errors.ForEach(x =>
                {
                    errors.Add(x.ErrorMessage);
                });
                validationMessage = Utils.ErrorBuilder(errors);

                response.ResponseCode = response.ResponseCode = ResponseCode.ValidationError.ToString("D").PadLeft(2, '0');
                response.ResponseMessage = $"{validationMessage}";
                response.Data = null;
                return Ok(response);
            }


            return Ok(await _userService.LogOutUser(info));
        }


        [HttpPost("DeActivateUser")]
        public async Task<IActionResult> DeActivate(DeactivateUser info)
        {
            var response= new BaseResponse();
            var validator= new DeactivatorValidator();
            var validateResult= await validator.ValidateAsync(info);
            string? validationMessage = string.Empty;

            if(validateResult.Errors.Count > 0) 
            {
                var errors=new List<string>();
                validateResult.Errors.ForEach(x =>
                {
                    errors.Add(x.ErrorMessage);

                });
                validationMessage = Utils.ErrorBuilder(errors);
                response.ResponseCode = response.ResponseCode = ResponseCode.ValidationError.ToString("D").PadLeft(2, '0');
                response.ResponseMessage = $"{validationMessage}";
                response.Data = null;
                return Ok(response);

            }

            return Ok(await _userService.DeactivateUser(info));
        }

        [HttpPost("ReActivateUser")]
        public async Task<IActionResult> ReActivate(ReactivateUser info)
        {
            var response = new BaseResponse();
            var validator = new ReactivatorValidator();
            var validateResult = await validator.ValidateAsync(info);
            string? validationMessage = string.Empty;

            if (validateResult.Errors.Count > 0)
            {
                var errors = new List<string>();
                validateResult.Errors.ForEach(x =>
                {
                    errors.Add(x.ErrorMessage);

                });
                validationMessage = Utils.ErrorBuilder(errors);
                response.ResponseCode = response.ResponseCode = ResponseCode.ValidationError.ToString("D").PadLeft(2, '0');
                response.ResponseMessage = $"{validationMessage}";
                response.Data = null;
                return Ok(response);

            }

            return Ok(await _userService.ReactivateUser(info));
        }


        [HttpGet("FindUserbyEmail")]

        public async Task<IActionResult> FindUserbyEmail([FromQuery]  string userEmail)
        {
            var response = new BaseResponse();
            if (string.IsNullOrEmpty(userEmail))
            {
                response.ResponseCode = response.ResponseCode = ResponseCode.ValidationError.ToString("D").PadLeft(2, '0');
                response.ResponseMessage = "userEmail field is required";
                response.Data = null;

                return Ok(response);

            }
            return Ok(await _userService.FindUser(userEmail));
            /*var validator= new EmailValidator();
            var validateResult = await validator.ValidateAsync(new EmailInput { Email = userEmail });
             return Ok(await _userService.FindUser(userEmail));*/
        }

        [HttpGet("FindUserbyId")]

        public async Task<IActionResult> FindUserbyId([FromQuery] long userId)
        {
            var response = new BaseResponse();
            if (userId <= 0)
            {
                response.ResponseCode = response.ResponseCode = ResponseCode.ValidationError.ToString("D").PadLeft(2, '0');
                response.ResponseMessage = "UserId is required ";
                response.Data = null;
                return Ok(response);
            }

            var info = await _userService.FindUser(userId);
            return Ok(info);
            /*var validator = new IdValidator();
            var validateResult = await validator.ValidateAsync(new InputId { Id = UserId });
            return Ok(await _userService.FindUser(UserId));*/

        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("GetAllActiveUsers")]
        public async Task<IActionResult> GetActiveUsers()
        {
            return Ok(await _userService.GetAllActiveUsers());
        }







    }
}
