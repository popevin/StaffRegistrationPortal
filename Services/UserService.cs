using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StaffApplication.DTOs;
using StaffApplication.Repositories;
using StaffRegistrationPortal.Common;
using StaffRegistrationPortal.Enums;
using StaffRegistrationPortal.Services;
using System.Data;
using System.Collections.Generic;

namespace StaffApplication.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, ILogger<UserService> logger,IMapper mapper)
        {
            _userRepository = userRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BaseResponse>CreateUser(CreateUser info)
        {
            var response = new BaseResponse();
            try
            {
                var requesterDetails = await _userRepository.FindUser(info.CreatedBy);

                if (requesterDetails == null)
                {
                    _logger.LogInformation("No Existing Authorizer for this action");

                    response.ResponseMessage = "No Existing Authorizer for this action";
                    response.ResponseCode = ResponseCode.AuthorizationError.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }
                if (requesterDetails.RoleId != 1)
                {
                    response.ResponseMessage = "Your role is not authorized to carry out this action";
                    response.ResponseCode = ResponseCode.AuthorizationError.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }

                var checkmail = await _userRepository.FindUser(info.Email);
                if (checkmail != null)
                {
                    response.ResponseMessage = "User already exist";
                    response.ResponseCode = ResponseCode.DuplicateError.ToString("D").PadLeft(2, '0'); 
                    response.Data = null;
                    return response;
                }

                var resp = await _userRepository.CreateUser(info);
                if (resp > 0)
                {
                    var user = await _userRepository.FindUser(info.Email);

                    response.ResponseMessage = "User Created Successfully";
                    response.ResponseCode = ResponseCode.Ok.ToString("D").PadLeft(2, '0');
                    var userView = _mapper.Map<List<UserViewModel>>(user);
                    response.Data = userView;
                    return response;
                }
                else
                {
                    _logger.LogError($"An error occured while creating user with mail {info.Email}. Please contact admin");

                    response.ResponseMessage = "An error occured while creating user. Please contact admin";
                    response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.ResponseMessage = $"An exception occured while Creating user ==> Message: {ex.Message}";
                response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                response.Data = null;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateUser(UpdateUser info)
        {
            var response = new BaseResponse();
            try
            {
                var requesterDetails = await _userRepository.FindUser(info.UpdatedBy);
                if (requesterDetails == null)
                {
                    response.ResponseMessage = "No Existing AuthoriZer for this action";
                    response.ResponseCode = ResponseCode.AuthorizationError.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }
                if (requesterDetails.RoleId != 1)
                {
                    response.ResponseMessage = "Your role is not authorized to carry out this action";
                    response.ResponseCode = ResponseCode.AuthorizationError.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }

              

                var resp = await _userRepository.UpdateUser(info);
                if (resp > 0)
                {
                    var user = await _userRepository.FindUser(info.Email);

                    response.ResponseMessage = "User Updated Successfully";
                    response.ResponseCode = ResponseCode.Ok.ToString("D").PadLeft(2, '0');
                    var userView = _mapper.Map<List<UserViewModel>>(user);
                    response.Data = userView;
                    return response;
                }
                else
                {
                    response.ResponseMessage = "An error occured while Updating user. Please contact admin";
                    response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }



            }
            catch (Exception ex)
            {
                response.ResponseMessage = $"An exception occured while Updating user ==> Message: {ex.Message}";
                response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                response.Data = null;
                return response;
            }
        }

        public async Task<BaseResponse> LogInUser(EmailandPassword info)
        {
            var response = new BaseResponse();

            try
            {
                var requesterDetails = await _userRepository.FindUser(info.Email);
                if (requesterDetails == null)
                {
                    response.ResponseMessage = "User details cannot be found. Not a valid User";
                    response.ResponseCode = ResponseCode.NotFound.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }
                if (requesterDetails.IsDeactivated == true)
                {
                    response.ResponseMessage = "User cannot access Login, user is deactivated";
                    response.ResponseCode = ResponseCode.NotFound.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }

                var resp = await _userRepository.LogInUser(info);
                if (resp > 0)
                {
                    
                    response.ResponseMessage= "User Logged in  Successfully";
                    response.ResponseCode = ResponseCode.Ok.ToString("D").PadLeft(2, '0');
                    var LogView = _mapper.Map<List<LogViewModel>>(requesterDetails);
                    response.Data = LogView;
                    return response;
                }
                else
                {
                    response.ResponseMessage = "An error occured while Logging In user. Please contact admin";
                    response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;

                }

            }
            catch (Exception ex)
            {
                response.ResponseMessage = $"An exception occured while Logging in user ==> Message: {ex.Message}";
                response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                response.Data = null;
                return response;
            }



        }

        public async Task<BaseResponse> LogOutUser(EmailandPassword info)
        {
            var response = new BaseResponse();

            try
            {
                var requesterDetails = await _userRepository.FindUser(info.Email);
                if (requesterDetails == null)
                {
                    response.ResponseMessage = "User details cannot be found. Not a valid User";
                    response.ResponseCode = ResponseCode.NotFound.ToString("D").PadLeft(2, '0'); ;
                    response.Data = null;
                    return response;
                }
                if (requesterDetails.IsDeactivated == true)
                {
                    response.ResponseMessage = "User cannot access Logout option, user is deactivated";
                    response.ResponseCode = ResponseCode.NotFound.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }

                var resp = await _userRepository.LogOutUser(info);
                if (resp > 0)
                {
                    response.ResponseMessage = "User Logged out   Successfully";
                    response.ResponseCode = ResponseCode.Ok.ToString("D").PadLeft(2, '0');
                    var LogView = _mapper.Map<List<LogViewModel>>(requesterDetails);
                    response.Data = LogView;
                    return response;
                }
                else
                {
                    response.ResponseMessage = "An error occured while Logging Out user. Please contact admin";
                    response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;

                }

            }
            catch (Exception ex)
            {
                response.ResponseMessage = $"An exception occured while Logging Out user ==> Message: {ex.Message}";
                response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                response.Data = null;
                return response;
            }



        }

        public async Task<BaseResponse> DeactivateUser(DeactivateUser info)
        {
            var response = new BaseResponse();

            try
            {
                var requesterDetails = await _userRepository.FindUser(info.DeactivatedBy);
                if (requesterDetails == null)
                {
                    response.ResponseMessage = "Authoriser details cannot be found. Not a valid User";
                    response.ResponseCode = ResponseCode.NotFound.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;

                }

                if (requesterDetails.RoleId != 1)
                {
                    response.ResponseMessage = "Your role is not authorized to carry out this action";
                    response.ResponseCode = ResponseCode.AuthorizationError.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }

                var checkmail = await _userRepository.FindUser(info.DeactivateEmail);
                if (checkmail == null)
                {
                    response.ResponseMessage = "This User Doesn't exist and Deactivate User action cannot be performed";
                    response.ResponseCode = ResponseCode.NotFound.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }

                var resp = await _userRepository.DeActivateUser(info);
                if (resp > 0)
                {
                    var user = await _userRepository.FindUser(info.DeactivateEmail);
                    response.ResponseMessage = "User Deactivated  Successfully";
                    response.ResponseCode = ResponseCode.Ok.ToString("D").PadLeft(2, '0');
                    var DeactivateView = _mapper.Map<List<DeactivateViewModel>>(requesterDetails);
                    response.Data = DeactivateView;
                    return response;

                }

                else
                {
                    response.ResponseMessage = "An error occured while Deactivating user. Please contact admin";
                    response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;

                }

            }
            catch (Exception ex)
            {
                response.ResponseMessage = $"An exception occured while Deactivating user ==> Message: {ex.Message}";
                response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                response.Data = null;
                return response;
            }

        }

        public async Task<BaseResponse> ReactivateUser(ReactivateUser info)
        {
            var response = new BaseResponse();

            try
            {
                var requesterDetails = await _userRepository.FindUser(info.ReactivatedBy);
                if (requesterDetails == null)
                {
                    response.ResponseMessage = "User details cannot be found. Not a valid User";
                    response.ResponseCode = ResponseCode.NotFound.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;

                }

                if (requesterDetails.RoleId != 1)
                {
                    response.ResponseMessage = "Your role is not authorized to carry out this action";
                    response.ResponseCode = ResponseCode.AuthorizationError.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }
               

                var checkmail = await _userRepository.FindUser(info.ReactivateEmail);
                if (checkmail == null)
                {
                    response.ResponseMessage = "This User Doesn't exist and Reactivate User action cannot be performed";
                    response.ResponseCode = ResponseCode.NotFound.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }

                var resp = await _userRepository.ReActivateUser(info);
                if (resp > 0)
                {
                    var user = await _userRepository.FindUser(info.ReactivateEmail);
                    response.ResponseMessage = "User Reactivated  Successfully";
                    response.ResponseCode = ResponseCode.Ok.ToString("D").PadLeft(2, '0');
                    var ReactivateView = _mapper.Map<List<ReactivateViewModel>>(requesterDetails);
                    response.Data = ReactivateView;
                    return response;

                }

                else
                {
                    response.ResponseMessage = "An error occured while Reactivating user. Please contact admin";
                    response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;

                }

            }
            catch (Exception ex)
            {
                response.ResponseMessage = $"An exception occured while Reactivating user ==> Message: {ex.Message}";
                response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                response.Data = null;
                return response;
            }

        }

        public async Task<BaseResponse> FindUser(string? userEmail)
        {
            var response = new BaseResponse();

            try
            {
                var requesterDetails = await _userRepository.FindUser(userEmail);
                if (requesterDetails == null)
                {
                    response.ResponseMessage = "User details cannot be found. Not a valid User";
                    response.ResponseCode = ResponseCode.NotFound.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }
                if (requesterDetails != null)
                {
                    response.ResponseMessage = "User details found";
                    response.ResponseCode = ResponseCode.Ok.ToString("D").PadLeft(2, '0');
                    var userView = _mapper.Map<List<UserViewModel>>(requesterDetails);
                    response.Data = userView;

                    return response;

                }
                else
                {
                    response.ResponseMessage = "An error occured while searching user";
                    response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;

                }
            }
            catch (Exception ex)
            {
                response.ResponseMessage = $"An exception occured while Searching user ==> Message: {ex.Message}";
                response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                response.Data = null;
                return response;
            }
        }
        public async Task<BaseResponse> FindUser(long userId)
        {
            var response = new BaseResponse();

            try
            {
                var requesterDetails = await _userRepository.FindUser(userId);
                if (requesterDetails == null)
                {
                    response.ResponseMessage = "User details cannot be found. Not a valid User";
                    response.ResponseCode = ResponseCode.NotFound.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;
                }
                if (requesterDetails != null)
                {
                    response.ResponseMessage = "User details found";
                    response.ResponseCode = ResponseCode.Ok.ToString("D").PadLeft(2, '0');
                    var userView = _mapper.Map<List<UserViewModel>>(requesterDetails);
                    response.Data = userView;

                    return response;

                }
                else
                {
                    response.ResponseMessage = "An error occured while searching user";
                    response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                    response.Data = null;
                    return response;

                }
            }
            catch (Exception ex)
            {
                response.ResponseMessage = $"An exception occured while Searching user ==> Message: {ex.Message}";
                response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                response.Data = null;
                return response;
            }
        }

        public async Task<BaseResponse> GetAllUsers()
        {
            var response = new BaseResponse();
            try
            {
                var infos = await _userRepository.GetAllUsers();
                response.ResponseMessage = "User details found";
                response.ResponseCode = ResponseCode.Ok.ToString("D").PadLeft(2, '0');
                var userView = _mapper.Map<List<UserViewModel>>(infos);
                response.Data= userView;
                return response;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = $"An exception occured while trying to get all users ==> Message: {ex.Message}";
                response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0')   ;
                response.Data = null;
                return response;
            }
        }

        public async Task<BaseResponse> GetAllActiveUsers()
        {
            var response = new BaseResponse();
            try
            {
                var infos = await _userRepository.GetAllActiveUsers();
                response.ResponseMessage = "User details found";
                response.ResponseCode = ResponseCode.Ok.ToString("D").PadLeft(2, '0');
                var userView = _mapper.Map<List<UserViewModel>>(infos);
                response.Data = userView;

                return response;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = $"An exception occured while trying to get all Active users ==> Message: {ex.Message}";
                response.ResponseCode = ResponseCode.Exception.ToString("D").PadLeft(2, '0');
                response.Data = null;
                return response;
            }
        }
    }

    /*baseresponse.ResponseCode = resp.ResponseCode;
                    baseresponse.ResponseMessage = resp.ResponseMessage;
                    var xxx = resp.Data.ToString();
    List<User> userList = JsonConvert.DeserializeObject<List<User>>(xxx);
    baseresponse.Data = userList;
                    return baseresponse;*/
}
