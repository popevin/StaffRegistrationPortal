using Dapper;
using StaffRegistrationPortal.DTOs;
using StaffRegistrationPortal.Enums;
using System.Data;
using System.Data.SqlClient;


namespace StaffApplication.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _config;
        private readonly ILogger<EmployeeRepository> _logger;
        private readonly string? _connectionString;
        private readonly string? _sqlprocedure = "Sp_Employee";


        public EmployeeRepository(IConfiguration config, ILogger<EmployeeRepository> logger)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("DefaultConnection");
            _logger = logger;
        }


        public async Task<dynamic> CreateEmployee(CreateEmployee info, string createdBy)
        {
            try
            {
                using (SqlConnection _dapper = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Status", EmployeeStatusGuides.CreateEmployee);
                    param.Add("@UserId", info.UserId);
                    param.Add("@DobUploadPath", info.DobUploadPath);
                    param.Add("@CertificateUploadPath", info.CertificateUploadPath);
                    param.Add("@PassportUploadPath", info.PassportUploadPath);
                    param.Add("@EmploymentStatus", info.EmploymentStatus);
                    param.Add("@MaritalStatus", info.MaritalStatus);
                    param.Add("@WorkingExperience", info.WorkingExperience);
                    param.Add("@Height", info.Height);
                    param.Add("@Weight", info.Weight);
                    param.Add("@Disability", info.Disability);
                    param.Add("@MedicalRecordUploadPath", info.MedicalRecordUploadPath);
                    param.Add("@NationalIDcode", info.NationalIDcode);
                    param.Add("@Nationality", info.Nationality);
                    param.Add("@IdUploadPath", info.IdUploadPath);
                    param.Add("@Created_By_User_Email", createdBy);
                    

                    dynamic resp = await _dapper.ExecuteAsync(_sqlprocedure, param: param, commandType: CommandType.StoredProcedure);

                    return resp;
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                _logger.LogError($"Exception Occured: MethodName: CreateEmployee(CreateEmployee info) ===>{ex.Message}");
                throw;
            }
        }

        public async Task<dynamic> UpdateEmployee(UpdateEmployee info, string updatedBy)
        {
            try
            {
                using (SqlConnection _dapper = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Status", EmployeeStatusGuides.UpdateEmployee);
                    param.Add("@EmployeeIdUpd", info.Id);
                    param.Add("@UserIdUpd", info.UserId);
                    param.Add("@DobUploadPathUpd", info.DobUploadPath);
                    param.Add("@CertificateUploadPathUpd", info.CertificateUploadPath);
                    param.Add("@PassportUploadPathUpd", info.PassportUploadPath);
                    param.Add("@EmploymentStatusUpd", info.EmploymentStatus);
                    param.Add("@MaritalStatusUpd", info.MaritalStatus);
                    param.Add("@WorkingExperienceUpd", info.WorkingExperience);
                    param.Add("@HeightUpd", info.Height);
                    param.Add("@WeightUpd", info.Weight);
                    param.Add("@DisabilityUpd", info.Disability);
                    param.Add("@MedicalRecordUploadPathUpd", info.MedicalRecordUploadPath);
                    param.Add("@NationalIDcodeUpd", info.NationalIDcode);
                    param.Add("@NationalityUpd", info.Nationality);
                    param.Add("@IdUploadPathUpd", info.IdUploadPath);
                    param.Add("@Updated_By_User_Email", updatedBy);


                    dynamic resp = await _dapper.ExecuteAsync(_sqlprocedure, param: param, commandType: CommandType.StoredProcedure);

                    return resp;
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                _logger.LogError($"Exception Occured: MethodName: UpdateEmployee(UpdateEmployee info) ===>{ex.Message}");
                throw;
            }

        }

        public async Task<int> DeleteEmployee(DeleteEmployee info,string deletedBy)
        {
            try
            {
                using (SqlConnection _dapper = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Status", EmployeeStatusGuides.DeleteEmployee);
                    param.Add("@Deleted_By_User_Email", info.Id);
                    param.Add("@Deactivated_By_User_Email", deletedBy);


                    dynamic resp = await _dapper.ExecuteAsync(_sqlprocedure, param: param, commandType: CommandType.StoredProcedure);

                    return resp;
                }
            }


            catch (Exception ex)
            {
                var err = ex.Message;
                _logger.LogError($"MethodName: DeleteEmployee(DeleteEmployee info)\r\n  ===>{ex.Message}");
                throw;
            }
        }

        public async Task<Employee> FindEmployee(int userId)
        {
            try
            {
                using (SqlConnection _dapper = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Status", EmployeeStatusGuides.FindEmployeeById);
                    param.Add("@UserIdGet", userId);

                    var userDetails = await _dapper.QueryFirstOrDefaultAsync<Employee>(_sqlprocedure, param: param, commandType: CommandType.StoredProcedure);

                    return userDetails;
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                _logger.LogError($"MethodName: FindEmployee(int userId) ===>{ex.Message}");
                throw;
            }

        }

        public async Task<Employee> FindEmployee(string? Email)
        {
            
            try
            {
                using (SqlConnection _dapper = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Status", EmployeeStatusGuides.FindEmployeeByEmail);
                    param.Add("@EmployeeEmailGet", Email);

                    var userDetails = await _dapper.QueryFirstOrDefaultAsync<Employee>(_sqlprocedure, param: param, commandType: CommandType.StoredProcedure);

                    return userDetails;
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                _logger.LogError($"MethodName: FindEmployee(string? Email) ===>{ex.Message}");
                throw;
            }
        }

        


        public async Task<IEnumerable<Employee>> GetAllActiveEmployee()
        {
            try
            {
                using (SqlConnection _dapper = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Status", EmployeeStatusGuides.GetAllActiveEmployee);

                    var users = await _dapper.QueryAsync<Employee>(_sqlprocedure, param: param, commandType: CommandType.StoredProcedure);

                    return users;
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                _logger.LogError($"MethodName: GetAllActiveEmployee() ===>{ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            try
            {
                using (SqlConnection _dapper = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Status", EmployeeStatusGuides.GetAllEmployee);

                    var users = await _dapper.QueryAsync<Employee>(_sqlprocedure, param: param, commandType: CommandType.StoredProcedure);

                    return users;
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                _logger.LogError($"MethodName: GetAllEmployee() ===>{ex.Message}");
                throw;
            }
        }





    }

}
