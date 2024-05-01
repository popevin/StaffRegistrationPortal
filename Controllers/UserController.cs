using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
using StaffApplication.Repositories;
using StaffApplication.Services;
using StaffRegistrationPortal.Services;
using StaffRegistrationPortal.Common;
using StaffRegistrationPortal.Validatiors;
using StaffRegistrationPortal.Enums;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using StaffRegistrationPortal.DTOs;

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

        [Authorize]
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUser request)
        {
            var response = new BaseResponse();

            //var email = "read email valur from claim";
            var email = User.FindFirstValue(ClaimTypes.Email);

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
            return Ok(await _userService.CreateUser(request, email));
                     
        }

        [Authorize]
        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUser request)
        {
            var response = new BaseResponse();
            var email = User.FindFirstValue(ClaimTypes.Email);
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

            return Ok(await _userService.UpdateUser(request,email));
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

            var LogInResponse = await _userService.LogInUser(info);
           
            return Ok(LogInResponse);
        }

        [Authorize]
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

        [Authorize]
        [HttpPost("DeActivateUser")]
        public async Task<IActionResult> DeActivate(DeactivateUser info)
        {
            var response= new BaseResponse();
            var email = User.FindFirstValue(ClaimTypes.Email);
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

            return Ok(await _userService.DeactivateUser(info,email));
        }

        [Authorize]
        [HttpPost("ReActivateUser")]
        public async Task<IActionResult> ReActivate(ReactivateUser info)
        {
            var response = new BaseResponse();
            var email = User.FindFirstValue(ClaimTypes.Email);
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

            return Ok(await _userService.ReactivateUser(info,email));
        }

        [Authorize]
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

        [Authorize]
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

            return Ok(await _userService.FindUser(userId));

        }

        [Authorize]
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetUser()
        {

            return Ok(await _userService.GetAllUsers());
        }


        [Authorize]
        [HttpGet("GetAllActiveUsers"),]
        public async Task<IActionResult> GetActiveUsers()
        {
            return Ok(await _userService.GetAllActiveUsers());
        }



      


    }
}
