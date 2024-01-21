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











}
