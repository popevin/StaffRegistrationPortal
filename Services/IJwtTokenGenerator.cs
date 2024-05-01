using StaffRegistrationPortal.Common;
using StaffRegistrationPortal.DTOs;

namespace StaffRegistrationPortal.Services
{
    public interface IJwtTokenGenerator
    {
    
      
        string? GenerateToken(LogViewModel logdata);

       
    }
}
