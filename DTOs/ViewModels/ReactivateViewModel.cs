namespace StaffRegistrationPortal.DTOs
{
    public class ReactivateViewModel
    {
        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public bool IsReactivated { get; set; }

        public string? ReactivatedBy { get; set; }

        public DateTime ReactivatedDate { get; set; }
    }

}
