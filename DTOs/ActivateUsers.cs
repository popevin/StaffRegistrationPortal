namespace StaffApplication.DTOs
{
    public class ReactivateUser
    {
        public int Id { get; set; }

        public string ReactivateEmail { get; set; }

        public string ReactivatedBy { get; set; }
    }

    public class DeactivateUser
    {
        public int Id { get; set; }

        public string DeactivateEmail { get; set; }


        public string DeactivatedBy { get; set; }

    }


    public class DeactivateViewModel
    {
        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public bool IsDeactivated { get; set; }

        public string? DeactivatedBy { get; set; }

        public DateTime DeactivatedDate { get; set; }
    }



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
