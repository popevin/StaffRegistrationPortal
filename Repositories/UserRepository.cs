using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using StaffApplication.Repositories;
using StaffApplication.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IIS.Core;
using StaffRegistrationPortal.DTOs;
using System.Data;
using System.Security.Principal;
using StaffRegistrationPortal.Enums;

namespace StaffApplication.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;
        private readonly ILogger<UserRepository> _logger;
        private readonly string? _connectionString;
        private readonly string? _sqlprocedure = "Sp_Auth";

        public UserRepository(IConfiguration config, ILogger<UserRepository> logger)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("DefaultConnection");
            _logger = logger;
        }

        public async Task<dynamic> CreateUser(CreateUser user, string createdBy)
        {
            try
            {
                using (SqlConnection _dapper = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Status", UserStatusGuides.CreateUser);
                    param.Add("@RoleId", user.RoleId);
                    param.Add("@GenderId", user.GenderId);
                    param.Add("@DepartmentId", user.DepartmentId);
                    param.Add("@Email", user.Email);
                    param.Add("@Password", user.Password);
                    param.Add("@FirstName", user.FirstName);
                    param.Add("@LastName", user.LastName);
                    param.Add("@OtherName", user.OtherName);
                    param.Add("@Address", user.Address);
                    param.Add("@Phone", user.Phone);
                    param.Add("@Created_By_User_Email", createdBy);

                    dynamic resp = await _dapper.ExecuteAsync(_sqlprocedure, param: param, commandType: CommandType.StoredProcedure);

                    return resp;
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                _logger.LogError($"Exception Occured: MethodName: CreateUser(CreateUser user) ===>{ex.Message}");
                throw;
            }
        }

        public async Task<dynamic> UpdateUser(UpdateUser user, string updatedBy)
        {
            try
            {
                using (SqlConnection _dapper = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Status", UserStatusGuides.UpdateUser);
                    param.Add("@UserIdUpd", user.UserId);
                    param.Add("@RoleIdUpd", user.RoleId);
                    param.Add("@GenderIdUpd", user.GenderId);
                    param.Add("@DepartmentIdUpd", user.DepartmentId);
                    param.Add("@EmailUpd", user.Email);
                    param.Add("@PasswordUpd", user.Password);
                    param.Add("@FirstnameUpd", user.FirstName);
                    param.Add("@LastnameUpd", user.LastName);
                    param.Add("@OthernameUpd", user.OtherName);
                    param.Add("@AddressUpd", user.Address);
                    param.Add("@PhoneUpd", user.Phone);
                    param.Add("@Updated_By_User_Email", updatedBy);

                    dynamic resp = await _dapper.ExecuteAsync(_sqlprocedure, param: param, commandType: CommandType.StoredProcedure);

                    return resp;
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                _logger.LogError($"Exception Occured: MethodName: UpdateUser(UpdateUser user) ===>{ex.Message}");
                throw;
            }

        }


        public async Task<int> DeActivateUser(DeactivateUser user, string deactivatedBy)
        {
            try
            {
                using (SqlConnection _dapper = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Status", UserStatusGuides.DeactivateUser);
                    param.Add("@UserIdDeActivate", user.Id);
                    param.Add("@Deactivated_By_User_Email", deactivatedBy);


                    dynamic resp = await _dapper.ExecuteAsync(_sqlprocedure, param: param, commandType: CommandType.StoredProcedure);

                    return resp;
                }
            }
           
      
            catch (Exception ex)
            {
                var err = ex.Message;
        _logger.LogError($"MethodName: DeactivateUser(Deactivate user) ===>{ex.Message}");
                throw;
            }
        }
    

        public async Task<int> ReActivateUser(ReactivateUser user, string reactivatedBy)
        {
            try
            {
                using (SqlConnection _dapper = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Status", UserStatusGuides.ReactivateUser);
                    param.Add("@UserIdReActivate", user.Id);
                    param.Add("@Reactivated_By_User_Email", reactivatedBy);



                    dynamic resp = await _dapper.ExecuteAsync(_sqlprocedure, param: param, commandType: CommandType.StoredProcedure);

                    return resp;
                }
            }


            catch (Exception ex)
            {
                var err = ex.Message;
                _logger.LogError($"MethodName: ReactivateUser(Reactivate user)===>{ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<User>>GetAllActiveUsers()
        {
            try
            {
                using (SqlConnection _dapper = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Status", UserStatusGuides.GetAllActiveUsers);

                    var users = await _dapper.QueryAsync<User>(_sqlprocedure, param: param, commandType: CommandType.StoredProcedure);

                    return users;
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                _logger.LogError($"MethodName: GetAllActiveUsers() ===>{ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                using (SqlConnection _dapper = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Status", UserStatusGuides.GetAllUsers);

                    var users = await _dapper.QueryAsync<User>(_sqlprocedure, param: param, commandType: CommandType.StoredProcedure);

                    return users;
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                _logger.LogError($"MethodName: GetAllUsers() ===>{ex.Message}");
                throw;
            }
        }

        public async Task<User> FindUser(int userId)
        {
            try
            {
                using (SqlConnection _dapper = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Status", UserStatusGuides.FindUserById);
                    param.Add("@UserIdGet", userId);

                    var userDetails = await _dapper.QueryFirstOrDefaultAsync<User>(_sqlprocedure, param: param, commandType: CommandType.StoredProcedure);

                    return userDetails;
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                _logger.LogError($"MethodName: FindUser(Long UserId) ===>{ex.Message}");
                throw;
            }
        }
        public async Task<User> FindUser(string? email)
        {
            try
            {
                using (SqlConnection _dapper = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Status", UserStatusGuides.FindUserByEmail);
                    param.Add("@UserEmailGet", email);

                    var userDetails = await _dapper.QueryFirstOrDefaultAsync<User>(_sqlprocedure, param: param, commandType: CommandType.StoredProcedure);

                    return userDetails;
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                _logger.LogError($"MethodName: FindUser(string email) ===>{ex.Message}");
                throw;
            }
        }

       


      

        public async Task<int> LogInUser(EmailandPassword user)
        {
            try
            {
                using (SqlConnection _dapper = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Status", UserStatusGuides.LogInUser);
                    param.Add("@UserEmailLogIn", user.Email);
                    param.Add("@UserPasswordLogIn", user.Password);

                    dynamic resp = await _dapper.ExecuteAsync(_sqlprocedure, param: param, commandType: CommandType.StoredProcedure);

                    return resp;
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                _logger.LogError($"MethodName: LogInUser(EmailandPassword user) ===>{ex.Message}");
                throw;
            }

        }
        public async Task<int> LogOutUser(EmailandPassword user)
        {
            try
            {
                using (SqlConnection _dapper = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Status", UserStatusGuides.LogOutUser);
                    param.Add("@UserEmailLogOut", user.Email);
                    param.Add("@UserPasswordLogOut", user.Password);

                    dynamic resp = await _dapper.ExecuteAsync(_sqlprocedure, param: param, commandType: CommandType.StoredProcedure);

                    return resp;
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                _logger.LogError($"MethodName: LogOutUser(EmailandPassword user) ===>{ex.Message}");
                throw;
            }


        }

       
        //public async Task<User> FindUser(string userEmail)
        //{
        //    place this bukk of code in a try-catch
        //    using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        //    try
        //    {

        //        var infos = await connection.QueryFirstOrDefaultAsync<User>("SELECT * FROM Users WHERE Email=@UserEmail  ", new { UserEmail = userEmail });
        //        return infos;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Error while trying to Find User {ex.Message}");
        //    }
        //}

       
      /*  public async Task<List<User>> GetAllUsers()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            try
            {
                //IEnumerable<User> infos = await SelectAllinfos(connection);

                var infos = await SelectAllinfos(connection);

                return infos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error or User not found {ex.Message}");
            }

        }*/

      /*  private static async Task<IEnumerable<User>> SelectAllinfos(SqlConnection connection)
        {
            return await connection.QueryAsync<User>("select * from Users");
        }*/

        /*       {
         "roleId":2,
         "genderId": 1,
         "departmentId": 4,
         "email": "Zainab@gmail.com",
         "password": "dgg123",
         "firstName": "Zainab",
         "lastName": "Ismail",
         "otherName": "bola",
         "address": "66,dare street lagos",
         "phone": "5262542662",
         "createdBy": "john@gmail.com"
       }*/

    }

/*{
  "id": 5,
  "roleId": 2,
  "genderId": 1,
  "departmentId": 4,
  "email": "Ayo@gmail.com",
  "password": "123",
  "firstName": "Ayo",
  "lastName": "ola",
  "otherName": "Temi",
  "address": "663 way lagos ",
  "phone": "6535388",
  "isActive": true,
  "isUpdated": true,
  "updatedBy": "john@gmail.com"
}
*/
}
