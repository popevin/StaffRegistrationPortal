namespace StaffRegistrationPortal.DTOs
{

    public class DeletedViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string CreatedBy { get; set; }
        public string DeletedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
