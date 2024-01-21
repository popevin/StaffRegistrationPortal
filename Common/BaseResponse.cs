namespace StaffRegistrationPortal.Common
{
    public class BaseResponse
    {
        public string? ResponseCode { get; set; }
        public string? ResponseMessage { get; set; }
        public object? Data { get; set; }
    }
}
