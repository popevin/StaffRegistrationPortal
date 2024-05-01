namespace StaffRegistrationPortal.DTOs
{
    public class LogViewModel
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public int GenderId { get; set; }

        public int DepartmentId { get; set; }

        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? OtherName { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public bool IsActive { get; set; }

        public string? Token { get; set; }
    }
}
