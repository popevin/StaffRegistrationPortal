using StaffRegistrationPortal.Common;

namespace StaffRegistrationPortal.Services
{
    public interface IValidationService
    {
        Task<BaseResponse> ValidateAsync<T>(T request);
    }
}
