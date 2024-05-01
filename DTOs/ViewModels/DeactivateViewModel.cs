namespace StaffRegistrationPortal.DTOs
{
    public class DeactivateViewModel
    {
        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public bool IsDeactivated { get; set; }

        public string? DeactivatedBy { get; set; }

        public DateTime DeactivatedDate { get; set; }
    }
}
