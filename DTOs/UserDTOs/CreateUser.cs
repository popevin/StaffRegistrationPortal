namespace StaffRegistrationPortal.DTOs
{
    public class CreateUser
    {
        //fields to create user
        public int RoleId { get; set; }

        public int GenderId { get; set; }

        public int DepartmentId { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? OtherName { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        //public string? CreatedBy { get; set; }

        //public DateTime CreatedDate { get; set; }
    }
}
