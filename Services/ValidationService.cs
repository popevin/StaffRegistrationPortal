using FluentValidation;
using StaffApplication.Services;
using StaffRegistrationPortal.Common;
using StaffRegistrationPortal.Enums;

namespace StaffRegistrationPortal.Services
{
    public class ValidationService : IValidationService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ValidationService> _logger;
        public ValidationService(IServiceProvider serviceProvider, ILogger<ValidationService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;

        }

        public async Task<BaseResponse> ValidateAsync<T>(T request)
        {
            var response = new BaseResponse();
            var validator = _serviceProvider.GetService<IValidator<T>>();
           
            if (validator == null)
            {
                response.ResponseMessage = $"No validator found for {typeof(T).Name}";
                response.ResponseCode= ResponseCode.ValidationError.ToString("D").PadLeft(2, '0');
                response.Data = null;

                return response;
            }

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

                _logger.LogError($"Validation Error ==> {validationMessage}");

              
                response.ResponseCode = ResponseCode.ValidationError.ToString("D").PadLeft(2, '0');
                response.ResponseMessage = $"{validationMessage}";
                response.Data = null;
                
            }

            return response;

        }
    }
}
