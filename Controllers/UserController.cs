﻿using Dapper;
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
using FluentValidation;

namespace StaffApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidationService _validationService;
       
        public UserController(IUserService userService, IValidationService validationService)
        {
            _userService = userService;
            _validationService = validationService;
        }

        [Authorize]
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUser request)
        {
           

            var email = User.FindFirstValue(ClaimTypes.Email);
            var validationResponse = await _validationService.ValidateAsync(request);
            if (validationResponse.ResponseCode == ResponseCode.ValidationError.ToString("D").PadLeft(2, '0'))
            {
               
                return Ok(validationResponse);
            }
            return Ok(await _userService.CreateUser(request, email));
                     
        }

        [Authorize]
        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUser request)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var validationResponse = await _validationService.ValidateAsync(request);
            if (validationResponse.ResponseCode == ResponseCode.ValidationError.ToString("D").PadLeft(2, '0'))
            {

                return Ok(validationResponse);
            }

            return Ok(await _userService.UpdateUser(request,email));
        }

        [HttpPost("LoginUser")]
       public async Task<IActionResult> LoginUser(EmailandPassword info)

        {
            
            var validationResponse = await _validationService.ValidateAsync(info);
            if (validationResponse.ResponseCode == ResponseCode.ValidationError.ToString("D").PadLeft(2, '0'))
            {

                return Ok(validationResponse);
            }

            return Ok(await _userService.LogInUser(info));
        }

        [Authorize]
        [HttpPost("LogOutUser")]
        public async Task<IActionResult> LogOutUser(EmailandPassword info)
        {
            
            var validationResponse = await _validationService.ValidateAsync(info);
            if (validationResponse.ResponseCode == ResponseCode.ValidationError.ToString("D").PadLeft(2, '0'))
            {

                return Ok(validationResponse);
            }


            return Ok(await _userService.LogOutUser(info));
        }

        [Authorize]
        [HttpPost("DeActivateUser")]
        public async Task<IActionResult> DeActivate(DeactivateUser info)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var validationResponse = await _validationService.ValidateAsync(info);
            if (validationResponse.ResponseCode == ResponseCode.ValidationError.ToString("D").PadLeft(2, '0'))
            {

                return Ok(validationResponse);
            }


            return Ok(await _userService.DeactivateUser(info,email));
        }

        [Authorize]
        [HttpPost("ReActivateUser")]
        public async Task<IActionResult> ReActivate(ReactivateUser info)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var validationResponse = await _validationService.ValidateAsync(info);
            if (validationResponse.ResponseCode == ResponseCode.ValidationError.ToString("D").PadLeft(2, '0'))
            {

                return Ok(validationResponse);
            }


            return Ok(await _userService.ReactivateUser(info,email));
        }

        [Authorize]
        [HttpGet("FindUserbyEmail")]

        public async Task<IActionResult> FindUserbyEmail([FromQuery]  string userEmail)
        {
            
            var validationResponse = await _validationService.ValidateAsync(userEmail);
            if (validationResponse.ResponseCode == ResponseCode.ValidationError.ToString("D").PadLeft(2, '0'))
            {

                return Ok(validationResponse);
            }
            return Ok(await _userService.FindUser(userEmail));
            /*var validator= new EmailValidator();
            var validateResult = await validator.ValidateAsync(new EmailInput { Email = userEmail });
             return Ok(await _userService.FindUser(userEmail));*/
        }

        [Authorize]
        [HttpGet("FindUserbyId")]

        public async Task<IActionResult> FindUserbyId([FromQuery] int userId)
        {
            
            var validationResponse = await _validationService.ValidateAsync(userId);
            if (validationResponse.ResponseCode == ResponseCode.ValidationError.ToString("D").PadLeft(2, '0'))
            {

                return Ok(validationResponse);
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
